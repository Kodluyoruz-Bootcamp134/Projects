<template>
  <div class="container loginPage">
    <div class="row">
      <div class="col-4 offset-4">
        <div class="card">
          <div class="card-header text-center">Log In</div>
          <div class="card-body">
            <div class="mb-3">
              <label class="form-label">Username</label>
              <input
                type="email"
                class="form-control"
                placeholder="korucuoglu"
                v-model="userData.username"
              />
            </div>
            <div class="mb-3">
              <label class="form-label">Password</label>
              <input
                type="password"
                class="form-control"
                v-model="userData.password"
                placeholder="*****"
              />
            </div>
            <div class="mb-3 d-flex justify-content-end align-items-center">
              <button @click="onSubmit" class="btn btn-sm btn-primary">
                Log In
              </button>
            </div>
          </div>
          <div class="card-footer text-center">
            <p>
              Don't have an account?
              <router-link
                :to="{ name: 'RegisterView' }"
                class="p-0 m-0 btn btn-link text-primary"
                >Sign Up
              </router-link>
            </p>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  data: () => ({
    userData: { username: '', password: '' },
  }),

  methods: {
    onSubmit() {
      this.$store.dispatch('users/login', this.userData)
    },
  },
}
</script>
