export function $(value) {
    if (value === undefined || value === null) {
        return new HtmlElementQuery([]);
    }
    if (typeof value === "string") {
        const ee = document.querySelectorAll(value);
        const hh = [];
        for (var i = 0; i < ee.length; i++) {
            hh.push(ee[i]);
        }
        return new HtmlElementQuery(hh);
    }
    else if (value instanceof HtmlElementQuery) {
        return value;
    }
    else if (value instanceof EventTarget) {
        return new HtmlElementQuery([value]);
    }
    else if (Array.isArray(value)) {
        return new HtmlElementQuery(value);
    }
    else {
        return new HtmlElementQuery([value]);
    }
}
export function $fromJson(obj, json) {
    const r = JSON.parse(json);
    return Object.assign(obj, r);
}
export class HtmlElementQuery {
    constructor(element) {
        this._elementList = new Array();
        element.forEach(el => {
            this._elementList.push(el);
        });
    }
    getTagName() {
        if (this._elementList.length > 0) {
            const v = this._elementList[0].tagName;
            if (v == null) {
                return "";
            }
            return v;
        }
        return "";
    }
    getAttribute(name) {
        if (this._elementList.length > 0) {
            const v = this._elementList[0].getAttribute(name);
            if (v == null) {
                return "";
            }
            return v;
        }
        return "";
    }
    hasAttribute(name) {
        if (this._elementList.length > 0) {
            return this._elementList[0].hasAttribute(name);
        }
        return false;
    }
    setAttribute(name, value) {
        this._elementList.forEach(el => {
            el.setAttribute(name, value.toString());
        });
        return this;
    }
    toggleAttributeValue(name, value1, value2) {
        for (var i = 0; i < this._elementList.length; i++) {
            var element = this._elementList[i];
            if (element.getAttribute(name) == value1) {
                element.setAttribute(name, value2);
            }
            else if (element.getAttribute(name) == value2) {
                element.setAttribute(name, value1);
            }
        }
        return this;
    }
    removeAttribute(name) {
        for (var i = 0; i < this._elementList.length; i++) {
            var element = this._elementList[i];
            element.removeAttribute(name);
        }
        return this;
    }
    getParentAttribute(name) {
        if (this.hasAttribute(name)) {
            return this.getAttribute(name);
        }
        return this.getParent("[" + name + "]").getAttribute(name);
    }
    setParentAttribute(name, value) {
        if (this.hasAttribute(name)) {
            return this.getAttribute(name);
        }
        this.getParent("[" + name + "]").setAttribute(name, value);
    }
    hasParentAttribute(name) {
        if (this.hasAttribute(name)) {
            return true;
        }
        return this.getParent("[" + name + "]").hasAttribute(name);
    }
    getNearestAttribute(name) {
        return this.getNearest("[" + name + "]").getAttribute(name);
    }
    getValue() {
        if (this._elementList.length > 0) {
            const element = this._elementList[0];
            if (element === null) {
                return "";
            }
            if (element.value == null) {
                return "";
            }
            return element.value;
        }
        return "";
    }
    getSelectedValue() {
        for (var i = 0; i < this._elementList.length; i++) {
            if (this._elementList[i] instanceof HTMLSelectElement) {
                let dl = this._elementList[i];
                return dl.options[dl.selectedIndex].value;
            }
        }
        return "";
    }
    getSelectedText() {
        for (var i = 0; i < this._elementList.length; i++) {
            if (this._elementList[i] instanceof HTMLSelectElement) {
                let dl = this._elementList[i];
                return dl.options[dl.selectedIndex].textContent;
            }
        }
        return "";
    }
    setValue(value) {
        for (var i = 0; i < this._elementList.length; i++) {
            const element = this._elementList[i];
            if (element === null) {
                continue;
            }
            element.value = value;
        }
        return this;
    }
    setSelectedValue(value) {
        for (var i = 0; i < this._elementList.length; i++) {
            if (this._elementList[i] instanceof HTMLSelectElement) {
                let dl = this._elementList[i];
                if (dl.options[dl.selectedIndex].value == value) {
                    dl.options[dl.selectedIndex].selected = true;
                }
            }
        }
        return "";
    }
    toggleChecked() {
        for (var i = 0; i < this._elementList.length; i++) {
            if ($(this._elementList[i]).isChecked() == true) {
                $(this._elementList[i]).setChecked(false);
            }
            else {
                $(this._elementList[i]).setChecked(true);
            }
        }
        return this;
    }
    getIndex() {
        if (this._elementList.length > 0) {
            const element = this._elementList[0];
            const parent = element.parentElement;
            for (var i = 0; i < parent.children.length; i++) {
                if (parent.children[i] == element) {
                    return i;
                }
            }
            return -1;
        }
        return -1;
    }
    setFocus(options) {
        if (this._elementList.length > 0) {
            const element = this._elementList[0];
            if (element === null) {
                return;
            }
            element.focus(options);
        }
        return this;
    }
    select() {
        if (this._elementList.length > 0) {
            const element = this._elementList[0];
            if (element === null) {
                return;
            }
            element.select();
        }
        return this;
    }
    setChecked(value) {
        for (var i = 0; i < this._elementList.length; i++) {
            var rb = this._elementList[i];
            if (rb.type == null) {
                continue;
            }
            if (rb.type.toLowerCase() == "radio" ||
                rb.type.toLowerCase() == "checkbox") {
                rb.checked = value;
            }
        }
        return this;
    }
    isChecked() {
        for (var i = 0; i < this._elementList.length; i++) {
            var rb = this._elementList[i];
            if (rb.type == null) {
                continue;
            }
            if (rb.type.toLowerCase() == "radio" ||
                rb.type.toLowerCase() == "checkbox") {
                return rb.checked;
            }
        }
        return null;
    }
    getInnerWidth() {
        if (this._elementList.length > 0) {
            const element = this._elementList[0];
            if (element instanceof Window) {
                return window.innerWidth || document.documentElement.clientWidth || document.body.clientWidth;
            }
            return element.clientWidth;
        }
        return null;
    }
    getInnerHeight() {
        if (this._elementList.length > 0) {
            const element = this._elementList[0];
            if (element instanceof Window) {
                return window.innerHeight || document.documentElement.clientHeight || document.body.clientHeight;
            }
            return element.clientHeight;
        }
        return null;
    }
    getOuterWidth() {
        if (this._elementList.length > 0) {
            const element = this._elementList[0];
            if (element instanceof Window) {
                return window.outerWidth || document.documentElement.clientWidth || document.body.clientWidth;
            }
            return element.offsetWidth;
        }
        return null;
    }
    getOuterHeight() {
        if (this._elementList.length > 0) {
            const element = this._elementList[0];
            if (element instanceof Window) {
                return window.outerHeight || document.documentElement.clientHeight || document.body.clientHeight;
            }
            return element.offsetHeight;
        }
        return null;
    }
    getOffset() {
        if (this._elementList.length > 0) {
            const element = this._elementList[0];
            var box = { top: 0, left: 0 };
            const doc = element && element.ownerDocument;
            const docElem = doc.documentElement;
            if (typeof element.getBoundingClientRect !== typeof undefined) {
                box = element.getBoundingClientRect();
            }
            const win = this.getWindow(doc);
            return {
                top: box.top + win.pageYOffset - docElem.clientTop,
                left: box.left + win.pageXOffset - docElem.clientLeft
            };
        }
        return null;
    }
    isWindow(obj) {
        return obj != null && obj === obj.window;
    }
    getWindow(element) {
        return this.isWindow(element) ? element : element.nodeType === 9 && element.defaultView;
    }
    getScrollLeft() {
        if (this._elementList.length > 0) {
            const element = this._elementList[0];
            if (element instanceof Window) {
                return document.documentElement.scrollLeft || document.body.scrollLeft;
            }
            return this._elementList[0].scrollLeft;
        }
        return null;
    }
    getScrollTop() {
        if (this._elementList.length > 0) {
            const element = this._elementList[0];
            if (element instanceof Window) {
                return document.documentElement.scrollTop || document.body.scrollTop;
            }
            return this._elementList[0].scrollTop;
        }
        return null;
    }
    setScrollLeft(value) {
        for (var i = 0; i < this._elementList.length; i++) {
            var element = this._elementList[i];
            if (element instanceof Window) {
                if (document.documentElement.scrollLeft != null) {
                    document.documentElement.scrollLeft = value;
                }
                else if (document.body.scrollLeft) {
                    document.body.scrollLeft = value;
                }
            }
            element.scrollLeft = value;
        }
    }
    setScrollTop(value) {
        for (var i = 0; i < this._elementList.length; i++) {
            var element = this._elementList[i];
            if (element instanceof Window) {
                if (document.documentElement.scrollTop != null) {
                    document.documentElement.scrollTop = value;
                }
                else if (document.body.scrollTop) {
                    document.body.scrollTop = value;
                }
            }
            element.scrollTop = value;
        }
    }
    getInnerText() {
        if (this._elementList.length > 0) {
            return this._elementList[0].textContent;
        }
        return "";
    }
    getInnerHtml() {
        if (this._elementList.length > 0) {
            return this._elementList[0].innerHTML;
        }
        return "";
    }
    getOuterHtml() {
        if (this._elementList.length > 0) {
            return this._elementList[0].outerHTML;
        }
        return "";
    }
    setInnerText(value) {
        for (var i = 0; i < this._elementList.length; i++) {
            this._elementList[i].textContent = value;
        }
        return this;
    }
    setInnerHtml(html) {
        for (var i = 0; i < this._elementList.length; i++) {
            this._elementList[i].innerHTML = html;
        }
        return this;
    }
    getStyle(name) {
        if (this._elementList.length > 0) {
            const element = this._elementList[0];
            const styles = window.getComputedStyle(element);
            return styles[name];
        }
        return "";
    }
    setStyle(name, value) {
        for (var i = 0; i < this._elementList.length; i++) {
            const element = this._elementList[i];
            element.style[name] = value;
        }
        return this;
    }
    removeStyle(name) {
        for (var i = 0; i < this._elementList.length; i++) {
            const element = this._elementList[i];
            element.style[name] = null;
        }
        return this;
    }
    toggleStyle(name, value1, value2) {
        for (var i = 0; i < this._elementList.length; i++) {
            let element = this._elementList[i];
            if (element.style[name] == value1) {
                element.style[name] = value2;
            }
            else if (element.style[name] == value2) {
                element.style[name] = value1;
            }
        }
        return this;
    }
    getHexColor(name) {
        const rgb = this.getStyle(name);
        return "#" + rgb.match(/\d+/g).map(function (value) {
            return ("0" + parseInt(value).toString(16)).slice(-2);
        }).join("");
    }
    addClass(className) {
        for (var i = 0; i < this._elementList.length; i++) {
            this._elementList[i].classList.add(className);
        }
        return this;
    }
    hasClass(className) {
        if (this._elementList.length > 0) {
            return this._elementList[0].classList.contains(className);
        }
        return false;
    }
    toggleClass(className) {
        for (var i = 0; i < this._elementList.length; i++) {
            this._elementList[i].classList.toggle(className);
        }
        return this;
    }
    removeClass(className) {
        for (var i = 0; i < this._elementList.length; i++) {
            this._elementList[i].classList.remove(className);
        }
        return this;
    }
    getParentElementList() {
        if (this._elementList.length > 0) {
            var element = this._elementList[0];
            var result = new Array();
            let p = element.parentElement;
            while (p != null) {
                result.push(p);
                p = p.parentElement;
            }
            return result;
        }
        return HtmlElementQuery._emptyElementList;
    }
    getFirstParent(selector) {
        return $(this.getParent(selector).getFirstElement());
    }
    getParent(selector) {
        const parentList = new Array();
        for (var i = 0; i < this._elementList.length; i++) {
            let element = this._elementList[i];
            let p = element.parentElement;
            while (p != null) {
                parentList.push(p);
                p = p.parentElement;
            }
        }
        const filterList = $(selector).getElementList();
        const l = new Array();
        for (var pIndex = 0; pIndex < parentList.length; pIndex++) {
            for (var i = 0; i < filterList.length; i++) {
                if (filterList[i] == parentList[pIndex]) {
                    $(filterList[i]).forEach(element => {
                        l.push(element);
                    });
                }
            }
        }
        return $(l);
    }
    remove() {
        for (var i = 0; i < this._elementList.length; i++) {
            this._elementList[i].remove();
        }
        return this;
    }
    on(eventType, selector, callback) {
        for (var i = 0; i < this._elementList.length; i++) {
            this.addEventListener(this._elementList[i], eventType, selector, callback);
        }
    }
    addEventListener(element, eventType, selector, callback) {
        let f = new OnEventHandler();
        f.element = element;
        f.eventType = eventType;
        f.handler = function (e) {
            const l = element.querySelectorAll(selector);
            for (var i = 0; i < l.length; i++) {
                if (event.target == l[i]) {
                    callback(l[i], e);
                    return;
                }
                var pp = $(event.target).getParentElementList();
                for (var pIndex = 0; pIndex < pp.length; pIndex++) {
                    if (pp[pIndex] == l[i]) {
                        callback(l[i], e);
                        return;
                    }
                }
            }
        }.bind(this);
        if (HtmlElementQuery._onEventHandlerList.find(el => el.element == element && el.eventType == eventType) == null) {
            element.addEventListener(eventType, function (e) {
                this.triggerOnEventHandler(element, eventType, e);
            }.bind(this));
        }
        HtmlElementQuery._onEventHandlerList.push(f);
    }
    triggerOnEventHandler(element, eventType, e) {
        for (var i = 0; i < HtmlElementQuery._onEventHandlerList.length; i++) {
            let f = HtmlElementQuery._onEventHandlerList[i];
            if (f.element != element || f.eventType != eventType) {
                continue;
            }
            f.handler(e);
            if (e.defaultPrevented === true) {
                break;
            }
        }
    }
    addEventListenerToAllElement(eventType, callback) {
        for (var i = 0; i < this._elementList.length; i++) {
            var element = this._elementList[i];
            element.addEventListener(eventType, callback);
        }
    }
    resize(callback) {
        this.addEventListenerToAllElement("resize", callback);
    }
    keydown(callback, keyCode) {
        for (var i = 0; i < this._elementList.length; i++) {
            var element = this._elementList[i];
            element.addEventListener("keydown", function (e) {
                if (keyCode == null || e.keyCode === keyCode) {
                    callback(e);
                }
            });
        }
    }
    keyup(callback, keyCode) {
        for (var i = 0; i < this._elementList.length; i++) {
            var element = this._elementList[i];
            element.addEventListener("keyup", function (e) {
                if (e.keyCode === null || e.keyCode === keyCode) {
                    callback(e);
                }
            });
        }
    }
    click(callback) {
        this.addEventListenerToAllElement("click", callback);
    }
    mousedown(callback) {
        this.addEventListenerToAllElement("mousedown", callback);
    }
    mousemove(callback) {
        this.addEventListenerToAllElement("mousemove", callback);
    }
    mouseup(callback) {
        this.addEventListenerToAllElement("mouseup", callback);
    }
    mouseover(callback) {
        this.addEventListenerToAllElement("mouseover", callback);
    }
    mouseenter(callback) {
        this.addEventListenerToAllElement("mouseenter", callback);
    }
    mouseleave(callback) {
        this.addEventListenerToAllElement("mouseleave", callback);
    }
    change(callback) {
        this.addEventListenerToAllElement("change", callback);
    }
    focus(callback) {
        this.addEventListenerToAllElement("focus", callback);
    }
    blur(callback) {
        this.addEventListenerToAllElement("blur", callback);
    }
    scroll(callback) {
        this.addEventListenerToAllElement("scroll", callback);
    }
    triggerEvent(event) {
        if (event instanceof Event) {
            for (var i = 0; i < this._elementList.length; i++) {
                var element = this._elementList[i];
                element.dispatchEvent(e);
            }
        }
        else if (typeof event === "string") {
            if (document.createEvent) {
                var e = document.createEvent("HTMLEvents");
                e.initEvent(event, true, true);
                for (var i = 0; i < this._elementList.length; i++) {
                    var element = this._elementList[i];
                    element.dispatchEvent(e);
                }
            }
        }
    }
    hide() {
        this.setStyle("display", "none");
        return this;
    }
    getElementCount() {
        if (this._elementList == null) {
            return 0;
        }
        return this._elementList.length;
    }
    getElementList() {
        return this._elementList;
    }
    getFirstElement() {
        if (this._elementList.length === 0) {
            return null;
        }
        return this._elementList[0];
    }
    getLastElement() {
        if (this._elementList.length === 0) {
            return null;
        }
        return this._elementList[this._elementList.length - 1];
    }
    getChildElementList() {
        const elementList = new Array();
        for (var i = 0; i < this._elementList.length; i++) {
            var element = this._elementList[i];
            for (var cIndex = 0; cIndex < element.children.length; cIndex++) {
                elementList.push(element.children[cIndex]);
            }
        }
        return elementList;
    }
    getSibling(direction) {
        const elementList = new Array();
        switch (direction) {
            case "Previous":
                for (var i = 0; i < this._elementList.length; i++) {
                    let element = this._elementList[i];
                    let nodeList = element.parentElement.children;
                    for (var nIndex = 0; nIndex < nodeList.length; nIndex++) {
                        if (nodeList[nIndex] == element) {
                            break;
                        }
                        elementList.push(nodeList[nIndex]);
                    }
                }
                break;
            case "Next":
                for (var i = 0; i < this._elementList.length; i++) {
                    let element = this._elementList[i];
                    let nodeList = element.parentElement.children;
                    let isStarted = false;
                    for (var nIndex = 0; nIndex < nodeList.length; nIndex++) {
                        if (isStarted == true) {
                            elementList.push(nodeList[nIndex]);
                        }
                        if (nodeList[nIndex] == element) {
                            isStarted = true;
                        }
                    }
                }
                break;
            default:
        }
        return new HtmlElementQuery(elementList);
    }
    getNearest(selector) {
        for (var i = 0; i < this._elementList.length; i++) {
            var element = this._elementList[i];
            let p = element.parentElement;
            while (p != null) {
                var child = $(p).find(selector).getFirstElement();
                if (child !== null) {
                    return $(child);
                }
                p = p.parentElement;
            }
        }
        return HtmlElementQuery._emptyHtmlElementQuery;
    }
    getNearestElement(selector) {
        for (var i = 0; i < this._elementList.length; i++) {
            var element = this._elementList[i];
            let p = element.parentElement;
            while (p != null) {
                var childList = $(p).find(selector).getElementList();
                for (var cIndex = 0; cIndex < childList.length; cIndex++) {
                    if (childList[cIndex] !== element) {
                        return childList[cIndex];
                    }
                }
                p = p.parentElement;
            }
        }
    }
    find(selector) {
        const elementList = new Array();
        for (var i = 0; i < this._elementList.length; i++) {
            let nodeList = this._elementList[i].querySelectorAll(selector);
            for (var nIndex = 0; nIndex < nodeList.length; nIndex++) {
                elementList.push(nodeList[nIndex]);
            }
        }
        return new HtmlElementQuery(elementList);
    }
    forEach(callback) {
        this._elementList.forEach(callback);
    }
    static domContentLoaded(callback) {
        document.addEventListener("DOMContentLoaded", callback);
    }
}
HtmlElementQuery._emptyElementList = new Array();
HtmlElementQuery._emptyHtmlElementQuery = new HtmlElementQuery(HtmlElementQuery._emptyElementList);
HtmlElementQuery._onEventHandlerList = new Array();
class OnEventHandler {
}
//# sourceMappingURL=HtmlElementQuery.js.map