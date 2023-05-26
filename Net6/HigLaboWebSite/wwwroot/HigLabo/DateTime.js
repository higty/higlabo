export class DateTime {
    constructor(value) {
        this.dateFormat = {
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
        if (value instanceof Date) {
            this.rawValue = value;
        }
        else if (typeof value === "number") {
            this.rawValue = new Date(value);
        }
        else if (typeof value === "string") {
            this.rawValue = new Date(value);
        }
        else if (value != null && value.Year != null && value.Month != null && value.Day != null) {
            this.rawValue = new Date(value.Year, value.Month - 1, value.Day, 0, 0, 0, 0);
        }
    }
    get value() {
        return this.rawValue;
    }
    get ticks() {
        return this.rawValue.valueOf();
    }
    get milliSecond() {
        return this.rawValue.getMilliseconds();
    }
    get second() {
        return this.rawValue.getSeconds();
    }
    get minute() {
        return this.rawValue.getMinutes();
    }
    get hours() {
        return this.rawValue.getHours();
    }
    get day() {
        return this.rawValue.getDate();
    }
    get month() {
        return this.rawValue.getMonth() + 1;
    }
    get year() {
        return this.rawValue.getFullYear();
    }
    get dayOfWeek() {
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
    addMilliSecond(value) {
        const v = this.rawValue.valueOf() + value;
        return new DateTime(new Date(v));
    }
    addSecond(value) {
        const v = this.rawValue.valueOf() + value * 1000;
        return new DateTime(new Date(v));
    }
    addMinute(value) {
        const v = this.rawValue.valueOf() + value * 60 * 1000;
        return new DateTime(new Date(v));
    }
    addHour(value) {
        const v = this.rawValue.valueOf() + value * 3600 * 1000;
        return new DateTime(new Date(v));
    }
    addDay(value) {
        const v = this.rawValue.valueOf() + value * 24 * 3600 * 1000;
        return new DateTime(new Date(v));
    }
    addMonth(value) {
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
    addYear(value) {
        const dayOfMonth = this.dayOfMonth(this.year + value, this.month);
        if (this.day > dayOfMonth) {
            return new DateTime(new Date(this.year + value, this.month, dayOfMonth));
        }
        else {
            return new DateTime(new Date(this.year + value, this.month, this.day));
        }
    }
    add(value) {
        const v = this.rawValue.valueOf() + value.totalMilliSeconds;
        return new DateTime(new Date(v));
    }
    getDayOfWeekName() {
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
    getDayOfWeekText() {
        const dw = this.rawValue.getDay();
        return DateTime.dayOfWeekList[dw];
    }
    getTimezoneOffset() {
        if (this.rawValue == null) {
            return null;
        }
        return this.rawValue.getTimezoneOffset();
    }
    setTimeZone(timeZoneMinute) {
        const currentTimeZone = -this.rawValue.getTimezoneOffset();
        if (timeZoneMinute == null) {
            timeZoneMinute = DateTime.timeZoneMinute;
        }
        const dtime = new DateTime(this.rawValue).addMinute(timeZoneMinute - currentTimeZone);
        return dtime;
    }
    static getToday() {
        const d = new DateTime(new Date());
        return new DateTime(new Date(d.year, d.month - 1, d.day));
    }
    isToday() {
        const d = new DateTime(new Date());
        const today = new DateTime(new Date(d.year, d.month - 1, d.day));
        return this.year == today.year && this.month == today.month && this.day == today.day;
    }
    timeOfDay() {
        const s = (24 * 3600 * this.day + 3600 * this.hours + 60 * this.minute + this.second);
        return new TimeSpan(s * 1000 + this.milliSecond);
    }
    isEqual(value) {
        return this.rawValue.getTime() === value.rawValue.getTime();
    }
    isDateEqual(value) {
        return this.year == value.year && this.month == value.month && this.day == value.day;
    }
    isTimeEqual(value) {
        return this.hours == value.hours && this.minute == value.minute && this.second == value.second && this.milliSecond == value.milliSecond;
    }
    dayOfMonth(year, month) {
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
    toString(dateFormat) {
        if (this.rawValue.toString() == "Invalid Date") {
            return "";
        }
        const z = {
            M: this.month,
            d: this.day,
            h: this.hours,
            H: this.hours,
            m: this.minute,
            s: this.second,
            f: this.milliSecond,
            ddd: this.getDayOfWeekText()
        };
        const v = dateFormat.replace(/(M+|d+|h+|H+|m+|s+|f+)/g, function (match) {
            if (match == "ddd") {
                return z["ddd"];
            }
            else {
                const f = match.slice(-1);
                const v = z[match.slice(-1)];
                if (f == 'f') {
                    return ((match.length > 1 ? "0" : "") + v).slice(-match.length);
                }
                else {
                    return ((match.length > 1 ? "0" : "") + v).slice(-2);
                }
            }
        });
        const fullYear = this.year.toString();
        const dateTimeText = v.replace(/(y+)/g, function (v) {
            return fullYear.slice(-v.length);
        });
        return dateTimeText;
    }
    static TryCreate(value) {
        if (value == null || value == "") {
            return null;
        }
        return new DateTime(value);
    }
}
DateTime.timeZoneMinute = 9 * 60;
DateTime.dayOfWeekList = ["Sun", "Mon", "Tue", "Wed", "Thu", "Fri", "Sat"];
export class TimeSpan {
    constructor(milliseconds) {
        this._TotalMilliSeconds = milliseconds;
    }
    get totalMilliSeconds() {
        return this._TotalMilliSeconds;
    }
    get milliSeconds() {
        return this._TotalMilliSeconds % 1000;
    }
    get seconds() {
        return Math.floor(this._TotalMilliSeconds / 1000) % 60;
    }
    get minutes() {
        return Math.floor(this._TotalMilliSeconds / (60 * 1000)) % 60;
    }
    get hours() {
        return Math.floor(this._TotalMilliSeconds / (60 * 60 * 1000)) % 24;
    }
    get days() {
        return Math.floor(this._TotalMilliSeconds / (24 * 3600 * 1000));
    }
    static substract(value1, value2) {
        return new TimeSpan(value1.ticks - value2.ticks);
    }
}
export var DayOfWeek;
(function (DayOfWeek) {
    DayOfWeek[DayOfWeek["Sunday"] = 0] = "Sunday";
    DayOfWeek[DayOfWeek["Monday"] = 1] = "Monday";
    DayOfWeek[DayOfWeek["Tuesday"] = 2] = "Tuesday";
    DayOfWeek[DayOfWeek["Wednesday"] = 3] = "Wednesday";
    DayOfWeek[DayOfWeek["Thursday"] = 4] = "Thursday";
    DayOfWeek[DayOfWeek["Friday"] = 5] = "Friday";
    DayOfWeek[DayOfWeek["Saturday"] = 6] = "Saturday";
})(DayOfWeek || (DayOfWeek = {}));
export class DateOnly {
}
export class TimeOnly {
}
//# sourceMappingURL=DateTime.js.map