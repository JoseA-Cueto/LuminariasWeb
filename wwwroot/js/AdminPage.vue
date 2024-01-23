<template>
  <div>
    <nav class="navbar navbar-dark bg-dark">
      <img src="../FAVICON.png" width="auto" height="50" alt="">
      <h3 style="color: white; margin-right: 20px;">Opciones de Administrador</h3>

      <select v-model="selectedOption" class="form-select" aria-label="Default select example" style="width: 200px;">
        <option value="products">Administrar Productos</option>
        <option value="categories">Administrar Categorías</option>
      </select>

      <router-link v-if="selectedOption === 'products'" to="/createproduct" class="btn btn-dark ml-2">Crear Producto</router-link>
      <router-link v-if="selectedOption === 'categories'" to="/createcategory" class="btn btn-dark ml-2">Crear Categoría</router-link>
    </nav>

    <section>
      <AdminProductsPage v-if="selectedOption === 'products'" class="mr-2"></AdminProductsPage>
      <AdminCategoriesPage v-if="selectedOption === 'categories'" class="mr-2"></AdminCategoriesPage>
    </section>
  </div>
</template>

<script>
import AdminProductsPage from './AdminProductsPage.vue'
import AdminCategoriesPage from './AdminCategoriesPage.vue'

export default {
  components: {
    AdminProductsPage,
    AdminCategoriesPage
  },
  data() {
    return {
      selectedOption: 'products'
    };
  }
}
</script>
