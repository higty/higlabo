/*
 * Created by Ivan Sanz (@isc30)
 * Copyright © 2017 Ivan Sanz Carasa. All rights reserved.
*/

export interface IIterable<TElement>
{
    copy(): IIterable<TElement>;
    reset(): void;
    next(): boolean;
    value(): TElement;
}

/* ES6 compatibility layer :D
interface IteratorResult<T>
{
    done: boolean;
    value: T;
}

interface Iterator<T>
{
    next(value?: any): IteratorResult<T>;
    return?(value?: any): IteratorResult<T>;
    throw?(e?: any): IteratorResult<T>;
}*/

export class ArrayIterator<TElement> implements IIterable<TElement>
{
    protected readonly source: TElement[];
    private _index: number;

    public constructor(source: TElement[])
    {
        this.source = source;
        this.reset();
    }

    public copy(): IIterable<TElement>
    {
        return new ArrayIterator<TElement>(this.source);
    }

    public reset(): void
    {
        this._index = -1;
    }

    private isValidIndex(): boolean
    {
        return this._index >= 0 && this._index < this.source.length;
    }

    public next(): boolean
    {
        ++this._index;

        return this.isValidIndex();
    }

    public value(): TElement
    {
        if (!this.isValidIndex())
        {
            throw new Error("Out of bounds");
        }

        return this.source[this._index];
    }
}
