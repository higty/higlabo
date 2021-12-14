export const strictEqualityComparer = () => (left, right) => left === right;
export function combineComparers(left, right) {
    return (l, r) => left(l, r) || right(l, r);
}
export function createComparer(keySelector, ascending, customComparer) {
    if (customComparer !== undefined) {
        return (l, r) => customComparer(keySelector(l), keySelector(r));
    }
    return ascending
        ? (l, r) => {
            const left = keySelector(l);
            const right = keySelector(r);
            return left < right
                ? -1
                : left > right
                    ? 1
                    : 0;
        }
        : (l, r) => {
            const left = keySelector(l);
            const right = keySelector(r);
            return left < right
                ? 1
                : left > right
                    ? -1
                    : 0;
        };
}
//# sourceMappingURL=Comparers.js.map