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
      <table class="table table-striped table-hover">
        <thead class="text-center">
          <tr>
            <th scope="col">ID</th>
            <th scope="col">Nombre</th>
            <th scope="col">Acciones</th>
          </tr>
        </thead>
        <tbody>
          <tr v-for="category in categories" :key="category.id">
            <th scope="row">{{ category.id }}</th>
            <td class="align-middle text-center" >{{ category.categoryName }}</td>
            <td class="align-middle text-center" >
              <button class="btn btn-sm btn-dark" type="button" data-bs-toggle="collapse" :data-bs-target="'#actionsCollapse' + category.id" aria-expanded="false" aria-controls="'actionsCollapse' + category.id">
                <i class="bi bi-three-dots-vertical"></i>
              </button>
              <div class="collapse" :id="'actionsCollapse' + category.id">
                <div class="d-flex justify-content-end">
                  <button @click="editCategory(category.id)" class="btn btn-sm btn-success">
                    <i class="bi bi-pencil-square"></i>
                  </button>
                  <button class="btn btn-sm btn-danger" @click="deleteCategory(category.id)">
                    <i class="bi bi-trash-fill"></i>
                  </button>
                  <button class="btn btn-sm btn-primary" @click="showCategory(category.id)">
                    <i class="bi bi-eye"></i> 
                  </button>
                </div>
              </div>
            </td>
          </tr>
        </tbody>
      </table>
    </div>

    <!-- Barra de carga -->
    <div class="progress">
      <div class="progress-bar progress-bar-striped progress-bar-animated" role="progressbar" aria-valuenow="75" aria-valuemin="0" aria-valuemax="100" style="width: 75%"></div>
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
