<template>
  <div>
    <div class="container">
      <div class="row">
        <div class="col-4 offset-4">
          <div class="card">
            <div class="card-header text-center">Sign Up</div>
            <div class="card-body">
              <div class="mb-3">
                <label class="form-label">Username</label>
                <input
                  type="text"
                  class="form-control"
                  placeholder="korucuoglu"
                  v-model="userData.username"
                />
              </div>
              <div class="mb-3">
                <label class="form-label">Email</label>
                <input
                  type="email"
                  class="form-control"
                  placeholder="info@base.com"
                  v-model="userData.email"
                />
              </div>
              <div class="mb-3">
                <label class="form-label">Password:</label>
                <input
                  type="password"
                  class="form-control"
                  placeholder="*******"
                  v-model="userData.password"
                />
              </div>
              <div class="mb-3 d-flex justify-content-end align-items-center">
                <button class="btn btn-sm btn-primary" @click="onSubmit">
                  Sign Up
                </button>
              </div>
            </div>
            <div class="card-footer text-center">
              <p>
                Already have an account?
                <router-link
                  :to="{ name: 'LoginView' }"
                  class="p-0 m-0 btn btn-link text-primary"
                  >Log In
                </router-link>
              </p>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  data() {
    return {
      userData: {
        username: '',
        email: '',
        password: '',
      },
    }
  },
  methods: {
    onSubmit() {
      this.$store.dispatch('users/register', this.userData)
    },
  },
}
</script>
