<template>
  <div class="container mt-5">
    <div class="row">
      <div class="col-3">
        <CategoryList @selected-category="selectedCategory = $event" />
      </div>
      <div class="col-9">
        <h1 class="text-center">My Articles</h1>
        <br />
        <p>
          <router-link :to="{ name: 'AddArticleView' }" class="btn btn-success">
            <i class="fas fa-plus-circle"></i> Add New Article
          </router-link>
        </p>
        <ArticleList :items="getMyArticles" :removeButtonActive="true" />
      </div>
    </div>
  </div>
</template>

<script>
import ArticleList from '@/components/Articles/ArticleList'
import CategoryList from '@/components/Categories/CategoryList'
// import ArticleService from '@/services/article'
import { mapGetters } from 'vuex'
export default {
  name: 'Home',
  components: {
    ArticleList,
    CategoryList,
  },
  data() {
    return {
      selectedCategory: null,
    }
  },

  computed: {
    ...mapGetters({
      MyArticles: 'articles/_getMyArticles',
    }),
    getMyArticles() {
      return this.MyArticles(this.selectedCategory)
    },
  },

  async mounted() {
    this.$store.dispatch('categories/fetchList')
    this.$store.dispatch('articles/fetchList')
  },
}
</script>
