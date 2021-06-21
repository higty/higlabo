export function $(selector: string): HtmlElementQuery;
export function $(element: Element): HtmlElementQuery;
export function $(elementList: Element[]): HtmlElementQuery;
export function $(eventTarget: EventTarget): HtmlElementQuery;
export function $(query: HtmlElementQuery): HtmlElementQuery;
export function $(value: string | Element | Element[] | EventTarget | HtmlElementQuery): HtmlElementQuery {
    if (value === undefined || value === null) { return new HtmlElementQuery([]); }
    if (typeof value === "string") {
        const ee = document.querySelectorAll(value);
        const hh = [];
        for (var i = 0; i < ee.length; i++) {
            hh.push(ee[i] as Element);
        }
        return new HtmlElementQuery(hh);
    }
    else if (value instanceof HtmlElementQuery) {
        return value;
    }
    else if (value instanceof EventTarget) {
        return new HtmlElementQuery([value as Element]);
    }
    else if (Array.isArray(value)) {
        return new HtmlElementQuery(value);
    }
    else {
        return new HtmlElementQuery([value]);
    }
}

export function $fromJson<T>(obj: T, json: string): T {
    const r = JSON.parse(json);
    return Object.assign(obj, r);
}

export class HtmlElementQuery {
    private static _emptyElementList = new Array<Element>();
    private static _emptyHtmlElementQuery = new HtmlElementQuery(HtmlElementQuery._emptyElementList);
    private static _onEventHandlerList: Array<OnEventHandler> = new Array<OnEventHandler>();

    private _elementList: Array<Element> = new Array<Element>();

    constructor(element: Array<Element>) {
        element.forEach(el => {
            this._elementList.push(el);
        });
    }

    public getTagName() {
        if (this._elementList.length > 0) {
            const v = this._elementList[0].tagName;
            if (v == null) { return ""; }
            return v;
        }
        return "";
    }
    public getAttribute(name: string): string {
        if (this._elementList.length > 0) {
            const v = this._elementList[0].getAttribute(name);
            if (v == null) { return ""; }
            return v;
        }
        return "";
    }
    public hasAttribute(name: string): boolean {
        if (this._elementList.length > 0) {
            return this._elementList[0].hasAttribute(name);
        }
        return false;
    }
    public setAttribute(name: string, value: string | number): HtmlElementQuery {
        this._elementList.forEach(el => {
            el.setAttribute(name, value.toString());
        });
        return this;
    }
    public toggleAttributeValue(name: string, value1: string, value2: string): HtmlElementQuery {
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
    public removeAttribute(name: string): HtmlElementQuery {
        for (var i = 0; i < this._elementList.length; i++) {
            var element = this._elementList[i];
            element.removeAttribute(name);
        }
        return this;
    }
    public getParentAttribute(name: string): string {
        if (this.hasAttribute(name)) {
            return this.getAttribute(name);
        }
        return this.getParent("[" + name + "]").getAttribute(name);
    }
    public setParentAttribute(name: string, value: string) {
        if (this.hasAttribute(name)) {
            return this.getAttribute(name);
        }
        this.getParent("[" + name + "]").setAttribute(name, value);
    }
    public hasParentAttribute(name: string): boolean {
        if (this.hasAttribute(name)) {
            return true;
        }
        return this.getParent("[" + name + "]").hasAttribute(name);
    }
    public getNearestAttribute(name: string): string {
        return this.getNearest("[" + name + "]").getAttribute(name);
    }

    public getValue(): string {
        if (this._elementList.length > 0) {
            const element = this._elementList[0] as HTMLInputElement;
            if (element === null) { return ""; }
            if (element.value == null) { return ""; }
            return element.value;
        }
        return "";
    }
    public getSelectedValue(): string {
        for (var i = 0; i < this._elementList.length; i++) {
            if (this._elementList[i] instanceof HTMLSelectElement) {
                let dl = this._elementList[i] as HTMLSelectElement;
                return dl.options[dl.selectedIndex].value;
            }
        }
        return "";
    }
    public getSelectedText(): string {
        for (var i = 0; i < this._elementList.length; i++) {
            if (this._elementList[i] instanceof HTMLSelectElement) {
                let dl = this._elementList[i] as HTMLSelectElement;
                return dl.options[dl.selectedIndex].textContent;
            }
        }
        return "";
    }
    public setValue(value: string): HtmlElementQuery {
        for (var i = 0; i < this._elementList.length; i++) {
            const element = this._elementList[i] as HTMLInputElement;
            if (element === null) { continue; }
            if ($(element).getAttribute("type").toLowerCase() == "file") { continue; }
            element.value = value;
        }
        return this;
    }
    public setSelectedValue(value: string) {
        for (var i = 0; i < this._elementList.length; i++) {
            if (this._elementList[i] instanceof HTMLSelectElement) {
                let dl = this._elementList[i] as HTMLSelectElement;
                if (dl.options[dl.selectedIndex].value == value) {
                    dl.options[dl.selectedIndex].selected = true;
                }
            }
        }
        return "";
    }
    public toggleChecked(): HtmlElementQuery {
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
    public getIndex(): number {
        if (this._elementList.length > 0) {
            const element = this._elementList[0] as HTMLInputElement;
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

    public setFocus(options?: FocusOptions): HtmlElementQuery {
        if (this._elementList.length > 0) {
            const element = this._elementList[0] as HTMLElement;
            if (element === null) { return; }
            element.focus(options);
        }
        return this;
    }
    public select(): HtmlElementQuery {
        if (this._elementList.length > 0) {
            const element = this._elementList[0] as HTMLInputElement;
            if (element === null) { return; }
            element.select();
        }
        return this;
    }
    public setChecked(value: boolean): HtmlElementQuery {
        for (var i = 0; i < this._elementList.length; i++) {
            var rb = this._elementList[i] as HTMLInputElement;
            if (rb.type == null) { continue; }
            if (rb.type.toLowerCase() == "radio" ||
                rb.type.toLowerCase() == "checkbox") {
                rb.checked = value;
            }
        }
        return this;
    }
    public isChecked(): boolean {
        for (var i = 0; i < this._elementList.length; i++) {
            var rb = this._elementList[i] as HTMLInputElement;
            if (rb.type == null) { continue; }
            if (rb.type.toLowerCase() == "radio" ||
                rb.type.toLowerCase() == "checkbox") {
                return rb.checked;
            }

        }
        return null;
    }

    public getInnerWidth(): number {
        if (this._elementList.length > 0) {
            const element = this._elementList[0] as HTMLElement;
            if (element instanceof Window) {
                return window.innerWidth || document.documentElement.clientWidth || document.body.clientWidth;
            }
            return element.clientWidth;
        }
        return null;
    }
    public getInnerHeight(): number {
        if (this._elementList.length > 0) {
            const element = this._elementList[0] as HTMLElement;
            if (element instanceof Window) {
                return window.innerHeight || document.documentElement.clientHeight || document.body.clientHeight;
            }
            return element.clientHeight;
        }
        return null;
    }
    public getOuterWidth(): number {
        if (this._elementList.length > 0) {
            const element = this._elementList[0] as HTMLElement;
            if (element instanceof Window) {
                return window.outerWidth || document.documentElement.clientWidth || document.body.clientWidth;
            }
            return element.offsetWidth;
        }
        return null;
    }
    public getOuterHeight(): number {
        if (this._elementList.length > 0) {
            const element = this._elementList[0] as HTMLElement;
            if (element instanceof Window) {
                return window.outerHeight || document.documentElement.clientHeight || document.body.clientHeight;
            }
            return element.offsetHeight;
        }
        return null;
    }
    public getOffset() {
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
    private isWindow(obj) {
        return obj != null && obj === obj.window;
    }
    private getWindow(element) {
        return this.isWindow(element) ? element : element.nodeType === 9 && element.defaultView;
    }
    public getScrollLeft() {
        if (this._elementList.length > 0) {
            const element = this._elementList[0];
            if (element instanceof Window) {
                return document.documentElement.scrollLeft || document.body.scrollLeft;
            }
            return this._elementList[0].scrollLeft;
        }
        return null;
    }
    public getScrollTop() {
        if (this._elementList.length > 0) {
            const element = this._elementList[0];
            if (element instanceof Window) {
                return document.documentElement.scrollTop || document.body.scrollTop;
            }
            return this._elementList[0].scrollTop;
        }
        return null;
    }
    public setScrollLeft(value: number) {
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
    public setScrollTop(value: number) {
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

    public getInnerText(): string {
        if (this._elementList.length > 0) {
            return this._elementList[0].textContent;
        }
        return "";
    }
    public getInnerHtml(): string {
        if (this._elementList.length > 0) {
            return this._elementList[0].innerHTML;
        }
        return "";
    }
    public getOuterHtml(): string {
        if (this._elementList.length > 0) {
            return this._elementList[0].outerHTML;
        }
        return "";
    }
    public setInnerText(value: string): HtmlElementQuery {
        for (var i = 0; i < this._elementList.length; i++) {
            this._elementList[i].textContent = value;
        }
        return this;
    }
    public setInnerHtml(html: string): HtmlElementQuery {
        for (var i = 0; i < this._elementList.length; i++) {
            this._elementList[i].innerHTML = html;
        }
        return this;
    }

    public getStyle(name: string): string {
        if (this._elementList.length > 0) {
            const element = this._elementList[0] as HTMLElement;
            const styles = window.getComputedStyle(element);
            return styles[name];
        }
        return "";
    }
    public setStyle(name: string, value: string): HtmlElementQuery {
        for (var i = 0; i < this._elementList.length; i++) {
            const element = this._elementList[i] as HTMLElement;
            element.style[name] = value;
        }
        return this;
    }
    public removeStyle(name: string): HtmlElementQuery {
        for (var i = 0; i < this._elementList.length; i++) {
            const element = this._elementList[i] as HTMLElement;
            element.style[name] = null;
        }
        return this;
    }
    public toggleStyle(name: string, value1: string, value2: string): HtmlElementQuery {
        for (var i = 0; i < this._elementList.length; i++) {
            let element = this._elementList[i] as HTMLElement;
            if (element.style[name] == value1) {
                element.style[name] = value2;
            }
            else if (element.style[name] == value2) {
                element.style[name] = value1;
            }
        }
        return this;
    }
    public getHexColor(name: string) {
        const rgb = this.getStyle(name);
        return "#" + rgb.match(/\d+/g).map(function (value) {
            return ("0" + parseInt(value).toString(16)).slice(-2);
        }).join("");
    }

    public addClass(className: string): HtmlElementQuery {
        for (var i = 0; i < this._elementList.length; i++) {
            this._elementList[i].classList.add(className);
        }
        return this;
    }
    public hasClass(className: string): boolean {
        if (this._elementList.length > 0) {
            return this._elementList[0].classList.contains(className);
        }
        return false;
    }
    public toggleClass(className: string): HtmlElementQuery {
        for (var i = 0; i < this._elementList.length; i++) {
            this._elementList[i].classList.toggle(className);
        }
        return this;
    }
    public removeClass(className: string): HtmlElementQuery {
        for (var i = 0; i < this._elementList.length; i++) {
            this._elementList[i].classList.remove(className);
        }
        return this;
    }
    public getParentElementList(): Array<Element> {
        if (this._elementList.length > 0) {
            var element = this._elementList[0];
            var result = new Array<Element>();
            let p = element.parentElement;
            while (p != null) {
                result.push(p);
                p = p.parentElement;
            }
            return result;
        }
        return HtmlElementQuery._emptyElementList;
    }
    public getFirstParent(selector: string): HtmlElementQuery {
        return $(this.getParent(selector).getFirstElement());
    }
    public getParent(selector: string): HtmlElementQuery {
        const parentList = new Array<Element>();

        for (var i = 0; i < this._elementList.length; i++) {
            let element = this._elementList[i];
            let p = element.parentElement;
            while (p != null) {
                parentList.push(p);
                p = p.parentElement;
            }
        }
        const filterList = $(selector).getElementList();
        const l = new Array<Element>();
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

    public remove(): HtmlElementQuery {
        for (var i = 0; i < this._elementList.length; i++) {
            this._elementList[i].remove();
        }
        return this;
    }

    public on(eventType: string, selector: string, callback: (target: Element, e: Event) => void) {
        for (var i = 0; i < this._elementList.length; i++) {
            this.addEventListener(this._elementList[i], eventType, selector, callback);
        }
    }
    private addEventListener(element: Element, eventType: string, selector: string, callback: (target: Element, e: Event) => void) {
        let f = new OnEventHandler();
        f.element = element;
        f.eventType = eventType;
        f.handler = function (e: Event) {
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
            element.addEventListener(eventType, function (e: Event) {
                this.triggerOnEventHandler(element, eventType, e);
            }.bind(this));
        }
        HtmlElementQuery._onEventHandlerList.push(f);
    }
    private triggerOnEventHandler(element: Element, eventType: string, e: Event) {
        for (var i = 0; i < HtmlElementQuery._onEventHandlerList.length; i++) {
            let f = HtmlElementQuery._onEventHandlerList[i];
            if (f.element != element || f.eventType != eventType) { continue; }
            f.handler(e);
            if (e.defaultPrevented === true) { break; }
        }
    }

    private addEventListenerToAllElement(eventType: string, callback: EventListenerOrEventListenerObject) {
        for (var i = 0; i < this._elementList.length; i++) {
            var element = this._elementList[i];
            element.addEventListener(eventType, callback);
        }
    }
    public resize(callback: EventListenerOrEventListenerObject) {
        this.addEventListenerToAllElement("resize", callback);
    }
    public keydown(callback: (e: KeyboardEvent) => {}, keyCode?: number) {
        for (var i = 0; i < this._elementList.length; i++) {
            var element = this._elementList[i];
            element.addEventListener("keydown", function (e: KeyboardEvent) {
                if (keyCode == null || e.keyCode === keyCode) {
                    callback(e);
                }
            });
        }
    }
    public keyup(callback: (e: KeyboardEvent) => {}, keyCode?: number) {
        for (var i = 0; i < this._elementList.length; i++) {
            var element = this._elementList[i];
            element.addEventListener("keyup", function (e: KeyboardEvent) {
                if (e.keyCode === null || e.keyCode === keyCode) {
                    callback(e);
                }
            });
        }
    }
    public click(callback: (e: MouseEvent) => {}) {
        this.addEventListenerToAllElement("click", callback);
    }
    public mousedown(callback: (e: MouseEvent) => {}) {
        this.addEventListenerToAllElement("mousedown", callback);
    }
    public mousemove(callback: (e: MouseEvent) => {}) {
        this.addEventListenerToAllElement("mousemove", callback);
    }
    public mouseup(callback: (e: MouseEvent) => {}) {
        this.addEventListenerToAllElement("mouseup", callback);
    }
    public mouseover(callback: (e: MouseEvent) => {}) {
        this.addEventListenerToAllElement("mouseover", callback);
    }
    public mouseenter(callback: (e: MouseEvent) => {}) {
        this.addEventListenerToAllElement("mouseenter", callback);
    }
    public mouseleave(callback: (e: MouseEvent) => {}) {
        this.addEventListenerToAllElement("mouseleave", callback);
    }
    public change(callback: (e: Event) => {}) {
        this.addEventListenerToAllElement("change", callback);
    }
    public focus(callback: (e: Event) => {}) {
        this.addEventListenerToAllElement("focus", callback);
    }
    public blur(callback: (e: Event) => {}) {
        this.addEventListenerToAllElement("blur", callback);
    }
    public scroll(callback: (e: Event) => {}) {
        this.addEventListenerToAllElement("scroll", callback);
    }

    public triggerEvent(event: string | Event) {
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

    public hide(): HtmlElementQuery {
        this.setStyle("display", "none");
        return this;
    }

    public getElementCount() {
        if (this._elementList == null) { return 0; }
        return this._elementList.length;
    }
    public getElementList(): Array<Element> {
        return this._elementList;
    }
    public getFirstElement(): Element {
        if (this._elementList.length === 0) { return null; }
        return this._elementList[0];
    }
    public getLastElement(): Element {
        if (this._elementList.length === 0) { return null; }
        return this._elementList[this._elementList.length - 1];
    }
    public getChildElementList(): Array<Element> {
        const elementList = new Array<Element>();
        for (var i = 0; i < this._elementList.length; i++) {
            var element = this._elementList[i];
            for (var cIndex = 0; cIndex < element.children.length; cIndex++) {
                elementList.push(element.children[cIndex]);
            }
        }
        return elementList;
    }
    public getSibling(direction: "Previous" | "Next"): HtmlElementQuery {
        const elementList = new Array<Element>();
        switch (direction) {
            case "Previous":
                for (var i = 0; i < this._elementList.length; i++) {
                    let element = this._elementList[i];
                    let nodeList = element.parentElement.children;
                    for (var nIndex = 0; nIndex < nodeList.length; nIndex++) {
                        if (nodeList[nIndex] == element) { break; }
                        elementList.push(nodeList[nIndex] as Element);
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
                            elementList.push(nodeList[nIndex] as Element);
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
    public getNearest(selector: string): HtmlElementQuery {
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
    public getNearestElement(selector: string): Element {
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
    public find(selector: string): HtmlElementQuery {
        const elementList = new Array<Element>();
        for (var i = 0; i < this._elementList.length; i++) {
            let nodeList = this._elementList[i].querySelectorAll(selector);
            for (var nIndex = 0; nIndex < nodeList.length; nIndex++) {
                elementList.push(nodeList[nIndex] as Element);
            }
        }
        return new HtmlElementQuery(elementList);
    }

    public forEach(callback: (element: Element, index: number, array: Element[]) => void) {
        this._elementList.forEach(callback);
    }

    public static domContentLoaded(callback: EventListenerOrEventListenerObject) {
        document.addEventListener("DOMContentLoaded", callback);
    }
}

class OnEventHandler {
    public element: Element;
    public eventType: string;
    public handler: EventListener;
}

