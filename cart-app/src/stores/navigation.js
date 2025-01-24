import { ref } from 'vue'
import { defineStore } from 'pinia'

export const useNavigationStore = defineStore('navigation', () => {
  const currentView = ref('home')
  
  function navigateTo(view) {
    currentView.value = view
  }

  return { currentView, navigateTo }
})
