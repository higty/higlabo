/*
 * Created by Ivan Sanz (@isc30)
 * Copyright © 2017 Ivan Sanz Carasa. All rights reserved.
*/

import { Selector } from "./Types.js";

export type ComparerResult = -1 | 0 | 1;
export type Comparer<T> = (left: T, right: T) => ComparerResult;

export type EqualityComparer<T> = (left: T, right: T) => boolean;
export const strictEqualityComparer = <T>() => (left: T, right: T) => left === right;

export function combineComparers<T>(left: Comparer<T>, right: Comparer<T>): Comparer<T>
{
    return (l: T, r: T) => left(l, r) || right(l, r);
}

export function createComparer<TElement, TKey>(
    keySelector: Selector<TElement, TKey>,
    ascending: boolean,
    customComparer?: Comparer<TKey>): Comparer<TElement>
{
    if (customComparer !== undefined)
    {
        return (l: TElement, r: TElement) => customComparer(keySelector(l), keySelector(r));
    }

    return ascending
        ? (l: TElement, r: TElement) =>
            {
                const left = keySelector(l);
                const right = keySelector(r);

                return left < right
                    ? -1
                    : left > right
                        ? 1
                        : 0;
            }
        : (l: TElement, r: TElement) =>
            {
                const left = keySelector(l);
                const right = keySelector(r);

                return left < right
                    ? 1
                    : left > right
                        ? -1
                        : 0;
            };
}
