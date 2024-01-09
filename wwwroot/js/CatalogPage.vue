<template>
  <div>
    <NavBar></NavBar>
    <div>
      <table class="table table-borderless">
        <thead>
          <tr>
            <th scope="col">ID</th>
            <th scope="col">Nombre</th>
            <th scope="col">Precio</th>
            <th scope="col">Categoría</th>
            <th scope="col">Acciones</th>
          </tr>
        </thead>
        <tbody>
          <tr v-for="product in products" :key="product.id">
            <th scope="row">{{ product.id }}</th>
            <td>{{ product.title }}</td>
            <td>{{ product.price }}</td>
            <td>{{ product.category }}</td>
            <td>
              <!-- Botones no funcionales de momento(no tienen estilos por eso estan feos) -->
              <button @click="addToCart(product.id)">
                <i class="material-icons">add_shopping_cart</i> Añadir al carrito
              </button>
              <button  @click="editProduct(product.id)">
                <i class="material-icons">edit</i> Editar
              </button>
            </td>
          </tr>
        </tbody>
      </table>
      <!-- Paginacion, que no se si quitarla, no me convence -->
      <nav aria-label="...">
        <ul class="pagination">
          <li class="page-item disabled">
            <a class="page-link" href="#" tabindex="-1" aria-disabled="true">Previous</a>
          </li>
          <li class="page-item"><a class="page-link" href="#">1</a></li>
          <li class="page-item active" aria-current="page">
            <a class="page-link" href="#">2</a>
          </li>
          <li class="page-item"><a class="page-link" href="#">3</a></li>
          <li class="page-item">
            <a class="page-link" href="#">Next</a>
          </li>
        </ul>
      </nav>
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
    };
  },
  mounted() {
    this.fetchProducts();
  },
  methods: {
    // EL PINGUERO ESTÁ AQUÍ
    //DPEPDPE QUE NUNCA ESTA DE MAS DECIRLO
    async fetchProducts() {
      try {
        const response = await fetch('api/Product/GetAllProducts');// Yo creo que el error es este.
           if (!response.ok) {
            throw new Error('Error en la petición al servidor');
          }

      const data = await response.json(); // Parsea la respuesta a JSON
      this.products = data;  // Le asigna los datos al array products(creo que no se esta llenando, f)
      }     catch (error) {
       console.error('Error en la petición:', error);
    }
},
    addToCart(productId) {
      // aqui va a ir el carrito cuando esto deje de comer pinga
      console.log(`Añadiendo al carrito el producto con ID ${productId}`);
    },
    editProduct(productId) {
      // esto va a ser para editar(solo admins)(claramente lo voy a hacer cuando el metodo deje de comer pinga)
      console.log(`Editando el producto con ID ${productId}`);
    },
  },
};
</script>
