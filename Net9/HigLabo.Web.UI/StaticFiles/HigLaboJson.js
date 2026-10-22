import { $ } from "./HtmlElementQuery.js";
export class HigLaboJson {
    static _initialized = false;
    initialize() {
        if (HigLaboJson._initialized == true) {
            return;
        }
        const htmx = window["htmx"];
        if (typeof htmx?.__findAllExt !== "function") {
            throw new Error("HigLaboJson requires the unminified htmx 4.0.0 source.");
        }
        const j = this;
        let api;
        const registered = htmx.registerExtension("higlabo-json", {
            init: function (internalApi) {
                api = internalApi;
                const determineMethodAndAction = htmx.__determineMethodAndAction;
                htmx.__determineMethodAndAction = function (element, event) {
                    if (!this.__attributeValue(element, "hx-action")) {
                        for (const method of ["get", "post", "put", "patch", "delete", "query"]) {
                            const action = this.__attr(element, "hx-" + method);
                            if (action != null) {
                                return { action: action, method: method.toUpperCase() };
                            }
                        }
                    }
                    return determineMethodAndAction.call(this, element, event);
                };
                htmx.__findAllExt = function (eltOrSelector, maybeSelector, thisAttr, global) {
                    let selector = maybeSelector ?? eltOrSelector;
                    let elt = maybeSelector ? (this.__normalizeElement(eltOrSelector) || document.body) : document;
                    if (selector.startsWith("global ")) {
                        return this.__findAllExt(elt, selector.slice(7), thisAttr, true);
                    }
                    let parts = selector ? api.HCON.split(selector) : [];
                    let result = [];
                    let unprocessedParts = [];
                    for (const part of parts) {
                        let selector = this.__stringHyperscriptStyleSelector(part);
                        let item;
                        if (elt instanceof Element && selector.startsWith("outerFirst ")) {
                            result.push(...$(elt).findOuterFirst(selector.slice(11)).getElements());
                        }
                        else if (elt instanceof Element && selector.startsWith("outer ")) {
                            result.push(...$(elt).findOuter(selector.slice(6)).getElements());
                        }
                        else if (elt instanceof Element && selector.startsWith("sibling ")) {
                            result.push(...$(elt).findSiblings(selector.slice(8)).getElements());
                        }
                        else if (elt instanceof Element && selector.startsWith("find ")) {
                            result.push(...$(elt).findDescendants(selector.slice(5)).getElements());
                        }
                        else if (elt instanceof Element && selector.startsWith("children ")) {
                            result.push(...$(elt).findChildren(selector.slice(9)).getElements());
                        }
                        else if (selector.startsWith("closest ")) {
                            item = elt.closest(selector.slice(8));
                        }
                        else if (selector.startsWith("find ")) {
                            item = elt.querySelector(selector.slice(5));
                        }
                        else if (selector.startsWith("findAll ")) {
                            result.push(...elt.querySelectorAll(selector.slice(8)));
                        }
                        else if (selector === "next" || selector === "nextElementSibling") {
                            item = elt.nextElementSibling;
                        }
                        else if (selector.startsWith("next ")) {
                            item = this.__scanForwardQuery(elt, selector.slice(5), !!global);
                        }
                        else if (selector === "previous" || selector === "previousElementSibling") {
                            item = elt.previousElementSibling;
                        }
                        else if (selector.startsWith("previous ")) {
                            item = this.__scanBackwardsQuery(elt, selector.slice(9), !!global);
                        }
                        else if (selector === "document") {
                            item = document;
                        }
                        else if (selector === "window") {
                            item = window;
                        }
                        else if (selector === "body") {
                            item = document.body;
                        }
                        else if (selector === "host") {
                            item = (elt.getRootNode()).host;
                        }
                        else if (selector === "this") {
                            if (thisAttr) {
                                result.push(...this.__findThisElements(elt, thisAttr));
                                continue;
                            }
                            item = elt;
                        }
                        else {
                            unprocessedParts.push(selector);
                        }
                        if (item) {
                            result.push(item);
                        }
                    }
                    if (unprocessedParts.length > 0) {
                        let standardSelector = unprocessedParts.join(",");
                        let rootNode = this.__getRootNode(elt, !!global);
                        result.push(...rootNode.querySelectorAll(standardSelector));
                    }
                    return [...new Set(result)];
                };
            },
            htmx_before_request: function (element, detail) {
                const request = detail.ctx.request;
                if (request.method === "GET" || request.method === "DELETE" || request.body instanceof FormData) {
                    return;
                }
                const p = j.Parse(element, api.attributeValue(element, "hx-include"));
                request.headers["Content-Type"] = "application/json";
                request.body = JSON.stringify(p);
            },
        });
        if (registered !== false) {
            HigLaboJson._initialized = true;
        }
    }
    Parse(element, selector) {
        const ee = $(element).findAll(selector).getElements();
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