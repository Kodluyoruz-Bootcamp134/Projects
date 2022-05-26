import axios from 'axios'
import store from '@/store'
import { useToast, TYPE } from 'vue-toastification'

export const http = axios.create({
  baseURL: 'http://localhost:5000',
  header: {
    'X-Application-Name': 'vue',
    'Content-Type': 'application/json',
  },
})

http.interceptors.request.use(function (config) {
  if (store.getters['users/isAuthenticated']) {
    const token = `Bearer ${store.getters['users/currentUserToken']}`
    config.headers.Authorization = token
  }
  return config
})

http.interceptors.response.use(
  function (response) {
    if (response.data.message) {
      useToast()(response.data.message, {
        type: TYPE.SUCCESS,
      })
    }

    if (response.status === 204) {
      useToast()('successful', {
        type: TYPE.SUCCESS,
      })
    }
    return response
  },
  function (error) {
    if (error.response.data.message) {
      useToast()(error.response.data.message, {
        type: TYPE.ERROR,
      })
    }

    if (error.response.status === 401) {
      if (store.getters['users/isAuthenticated']) {
        useToast()('Your session has expired. Please login again.', {
          type: TYPE.ERROR,
        })
      } else {
        useToast()('Please login.', {
          type: TYPE.ERROR,
        })
      }
      store.commit('users/logout')
    }

    return Promise.reject(error)
  }
)

// http.interceptors.response.use(function (response) {
//   if (response.data.message) {
//     useToast(response.data.message, {
//       type: response.data.isSuccessful ? TYPE.SUCCESS : TYPE.WARNING,
//     })
//   }
//   console.log('axios test', response)
//   return response
// })
