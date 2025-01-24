<template>
    <div class="user-profile">
      <div v-if="loading">Loading user data...</div>
      <div v-else-if="user" class="user-info">
        <h3>{{ user.name }}</h3>
        <div class="purchase-history">
          <h4>Recent Purchases</h4>
          <ul>
            <li v-for="purchase in recentPurchases" :key="purchase.id">
              {{ purchase.productName }} - ${{ purchase.amount }}
            </li>
          </ul>
          <div class="total">
            Total Spent: ${{ totalSpent }}
          </div>
        </div>
      </div>
    </div>
  </template>
  
  <script>
  import { onMounted } from 'vue'
  import { storeToRefs } from 'pinia'
  import { useUserStore } from '../stores/userStore'
  
  export default {
    name: 'UserProfile',
    setup() {
      const userStore = useUserStore()
      const { user, loading, recentPurchases, totalSpent } = storeToRefs(userStore)
  
      onMounted(() => {
        userStore.fetchUser()
      })
  
      return {
        user,
        loading,
        recentPurchases,
        totalSpent
      }
    }
  }
  </script>