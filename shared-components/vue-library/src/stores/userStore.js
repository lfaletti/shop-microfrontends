import { defineStore } from 'pinia'

export const useUserStore = defineStore('user', {
  state: () => ({
    user: null,
    loading: false
  }),
  
  getters: {
    recentPurchases: (state) => 
      state.user?.purchases
        .sort((a, b) => new Date(b.date) - new Date(a.date))
        .slice(0, 5) || [],
    
    totalSpent: (state) =>
      state.user?.purchases.reduce((sum, purchase) => sum + purchase.amount, 0) || 0
  },
  
  actions: {
    async fetchUser() {
      this.loading = true
      const response = await fetch('/api/user')
      this.user = await response.json()
      this.loading = false
    },
    
    addPurchase(purchase) {
      if (this.user) {
        this.user.purchases.push(purchase)
      }
    }
  }
})