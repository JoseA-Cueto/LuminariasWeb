 <<template>
    
  <div v-if="showSuccessAlert" class="position-fixed top-0 start-0 m-3">
          <div class="alert alert-primary" role="alert">
            Producto eliminado con éxito.
          </div>
  </div>

        <div v-if="showErrorAlert" class="position-fixed top-0 start-0 m-3">
          <div class="alert alert-danger" role="alert">
            Error al eliminar el producto. Por favor, inténtalo de nuevo.
          </div>
        </div>

    <div>
      <table class="table">
        <thead>
          <tr>
            <th scope="col">ID</th>
            <th scope="col">Nombre</th>
            <th scope="col">Precio</th>
            <th scope="col">Descripción</th>
            <th scope="col">Cantidad</th>
            <th scope="col">Acciones</th>
          </tr>
        </thead>
        <tbody>
          <tr v-for="product in products" :key="product.id">
            <th scope="row">{{ product.id }}</th>
            <td>{{ product.name }}</td>
            <td>{{ product.price }}</td>
            <td>{{ product.description }}</td>
            <td>{{ product.quantity }}</td>
            <td>

            <button @click="editProduct(product.id)" class="btn btn-success">
              <i class="material-icons">edit</i>
            </button>
            <button class="btn btn-danger" @click="deleteProduct(product.id)">
              <i class="material-icons">delete</i> 
            </button>
            <button class="btn btn-primary" @click="showProduct(product.id)">
                <i class="material-icons">info</i> 
            </button>
              
            </td>
          </tr>
        </tbody>
      </table>
     
    </div>
    <div class="d-flex justify-content-center" >
      <div v-if="loading" class="spinner-border " role="status">
        <span class="sr-only"></span>
    </div>
    </div>
 
</template>

<script>


export default {
  
  data() {
    return {
      products: [],
      loading: false,
      showSuccessAlert: false,
      showErrorAlert: false,
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
      async deleteProduct(id) {
      try {
        this.loading = true; // Activamos el spinner antes de la petición
        const response = await fetch(`../api/Product/DeleteProduct/${id}`, {
          method: 'DELETE',
        });

        if (!response.ok) {
          throw new Error('Error en la petición al servidor');
        }

        this.products = this.products.filter((product) => product.id !== id);
        this.showSuccessAlert = true;
        setTimeout(() => {
          this.showSuccessAlert = false;
        }, 2000);
      } catch (error) {
        console.error('Error en la petición:', error);
        this.showErrorAlert = true;
        setTimeout(() => {
          this.showErrorAlert = false;
        }, 2000);
      } finally {
        this.loading = false; 
      }
    },
    editProduct(productId) {
       this.$router.push({ name: 'EditProduct', params: { id: productId } });
    },
    showProduct(productId) {
       this.$router.push({ name: 'ShowProduct', params: { id: productId } });
    },
  },
};
</script>


