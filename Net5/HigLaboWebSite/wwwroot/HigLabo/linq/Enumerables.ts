// -
// Created by Ivan Sanz (@isc30)
// Copyright © 2017 Ivan Sanz Carasa. All rights reserved.
// -

// region IMPORTS

import { Action, Aggregator, Dynamic, Indexer, Predicate, Selector, ZipSelector } from "./Types.js";
import { ArrayIterator, IIterable } from "./Iterators.js";
import { Comparer, EqualityComparer, strictEqualityComparer, combineComparers, createComparer } from "./Comparers.js";
import { Dictionary, IDictionary, IList, List } from "./Collections.js";

import { Cached } from "./Utils.js";

// endregion

// region Interfaces
export interface IKeyValue<TKey, TValue>
{
    key: TKey;
    value: TValue;
}

export type IGrouping<TKey, TElement> = IKeyValue<TKey, IQueryable<TElement>>;

export interface IQueryable<TOut>
{
    copy(): IQueryable<TOut>;

    asEnumerable(): IEnumerable<TOut>;
    toArray(): TOut[];
    toList(): IList<TOut>;
    toDictionary<TKey extends Indexer, TValue>(
        keySelector: Selector<TOut, TKey>,
        valueSelector: Selector<TOut, TValue>)
        : IDictionary<TKey, TValue>;
    // toLookup

    aggregate(aggregator: Aggregator<TOut, TOut | undefined>): TOut;
    aggregate<TValue>(aggregator: Aggregator<TOut, TValue>, initialValue: TValue): TValue;

    all(predicate: Predicate<TOut>): boolean;

    any(): boolean;
    any(predicate: Predicate<TOut>): boolean;

    average(selector: Selector<TOut, number>): number;

    concat(
        other: TOut[] | IQueryable<TOut>,
        ...others: Array<TOut[] | IQueryable<TOut>>)
        : IEnumerable<TOut>;

    contains(element: TOut): boolean;

    count(): number;
    count(predicate: Predicate<TOut>): number;

    defaultIfEmpty(): IEnumerable<TOut | undefined>;
    defaultIfEmpty(defaultValue: TOut): IEnumerable<TOut>;

    distinct(): IEnumerable<TOut>;
    distinct<TKey>(keySelector: Selector<TOut, TKey>): IEnumerable<TOut>;

    elementAt(index: number): TOut;

    elementAtOrDefault(index: number): TOut | undefined;

    except(other: IQueryable<TOut>): IEnumerable<TOut>;

    first(): TOut;
    first(predicate: Predicate<TOut>): TOut;

    firstOrDefault(): TOut | undefined;
    firstOrDefault(predicate: Predicate<TOut>): TOut | undefined;

    forEach(action: Action<TOut>): void;

    groupBy<TKey extends Indexer>(
        keySelector: Selector<TOut, TKey>)
        : IEnumerable<IGrouping<TKey, TOut>>;
    groupBy<TKey extends Indexer, TValue>(
        keySelector: Selector<TOut, TKey>,
        valueSelector: Selector<TOut, TValue>)
        : IEnumerable<IGrouping<TKey, TValue>>;

    // groupJoin

    // intersect

    // join

    last(): TOut;
    last(predicate: Predicate<TOut>): TOut;

    lastOrDefault(): TOut | undefined;
    lastOrDefault(predicate: Predicate<TOut>): TOut | undefined;

    // longCount

    max(): TOut;
    max<TSelectorOut>(selector: Selector<TOut, TSelectorOut>): TSelectorOut;

    min(): TOut;
    min<TSelectorOut>(selector: Selector<TOut, TSelectorOut>): TSelectorOut;

    orderBy<TKey>(
        keySelector: Selector<TOut, TKey>): IOrderedEnumerable<TOut>;
    orderBy<TKey>(
        keySelector: Selector<TOut, TKey>,
        comparer: Comparer<TKey>): IOrderedEnumerable<TOut>;

    orderByDescending<TKey>(
        keySelector: Selector<TOut, TKey>): IOrderedEnumerable<TOut>;

    reverse(): IEnumerable<TOut>;

    select<TSelectorOut>(selector: Selector<TOut, TSelectorOut>): IEnumerable<TSelectorOut>;

    selectMany<TSelectorOut>(
        selector: Selector<TOut, TSelectorOut[] | IQueryable<TSelectorOut>>)
        : IEnumerable<TSelectorOut>;

    sequenceEqual(other: IQueryable<TOut> | TOut[]): boolean;
    sequenceEqual(other: IQueryable<TOut> | TOut[], comparer: EqualityComparer<TOut>): boolean;

    single(): TOut;
    single(predicate: Predicate<TOut>): TOut;

    singleOrDefault(): TOut | undefined;
    singleOrDefault(predicate: Predicate<TOut>): TOut | undefined;

    skip(amount: number): IEnumerable<TOut>;

    skipWhile(predicate: Predicate<TOut>): IEnumerable<TOut>;

    sum(selector: Selector<TOut, number>): number;

    take(amount: number): IEnumerable<TOut>;

    takeWhile(predicate: Predicate<TOut>): IEnumerable<TOut>;

    union(other: IQueryable<TOut>): IEnumerable<TOut>;

    where(predicate: Predicate<TOut>): IEnumerable<TOut>;

    zip<TOther, TSelectorOut>(other: IQueryable<TOther> | TOther[], selector: ZipSelector<TOut, TOther, TSelectorOut>): IEnumerable<TSelectorOut>;
}

export interface IEnumerable<TOut> extends IQueryable<TOut>, IIterable<TOut>
{
    copy(): IEnumerable<TOut>;
}

export interface IOrderedEnumerable<TOut> extends IEnumerable<TOut>
{
    copy(): IOrderedEnumerable<TOut>;

    thenBy<TKey>(
        keySelector: Selector<TOut, TKey>): IOrderedEnumerable<TOut>;
    thenBy<TKey>(
        keySelector: Selector<TOut, TKey>,
        comparer: Comparer<TKey>): IOrderedEnumerable<TOut>;

    thenByDescending<TKey>(keySelector: Selector<TOut, TKey>): IOrderedEnumerable<TOut>;
}
// endregion
// region EnumerableBase
export abstract class EnumerableBase<TElement, TOut> implements IEnumerable<TOut>
{

    protected readonly source: IIterable<TElement> | IEnumerable<TElement>;

    protected constructor(source: IIterable<TElement>)
    {
        this.source = source;
    }

    public abstract copy(): IEnumerable<TOut>;
    public abstract value(): TOut;

    public reset(): void
    {
        this.source.reset();
    }

    public next(): boolean
    {
        return this.source.next();
    }

    public asEnumerable(): IEnumerable<TOut>
    {
        return this;
    }

    public toArray(): TOut[]
    {
        const result: TOut[] = [];
        this.reset();

        while (this.next())
        {
            result.push(this.value());
        }

        return result;
    }

    public toList(): IList<TOut>
    {
        return new List<TOut>(this.toArray());
    }

    public toDictionary<TKey extends Indexer, TValue>(
        keySelector: Selector<TOut, TKey>,
        valueSelector: Selector<TOut, TValue>)
        : IDictionary<TKey, TValue>
    {
        return Dictionary.fromArray(this.toArray(), keySelector, valueSelector);
    }

    public count(): number;
    public count(predicate: Predicate<TOut>): number;
    public count(predicate?: Predicate<TOut>): number
    {
        if (predicate !== undefined)
        {
            // Don't copy iterators
            return new ConditionalEnumerable<TOut>(this, predicate).count();
        }

        let result: number = 0;
        this.reset();

        while (this.next())
        {
            ++result;
        }

        // tslint:disable-next-line:no-bitwise
        return result >>> 0;
    }

    public any(): boolean;
    public any(predicate: Predicate<TOut>): boolean;
    public any(predicate?: Predicate<TOut>): boolean
    {
        if (predicate !== undefined)
        {
            // Don't copy iterators
            return new ConditionalEnumerable<TOut>(this, predicate).any();
        }

        this.reset();

        return this.next();
    }

    public all(predicate: Predicate<TOut>): boolean
    {
        this.reset();

        while (this.next())
        {
            if (!predicate(this.value()))
            {
                return false;
            }
        }

        return true;
    }

    public reverse(): IEnumerable<TOut>
    {
        return new ReverseEnumerable<TOut>(this.copy());
    }

    public contains(element: TOut): boolean
    {
        return this.any(e => e === element);
    }

    public sequenceEqual(other: IQueryable<TOut> | TOut[]): boolean;
    public sequenceEqual(other: IQueryable<TOut> | TOut[], comparer: EqualityComparer<TOut>): boolean;
    public sequenceEqual(other: IQueryable<TOut> | TOut[], comparer: EqualityComparer<TOut> = strictEqualityComparer<TOut>()): boolean
    {
        const otherEnumerable = other instanceof Array
            ? new ArrayEnumerable(other)
            : other.asEnumerable();

        this.reset();
        otherEnumerable.reset();

        while (this.next())
        {
            if (!otherEnumerable.next() || !comparer(this.value(), otherEnumerable.value()))
            {
                return false;
            }
        }

        return !otherEnumerable.next();
    }

    public where(predicate: Predicate<TOut>): IEnumerable<TOut>
    {
        return new ConditionalEnumerable<TOut>(this.copy(), predicate);
    }

    public select<TSelectorOut>(selector: Selector<TOut, TSelectorOut>): IEnumerable<TSelectorOut>
    {
        return new TransformEnumerable<TOut, TSelectorOut>(this.copy(), selector);
    }

    public selectMany<TSelectorOut>(
        selector: Selector<TOut, TSelectorOut[] | IQueryable<TSelectorOut>>)
        : IEnumerable<TSelectorOut>
    {
        const selectToEnumerable = (e: TOut) =>
        {
            const ie = selector(e);

            return Array.isArray(ie)
                ? new ArrayEnumerable(ie)
                : ie.asEnumerable();
        };

        return this
            .select(selectToEnumerable).toArray()
            .reduce((p, c) => new ConcatEnumerable(p, c), Enumerable.empty()) as IEnumerable<TSelectorOut>;
    }

    public skipWhile(predicate: Selector<TOut, boolean>): IEnumerable<TOut>
    {
        return new SkipWhileEnumerable(this.copy(), predicate);
    }

    public concat(
        other: TOut[] | IQueryable<TOut>,
        ...others: Array<TOut[] | IQueryable<TOut>>)
        : IEnumerable<TOut>
    {
        const asEnumerable = (e: TOut[] | IQueryable<TOut>): IIterable<TOut> =>
        {
            return e instanceof Array
                ? new ArrayEnumerable(e)
                : e.asEnumerable();
        };

        let result = new ConcatEnumerable<TOut>(this.copy(), asEnumerable(other).copy());

        for (let i = 0, end = others.length; i < end; ++i)
        {
            result = new ConcatEnumerable<TOut>(result, asEnumerable(others[i]).copy());
        }

        return result;
    }

    public defaultIfEmpty(): IEnumerable<TOut | undefined>;
    public defaultIfEmpty(defaultValue: TOut): IEnumerable<TOut>;
    public defaultIfEmpty(defaultValue?: TOut): IEnumerable<TOut | undefined>
    {
        return new DefaultIfEmptyEnumerable<TOut>(this, defaultValue);
    }

    public elementAt(index: number): TOut
    {
        const element = this.elementAtOrDefault(index);

        if (element === undefined)
        {
            throw new Error("Out of bounds");
        }

        return element;
    }

    public elementAtOrDefault(index: number): TOut | undefined
    {
        if (index < 0)
        {
            throw new Error("Negative index is forbiden");
        }

        this.reset();

        let currentIndex = -1;

        while (this.next())
        {
            ++currentIndex;

            if (currentIndex === index)
            {
                break;
            }
        }

        if (currentIndex !== index)
        {
            return undefined;
        }

        return this.value();
    }

    public except(other: IQueryable<TOut>): IEnumerable<TOut>
    {
        return this.where(e => !other.contains(e));
    }

    public first(): TOut;
    public first(predicate: Predicate<TOut>): TOut;
    public first(predicate?: Predicate<TOut>): TOut
    {
        let element: TOut | undefined;

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

    public firstOrDefault(): TOut | undefined;
    public firstOrDefault(predicate: Predicate<TOut>): TOut | undefined;
    public firstOrDefault(predicate?: Predicate<TOut>): TOut | undefined
    {
        if (predicate !== undefined)
        {
            // Don't copy iterators
            return new ConditionalEnumerable<TOut>(this, predicate).firstOrDefault();
        }

        this.reset();

        if (!this.next())
        {
            return undefined;
        }

        return this.value();
    }

    public forEach(action: Action<TOut>): void
    {
        this.reset();

        for (let i = 0; this.next(); ++i)
        {
            action(this.value(), i);
        }
    }

    groupBy<TKey extends Indexer>(
        keySelector: Selector<TOut, TKey>)
        : IEnumerable<IGrouping<TKey, TOut>>;
    groupBy<TKey extends Indexer, TValue>(
        keySelector: Selector<TOut, TKey>,
        valueSelector: Selector<TOut, TValue>)
        : IEnumerable<IGrouping<TKey, TValue>>;
    groupBy<TKey extends Indexer, TValue>(
        keySelector: Selector<TOut, TKey>,
        valueSelector?: Selector<TOut, TValue>)
        : IEnumerable<IGrouping<TKey, TOut | TValue>>
    {
        const array = this.toArray();
        const dictionary = new Dictionary<TKey, IQueryable<TOut | TValue>>();

        for (let i = 0; i < array.length; ++i)
        {
            const key = keySelector(array[i]);
            const value = valueSelector !== undefined
                ? valueSelector(array[i])
                : array[i];

            if (!dictionary.containsKey(key))
            {
                dictionary.set(key, new List<TOut | TValue>());
            }

            (dictionary.get(key) as IList<TOut | TValue>).push(value);
        }

        return dictionary.asEnumerable();
    }

    public last(): TOut;
    public last(predicate: Predicate<TOut>): TOut;
    public last(predicate?: Predicate<TOut>): TOut
    {
        let element: TOut | undefined;

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

    public lastOrDefault(): TOut | undefined;
    public lastOrDefault(predicate: Predicate<TOut>): TOut | undefined;
    public lastOrDefault(predicate?: Predicate<TOut>): TOut | undefined
    {
        if (predicate !== undefined)
        {
            // Don't copy iterators
            return new ConditionalEnumerable<TOut>(this, predicate).lastOrDefault();
        }

        const reversed = new ReverseEnumerable<TOut>(this);
        reversed.reset();

        if (!reversed.next())
        {
            return undefined;
        }

        return reversed.value();
    }

    public single(): TOut;
    public single(predicate: Predicate<TOut>): TOut;
    public single(predicate?: Predicate<TOut>): TOut
    {
        let element: TOut | undefined;

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

    public singleOrDefault(): TOut | undefined;
    public singleOrDefault(predicate: Predicate<TOut>): TOut | undefined;
    public singleOrDefault(predicate?: Predicate<TOut>): TOut | undefined
    {
        if (predicate !== undefined)
        {
            // Don't copy iterators
            return new ConditionalEnumerable<TOut>(this, predicate).singleOrDefault();
        }

        this.reset();

        if (!this.next())
        {
            return undefined;
        }

        const element = this.value();

        if (this.next())
        {
            throw new Error("Sequence contains more than 1 element");
        }

        return element;
    }

    public distinct(): IEnumerable<TOut>;
    public distinct<TKey>(keySelector: Selector<TOut, TKey>): IEnumerable<TOut>;
    public distinct<TKey>(keySelector?: Selector<TOut, TKey>): IEnumerable<TOut>
    {
        return new UniqueEnumerable(this.copy(), keySelector);
    }

    public aggregate(aggregator: Aggregator<TOut, TOut | undefined>): TOut;
    public aggregate<TValue>(aggregator: Aggregator<TOut, TValue>, initialValue: TValue): TValue;
    public aggregate<TValue>(aggregator: Aggregator<TOut, TValue>, initialValue?: TValue): TValue
    {
        let value = initialValue;

        this.reset();

        if (initialValue === undefined)
        {
            if (!this.next())
            {
                throw new Error("Sequence contains no elements");
            }

            value = aggregator(value as TValue, this.value());
        }

        while (this.next())
        {
            value = aggregator(value as TValue, this.value());
        }

        return value as TValue;
    }

    public min(): TOut;
    public min<TSelectorOut>(selector: Selector<TOut, TSelectorOut>): TSelectorOut;
    public min<TSelectorOut>(selector?: Selector<TOut, TSelectorOut>): TOut | TSelectorOut
    {
        if (selector !== undefined)
        {
            // Don't copy iterators
            return new TransformEnumerable<TOut, TSelectorOut>(this, selector).min();
        }

        return this.aggregate((previous, current) =>
            (previous !== undefined && previous < current)
                ? previous
                : current);
    }

    public orderBy<TKey>(
        keySelector: Selector<TOut, TKey>): IOrderedEnumerable<TOut>;
    public orderBy<TKey>(
        keySelector: Selector<TOut, TKey>,
        comparer: Comparer<TKey>): IOrderedEnumerable<TOut>;
    public orderBy<TKey>(
        keySelector: Selector<TOut, TKey>,
        comparer?: Comparer<TKey>): IOrderedEnumerable<TOut>
    {
        return new OrderedEnumerable(this.copy(), createComparer(keySelector, true, comparer));
    }

    public orderByDescending<TKey>(
        keySelector: Selector<TOut, TKey>): IOrderedEnumerable<TOut>
    {
        return new OrderedEnumerable(this.copy(), createComparer(keySelector, false, undefined));
    }

    public max(): TOut;
    public max<TSelectorOut>(selector: Selector<TOut, TSelectorOut>): TSelectorOut;
    public max<TSelectorOut>(selector?: Selector<TOut, TSelectorOut>): TOut | TSelectorOut
    {
        if (selector !== undefined)
        {
            // Don't copy iterators
            return new TransformEnumerable<TOut, TSelectorOut>(this, selector).max();
        }

        return this.aggregate((previous, current) =>
            (previous !== undefined && previous > current)
                ? previous
                : current);
    }

    public sum(selector: Selector<TOut, number>): number
    {
        return this.aggregate(
            (previous: number, current: TOut) => previous + selector(current), 0);
    }

    public average(selector: Selector<TOut, number>): number
    {
        this.reset();

        if (!this.next())
        {
            throw new Error("Sequence contains no elements");
        }

        let sum = 0;
        let count = 0;

        do
        {
            sum += selector(this.value());
            ++count;
        }
        while (this.next());

        return sum / count;
    }

    public skip(amount: number): IEnumerable<TOut>
    {
        return new RangeEnumerable<TOut>(this.copy(), amount, undefined);
    }

    public take(amount: number): IEnumerable<TOut>
    {
        return new RangeEnumerable<TOut>(this.copy(), undefined, amount);
    }

    public takeWhile(predicate: Predicate<TOut>): IEnumerable<TOut>
    {
        return new TakeWhileEnumerable(this.copy(), predicate);
    }

    public union(other: IQueryable<TOut>): IEnumerable<TOut>
    {
        return new UniqueEnumerable(this.concat(other));
    }

    public zip<TOther, TSelectorOut>(other: IQueryable<TOther> | TOther[], selector: ZipSelector<TOut, TOther, TSelectorOut>): IEnumerable<TSelectorOut>
    {
        const otherAsEnumerable = other instanceof Array
            ? new ArrayEnumerable(other)
            : other.asEnumerable();

        return new ZippedEnumerable<TOut, TOther, TSelectorOut>(this, otherAsEnumerable, selector);
    }
}
// endregion
// region Enumerable
export class Enumerable<TElement> extends EnumerableBase<TElement, TElement>
{
    protected currentValue: Cached<TElement>;

    public static fromSource<TElement>(source: TElement[] | IIterable<TElement>): IEnumerable<TElement>
    {
        if (source instanceof Array)
        {
            return new ArrayEnumerable<TElement>(source);
        }

        return new Enumerable<TElement>(source);
    }

    public static empty<TElement>(): IEnumerable<TElement>
    {
        return Enumerable.fromSource([]);
    }

    public static range(start: number, count: number): IEnumerable<number>;
    public static range(start: number, count: number, ascending: boolean): IEnumerable<number>;
    public static range(start: number, count: number, ascending: boolean = true): IEnumerable<number>
    {
        if (count < 0)
        {
            throw new Error("Count must be >= 0");
        }

        const source = new Array<number>(count);

        if (ascending)
        {
            // tslint:disable-next-line:curly
            for (let i = 0; i < count; source[i] = start + (i++));
        }
        else
        {
            // tslint:disable-next-line:curly
            for (let i = 0; i < count; source[i] = start - (i++));
        }

        return new ArrayEnumerable(source);
    }

    public static repeat<TElement>(element: TElement, count: number): IEnumerable<TElement>
    {
        if (count < 0)
        {
            throw new Error("Count must me >= 0");
        }

        const source = new Array<TElement>(count);

        for (let i = 0; i < count; ++i)
        {
            source[i] = element;
        }

        return new ArrayEnumerable(source);
    }

    public constructor(source: IIterable<TElement>)
    {
        super(source);
        this.currentValue = new Cached<TElement>();
    }

    public copy(): IEnumerable<TElement>
    {
        return new Enumerable<TElement>(this.source.copy());
    }

    public value(): TElement
    {
        if (!this.currentValue.isValid())
        {
            this.currentValue.value = this.source.value();
        }

        return this.currentValue.value;
    }

    public reset(): void
    {
        super.reset();
        this.currentValue.invalidate();
    }

    public next(): boolean
    {
        this.currentValue.invalidate();

        return super.next();
    }
}
// endregion
// region ConditionalEnumerable
export class ConditionalEnumerable<TElement> extends Enumerable<TElement>
{
    protected source: IEnumerable<TElement>;
    private _predicate: Predicate<TElement>;

    public constructor(source: IEnumerable<TElement>, predicate: Predicate<TElement>)
    {
        super(source);
        this._predicate = predicate;
    }

    public copy(): ConditionalEnumerable<TElement>
    {
        return new ConditionalEnumerable<TElement>(this.source.copy(), this._predicate);
    }

    public next(): boolean
    {
        let hasValue: boolean;

        do
        {
            hasValue = super.next();
        }
        while (hasValue && !this._predicate(this.value()));

        return hasValue;
    }
}
// endregion
// region SkipWhileEnumerable
export class SkipWhileEnumerable<TElement> extends Enumerable<TElement>
{
    protected source: IEnumerable<TElement>;
    private _predicate: Predicate<TElement>;
    private _shouldContinueChecking: boolean;

    public constructor(source: IEnumerable<TElement>, predicate: Predicate<TElement>)
    {
        super(source);
        this._predicate = predicate;
        this._shouldContinueChecking = true;
    }

    public reset(): void
    {
        super.reset();
        this._shouldContinueChecking = true;
    }

    public copy(): SkipWhileEnumerable<TElement>
    {
        return new SkipWhileEnumerable<TElement>(this.source.copy(), this._predicate);
    }

    public next(): boolean
    {
        if (!this._shouldContinueChecking)
        {
            return super.next();
        }

        let hasValue: boolean;

        do
        {
            hasValue = super.next();
        }
        while (hasValue && this._predicate(this.value()));

        this._shouldContinueChecking = false;

        return hasValue;
    }
}
// endregion
// region TakeWhileEnumerable
export class TakeWhileEnumerable<TElement> extends Enumerable<TElement>
{
    protected source: IEnumerable<TElement>;
    private _predicate: Predicate<TElement>;
    private _shouldContinueTaking: boolean;

    public constructor(source: IEnumerable<TElement>, predicate: Predicate<TElement>)
    {
        super(source);
        this._predicate = predicate;
        this._shouldContinueTaking = true;
    }

    public reset(): void
    {
        super.reset();
        this._shouldContinueTaking = true;
    }

    public copy(): TakeWhileEnumerable<TElement>
    {
        return new TakeWhileEnumerable<TElement>(this.source.copy(), this._predicate);
    }

    public next(): boolean
    {
        if (super.next())
        {
            if (this._shouldContinueTaking && this._predicate(this.value()))
            {
                return true;
            }
        }

        this._shouldContinueTaking = false;

        return false;
    }
}
// endregion
// region ConcatEnumerable
export class ConcatEnumerable<TElement> extends Enumerable<TElement>
{
    private _otherSource: IIterable<TElement>;
    private _isFirstSourceFinished: boolean;

    public constructor(left: IIterable<TElement>, right: IIterable<TElement>)
    {
        super(left);
        this._otherSource = right;
        this._isFirstSourceFinished = false;
    }

    public copy(): ConcatEnumerable<TElement>
    {
        return new ConcatEnumerable<TElement>(this.source.copy(), this._otherSource.copy());
    }

    public reset(): void
    {
        this.source.reset();
        this._otherSource.reset();
        this._isFirstSourceFinished = false;
        this.currentValue.invalidate();
    }

    public next(): boolean
    {
        this.currentValue.invalidate();

        const hasValue = !this._isFirstSourceFinished
            ? this.source.next()
            : this._otherSource.next();

        if (!hasValue && !this._isFirstSourceFinished)
        {
            this._isFirstSourceFinished = true;

            return this.next();
        }

        return hasValue;
    }

    public value(): TElement
    {
        if (!this.currentValue.isValid())
        {
            this.currentValue.value = !this._isFirstSourceFinished
                ? this.source.value()
                : this._otherSource.value();
        }

        return this.currentValue.value;
    }
}
// endregion
// region UniqueEnumerable
export class UniqueEnumerable<TElement, TKey> extends Enumerable<TElement>
{
    protected source: IEnumerable<TElement>;
    private _seen: { primitive: Dynamic, complex: Array<TElement | TKey> };
    private _keySelector: Selector<TElement, TKey> | undefined;

    public constructor(source: IEnumerable<TElement>, keySelector?: Selector<TElement, TKey>)
    {
        super(source);
        this._keySelector = keySelector;
        this._seen = { primitive: { number: {}, string: {}, boolean: {} }, complex: [] };
    }

    public copy(): UniqueEnumerable<TElement, TKey>
    {
        return new UniqueEnumerable(this.source.copy(), this._keySelector);
    }

    public reset(): void
    {
        super.reset();
        this._seen = { primitive: { number: {}, string: {}, boolean: {} }, complex: [] };
    }

    private isUnique(element: TElement): boolean
    {
        const key = this._keySelector !== undefined
            ? this._keySelector(element)
            : element;
        const type = typeof key;

        return (type in this._seen.primitive)
            ? this._seen.primitive[type].hasOwnProperty(key)
                ? false
                : this._seen.primitive[type][key] = true
            : this._seen.complex.indexOf(key) !== -1
                ? false
                : this._seen.complex.push(key) > -1;
    }

    public next(): boolean
    {
        let hasValue: boolean;

        do
        {
            hasValue = super.next();
        }
        while (hasValue && !this.isUnique(this.value()));

        return hasValue;
    }
}
// endregion
// region RangeEnumerable
export class RangeEnumerable<TElement> extends Enumerable<TElement>
{
    protected source: IEnumerable<TElement>;
    private _start: number | undefined;
    private _count: number | undefined;
    private _currentIndex: number;

    public constructor(source: IEnumerable<TElement>, start: number | undefined, count: number | undefined)
    {
        if ((start !== undefined && start < 0) || (count !== undefined && count < 0))
        {
            throw new Error("Incorrect parameters");
        }

        super(source);
        this._start = start;
        this._count = count;
        this._currentIndex = -1;
    }

    public copy(): RangeEnumerable<TElement>
    {
        return new RangeEnumerable<TElement>(this.source.copy(), this._start, this._count);
    }

    public reset(): void
    {
        super.reset();
        this._currentIndex = -1;
    }

    private isValidIndex(): boolean
    {
        const start = this._start !== undefined ? this._start : 0;
        const end = this._count !== undefined ? start + this._count : undefined;

        return this._currentIndex >= start && (end === undefined || this._currentIndex < end);
    }

    private performSkip(): boolean
    {
        const start = this._start !== undefined ? this._start : 0;
        let hasValue: boolean = true;

        while (hasValue && this._currentIndex + 1 < start)
        {
            hasValue = super.next();
            ++this._currentIndex;
        }

        return hasValue;
    }

    public next(): boolean
    {
        if (this._currentIndex < 0 && !this.performSkip())
        {
            return false;
        }

        ++this._currentIndex;

        return super.next() && this.isValidIndex();
    }

    public value(): TElement
    {
        if (!this.isValidIndex())
        {
            throw new Error("Out of bounds");
        }

        return super.value();
    }
}
// endregion
// region TransformEnumerable
export class TransformEnumerable<TElement, TOut> extends EnumerableBase<TElement, TOut>
{
    protected source: IEnumerable<TElement>;
    private _transform: Selector<TElement, TOut>;
    private _currentValue: Cached<TOut>;

    public constructor(source: IEnumerable<TElement>, transform: Selector<TElement, TOut>)
    {
        super(source);
        this._transform = transform;
        this._currentValue = new Cached<TOut>();
    }

    public copy(): TransformEnumerable<TElement, TOut>
    {
        return new TransformEnumerable<TElement, TOut>(this.source.copy(), this._transform);
    }

    public value(): TOut
    {
        if (!this._currentValue.isValid())
        {
            this._currentValue.value = this._transform(this.source.value());
        }

        return this._currentValue.value;
    }

    public reset(): void
    {
        super.reset();
        this._currentValue.invalidate();
    }

    public next(): boolean
    {
        this._currentValue.invalidate();

        return super.next();
    }
}
// endregion
// region ReverseEnumerable
export class ReverseEnumerable<TElement> extends Enumerable<TElement>
{
    protected source: IEnumerable<TElement>;
    private _elements: Cached<TElement[]>;
    private _currentIndex: number;

    public constructor(source: IEnumerable<TElement>)
    {
        super(source);
        this._elements = new Cached<TElement[]>();
        this._currentIndex = -1;
    }

    public copy(): IEnumerable<TElement>
    {
        return new ReverseEnumerable(this.source.copy());
    }

    public reset(): void
    {
        this._elements.invalidate();
        this._currentIndex = -1;
    }

    private isValidIndex(): boolean
    {
        return this._currentIndex >= 0
            && this._currentIndex < this._elements.value.length;
    }

    public all(predicate: Predicate<TElement>): boolean
    {
        return this.source.all(predicate);
    }

    public any(): boolean;
    public any(predicate: Predicate<TElement>): boolean;
    public any(predicate?: Predicate<TElement>): boolean
    {
        if (predicate !== undefined)
        {
            return this.source.any(predicate);
        }

        return this.source.any();
    }

    public average(selector: Selector<TElement, number>): number
    {
        return this.source.average(selector);
    }

    public count(): number;
    public count(predicate: Predicate<TElement>): number;
    public count(predicate?: Predicate<TElement>): number
    {
        if (predicate !== undefined)
        {
            return this.source.count(predicate);
        }

        return this.source.count();
    }

    public max(): TElement;
    public max<TSelectorOut>(selector: Selector<TElement, TSelectorOut>): TSelectorOut;
    public max<TSelectorOut>(selector?: Selector<TElement, TSelectorOut>): TElement | TSelectorOut
    {
        if (selector !== undefined)
        {
            return this.source.max(selector);
        }

        return this.source.max();
    }

    public min(): TElement;
    public min<TSelectorOut>(selector: Selector<TElement, TSelectorOut>): TSelectorOut;
    public min<TSelectorOut>(selector?: Selector<TElement, TSelectorOut>): TElement | TSelectorOut
    {
        if (selector !== undefined)
        {
            return this.source.min(selector);
        }

        return this.source.min();
    }

    public reverse(): IEnumerable<TElement>
    {
        return this.source.copy(); // haha so smart
    }

    public sum(selector: Selector<TElement, number>): number
    {
        return this.source.sum(selector);
    }

    public next(): boolean
    {
        if (!this._elements.isValid())
        {
            this._elements.value = this.source.toArray();
        }

        ++this._currentIndex;

        return this.isValidIndex();
    }

    public value(): TElement
    {
        if (!this._elements.isValid() || !this.isValidIndex())
        {
            throw new Error("Out of bounds");
        }

        return this._elements.value[(this._elements.value.length - 1) - this._currentIndex];
    }
}
// endregion
// region OrderedEnumerable
export class OrderedEnumerable<TElement>
    extends EnumerableBase<TElement, TElement>
    implements IOrderedEnumerable<TElement>
{
    protected source: IEnumerable<TElement>;
    private _comparer: Comparer<TElement>;
    private _elements: Cached<TElement[]>;
    private _currentIndex: number;

    public constructor(source: IEnumerable<TElement>, comparer: Comparer<TElement>)
    {
        super(source);

        this._comparer = comparer;
        this._elements = new Cached<TElement[]>();
        this._currentIndex = -1;
    }

    private isValidIndex(): boolean
    {
        return this._currentIndex >= 0
            && this._currentIndex < this._elements.value.length;
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
        return new OrderedEnumerable(this.source.copy(), createComparer(keySelector, true, comparer));
    }

    public orderByDescending<TKey>(
        keySelector: Selector<TElement, TKey>): IOrderedEnumerable<TElement>
    {
        return new OrderedEnumerable(this.source.copy(), createComparer(keySelector, false, undefined));
    }

    public thenBy<TKey>(
        keySelector: Selector<TElement, TKey>): IOrderedEnumerable<TElement>;
    public thenBy<TKey>(
        keySelector: Selector<TElement, TKey>,
        comparer: Comparer<TKey>): IOrderedEnumerable<TElement>;
    public thenBy<TKey>(
        keySelector: Selector<TElement, TKey>,
        comparer?: Comparer<TKey>): IOrderedEnumerable<TElement>
    {
        return new OrderedEnumerable(
            this.source.copy(),
            combineComparers(this._comparer, createComparer(keySelector, true, comparer)));
    }

    public thenByDescending<TKeySelector>(
        keySelector: Selector<TElement, TKeySelector>): IOrderedEnumerable<TElement>
    {
        return new OrderedEnumerable(
            this.source.copy(),
            combineComparers(this._comparer, createComparer(keySelector, false, undefined)));
    }

    public reset(): void
    {
        this._elements.invalidate();
        this._currentIndex = -1;
    }

    public copy(): IOrderedEnumerable<TElement>
    {
        return new OrderedEnumerable(this.source.copy(), this._comparer);
    }

    public value(): TElement
    {
        if (!this._elements.isValid() || !this.isValidIndex())
        {
            throw new Error("Out of bounds");
        }

        return this._elements.value[this._currentIndex];
    }

    public next(): boolean
    {
        if (!this._elements.isValid())
        {
            this._elements.value = this.toArray();
        }

        ++this._currentIndex;

        return this.isValidIndex();
    }

    public toArray(): TElement[]
    {
        // Allocate the array before sorting
        // It's faster than working with anonymous reference
        const result = this.source.toArray();

        return result.sort(this._comparer);
    }
}
// endregion
// region ArrayEnumerable
export class ArrayEnumerable<TOut> extends Enumerable<TOut>
{
    protected list: List<TOut>;

    public constructor(source: TOut[])
    {
        super(new ArrayIterator(source));

        this.list = new List(source);
    }

    public toArray(): TOut[]
    {
        return this.list.toArray();
    }

    public aggregate(aggregator: Aggregator<TOut, TOut | undefined>): TOut;
    public aggregate<TValue>(aggregator: Aggregator<TOut, TValue>, initialValue: TValue): TValue;
    public aggregate<TValue>(
        aggregator: Aggregator<TOut, TValue | TOut | undefined>,
        initialValue?: TValue): TValue | TOut
    {
        if (initialValue !== undefined)
        {
            return this.list.aggregate(
                aggregator as Aggregator<TOut, TValue>,
                initialValue as TValue);
        }

        return this.list.aggregate(aggregator as Aggregator<TOut, TOut | undefined>);
    }

    public any(): boolean;
    public any(predicate: Predicate<TOut>): boolean;
    public any(predicate?: Predicate<TOut>): boolean
    {
        if (predicate !== undefined)
        {
            return this.list.any(predicate);
        }

        return this.list.any();
    }

    public all(predicate: Predicate<TOut>): boolean
    {
        return this.list.all(predicate);
    }

    public average(selector: Selector<TOut, number>): number
    {
        return this.list.average(selector);
    }

    public count(): number;
    public count(predicate: Predicate<TOut>): number;
    public count(predicate?: Predicate<TOut>): number
    {
        if (predicate !== undefined)
        {
            return this.list.count(predicate);
        }

        return this.list.count();
    }

    public copy(): IEnumerable<TOut>
    {
        return new ArrayEnumerable(this.list.asArray());
    }

    public elementAtOrDefault(index: number): TOut | undefined
    {
        return this.list.elementAtOrDefault(index);
    }

    public firstOrDefault(): TOut | undefined;
    public firstOrDefault(predicate: Predicate<TOut>): TOut | undefined;
    public firstOrDefault(predicate?: Predicate<TOut>): TOut | undefined
    {
        if (predicate !== undefined)
        {
            return this.list.firstOrDefault(predicate);
        }

        return this.list.firstOrDefault();
    }

    public lastOrDefault(): TOut | undefined;
    public lastOrDefault(predicate: Predicate<TOut>): TOut | undefined;
    public lastOrDefault(predicate?: Predicate<TOut>): TOut | undefined
    {
        if (predicate !== undefined)
        {
            return this.list.lastOrDefault(predicate);
        }

        return this.list.lastOrDefault();
    }
}
// endregion
// region DefaultIfEmptyEnumerable
export class DefaultIfEmptyEnumerable<TOut> extends EnumerableBase<TOut, TOut | undefined>
{
    protected source: IEnumerable<TOut>;
    private _mustUseDefaultValue: boolean | undefined;
    private _defaultValue: TOut | undefined;

    public constructor(source: IEnumerable<TOut>, defaultValue?: TOut)
    {
        super(source);
        this._mustUseDefaultValue = undefined;
        this._defaultValue = defaultValue;
    }

    public copy(): DefaultIfEmptyEnumerable<TOut>
    {
        return new DefaultIfEmptyEnumerable<TOut>(this.source.copy(), this._defaultValue);
    }

    public value(): TOut | undefined
    {
        if (this._mustUseDefaultValue)
        {
            return this._defaultValue;
        }

        return this.source.value();
    }

    public next(): boolean
    {
        const hasNextElement = super.next();

        // single default element
        this._mustUseDefaultValue = this._mustUseDefaultValue === undefined && !hasNextElement;

        return this._mustUseDefaultValue || hasNextElement;
    }

    public reset(): void
    {
        super.reset();
        this._mustUseDefaultValue = undefined;
    }
}
// endregion
// region ZippedEnumerable
export class ZippedEnumerable<TElement, TOther, TOut> extends EnumerableBase<TElement, TOut>
{
    private _otherSource: IIterable<TOther>;
    private _isOneOfTheSourcesFinished: boolean;
    private _currentValue: Cached<TOut>;
    private _selector: ZipSelector<TElement, TOther, TOut>;

    public constructor(source: IIterable<TElement>, otherSource: IIterable<TOther>, selector: ZipSelector<TElement, TOther, TOut>)
    {
        super(source);
        this._otherSource = otherSource;
        this._isOneOfTheSourcesFinished = false;
        this._currentValue = new Cached<TOut>();
        this._selector = selector;
    }

    public copy(): ZippedEnumerable<TElement, TOther, TOut>
    {
        return new ZippedEnumerable<TElement, TOther, TOut>(this.source.copy(), this._otherSource.copy(), this._selector);
    }

    public value(): TOut
    {
        if (!this._currentValue.isValid())
        {
            this._currentValue.value = this._selector(this.source.value(), this._otherSource.value());
        }

        return this._currentValue.value;
    }

    public reset(): void
    {
        super.reset();
        this._otherSource.reset();
        this._isOneOfTheSourcesFinished = false;
        this._currentValue.invalidate();
    }

    public next(): boolean
    {
        this._currentValue.invalidate();

        if (!this._isOneOfTheSourcesFinished)
        {
            this._isOneOfTheSourcesFinished = !super.next() || !this._otherSource.next();
        }

        return !this._isOneOfTheSourcesFinished;
    }
}
// endregion
