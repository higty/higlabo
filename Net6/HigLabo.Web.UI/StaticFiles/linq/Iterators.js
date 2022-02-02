export class ArrayIterator {
    constructor(source) {
        this.source = source;
        this.reset();
    }
    copy() {
        return new ArrayIterator(this.source);
    }
    reset() {
        this._index = -1;
    }
    isValidIndex() {
        return this._index >= 0 && this._index < this.source.length;
    }
    next() {
        ++this._index;
        return this.isValidIndex();
    }
    value() {
        if (!this.isValidIndex()) {
            throw new Error("Out of bounds");
        }
        return this.source[this._index];
    }
}
//# sourceMappingURL=Iterators.js.map