<template>
  <AppHeader />
  <router-view />
</template>

<script>
import AppHeader from '@/components/shared/AppHeader'
export default {
  components: {
    AppHeader,
  },
}
</script>
