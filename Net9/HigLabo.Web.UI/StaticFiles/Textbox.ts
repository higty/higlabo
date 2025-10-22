import { $ } from "./HtmlElementQuery.js";

export class Textbox {
    // フォーマッタ登録（auto-format の値と紐付け）
    private formatters: Record<string, (raw: string, el: Element) => string | null> = {
        time: (raw) => this.toHHmm(raw),
        date: (raw) => this.toYYYYMMDD(raw),
        number: (raw) => this.toNumber(raw),
    };

    public initialize() {
        $("body").on("focusin", "textarea[auto-height-resize]", this.textarea_Focusin.bind(this));
        $("body").on("input", "textarea[auto-height-resize]", this.textarea_Input.bind(this));

        // auto-format 対象のフォーカスアウトで整形
        $("body").on("focusin", "[auto-format]", this.autoFormat_Focusin.bind(this));
        $("body").on("focusout", "[auto-format]", this.autoFormat_Focusout.bind(this));
    }

    private textarea_Focusin(target: Element, e: Event) {
        this.setTextareaHeight(target);
    }
    private textarea_Input(target: Element, e: KeyboardEvent) {
        this.setTextareaHeight(target);
    }

    private autoFormat_Focusin(target: Element, e: Event) {
        $(target).select();
    }
    private autoFormat_Focusout(target: Element, e: Event) {
        const kind = ($(target).getAttribute("auto-format") || "").trim().toLowerCase();
        if (!kind) return;

        const formatter = this.formatters[kind];
        if (!formatter) return;

        const raw = $(target).getValue().trim();
        if (raw === "") return;

        const formatted = formatter(raw, target);
        if (formatted !== null) {
            $(target).setValue(formatted);
        }
        // null は「変換不可→未変更」
    }

    // ==== time: 2〜4桁（や区切り混在）→ HH:mm ====
    private toHHmm(input: string): string | null {
        const digits = input.replace(/\D/g, "");
        if (digits.length === 0) return "";

        let h: number, m: number;
        if (digits.length === 2) { h = parseInt(digits, 10); m = 0; }
        else if (digits.length === 3) { h = parseInt(digits.slice(0, 1), 10); m = parseInt(digits.slice(1), 10); }
        else if (digits.length === 4) { h = parseInt(digits.slice(0, 2), 10); m = parseInt(digits.slice(2), 10); }
        else { return null; }

        if (Number.isNaN(h) || Number.isNaN(m)) return null;
        if (h < 0) h = 0; if (h > 23) h = 23;
        if (m < 0) m = 0; if (m > 59) m = 59;

        const hh = ("0" + h).slice(-2);
        const mm = ("0" + m).slice(-2);
        return `${hh}:${mm}`;
    }

    // ==== date: 6桁(yyMMdd)/8桁(yyyyMMdd)/区切り付き → YYYY-MM-DD ====
    private toYYYYMMDD(input: string): string | null {
        const digits = input.replace(/\D/g, "");
        let y: number, m: number, d: number;

        if (digits.length === 8) {
            y = parseInt(digits.slice(0, 4), 10);
            m = parseInt(digits.slice(4, 6), 10);
            d = parseInt(digits.slice(6, 8), 10);
        } else if (digits.length === 6) {
            y = 2000 + parseInt(digits.slice(0, 2), 10); // 2000年代前提
            m = parseInt(digits.slice(2, 4), 10);
            d = parseInt(digits.slice(4, 6), 10);
        } else {
            const tryDate = new Date(input);
            if (Number.isNaN(tryDate.getTime())) return null;
            y = tryDate.getFullYear();
            m = tryDate.getMonth() + 1;
            d = tryDate.getDate();
        }
        if ([y, m, d].some(v => Number.isNaN(v))) return null;

        if (m < 1) m = 1; if (m > 12) m = 12;
        const maxD = new Date(y, m, 0).getDate(); // m は 1-12 を想定
        if (d < 1) d = 1; if (d > maxD) d = maxD;

        const yyyy = y.toString().padStart(4, "0");
        const mm = m.toString().padStart(2, "0");
        const dd = d.toString().padStart(2, "0");
        return `${yyyy}-${mm}-${dd}`;
    }

    // ==== number: 桁区切り。小数桁数は元の桁数を維持 ====
    private toNumber(input: string): string | null {
        const cleaned = input
            .trim()
            .replace(/[^\d\.\-+]/g, "")
            .replace(/(?!^)[+\-]/g, "")
            .replace(/^([+\-]?\d*)\.(.*)\.(.*)$/, "$1.$2$3");
        if (cleaned === "" || cleaned === "-" || cleaned === "+") return null;

        const n = Number(cleaned);
        if (!Number.isFinite(n)) return null;

        const decPart = (cleaned.split(".")[1] ?? "");
        const decLen = Math.min(decPart.length, 20);
        return n.toLocaleString(undefined, {
            minimumFractionDigits: decLen,
            maximumFractionDigits: decLen
        });
    }

    // ==== 既存：テキストエリア自動高さ ====
    public setAllTextareaHeight() {
        $("textarea[auto-resize]").forEach(element => {
            this.setTextareaHeight(element);
        });
    }
    public setTextareaHeight(textbox: Element) {
        const tx = textbox;
        $(tx).setStyle("overflow-y", "hidden");
        $(tx).setStyle("height", "0");
        $(tx).setStyle("height", tx.scrollHeight + "px");
    }
}
