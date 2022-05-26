<template>
  <div class="container mt-5">
    <h1 class="text-center">Public Articles</h1>
    <br />
    <ArticleList :items="getPublicArticles" />
  </div>
</template>

<script>
import ArticleList from '@/components/Articles/ArticleList'
import { mapGetters } from 'vuex'
export default {
  name: 'Home',
  components: {
    ArticleList,
  },

  computed: {
    ...mapGetters({
      getPublicArticles: 'articles/getPublicArticles',
    }),
  },
}
</script>
