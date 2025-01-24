import './assets/main.css'

import { createApp } from 'vue'
import { createPinia } from 'pinia'
import App from './App.vue'

import { useCartStore } from './stores/cart'


const pinia = createPinia()

window.parent.eventBus?.subscribe('product:added-to-cart', async (product) => {
  const response = await fetch('api/cart', {
    method: 'POST',
    headers: {
      'Content-Type': 'application/json',
    },
    body: JSON.stringify(product)
  })

  const products = await response.json();
  const cartStore = useCartStore(pinia)
  cartStore.updateCart({ Items: products })
})

const app = createApp(App)

app.use(pinia)
app.mount('#app')
