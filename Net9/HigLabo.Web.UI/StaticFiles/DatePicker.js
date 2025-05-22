import { DateOnly, DateTime } from "./DateTime.js";
import { $ } from "./HtmlElementQuery.js";
export class DatePicker {
    initialize() {
        $("body").on("focusin", "input[date-picker],[input-date][date-picker]>input", this.dateTimeTextBox_Focusin.bind(this));
        $("body").on("keydown", "input[date-picker],[input-date][date-picker]>input", this.dateTextBox_Keydown.bind(this));
        $("body").on("click", "[date-picker]", this.dateTextBox_Click.bind(this));
    }
    initializeFlatpickr(language) {
        const flatpickr = window["flatpickr"];
        if (flatpickr == null) {
            return;
        }
        try {
            flatpickr.l10ns.default.firstDayOfWeek = 1;
            if (language == "ja-JP") {
                flatpickr.localize(flatpickr.l10ns.ja);
            }
            flatpickr("[date-picker]", {
                dateFormat: "Y/m/d",
                allowInput: true,
                disableMobile: true,
                onChange: function (selectedDates, dateStr, instance) {
                    const element = $(instance._input).getFirstElement();
                    if (element == null) {
                        return;
                    }
                    if (element.tagName == "INPUT") {
                        return;
                    }
                    if ($(element).getAttribute("input-date") == "true") {
                        $(element).find("input[type='text']").setValue(dateStr);
                    }
                    else {
                        $(element).setInnerText(dateStr);
                    }
                }
            });
            flatpickr("[inline-date-picker]", {
                dateFormat: "Y/m/d",
                allowInput: true,
                disableMobile: true,
                inline: true
            });
        }
        catch { }
    }
    dateTimeTextBox_Focusin(target, e) {
        $(target).select();
    }
    dateTextBox_Keydown(target, e) {
        const ftx = target;
        if (ftx._flatpickr != null) {
            if (e.key == "ArrowDown") {
                ftx._flatpickr.open();
            }
            else {
                ftx._flatpickr.close();
            }
        }
        if (e.key != "Tab") {
            return;
        }
        var tx = $(target);
        var text = tx.getValue();
        var value = parseInt(text);
        if (isNaN(value) == true) {
            return;
        }
        var today = DateTime.getToday();
        var date = new DateOnly();
        if (text.length <= 2) {
            date.Year = today.year;
            date.Month = today.month;
            date.Day = value;
        }
        else if (text.length == 3) {
            date.Year = today.year;
            date.Month = parseInt(text.substring(0, 1));
            date.Day = parseInt(text.substring(1, 3));
        }
        else if (text.length == 4) {
            date.Year = today.year;
            date.Month = parseInt(text.substring(0, 2));
            date.Day = parseInt(text.substring(2, 4));
        }
        else if (text.length == 5) {
            date.Year = parseInt("20" + text.substring(0, 2));
            date.Month = parseInt(text.substring(2, 3));
            date.Day = parseInt(text.substring(3, 5));
        }
        else if (text.length == 6) {
            date.Year = parseInt("20" + text.substring(0, 2));
            date.Month = parseInt(text.substring(2, 4));
            date.Day = parseInt(text.substring(4, 6));
        }
        else if (text.length == 8) {
            date.Year = parseInt(text.substring(0, 4));
            date.Month = parseInt(text.substring(4, 6));
            date.Day = parseInt(text.substring(6, 8));
        }
        else {
            return;
        }
        let dateTime = new DateTime(date);
        if (text.length == 1 || text.length == 2) {
            if (dateTime.value < today.value) {
                dateTime = today.addMonth(1);
            }
        }
        tx.setValue(dateTime.toString("yyyy/MM/dd"));
    }
    dateTextBox_Click(target, e) {
        if (target.tagName == "INPUT") {
            return;
        }
        const ftx = target;
        if (ftx._flatpickr != null) {
            ftx._flatpickr.open();
        }
    }
}
//# sourceMappingURL=DatePicker.js.map