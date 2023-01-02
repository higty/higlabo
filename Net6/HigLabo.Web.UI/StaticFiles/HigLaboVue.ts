import { DateTime } from "./DateTime.js";
import { $ } from "./HtmlElementQuery.js";
import { List } from "./linq/Linq.js";

export class HigLaboVue {
    public static formatMethods = {
        intlFormat: HigLaboVue.intlFormat,
        numberFormat: HigLaboVue.numberFormat,
        currencyFormat: HigLaboVue.currencyFormat,
        dateFormat: HigLaboVue.dateFormat,
        encodeURI: HigLaboVue.encodeURI,
        encodeURIComponent: HigLaboVue.encodeURIComponent,
        decodeURI: HigLaboVue.decodeURI,
        decodeURIComponent: HigLaboVue.decodeURIComponent,
    };
    public static defaultSettings = {
        culture: "ja-JP",
        currency: "JPY",
    }

    private static createApp(templateID: string, data: any) {
        var template = document.getElementById(templateID);
        if (template == null) { throw new Error("Template not found. id is " + templateID); }
        const app = window["Vue"].createApp({
            data() { return data; },
            template: template.innerHTML,
            methods: HigLaboVue.formatMethods
        });
        return app;
    }
    public static create(templateID: string, data: any): Array<Element> {
        const dummyContainer = this.getDummyElement();
        const dummyElement = document.createElement("div");
        dummyContainer.appendChild(dummyElement);

        const app = HigLaboVue.createApp(templateID, data);
        app.mount(dummyElement);

        //Remove [data-v-app] element and replace it.
        const elementList = $(dummyElement.parentElement).find("[data-v-app]").getElementList();
        const createdElementList = new List<Element>();
        for (var i = 0; i < elementList.length; i++) {
            var element = elementList[i];
            while (element.children.length > 0) {
                var actualElement = element.children[0];
                createdElementList.push(actualElement);
                actualElement.remove();
                HigLaboVue.appendChild(actualElement, data);
            }
        }
        dummyElement.remove();
        return createdElementList.toArray();
    }
    private static getDummyElement() {
        const dummyElementID = "HigLaboVueDummyElement";
        let dummyElement = document.getElementById(dummyElementID);
        if (dummyElement == null) {
            const div = document.createElement("div");
            div.id = dummyElementID;
            div.style.display = "none";
            document.body.appendChild(div);
        }
        return document.getElementById(dummyElementID);
    }
    public static render(element: Element, templateID: string, data: any): Array<Element> {
        $(element).setInnerHtml("");
        return this.processElement(element, templateID, data, "append");
    }
    public static append(element: Element, templateID: string, data: any): Array<Element> {
        return this.processElement(element, templateID, data, "append");
    }
    public static insertBefore(targetElement: Element, templateID: string, data: any): Array<Element> {
        return this.processElement(targetElement.parentElement, templateID, data, "before", targetElement);
    }
    public static insertAfter(targetElement: Element, templateID: string, data: any): Array<Element> {
        return this.processElement(targetElement.parentElement, templateID, data, "after", targetElement);
    }
    private static processElement(element: Element, templateID: string, data: any, insertType: "append" | "before" | "after", targetElement?: Element): Array<Element> {
        if (element == null) { throw new Error("element must not be null."); }

        const span = document.createElement("span") as HTMLElement;
        element.appendChild(span);//Dummy element

        const app = HigLaboVue.createApp(templateID, data);
        app.mount(span);

        //Remove Dummy element and replace it.
        const elementList = $(element).find("[data-v-app]").getElementList();
        const createdElementList = new List<Element>();
        for (var i = 0; i < elementList.length; i++) {
            var element = elementList[i];
            while (element.children.length > 0) {
                var actualElement = element.children[0];
                switch (insertType) {
                    case "append": element.parentElement.append(actualElement); break;
                    case "before": element.parentElement.insertBefore(actualElement, targetElement); break;
                    case "after": element.parentElement.insertBefore(actualElement, targetElement.nextSibling); break;
                    default:
                }
                HigLaboVue.appendChild(actualElement, data);
                createdElementList.push(actualElement);
            }
            element.remove();
        }
        return createdElementList.toArray();
    }
    private static appendChild(element: Element, data: any) {
        const templateList = $(element).find("[template-name]").getElementList();
        for (var i = 0; i < templateList.length; i++) {
            var pl = $(templateList[i]);
            var templateID = pl.getAttribute("template-name");
            if (templateID == "") { continue; }

            var name = pl.getAttribute("property-name");

            var r = data[name];
            if (r == null && name == "this") {
                r = data;
            }
            if (r != null) {
                if (r instanceof Array) {
                    for (var rIndex = 0; rIndex < r.length; rIndex++) {
                        HigLaboVue.append(templateList[i], templateID, r[rIndex]);
                    }
                }
                else {
                    HigLaboVue.append(templateList[i], templateID, r);
                }
                pl.removeAttribute("template-name");
            }
        }
    }

    public static intlFormat(value, formatType: "DateTime" | "Number", format: string) {
        switch (formatType) {
            case "DateTime": return Intl.DateTimeFormat(HigLaboVue.defaultSettings.culture, HigLaboVue.getIntlFormatOptions(format)).format(value);
            case "Number": return Intl.NumberFormat(HigLaboVue.defaultSettings.culture, HigLaboVue.getIntlFormatOptions(format)).format(value);
            default:
        }
    }
    public static getIntlFormatOptions(key: string) {
        return {};
    }

    public static numberFormat(value, format: string) {
        if (value == null) { return ""; }
        if (format == null) {
            format = "1.0";
        }
        const rx = /([0-9])[\\.]([0-9])/;
        const m = rx.exec(format);
        if (m == null) {
            return new Intl.NumberFormat(HigLaboVue.defaultSettings.culture, {}).format(value);
        }
        const f = new Intl.NumberFormat(HigLaboVue.defaultSettings.culture, {
            minimumIntegerDigits: parseInt(m[1]),
            maximumFractionDigits: parseInt(m[2])
        });
        return f.format(value);
    }
    public static currencyFormat(value, format: string, currency: string) {
        if (value == null) { return ""; }
        if (format == null) {
            format = "1.0";
        }
        if (currency == null) {
            currency = HigLaboVue.defaultSettings.currency;
        }
        const rx = /([0-9])[\\.]([0-9])/;
        const m = rx.exec(format);
        if (m == null) {
            return new Intl.NumberFormat(HigLaboVue.defaultSettings.culture, { style: "currency", currency: currency }).format(value);
        }
        const f = new Intl.NumberFormat(HigLaboVue.defaultSettings.culture, {
            style: "currency",
            currency: currency,
            minimumIntegerDigits: parseInt(m[1]),
            maximumFractionDigits: parseInt(m[2])
        });
        return f.format(value);
    }
    public static dateFormat(value, format: string) {
        if (value == null) { return ""; }
        return new DateTime(value).toString(format);
    }
    public static encodeURI(value) {
        if (value == null) { return ""; }
        return encodeURI(value);
    }
    public static encodeURIComponent(value) {
        if (value == null) { return ""; }
        return encodeURIComponent(value);
    }
    public static decodeURI(value) {
        if (value == null) { return ""; }
        return decodeURI(value);
    }
    public static decodeURIComponent(value) {
        if (value == null) { return ""; }
        return decodeURIComponent(value);
    }

}

