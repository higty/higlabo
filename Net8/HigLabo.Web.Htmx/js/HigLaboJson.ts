export class HigLaboJson {
    public static processParameter(parameter, node: Node) {
        node.childNodes.forEach((childNode) => {
            if (childNode.nodeType == Node.ELEMENT_NODE) {
                const childElement = <HTMLElement>childNode;
                const name = childElement.getAttribute("name");

                if (parameter instanceof Array) {
                    if (childElement.getAttribute("hig-property-type") == "Ignore") {
                        return;
                    }
                    else if (childElement.getAttribute("hig-property-type") == "Object") {
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
                                if (childElement.getAttribute("type") == "checkbox") {
                                    if (inputElement.checked == true) {
                                        //Push value to array
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
                                let inputElement = childElement as HTMLInputElement;
                                //Push object to array
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
                                r[name] = childElement.innerText;
                                parameter.push(r);
                            }
                        }
                    }
                }
                else {
                    if (name != null) {
                        if (childElement.getAttribute("hig-property-type") == "Ignore") {
                            return;
                        }
                        else if (childElement.getAttribute("hig-property-type") == "Object") {
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
                                if (childElement.getAttribute("type") == "checkbox") {
                                    parameter[name] = inputElement.checked;
                                }
                                else {
                                    parameter[name] = inputElement.value;
                                }
                            }
                            else {
                                parameter[name] = childElement.innerText;
                            }
                        }
                    }
                }
                this.processParameter(parameter, childNode);
            }
        });
    }
    public static processArrayParameter(arrayParameter: Array<any>, node: Node) {
        node.childNodes.forEach((childNode) => {
            if (childNode.nodeType == Node.ELEMENT_NODE) {
                const childElement = <HTMLElement>childNode;
                const name = childElement.getAttribute("name");
                if (name != null) {
                    if (childElement.getAttribute("hig-property-type") == "Ignore") {
                        return;
                    }
                    else if (childElement.getAttribute("hig-property-type") == "Object") {
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
                            arrayParameter.push({ name: childElement.innerText });
                        }
                        this.processParameter(arrayParameter, childNode);
                    }
                }
                else {
                    if (childElement.getAttribute("hig-property-type") == "Ignore") {
                        return;
                    }
                    else if (childElement.getAttribute("hig-property-type") == "Object") {
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

