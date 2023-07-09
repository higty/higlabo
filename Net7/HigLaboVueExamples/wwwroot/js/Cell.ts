import { ref } from '../lib/vue/vue.esm-browser.js'
import { cells, evalCell } from './store.js'

export default {
    props: {
        c: Number,
        r: Number
    },
    setup(props) {
        const editing = ref(false)

        function update(e) {
            editing.value = false
            cells[props.c][props.r] = e.target.value.trim()
        }

        return {
            cells,
            editing,
            evalCell,
            update
        }
    },
    template: `
  <div class="cell" :title="cells[c][r]" @click="editing = true">
    <input
      v-if="editing"
      :value="cells[c][r]"
      @change="update"
      @blur="update"
      @vnode-mounted="({ el }) => el.focus()"
    >
    <span v-else>{{ evalCell(cells[c][r]) }}</span>
  </div>
  `
}
