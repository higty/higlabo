var ArrayIterator = (function () {
    function ArrayIterator(source) {
        this.source = source;
        this.reset();
    }
    ArrayIterator.prototype.copy = function () {
        return new ArrayIterator(this.source);
    };
    ArrayIterator.prototype.reset = function () {
        this._index = -1;
    };
    ArrayIterator.prototype.isValidIndex = function () {
        return this._index >= 0 && this._index < this.source.length;
    };
    ArrayIterator.prototype.next = function () {
        ++this._index;
        return this.isValidIndex();
    };
    ArrayIterator.prototype.value = function () {
        if (!this.isValidIndex()) {
            throw new Error("Out of bounds");
        }
        return this.source[this._index];
    };
    return ArrayIterator;
}());
export { ArrayIterator };
//# sourceMappingURL=Iterators.js.map