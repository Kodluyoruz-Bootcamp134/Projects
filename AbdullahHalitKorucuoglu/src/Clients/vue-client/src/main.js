import { createApp } from 'vue'
import App from './App.vue'
import router from './router'
import store from './store'
import axios from 'axios'
import '@/assets/bootstrap.css'
import helperMixin from '@/mixins/helperMixin'
import Toast, { POSITION } from 'vue-toastification'
import 'vue-toastification/dist/index.css'

const app = createApp(App)
app.config.globalProperties.$http = axios
app.mixin(helperMixin)
app.use(store)
app.use(router)
app.use(Toast, {
  position: POSITION.TOP_RIGHT,
})
app.mount('#app')
