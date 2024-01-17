<template>
  <div>
    <NavBar></NavBar>
    
    <div class="cat" style="display: grid; grid-template-columns: repeat(5, 1fr); gap: 20px;">
      <div v-for="product in products" :key="product.id" class="card" style="with: 60%">
        <img class="card-img-top" src="../ExampleImg.jpg" alt="Card image cap">
        <div class="card-body">
          <h5 class="card-title">{{ product.name }}</h5>
          <p class="card-text">{{ product.price }}</p>
          <button class="btn btn-primary mx-2px " @click="addToCart">
                <i class="material-icons">add_shopping_cart</i> 
            </button>
          <button class="btn btn-primary mr-20px" @click="showProduct(product.id)">
                <i class="material-icons">info</i> 
            </button>
        </div>
      </div>
    </div>

    <div class="d-flex justify-content-center" >
      <div v-if="loading" class="spinner-border text-primary" role="status">
        <span class="sr-only"></span>
      </div>
    </div>

    <Footer></Footer>
  </div>
</template>

<script>
import NavBar from './NavBar.vue';
import Footer from './Footer.vue';

export default {
  components: {
    NavBar,
    Footer,
  },
  data() {
    return {
      products: [],
      loading: false, // Agregamos la variable de carga
    };
  },
  mounted() {
    this.fetchProducts();
  },
  methods: {
    async fetchProducts() {
      try {
        this.loading = true; // Activamos el spinner al inicio de la petición
        const response = await fetch('../api/Product/GetAllProducts');
        if (!response.ok) {
          throw new Error('Error en la petición al servidor');
        }

        const data = await response.json();
        this.products = data;
      } catch (error) {
        console.error('Error en la petición:', error);
      } finally {
        this.loading = false; // Desactivamos el spinner al finalizar la petición
      }
    },
    addToCart(productId) {
      console.log(`Añadiendo al carrito el producto con ID ${productId}`);
    },
    editProduct(productId) {
      console.log(`Editando el producto con ID ${productId}`);
    },
    showProduct(productId) {
       console.log(`Mostrando detalles`);
       //this.$router.push({ name: 'ShowProduct', params: { id: productId } });
    },
  },
};
</script>


