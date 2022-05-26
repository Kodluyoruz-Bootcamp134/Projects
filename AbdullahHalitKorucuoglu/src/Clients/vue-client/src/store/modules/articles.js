import { http } from '@/utils/http'
import router from '@/router'

export default {
  namespaced: true,
  state: {
    list: [],
  },
  mutations: {
    setList(state, data) {
      state.list = data
    },
    addItem(state, data) {
      state.list.push(data)
    },
    deleteItem(state, id) {
      if (state.list.some((x) => x.id == id)) {
        state.list = state.list.filter((x) => x.id != id)
      }
    },
  },
  actions: {
    fetchList({ commit }) {
      http.get('/articles').then(({ data: articleList }) => {
        commit('setList', articleList.value || [])
      })
    },
    addItem({ commit, rootGetters }, userData) {
      http.post('/articles', userData).then(({ data }) => {
        const article = {
          ...userData,
          id: data.value,
          createdDate: new Date(),
          username: rootGetters['users/currentUser']?.username,
        }
        commit('addItem', article)
        router.push({ name: 'ArticleDetailsView', params: { id: article.id } })
      })
    },
    update({ commit }, userData) {
      http.put('/articles', userData).then(() => {
        commit('deleteItem', userData.id)
        commit('addItem', userData)
      })
    },
    delete({ commit }, id) {
      http.delete(`articles/${id}`).then(() => {
        commit('deleteItem', id)
      })
    },
  },
  getters: {
    _getMyArticles:
      (state, getters, rootState, rootGetters) => (categoryId) => {
        const userName = rootGetters['users/currentUser']?.username
        if (categoryId) {
          return state.list.filter(
            (item) =>
              item.categoryId === categoryId && item.username == userName
          )
        }
        return state.list.filter((item) => item.username == userName)
      },
    _getListById: (state) => (id) => {
      return state.list.find((item) => item.id === id)
    },
    getPublicArticles: (state) => {
      return state.list.filter((item) => item.isPublic === true)
    },
  },
}
