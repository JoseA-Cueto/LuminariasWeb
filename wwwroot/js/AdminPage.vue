<template>
  <div>
    <nav class="navbar navbar-dark bg-dark d-flex p-2">
      <img src="../FAVICON.png" width="30" height="auto" alt="">
    </nav>
    <div class="container-fluid m-10">
      <ul class="nav nav-tabs">
        <li class="nav-item">
          <a class="nav-link" :class="{ active: selectedOption === 'products' }" @click="selectedOption = 'products'">Productos</a>
        </li>
        <li class="nav-item">
          <a class="nav-link" :class="{ active: selectedOption === 'categories' }" @click="selectedOption = 'categories'">Categorías</a>
        </li>
        <li class="ml-auto"> <!-- Utiliza la clase 'ml-auto' para alinear a la derecha -->
          <button v-if="selectedOption === 'products'" 
          class="btn btn-dark "  
          @click="createProduct" 
          data-bs-toggle="modal" data-bs-target="#modalcreateproduct">
          Crear Producto
        </button>
          <button v-else-if="selectedOption === 'categories'" 
          class="btn btn-dark " 
          @click="createCategory"
          data-bs-toggle="modal" data-bs-target="#modalcreateCategory">
          Crear Categoría
        </button>
        </li>
      </ul>
      <div class="modal fade" id="modalcreateproduct" data-bs-backdrop="static">
        <div class="modal-dialog modal-dialog-scrollable modal-dialog-centered">
          <div class="modal-content">
            <div class="modal-header">
              <h3>Crear un Producto</h3>
              <button class=" btn-close" data-bs-dismiss="modal"></button>
            </div>
            <div class="modal-body">
              <CreateProductPage/>
            </div>
          </div>
        </div>
      </div>
      <div class="modal fade" id="modalcreateCategory" data-bs-backdrop="static">
        <div class="modal-dialog modal-dialog-scrollable modal-dialog-centered">
          <div class="modal-content">
            <div class="modal-header">
              <h3>Crear una Categoria</h3>
              <button class=" btn-close" data-bs-dismiss="modal"></button>
            </div>
            <div class="modal-body">
              <CreateCategoryPage/>
            </div>
          </div>
        </div>
      </div>

      <div class="tab-content mt-2">
        <div v-if="selectedOption === 'products'">
          <AdminProductsPage />
        </div>
        <div v-else-if="selectedOption === 'categories'">
          <AdminCategoriesPage />
        </div>
      </div>
    </div>
  </div>
</template>


<script>
import AdminProductsPage from './AdminProductsPage.vue'
import AdminCategoriesPage from './AdminCategoriesPage.vue'
import CreateProductPage from './CreateProductPage.vue'
import CreateCategoryPage from './CreateCategoryPage.vue'

export default {
  components: {
    AdminProductsPage,
    AdminCategoriesPage,
    CreateProductPage,
    CreateCategoryPage,
  },
  data() {
    return {
      selectedOption: 'products'
    };
  }
}
</script>