export default {
    props: {
        todo: Object
    },
    template: `
  <li>{{ todo.text }}</li>
  `
}
