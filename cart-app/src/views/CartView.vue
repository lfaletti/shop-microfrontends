<script setup>
import CartSummary from '../components/CartSummary.vue'
</script>

<template>
  <div class="cart">
    <h1>Your Cart:</h1>
    <CartSummary />
  </div>
</template>

<style scoped>
.cart {
  margin:20px;
  width: 100%;
}
</style>
