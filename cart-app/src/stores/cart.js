import { defineStore } from 'pinia'
import { ref } from 'vue'

export const useCartStore = defineStore('cart', () => {
  const cartItems = ref([])
  const lastUpdate = ref(Date.now())

  function updateCart(items) {
    cartItems.value = items
    lastUpdate.value = Date.now()
  }

  return {
    cartItems,
    lastUpdate,
    updateCart
  }
})
