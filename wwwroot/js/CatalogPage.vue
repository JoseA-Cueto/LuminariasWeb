<template>
  <div>
    <navBar></navBar>
    
    <div class="container-fluid mt-3">
      <div class="row">
        <div v-for="product in products" :key="product.id" class="col-12 col-sm-6 col-md-4 col-lg-3 mb-3">
          <div class="card">
            <img class="card-img-top" :src="product.imagePath" alt="Card image cap">
            <div class="card-body">
              <h5 class="card-title">{{ product.name }}</h5>
              <p class="card-text">USD {{ product.price }}</p>
              <div class="d-flex justify-content-center">
                <button class="btn btn-primary mr-2 mx-3" @click="addToCart(product)">
                  <i class="material-icons">add_shopping_cart</i> 
                </button>
                <button class="btn btn-primary mx-3" @click="showProduct(product.id)">
                  <i class="material-icons">info</i> 
                </button>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>

    <div class="d-flex justify-content-center mt-3">
      <div v-if="loading" class="spinner-border text-primary" role="status">
        <span class="sr-only"></span>
      </div>
    </div>

    <Footer></Footer>
  </div>
</template>

<script>
import navBar from './navBar.vue';
import Footer from './Footer.vue';

export default {
  components: {
    navBar,
    Footer,
  },
  data() {
    return {
      products: [],
      loading: false,
    };
  },
  mounted() {
    this.fetchProducts();
  },
  methods: {
    async fetchProducts() {
      try {
        this.loading = true;
        const response = await fetch('../api/Product/GetAllProducts');
        if (!response.ok) {
          throw new Error('Error en la petición al servidor');
        }

        const data = await response.json();
        this.products = data;
      } catch (error) {
        console.error('Error en la petición:', error);
      } finally {
        this.loading = false;
      }
    },
    async addToCart(product) {
      const item = {
        productId: product.id,
        productName: product.name,
        price: product.price,
        quantity: 1 
      };

      try {
          const response = await fetch('../api/cart/AddToCart', {
          method: 'POST',
          headers: {
            'Content-Type': 'application/json'
          },
          body: JSON.stringify(item)
        });

        if (!response.ok) {
          throw new Error('Error al agregar el producto al carrito');
        }

        console.log('Producto agregado al carrito con éxito');
      } catch (error) {
        console.error('Error al agregar el producto al carrito:', error);
      }
    },
    
    showProduct(productId) {
       console.log(`Mostrando detalles`);
       //this.$router.push({ name: 'ShowProduct', params: { id: productId } });
    },
  },
};
</script>
