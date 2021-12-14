import { ArrayEnumerable, ConcatEnumerable, ConditionalEnumerable, Enumerable, OrderedEnumerable, RangeEnumerable, ReverseEnumerable, TransformEnumerable, UniqueEnumerable, } from "./Enumerables.js";
import { strictEqualityComparer, createComparer } from "./Comparers.js";
export class EnumerableCollection {
    toList() {
        return new List(this.toArray());
    }
    toDictionary(keySelector, valueSelector) {
        return Dictionary.fromArray(this.toArray(), keySelector, valueSelector);
    }
    reverse() {
        return new ReverseEnumerable(this.asEnumerable());
    }
    concat(other, ...others) {
        return this.asEnumerable().concat(other, ...others);
    }
    contains(element) {
        return this.any(e => e === element);
    }
    where(predicate) {
        return new ConditionalEnumerable(this.asEnumerable(), predicate);
    }
    select(selector) {
        return new TransformEnumerable(this.asEnumerable(), selector);
    }
    selectMany(selector) {
        const selectToEnumerable = (e) => {
            const ie = selector(e);
            return ie instanceof Array
                ? new ArrayEnumerable(ie)
                : ie.asEnumerable();
        };
        return this
            .select(selectToEnumerable).toArray()
            .reduce((p, c) => new ConcatEnumerable(p, c), Enumerable.empty());
    }
    elementAt(index) {
        const element = this.elementAtOrDefault(index);
        if (element === undefined) {
            throw new Error("Out of bounds");
        }
        return element;
    }
    except(other) {
        return this.asEnumerable().except(other);
    }
    first(predicate) {
        let element;
        if (predicate !== undefined) {
            element = this.firstOrDefault(predicate);
        }
        else {
            element = this.firstOrDefault();
        }
        if (element === undefined) {
            throw new Error("Sequence contains no elements");
        }
        return element;
    }
    groupBy(keySelector, valueSelector) {
        const array = this.toArray();
        const dictionary = new Dictionary();
        for (let i = 0; i < array.length; ++i) {
            const key = keySelector(array[i]);
            const value = valueSelector !== undefined
                ? valueSelector(array[i])
                : array[i];
            if (!dictionary.containsKey(key)) {
                dictionary.set(key, new List());
            }
            dictionary.get(key).push(value);
        }
        return dictionary.asEnumerable();
    }
    last(predicate) {
        let element;
        if (predicate !== undefined) {
            element = this.lastOrDefault(predicate);
        }
        else {
            element = this.lastOrDefault();
        }
        if (element === undefined) {
            throw new Error("Sequence contains no elements");
        }
        return element;
    }
    single(predicate) {
        let element;
        if (predicate !== undefined) {
            element = this.singleOrDefault(predicate);
        }
        else {
            element = this.singleOrDefault();
        }
        if (element === undefined) {
            throw new Error("Sequence contains no elements");
        }
        return element;
    }
    singleOrDefault(predicate) {
        if (predicate !== undefined) {
            return this.asEnumerable().singleOrDefault(predicate);
        }
        return this.asEnumerable().singleOrDefault();
    }
    skipWhile(predicate) {
        return this.asEnumerable().skipWhile(predicate);
    }
    takeWhile(predicate) {
        return this.asEnumerable().takeWhile(predicate);
    }
    sequenceEqual(other, comparer) {
        if (comparer !== undefined) {
            return this.asEnumerable().sequenceEqual(other, comparer);
        }
        return this.asEnumerable().sequenceEqual(other);
    }
    distinct(keySelector) {
        return new UniqueEnumerable(this.asEnumerable(), keySelector);
    }
    min(selector) {
        if (selector !== undefined) {
            return new TransformEnumerable(this.asEnumerable(), selector).min();
        }
        return this.aggregate((previous, current) => (previous !== undefined && previous < current)
            ? previous
            : current);
    }
    orderBy(keySelector, comparer) {
        return new OrderedEnumerable(this.asEnumerable(), createComparer(keySelector, true, comparer));
    }
    orderByDescending(keySelector) {
        return new OrderedEnumerable(this.asEnumerable(), createComparer(keySelector, false, undefined));
    }
    max(selector) {
        if (selector !== undefined) {
            return new TransformEnumerable(this.asEnumerable(), selector).max();
        }
        return this.aggregate((previous, current) => (previous !== undefined && previous > current)
            ? previous
            : current);
    }
    sum(selector) {
        return this.aggregate((previous, current) => previous + selector(current), 0);
    }
    skip(amount) {
        return new RangeEnumerable(this.asEnumerable(), amount, undefined);
    }
    take(amount) {
        return new RangeEnumerable(this.asEnumerable(), undefined, amount);
    }
    union(other) {
        return new UniqueEnumerable(this.concat(other));
    }
    aggregate(aggregator, initialValue) {
        if (initialValue !== undefined) {
            return this.asEnumerable().aggregate(aggregator, initialValue);
        }
        return this.asEnumerable().aggregate(aggregator);
    }
    any(predicate) {
        if (predicate !== undefined) {
            return this.asEnumerable().any(predicate);
        }
        return this.asEnumerable().any();
    }
    all(predicate) {
        return this.asEnumerable().all(predicate);
    }
    average(selector) {
        return this.asEnumerable().average(selector);
    }
    count(predicate) {
        if (predicate !== undefined) {
            return this.asEnumerable().count(predicate);
        }
        return this.asEnumerable().count();
    }
    elementAtOrDefault(index) {
        return this.asEnumerable().elementAtOrDefault(index);
    }
    firstOrDefault(predicate) {
        if (predicate !== undefined) {
            return this.asEnumerable().firstOrDefault(predicate);
        }
        return this.asEnumerable().firstOrDefault();
    }
    lastOrDefault(predicate) {
        if (predicate !== undefined) {
            return this.asEnumerable().lastOrDefault(predicate);
        }
        return this.asEnumerable().lastOrDefault();
    }
    forEach(action) {
        return this.asEnumerable().forEach(action);
    }
    defaultIfEmpty(defaultValue) {
        if (defaultValue !== undefined) {
            return this.asEnumerable().defaultIfEmpty(defaultValue);
        }
        return this.asEnumerable().defaultIfEmpty();
    }
    zip(other, selector) {
        return this.asEnumerable().zip(other, selector);
    }
}
export class ArrayQueryable extends EnumerableCollection {
    constructor(elements = []) {
        super();
        this.source = elements;
    }
    asArray() {
        return this.source;
    }
    toArray() {
        return [].concat(this.source);
    }
    toList() {
        return new List(this.toArray());
    }
    asEnumerable() {
        return new ArrayEnumerable(this.source);
    }
    aggregate(aggregator, initialValue) {
        if (initialValue !== undefined) {
            return this.source.reduce(aggregator, initialValue);
        }
        return this.source.reduce(aggregator);
    }
    any(predicate) {
        if (predicate !== undefined) {
            return this.source.some(predicate);
        }
        return this.source.length > 0;
    }
    all(predicate) {
        return this.source.every(predicate);
    }
    average(selector) {
        if (this.count() === 0) {
            throw new Error("Sequence contains no elements");
        }
        let sum = 0;
        for (let i = 0, end = this.source.length; i < end; ++i) {
            sum += selector(this.source[i]);
        }
        return sum / this.source.length;
    }
    count(predicate) {
        if (predicate !== undefined) {
            return this.source.filter(predicate).length;
        }
        return this.source.length;
    }
    elementAtOrDefault(index) {
        if (index < 0) {
            throw new Error("Negative index is forbiden");
        }
        return this.source[index];
    }
    firstOrDefault(predicate) {
        if (predicate !== undefined) {
            return this.source.filter(predicate)[0];
        }
        return this.source[0];
    }
    groupBy(keySelector, valueSelector) {
        const array = this.asArray();
        const dictionary = new Dictionary();
        for (let i = 0; i < array.length; ++i) {
            const key = keySelector(array[i]);
            const value = valueSelector !== undefined
                ? valueSelector(array[i])
                : array[i];
            if (!dictionary.containsKey(key)) {
                dictionary.set(key, new List());
            }
            dictionary.get(key).push(value);
        }
        return dictionary.asEnumerable();
    }
    lastOrDefault(predicate) {
        if (predicate !== undefined) {
            const records = this.source.filter(predicate);
            return records[records.length - 1];
        }
        return this.source[this.source.length - 1];
    }
    forEach(action) {
        for (let i = 0, end = this.source.length; i < end; ++i) {
            action(this.source[i], i);
        }
    }
    sequenceEqual(other, comparer = strictEqualityComparer()) {
        if (other instanceof ArrayQueryable
            || other instanceof Array) {
            const thisArray = this.asArray();
            const otherArray = other instanceof ArrayQueryable
                ? other.asArray()
                : other;
            if (thisArray.length != otherArray.length) {
                return false;
            }
            for (let i = 0; i < thisArray.length; ++i) {
                if (!comparer(thisArray[i], otherArray[i])) {
                    return false;
                }
            }
            return true;
        }
        return this.asEnumerable().sequenceEqual(other, comparer);
    }
}
export class List extends ArrayQueryable {
    copy() {
        return new List(this.toArray());
    }
    asReadOnly() {
        return this;
    }
    clear() {
        this.source = [];
    }
    remove(element) {
        const newSource = [];
        for (let i = 0, end = this.source.length; i < end; ++i) {
            if (this.source[i] !== element) {
                newSource.push(this.source[i]);
            }
        }
        this.source = newSource;
    }
    removeAt(index) {
        if (index < 0 || this.source[index] === undefined) {
            throw new Error("Out of bounds");
        }
        return this.source.splice(index, 1)[0];
    }
    get(index) {
        return this.source[index];
    }
    push(element) {
        return this.source.push(element);
    }
    pushIfNotExists(element, selector) {
        const r = this.firstOrDefault(selector);
        if (r == null) {
            return this.source.push(element);
        }
        else {
            return this.source.length;
        }
    }
    pushRange(elements) {
        if (!(elements instanceof Array)) {
            elements = elements.toArray();
        }
        return this.source.push.apply(this.source, elements);
    }
    pushFront(element) {
        return this.source.unshift(element);
    }
    replace(element, selector) {
        for (var i = 0; i < this.source.length; i++) {
            if (selector(this.source[i]) == true) {
                this.source[i] = element;
                return i;
            }
        }
        return this.source.push(element);
    }
    pop() {
        return this.source.pop();
    }
    popFront() {
        return this.source.shift();
    }
    set(index, element) {
        if (index < 0) {
            throw new Error("Out of bounds");
        }
        this.source[index] = element;
    }
    insert(index, element) {
        if (index < 0 || index > this.source.length) {
            throw new Error("Out of bounds");
        }
        this.source.splice(index, 0, element);
    }
    indexOf(element) {
        return this.source.indexOf(element);
    }
    sort(comparerList) {
        this.asArray().sort((x, y) => {
            for (var i = 0; i < comparerList.length; i++) {
                let comparer = comparerList[i];
                let result = comparer(x, y);
                if (result != 0) {
                    return result;
                }
            }
            return 0;
        });
    }
}
export class Stack extends ArrayQueryable {
    copy() {
        return new Stack(this.toArray());
    }
    clear() {
        this.source = [];
    }
    peek() {
        return this.source[this.source.length - 1];
    }
    pop() {
        return this.source.pop();
    }
    push(element) {
        return this.source.push(element);
    }
}
export class Dictionary extends EnumerableCollection {
    constructor(keyValuePairs) {
        super();
        this.clear();
        if (keyValuePairs !== undefined) {
            for (let i = 0; i < keyValuePairs.length; ++i) {
                const pair = keyValuePairs[i];
                this.set(pair.key, pair.value);
            }
        }
    }
    static fromArray(array, keySelector, valueSelector) {
        const keyValuePairs = array.map(v => {
            return {
                key: keySelector(v),
                value: valueSelector(v),
            };
        });
        return new Dictionary(keyValuePairs);
    }
    static fromJsObject(object) {
        const keys = new List(Object.getOwnPropertyNames(object));
        const keyValues = keys.select(k => ({ key: k, value: object[k] }));
        return new Dictionary(keyValues.toArray());
    }
    copy() {
        return new Dictionary(this.toArray());
    }
    asReadOnly() {
        return this;
    }
    asEnumerable() {
        return new ArrayEnumerable(this.toArray());
    }
    toArray() {
        return this.getKeys().select(p => {
            return {
                key: p,
                value: this.dictionary[p],
            };
        }).toArray();
    }
    clear() {
        this.dictionary = {};
    }
    containsKey(key) {
        return this.dictionary.hasOwnProperty(key);
    }
    containsValue(value) {
        const keys = this.getKeysFast();
        for (let i = 0; i < keys.length; ++i) {
            if (this.dictionary[keys[i]] === value) {
                return true;
            }
        }
        return false;
    }
    getKeys() {
        const keys = this.getKeysFast();
        return new List(keys.map(k => this.keyType === "number"
            ? parseFloat(k)
            : k));
    }
    getKeysFast() {
        return Object.getOwnPropertyNames(this.dictionary);
    }
    getValues() {
        const keys = this.getKeysFast();
        const result = new Array(keys.length);
        for (let i = 0; i < keys.length; ++i) {
            result[i] = this.dictionary[keys[i]];
        }
        return new List(result);
    }
    remove(key) {
        if (this.containsKey(key)) {
            delete this.dictionary[key];
        }
    }
    get(key) {
        if (!this.containsKey(key)) {
            throw new Error(`Key doesn't exist: ${key}`);
        }
        return this.dictionary[key];
    }
    set(key, value) {
        if (this.containsKey(key)) {
            throw new Error(`Key already exists: ${key}`);
        }
        this.setOrUpdate(key, value);
    }
    setOrUpdate(key, value) {
        if (this.keyType === undefined) {
            this.keyType = typeof key;
        }
        this.dictionary[key] = value;
    }
}
//# sourceMappingURL=Collections.js.map