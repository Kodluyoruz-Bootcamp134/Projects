import moment from 'moment'

export default {
  methods: {
    copy(myObject) {
      return JSON.parse(JSON.stringify(myObject))
    },
    timesFormat(time) {
      return moment(time).format('D MMM YYYY')
    },
    parseJwt(token) {
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
    },
  },
}
