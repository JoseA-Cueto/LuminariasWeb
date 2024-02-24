<template>
    <nav>
      <div class="logo">
        <router-link to="/access">
        <button><img src="../FAVICON.png" alt=""></button>
      </router-link>
      </div>
      <img src="../TEXTO.png" alt="">
      <div class="buys">
        <i class="material-icons">shopping_cart</i>
        <span>{{ cartItemCount }}</span>
        <i class="material-icons">account_balance_wallet</i>
        <span>{{ totalPrice }}</span>
      </div>
    </nav>
  </template>
  
  <script>
  export default {
    data() {
      return {
        cartItemCount: 0,
        totalPrice: 0
      };
    },
    mounted() {
      this.fetchShoppingCart();
    },
    methods: {
       fetchShoppingCart() {
        try {
          const response =  fetch('../api/ShoppingCart/GetShoppingCart');
          if (!response.ok) {
            throw new Error('Error al obtener el carrito de compras');
          }
  
          const data =  response.json();
          this.cartItemCount = data.quantity;
          this.totalPrice = data.totalPrice;
        } catch (error) {
          console.error('Error al obtener el carrito de compras:', error);
        }
      }
    }
  };
  </script>
  
  <style scoped>
  nav {
    top: 0;
    width: 100%;
    z-index: 1000;
    background-color: #3d5e94;
    display: flex;
    justify-content: space-between;
    align-items: center;
    padding: 10px;
    box-shadow: 0 2px 4px rgba(0, 0, 0, 0.1);
  }
  
  .logo {
    display: flex;
    align-items: center;
  }
  
  .logo img {
    max-height: 50px;
    width: auto;
    padding: 5px;
  }
  
  img {
    max-height: 60px;
    width: auto;
  }
  
  .buys {
    color: white;
    display: flex;
    align-items: center;
  }
  
  .buys i {
    margin: 20px;
    cursor: pointer;
  }
  
  .buys span {
    margin-left: 5px;
  }
  </style>
  