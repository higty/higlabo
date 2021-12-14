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
var __spreadArrays = (this && this.__spreadArrays) || function () {
    for (var s = 0, i = 0, il = arguments.length; i < il; i++) s += arguments[i].length;
    for (var r = Array(s), k = 0, i = 0; i < il; i++)
        for (var a = arguments[i], j = 0, jl = a.length; j < jl; j++, k++)
            r[k] = a[j];
    return r;
};
import { ArrayEnumerable, ConcatEnumerable, ConditionalEnumerable, Enumerable, OrderedEnumerable, RangeEnumerable, ReverseEnumerable, TransformEnumerable, UniqueEnumerable, } from "./Enumerables.js";
import { strictEqualityComparer, createComparer } from "./Comparers.js";
var EnumerableCollection = (function () {
    function EnumerableCollection() {
    }
    EnumerableCollection.prototype.toList = function () {
        return new List(this.toArray());
    };
    EnumerableCollection.prototype.toDictionary = function (keySelector, valueSelector) {
        return Dictionary.fromArray(this.toArray(), keySelector, valueSelector);
    };
    EnumerableCollection.prototype.reverse = function () {
        return new ReverseEnumerable(this.asEnumerable());
    };
    EnumerableCollection.prototype.concat = function (other) {
        var _a;
        var others = [];
        for (var _i = 1; _i < arguments.length; _i++) {
            others[_i - 1] = arguments[_i];
        }
        return (_a = this.asEnumerable()).concat.apply(_a, __spreadArrays([other], others));
    };
    EnumerableCollection.prototype.contains = function (element) {
        return this.any(function (e) { return e === element; });
    };
    EnumerableCollection.prototype.where = function (predicate) {
        return new ConditionalEnumerable(this.asEnumerable(), predicate);
    };
    EnumerableCollection.prototype.select = function (selector) {
        return new TransformEnumerable(this.asEnumerable(), selector);
    };
    EnumerableCollection.prototype.selectMany = function (selector) {
        var selectToEnumerable = function (e) {
            var ie = selector(e);
            return ie instanceof Array
                ? new ArrayEnumerable(ie)
                : ie.asEnumerable();
        };
        return this
            .select(selectToEnumerable).toArray()
            .reduce(function (p, c) { return new ConcatEnumerable(p, c); }, Enumerable.empty());
    };
    EnumerableCollection.prototype.elementAt = function (index) {
        var element = this.elementAtOrDefault(index);
        if (element === undefined) {
            throw new Error("Out of bounds");
        }
        return element;
    };
    EnumerableCollection.prototype.except = function (other) {
        return this.asEnumerable().except(other);
    };
    EnumerableCollection.prototype.first = function (predicate) {
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
    EnumerableCollection.prototype.groupBy = function (keySelector, valueSelector) {
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
    EnumerableCollection.prototype.last = function (predicate) {
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
    EnumerableCollection.prototype.single = function (predicate) {
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
    EnumerableCollection.prototype.singleOrDefault = function (predicate) {
        if (predicate !== undefined) {
            return this.asEnumerable().singleOrDefault(predicate);
        }
        return this.asEnumerable().singleOrDefault();
    };
    EnumerableCollection.prototype.skipWhile = function (predicate) {
        return this.asEnumerable().skipWhile(predicate);
    };
    EnumerableCollection.prototype.takeWhile = function (predicate) {
        return this.asEnumerable().takeWhile(predicate);
    };
    EnumerableCollection.prototype.sequenceEqual = function (other, comparer) {
        if (comparer !== undefined) {
            return this.asEnumerable().sequenceEqual(other, comparer);
        }
        return this.asEnumerable().sequenceEqual(other);
    };
    EnumerableCollection.prototype.distinct = function (keySelector) {
        return new UniqueEnumerable(this.asEnumerable(), keySelector);
    };
    EnumerableCollection.prototype.min = function (selector) {
        if (selector !== undefined) {
            return new TransformEnumerable(this.asEnumerable(), selector).min();
        }
        return this.aggregate(function (previous, current) {
            return (previous !== undefined && previous < current)
                ? previous
                : current;
        });
    };
    EnumerableCollection.prototype.orderBy = function (keySelector, comparer) {
        return new OrderedEnumerable(this.asEnumerable(), createComparer(keySelector, true, comparer));
    };
    EnumerableCollection.prototype.orderByDescending = function (keySelector) {
        return new OrderedEnumerable(this.asEnumerable(), createComparer(keySelector, false, undefined));
    };
    EnumerableCollection.prototype.max = function (selector) {
        if (selector !== undefined) {
            return new TransformEnumerable(this.asEnumerable(), selector).max();
        }
        return this.aggregate(function (previous, current) {
            return (previous !== undefined && previous > current)
                ? previous
                : current;
        });
    };
    EnumerableCollection.prototype.sum = function (selector) {
        return this.aggregate(function (previous, current) { return previous + selector(current); }, 0);
    };
    EnumerableCollection.prototype.skip = function (amount) {
        return new RangeEnumerable(this.asEnumerable(), amount, undefined);
    };
    EnumerableCollection.prototype.take = function (amount) {
        return new RangeEnumerable(this.asEnumerable(), undefined, amount);
    };
    EnumerableCollection.prototype.union = function (other) {
        return new UniqueEnumerable(this.concat(other));
    };
    EnumerableCollection.prototype.aggregate = function (aggregator, initialValue) {
        if (initialValue !== undefined) {
            return this.asEnumerable().aggregate(aggregator, initialValue);
        }
        return this.asEnumerable().aggregate(aggregator);
    };
    EnumerableCollection.prototype.any = function (predicate) {
        if (predicate !== undefined) {
            return this.asEnumerable().any(predicate);
        }
        return this.asEnumerable().any();
    };
    EnumerableCollection.prototype.all = function (predicate) {
        return this.asEnumerable().all(predicate);
    };
    EnumerableCollection.prototype.average = function (selector) {
        return this.asEnumerable().average(selector);
    };
    EnumerableCollection.prototype.count = function (predicate) {
        if (predicate !== undefined) {
            return this.asEnumerable().count(predicate);
        }
        return this.asEnumerable().count();
    };
    EnumerableCollection.prototype.elementAtOrDefault = function (index) {
        return this.asEnumerable().elementAtOrDefault(index);
    };
    EnumerableCollection.prototype.firstOrDefault = function (predicate) {
        if (predicate !== undefined) {
            return this.asEnumerable().firstOrDefault(predicate);
        }
        return this.asEnumerable().firstOrDefault();
    };
    EnumerableCollection.prototype.lastOrDefault = function (predicate) {
        if (predicate !== undefined) {
            return this.asEnumerable().lastOrDefault(predicate);
        }
        return this.asEnumerable().lastOrDefault();
    };
    EnumerableCollection.prototype.forEach = function (action) {
        return this.asEnumerable().forEach(action);
    };
    EnumerableCollection.prototype.defaultIfEmpty = function (defaultValue) {
        if (defaultValue !== undefined) {
            return this.asEnumerable().defaultIfEmpty(defaultValue);
        }
        return this.asEnumerable().defaultIfEmpty();
    };
    EnumerableCollection.prototype.zip = function (other, selector) {
        return this.asEnumerable().zip(other, selector);
    };
    return EnumerableCollection;
}());
export { EnumerableCollection };
var ArrayQueryable = (function (_super) {
    __extends(ArrayQueryable, _super);
    function ArrayQueryable(elements) {
        if (elements === void 0) { elements = []; }
        var _this = _super.call(this) || this;
        _this.source = elements;
        return _this;
    }
    ArrayQueryable.prototype.asArray = function () {
        return this.source;
    };
    ArrayQueryable.prototype.toArray = function () {
        return [].concat(this.source);
    };
    ArrayQueryable.prototype.toList = function () {
        return new List(this.toArray());
    };
    ArrayQueryable.prototype.asEnumerable = function () {
        return new ArrayEnumerable(this.source);
    };
    ArrayQueryable.prototype.aggregate = function (aggregator, initialValue) {
        if (initialValue !== undefined) {
            return this.source.reduce(aggregator, initialValue);
        }
        return this.source.reduce(aggregator);
    };
    ArrayQueryable.prototype.any = function (predicate) {
        if (predicate !== undefined) {
            return this.source.some(predicate);
        }
        return this.source.length > 0;
    };
    ArrayQueryable.prototype.all = function (predicate) {
        return this.source.every(predicate);
    };
    ArrayQueryable.prototype.average = function (selector) {
        if (this.count() === 0) {
            throw new Error("Sequence contains no elements");
        }
        var sum = 0;
        for (var i = 0, end = this.source.length; i < end; ++i) {
            sum += selector(this.source[i]);
        }
        return sum / this.source.length;
    };
    ArrayQueryable.prototype.count = function (predicate) {
        if (predicate !== undefined) {
            return this.source.filter(predicate).length;
        }
        return this.source.length;
    };
    ArrayQueryable.prototype.elementAtOrDefault = function (index) {
        if (index < 0) {
            throw new Error("Negative index is forbiden");
        }
        return this.source[index];
    };
    ArrayQueryable.prototype.firstOrDefault = function (predicate) {
        if (predicate !== undefined) {
            return this.source.filter(predicate)[0];
        }
        return this.source[0];
    };
    ArrayQueryable.prototype.groupBy = function (keySelector, valueSelector) {
        var array = this.asArray();
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
    ArrayQueryable.prototype.lastOrDefault = function (predicate) {
        if (predicate !== undefined) {
            var records = this.source.filter(predicate);
            return records[records.length - 1];
        }
        return this.source[this.source.length - 1];
    };
    ArrayQueryable.prototype.forEach = function (action) {
        for (var i = 0, end = this.source.length; i < end; ++i) {
            action(this.source[i], i);
        }
    };
    ArrayQueryable.prototype.sequenceEqual = function (other, comparer) {
        if (comparer === void 0) { comparer = strictEqualityComparer(); }
        if (other instanceof ArrayQueryable
            || other instanceof Array) {
            var thisArray = this.asArray();
            var otherArray = other instanceof ArrayQueryable
                ? other.asArray()
                : other;
            if (thisArray.length != otherArray.length) {
                return false;
            }
            for (var i = 0; i < thisArray.length; ++i) {
                if (!comparer(thisArray[i], otherArray[i])) {
                    return false;
                }
            }
            return true;
        }
        return this.asEnumerable().sequenceEqual(other, comparer);
    };
    return ArrayQueryable;
}(EnumerableCollection));
export { ArrayQueryable };
var List = (function (_super) {
    __extends(List, _super);
    function List() {
        return _super !== null && _super.apply(this, arguments) || this;
    }
    List.prototype.copy = function () {
        return new List(this.toArray());
    };
    List.prototype.asReadOnly = function () {
        return this;
    };
    List.prototype.clear = function () {
        this.source = [];
    };
    List.prototype.remove = function (element) {
        var newSource = [];
        for (var i = 0, end = this.source.length; i < end; ++i) {
            if (this.source[i] !== element) {
                newSource.push(this.source[i]);
            }
        }
        this.source = newSource;
    };
    List.prototype.removeAt = function (index) {
        if (index < 0 || this.source[index] === undefined) {
            throw new Error("Out of bounds");
        }
        return this.source.splice(index, 1)[0];
    };
    List.prototype.get = function (index) {
        return this.source[index];
    };
    List.prototype.push = function (element) {
        return this.source.push(element);
    };
    List.prototype.pushIfNotExists = function (element, selector) {
        var r = this.firstOrDefault(selector);
        if (r == null) {
            return this.source.push(element);
        }
        else {
            return this.source.length;
        }
    };
    List.prototype.pushRange = function (elements) {
        if (!(elements instanceof Array)) {
            elements = elements.toArray();
        }
        return this.source.push.apply(this.source, elements);
    };
    List.prototype.pushFront = function (element) {
        return this.source.unshift(element);
    };
    List.prototype.replace = function (element, selector) {
        for (var i = 0; i < this.source.length; i++) {
            if (selector(this.source[i]) == true) {
                this.source[i] = element;
                return i;
            }
        }
        return this.source.push(element);
    };
    List.prototype.pop = function () {
        return this.source.pop();
    };
    List.prototype.popFront = function () {
        return this.source.shift();
    };
    List.prototype.set = function (index, element) {
        if (index < 0) {
            throw new Error("Out of bounds");
        }
        this.source[index] = element;
    };
    List.prototype.insert = function (index, element) {
        if (index < 0 || index > this.source.length) {
            throw new Error("Out of bounds");
        }
        this.source.splice(index, 0, element);
    };
    List.prototype.indexOf = function (element) {
        return this.source.indexOf(element);
    };
    List.prototype.sort = function (comparerList) {
        this.asArray().sort(function (x, y) {
            for (var i = 0; i < comparerList.length; i++) {
                var comparer = comparerList[i];
                var result = comparer(x, y);
                if (result != 0) {
                    return result;
                }
            }
            return 0;
        });
    };
    return List;
}(ArrayQueryable));
export { List };
var Stack = (function (_super) {
    __extends(Stack, _super);
    function Stack() {
        return _super !== null && _super.apply(this, arguments) || this;
    }
    Stack.prototype.copy = function () {
        return new Stack(this.toArray());
    };
    Stack.prototype.clear = function () {
        this.source = [];
    };
    Stack.prototype.peek = function () {
        return this.source[this.source.length - 1];
    };
    Stack.prototype.pop = function () {
        return this.source.pop();
    };
    Stack.prototype.push = function (element) {
        return this.source.push(element);
    };
    return Stack;
}(ArrayQueryable));
export { Stack };
var Dictionary = (function (_super) {
    __extends(Dictionary, _super);
    function Dictionary(keyValuePairs) {
        var _this = _super.call(this) || this;
        _this.clear();
        if (keyValuePairs !== undefined) {
            for (var i = 0; i < keyValuePairs.length; ++i) {
                var pair = keyValuePairs[i];
                _this.set(pair.key, pair.value);
            }
        }
        return _this;
    }
    Dictionary.fromArray = function (array, keySelector, valueSelector) {
        var keyValuePairs = array.map(function (v) {
            return {
                key: keySelector(v),
                value: valueSelector(v),
            };
        });
        return new Dictionary(keyValuePairs);
    };
    Dictionary.fromJsObject = function (object) {
        var keys = new List(Object.getOwnPropertyNames(object));
        var keyValues = keys.select(function (k) { return ({ key: k, value: object[k] }); });
        return new Dictionary(keyValues.toArray());
    };
    Dictionary.prototype.copy = function () {
        return new Dictionary(this.toArray());
    };
    Dictionary.prototype.asReadOnly = function () {
        return this;
    };
    Dictionary.prototype.asEnumerable = function () {
        return new ArrayEnumerable(this.toArray());
    };
    Dictionary.prototype.toArray = function () {
        var _this = this;
        return this.getKeys().select(function (p) {
            return {
                key: p,
                value: _this.dictionary[p],
            };
        }).toArray();
    };
    Dictionary.prototype.clear = function () {
        this.dictionary = {};
    };
    Dictionary.prototype.containsKey = function (key) {
        return this.dictionary.hasOwnProperty(key);
    };
    Dictionary.prototype.containsValue = function (value) {
        var keys = this.getKeysFast();
        for (var i = 0; i < keys.length; ++i) {
            if (this.dictionary[keys[i]] === value) {
                return true;
            }
        }
        return false;
    };
    Dictionary.prototype.getKeys = function () {
        var _this = this;
        var keys = this.getKeysFast();
        return new List(keys.map(function (k) { return _this.keyType === "number"
            ? parseFloat(k)
            : k; }));
    };
    Dictionary.prototype.getKeysFast = function () {
        return Object.getOwnPropertyNames(this.dictionary);
    };
    Dictionary.prototype.getValues = function () {
        var keys = this.getKeysFast();
        var result = new Array(keys.length);
        for (var i = 0; i < keys.length; ++i) {
            result[i] = this.dictionary[keys[i]];
        }
        return new List(result);
    };
    Dictionary.prototype.remove = function (key) {
        if (this.containsKey(key)) {
            delete this.dictionary[key];
        }
    };
    Dictionary.prototype.get = function (key) {
        if (!this.containsKey(key)) {
            throw new Error("Key doesn't exist: " + key);
        }
        return this.dictionary[key];
    };
    Dictionary.prototype.set = function (key, value) {
        if (this.containsKey(key)) {
            throw new Error("Key already exists: " + key);
        }
        this.setOrUpdate(key, value);
    };
    Dictionary.prototype.setOrUpdate = function (key, value) {
        if (this.keyType === undefined) {
            this.keyType = typeof key;
        }
        this.dictionary[key] = value;
    };
    return Dictionary;
}(EnumerableCollection));
export { Dictionary };
//# sourceMappingURL=Collections.js.map