<script setup>
import { useNavigationStore } from './stores/navigation'
import HomeView from './views/HomeView.vue'
import CartView from './views/CartView.vue'

const navigation = useNavigationStore()
</script>

<template>
  <div>
    <header>
      <nav>
        <a href="#" @click.prevent="navigation.navigateTo('home')">Home</a> |
        <a href="#" @click.prevent="navigation.navigateTo('cart')">Cart</a>
      </nav>
    </header>

    <component :is="navigation.currentView === 'home' ? HomeView : CartView" />
  </div>
</template>
<style>
/* Reset default margins and make app take full height */
html, body, #app {
  margin: 0;
  padding: 0;
  height: 100%;
  width: 100%;
}

#app {
  display: flex;
  flex-direction: column;
}

nav {
  padding: 1rem;
}

nav a {
  font-weight: bold;
  color: #639699;
  text-decoration: none;
}

nav a:hover {
  color: #42b983;
}
</style>
