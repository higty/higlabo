window["htmx"].registerExtension("after-swap-scroll-to", {
    htmx_after_swap: function (element: Element, detail) {
        const container = detail.ctx.target;
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
