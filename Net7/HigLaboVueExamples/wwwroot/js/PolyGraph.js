import AxisLabel from './AxisLabel.js';
import { computed } from '../lib/vue/vue.esm-browser.js';
import { valueToPoint } from '../js/Util.js';
export default {
    components: {
        AxisLabel
    },
    props: {
        stats: Array
    },
    setup(props) {
        const points = computed(() => {
            const total = props.stats.length;
            return props.stats
                .map((stat, i) => {
                const { x, y } = valueToPoint(stat.value, i, total);
                return `${x},${y}`;
            })
                .join(' ');
        });
        return {
            points
        };
    },
    template: `
  <g>
    <polygon :points="points"></polygon>
    <circle cx="100" cy="100" r="80"></circle>
    <axis-label
      v-for="(stat, index) in stats"
      :stat="stat"
      :index="index"
      :total="stats.length"
    >
    </axis-label>
  </g>
  `
};
//# sourceMappingURL=PolyGraph.js.map