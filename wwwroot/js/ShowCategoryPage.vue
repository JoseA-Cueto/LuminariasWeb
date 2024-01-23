<template>
  <div class="container">
    <div class="col-md-6">

      <h2 class="text-center mb-4">{{categoryName}}</h2>
      <div v-if="showProgressBar" class="progress">
        <div class="progress-bar progress-bar-striped progress-bar-animated" role="progressbar" 
             aria-valuenow="100" aria-valuemin="0" aria-valuemax="100" style="width: 100%"></div>
      </div>

      <form @submit.prevent="getBack" class="needs-validation" novalidate>

        <div class="form-row">
          <div class="form-group col-md-12">
            <label for="categoryName">Nombre</label>
            <input class="form-control" type="text" v-model="categoryName" readonly>
            <div class="invalid-feedback">
              El nombre es obligatorio.
            </div>
          </div>
        </div>

        <button type="submit" class="btn btn-dark form-group col-md-12">Volver</button>
        
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
    getBack() {
      this.$router.push('/admin');
    },
  },
};
</script>
