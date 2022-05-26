<template>
  <nav class="navbar navbar-expand-lg navbar-light bg-light">
    <div class="container">
      <router-link class="navbar-brand" :to="{ name: 'HomeView' }"
        >Base Project</router-link
      >
      <button class="navbar-toggler" type="button">
        <span class="navbar-toggler-icon"></span>
      </button>
      <div class="collapse navbar-collapse d-flex justify-content-between">
        <div class="navbar-nav">
          <router-link
            v-if="isAuthenticated"
            class="nav-link"
            active-class="active"
            :to="{ name: 'MyArticlesView' }"
            >My Articles</router-link
          >
        </div>
        <div class="navbar-nav" v-if="!isAuthenticated">
          <router-link class="nav-link" :to="{ name: 'LoginView' }"
            >Login</router-link
          >
        </div>
        <div class="navbar-nav" v-else>
          <ul class="navbar-nav me-0 mb-2 mb-lg-0">
            <li class="nav-item dropdown">
              <a
                class="nav-link dropdown-toggle"
                role="button"
                @click="menuOpened = !menuOpened"
                >{{ currentUser.username }}</a
              >
              <ul class="dropdown-menu" :class="{ show: menuOpened }">
                <li>
                  <router-link
                    class="dropdown-item"
                    :to="{ name: 'ProfilView' }"
                    >Profile</router-link
                  >
                </li>
                <li>
                  <router-link
                    class="dropdown-item"
                    :to="{ name: 'SecurityView' }"
                    >Account Security</router-link
                  >
                </li>
                <li>
                  <a class="dropdown-item" @click="Logout">Logout</a>
                </li>
              </ul>
            </li>
          </ul>
        </div>
      </div>
    </div>
  </nav>
</template>

<script>
import { mapGetters } from 'vuex'
export default {
  computed: {
    ...mapGetters({
      isAuthenticated: 'users/isAuthenticated',
      currentUser: 'users/currentUser',
    }),
  },

  data() {
    return {
      menuOpened: false,
    }
  },

  methods: {
    Logout() {
      this.$store.commit('users/logout')
    },
  },
}
</script>
