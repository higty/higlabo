export class HigLaboFlatpickr {
    initialize() {
    }
    ReplaceMonthNav(instance) {
        const monthNav = instance.monthNav;
        if (monthNav == null) {
            return;
        }
        if (monthNav.getAttribute("higlabo-flatpickr-month-nav") == "true") {
            this.setMonthNavText(instance);
            return;
        }
        monthNav.setAttribute("higlabo-flatpickr-month-nav", "true");
        monthNav.textContent = "";
        const yearText = document.createElement("input");
        yearText.type = "text";
        yearText.inputMode = "numeric";
        yearText.className = "higlabo-flatpickr-year-text";
        yearText.addEventListener("focus", () => yearText.select());
        yearText.addEventListener("keydown", e => {
            e.stopPropagation();
            if (e.key == "Enter") {
                e.preventDefault();
                this.setFlatpickrYear(instance, yearText);
                yearText.blur();
            }
            else if (e.key == "Escape") {
                e.preventDefault();
                this.setMonthNavText(instance);
                yearText.blur();
            }
        });
        yearText.addEventListener("blur", () => {
            this.setFlatpickrYear(instance, yearText);
        });
        const monthText = document.createElement("select");
        monthText.className = "higlabo-flatpickr-month-text";
        instance.l10n.months.longhand.forEach((monthName, index) => {
            const option = document.createElement("option");
            option.value = index.toString();
            option.textContent = monthName;
            monthText.appendChild(option);
        });
        monthText.addEventListener("change", () => {
            instance.changeMonth(parseInt(monthText.value) - instance.currentMonth);
        });
        monthText.addEventListener("keydown", e => {
            e.stopPropagation();
        });
        monthNav.appendChild(this.createFlatpickrMonthNavRow("year", yearText, () => instance.changeYear(instance.currentYear - 1), () => instance.changeYear(instance.currentYear + 1)));
        monthNav.appendChild(this.createFlatpickrMonthNavRow("month", monthText, () => instance.changeMonth(-1), () => instance.changeMonth(1)));
        this.setMonthNavText(instance);
    }
    createFlatpickrMonthNavRow(rowName, textElement, previous, next) {
        const row = document.createElement("div");
        row.className = "higlabo-flatpickr-month-nav-row";
        row.setAttribute("higlabo-flatpickr-month-nav-row", rowName);
        row.appendChild(this.createFlatpickrMonthNavButton("previous", previous));
        row.appendChild(textElement);
        row.appendChild(this.createFlatpickrMonthNavButton("next", next));
        return row;
    }
    createFlatpickrMonthNavButton(direction, click) {
        const button = document.createElement("button");
        button.type = "button";
        button.className = "higlabo-flatpickr-month-nav-button";
        button.setAttribute("higlabo-flatpickr-month-nav-button", direction);
        button.innerHTML = direction == "previous" ? "<" : ">";
        button.addEventListener("click", e => {
            e.preventDefault();
            e.stopPropagation();
            click();
        });
        return button;
    }
    setFlatpickrYear(instance, yearText) {
        const year = parseInt(yearText.value.replace(/[^\d]/g, ""));
        if (isNaN(year) == true) {
            this.setMonthNavText(instance);
            return;
        }
        if (year != instance.currentYear) {
            instance.changeYear(year);
        }
        this.setMonthNavText(instance);
    }
    setMonthNavText(instance) {
        const monthNav = instance.monthNav;
        if (monthNav == null) {
            return;
        }
        const yearText = monthNav.querySelector(".higlabo-flatpickr-year-text");
        const monthText = monthNav.querySelector(".higlabo-flatpickr-month-text");
        if (yearText != null) {
            if (yearText instanceof HTMLInputElement) {
                if (document.activeElement != yearText) {
                    yearText.value = instance.currentYear.toString();
                }
            }
            else {
                yearText.textContent = instance.currentYear.toString();
            }
        }
        if (monthText != null) {
            if (monthText instanceof HTMLSelectElement) {
                monthText.value = instance.currentMonth.toString();
            }
            else {
                const monthName = instance.l10n.months.longhand[instance.currentMonth];
                monthText.textContent = monthName;
            }
        }
    }
}
//# sourceMappingURL=HigLaboFlatpickr.js.map