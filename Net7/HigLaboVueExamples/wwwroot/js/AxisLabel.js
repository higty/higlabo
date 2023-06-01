import { computed } from '../lib/vue/vue.esm-browser.js';
import { valueToPoint } from '../js/Util.js';
export default {
    props: {
        stat: Object,
        index: Number,
        total: Number
    },
    setup(props) {
        const point = computed(() => valueToPoint(+props.stat.value + 10, props.index, props.total));
        return {
            point
        };
    },
    template: `
  <text :x="point.x" :y="point.y">{{stat.label}}</text>
  `
};
//# sourceMappingURL=AxisLabel.js.map