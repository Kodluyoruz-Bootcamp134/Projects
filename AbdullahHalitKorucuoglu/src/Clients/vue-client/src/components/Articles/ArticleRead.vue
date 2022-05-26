<template>
  <h1 class="text-center text-capitalize">{{ item.title }}</h1>
  <br />
  <div class="row">
    <div class="col-10 offset-1">
      <p class="lead lh-lg">{{ item.content }}</p>
      <p class="h5 text-end">
        written by {{ item.username }} at
        {{ this.timesFormat(item.createdDate) }}
      </p>
    </div>
  </div>
</template>

<script>
export default {
  props: ['item'],
}
</script>
