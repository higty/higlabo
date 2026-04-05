window["htmx"].defineExtension("after-swap-scroll-to", {
    onEvent: function (name, evt) {

        if (name !== "htmx:afterSwap") return true;

        const container = evt.detail.target;
        if (!(container instanceof HTMLElement)) return true;

        const selector = container.dataset.scrollTo;
        if (!selector) return true;

        const target = container.querySelector(selector);
        if (!(target instanceof HTMLElement)) return true;

        const headerHeight =
            container.querySelector("thead")?.getBoundingClientRect().height ?? 0;

        const top =
            target.getBoundingClientRect().top -
            container.getBoundingClientRect().top +
            container.scrollTop -
            headerHeight;

        container.scrollTo({
            top,
            behavior: "smooth"
        });

        return true;
    }
});