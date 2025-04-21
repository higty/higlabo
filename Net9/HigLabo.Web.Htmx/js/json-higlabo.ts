window["htmx"].defineExtension("json-higlabo", {
    onEvent: function (name, evt) {
        if (name === "htmx:configRequest") {
            evt.detail.headers["Content-Type"] = "application/json";
        }
    },
    encodeParameters: function (xhr, parameters, element: Element) {
        xhr.overrideMimeType("text/json");

        const ee = new Array<Element>();
        let hxInclude = element.getAttribute("hx-include");

        if (hxInclude == null) {
            hxInclude = "this";
        }
        const ss = hxInclude.split(",");
        for (var i = 0; i < ss.length; i++) {
            let selector = ss[i];
            if (selector.startsWith("closest ")) {
                selector = selector.substring(8);
                ee.push(element.closest(selector));
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

        let p: any = {};
        for (var eIndex = 0; eIndex < ee.length; eIndex++) {
            const el = ee[eIndex]
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
        return JSON.stringify(p);
    },
    processParameter: function (parameter, node: Node) {
        node.childNodes.forEach((childNode) => {
            if (childNode.nodeType == Node.ELEMENT_NODE) {
                const childElement = <HTMLElement>childNode;
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
                                let inputElement = childElement as HTMLInputElement;
                                if (childElement.getAttribute("type").toLowerCase() == "checkbox") {
                                    if (inputElement.checked == true) {
                                        //Push value to array
                                        parameter.push(inputElement.value);
                                    }
                                }
                                else if (childElement.getAttribute("type").toLowerCase() == "radio") {
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
                            if (childElement.tagName == "INPUT" || childElement.tagName == "TEXTAREA") {
                                let inputElement = childElement as HTMLInputElement;
                                //Push object to array
                                if (childElement.getAttribute("type").toLowerCase() == "checkbox") {
                                    parameter.push({
                                        name: name,
                                        value: inputElement.value,
                                        checked: inputElement.checked
                                    });
                                }
                                else if (childElement.getAttribute("type").toLowerCase() == "radio") {
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
                            else {
                                let r = {};
                                if (childElement.getAttribute("contenteditable") == "true") {
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
                            if (childElement.tagName.toLowerCase() == "input" || childElement.tagName.toLowerCase() == "textarea") {
                                let inputElement = childElement as HTMLInputElement;
                                if (childElement.getAttribute("type").toLowerCase() == "checkbox") {
                                    parameter[name] = inputElement.checked;
                                }
                                else if (childElement.getAttribute("type").toLowerCase() == "radio") {
                                    if (inputElement.checked == true) {
                                        parameter[name] = inputElement.value;
                                    }
                                }
                                else {
                                    parameter[name] = inputElement.value;
                                }
                            }
                            else {
                                if (childElement.getAttribute("contenteditable") == "true") {
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
    },
    processArrayParameter: function (arrayParameter: Array<any>, node: Node) {
        node.childNodes.forEach((childNode) => {
            if (childNode.nodeType == Node.ELEMENT_NODE) {
                const childElement = <HTMLElement>childNode;
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
                        if (childElement.tagName == "INPUT") {
                            let inputElement = childElement as HTMLInputElement;
                            if (childElement.getAttribute("type").toLowerCase() == "checkbox") {
                                if (inputElement.checked == true) {
                                    arrayParameter.push({ name: inputElement.value });
                                }
                            }
                            else if (childElement.getAttribute("type").toLowerCase() == "radio") {
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
});