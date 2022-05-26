import { http } from '@/utils/http'
import router from '@/router'

export default {
  namespaced: true,
  state: {
    user: null,
  },
  mutations: {
    setUser(state, data) {
      state.user = data
      router.push({ name: 'HomeView' })
    },
    logout(state) {
      state.user = null
      router.push({ name: 'LoginView' })
    },
  },
  actions: {
    register(_, userData) {
      http.post('/users/register', userData).then(() => {
        router.push({ name: 'LoginView' })
      })
    },
    login({ commit }, data) {
      http.post('users/login', data).then(({ data }) => {
        function parseJwt(token) {
          var base64Url = token.split('.')[1]
          var base64 = base64Url.replace(/-/g, '+').replace(/_/g, '/')
          var jsonPayload = decodeURIComponent(
            atob(base64)
              .split('')
              .map(function (c) {
                return '%' + ('00' + c.charCodeAt(0).toString(16)).slice(-2)
              })
              .join('')
          )
          return JSON.parse(jsonPayload)
        }
        const loginData = {
          token: data.value,
          info: parseJwt(data.value),
        }
        commit('setUser', loginData)
      })
    },
    update({ commit }, userData) {
      http.put('users', userData).then(() => {
        commit('logout')
      })
    },
    changePassword(_, userData) {
      http.put('users/password', userData).then(() => {
        router.push({ name: 'HomeView' })
      })
    },
  },
  getters: {
    isAuthenticated: (state) => state.user !== null,
    currentUserToken: (state) => state.user?.token,
    currentUser: (state) => state.user?.info,
  },
}
