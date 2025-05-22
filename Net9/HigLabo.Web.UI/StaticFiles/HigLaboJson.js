export class HigLaboJson {
    static processParameter(parameter, node) {
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
                                    parameter[name] = selectElement.options[selectElement.selectedIndex].value;
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
    }
    static processArrayParameter(arrayParameter, node) {
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