<template>
  <div>
   
    <table class="table table-striped table-hover">
      <!-- Encabezados de la tabla -->
      <thead class="text-center">
        <tr>
          <th scope="col">
            <button class="btn btn-dark" >Imagen</button>
          </th>
          <th scope="col">
            <button class="btn btn-dark" @click="sortBy('name')">Nombre</button>
          </th>
          <th scope="col">
            <button class="btn btn-dark" @click="sortBy('price')">Precio</button>
          </th>
          <th scope="col">Descripción</th>
          <th scope="col">
            <button class="btn btn-dark" @click="sortBy('quantity')">Cantidad</button>
          </th>
          <th scope="col">Acciones</th>
        </tr>
      </thead>

      <!-- Cuerpo de la tabla -->
      <tbody>
        <tr v-for="product in paginatedProducts" :key="product.id">
          <td class="align-middle text-center" ><img :src="product.imagePath" :style="{ width: '120px' }" class="img-thumbnail border border-5" alt=""></td>
          <td class="align-middle text-center">{{ product.name }}</td>
          <td class="align-middle text-center">{{ product.price }}</td>
          <td class="align-middle text-center">{{ product.description }}</td>
          <td class="align-middle text-center">{{ product.quantity }}</td>
          <td class="align-middle text-center">
            <button class="btn btn-sm btn-dark" type="button" data-bs-toggle="collapse" :data-bs-target="'#actionsCollapse' + product.id" aria-expanded="false" aria-controls="'actionsCollapse' + product.id">
              <i class="bi bi-three-dots-vertical"></i>
            </button>
            <div class="collapse" :id="'actionsCollapse' + product.id">
              <button class="btn btn-sm btn-success" 
              @click="editProduct(product.id)">
                <i class="bi bi-pencil-square"></i>
              </button>
              <button class="btn btn-sm btn-primary" 
              @click="showProduct(product.id)"
              data-bs-toggle="modal"
               data-bs-target="#ShowProduct">
                <i class="bi bi-eye"></i>
              </button>
              <button class="btn btn-sm btn-danger" @click="deleteProduct(product.id)">
                <i class="bi bi-trash-fill"></i>
              </button>
            </div>
          </td>
        </tr>
      </tbody>
    </table>

    <!-- Barra de carga -->
    <div class="progress">
      <div class="progress-bar progress-bar-striped progress-bar-animated" role="progressbar" :style="{ width: loading ? '100%' : '0' }"></div>
    </div>

    <!-- Paginación -->
    <nav>
      <ul class="pagination justify-content-end">
        <li class="page-item" :class="{ 'disabled': currentPage === 1 }">
          <button class="page-link" @click="goToPage(currentPage - 1)" :disabled="currentPage === 1">Anterior</button>
        </li>
        <li class="page-item" v-for="page in totalPages" :key="page" :class="{ 'active': page === currentPage }">
          <button class="page-link" @click="goToPage(page)">{{ page }}</button>
        </li>
        <li class="page-item" :class="{ 'disabled': currentPage === totalPages }">
          <button class="page-link" @click="goToPage(currentPage + 1)" :disabled="currentPage === totalPages">Siguiente</button>
        </li>
      </ul>
    </nav>
  </div>
</template>

<script>
import ShowProductPage from './ShowProductPage.vue'
export default {
  components:{
    ShowProductPage
  },
  data() {
    return {
      products: [],
      loading: false,
      showSuccessAlert: false,
      showErrorAlert: false,
      searchTerm: '',
      sortByField: '',
      sortOrder: 'asc',
      currentPage: 1,
      itemsPerPage: 6,
    };
  },
   
  mounted() {
    this.fetchProducts();
  },
  computed: {
    filteredProducts() {
      return this.products.filter(product => {
        return product.name.toLowerCase().includes(this.searchTerm.toLowerCase());
      });
    },

    sortedProducts() {
      const sorted = this.products.slice().sort((a, b) => {
        if (this.sortOrder === 'asc') {
          return a[this.sortByField] > b[this.sortByField] ? 1 : -1;
        } else {
          return a[this.sortByField] < b[this.sortByField] ? 1 : -1;
        }
      });
      return sorted;
    },
    paginatedProducts() {
      const start = (this.currentPage - 1) * this.itemsPerPage;
      const end = start + this.itemsPerPage;
      return this.sortedProducts.slice(start, end);
    },
    totalPages() {
      return Math.ceil(this.sortedProducts.length / this.itemsPerPage);
    },
  },
  methods: {
    async fetchProducts() {
      try {
        this.loading = true; // Activamos la barra de carga al inicio de la petición
        const response = await fetch('../api/Product/GetAllProducts');
        if (!response.ok) {
          throw new Error('Error en la petición al servidor');
        }

        const data = await response.json();
        this.products = data;
        console.log(this.products)
      } catch (error) {
        console.error('Error en la petición:', error);
      } finally {
        this.loading = false; // Desactivamos la barra de carga al finalizar la petición
      }
    },
    async deleteProduct(id) {
      try {
        this.loading = true; // Activamos la barra de carga antes de la petición
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
    sortBy(field) {
      if (this.sortByField === field) {
        this.sortOrder = this.sortOrder === 'asc' ? 'desc' : 'asc';
      } else {
        this.sortByField = field;
        this.sortOrder = 'asc';
      }
    },
    goToPage(page) {
      if (page >= 1 && page <= this.totalPages) {
        this.currentPage = page;
      }
    },
    searchProducts() {
      this.currentPage = 1; // Reiniciar a la primera página al buscar
    },
  },
};
</script>
