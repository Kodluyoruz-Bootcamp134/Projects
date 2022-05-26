<template>
  <div class="row">
    <ArticleListItem
      v-for="item in items"
      :removeButtonActive="removeButtonActive"
      :key="item.id"
      :item="item"
    />
  </div>
</template>

<script>
import ArticleListItem from './ArticleListItem.vue'
export default {
  name: 'Home',
  components: {
    ArticleListItem,
  },

  props: ['items', 'removeButtonActive'],
}
</script>
