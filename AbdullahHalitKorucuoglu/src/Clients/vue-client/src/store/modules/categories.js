import { http } from '@/utils/http'

export default {
  namespaced: true,
  state: {
    list: [],
  },
  mutations: {
    setList(state, data) {
      state.list = data
    },
  },
  actions: {
    fetchList({ commit }) {
      http.get('/categories').then(({ data: categoryList }) => {
        commit('setList', categoryList.value || [])
      })
    },
  },
  getters: {
    categoryList: (state) => state.list,
  },
}
