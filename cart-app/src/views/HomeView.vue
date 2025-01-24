<script setup>
</script>

<template>
  <div class="home">
    <h1>Cart App - Vue 3</h1>
    <div class="content">
      <p>I am a Microfrontend developed in Vue</p>
      <p>I can have my own navigation</p>
      <p>I can have my own routes</p>
      <p>I can have my own styles</p>
      <p>I can have my own components</p>
      <p>I can have my own data</p>
      <p>I can have my own state</p>
        <!-- list the operations that I can hit -->   
        <p>I own the following BFF operations:</p>

        <ul>
            <li>GET /api/cart - Get cart items with enriched data</li>
            <li>POST /api/cart - Add a product to cart</li>
        </ul>
        
        <p>Go to Cart to run operations</p>

    </div>
  </div>
</template>
  <style scoped>
  .home {
    margin:20px;
    width: 100%;    
  }
  </style>
