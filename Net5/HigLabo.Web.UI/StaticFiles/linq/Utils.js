var Cached = (function () {
    function Cached() {
        this._isValid = false;
    }
    Cached.prototype.invalidate = function () {
        this._isValid = false;
    };
    Cached.prototype.isValid = function () {
        return this._isValid;
    };
    Object.defineProperty(Cached.prototype, "value", {
        get: function () {
            if (!this._isValid) {
                throw new Error("Trying to get value of invalid cache");
            }
            return this._value;
        },
        set: function (value) {
            this._value = value;
            this._isValid = true;
        },
        enumerable: false,
        configurable: true
    });
    return Cached;
}());
export { Cached };
//# sourceMappingURL=Utils.js.map