export function $(value) {
    if (value === undefined || value === null) {
        return new HtmlElementQuery([]);
    }
    if (typeof value === "string") {
        var ee = document.querySelectorAll(value);
        var hh = [];
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
var HtmlElementQuery = (function () {
    function HtmlElementQuery(element) {
        var _this = this;
        this._elementList = new Array();
        element.forEach(function (el) {
            _this._elementList.push(el);
        });
    }
    HtmlElementQuery.prototype.getTagName = function () {
        if (this._elementList.length > 0) {
            var v = this._elementList[0].tagName;
            if (v == null) {
                return "";
            }
            return v;
        }
        return "";
    };
    HtmlElementQuery.prototype.getAttribute = function (name) {
        if (this._elementList.length > 0) {
            var v = this._elementList[0].getAttribute(name);
            if (v == null) {
                return "";
            }
            return v;
        }
        return "";
    };
    HtmlElementQuery.prototype.hasAttribute = function (name) {
        if (this._elementList.length > 0) {
            return this._elementList[0].hasAttribute(name);
        }
        return false;
    };
    HtmlElementQuery.prototype.setAttribute = function (name, value) {
        this._elementList.forEach(function (el) {
            el.setAttribute(name, value.toString());
        });
        return this;
    };
    HtmlElementQuery.prototype.toggleAttributeValue = function (name, value1, value2) {
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
    };
    HtmlElementQuery.prototype.removeAttribute = function (name) {
        for (var i = 0; i < this._elementList.length; i++) {
            var element = this._elementList[i];
            element.removeAttribute(name);
        }
        return this;
    };
    HtmlElementQuery.prototype.getParentAttribute = function (name) {
        if (this.hasAttribute(name)) {
            return this.getAttribute(name);
        }
        return this.getParent("[" + name + "]").getAttribute(name);
    };
    HtmlElementQuery.prototype.hasParentAttribute = function (name) {
        if (this.hasAttribute(name)) {
            return true;
        }
        return this.getParent("[" + name + "]").hasAttribute(name);
    };
    HtmlElementQuery.prototype.getNearestAttribute = function (name) {
        return this.getNearest("[" + name + "]").getAttribute(name);
    };
    HtmlElementQuery.prototype.getValue = function () {
        if (this._elementList.length > 0) {
            var element = this._elementList[0];
            if (element === null) {
                return "";
            }
            if (element.value == null) {
                return "";
            }
            return element.value;
        }
        return "";
    };
    HtmlElementQuery.prototype.getSelectedValue = function () {
        for (var i = 0; i < this._elementList.length; i++) {
            if (this._elementList[i] instanceof HTMLSelectElement) {
                var dl = this._elementList[i];
                return dl.options[dl.selectedIndex].value;
            }
        }
        return "";
    };
    HtmlElementQuery.prototype.getSelectedText = function () {
        for (var i = 0; i < this._elementList.length; i++) {
            if (this._elementList[i] instanceof HTMLSelectElement) {
                var dl = this._elementList[i];
                return dl.options[dl.selectedIndex].textContent;
            }
        }
        return "";
    };
    HtmlElementQuery.prototype.setValue = function (value) {
        for (var i = 0; i < this._elementList.length; i++) {
            var element = this._elementList[i];
            if (element === null) {
                continue;
            }
            if ($(element).getAttribute("type").toLowerCase() == "file") {
                continue;
            }
            element.value = value;
        }
        return this;
    };
    HtmlElementQuery.prototype.setSelectedValue = function (value) {
        for (var i = 0; i < this._elementList.length; i++) {
            if (this._elementList[i] instanceof HTMLSelectElement) {
                var dl = this._elementList[i];
                if (dl.options[dl.selectedIndex].value == value) {
                    dl.options[dl.selectedIndex].selected = true;
                }
            }
        }
        return "";
    };
    HtmlElementQuery.prototype.toggleChecked = function () {
        for (var i = 0; i < this._elementList.length; i++) {
            if ($(this._elementList[i]).isChecked() == true) {
                $(this._elementList[i]).setChecked(false);
            }
            else {
                $(this._elementList[i]).setChecked(true);
            }
        }
        return this;
    };
    HtmlElementQuery.prototype.getIndex = function () {
        if (this._elementList.length > 0) {
            var element = this._elementList[0];
            var parent_1 = element.parentElement;
            for (var i = 0; i < parent_1.children.length; i++) {
                if (parent_1.children[i] == element) {
                    return i;
                }
            }
            return -1;
        }
        return -1;
    };
    HtmlElementQuery.prototype.setFocus = function (options) {
        if (this._elementList.length > 0) {
            var element = this._elementList[0];
            if (element === null) {
                return;
            }
            element.focus(options);
        }
        return this;
    };
    HtmlElementQuery.prototype.select = function () {
        if (this._elementList.length > 0) {
            var element = this._elementList[0];
            if (element === null) {
                return;
            }
            element.select();
        }
        return this;
    };
    HtmlElementQuery.prototype.setChecked = function (value) {
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
    };
    HtmlElementQuery.prototype.isChecked = function () {
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
    };
    HtmlElementQuery.prototype.getInnerWidth = function () {
        if (this._elementList.length > 0) {
            var element = this._elementList[0];
            if (element instanceof Window) {
                return window.innerWidth || document.documentElement.clientWidth || document.body.clientWidth;
            }
            return element.clientWidth;
        }
        return null;
    };
    HtmlElementQuery.prototype.getInnerHeight = function () {
        if (this._elementList.length > 0) {
            var element = this._elementList[0];
            if (element instanceof Window) {
                return window.innerHeight || document.documentElement.clientHeight || document.body.clientHeight;
            }
            return element.clientHeight;
        }
        return null;
    };
    HtmlElementQuery.prototype.getOuterWidth = function () {
        if (this._elementList.length > 0) {
            var element = this._elementList[0];
            if (element instanceof Window) {
                return window.outerWidth || document.documentElement.clientWidth || document.body.clientWidth;
            }
            return element.offsetWidth;
        }
        return null;
    };
    HtmlElementQuery.prototype.getOuterHeight = function () {
        if (this._elementList.length > 0) {
            var element = this._elementList[0];
            if (element instanceof Window) {
                return window.outerHeight || document.documentElement.clientHeight || document.body.clientHeight;
            }
            return element.offsetHeight;
        }
        return null;
    };
    HtmlElementQuery.prototype.getOffset = function () {
        if (this._elementList.length > 0) {
            var element = this._elementList[0];
            var box = { top: 0, left: 0 };
            var doc = element && element.ownerDocument;
            var docElem = doc.documentElement;
            if (typeof element.getBoundingClientRect !== typeof undefined) {
                box = element.getBoundingClientRect();
            }
            var win = this.getWindow(doc);
            return {
                top: box.top + win.pageYOffset - docElem.clientTop,
                left: box.left + win.pageXOffset - docElem.clientLeft
            };
        }
        return null;
    };
    HtmlElementQuery.prototype.isWindow = function (obj) {
        return obj != null && obj === obj.window;
    };
    HtmlElementQuery.prototype.getWindow = function (element) {
        return this.isWindow(element) ? element : element.nodeType === 9 && element.defaultView;
    };
    HtmlElementQuery.prototype.getScrollLeft = function () {
        if (this._elementList.length > 0) {
            var element = this._elementList[0];
            if (element instanceof Window) {
                return document.documentElement.scrollLeft || document.body.scrollLeft;
            }
            return this._elementList[0].scrollLeft;
        }
        return null;
    };
    HtmlElementQuery.prototype.getScrollTop = function () {
        if (this._elementList.length > 0) {
            var element = this._elementList[0];
            if (element instanceof Window) {
                return document.documentElement.scrollTop || document.body.scrollTop;
            }
            return this._elementList[0].scrollTop;
        }
        return null;
    };
    HtmlElementQuery.prototype.setScrollLeft = function (value) {
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
    };
    HtmlElementQuery.prototype.setScrollTop = function (value) {
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
    };
    HtmlElementQuery.prototype.getInnerText = function () {
        if (this._elementList.length > 0) {
            return this._elementList[0].textContent;
        }
        return "";
    };
    HtmlElementQuery.prototype.getInnerHtml = function () {
        if (this._elementList.length > 0) {
            return this._elementList[0].innerHTML;
        }
        return "";
    };
    HtmlElementQuery.prototype.getOuterHtml = function () {
        if (this._elementList.length > 0) {
            return this._elementList[0].outerHTML;
        }
        return "";
    };
    HtmlElementQuery.prototype.setInnerText = function (value) {
        for (var i = 0; i < this._elementList.length; i++) {
            this._elementList[i].textContent = value;
        }
        return this;
    };
    HtmlElementQuery.prototype.setInnerHtml = function (html) {
        for (var i = 0; i < this._elementList.length; i++) {
            this._elementList[i].innerHTML = html;
        }
        return this;
    };
    HtmlElementQuery.prototype.getStyle = function (name) {
        if (this._elementList.length > 0) {
            var element = this._elementList[0];
            var styles = window.getComputedStyle(element);
            return styles[name];
        }
        return "";
    };
    HtmlElementQuery.prototype.setStyle = function (name, value) {
        for (var i = 0; i < this._elementList.length; i++) {
            var element = this._elementList[i];
            element.style[name] = value;
        }
        return this;
    };
    HtmlElementQuery.prototype.removeStyle = function (name) {
        for (var i = 0; i < this._elementList.length; i++) {
            var element = this._elementList[i];
            element.style[name] = null;
        }
        return this;
    };
    HtmlElementQuery.prototype.toggleStyle = function (name, value1, value2) {
        for (var i = 0; i < this._elementList.length; i++) {
            var element = this._elementList[i];
            if (element.style[name] == value1) {
                element.style[name] = value2;
            }
            else if (element.style[name] == value2) {
                element.style[name] = value1;
            }
        }
        return this;
    };
    HtmlElementQuery.prototype.getHexColor = function (name) {
        var rgb = this.getStyle(name);
        return "#" + rgb.match(/\d+/g).map(function (value) {
            return ("0" + parseInt(value).toString(16)).slice(-2);
        }).join("");
    };
    HtmlElementQuery.prototype.addClass = function (className) {
        for (var i = 0; i < this._elementList.length; i++) {
            this._elementList[i].classList.add(className);
        }
        return this;
    };
    HtmlElementQuery.prototype.hasClass = function (className) {
        if (this._elementList.length > 0) {
            return this._elementList[0].classList.contains(className);
        }
        return false;
    };
    HtmlElementQuery.prototype.toggleClass = function (className) {
        for (var i = 0; i < this._elementList.length; i++) {
            this._elementList[i].classList.toggle(className);
        }
        return this;
    };
    HtmlElementQuery.prototype.removeClass = function (className) {
        for (var i = 0; i < this._elementList.length; i++) {
            this._elementList[i].classList.remove(className);
        }
        return this;
    };
    HtmlElementQuery.prototype.getParentElementList = function () {
        if (this._elementList.length > 0) {
            var element = this._elementList[0];
            var result = new Array();
            for (var p = element && element.parentElement; p; p = p.parentElement) {
                result.push(p);
            }
            return result;
        }
        return HtmlElementQuery._emptyElementList;
    };
    HtmlElementQuery.prototype.getFirstParent = function (selector) {
        return $(this.getParent(selector).getFirstElement());
    };
    HtmlElementQuery.prototype.getParent = function (selector) {
        var parentList = new Array();
        for (var i = 0; i < this._elementList.length; i++) {
            var element = this._elementList[i];
            var p = element;
            while (p.parentElement != null) {
                parentList.push(p.parentElement);
                p = p.parentElement;
            }
        }
        var filterList = $(selector).getElementList();
        var l = new Array();
        for (var pIndex = 0; pIndex < parentList.length; pIndex++) {
            for (var i = 0; i < filterList.length; i++) {
                if (filterList[i] == parentList[pIndex]) {
                    $(filterList[i]).forEach(function (element) {
                        l.push(element);
                    });
                }
            }
        }
        return $(l);
    };
    HtmlElementQuery.prototype.remove = function () {
        for (var i = 0; i < this._elementList.length; i++) {
            this._elementList[i].remove();
        }
        return this;
    };
    HtmlElementQuery.prototype.on = function (eventType, selector, callback) {
        for (var i = 0; i < this._elementList.length; i++) {
            this.addEventListener(this._elementList[i], eventType, selector, callback);
        }
    };
    HtmlElementQuery.prototype.addEventListener = function (element, eventType, selector, callback) {
        var f = new OnEventHandler();
        f.element = element;
        f.eventType = eventType;
        f.handler = function (e) {
            var l = element.querySelectorAll(selector);
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
        if (HtmlElementQuery._onEventHandlerList.find(function (el) { return el.element == element && el.eventType == eventType; }) == null) {
            element.addEventListener(eventType, function (e) {
                this.triggerOnEventHandler(element, eventType, e);
            }.bind(this));
        }
        HtmlElementQuery._onEventHandlerList.push(f);
    };
    HtmlElementQuery.prototype.triggerOnEventHandler = function (element, eventType, e) {
        for (var i = 0; i < HtmlElementQuery._onEventHandlerList.length; i++) {
            var f = HtmlElementQuery._onEventHandlerList[i];
            if (f.element != element || f.eventType != eventType) {
                continue;
            }
            f.handler(e);
            if (e.defaultPrevented === true) {
                break;
            }
        }
    };
    HtmlElementQuery.prototype.addEventListenerToAllElement = function (eventType, callback) {
        for (var i = 0; i < this._elementList.length; i++) {
            var element = this._elementList[i];
            element.addEventListener(eventType, callback);
        }
    };
    HtmlElementQuery.prototype.resize = function (callback) {
        this.addEventListenerToAllElement("resize", callback);
    };
    HtmlElementQuery.prototype.keydown = function (callback, keyCode) {
        for (var i = 0; i < this._elementList.length; i++) {
            var element = this._elementList[i];
            element.addEventListener("keydown", function (e) {
                if (keyCode == null || e.keyCode === keyCode) {
                    callback(e);
                }
            });
        }
    };
    HtmlElementQuery.prototype.keyup = function (callback, keyCode) {
        for (var i = 0; i < this._elementList.length; i++) {
            var element = this._elementList[i];
            element.addEventListener("keyup", function (e) {
                if (e.keyCode === null || e.keyCode === keyCode) {
                    callback(e);
                }
            });
        }
    };
    HtmlElementQuery.prototype.click = function (callback) {
        this.addEventListenerToAllElement("click", callback);
    };
    HtmlElementQuery.prototype.mousedown = function (callback) {
        this.addEventListenerToAllElement("mousedown", callback);
    };
    HtmlElementQuery.prototype.mousemove = function (callback) {
        this.addEventListenerToAllElement("mousemove", callback);
    };
    HtmlElementQuery.prototype.mouseup = function (callback) {
        this.addEventListenerToAllElement("mouseup", callback);
    };
    HtmlElementQuery.prototype.mouseover = function (callback) {
        this.addEventListenerToAllElement("mouseover", callback);
    };
    HtmlElementQuery.prototype.change = function (callback) {
        this.addEventListenerToAllElement("change", callback);
    };
    HtmlElementQuery.prototype.focus = function (callback) {
        this.addEventListenerToAllElement("focus", callback);
    };
    HtmlElementQuery.prototype.blur = function (callback) {
        this.addEventListenerToAllElement("blur", callback);
    };
    HtmlElementQuery.prototype.scroll = function (callback) {
        this.addEventListenerToAllElement("scroll", callback);
    };
    HtmlElementQuery.prototype.triggerEvent = function (event) {
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
    };
    HtmlElementQuery.prototype.hide = function () {
        this.setStyle("display", "none");
        return this;
    };
    HtmlElementQuery.prototype.getElementCount = function () {
        if (this._elementList == null) {
            return 0;
        }
        return this._elementList.length;
    };
    HtmlElementQuery.prototype.getElementList = function () {
        return this._elementList;
    };
    HtmlElementQuery.prototype.getFirstElement = function () {
        if (this._elementList.length === 0) {
            return null;
        }
        return this._elementList[0];
    };
    HtmlElementQuery.prototype.getLastElement = function () {
        if (this._elementList.length === 0) {
            return null;
        }
        return this._elementList[this._elementList.length - 1];
    };
    HtmlElementQuery.prototype.getChildElementList = function () {
        var elementList = new Array();
        for (var i = 0; i < this._elementList.length; i++) {
            var element = this._elementList[i];
            for (var cIndex = 0; cIndex < element.children.length; cIndex++) {
                elementList.push(element.children[cIndex]);
            }
        }
        return elementList;
    };
    HtmlElementQuery.prototype.getSibling = function (direction) {
        var elementList = new Array();
        switch (direction) {
            case "Previous":
                for (var i = 0; i < this._elementList.length; i++) {
                    var element = this._elementList[i];
                    var nodeList = element.parentElement.children;
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
                    var element = this._elementList[i];
                    var nodeList = element.parentElement.children;
                    var isStarted = false;
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
    };
    HtmlElementQuery.prototype.getNearest = function (selector) {
        for (var i = 0; i < this._elementList.length; i++) {
            var element = this._elementList[i];
            for (var p = element && element.parentElement; p; p = p.parentElement) {
                var child = $(p).find(selector).getFirstElement();
                if (child !== null) {
                    return $(child);
                }
            }
        }
        return HtmlElementQuery._emptyHtmlElementQuery;
    };
    HtmlElementQuery.prototype.getNearestElement = function (selector) {
        for (var i = 0; i < this._elementList.length; i++) {
            var element = this._elementList[i];
            for (var p = element && element.parentElement; p; p = p.parentElement) {
                var childList = $(p).find(selector).getElementList();
                for (var cIndex = 0; cIndex < childList.length; cIndex++) {
                    if (childList[cIndex] !== element) {
                        return childList[cIndex];
                    }
                }
            }
        }
    };
    HtmlElementQuery.prototype.find = function (selector) {
        var elementList = new Array();
        for (var i = 0; i < this._elementList.length; i++) {
            var nodeList = this._elementList[i].querySelectorAll(selector);
            for (var nIndex = 0; nIndex < nodeList.length; nIndex++) {
                elementList.push(nodeList[nIndex]);
            }
        }
        return new HtmlElementQuery(elementList);
    };
    HtmlElementQuery.prototype.forEach = function (callback) {
        this._elementList.forEach(callback);
    };
    HtmlElementQuery.domContentLoaded = function (callback) {
        document.addEventListener("DOMContentLoaded", callback);
    };
    HtmlElementQuery._emptyElementList = new Array();
    HtmlElementQuery._emptyHtmlElementQuery = new HtmlElementQuery(HtmlElementQuery._emptyElementList);
    HtmlElementQuery._onEventHandlerList = new Array();
    return HtmlElementQuery;
}());
export { HtmlElementQuery };
var OnEventHandler = (function () {
    function OnEventHandler() {
    }
    return OnEventHandler;
}());
var person = (function (el) {
    return {
        set age(v) {
            el.value = v;
        },
        get age() {
            return el.value;
        }
    };
})(document.getElementById("age"));
//# sourceMappingURL=HtmlElementQuery.js.map