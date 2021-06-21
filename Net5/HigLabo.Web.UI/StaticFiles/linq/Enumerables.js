var __extends = (this && this.__extends) || (function () {
    var extendStatics = function (d, b) {
        extendStatics = Object.setPrototypeOf ||
            ({ __proto__: [] } instanceof Array && function (d, b) { d.__proto__ = b; }) ||
            function (d, b) { for (var p in b) if (Object.prototype.hasOwnProperty.call(b, p)) d[p] = b[p]; };
        return extendStatics(d, b);
    };
    return function (d, b) {
        extendStatics(d, b);
        function __() { this.constructor = d; }
        d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
    };
})();
import { ArrayIterator } from "./Iterators.js";
import { strictEqualityComparer, combineComparers, createComparer } from "./Comparers.js";
import { Dictionary, List } from "./Collections.js";
import { Cached } from "./Utils.js";
var EnumerableBase = (function () {
    function EnumerableBase(source) {
        this.source = source;
    }
    EnumerableBase.prototype.reset = function () {
        this.source.reset();
    };
    EnumerableBase.prototype.next = function () {
        return this.source.next();
    };
    EnumerableBase.prototype.asEnumerable = function () {
        return this;
    };
    EnumerableBase.prototype.toArray = function () {
        var result = [];
        this.reset();
        while (this.next()) {
            result.push(this.value());
        }
        return result;
    };
    EnumerableBase.prototype.toList = function () {
        return new List(this.toArray());
    };
    EnumerableBase.prototype.toDictionary = function (keySelector, valueSelector) {
        return Dictionary.fromArray(this.toArray(), keySelector, valueSelector);
    };
    EnumerableBase.prototype.count = function (predicate) {
        if (predicate !== undefined) {
            return new ConditionalEnumerable(this, predicate).count();
        }
        var result = 0;
        this.reset();
        while (this.next()) {
            ++result;
        }
        return result >>> 0;
    };
    EnumerableBase.prototype.any = function (predicate) {
        if (predicate !== undefined) {
            return new ConditionalEnumerable(this, predicate).any();
        }
        this.reset();
        return this.next();
    };
    EnumerableBase.prototype.all = function (predicate) {
        this.reset();
        while (this.next()) {
            if (!predicate(this.value())) {
                return false;
            }
        }
        return true;
    };
    EnumerableBase.prototype.reverse = function () {
        return new ReverseEnumerable(this.copy());
    };
    EnumerableBase.prototype.contains = function (element) {
        return this.any(function (e) { return e === element; });
    };
    EnumerableBase.prototype.sequenceEqual = function (other, comparer) {
        if (comparer === void 0) { comparer = strictEqualityComparer(); }
        var otherEnumerable = other instanceof Array
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
    };
    EnumerableBase.prototype.where = function (predicate) {
        return new ConditionalEnumerable(this.copy(), predicate);
    };
    EnumerableBase.prototype.select = function (selector) {
        return new TransformEnumerable(this.copy(), selector);
    };
    EnumerableBase.prototype.selectMany = function (selector) {
        var selectToEnumerable = function (e) {
            var ie = selector(e);
            return Array.isArray(ie)
                ? new ArrayEnumerable(ie)
                : ie.asEnumerable();
        };
        return this
            .select(selectToEnumerable).toArray()
            .reduce(function (p, c) { return new ConcatEnumerable(p, c); }, Enumerable.empty());
    };
    EnumerableBase.prototype.skipWhile = function (predicate) {
        return new SkipWhileEnumerable(this.copy(), predicate);
    };
    EnumerableBase.prototype.concat = function (other) {
        var others = [];
        for (var _i = 1; _i < arguments.length; _i++) {
            others[_i - 1] = arguments[_i];
        }
        var asEnumerable = function (e) {
            return e instanceof Array
                ? new ArrayEnumerable(e)
                : e.asEnumerable();
        };
        var result = new ConcatEnumerable(this.copy(), asEnumerable(other).copy());
        for (var i = 0, end = others.length; i < end; ++i) {
            result = new ConcatEnumerable(result, asEnumerable(others[i]).copy());
        }
        return result;
    };
    EnumerableBase.prototype.defaultIfEmpty = function (defaultValue) {
        return new DefaultIfEmptyEnumerable(this, defaultValue);
    };
    EnumerableBase.prototype.elementAt = function (index) {
        var element = this.elementAtOrDefault(index);
        if (element === undefined) {
            throw new Error("Out of bounds");
        }
        return element;
    };
    EnumerableBase.prototype.elementAtOrDefault = function (index) {
        if (index < 0) {
            throw new Error("Negative index is forbiden");
        }
        this.reset();
        var currentIndex = -1;
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
    };
    EnumerableBase.prototype.except = function (other) {
        return this.where(function (e) { return !other.contains(e); });
    };
    EnumerableBase.prototype.first = function (predicate) {
        var element;
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
    };
    EnumerableBase.prototype.firstOrDefault = function (predicate) {
        if (predicate !== undefined) {
            return new ConditionalEnumerable(this, predicate).firstOrDefault();
        }
        this.reset();
        if (!this.next()) {
            return undefined;
        }
        return this.value();
    };
    EnumerableBase.prototype.forEach = function (action) {
        this.reset();
        for (var i = 0; this.next(); ++i) {
            action(this.value(), i);
        }
    };
    EnumerableBase.prototype.groupBy = function (keySelector, valueSelector) {
        var array = this.toArray();
        var dictionary = new Dictionary();
        for (var i = 0; i < array.length; ++i) {
            var key = keySelector(array[i]);
            var value = valueSelector !== undefined
                ? valueSelector(array[i])
                : array[i];
            if (!dictionary.containsKey(key)) {
                dictionary.set(key, new List());
            }
            dictionary.get(key).push(value);
        }
        return dictionary.asEnumerable();
    };
    EnumerableBase.prototype.last = function (predicate) {
        var element;
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
    };
    EnumerableBase.prototype.lastOrDefault = function (predicate) {
        if (predicate !== undefined) {
            return new ConditionalEnumerable(this, predicate).lastOrDefault();
        }
        var reversed = new ReverseEnumerable(this);
        reversed.reset();
        if (!reversed.next()) {
            return undefined;
        }
        return reversed.value();
    };
    EnumerableBase.prototype.single = function (predicate) {
        var element;
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
    };
    EnumerableBase.prototype.singleOrDefault = function (predicate) {
        if (predicate !== undefined) {
            return new ConditionalEnumerable(this, predicate).singleOrDefault();
        }
        this.reset();
        if (!this.next()) {
            return undefined;
        }
        var element = this.value();
        if (this.next()) {
            throw new Error("Sequence contains more than 1 element");
        }
        return element;
    };
    EnumerableBase.prototype.distinct = function (keySelector) {
        return new UniqueEnumerable(this.copy(), keySelector);
    };
    EnumerableBase.prototype.aggregate = function (aggregator, initialValue) {
        var value = initialValue;
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
    };
    EnumerableBase.prototype.min = function (selector) {
        if (selector !== undefined) {
            return new TransformEnumerable(this, selector).min();
        }
        return this.aggregate(function (previous, current) {
            return (previous !== undefined && previous < current)
                ? previous
                : current;
        });
    };
    EnumerableBase.prototype.orderBy = function (keySelector, comparer) {
        return new OrderedEnumerable(this.copy(), createComparer(keySelector, true, comparer));
    };
    EnumerableBase.prototype.orderByDescending = function (keySelector) {
        return new OrderedEnumerable(this.copy(), createComparer(keySelector, false, undefined));
    };
    EnumerableBase.prototype.max = function (selector) {
        if (selector !== undefined) {
            return new TransformEnumerable(this, selector).max();
        }
        return this.aggregate(function (previous, current) {
            return (previous !== undefined && previous > current)
                ? previous
                : current;
        });
    };
    EnumerableBase.prototype.sum = function (selector) {
        return this.aggregate(function (previous, current) { return previous + selector(current); }, 0);
    };
    EnumerableBase.prototype.average = function (selector) {
        this.reset();
        if (!this.next()) {
            throw new Error("Sequence contains no elements");
        }
        var sum = 0;
        var count = 0;
        do {
            sum += selector(this.value());
            ++count;
        } while (this.next());
        return sum / count;
    };
    EnumerableBase.prototype.skip = function (amount) {
        return new RangeEnumerable(this.copy(), amount, undefined);
    };
    EnumerableBase.prototype.take = function (amount) {
        return new RangeEnumerable(this.copy(), undefined, amount);
    };
    EnumerableBase.prototype.takeWhile = function (predicate) {
        return new TakeWhileEnumerable(this.copy(), predicate);
    };
    EnumerableBase.prototype.union = function (other) {
        return new UniqueEnumerable(this.concat(other));
    };
    EnumerableBase.prototype.zip = function (other, selector) {
        var otherAsEnumerable = other instanceof Array
            ? new ArrayEnumerable(other)
            : other.asEnumerable();
        return new ZippedEnumerable(this, otherAsEnumerable, selector);
    };
    return EnumerableBase;
}());
export { EnumerableBase };
var Enumerable = (function (_super) {
    __extends(Enumerable, _super);
    function Enumerable(source) {
        var _this = _super.call(this, source) || this;
        _this.currentValue = new Cached();
        return _this;
    }
    Enumerable.fromSource = function (source) {
        if (source instanceof Array) {
            return new ArrayEnumerable(source);
        }
        return new Enumerable(source);
    };
    Enumerable.empty = function () {
        return Enumerable.fromSource([]);
    };
    Enumerable.range = function (start, count, ascending) {
        if (ascending === void 0) { ascending = true; }
        if (count < 0) {
            throw new Error("Count must be >= 0");
        }
        var source = new Array(count);
        if (ascending) {
            for (var i = 0; i < count; source[i] = start + (i++))
                ;
        }
        else {
            for (var i = 0; i < count; source[i] = start - (i++))
                ;
        }
        return new ArrayEnumerable(source);
    };
    Enumerable.repeat = function (element, count) {
        if (count < 0) {
            throw new Error("Count must me >= 0");
        }
        var source = new Array(count);
        for (var i = 0; i < count; ++i) {
            source[i] = element;
        }
        return new ArrayEnumerable(source);
    };
    Enumerable.prototype.copy = function () {
        return new Enumerable(this.source.copy());
    };
    Enumerable.prototype.value = function () {
        if (!this.currentValue.isValid()) {
            this.currentValue.value = this.source.value();
        }
        return this.currentValue.value;
    };
    Enumerable.prototype.reset = function () {
        _super.prototype.reset.call(this);
        this.currentValue.invalidate();
    };
    Enumerable.prototype.next = function () {
        this.currentValue.invalidate();
        return _super.prototype.next.call(this);
    };
    return Enumerable;
}(EnumerableBase));
export { Enumerable };
var ConditionalEnumerable = (function (_super) {
    __extends(ConditionalEnumerable, _super);
    function ConditionalEnumerable(source, predicate) {
        var _this = _super.call(this, source) || this;
        _this._predicate = predicate;
        return _this;
    }
    ConditionalEnumerable.prototype.copy = function () {
        return new ConditionalEnumerable(this.source.copy(), this._predicate);
    };
    ConditionalEnumerable.prototype.next = function () {
        var hasValue;
        do {
            hasValue = _super.prototype.next.call(this);
        } while (hasValue && !this._predicate(this.value()));
        return hasValue;
    };
    return ConditionalEnumerable;
}(Enumerable));
export { ConditionalEnumerable };
var SkipWhileEnumerable = (function (_super) {
    __extends(SkipWhileEnumerable, _super);
    function SkipWhileEnumerable(source, predicate) {
        var _this = _super.call(this, source) || this;
        _this._predicate = predicate;
        _this._shouldContinueChecking = true;
        return _this;
    }
    SkipWhileEnumerable.prototype.reset = function () {
        _super.prototype.reset.call(this);
        this._shouldContinueChecking = true;
    };
    SkipWhileEnumerable.prototype.copy = function () {
        return new SkipWhileEnumerable(this.source.copy(), this._predicate);
    };
    SkipWhileEnumerable.prototype.next = function () {
        if (!this._shouldContinueChecking) {
            return _super.prototype.next.call(this);
        }
        var hasValue;
        do {
            hasValue = _super.prototype.next.call(this);
        } while (hasValue && this._predicate(this.value()));
        this._shouldContinueChecking = false;
        return hasValue;
    };
    return SkipWhileEnumerable;
}(Enumerable));
export { SkipWhileEnumerable };
var TakeWhileEnumerable = (function (_super) {
    __extends(TakeWhileEnumerable, _super);
    function TakeWhileEnumerable(source, predicate) {
        var _this = _super.call(this, source) || this;
        _this._predicate = predicate;
        _this._shouldContinueTaking = true;
        return _this;
    }
    TakeWhileEnumerable.prototype.reset = function () {
        _super.prototype.reset.call(this);
        this._shouldContinueTaking = true;
    };
    TakeWhileEnumerable.prototype.copy = function () {
        return new TakeWhileEnumerable(this.source.copy(), this._predicate);
    };
    TakeWhileEnumerable.prototype.next = function () {
        if (_super.prototype.next.call(this)) {
            if (this._shouldContinueTaking && this._predicate(this.value())) {
                return true;
            }
        }
        this._shouldContinueTaking = false;
        return false;
    };
    return TakeWhileEnumerable;
}(Enumerable));
export { TakeWhileEnumerable };
var ConcatEnumerable = (function (_super) {
    __extends(ConcatEnumerable, _super);
    function ConcatEnumerable(left, right) {
        var _this = _super.call(this, left) || this;
        _this._otherSource = right;
        _this._isFirstSourceFinished = false;
        return _this;
    }
    ConcatEnumerable.prototype.copy = function () {
        return new ConcatEnumerable(this.source.copy(), this._otherSource.copy());
    };
    ConcatEnumerable.prototype.reset = function () {
        this.source.reset();
        this._otherSource.reset();
        this._isFirstSourceFinished = false;
        this.currentValue.invalidate();
    };
    ConcatEnumerable.prototype.next = function () {
        this.currentValue.invalidate();
        var hasValue = !this._isFirstSourceFinished
            ? this.source.next()
            : this._otherSource.next();
        if (!hasValue && !this._isFirstSourceFinished) {
            this._isFirstSourceFinished = true;
            return this.next();
        }
        return hasValue;
    };
    ConcatEnumerable.prototype.value = function () {
        if (!this.currentValue.isValid()) {
            this.currentValue.value = !this._isFirstSourceFinished
                ? this.source.value()
                : this._otherSource.value();
        }
        return this.currentValue.value;
    };
    return ConcatEnumerable;
}(Enumerable));
export { ConcatEnumerable };
var UniqueEnumerable = (function (_super) {
    __extends(UniqueEnumerable, _super);
    function UniqueEnumerable(source, keySelector) {
        var _this = _super.call(this, source) || this;
        _this._keySelector = keySelector;
        _this._seen = { primitive: { number: {}, string: {}, boolean: {} }, complex: [] };
        return _this;
    }
    UniqueEnumerable.prototype.copy = function () {
        return new UniqueEnumerable(this.source.copy(), this._keySelector);
    };
    UniqueEnumerable.prototype.reset = function () {
        _super.prototype.reset.call(this);
        this._seen = { primitive: { number: {}, string: {}, boolean: {} }, complex: [] };
    };
    UniqueEnumerable.prototype.isUnique = function (element) {
        var key = this._keySelector !== undefined
            ? this._keySelector(element)
            : element;
        var type = typeof key;
        return (type in this._seen.primitive)
            ? this._seen.primitive[type].hasOwnProperty(key)
                ? false
                : this._seen.primitive[type][key] = true
            : this._seen.complex.indexOf(key) !== -1
                ? false
                : this._seen.complex.push(key) > -1;
    };
    UniqueEnumerable.prototype.next = function () {
        var hasValue;
        do {
            hasValue = _super.prototype.next.call(this);
        } while (hasValue && !this.isUnique(this.value()));
        return hasValue;
    };
    return UniqueEnumerable;
}(Enumerable));
export { UniqueEnumerable };
var RangeEnumerable = (function (_super) {
    __extends(RangeEnumerable, _super);
    function RangeEnumerable(source, start, count) {
        var _this = this;
        if ((start !== undefined && start < 0) || (count !== undefined && count < 0)) {
            throw new Error("Incorrect parameters");
        }
        _this = _super.call(this, source) || this;
        _this._start = start;
        _this._count = count;
        _this._currentIndex = -1;
        return _this;
    }
    RangeEnumerable.prototype.copy = function () {
        return new RangeEnumerable(this.source.copy(), this._start, this._count);
    };
    RangeEnumerable.prototype.reset = function () {
        _super.prototype.reset.call(this);
        this._currentIndex = -1;
    };
    RangeEnumerable.prototype.isValidIndex = function () {
        var start = this._start !== undefined ? this._start : 0;
        var end = this._count !== undefined ? start + this._count : undefined;
        return this._currentIndex >= start && (end === undefined || this._currentIndex < end);
    };
    RangeEnumerable.prototype.performSkip = function () {
        var start = this._start !== undefined ? this._start : 0;
        var hasValue = true;
        while (hasValue && this._currentIndex + 1 < start) {
            hasValue = _super.prototype.next.call(this);
            ++this._currentIndex;
        }
        return hasValue;
    };
    RangeEnumerable.prototype.next = function () {
        if (this._currentIndex < 0 && !this.performSkip()) {
            return false;
        }
        ++this._currentIndex;
        return _super.prototype.next.call(this) && this.isValidIndex();
    };
    RangeEnumerable.prototype.value = function () {
        if (!this.isValidIndex()) {
            throw new Error("Out of bounds");
        }
        return _super.prototype.value.call(this);
    };
    return RangeEnumerable;
}(Enumerable));
export { RangeEnumerable };
var TransformEnumerable = (function (_super) {
    __extends(TransformEnumerable, _super);
    function TransformEnumerable(source, transform) {
        var _this = _super.call(this, source) || this;
        _this._transform = transform;
        _this._currentValue = new Cached();
        return _this;
    }
    TransformEnumerable.prototype.copy = function () {
        return new TransformEnumerable(this.source.copy(), this._transform);
    };
    TransformEnumerable.prototype.value = function () {
        if (!this._currentValue.isValid()) {
            this._currentValue.value = this._transform(this.source.value());
        }
        return this._currentValue.value;
    };
    TransformEnumerable.prototype.reset = function () {
        _super.prototype.reset.call(this);
        this._currentValue.invalidate();
    };
    TransformEnumerable.prototype.next = function () {
        this._currentValue.invalidate();
        return _super.prototype.next.call(this);
    };
    return TransformEnumerable;
}(EnumerableBase));
export { TransformEnumerable };
var ReverseEnumerable = (function (_super) {
    __extends(ReverseEnumerable, _super);
    function ReverseEnumerable(source) {
        var _this = _super.call(this, source) || this;
        _this._elements = new Cached();
        _this._currentIndex = -1;
        return _this;
    }
    ReverseEnumerable.prototype.copy = function () {
        return new ReverseEnumerable(this.source.copy());
    };
    ReverseEnumerable.prototype.reset = function () {
        this._elements.invalidate();
        this._currentIndex = -1;
    };
    ReverseEnumerable.prototype.isValidIndex = function () {
        return this._currentIndex >= 0
            && this._currentIndex < this._elements.value.length;
    };
    ReverseEnumerable.prototype.all = function (predicate) {
        return this.source.all(predicate);
    };
    ReverseEnumerable.prototype.any = function (predicate) {
        if (predicate !== undefined) {
            return this.source.any(predicate);
        }
        return this.source.any();
    };
    ReverseEnumerable.prototype.average = function (selector) {
        return this.source.average(selector);
    };
    ReverseEnumerable.prototype.count = function (predicate) {
        if (predicate !== undefined) {
            return this.source.count(predicate);
        }
        return this.source.count();
    };
    ReverseEnumerable.prototype.max = function (selector) {
        if (selector !== undefined) {
            return this.source.max(selector);
        }
        return this.source.max();
    };
    ReverseEnumerable.prototype.min = function (selector) {
        if (selector !== undefined) {
            return this.source.min(selector);
        }
        return this.source.min();
    };
    ReverseEnumerable.prototype.reverse = function () {
        return this.source.copy();
    };
    ReverseEnumerable.prototype.sum = function (selector) {
        return this.source.sum(selector);
    };
    ReverseEnumerable.prototype.next = function () {
        if (!this._elements.isValid()) {
            this._elements.value = this.source.toArray();
        }
        ++this._currentIndex;
        return this.isValidIndex();
    };
    ReverseEnumerable.prototype.value = function () {
        if (!this._elements.isValid() || !this.isValidIndex()) {
            throw new Error("Out of bounds");
        }
        return this._elements.value[(this._elements.value.length - 1) - this._currentIndex];
    };
    return ReverseEnumerable;
}(Enumerable));
export { ReverseEnumerable };
var OrderedEnumerable = (function (_super) {
    __extends(OrderedEnumerable, _super);
    function OrderedEnumerable(source, comparer) {
        var _this = _super.call(this, source) || this;
        _this._comparer = comparer;
        _this._elements = new Cached();
        _this._currentIndex = -1;
        return _this;
    }
    OrderedEnumerable.prototype.isValidIndex = function () {
        return this._currentIndex >= 0
            && this._currentIndex < this._elements.value.length;
    };
    OrderedEnumerable.prototype.orderBy = function (keySelector, comparer) {
        return new OrderedEnumerable(this.source.copy(), createComparer(keySelector, true, comparer));
    };
    OrderedEnumerable.prototype.orderByDescending = function (keySelector) {
        return new OrderedEnumerable(this.source.copy(), createComparer(keySelector, false, undefined));
    };
    OrderedEnumerable.prototype.thenBy = function (keySelector, comparer) {
        return new OrderedEnumerable(this.source.copy(), combineComparers(this._comparer, createComparer(keySelector, true, comparer)));
    };
    OrderedEnumerable.prototype.thenByDescending = function (keySelector) {
        return new OrderedEnumerable(this.source.copy(), combineComparers(this._comparer, createComparer(keySelector, false, undefined)));
    };
    OrderedEnumerable.prototype.reset = function () {
        this._elements.invalidate();
        this._currentIndex = -1;
    };
    OrderedEnumerable.prototype.copy = function () {
        return new OrderedEnumerable(this.source.copy(), this._comparer);
    };
    OrderedEnumerable.prototype.value = function () {
        if (!this._elements.isValid() || !this.isValidIndex()) {
            throw new Error("Out of bounds");
        }
        return this._elements.value[this._currentIndex];
    };
    OrderedEnumerable.prototype.next = function () {
        if (!this._elements.isValid()) {
            this._elements.value = this.toArray();
        }
        ++this._currentIndex;
        return this.isValidIndex();
    };
    OrderedEnumerable.prototype.toArray = function () {
        var result = this.source.toArray();
        return result.sort(this._comparer);
    };
    return OrderedEnumerable;
}(EnumerableBase));
export { OrderedEnumerable };
var ArrayEnumerable = (function (_super) {
    __extends(ArrayEnumerable, _super);
    function ArrayEnumerable(source) {
        var _this = _super.call(this, new ArrayIterator(source)) || this;
        _this.list = new List(source);
        return _this;
    }
    ArrayEnumerable.prototype.toArray = function () {
        return this.list.toArray();
    };
    ArrayEnumerable.prototype.aggregate = function (aggregator, initialValue) {
        if (initialValue !== undefined) {
            return this.list.aggregate(aggregator, initialValue);
        }
        return this.list.aggregate(aggregator);
    };
    ArrayEnumerable.prototype.any = function (predicate) {
        if (predicate !== undefined) {
            return this.list.any(predicate);
        }
        return this.list.any();
    };
    ArrayEnumerable.prototype.all = function (predicate) {
        return this.list.all(predicate);
    };
    ArrayEnumerable.prototype.average = function (selector) {
        return this.list.average(selector);
    };
    ArrayEnumerable.prototype.count = function (predicate) {
        if (predicate !== undefined) {
            return this.list.count(predicate);
        }
        return this.list.count();
    };
    ArrayEnumerable.prototype.copy = function () {
        return new ArrayEnumerable(this.list.asArray());
    };
    ArrayEnumerable.prototype.elementAtOrDefault = function (index) {
        return this.list.elementAtOrDefault(index);
    };
    ArrayEnumerable.prototype.firstOrDefault = function (predicate) {
        if (predicate !== undefined) {
            return this.list.firstOrDefault(predicate);
        }
        return this.list.firstOrDefault();
    };
    ArrayEnumerable.prototype.lastOrDefault = function (predicate) {
        if (predicate !== undefined) {
            return this.list.lastOrDefault(predicate);
        }
        return this.list.lastOrDefault();
    };
    return ArrayEnumerable;
}(Enumerable));
export { ArrayEnumerable };
var DefaultIfEmptyEnumerable = (function (_super) {
    __extends(DefaultIfEmptyEnumerable, _super);
    function DefaultIfEmptyEnumerable(source, defaultValue) {
        var _this = _super.call(this, source) || this;
        _this._mustUseDefaultValue = undefined;
        _this._defaultValue = defaultValue;
        return _this;
    }
    DefaultIfEmptyEnumerable.prototype.copy = function () {
        return new DefaultIfEmptyEnumerable(this.source.copy(), this._defaultValue);
    };
    DefaultIfEmptyEnumerable.prototype.value = function () {
        if (this._mustUseDefaultValue) {
            return this._defaultValue;
        }
        return this.source.value();
    };
    DefaultIfEmptyEnumerable.prototype.next = function () {
        var hasNextElement = _super.prototype.next.call(this);
        this._mustUseDefaultValue = this._mustUseDefaultValue === undefined && !hasNextElement;
        return this._mustUseDefaultValue || hasNextElement;
    };
    DefaultIfEmptyEnumerable.prototype.reset = function () {
        _super.prototype.reset.call(this);
        this._mustUseDefaultValue = undefined;
    };
    return DefaultIfEmptyEnumerable;
}(EnumerableBase));
export { DefaultIfEmptyEnumerable };
var ZippedEnumerable = (function (_super) {
    __extends(ZippedEnumerable, _super);
    function ZippedEnumerable(source, otherSource, selector) {
        var _this = _super.call(this, source) || this;
        _this._otherSource = otherSource;
        _this._isOneOfTheSourcesFinished = false;
        _this._currentValue = new Cached();
        _this._selector = selector;
        return _this;
    }
    ZippedEnumerable.prototype.copy = function () {
        return new ZippedEnumerable(this.source.copy(), this._otherSource.copy(), this._selector);
    };
    ZippedEnumerable.prototype.value = function () {
        if (!this._currentValue.isValid()) {
            this._currentValue.value = this._selector(this.source.value(), this._otherSource.value());
        }
        return this._currentValue.value;
    };
    ZippedEnumerable.prototype.reset = function () {
        _super.prototype.reset.call(this);
        this._otherSource.reset();
        this._isOneOfTheSourcesFinished = false;
        this._currentValue.invalidate();
    };
    ZippedEnumerable.prototype.next = function () {
        this._currentValue.invalidate();
        if (!this._isOneOfTheSourcesFinished) {
            this._isOneOfTheSourcesFinished = !_super.prototype.next.call(this) || !this._otherSource.next();
        }
        return !this._isOneOfTheSourcesFinished;
    };
    return ZippedEnumerable;
}(EnumerableBase));
export { ZippedEnumerable };
//# sourceMappingURL=Enumerables.js.map