<template>
  <div>
    <div v-if="showSuccessAlert" class="position-fixed top-0 start-0 m-3">
      <div class="alert alert-primary" role="alert">
        Categoria eliminada con éxito.
      </div>
    </div>

    <div v-if="showErrorAlert" class="position-fixed top-0 start-0 m-3">
      <div class="alert alert-danger" role="alert">
        Error al eliminar la Categoria. Por favor, inténtalo de nuevo.
      </div>
    </div>

    <div>
      <table class="table">
        <thead>
          <tr>
            <th scope="col">ID</th>
            <th scope="col">Nombre</th>
            <th scope="col" class="d-flex justify-content-end">Acciones</th>
          </tr>
        </thead>
        <tbody>
          <tr v-for="category in categories" :key="category.id">
            <th scope="row">{{ category.id }}</th>
            <td >{{ category.categoryName }}</td>
            <td>
              <div class="d-flex justify-content-end">
                <button @click="editCategory(category.id)" class="btn btn-success">
                  <i class="material-icons">edit</i>
                </button>
                <button class="btn btn-danger" @click="deleteCategory(category.id)">
                  <i class="material-icons">delete</i> 
                </button>
                <button class="btn btn-primary" @click="showCategory(category.id)">
                  <i class="material-icons">info</i> 
                </button>
              </div>
            </td>
          </tr>
        </tbody>
      </table>
    </div>

    <div class="d-flex justify-content-center">
      <div v-if="loading" class="spinner-border" role="status">
        <span class="sr-only"></span>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  data() {
    return {
      categories: [],
      loading: false,
      showSuccessAlert: false,
      showErrorAlert: false,
    };
  },
  mounted() {
    this.fetchCategories();
  },
  methods: {
    async fetchCategories() {
      try {
        this.loading = true;
        const response = await fetch('../api/Category/GetAllCategories');
        if (!response.ok) {
          throw new Error('Error en la petición al servidor');
        }

        const data = await response.json();
        this.categories = data;
      } catch (error) {
        console.error('Error en la petición:', error);
      } finally {
        this.loading = false;
      }
    },
    async deleteCategory(id) {
      try {
        this.loading = true;
        const response = await fetch(`../api/Category/DeleteCategory/${id}`, {
          method: 'DELETE',
        });

        if (!response.ok) {
          throw new Error('Error en la petición al servidor');
        }

        this.categories = this.categories.filter((category) => category.id !== id);
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
    editCategory(categoryId) {
      this.$router.push({ name: 'EditCategory', params: { id: categoryId } }); 
    },
    showCategory(categoryId) {
       this.$router.push({ name: 'ShowCategory', params: { id: categoryId } });
    },
  },
};
</script>
