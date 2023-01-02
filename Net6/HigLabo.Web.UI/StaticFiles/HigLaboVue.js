import { DateTime } from "./DateTime.js";
import { $ } from "./HtmlElementQuery.js";
import { List } from "./linq/Linq.js";
export class HigLaboVue {
    static createApp(templateID, data) {
        var template = document.getElementById(templateID);
        if (template == null) {
            throw new Error("Template not found. id is " + templateID);
        }
        const app = window["Vue"].createApp({
            data() { return data; },
            template: template.innerHTML,
            methods: HigLaboVue.formatMethods
        });
        return app;
    }
    static create(templateID, data) {
        const dummyContainer = this.getDummyElement();
        const dummyElement = document.createElement("div");
        dummyContainer.appendChild(dummyElement);
        const app = HigLaboVue.createApp(templateID, data);
        app.mount(dummyElement);
        const elementList = $(dummyElement.parentElement).find("[data-v-app]").getElementList();
        const createdElementList = new List();
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
    static getDummyElement() {
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
    static render(element, templateID, data) {
        $(element).setInnerHtml("");
        return this.processElement(element, templateID, data, "append");
    }
    static append(element, templateID, data) {
        return this.processElement(element, templateID, data, "append");
    }
    static insertBefore(targetElement, templateID, data) {
        return this.processElement(targetElement.parentElement, templateID, data, "before", targetElement);
    }
    static insertAfter(targetElement, templateID, data) {
        return this.processElement(targetElement.parentElement, templateID, data, "after", targetElement);
    }
    static processElement(element, templateID, data, insertType, targetElement) {
        if (element == null) {
            throw new Error("element must not be null.");
        }
        const span = document.createElement("span");
        element.appendChild(span);
        const app = HigLaboVue.createApp(templateID, data);
        app.mount(span);
        const elementList = $(element).find("[data-v-app]").getElementList();
        const createdElementList = new List();
        for (var i = 0; i < elementList.length; i++) {
            var element = elementList[i];
            while (element.children.length > 0) {
                var actualElement = element.children[0];
                switch (insertType) {
                    case "append":
                        element.parentElement.append(actualElement);
                        break;
                    case "before":
                        element.parentElement.insertBefore(actualElement, targetElement);
                        break;
                    case "after":
                        element.parentElement.insertBefore(actualElement, targetElement.nextSibling);
                        break;
                    default:
                }
                HigLaboVue.appendChild(actualElement, data);
                createdElementList.push(actualElement);
            }
            element.remove();
        }
        return createdElementList.toArray();
    }
    static appendChild(element, data) {
        const templateList = $(element).find("[template-name]").getElementList();
        for (var i = 0; i < templateList.length; i++) {
            var pl = $(templateList[i]);
            var templateID = pl.getAttribute("template-name");
            if (templateID == "") {
                continue;
            }
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
    static intlFormat(value, formatType, format) {
        switch (formatType) {
            case "DateTime": return Intl.DateTimeFormat(HigLaboVue.defaultSettings.culture, HigLaboVue.getIntlFormatOptions(format)).format(value);
            case "Number": return Intl.NumberFormat(HigLaboVue.defaultSettings.culture, HigLaboVue.getIntlFormatOptions(format)).format(value);
            default:
        }
    }
    static getIntlFormatOptions(key) {
        return {};
    }
    static numberFormat(value, format) {
        if (value == null) {
            return "";
        }
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
    static currencyFormat(value, format, currency) {
        if (value == null) {
            return "";
        }
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
    static dateFormat(value, format) {
        if (value == null) {
            return "";
        }
        return new DateTime(value).toString(format);
    }
    static encodeURI(value) {
        if (value == null) {
            return "";
        }
        return encodeURI(value);
    }
    static encodeURIComponent(value) {
        if (value == null) {
            return "";
        }
        return encodeURIComponent(value);
    }
    static decodeURI(value) {
        if (value == null) {
            return "";
        }
        return decodeURI(value);
    }
    static decodeURIComponent(value) {
        if (value == null) {
            return "";
        }
        return decodeURIComponent(value);
    }
}
HigLaboVue.formatMethods = {
    intlFormat: HigLaboVue.intlFormat,
    numberFormat: HigLaboVue.numberFormat,
    currencyFormat: HigLaboVue.currencyFormat,
    dateFormat: HigLaboVue.dateFormat,
    encodeURI: HigLaboVue.encodeURI,
    encodeURIComponent: HigLaboVue.encodeURIComponent,
    decodeURI: HigLaboVue.decodeURI,
    decodeURIComponent: HigLaboVue.decodeURIComponent,
};
HigLaboVue.defaultSettings = {
    culture: "ja-JP",
    currency: "JPY",
};
//# sourceMappingURL=HigLaboVue.js.map