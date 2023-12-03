import { ArrayIterator } from "./Iterators.js";
import { strictEqualityComparer, combineComparers, createComparer } from "./Comparers.js";
import { Dictionary, List } from "./Collections.js";
import { Cached } from "./Utils.js";
export class EnumerableBase {
    constructor(source) {
        this.source = source;
    }
    reset() {
        this.source.reset();
    }
    next() {
        return this.source.next();
    }
    asEnumerable() {
        return this;
    }
    toArray() {
        const result = [];
        this.reset();
        while (this.next()) {
            result.push(this.value());
        }
        return result;
    }
    toList() {
        return new List(this.toArray());
    }
    toDictionary(keySelector, valueSelector) {
        return Dictionary.fromArray(this.toArray(), keySelector, valueSelector);
    }
    count(predicate) {
        if (predicate !== undefined) {
            return new ConditionalEnumerable(this, predicate).count();
        }
        let result = 0;
        this.reset();
        while (this.next()) {
            ++result;
        }
        return result >>> 0;
    }
    any(predicate) {
        if (predicate !== undefined) {
            return new ConditionalEnumerable(this, predicate).any();
        }
        this.reset();
        return this.next();
    }
    all(predicate) {
        this.reset();
        while (this.next()) {
            if (!predicate(this.value())) {
                return false;
            }
        }
        return true;
    }
    reverse() {
        return new ReverseEnumerable(this.copy());
    }
    contains(element) {
        return this.any(e => e === element);
    }
    sequenceEqual(other, comparer = strictEqualityComparer()) {
        const otherEnumerable = other instanceof Array
            ? new ArrayEnumerable(other)
            : other.asEnumerable();
        this.reset();
        otherEnumerable.reset();
        while (this.next()) {
            if (!otherEnumerable.next() || !comparer(this.value(), otherEnumerable.value())) {
                return false;
            }
        }
        return !otherEnumerable.next();
    }
    where(predicate) {
        return new ConditionalEnumerable(this.copy(), predicate);
    }
    select(selector) {
        return new TransformEnumerable(this.copy(), selector);
    }
    selectMany(selector) {
        const selectToEnumerable = (e) => {
            const ie = selector(e);
            return Array.isArray(ie)
                ? new ArrayEnumerable(ie)
                : ie.asEnumerable();
        };
        return this
            .select(selectToEnumerable).toArray()
            .reduce((p, c) => new ConcatEnumerable(p, c), Enumerable.empty());
    }
    skipWhile(predicate) {
        return new SkipWhileEnumerable(this.copy(), predicate);
    }
    concat(other, ...others) {
        const asEnumerable = (e) => {
            return e instanceof Array
                ? new ArrayEnumerable(e)
                : e.asEnumerable();
        };
        let result = new ConcatEnumerable(this.copy(), asEnumerable(other).copy());
        for (let i = 0, end = others.length; i < end; ++i) {
            result = new ConcatEnumerable(result, asEnumerable(others[i]).copy());
        }
        return result;
    }
    defaultIfEmpty(defaultValue) {
        return new DefaultIfEmptyEnumerable(this, defaultValue);
    }
    elementAt(index) {
        const element = this.elementAtOrDefault(index);
        if (element === undefined) {
            throw new Error("Out of bounds");
        }
        return element;
    }
    elementAtOrDefault(index) {
        if (index < 0) {
            throw new Error("Negative index is forbiden");
        }
        this.reset();
        let currentIndex = -1;
        while (this.next()) {
            ++currentIndex;
            if (currentIndex === index) {
                break;
            }
        }
        if (currentIndex !== index) {
            return undefined;
        }
        return this.value();
    }
    except(other) {
        return this.where(e => !other.contains(e));
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
    firstOrDefault(predicate) {
        if (predicate !== undefined) {
            return new ConditionalEnumerable(this, predicate).firstOrDefault();
        }
        this.reset();
        if (!this.next()) {
            return undefined;
        }
        return this.value();
    }
    forEach(action) {
        this.reset();
        for (let i = 0; this.next(); ++i) {
            action(this.value(), i);
        }
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
    lastOrDefault(predicate) {
        if (predicate !== undefined) {
            return new ConditionalEnumerable(this, predicate).lastOrDefault();
        }
        const reversed = new ReverseEnumerable(this);
        reversed.reset();
        if (!reversed.next()) {
            return undefined;
        }
        return reversed.value();
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
            return new ConditionalEnumerable(this, predicate).singleOrDefault();
        }
        this.reset();
        if (!this.next()) {
            return undefined;
        }
        const element = this.value();
        if (this.next()) {
            throw new Error("Sequence contains more than 1 element");
        }
        return element;
    }
    distinct(keySelector) {
        return new UniqueEnumerable(this.copy(), keySelector);
    }
    aggregate(aggregator, initialValue) {
        let value = initialValue;
        this.reset();
        if (initialValue === undefined) {
            if (!this.next()) {
                throw new Error("Sequence contains no elements");
            }
            value = aggregator(value, this.value());
        }
        while (this.next()) {
            value = aggregator(value, this.value());
        }
        return value;
    }
    min(selector) {
        if (selector !== undefined) {
            return new TransformEnumerable(this, selector).min();
        }
        return this.aggregate((previous, current) => (previous !== undefined && previous < current)
            ? previous
            : current);
    }
    orderBy(keySelector, comparer) {
        return new OrderedEnumerable(this.copy(), createComparer(keySelector, true, comparer));
    }
    orderByDescending(keySelector) {
        return new OrderedEnumerable(this.copy(), createComparer(keySelector, false, undefined));
    }
    max(selector) {
        if (selector !== undefined) {
            return new TransformEnumerable(this, selector).max();
        }
        return this.aggregate((previous, current) => (previous !== undefined && previous > current)
            ? previous
            : current);
    }
    sum(selector) {
        return this.aggregate((previous, current) => previous + selector(current), 0);
    }
    average(selector) {
        this.reset();
        if (!this.next()) {
            throw new Error("Sequence contains no elements");
        }
        let sum = 0;
        let count = 0;
        do {
            sum += selector(this.value());
            ++count;
        } while (this.next());
        return sum / count;
    }
    skip(amount) {
        return new RangeEnumerable(this.copy(), amount, undefined);
    }
    take(amount) {
        return new RangeEnumerable(this.copy(), undefined, amount);
    }
    takeWhile(predicate) {
        return new TakeWhileEnumerable(this.copy(), predicate);
    }
    union(other) {
        return new UniqueEnumerable(this.concat(other));
    }
    zip(other, selector) {
        const otherAsEnumerable = other instanceof Array
            ? new ArrayEnumerable(other)
            : other.asEnumerable();
        return new ZippedEnumerable(this, otherAsEnumerable, selector);
    }
}
export class Enumerable extends EnumerableBase {
    static fromSource(source) {
        if (source instanceof Array) {
            return new ArrayEnumerable(source);
        }
        return new Enumerable(source);
    }
    static empty() {
        return Enumerable.fromSource([]);
    }
    static range(start, count, ascending = true) {
        if (count < 0) {
            throw new Error("Count must be >= 0");
        }
        const source = new Array(count);
        if (ascending) {
            for (let i = 0; i < count; source[i] = start + (i++))
                ;
        }
        else {
            for (let i = 0; i < count; source[i] = start - (i++))
                ;
        }
        return new ArrayEnumerable(source);
    }
    static repeat(element, count) {
        if (count < 0) {
            throw new Error("Count must me >= 0");
        }
        const source = new Array(count);
        for (let i = 0; i < count; ++i) {
            source[i] = element;
        }
        return new ArrayEnumerable(source);
    }
    constructor(source) {
        super(source);
        this.currentValue = new Cached();
    }
    copy() {
        return new Enumerable(this.source.copy());
    }
    value() {
        if (!this.currentValue.isValid()) {
            this.currentValue.value = this.source.value();
        }
        return this.currentValue.value;
    }
    reset() {
        super.reset();
        this.currentValue.invalidate();
    }
    next() {
        this.currentValue.invalidate();
        return super.next();
    }
}
export class ConditionalEnumerable extends Enumerable {
    constructor(source, predicate) {
        super(source);
        this._predicate = predicate;
    }
    copy() {
        return new ConditionalEnumerable(this.source.copy(), this._predicate);
    }
    next() {
        let hasValue;
        do {
            hasValue = super.next();
        } while (hasValue && !this._predicate(this.value()));
        return hasValue;
    }
}
export class SkipWhileEnumerable extends Enumerable {
    constructor(source, predicate) {
        super(source);
        this._predicate = predicate;
        this._shouldContinueChecking = true;
    }
    reset() {
        super.reset();
        this._shouldContinueChecking = true;
    }
    copy() {
        return new SkipWhileEnumerable(this.source.copy(), this._predicate);
    }
    next() {
        if (!this._shouldContinueChecking) {
            return super.next();
        }
        let hasValue;
        do {
            hasValue = super.next();
        } while (hasValue && this._predicate(this.value()));
        this._shouldContinueChecking = false;
        return hasValue;
    }
}
export class TakeWhileEnumerable extends Enumerable {
    constructor(source, predicate) {
        super(source);
        this._predicate = predicate;
        this._shouldContinueTaking = true;
    }
    reset() {
        super.reset();
        this._shouldContinueTaking = true;
    }
    copy() {
        return new TakeWhileEnumerable(this.source.copy(), this._predicate);
    }
    next() {
        if (super.next()) {
            if (this._shouldContinueTaking && this._predicate(this.value())) {
                return true;
            }
        }
        this._shouldContinueTaking = false;
        return false;
    }
}
export class ConcatEnumerable extends Enumerable {
    constructor(left, right) {
        super(left);
        this._otherSource = right;
        this._isFirstSourceFinished = false;
    }
    copy() {
        return new ConcatEnumerable(this.source.copy(), this._otherSource.copy());
    }
    reset() {
        this.source.reset();
        this._otherSource.reset();
        this._isFirstSourceFinished = false;
        this.currentValue.invalidate();
    }
    next() {
        this.currentValue.invalidate();
        const hasValue = !this._isFirstSourceFinished
            ? this.source.next()
            : this._otherSource.next();
        if (!hasValue && !this._isFirstSourceFinished) {
            this._isFirstSourceFinished = true;
            return this.next();
        }
        return hasValue;
    }
    value() {
        if (!this.currentValue.isValid()) {
            this.currentValue.value = !this._isFirstSourceFinished
                ? this.source.value()
                : this._otherSource.value();
        }
        return this.currentValue.value;
    }
}
export class UniqueEnumerable extends Enumerable {
    constructor(source, keySelector) {
        super(source);
        this._keySelector = keySelector;
        this._seen = { primitive: { number: {}, string: {}, boolean: {} }, complex: [] };
    }
    copy() {
        return new UniqueEnumerable(this.source.copy(), this._keySelector);
    }
    reset() {
        super.reset();
        this._seen = { primitive: { number: {}, string: {}, boolean: {} }, complex: [] };
    }
    isUnique(element) {
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
    next() {
        let hasValue;
        do {
            hasValue = super.next();
        } while (hasValue && !this.isUnique(this.value()));
        return hasValue;
    }
}
export class RangeEnumerable extends Enumerable {
    constructor(source, start, count) {
        if ((start !== undefined && start < 0) || (count !== undefined && count < 0)) {
            throw new Error("Incorrect parameters");
        }
        super(source);
        this._start = start;
        this._count = count;
        this._currentIndex = -1;
    }
    copy() {
        return new RangeEnumerable(this.source.copy(), this._start, this._count);
    }
    reset() {
        super.reset();
        this._currentIndex = -1;
    }
    isValidIndex() {
        const start = this._start !== undefined ? this._start : 0;
        const end = this._count !== undefined ? start + this._count : undefined;
        return this._currentIndex >= start && (end === undefined || this._currentIndex < end);
    }
    performSkip() {
        const start = this._start !== undefined ? this._start : 0;
        let hasValue = true;
        while (hasValue && this._currentIndex + 1 < start) {
            hasValue = super.next();
            ++this._currentIndex;
        }
        return hasValue;
    }
    next() {
        if (this._currentIndex < 0 && !this.performSkip()) {
            return false;
        }
        ++this._currentIndex;
        return super.next() && this.isValidIndex();
    }
    value() {
        if (!this.isValidIndex()) {
            throw new Error("Out of bounds");
        }
        return super.value();
    }
}
export class TransformEnumerable extends EnumerableBase {
    constructor(source, transform) {
        super(source);
        this._transform = transform;
        this._currentValue = new Cached();
    }
    copy() {
        return new TransformEnumerable(this.source.copy(), this._transform);
    }
    value() {
        if (!this._currentValue.isValid()) {
            this._currentValue.value = this._transform(this.source.value());
        }
        return this._currentValue.value;
    }
    reset() {
        super.reset();
        this._currentValue.invalidate();
    }
    next() {
        this._currentValue.invalidate();
        return super.next();
    }
}
export class ReverseEnumerable extends Enumerable {
    constructor(source) {
        super(source);
        this._elements = new Cached();
        this._currentIndex = -1;
    }
    copy() {
        return new ReverseEnumerable(this.source.copy());
    }
    reset() {
        this._elements.invalidate();
        this._currentIndex = -1;
    }
    isValidIndex() {
        return this._currentIndex >= 0
            && this._currentIndex < this._elements.value.length;
    }
    all(predicate) {
        return this.source.all(predicate);
    }
    any(predicate) {
        if (predicate !== undefined) {
            return this.source.any(predicate);
        }
        return this.source.any();
    }
    average(selector) {
        return this.source.average(selector);
    }
    count(predicate) {
        if (predicate !== undefined) {
            return this.source.count(predicate);
        }
        return this.source.count();
    }
    max(selector) {
        if (selector !== undefined) {
            return this.source.max(selector);
        }
        return this.source.max();
    }
    min(selector) {
        if (selector !== undefined) {
            return this.source.min(selector);
        }
        return this.source.min();
    }
    reverse() {
        return this.source.copy();
    }
    sum(selector) {
        return this.source.sum(selector);
    }
    next() {
        if (!this._elements.isValid()) {
            this._elements.value = this.source.toArray();
        }
        ++this._currentIndex;
        return this.isValidIndex();
    }
    value() {
        if (!this._elements.isValid() || !this.isValidIndex()) {
            throw new Error("Out of bounds");
        }
        return this._elements.value[(this._elements.value.length - 1) - this._currentIndex];
    }
}
export class OrderedEnumerable extends EnumerableBase {
    constructor(source, comparer) {
        super(source);
        this._comparer = comparer;
        this._elements = new Cached();
        this._currentIndex = -1;
    }
    isValidIndex() {
        return this._currentIndex >= 0
            && this._currentIndex < this._elements.value.length;
    }
    orderBy(keySelector, comparer) {
        return new OrderedEnumerable(this.source.copy(), createComparer(keySelector, true, comparer));
    }
    orderByDescending(keySelector) {
        return new OrderedEnumerable(this.source.copy(), createComparer(keySelector, false, undefined));
    }
    thenBy(keySelector, comparer) {
        return new OrderedEnumerable(this.source.copy(), combineComparers(this._comparer, createComparer(keySelector, true, comparer)));
    }
    thenByDescending(keySelector) {
        return new OrderedEnumerable(this.source.copy(), combineComparers(this._comparer, createComparer(keySelector, false, undefined)));
    }
    reset() {
        this._elements.invalidate();
        this._currentIndex = -1;
    }
    copy() {
        return new OrderedEnumerable(this.source.copy(), this._comparer);
    }
    value() {
        if (!this._elements.isValid() || !this.isValidIndex()) {
            throw new Error("Out of bounds");
        }
        return this._elements.value[this._currentIndex];
    }
    next() {
        if (!this._elements.isValid()) {
            this._elements.value = this.toArray();
        }
        ++this._currentIndex;
        return this.isValidIndex();
    }
    toArray() {
        const result = this.source.toArray();
        return result.sort(this._comparer);
    }
}
export class ArrayEnumerable extends Enumerable {
    constructor(source) {
        super(new ArrayIterator(source));
        this.list = new List(source);
    }
    toArray() {
        return this.list.toArray();
    }
    aggregate(aggregator, initialValue) {
        if (initialValue !== undefined) {
            return this.list.aggregate(aggregator, initialValue);
        }
        return this.list.aggregate(aggregator);
    }
    any(predicate) {
        if (predicate !== undefined) {
            return this.list.any(predicate);
        }
        return this.list.any();
    }
    all(predicate) {
        return this.list.all(predicate);
    }
    average(selector) {
        return this.list.average(selector);
    }
    count(predicate) {
        if (predicate !== undefined) {
            return this.list.count(predicate);
        }
        return this.list.count();
    }
    copy() {
        return new ArrayEnumerable(this.list.asArray());
    }
    elementAtOrDefault(index) {
        return this.list.elementAtOrDefault(index);
    }
    firstOrDefault(predicate) {
        if (predicate !== undefined) {
            return this.list.firstOrDefault(predicate);
        }
        return this.list.firstOrDefault();
    }
    lastOrDefault(predicate) {
        if (predicate !== undefined) {
            return this.list.lastOrDefault(predicate);
        }
        return this.list.lastOrDefault();
    }
}
export class DefaultIfEmptyEnumerable extends EnumerableBase {
    constructor(source, defaultValue) {
        super(source);
        this._mustUseDefaultValue = undefined;
        this._defaultValue = defaultValue;
    }
    copy() {
        return new DefaultIfEmptyEnumerable(this.source.copy(), this._defaultValue);
    }
    value() {
        if (this._mustUseDefaultValue) {
            return this._defaultValue;
        }
        return this.source.value();
    }
    next() {
        const hasNextElement = super.next();
        this._mustUseDefaultValue = this._mustUseDefaultValue === undefined && !hasNextElement;
        return this._mustUseDefaultValue || hasNextElement;
    }
    reset() {
        super.reset();
        this._mustUseDefaultValue = undefined;
    }
}
export class ZippedEnumerable extends EnumerableBase {
    constructor(source, otherSource, selector) {
        super(source);
        this._otherSource = otherSource;
        this._isOneOfTheSourcesFinished = false;
        this._currentValue = new Cached();
        this._selector = selector;
    }
    copy() {
        return new ZippedEnumerable(this.source.copy(), this._otherSource.copy(), this._selector);
    }
    value() {
        if (!this._currentValue.isValid()) {
            this._currentValue.value = this._selector(this.source.value(), this._otherSource.value());
        }
        return this._currentValue.value;
    }
    reset() {
        super.reset();
        this._otherSource.reset();
        this._isOneOfTheSourcesFinished = false;
        this._currentValue.invalidate();
    }
    next() {
        this._currentValue.invalidate();
        if (!this._isOneOfTheSourcesFinished) {
            this._isOneOfTheSourcesFinished = !super.next() || !this._otherSource.next();
        }
        return !this._isOneOfTheSourcesFinished;
    }
}
//# sourceMappingURL=Enumerables.js.map