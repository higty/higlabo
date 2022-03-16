import { List } from "./linq/Linq.js";
import { DateTime } from "./DateTime.js";
import { $ } from "./HtmlElementQuery.js";
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
        return this.processElement(element, null, templateID, data);
    }
    static append(element, templateID, data) {
        return this.processElement(element, null, templateID, data);
    }
    static insertBefore(targetElement, templateID, data) {
        return this.processElement(targetElement.parentElement, targetElement, templateID, data);
    }
    static processElement(element, targetElement, templateID, data) {
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
                if (targetElement == null) {
                    element.parentElement.append(actualElement);
                }
                else {
                    element.parentElement.insertBefore(actualElement, targetElement);
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
    static numberFormat(value, culture) {
        if (value == null) {
            return "";
        }
        if (culture == null) {
            culture = HigLaboVue.defaultSettings.culture;
        }
        const f = new Intl.NumberFormat(culture);
        return f.format(value);
    }
    static currencyFormat(value, culture, currency) {
        if (value == null) {
            return "";
        }
        if (culture == null) {
            culture = HigLaboVue.defaultSettings.culture;
        }
        if (currency == null) {
            currency = HigLaboVue.defaultSettings.currency;
        }
        const f = new Intl.NumberFormat(culture, {
            style: "currency",
            currency: currency
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