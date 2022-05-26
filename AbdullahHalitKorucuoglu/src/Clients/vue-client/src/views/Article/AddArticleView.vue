<template>
  <div class="container mt-5">
    <div class="card card-outline-secondary">
      <div class="card-body">
        <h3 class="text-center fw-bolder">Add New Article</h3>
        <div class="form-group mt-3 p-2">
          <label class="form-label fw-bolder">Title</label>
          <input
            class="form-control"
            required="required"
            type="text"
            v-model="userData.title"
          />
        </div>
        <div class="form-group mt-3 p-2">
          <label class="form-label fw-bolder">Content</label>
          <textarea
            cols="3"
            rows="3"
            class="form-control"
            required="required"
            type="text"
            v-model="userData.content"
          />
        </div>
        <div class="form-group mt-3 p-2">
          <label class="form-label fw-bolder">Category</label>
          <select class="form-control" v-model="userData.categoryId">
            <option disabled>Please select one category</option>
            <option
              v-for="category in categoryList"
              :key="category.id"
              :value="category.id"
            >
              {{ category.title }}
            </option>
          </select>
        </div>
        <div class="form-group mt-3 p-2">
          <label class="form-label fw-bolder">Is Public</label>
          <input
            class="form-check-input"
            type="checkbox"
            v-model="userData.isPublic"
            id="flexCheckDefault"
          />
        </div>
        <button class="btn btn-primary" @click="onSave">Submit</button>
      </div>
    </div>
  </div>
</template>

<script>
import { mapGetters } from 'vuex'
export default {
  computed: {
    ...mapGetters({
      categoryList: 'categories/categoryList',
    }),
  },

  data() {
    return {
      userData: {
        title: null,
        content: null,
        categoryId: null,
        isPublic: true,
      },
    }
  },

  methods: {
    onSave() {
      this.$store.dispatch('articles/addItem', this.userData)
    },
  },
}
</script>
