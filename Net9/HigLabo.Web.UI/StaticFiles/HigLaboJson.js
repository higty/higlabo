export class HigLaboJson {
    processParameter(parameter, node) {
        node.childNodes.forEach((childNode) => {
            if (childNode.nodeType == Node.ELEMENT_NODE) {
                const childElement = childNode;
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
                                else {
                                    parameter.push(inputElement.value);
                                }
                            }
                        }
                        else {
                            if (childElement.tagName.toLowerCase() == "input" || childElement.tagName.toLowerCase() == "textarea") {
                                let inputElement = childElement;
                                if (childElement.getAttribute("type") == "checkbox") {
                                    parameter.push({
                                        name: name,
                                        value: inputElement.value,
                                        checked: inputElement.checked
                                    });
                                }
                                else {
                                    let r = {};
                                    r[name] = inputElement.value;
                                    parameter.push(r);
                                }
                            }
                            else {
                                let r = {};
                                r[name] = childElement.textContent;
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
                                let inputElement = childElement;
                                if (childElement.getAttribute("type") == "checkbox") {
                                    parameter[name] = inputElement.checked;
                                }
                                else {
                                    parameter[name] = inputElement.value;
                                }
                            }
                            else {
                                parameter[name] = childElement.textContent;
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
                            let inputElement = childElement;
                            if (childElement.getAttribute("type") == "checkbox") {
                                if (inputElement.checked == true) {
                                    arrayParameter.push({ name: inputElement.value });
                                }
                            }
                            else {
                                arrayParameter.push({ name: inputElement.value });
                            }
                        }
                        else {
                            arrayParameter.push({ name: childElement.textContent });
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