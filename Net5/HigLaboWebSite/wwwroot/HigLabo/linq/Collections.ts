// -
// Created by Ivan Sanz (@isc30)
// Copyright © 2017 Ivan Sanz Carasa. All rights reserved.
// -

// region IMPORTS
// tslint:disable-next-line:max-line-length

import { Action, Aggregator, Dynamic, Indexer, Predicate, Selector, ZipSelector, Type } from "./Types.js";
import
{
    ArrayEnumerable,
    ConcatEnumerable,
    ConditionalEnumerable,
    Enumerable,
    IEnumerable,
    IGrouping,
    IKeyValue,
    IOrderedEnumerable,
    IQueryable,
    OrderedEnumerable,
    RangeEnumerable,
    ReverseEnumerable,
    TransformEnumerable,
    UniqueEnumerable,
    ZippedEnumerable,
} from "./Enumerables.js";
import { Comparer, EqualityComparer, strictEqualityComparer, createComparer } from "./Comparers.js";

// endregion

// region EnumerableCollection
export abstract class EnumerableCollection<TElement>
    implements IQueryable<TElement>
{
    public abstract copy(): IQueryable<TElement>;
    public abstract asEnumerable(): IEnumerable<TElement>;
    public abstract toArray(): TElement[];

    public toList(): IList<TElement>
    {
        return new List<TElement>(this.toArray());
    }

    public toDictionary<TKey extends Indexer, TValue>(
        keySelector: Selector<TElement, TKey>,
        valueSelector: Selector<TElement, TValue>)
        : IDictionary<TKey, TValue>
    {
        return Dictionary.fromArray(this.toArray(), keySelector, valueSelector);
    }

    public reverse(): IEnumerable<TElement>
    {
        return new ReverseEnumerable<TElement>(this.asEnumerable());
    }

    public concat(
        other: TElement[] | IQueryable<TElement>,
        ...others: Array<TElement[] | IQueryable<TElement>>)
        : IEnumerable<TElement>
    {
        return this.asEnumerable().concat(other, ...others);
    }

    public contains(element: TElement): boolean
    {
        return this.any(e => e === element);
    }

    public where(predicate: Predicate<TElement>): IEnumerable<TElement>
    {
        return new ConditionalEnumerable<TElement>(this.asEnumerable(), predicate);
    }

    public select<TSelectorOut>(selector: Selector<TElement, TSelectorOut>): IEnumerable<TSelectorOut>
    {
        return new TransformEnumerable<TElement, TSelectorOut>(this.asEnumerable(), selector);
    }

    public selectMany<TSelectorOut>(
        selector: Selector<TElement, TSelectorOut[] | List<TSelectorOut> | IEnumerable<TSelectorOut>>)
        : IEnumerable<TSelectorOut>
    {
        const selectToEnumerable = (e: TElement) =>
        {
            const ie = selector(e);

            return ie instanceof Array
                ? new ArrayEnumerable(ie)
                : ie.asEnumerable();
        };

        return this
            .select(selectToEnumerable).toArray()
            .reduce((p, c) => new ConcatEnumerable(p, c), Enumerable.empty()) as IEnumerable<TSelectorOut>;
    }

    public elementAt(index: number): TElement
    {
        const element = this.elementAtOrDefault(index);

        if (element === undefined)
        {
            throw new Error("Out of bounds");
        }

        return element;
    }

    public except(other: IQueryable<TElement>): IEnumerable<TElement>
    {
        return this.asEnumerable().except(other);
    }

    public first(): TElement;
    public first(predicate: Predicate<TElement>): TElement;
    public first(predicate?: Predicate<TElement>): TElement
    {
        let element: TElement | undefined;

        if (predicate !== undefined)
        {
            element = this.firstOrDefault(predicate);
        }
        else
        {
            element = this.firstOrDefault();
        }

        if (element === undefined)
        {
            throw new Error("Sequence contains no elements");
        }

        return element;
    }

    public groupBy<TKey extends Indexer>(
        keySelector: Selector<TElement, TKey>)
        : IEnumerable<IGrouping<TKey, TElement>>;
    public groupBy<TKey extends Indexer, TValue>(
        keySelector: Selector<TElement, TKey>,
        valueSelector: Selector<TElement, TValue>)
        : IEnumerable<IGrouping<TKey, TValue>>;
    public groupBy<TKey extends Indexer, TValue>(
        keySelector: Selector<TElement, TKey>,
        valueSelector?: Selector<TElement, TValue>)
        : IEnumerable<IGrouping<TKey, TElement | TValue>>
    {
        const array = this.toArray();
        const dictionary = new Dictionary<TKey, IQueryable<TElement | TValue>>();

        for (let i = 0; i < array.length; ++i)
        {
            const key = keySelector(array[i]);
            const value = valueSelector !== undefined
                ? valueSelector(array[i])
                : array[i];

            if (!dictionary.containsKey(key))
            {
                dictionary.set(key, new List<TElement | TValue>());
            }

            (dictionary.get(key) as IList<TElement | TValue>).push(value);
        }

        return dictionary.asEnumerable();
    }

    public last(): TElement;
    public last(predicate: Predicate<TElement>): TElement;
    public last(predicate?: Predicate<TElement>): TElement
    {
        let element: TElement | undefined;

        if (predicate !== undefined)
        {
            element = this.lastOrDefault(predicate);
        }
        else
        {
            element = this.lastOrDefault();
        }

        if (element === undefined)
        {
            throw new Error("Sequence contains no elements");
        }

        return element;
    }

    public single(): TElement;
    public single(predicate: Predicate<TElement>): TElement;
    public single(predicate?: Predicate<TElement>): TElement
    {
        let element: TElement | undefined;

        if (predicate !== undefined)
        {
            element = this.singleOrDefault(predicate);
        }
        else
        {
            element = this.singleOrDefault();
        }

        if (element === undefined)
        {
            throw new Error("Sequence contains no elements");
        }

        return element;
    }

    public singleOrDefault(): TElement | undefined;
    public singleOrDefault(predicate: Predicate<TElement>): TElement | undefined;
    public singleOrDefault(predicate?: Predicate<TElement>): TElement | undefined
    {
        if (predicate !== undefined)
        {
            return this.asEnumerable().singleOrDefault(predicate);
        }

        return this.asEnumerable().singleOrDefault();
    }

    public skipWhile(predicate: Predicate<TElement>): IEnumerable<TElement>
    {
        return this.asEnumerable().skipWhile(predicate);
    }

    public takeWhile(predicate: Predicate<TElement>): IEnumerable<TElement>
    {
        return this.asEnumerable().takeWhile(predicate);
    }

    public sequenceEqual(other: IQueryable<TElement> | TElement[]): boolean
    public sequenceEqual(other: IQueryable<TElement> | TElement[], comparer: EqualityComparer<TElement>): boolean;
    public sequenceEqual(other: IQueryable<TElement> | TElement[], comparer?: EqualityComparer<TElement>): boolean
    {
        if (comparer !== undefined)
        {
            return this.asEnumerable().sequenceEqual(other, comparer);
        }

        return this.asEnumerable().sequenceEqual(other);
    }

    public distinct(): IEnumerable<TElement>;
    public distinct<TKey>(keySelector: Selector<TElement, TKey>): IEnumerable<TElement>;
    public distinct<TKey>(keySelector?: Selector<TElement, TKey>): IEnumerable<TElement>
    {
        return new UniqueEnumerable(this.asEnumerable(), keySelector);
    }

    public min(): TElement;
    public min<TSelectorOut>(selector: Selector<TElement, TSelectorOut>): TSelectorOut;
    public min<TSelectorOut>(selector?: Selector<TElement, TSelectorOut>): TElement | TSelectorOut
    {
        if (selector !== undefined)
        {
            // Don't copy iterators
            return new TransformEnumerable<TElement, TSelectorOut>(this.asEnumerable(), selector).min();
        }

        return this.aggregate((previous, current) =>
            (previous !== undefined && previous < current)
                ? previous
                : current);
    }

    public orderBy<TKey>(
        keySelector: Selector<TElement, TKey>): IOrderedEnumerable<TElement>;
    public orderBy<TKey>(
        keySelector: Selector<TElement, TKey>,
        comparer: Comparer<TKey>): IOrderedEnumerable<TElement>;
    public orderBy<TKey>(
        keySelector: Selector<TElement, TKey>,
        comparer?: Comparer<TKey>): IOrderedEnumerable<TElement>
    {
        return new OrderedEnumerable(this.asEnumerable(), createComparer(keySelector, true, comparer));
    }

    public orderByDescending<TKey>(
        keySelector: Selector<TElement, TKey>): IOrderedEnumerable<TElement>
    {
        return new OrderedEnumerable(this.asEnumerable(), createComparer(keySelector, false, undefined));
    }

    public max(): TElement;
    public max<TSelectorOut>(selector: Selector<TElement, TSelectorOut>): TSelectorOut;
    public max<TSelectorOut>(selector?: Selector<TElement, TSelectorOut>): TElement | TSelectorOut
    {
        if (selector !== undefined)
        {
            // Don't copy iterators
            return new TransformEnumerable<TElement, TSelectorOut>(this.asEnumerable(), selector).max();
        }

        return this.aggregate((previous, current) =>
            (previous !== undefined && previous > current)
                ? previous
                : current);
    }

    public sum(selector: Selector<TElement, number>): number
    {
        return this.aggregate(
            (previous: number, current: TElement) => previous + selector(current), 0);
    }

    public skip(amount: number): IEnumerable<TElement>
    {
        return new RangeEnumerable<TElement>(this.asEnumerable(), amount, undefined);
    }

    public take(amount: number): IEnumerable<TElement>
    {
        return new RangeEnumerable<TElement>(this.asEnumerable(), undefined, amount);
    }

    public union(other: IQueryable<TElement>): IEnumerable<TElement>
    {
        return new UniqueEnumerable(this.concat(other));
    }

    public aggregate(aggregator: Aggregator<TElement, TElement | undefined>): TElement;
    public aggregate<TValue>(aggregator: Aggregator<TElement, TValue>, initialValue: TValue): TValue;
    public aggregate<TValue>(
        aggregator: Aggregator<TElement, TValue | TElement | undefined>,
        initialValue?: TValue): TValue | TElement
    {
        if (initialValue !== undefined)
        {
            return this.asEnumerable().aggregate(
                aggregator as Aggregator<TElement, TValue>,
                initialValue);
        }

        return this.asEnumerable().aggregate(
            aggregator as Aggregator<TElement, TElement | undefined>);
    }

    public any(): boolean;
    public any(predicate: Predicate<TElement>): boolean;
    public any(predicate?: Predicate<TElement>): boolean
    {
        if (predicate !== undefined)
        {
            return this.asEnumerable().any(predicate);
        }

        return this.asEnumerable().any();
    }

    public all(predicate: Predicate<TElement>): boolean
    {
        return this.asEnumerable().all(predicate);
    }

    public average(selector: Selector<TElement, number>): number
    {
        return this.asEnumerable().average(selector);
    }

    public count(): number;
    public count(predicate: Predicate<TElement>): number;
    public count(predicate?: Predicate<TElement>): number
    {
        if (predicate !== undefined)
        {
            return this.asEnumerable().count(predicate);
        }

        return this.asEnumerable().count();
    }

    public elementAtOrDefault(index: number): TElement | undefined
    {
        return this.asEnumerable().elementAtOrDefault(index);
    }

    public firstOrDefault(): TElement | undefined;
    public firstOrDefault(predicate: Predicate<TElement>): TElement | undefined;
    public firstOrDefault(predicate?: Predicate<TElement>): TElement | undefined
    {
        if (predicate !== undefined)
        {
            return this.asEnumerable().firstOrDefault(predicate);
        }

        return this.asEnumerable().firstOrDefault();
    }

    public lastOrDefault(): TElement | undefined;
    public lastOrDefault(predicate: Predicate<TElement>): TElement | undefined;
    public lastOrDefault(predicate?: Predicate<TElement>): TElement | undefined
    {
        if (predicate !== undefined)
        {
            return this.asEnumerable().lastOrDefault(predicate);
        }

        return this.asEnumerable().lastOrDefault();
    }

    public forEach(action: Action<TElement>): void
    {
        return this.asEnumerable().forEach(action);
    }

    public defaultIfEmpty(): IEnumerable<TElement | undefined>;
    public defaultIfEmpty(defaultValue: TElement): IEnumerable<TElement>;
    public defaultIfEmpty(defaultValue?: TElement): IEnumerable<TElement | undefined>
    {
        if (defaultValue !== undefined)
        {
            return this.asEnumerable().defaultIfEmpty(defaultValue);
        }

        return this.asEnumerable().defaultIfEmpty();
    }

    public zip<TOther, TSelectorOut>(other: IQueryable<TOther> | TOther[], selector: ZipSelector<TElement, TOther, TSelectorOut>): IEnumerable<TSelectorOut>
    {
        return this.asEnumerable().zip(other, selector);
    }
}
// endregion
// region ArrayQueryable
export abstract class ArrayQueryable<TElement>
    extends EnumerableCollection<TElement>
{
    protected source: TElement[];

    public abstract copy(): IQueryable<TElement>;

    public constructor();
    public constructor(elements: TElement[])
    public constructor(elements: TElement[] = [])
    {
        super();
        this.source = elements;
    }

    public asArray(): TElement[]
    {
        return this.source;
    }

    public toArray(): TElement[]
    {
        return ([] as TElement[]).concat(this.source);
    }

    public toList(): IList<TElement>
    {
        return new List<TElement>(this.toArray());
    }

    public asEnumerable(): IEnumerable<TElement>
    {
        return new ArrayEnumerable(this.source);
    }

    public aggregate(aggregator: Aggregator<TElement, TElement | undefined>): TElement;
    public aggregate<TValue>(aggregator: Aggregator<TElement, TValue>, initialValue: TValue): TValue;
    public aggregate<TValue>(
        aggregator: Aggregator<TElement, TValue | TElement | undefined>,
        initialValue?: TValue): TValue | TElement
    {
        if (initialValue !== undefined)
        {
            return this.source.reduce(
                aggregator as Aggregator<TElement, TValue>,
                initialValue);
        }

        return this.source.reduce(aggregator as Aggregator<TElement, TElement>);
    }

    public any(): boolean;
    public any(predicate: Predicate<TElement>): boolean;
    public any(predicate?: Predicate<TElement>): boolean
    {
        if (predicate !== undefined)
        {
            return this.source.some(predicate);
        }

        return this.source.length > 0;
    }

    public all(predicate: Predicate<TElement>): boolean
    {
        return this.source.every(predicate);
    }

    public average(selector: Selector<TElement, number>): number
    {
        if (this.count() === 0)
        {
            throw new Error("Sequence contains no elements");
        }

        let sum = 0;

        for (let i = 0, end = this.source.length; i < end; ++i)
        {
            sum += selector(this.source[i]);
        }

        return sum / this.source.length;
    }

    public count(): number;
    public count(predicate: Predicate<TElement>): number;
    public count(predicate?: Predicate<TElement>): number
    {
        if (predicate !== undefined)
        {
            return this.source.filter(predicate).length;
        }

        return this.source.length;
    }

    public elementAtOrDefault(index: number): TElement | undefined
    {
        if (index < 0)
        {
            throw new Error("Negative index is forbiden");
        }

        return this.source[index];
    }

    public firstOrDefault(): TElement | undefined;
    public firstOrDefault(predicate: Predicate<TElement>): TElement | undefined;
    public firstOrDefault(predicate?: Predicate<TElement>): TElement | undefined
    {
        if (predicate !== undefined)
        {
            return this.source.filter(predicate)[0];
        }

        return this.source[0];
    }

    public groupBy<TKey extends Indexer>(
        keySelector: Selector<TElement, TKey>)
        : IEnumerable<IGrouping<TKey, TElement>>;
    public groupBy<TKey extends Indexer, TValue>(
        keySelector: Selector<TElement, TKey>,
        valueSelector: Selector<TElement, TValue>)
        : IEnumerable<IGrouping<TKey, TValue>>;
    public groupBy<TKey extends Indexer, TValue>(
        keySelector: Selector<TElement, TKey>,
        valueSelector?: Selector<TElement, TValue>)
        : IEnumerable<IGrouping<TKey, TElement | TValue>>
    {
        const array = this.asArray();
        const dictionary = new Dictionary<TKey, IQueryable<TElement | TValue>>();

        for (let i = 0; i < array.length; ++i)
        {
            const key = keySelector(array[i]);
            const value = valueSelector !== undefined
                ? valueSelector(array[i])
                : array[i];

            if (!dictionary.containsKey(key))
            {
                dictionary.set(key, new List<TElement | TValue>());
            }

            (dictionary.get(key) as IList<TElement | TValue>).push(value);
        }

        return dictionary.asEnumerable();
    }

    public lastOrDefault(): TElement | undefined;
    public lastOrDefault(predicate: Predicate<TElement>): TElement | undefined;
    public lastOrDefault(predicate?: Predicate<TElement>): TElement | undefined
    {
        if (predicate !== undefined)
        {
            const records = this.source.filter(predicate);

            return records[records.length - 1];
        }

        return this.source[this.source.length - 1];
    }

    public forEach(action: Action<TElement>): void
    {
        for (let i = 0, end = this.source.length; i < end; ++i)
        {
            action(this.source[i], i);
        }
    }

    public sequenceEqual(other: IQueryable<TElement> | TElement[]): boolean;
    public sequenceEqual(other: IQueryable<TElement> | TElement[], comparer: EqualityComparer<TElement>): boolean;
    public sequenceEqual(other: IQueryable<TElement> | TElement[], comparer: EqualityComparer<TElement> = strictEqualityComparer<TElement>()): boolean
    {
        if (other instanceof ArrayQueryable
            || other instanceof Array)
        {
            const thisArray = this.asArray();
            const otherArray = other instanceof ArrayQueryable
                ? other.asArray() as TElement[]
                : other;

            if (thisArray.length != otherArray.length)
            {
                return false;
            }

            for (let i = 0; i < thisArray.length; ++i)
            {
                if (!comparer(thisArray[i], otherArray[i]))
                {
                    return false;
                }
            }

            return true;
        }

        return this.asEnumerable().sequenceEqual(other, comparer);
    }
}
// endregion
// region List
export interface IReadOnlyList<TElement>
    extends IQueryable<TElement>
{
    copy(): IList<TElement>;

    get(index: number): TElement | undefined;

    indexOf(element: TElement): number;
}

export interface IList<TElement>
    extends IReadOnlyList<TElement>
{
    asReadOnly(): IReadOnlyList<TElement>;
    asArray(): TElement[];
    clear(): void;
    push(element: TElement): number;
    pushRange(elements: TElement[] | IQueryable<TElement>): number;
    pushFront(element: TElement): number;
    pop(): TElement | undefined;
    popFront(): TElement | undefined;
    remove(element: TElement): void;
    removeAt(index: number): TElement | undefined;
    set(index: number, element: TElement): void;
    insert(index: number, element: TElement): void;
    sort(comparerList: Comparer<TElement>[]): void;
}

export class List<TElement>
    extends ArrayQueryable<TElement>
    implements IList<TElement>
{
    public copy(): IList<TElement>
    {
        return new List<TElement>(this.toArray());
    }

    public asReadOnly(): IReadOnlyList<TElement>
    {
        return this;
    }

    public clear(): void
    {
        this.source = [];
    }

    public remove(element: TElement): void
    {
        const newSource: TElement[] = [];

        for (let i = 0, end = this.source.length; i < end; ++i)
        {
            if (this.source[i] !== element)
            {
                newSource.push(this.source[i]);
            }
        }

        this.source = newSource;
    }

    public removeAt(index: number): TElement | undefined
    {
        if (index < 0 || this.source[index] === undefined)
        {
            throw new Error("Out of bounds");
        }

        return this.source.splice(index, 1)[0];
    }

    public get(index: number): TElement | undefined
    {
        return this.source[index];
    }

    public push(element: TElement): number
    {
        return this.source.push(element);
    }

    public pushIfNotExists(element: TElement, selector: Selector<TElement, boolean>): number {
        const r = this.firstOrDefault(selector);
        if (r == null) {
            return this.source.push(element);
        }
        else {
            return this.source.length;
        }
    }

    public pushRange(elements: TElement[] | IQueryable<TElement>): number
    {
        if (!(elements instanceof Array))
        {
            elements = elements.toArray();
        }

        return this.source.push.apply(this.source, elements);
    }

    public pushFront(element: TElement): number
    {
        return this.source.unshift(element);
    }

    public replace(element: TElement, selector: Selector<TElement, boolean>): number {
        for (var i = 0; i < this.source.length; i++) {
            if (selector(this.source[i]) == true) {
                this.source[i] = element;
                return i;
            }
        }
        return this.source.push(element);
    }

    public pop(): TElement | undefined
    {
        return this.source.pop();
    }

    public popFront(): TElement | undefined
    {
        return this.source.shift();
    }

    public set(index: number, element: TElement): void
    {
        if (index < 0)
        {
            throw new Error("Out of bounds");
        }

        this.source[index] = element;
    }

    public insert(index: number, element: TElement): void
    {
        if (index < 0 || index > this.source.length)
        {
            throw new Error("Out of bounds");
        }

        this.source.splice(index, 0, element);
    }

    public indexOf(element: TElement): number
    {
        return this.source.indexOf(element);
    }

    public sort(comparerList: Comparer<TElement>[]): void {
        this.asArray().sort((x, y) => {
            for (var i = 0; i < comparerList.length; i++) {
                let comparer = comparerList[i];
                let result = comparer(x, y);
                if (result != 0) { return result; }
            }
            return 0;
        });
    }
}
// endregion
// region Stack
export interface IStack<TElement>
    extends IQueryable<TElement>
{
    copy(): IStack<TElement>;

    asArray(): TElement[];
    clear(): void;
    peek(): TElement | undefined;
    pop(): TElement | undefined;
    push(element: TElement): number;
}

export class Stack<TElement>
    extends ArrayQueryable<TElement>
    implements IStack<TElement>
{
    public copy(): IStack<TElement>
    {
        return new Stack<TElement>(this.toArray());
    }

    public clear(): void
    {
        this.source = [];
    }

    public peek(): TElement | undefined
    {
        return this.source[this.source.length - 1];
    }

    public pop(): TElement | undefined
    {
        return this.source.pop();
    }

    public push(element: TElement): number
    {
        return this.source.push(element);
    }
}
// endregion
// region Dictionary 
export interface IReadOnlyDictionary<TKey extends Indexer, TValue>
    extends IQueryable<IKeyValue<TKey, TValue>>
{
    copy(): IDictionary<TKey, TValue>;

    containsKey(key: TKey): boolean;
    containsValue(value: TValue): boolean;
    getKeys(): IList<TKey>;
    getValues(): IList<TValue>;

    get(key: TKey): TValue;
}

export interface IDictionary<TKey extends Indexer, TValue>
    extends IReadOnlyDictionary<TKey, TValue>
{
    asReadOnly(): IReadOnlyDictionary<TKey, TValue>;
    clear(): void;
    remove(key: TKey): void;
    set(key: TKey, value: TValue): void;
    setOrUpdate(key: TKey, value: TValue): void;
}

export class Dictionary<TKey extends Indexer, TValue>
    extends EnumerableCollection<IKeyValue<TKey, TValue>>
    implements IDictionary<TKey, TValue>
{
    public static fromArray<TArray, TKey extends Indexer, TValue>(
        array: TArray[],
        keySelector: Selector<TArray, TKey>,
        valueSelector: Selector<TArray, TValue>)
        : IDictionary<TKey, TValue>
    {
        const keyValuePairs = array.map<IKeyValue<TKey, TValue>>(v =>
        {
            return {
                key: keySelector(v),
                value: valueSelector(v),
            };
        });

        return new Dictionary(keyValuePairs);
    }

    public static fromJsObject<TValue = string>(
        object: Dynamic)
        : IDictionary<string, TValue>
    {
        const keys = new List(Object.getOwnPropertyNames(object));
        const keyValues = keys.select(k => <IKeyValue<string, TValue>>{ key: k, value: object[k] });

        return new Dictionary(keyValues.toArray());
    }

    protected dictionary: Dynamic;
    protected keyType: Type;

    public constructor();
    public constructor(keyValuePairs: Array<IKeyValue<TKey, TValue>>);
    public constructor(keyValuePairs?: Array<IKeyValue<TKey, TValue>>)
    {
        super();
        this.clear();

        if (keyValuePairs !== undefined)
        {
            for (let i = 0; i < keyValuePairs.length; ++i)
            {
                const pair = keyValuePairs[i];
                this.set(pair.key, pair.value);
            }
        }
    }

    public copy(): IDictionary<TKey, TValue>
    {
        return new Dictionary<TKey, TValue>(this.toArray());
    }

    public asReadOnly(): IReadOnlyDictionary<TKey, TValue>
    {
        return this;
    }

    public asEnumerable(): IEnumerable<IKeyValue<TKey, TValue>>
    {
        return new ArrayEnumerable(this.toArray());
    }

    public toArray(): Array<IKeyValue<TKey, TValue>>
    {
        return this.getKeys().select<IKeyValue<TKey, TValue>>(p =>
        {
            return {
                key: p,
                value: this.dictionary[p],
            };
        }).toArray();
    }

    public clear(): void
    {
        this.dictionary = {};
    }

    public containsKey(key: TKey): boolean
    {
        return this.dictionary.hasOwnProperty(key);
    }

    public containsValue(value: TValue): boolean
    {
        const keys = this.getKeysFast();

        for (let i = 0; i < keys.length; ++i)
        {
            if (this.dictionary[keys[i]] === value)
            {
                return true;
            }
        }

        return false;
    }

    public getKeys(): IList<TKey>
    {
        const keys = this.getKeysFast();

        return new List(keys.map(
            k => this.keyType === "number"
                ? parseFloat(k)
                : k) as TKey[]);
    }

    protected getKeysFast(): string[]
    {
        return Object.getOwnPropertyNames(this.dictionary);
    }

    public getValues(): IList<TValue>
    {
        const keys = this.getKeysFast();
        const result = new Array<TValue>(keys.length);

        for (let i = 0; i < keys.length; ++i)
        {
            result[i] = this.dictionary[keys[i]];
        }

        return new List(result);
    }

    public remove(key: TKey): void
    {
        if (this.containsKey(key))
        {
            delete this.dictionary[key];
        }
    }

    public get(key: TKey): TValue
    {
        if (!this.containsKey(key))
        {
            throw new Error(`Key doesn't exist: ${key}`)
        }

        return this.dictionary[key];
    }

    public set(key: TKey, value: TValue): void
    {
        if (this.containsKey(key))
        {
            throw new Error(`Key already exists: ${key}`);
        }

        this.setOrUpdate(key, value);
    }

    public setOrUpdate(key: TKey, value: TValue): void
    {
        if (this.keyType === undefined)
        {
            this.keyType = typeof key;
        }

        this.dictionary[key] = value;
    }
}
// endregion
