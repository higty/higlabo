import { $ } from "./HtmlElementQuery.js";
export class HigLaboJson {
    static HxTargetOuter = "outer ";
    static OriginalHxTargetAttribute = "hx-target-outer";
    static OriginalDataHxTargetAttribute = "data-hx-target-outer";
    static HxTargetKeyAttribute = "hx-target-outer-key";
    static HxRequestSelector = "[hx-get], [data-hx-get], [hx-post], [data-hx-post], [hx-put], [data-hx-put], [hx-delete], [data-hx-delete], [hx-patch], [data-hx-patch]";
    static _initialized = false;
    _hxTargetIndex = 0;
    initialize() {
        if (HigLaboJson._initialized == true) {
            return;
        }
        HigLaboJson._initialized = true;
        const j = this;
        window["htmx"].defineExtension("higlabo-json", {
            onEvent: function (name, evt) {
                if (name === "htmx:beforeProcessNode") {
                    j.processHxTargetNode(evt.detail.elt);
                }
                if (name === "htmx:configRequest") {
                    evt.detail.headers["Content-Type"] = "application/json";
                }
            },
            encodeParameters: function (xhr, parameters, element) {
                xhr.overrideMimeType("text/json");
                const p = j.Parse(element, element.getAttribute("hx-include"));
                return JSON.stringify(p);
            },
        });
    }
    processHxTargetNode(element) {
        if (element == null) {
            return;
        }
        if (element.matches(HigLaboJson.HxRequestSelector) == false) {
            return;
        }
        const hxTargetElement = this.hasOuterHxTarget(element) == true ? element :
            $(element)
                .findAncestors("[hx-target-outer], [data-hx-target-outer], [hx-target], [data-hx-target]")
                .getElements()
                .find((e) => this.hasOuterHxTarget(e) == true);
        if (hxTargetElement == null) {
            return;
        }
        const hxTarget = hxTargetElement.getAttribute(HigLaboJson.OriginalHxTargetAttribute) ??
            hxTargetElement.getAttribute(HigLaboJson.OriginalDataHxTargetAttribute) ??
            hxTargetElement.getAttribute("hx-target") ??
            hxTargetElement.getAttribute("data-hx-target");
        if (hxTarget == null || hxTarget.trim().startsWith(HigLaboJson.HxTargetOuter) == false) {
            return;
        }
        const selector = hxTarget.trim().substring(HigLaboJson.HxTargetOuter.length);
        const target = $(element).findOuterFirst(selector).getFirstElement();
        if (target == null) {
            return;
        }
        if (element.hasAttribute(HigLaboJson.OriginalHxTargetAttribute) == false &&
            element.hasAttribute(HigLaboJson.OriginalDataHxTargetAttribute) == false) {
            if (element.hasAttribute("data-hx-target") == true) {
                element.setAttribute(HigLaboJson.OriginalDataHxTargetAttribute, hxTarget);
            }
            else {
                element.setAttribute(HigLaboJson.OriginalHxTargetAttribute, hxTarget);
            }
        }
        const key = this.getHxTargetKey(target);
        element.setAttribute("hx-target", `[${HigLaboJson.HxTargetKeyAttribute}='${key}']`);
    }
    hasOuterHxTarget(element) {
        const hxTarget = element.getAttribute(HigLaboJson.OriginalHxTargetAttribute) ??
            element.getAttribute(HigLaboJson.OriginalDataHxTargetAttribute) ??
            element.getAttribute("hx-target") ??
            element.getAttribute("data-hx-target");
        return hxTarget != null && hxTarget.trim().startsWith(HigLaboJson.HxTargetOuter) == true;
    }
    getHxTargetKey(element) {
        let key = element.getAttribute(HigLaboJson.HxTargetKeyAttribute);
        if (key == null) {
            this._hxTargetIndex++;
            key = this._hxTargetIndex.toString();
            element.setAttribute(HigLaboJson.HxTargetKeyAttribute, key);
        }
        return key;
    }
    Parse(element, selector) {
        const ee = new Array();
        if (selector == null) {
            selector = "this";
        }
        const ss = selector.split(",");
        for (var i = 0; i < ss.length; i++) {
            let selector = ss[i].trim();
            if (selector.startsWith("closest ")) {
                selector = selector.substring(8);
                ee.push(element.closest(selector));
            }
            else if (selector.startsWith("outerFirst ")) {
                selector = selector.substring(11);
                ee.push($(element).findOuterFirst(selector).getFirstElement());
            }
            else if (selector.startsWith("outer ")) {
                selector = selector.substring(6);
                $(element).findOuter(selector).getElements().forEach((e) => {
                    ee.push(e);
                });
            }
            else if (selector.startsWith("sibling ")) {
                selector = selector.substring(8);
                $(element).findSiblings(selector).getElements().forEach((e) => {
                    ee.push(e);
                });
            }
            else if (selector.startsWith("find ")) {
                selector = selector.substring(5);
                $(element).find(selector).getElements().forEach((e) => {
                    ee.push(e);
                });
            }
            else if (selector.startsWith("children ")) {
                selector = selector.substring(9);
                $(element).findChildren(selector).getElements().forEach((e) => {
                    ee.push(e);
                });
            }
            else if (selector == "this") {
                ee.push(element);
            }
            else {
                document.querySelectorAll(selector).forEach((e) => {
                    ee.push(e);
                });
            }
        }
        let p = {};
        if (element.getAttribute("hx-include-object") != null) {
            try {
                p = JSON.parse(element.getAttribute("hx-include-object"));
            }
            catch { }
        }
        if (p == null) {
            p = {};
        }
        for (var eIndex = 0; eIndex < ee.length; eIndex++) {
            const el = ee[eIndex];
            if (el == null) {
                continue;
            }
            const name = el.getAttribute("name");
            if (name != "" && el.getAttribute("hig-property-type") == "Array") {
                let rr = [];
                p[name] = rr;
                this.processArrayParameter(rr, ee[eIndex]);
            }
            else {
                this.processParameter(p, ee[eIndex]);
            }
        }
        return p;
    }
    processParameter(parameter, node) {
        node.childNodes.forEach((childNode) => {
            if (childNode.nodeType == Node.ELEMENT_NODE) {
                const childElement = childNode;
                if (childElement.getAttribute("hig-property-type") == "Ignore") {
                    return;
                }
                const name = childElement.getAttribute("name");
                if (parameter instanceof Array) {
                    if (childElement.getAttribute("hig-property-type") == "Object") {
                        let r = {};
                        parameter.push(r);
                        this.processParameter(r, childNode);
                        return;
                    }
                    else if (childElement.getAttribute("hig-property-type") == "Array") {
                        let rr = [];
                        parameter.push(rr);
                        this.processArrayParameter(rr, childNode);
                        return;
                    }
                    else {
                        if (name == null) {
                            if (childElement.tagName == "INPUT") {
                                let inputElement = childElement;
                                if (childElement.getAttribute("type") == "checkbox") {
                                    if (inputElement.checked == true) {
                                        parameter.push(inputElement.value);
                                    }
                                }
                                else if (childElement.getAttribute("type") == "radio") {
                                    if (inputElement.checked == true) {
                                        parameter.push(inputElement.value);
                                    }
                                }
                                else {
                                    parameter.push(inputElement.value);
                                }
                            }
                        }
                        else {
                            if (childElement.tagName.toLowerCase() == "select") {
                                let selectElement = childElement;
                                if (selectElement.selectedIndex > -1) {
                                    let r = {};
                                    r[name] = selectElement.options[selectElement.selectedIndex].value;
                                    parameter.push(r);
                                }
                            }
                            if (childElement.tagName == "INPUT" || childElement.tagName == "TEXTAREA") {
                                let inputElement = childElement;
                                if (childElement.getAttribute("type") == "checkbox") {
                                    parameter.push({
                                        name: name,
                                        value: inputElement.value,
                                        checked: inputElement.checked
                                    });
                                }
                                else if (childElement.getAttribute("type") == "radio") {
                                    if (inputElement.checked == true) {
                                        let r = {};
                                        r[name] = inputElement.value;
                                        parameter.push(r);
                                    }
                                }
                                else {
                                    let r = {};
                                    r[name] = inputElement.value;
                                    parameter.push(r);
                                }
                            }
                            else if (childElement.tagName.toLowerCase() == "img") {
                                let r = {};
                                r[name] = childElement.getAttribute("src");
                                parameter.push(r);
                            }
                            else {
                                let r = {};
                                if (childElement.hasAttribute("item-group") == true) {
                                    if (childElement.getAttribute("current") == "true") {
                                        parameter[name] = childElement.getAttribute("value");
                                    }
                                }
                                else if (childElement.getAttribute("contenteditable") == "true") {
                                    r[name] = childElement.innerHTML;
                                }
                                else {
                                    r[name] = childElement.innerText;
                                }
                                parameter.push(r);
                            }
                        }
                    }
                }
                else {
                    if (name != null) {
                        if (childElement.getAttribute("hig-property-type") == "Object") {
                            let r = {};
                            parameter[name] = r;
                            this.processParameter(r, childNode);
                            return;
                        }
                        else if (childElement.getAttribute("hig-property-type") == "Array") {
                            let rr = [];
                            parameter[name] = rr;
                            this.processArrayParameter(rr, childNode);
                            return;
                        }
                        else {
                            if (childElement.tagName.toLowerCase() == "select") {
                                let selectElement = childElement;
                                if (selectElement.selectedIndex > -1) {
                                    parameter[name] = selectElement.options[selectElement.selectedIndex].value;
                                }
                            }
                            else if (childElement.tagName.toLowerCase() == "input" || childElement.tagName.toLowerCase() == "textarea") {
                                let inputElement = childElement;
                                if (childElement.getAttribute("type") == "checkbox") {
                                    parameter[name] = inputElement.checked;
                                }
                                else if (childElement.getAttribute("type") == "radio") {
                                    if (inputElement.checked == true) {
                                        parameter[name] = inputElement.value;
                                    }
                                }
                                else {
                                    parameter[name] = inputElement.value;
                                }
                            }
                            else if (childElement.tagName.toLowerCase() == "img") {
                                parameter[name] = childElement.getAttribute("src");
                            }
                            else {
                                if (childElement.hasAttribute("item-group") == true) {
                                    if (childElement.getAttribute("current") == "true") {
                                        parameter[name] = childElement.getAttribute("value");
                                    }
                                }
                                else if (childElement.getAttribute("contenteditable") == "true") {
                                    parameter[name] = childElement.innerHTML;
                                }
                                else {
                                    parameter[name] = childElement.innerText;
                                }
                            }
                        }
                    }
                }
                this.processParameter(parameter, childNode);
            }
        });
    }
    processArrayParameter(arrayParameter, node) {
        node.childNodes.forEach((childNode) => {
            if (childNode.nodeType == Node.ELEMENT_NODE) {
                const childElement = childNode;
                if (childElement.getAttribute("hig-property-type") == "Ignore") {
                    return;
                }
                const name = childElement.getAttribute("name");
                if (name != null) {
                    if (childElement.getAttribute("hig-property-type") == "Object") {
                        let r = {};
                        arrayParameter.push(r);
                        this.processParameter(r, childNode);
                    }
                    else if (childElement.getAttribute("hig-property-type") == "Array") {
                        let rr = [];
                        arrayParameter.push(rr);
                        this.processArrayParameter(rr, childNode);
                    }
                    else {
                        if (childElement.tagName.toLowerCase() == "select") {
                            let selectElement = childElement;
                            if (selectElement.selectedIndex > -1) {
                                arrayParameter.push({ name: selectElement.options[selectElement.selectedIndex].value });
                            }
                        }
                        else if (childElement.tagName == "INPUT") {
                            let inputElement = childElement;
                            if (childElement.getAttribute("type") == "checkbox") {
                                if (inputElement.checked == true) {
                                    arrayParameter.push({ name: inputElement.value });
                                }
                            }
                            else if (childElement.getAttribute("type") == "radio") {
                                if (inputElement.checked == true) {
                                    arrayParameter.push({ name: inputElement.value });
                                }
                            }
                            else {
                                arrayParameter.push({ name: inputElement.value });
                            }
                        }
                        else {
                            arrayParameter.push({ name: childElement.innerText });
                        }
                        this.processParameter(arrayParameter, childNode);
                    }
                }
                else {
                    if (childElement.getAttribute("hig-property-type") == "Object") {
                        let r = {};
                        arrayParameter.push(r);
                        this.processParameter(r, childNode);
                    }
                    else if (childElement.getAttribute("hig-property-type") == "Array") {
                        let rr = [];
                        arrayParameter.push(rr);
                        this.processArrayParameter(rr, childNode);
                    }
                    else {
                        this.processParameter(arrayParameter, childNode);
                    }
                }
            }
        });
    }
}
//# sourceMappingURL=HigLaboJson.js.map