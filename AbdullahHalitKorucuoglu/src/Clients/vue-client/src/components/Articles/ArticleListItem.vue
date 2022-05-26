<template>
  <div class="card mb-2">
    <div class="card-body d-flex justify-content-between gap-3">
      <div class="content">
        <router-link
          :to="{
            name: 'ArticleDetailsView',
            params: { id: item.id, public: true },
          }"
          class="card-title h5"
          >{{ item.title }}</router-link
        >
        <h6 class="card-subtitle mb-2 text-muted">{{ item.username }}</h6>
        <p class="card-text">
          {{ item.content }}
        </p>
      </div>
      <div v-if="removeButtonActive" class="buttons">
        <i
          class="fa-solid fa-trash text-danger"
          @click="deleteItem(item.id)"
        ></i>
        <!-- <button class="btn btn-sm btn-danger">Delete</button> -->
      </div>
    </div>
  </div>
</template>

<script>
import { mapGetters } from 'vuex'
export default {
  props: {
    item: {
      type: Object,
    },
    removeButtonActive: {
      type: Boolean,
      default: false,
    },
  },
  computed: {
    ...mapGetters({
      currentUser: 'users/currentUser',
    }),
  },
  methods: {
    deleteItem(id) {
      this.$store.dispatch('articles/delete', id)
    },
  },
}
</script>

<style>
.content {
  white-space: nowrap;
  flex: 0 1 auto;
  text-overflow: ellipsis;
  overflow: hidden;
  min-width: 0;
}
</style>
