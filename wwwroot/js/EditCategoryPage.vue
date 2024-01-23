<template>
  <div class="container">
    <div class="col-md-6">

      <div v-if="showSuccessAlert" class="position-fixed top-0 start-0 m-3">
        <div class="alert alert-primary" role="alert">
          Categoría editada con éxito.
        </div>
      </div>

      <div v-if="showErrorAlert" class="position-fixed top-0 start-0 m-3">
        <div class="alert alert-danger" role="alert">
          Error al editar la categoría. Por favor, inténtalo de nuevo.
        </div>
      </div>

      <h2 class="text-center mb-4">Editar Categoría</h2>
      <div v-if="showProgressBar" class="progress">
        <div class="progress-bar progress-bar-striped progress-bar-animated" role="progressbar" 
             aria-valuenow="100" aria-valuemin="0" aria-valuemax="100" style="width: 100%"></div>
      </div>
      
      <form @submit.prevent="updateCategory" class="needs-validation" novalidate>

        <div class="form-row">
          <div class="form-group col-md-12">
            <label for="categoryName">Nombre</label>
            <input v-model="categoryName" type="text" class="form-control" id="categoryName" required />
            <div class="invalid-feedback">
              El nombre es obligatorio.
            </div>
          </div>
        </div>

        <button type="submit" class="btn btn-dark form-group col-md-12">Editar Categoría</button>
        
      </form>
    </div>
  </div>
</template>

<script>
export default {
  props: ['id'],
  data() {
    return {
      showSuccessAlert: false,
      showErrorAlert: false,
      showProgressBar: false,
      categoryName: '',
    };
  },
  mounted() {
    this.fetchCategoryDetails();
  },
  methods: {
    async fetchCategoryDetails() {
      try {
        this.showProgressBar = true;
        const categoryId = this.$route.params.id;
        const response = await fetch(`../api/Category/GetCategoryById/${categoryId}`);
        
        if (!response.ok) {
          throw new Error('Error en la petición al servidor');
        }

        const categoryDetails = await response.json();
        this.categoryName = categoryDetails.categoryName;

        console.log('Datos que se reciben al servidor:', {
          Id: this.$route.params.id,
          CategoryName: this.categoryName,
        });

      } catch (error) {
        console.error('Error en la petición:', error);
      } finally {
        this.showProgressBar = false;
      }
    },
    async updateCategory() {
      try {
        this.showProgressBar = true;
        const categoryId = this.$route.params.id;
        const response = await fetch(`../api/Category/UpdateCategory/${categoryId}`, {
          method: 'PUT',
          headers: {
            'Content-Type': 'application/json',
          },
          body: JSON.stringify({
            Id: this.$route.params.id,
            CategoryName: this.categoryName,
          }),
        });

        if (response.ok) {
          this.showSuccessAlert = true;
          setTimeout(() => {
            this.$router.push('/admin');
          }, 2000);
        } else if (response.status === 404) {
          console.error('Categoría no encontrada.');
        } else if (response.status === 500) {
          console.error('Error interno del servidor.');
        } else {
          console.error('Error no manejado:', response.statusText);
        }
      } catch (error) {
        this.showErrorAlert = true;
        console.error('Error en la petición:', error);
      } finally {
        this.showProgressBar = false;
      }
    },
  },
};
</script>
