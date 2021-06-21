import { List } from "../JavaScript/lib/linq/Linq.js";
import { DateTime } from "./DateTime.js";
import { $ } from "./HtmlElementQuery.js";
var HigLaboVue = (function () {
    function HigLaboVue() {
    }
    HigLaboVue.createApp = function (templateID, data) {
        var template = document.getElementById(templateID);
        if (template == null) {
            throw new Error("Template not found. id is " + template);
        }
        var app = window["Vue"].createApp({
            data: function () { return data; },
            template: template.innerHTML,
            methods: HigLaboVue.formatMethods
        });
        return app;
    };
    HigLaboVue.render = function (element, templateID, data) {
        $(element).setInnerHtml("");
        return this.create(element, null, templateID, data);
    };
    HigLaboVue.append = function (element, templateID, data) {
        return this.create(element, null, templateID, data);
    };
    HigLaboVue.insertBefore = function (targetElement, templateID, data) {
        return this.create(targetElement.parentElement, targetElement, templateID, data);
    };
    HigLaboVue.create = function (element, targetElement, templateID, data) {
        if (element == null) {
            throw new Error("element must not be null.");
        }
        var span = document.createElement("span");
        element.appendChild(span);
        var app = HigLaboVue.createApp(templateID, data);
        app.mount(span);
        var elementList = $(element).find("[data-v-app]").getElementList();
        var createdElementList = new List();
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
    };
    HigLaboVue.appendChild = function (element, data) {
        var templateList = $(element).find("[template-name]").getElementList();
        for (var i = 0; i < templateList.length; i++) {
            var pl = $(templateList[i]);
            var templateID = pl.getAttribute("template-name");
            if (templateID == "") {
                continue;
            }
            var name = pl.getAttribute("property-name");
            var r = data[name];
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
    };
    HigLaboVue.encodeURI = function (value) {
        if (value == null) {
            return "";
        }
        return encodeURI(value);
    };
    HigLaboVue.encodeURIComponent = function (value) {
        if (value == null) {
            return "";
        }
        return encodeURIComponent(value);
    };
    HigLaboVue.decodeURI = function (value) {
        if (value == null) {
            return "";
        }
        return decodeURI(value);
    };
    HigLaboVue.decodeURIComponent = function (value) {
        if (value == null) {
            return "";
        }
        return decodeURIComponent(value);
    };
    HigLaboVue.dateFormat = function (value, format) {
        if (value == null) {
            return "";
        }
        return new DateTime(new Date(value)).toString(format);
    };
    HigLaboVue.yyyyMMddHHmmssfff = function (value) {
        if (value == null) {
            return "";
        }
        return new DateTime(new Date(value)).toString("yyyy/MM/dd hh:mm:ss.fff");
    };
    HigLaboVue.yyyyMMddHHmmss = function (value) {
        if (value == null) {
            return "";
        }
        return new DateTime(new Date(value)).toString("yyyy/MM/dd hh:mm:ss");
    };
    HigLaboVue.yyyyMMddHHmm = function (value) {
        if (value == null) {
            return "";
        }
        return new DateTime(new Date(value)).toString("yyyy/MM/dd hh:mm");
    };
    HigLaboVue.yyyyMMdd = function (value) {
        if (value == null) {
            return "";
        }
        return new DateTime(new Date(value)).toString("yyyy/MM/dd");
    };
    HigLaboVue.MMdd = function (value) {
        if (value == null) {
            return "";
        }
        return new DateTime(new Date(value)).toString("MM/dd");
    };
    HigLaboVue.MMddHHmm = function (value) {
        if (value == null) {
            return "";
        }
        return new DateTime(new Date(value)).toString("MM/dd hh:mm");
    };
    HigLaboVue.HHmmss = function (value) {
        if (value == null) {
            return "";
        }
        return new DateTime(new Date(value)).toString("hh:mm:ss");
    };
    HigLaboVue.HHmm = function (value) {
        if (value == null) {
            return "";
        }
        return new DateTime(new Date(value)).toString("hh:mm");
    };
    HigLaboVue.formatMethods = {
        yyyyMMddHHmmssfff: HigLaboVue.yyyyMMddHHmmssfff,
        yyyyMMddHHmmss: HigLaboVue.yyyyMMddHHmmss,
        yyyyMMddHHmm: HigLaboVue.yyyyMMddHHmm,
        yyyyMMdd: HigLaboVue.yyyyMMdd,
        MMddHHmm: HigLaboVue.MMddHHmm,
        MMdd: HigLaboVue.MMdd,
        HHmmss: HigLaboVue.HHmmss,
        HHmm: HigLaboVue.HHmm,
        dateFormat: HigLaboVue.dateFormat,
        encodeURI: HigLaboVue.encodeURI,
        encodeURIComponent: HigLaboVue.encodeURIComponent,
        decodeURI: HigLaboVue.decodeURI,
        decodeURIComponent: HigLaboVue.decodeURIComponent,
    };
    return HigLaboVue;
}());
export { HigLaboVue };
//# sourceMappingURL=HigLaboVue.js.map