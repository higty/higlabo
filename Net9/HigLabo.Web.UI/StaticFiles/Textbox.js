import { $ } from "./HtmlElementQuery.js";
export class Textbox {
    formatters = {
        time: (raw) => this.toHHmm(raw),
        date: (raw) => this.toYYYYMMDD(raw),
        number: (raw) => this.toNumber(raw),
    };
    initialize() {
        $("body").on("focusin", "textarea[auto-height-resize]", this.textarea_Focusin.bind(this));
        $("body").on("input", "textarea[auto-height-resize]", this.textarea_Input.bind(this));
        $("body").on("focusin", "[auto-format]", this.autoFormat_Focusin.bind(this));
        $("body").on("focusout", "[auto-format]", this.autoFormat_Focusout.bind(this));
    }
    textarea_Focusin(target, e) {
        this.setTextareaHeight(target);
    }
    textarea_Input(target, e) {
        this.setTextareaHeight(target);
    }
    autoFormat_Focusin(target, e) {
        $(target).select();
    }
    autoFormat_Focusout(target, e) {
        const kind = ($(target).getAttribute("auto-format") || "").trim().toLowerCase();
        if (!kind)
            return;
        const formatter = this.formatters[kind];
        if (!formatter)
            return;
        const raw = $(target).getValue().trim();
        if (raw === "")
            return;
        const formatted = formatter(raw, target);
        if (formatted !== null) {
            $(target).setValue(formatted);
        }
    }
    toHHmm(input) {
        const digits = input.replace(/\D/g, "");
        if (digits.length === 0)
            return "";
        let h, m;
        if (digits.length === 2) {
            h = parseInt(digits, 10);
            m = 0;
        }
        else if (digits.length === 3) {
            h = parseInt(digits.slice(0, 1), 10);
            m = parseInt(digits.slice(1), 10);
        }
        else if (digits.length === 4) {
            h = parseInt(digits.slice(0, 2), 10);
            m = parseInt(digits.slice(2), 10);
        }
        else {
            return null;
        }
        if (Number.isNaN(h) || Number.isNaN(m))
            return null;
        if (h < 0)
            h = 0;
        if (h > 23)
            h = 23;
        if (m < 0)
            m = 0;
        if (m > 59)
            m = 59;
        const hh = ("0" + h).slice(-2);
        const mm = ("0" + m).slice(-2);
        return `${hh}:${mm}`;
    }
    toYYYYMMDD(input) {
        const digits = input.replace(/\D/g, "");
        let y, m, d;
        if (digits.length === 8) {
            y = parseInt(digits.slice(0, 4), 10);
            m = parseInt(digits.slice(4, 6), 10);
            d = parseInt(digits.slice(6, 8), 10);
        }
        else if (digits.length === 6) {
            y = 2000 + parseInt(digits.slice(0, 2), 10);
            m = parseInt(digits.slice(2, 4), 10);
            d = parseInt(digits.slice(4, 6), 10);
        }
        else {
            const tryDate = new Date(input);
            if (Number.isNaN(tryDate.getTime()))
                return null;
            y = tryDate.getFullYear();
            m = tryDate.getMonth() + 1;
            d = tryDate.getDate();
        }
        if ([y, m, d].some(v => Number.isNaN(v)))
            return null;
        if (m < 1)
            m = 1;
        if (m > 12)
            m = 12;
        const maxD = new Date(y, m, 0).getDate();
        if (d < 1)
            d = 1;
        if (d > maxD)
            d = maxD;
        const yyyy = y.toString().padStart(4, "0");
        const mm = m.toString().padStart(2, "0");
        const dd = d.toString().padStart(2, "0");
        return `${yyyy}-${mm}-${dd}`;
    }
    toNumber(input) {
        const cleaned = input
            .trim()
            .replace(/[^\d\.\-+]/g, "")
            .replace(/(?!^)[+\-]/g, "")
            .replace(/^([+\-]?\d*)\.(.*)\.(.*)$/, "$1.$2$3");
        if (cleaned === "" || cleaned === "-" || cleaned === "+")
            return null;
        const n = Number(cleaned);
        if (!Number.isFinite(n))
            return null;
        const decPart = (cleaned.split(".")[1] ?? "");
        const decLen = Math.min(decPart.length, 20);
        return n.toLocaleString(undefined, {
            minimumFractionDigits: decLen,
            maximumFractionDigits: decLen
        });
    }
    setAllTextareaHeight() {
        $("textarea[auto-height-resize]").forEach(element => {
            this.setTextareaHeight(element);
        });
    }
    setTextareaHeight(textbox) {
        const tx = textbox;
        $(tx).setStyle("height", "0");
        $(tx).setStyle("height", tx.scrollHeight + "px");
        if ($(tx).getOuterHeight() >= tx.scrollHeight) {
            $(tx).setStyle("overflow-y", "hidden");
        }
        else {
            $(tx).removeStyle("overflow-y");
        }
    }
}
//# sourceMappingURL=Textbox.js.map