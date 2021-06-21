export var strictEqualityComparer = function () { return function (left, right) { return left === right; }; };
export function combineComparers(left, right) {
    return function (l, r) { return left(l, r) || right(l, r); };
}
export function createComparer(keySelector, ascending, customComparer) {
    if (customComparer !== undefined) {
        return function (l, r) { return customComparer(keySelector(l), keySelector(r)); };
    }
    return ascending
        ? function (l, r) {
            var left = keySelector(l);
            var right = keySelector(r);
            return left < right
                ? -1
                : left > right
                    ? 1
                    : 0;
        }
        : function (l, r) {
            var left = keySelector(l);
            var right = keySelector(r);
            return left < right
                ? 1
                : left > right
                    ? -1
                    : 0;
        };
}
//# sourceMappingURL=Comparers.js.map