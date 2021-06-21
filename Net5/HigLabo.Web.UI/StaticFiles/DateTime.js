var DateTime = (function () {
    function DateTime(value, timeZoneHour) {
        this.i18n = {
            dayNames: [
                "Sun", "Mon", "Tue", "Wed", "Thu", "Fri", "Sat",
                "Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday"
            ],
            monthNames: [
                "Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec",
                "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"
            ]
        };
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
    }
    Object.defineProperty(DateTime.prototype, "value", {
        get: function () {
            return this.rawValue;
        },
        enumerable: false,
        configurable: true
    });
    Object.defineProperty(DateTime.prototype, "ticks", {
        get: function () {
            return this.rawValue.valueOf();
        },
        enumerable: false,
        configurable: true
    });
    Object.defineProperty(DateTime.prototype, "milliSecond", {
        get: function () {
            return this.rawValue.getMilliseconds();
        },
        enumerable: false,
        configurable: true
    });
    Object.defineProperty(DateTime.prototype, "second", {
        get: function () {
            return this.rawValue.getSeconds();
        },
        enumerable: false,
        configurable: true
    });
    Object.defineProperty(DateTime.prototype, "minute", {
        get: function () {
            return this.rawValue.getMinutes();
        },
        enumerable: false,
        configurable: true
    });
    Object.defineProperty(DateTime.prototype, "hours", {
        get: function () {
            return this.rawValue.getHours();
        },
        enumerable: false,
        configurable: true
    });
    Object.defineProperty(DateTime.prototype, "day", {
        get: function () {
            return this.rawValue.getDate();
        },
        enumerable: false,
        configurable: true
    });
    Object.defineProperty(DateTime.prototype, "month", {
        get: function () {
            return this.rawValue.getMonth() + 1;
        },
        enumerable: false,
        configurable: true
    });
    Object.defineProperty(DateTime.prototype, "year", {
        get: function () {
            return this.rawValue.getFullYear();
        },
        enumerable: false,
        configurable: true
    });
    Object.defineProperty(DateTime.prototype, "dayOfWeek", {
        get: function () {
            var dw = this.rawValue.getDay();
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
        },
        enumerable: false,
        configurable: true
    });
    DateTime.prototype.addMilliSecond = function (value) {
        var v = this.rawValue.valueOf() + value;
        return new DateTime(new Date(v));
    };
    DateTime.prototype.addSecond = function (value) {
        var v = this.rawValue.valueOf() + value * 1000;
        return new DateTime(new Date(v));
    };
    DateTime.prototype.addMinute = function (value) {
        var v = this.rawValue.valueOf() + value * 60 * 1000;
        return new DateTime(new Date(v));
    };
    DateTime.prototype.addHour = function (value) {
        var v = this.rawValue.valueOf() + value * 3600 * 1000;
        return new DateTime(new Date(v));
    };
    DateTime.prototype.addDay = function (value) {
        var v = this.rawValue.valueOf() + value * 24 * 3600 * 1000;
        return new DateTime(new Date(v));
    };
    DateTime.prototype.addMonth = function (value) {
        var newMonth = (this.month + value);
        if (newMonth > 12) {
            var dayOfMonth = this.dayOfMonth(this.year + (newMonth / 12), newMonth % 12);
            if (this.day > dayOfMonth) {
                return new DateTime(new Date(this.year + (newMonth / 12), newMonth % 12 - 1, dayOfMonth));
            }
            else {
                return new DateTime(new Date(this.year + (newMonth / 12), newMonth % 12 - 1, this.day));
            }
        }
        else {
            var dayOfMonth = this.dayOfMonth(this.year, newMonth);
            if (this.day > dayOfMonth) {
                return new DateTime(new Date(this.year, newMonth - 1, dayOfMonth));
            }
            else {
                return new DateTime(new Date(this.year, newMonth - 1, this.day));
            }
        }
    };
    DateTime.prototype.addYear = function (value) {
        var dayOfMonth = this.dayOfMonth(this.year + value, this.month);
        if (this.day > dayOfMonth) {
            return new DateTime(new Date(this.year + value, this.month, dayOfMonth));
        }
        else {
            return new DateTime(new Date(this.year + value, this.month, this.day));
        }
    };
    DateTime.prototype.add = function (value) {
        var v = this.rawValue.valueOf() + value.totalMilliSeconds;
        return new DateTime(new Date(v));
    };
    DateTime.prototype.getDayOfWeekName = function () {
        var dw = this.rawValue.getDay();
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
    };
    DateTime.getToday = function () {
        var d = new DateTime(new Date());
        return new DateTime(new Date(d.year, d.month - 1, d.day));
    };
    DateTime.prototype.isToday = function () {
        var d = new DateTime(new Date());
        var today = new DateTime(new Date(d.year, d.month - 1, d.day));
        return this.year == today.year && this.month == today.month && this.day == today.day;
    };
    DateTime.prototype.timeOfDay = function () {
        var s = (24 * 3600 * this.day + 3600 * this.hours + 60 * this.minute + this.second);
        return new TimeSpan(s * 1000 + this.milliSecond);
    };
    DateTime.prototype.isEqual = function (value) {
        return this.rawValue.getTime() === value.rawValue.getTime();
    };
    DateTime.prototype.isDateEqual = function (value) {
        return this.year == value.year && this.month == value.month && this.day == value.day;
    };
    DateTime.prototype.isTimeEqual = function (value) {
        return this.hours == value.hours && this.minute == value.minute && this.second == value.second && this.milliSecond == value.milliSecond;
    };
    DateTime.prototype.dayOfMonth = function (year, month) {
        if (month == 12) {
            var d = new DateTime(new Date(year + 1, 1, 1));
            d.addDay(-1);
            return d.day;
        }
        else {
            var d = new DateTime(new Date(year, month, 1));
            d.addDay(-1);
            return d.day;
        }
    };
    DateTime.prototype.toString = function (dateFormat) {
        if (this.rawValue.toString() == "Invalid Date") {
            return "";
        }
        var z = {
            M: this.month,
            d: this.day,
            h: this.hours,
            m: this.minute,
            s: this.second,
            f: this.milliSecond
        };
        var v = dateFormat.replace(/(M+|d+|h+|m+|s+|f+)/g, function (v) {
            return ((v.length > 1 ? "0" : "") + z[v.slice(-1)]).slice(-2);
        });
        var fullYear = this.year.toString();
        var dateTimeText = v.replace(/(y+)/g, function (v) {
            return fullYear.slice(-v.length);
        });
        return dateTimeText;
    };
    return DateTime;
}());
export { DateTime };
var TimeSpan = (function () {
    function TimeSpan(milliseconds) {
        this._TotalMilliSeconds = milliseconds;
    }
    Object.defineProperty(TimeSpan.prototype, "totalMilliSeconds", {
        get: function () {
            return this._TotalMilliSeconds;
        },
        enumerable: false,
        configurable: true
    });
    Object.defineProperty(TimeSpan.prototype, "milliSeconds", {
        get: function () {
            return this._TotalMilliSeconds % 1000;
        },
        enumerable: false,
        configurable: true
    });
    Object.defineProperty(TimeSpan.prototype, "seconds", {
        get: function () {
            return Math.floor(this._TotalMilliSeconds / 1000) % 60;
        },
        enumerable: false,
        configurable: true
    });
    Object.defineProperty(TimeSpan.prototype, "minutes", {
        get: function () {
            return Math.floor(this._TotalMilliSeconds / (60 * 1000)) % 60;
        },
        enumerable: false,
        configurable: true
    });
    Object.defineProperty(TimeSpan.prototype, "hours", {
        get: function () {
            return Math.floor(this._TotalMilliSeconds / (60 * 60 * 1000)) % 24;
        },
        enumerable: false,
        configurable: true
    });
    Object.defineProperty(TimeSpan.prototype, "days", {
        get: function () {
            return Math.floor(this._TotalMilliSeconds / (24 * 3600 * 1000));
        },
        enumerable: false,
        configurable: true
    });
    TimeSpan.substract = function (value1, value2) {
        return new TimeSpan(value1.ticks - value2.ticks);
    };
    return TimeSpan;
}());
export { TimeSpan };
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
//# sourceMappingURL=DateTime.js.map