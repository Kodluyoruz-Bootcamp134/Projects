<template>
  <div class="list-group">
    <a
      href="#"
      @click="selectedCategory = null"
      class="list-group-item list-group-item-action"
      :class="{ active: !selectedCategory }"
    >
      Tüm Kategoriler
    </a>
    <a
      v-for="category in categoryList"
      :key="category.id"
      href="#"
      @click="selectedCategory = category.id"
      class="list-group-item list-group-item-action"
      :class="{ active: selectedCategory == category.id }"
      >{{ `${category.title} (${category.articleCount})` }}
    </a>
  </div>
</template>

<script>
import { mapGetters } from 'vuex'
export default {
  data() {
    return {
      selectedCategory: null,
    }
  },
  computed: {
    ...mapGetters({
      categoryList: 'categories/categoryList',
    }),
  },
  watch: {
    async selectedCategory(n) {
      this.$emit('selected-category', n)
    },
  },
}
</script>
