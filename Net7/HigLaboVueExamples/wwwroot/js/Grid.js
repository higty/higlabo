import { ref, computed } from '../lib/vue/vue.esm-browser.js';
export default {
    props: {
        data: Array,
        columns: Array,
        filterKey: String
    },
    setup(props) {
        const sortKey = ref('');
        const sortOrders = ref(props.columns.reduce((o, key) => ((o[key] = 1), o), {}));
        const filteredData = computed(() => {
            let { data, filterKey } = props;
            if (filterKey) {
                filterKey = filterKey.toLowerCase();
                data = data.filter((row) => {
                    return Object.keys(row).some((key) => {
                        return String(row[key]).toLowerCase().indexOf(filterKey) > -1;
                    });
                });
            }
            const key = sortKey.value;
            if (key) {
                const order = sortOrders.value[key];
                data = data.slice().sort((a, b) => {
                    a = a[key];
                    b = b[key];
                    return (a === b ? 0 : a > b ? 1 : -1) * order;
                });
            }
            return data;
        });
        function sortBy(key) {
            sortKey.value = key;
            sortOrders.value[key] *= -1;
        }
        function capitalize(str) {
            return str.charAt(0).toUpperCase() + str.slice(1);
        }
        return {
            sortKey,
            sortOrders,
            filteredData,
            sortBy,
            capitalize
        };
    },
    template: `
  <table v-if="filteredData.length">
    <thead>
      <tr>
        <th v-for="key in columns"
          @click="sortBy(key)"
          :class="{ active: sortKey == key }">
          {{ capitalize(key) }}
          <span class="arrow" :class="sortOrders[key] > 0 ? 'asc' : 'dsc'">
          </span>
        </th>
      </tr>
    </thead>
    <tbody>
      <tr v-for="entry in filteredData">
        <td v-for="key in columns">
          {{entry[key]}}
        </td>
      </tr>
    </tbody>
  </table>
  <p v-else>No matches found.</p>
  `
};
//# sourceMappingURL=Grid.js.map