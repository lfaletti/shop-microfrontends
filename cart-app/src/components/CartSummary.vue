<script setup>
import { ref, onMounted, watch } from 'vue'
import { useCartStore } from '../stores/cart'

const cartStore = useCartStore()
const products = ref([])

watch(() => cartStore.lastUpdate, () => {
  products.value = cartStore.cartItems
})

const fetchProducts = async () => {
  const response = await fetch('api/cart')
  products.value = await response.json()
}

onMounted(() => {
  fetchProducts()  
})
</script>

<template>
  <div class="cart-container">
    <div class="product-grid">
      <div v-for="product in products.items" :key="product.id" class="product-item">
        <h3>{{ product.name }}</h3>
        <p>{{ product.priceFormatted }}</p>
        <p>Estimated Delivery: {{ product.estimatedDelivery }}</p>
        <p v-if="product.giftWrappingAvailable">Gift wrapping available</p>
      </div>
    </div>

    <div class="summary-section" v-if="products.summary">
      <h2>Order Summary</h2>
      <div class="summary-details">
        <p>Subtotal: ${{ products.summary.subTotal.toFixed(2) }}</p>
        <p>Tax: ${{ products.summary.tax.toFixed(2) }}</p>
        <p>Total: ${{ products.summary.total.toFixed(2) }}</p>
        <p>Items: {{ products.summary.itemCount }}</p>
        <p v-if="products.summary.qualifiesForFreeShipping" class="free-shipping">
          Qualifies for Free Shipping!
        </p>
      </div>
    </div>
  </div>
</template>

<style scoped>
.cart-container {
  width: 100%;
}

.product-grid {
  display: grid;
  grid-template-columns: repeat(auto-fill, minmax(250px, 1fr));
  gap: 1rem;
  margin-bottom: 2rem;
}

.product-item {
  text-align: left;
  padding: 1rem;
  border: 1px solid #eee;
  border-radius: 8px;
}

.summary-section {
  border-top: 2px solid #eee;
  padding-top: 1rem;
}

.summary-details {
  text-align: right;
  max-width: 300px;
  margin-left: auto;
}

.free-shipping {
  color: #42b983;
  font-weight: bold;
}
</style>