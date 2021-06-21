export class DateTime {
    public static timeZoneMinute = 9 * 60;

    private rawValue: Date;
    private i18n = {
        dayNames: [
            "Sun", "Mon", "Tue", "Wed", "Thu", "Fri", "Sat",
            "Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday"
        ],
        monthNames: [
            "Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec",
            "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"
        ]
    }
    public dateFormat = {
        default: "ddd mmm dd yyyy HH:MM:ss",
        shortDate: "m/d/yy",
        mediumDate: "mmm d, yyyy",
        longDate: "mmmm d, yyyy",
        fullDate: "dddd, mmmm d, yyyy",
        shortTime: "h:MM TT",
        mediumTime: "h:MM:ss TT",
        longTime: "h:MM:ss TT Z",
        isoDate: "yyyy-mm-dd",
        isoTime: "HH:MM:ss",
        isoDateTime: "yyyy-mm-dd'T'HH:MM:ss",
        isoUtcDateTime: "UTC:yyyy-mm-dd'T'HH:MM:ss'Z'"
    };

    get value(): Date {
        return this.rawValue;
    }
    get ticks(): number {
        return this.rawValue.valueOf();
    }
    get milliSecond(): number {
        return this.rawValue.getMilliseconds();
    }
    get second(): number {
        return this.rawValue.getSeconds();
    }
    get minute(): number {
        return this.rawValue.getMinutes();
    }
    get hours(): number {
        return this.rawValue.getHours();
    }
    get day(): number {
        return this.rawValue.getDate();
    }
    get month(): number {
        return this.rawValue.getMonth() + 1;
    }
    get year(): number {
        return this.rawValue.getFullYear();
    }
    get dayOfWeek(): DayOfWeek {
        const dw = this.rawValue.getDay();
        switch (dw) {
            case 0: return DayOfWeek.Sunday;
            case 1: return DayOfWeek.Monday;
            case 2: return DayOfWeek.Tuesday;
            case 3: return DayOfWeek.Wednesday;
            case 4: return DayOfWeek.Thursday;
            case 5: return DayOfWeek.Friday;
            case 6: return DayOfWeek.Saturday;
        }
        throw new Error("Invalid dayOfWeek");
    }

    constructor(value: Date | string | number) {
        if (value instanceof Date) {
            this.rawValue = value;
        }
        else if (typeof value === "number") {
            this.rawValue = new Date(value);
        }
        else if (typeof value === "string") {
            this.rawValue = new Date(value);
        }
    }

    public addMilliSecond(value: number): DateTime {
        const v = this.rawValue.valueOf() + value;
        return new DateTime(new Date(v));
    }
    public addSecond(value: number): DateTime {
        const v = this.rawValue.valueOf() + value * 1000;
        return new DateTime(new Date(v));
    }
    public addMinute(value: number): DateTime {
        const v = this.rawValue.valueOf() + value * 60 * 1000;
        return new DateTime(new Date(v));
    }
    public addHour(value: number): DateTime {
        const v = this.rawValue.valueOf() + value * 3600 * 1000;
        return new DateTime(new Date(v));
    }
    public addDay(value: number): DateTime {
        const v = this.rawValue.valueOf() + value * 24 * 3600 * 1000;
        return new DateTime(new Date(v));
    }
    public addMonth(value: number): DateTime {
        const newMonth = (this.month + value);
        if (newMonth > 12) {
            const dayOfMonth = this.dayOfMonth(this.year + (newMonth / 12), newMonth % 12);
            if (this.day > dayOfMonth) {
                return new DateTime(new Date(this.year + (newMonth / 12), newMonth % 12 - 1, dayOfMonth));
            }
            else {
                return new DateTime(new Date(this.year + (newMonth / 12), newMonth % 12 - 1, this.day));
            }
        }
        else {
            const dayOfMonth = this.dayOfMonth(this.year, newMonth);
            if (this.day > dayOfMonth) {
                return new DateTime(new Date(this.year, newMonth - 1, dayOfMonth));
            }
            else {
                return new DateTime(new Date(this.year, newMonth - 1, this.day));
            }
        }
    }
    public addYear(value: number): DateTime {
        const dayOfMonth = this.dayOfMonth(this.year + value, this.month);
        if (this.day > dayOfMonth) {
            return new DateTime(new Date(this.year + value, this.month, dayOfMonth));
        }
        else {
            return new DateTime(new Date(this.year + value, this.month, this.day));
        }
    }
    public add(value: TimeSpan): DateTime {
        const v = this.rawValue.valueOf() + value.totalMilliSeconds;
        return new DateTime(new Date(v));
    }
    public getDayOfWeekName(): string {
        const dw = this.rawValue.getDay();
        switch (dw) {
            case 0: return "Sunday";
            case 1: return "Monday";
            case 2: return "Tuesday";
            case 3: return "Wednesday";
            case 4: return "Thursday";
            case 5: return "Friday";
            case 6: return "Saturday";
        }
        throw new Error("Invalid dayOfWeek");
    }
    public getTimezoneOffset(): number {
        if (this.rawValue == null) { return null; }
        return this.rawValue.getTimezoneOffset();
    }
    public setTimeZone(timeZoneMinute: number): DateTime {
        const currentTimeZone = -this.rawValue.getTimezoneOffset();
        if (timeZoneMinute == null) {
            timeZoneMinute = DateTime.timeZoneMinute;
        }
        const dtime = new DateTime(this.rawValue).addMinute(timeZoneMinute - currentTimeZone);
        return dtime;
    }

    public static getToday(): DateTime {
        const d = new DateTime(new Date());
        return new DateTime(new Date(d.year, d.month - 1, d.day));
    }
    public isToday(): boolean {
        const d = new DateTime(new Date());
        const today = new DateTime(new Date(d.year, d.month - 1, d.day));
        return this.year == today.year && this.month == today.month && this.day == today.day;
    }
    public timeOfDay(): TimeSpan {
        const s = (24 * 3600 * this.day + 3600 * this.hours + 60 * this.minute + this.second);
        return new TimeSpan(s * 1000 + this.milliSecond);
    }
    public isEqual(value: DateTime): boolean {
        return this.rawValue.getTime() === value.rawValue.getTime();
    }
    public isDateEqual(value: DateTime): boolean {
        return this.year == value.year && this.month == value.month && this.day == value.day;
    }
    public isTimeEqual(value: DateTime): boolean {
        return this.hours == value.hours && this.minute == value.minute && this.second == value.second && this.milliSecond == value.milliSecond;
    }

    public dayOfMonth(year: number, month: number) {
        if (month == 12) {
            const d = new DateTime(new Date(year + 1, 1, 1));
            d.addDay(-1);
            return d.day;
        }
        else {
            const d = new DateTime(new Date(year, month, 1));
            d.addDay(-1);
            return d.day;
        }
    }

    public toString(dateFormat: string): string {
        if (this.rawValue.toString() == "Invalid Date") { return ""; }

        const z = {
            M: this.month,
            d: this.day,
            h: this.hours,
            H: this.hours,
            m: this.minute,
            s: this.second,
            f: this.milliSecond
        };
        const v = dateFormat.replace(/(M+|d+|h+|H+|m+|s+|f+)/g, function (v) {
            return ((v.length > 1 ? "0" : "") + z[v.slice(-1)]).slice(-2)
        });

        const fullYear = this.year.toString();
        const dateTimeText = v.replace(/(y+)/g, function (v) {
            return fullYear.slice(-v.length)
        });
        return dateTimeText;
    }
}

export class TimeSpan {
    private _TotalMilliSeconds: number;

    get totalMilliSeconds(): number {
        return this._TotalMilliSeconds;
    }
    get milliSeconds(): number {
        return this._TotalMilliSeconds % 1000;
    }
    get seconds(): number {
        return Math.floor(this._TotalMilliSeconds / 1000) % 60;
    }
    get minutes(): number {
        return Math.floor(this._TotalMilliSeconds / (60 * 1000)) % 60;
    }
    get hours(): number {
        return Math.floor(this._TotalMilliSeconds / (60 * 60 * 1000)) % 24;
    }
    get days(): number {
        return Math.floor(this._TotalMilliSeconds / (24 * 3600 * 1000));
    }

    constructor(milliseconds: number) {
        this._TotalMilliSeconds = milliseconds;
    }
    public static substract(value1: DateTime, value2: DateTime) {
        return new TimeSpan(value1.ticks - value2.ticks);
    }
}

export enum DayOfWeek {
    Sunday = 0,
    Monday = 1,
    Tuesday = 2,
    Wednesday = 3,
    Thursday = 4,
    Friday = 5,
    Saturday = 6,
}

