<template>
  <div v-if="getArticle != null" class="container mt-5">
    <component
      :is="getComponent"
      :item="getArticle"
      @cancel="this.editMode = false"
      @update="Update($event)"
    />
    <a v-if="isOWner && !editMode" @click="editMode = !editMode"
      >click to edit</a
    >
  </div>
</template>

<script>
import ArticleRead from '@/components/Articles/ArticleRead'
import ArticleEdit from '@/components/Articles/ArticleEdit'
import { mapGetters } from 'vuex'
export default {
  components: {
    ArticleRead,
    ArticleEdit,
  },
  data() {
    return {
      editMode: false,
    }
  },
  computed: {
    ...mapGetters({
      currentUser: 'users/currentUser',
      getArticleById: 'articles/_getListById',
    }),
    getArticle() {
      return this.getArticleById(this.$route.params.id)
    },
    isOWner() {
      return this.getArticle.username == this.currentUser?.username
    },
    getComponent() {
      return this.editMode ? 'ArticleEdit' : 'ArticleRead'
    },
  },
  methods: {
    async Update(data) {
      await this.$store.dispatch('articles/update', data)
      this.editMode = false
    },
  },
}
</script>
