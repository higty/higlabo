(function (global, factory) {
    typeof exports === 'object' && typeof module !== 'undefined' ? factory(exports) :
        typeof define === 'function' && define.amd ? define(['exports'], factory) :
            (global = typeof globalThis !== 'undefined' ? globalThis : global || self, factory(global.ja = {}));
}(this, (function (exports) {
    'use strict';

    var fp = typeof window !== "undefined" && window.flatpickr !== undefined
        ? window.flatpickr
        : {
            l10ns: {},
        };
    var Japanese = {
        weekdays: {
            shorthand: ["“ú", "Œ", "‰Î", "…", "–Ø", "‹à", "“y"],
            longhand: [
                "“ú—j“ú",
                "Œ—j“ú",
                "‰Î—j“ú",
                "…—j“ú",
                "–Ø—j“ú",
                "‹à—j“ú",
                "“y—j“ú",
            ],
        },
        months: {
            shorthand: [
                "1Œ",
                "2Œ",
                "3Œ",
                "4Œ",
                "5Œ",
                "6Œ",
                "7Œ",
                "8Œ",
                "9Œ",
                "10Œ",
                "11Œ",
                "12Œ",
            ],
            longhand: [
                "1Œ",
                "2Œ",
                "3Œ",
                "4Œ",
                "5Œ",
                "6Œ",
                "7Œ",
                "8Œ",
                "9Œ",
                "10Œ",
                "11Œ",
                "12Œ",
            ],
        },
        time_24hr: true,
        rangeSeparator: " ‚©‚ç ",
        monthAriaLabel: "Œ",
        amPM: ["Œß‘O", "ŒßŒã"],
        yearAriaLabel: "”N",
        hourAriaLabel: "ŠÔ",
        minuteAriaLabel: "•ª",
    };
    fp.l10ns.ja = Japanese;
    var ja = fp.l10ns;

    exports.Japanese = Japanese;
    exports.default = ja;

    Object.defineProperty(exports, '__esModule', { value: true });

})));