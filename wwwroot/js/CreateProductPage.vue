<template>
  <div class="container">
    <div class="col-md-6">
      <div v-if="showSuccessAlert" class="position-fixed top-0 start-0 m-3">
        <div class="alert alert-primary" role="alert">
          Producto creado con éxito.
        </div>
      </div>

      <div v-if="showErrorAlert" class="position-fixed top-0 start-0 m-3">
        <div class="alert alert-danger" role="alert">
          Error al crear el producto. Por favor, inténtalo de nuevo.
        </div>
      </div>

      <h2 class="text-center mb-4">Crear Nuevo Producto</h2>
      <div v-if="showProgressBar" class="progress">
        <div
          class="progress-bar progress-bar-striped progress-bar-animated"
          role="progressbar"
          aria-valuenow="100"
          aria-valuemin="0"
          aria-valuemax="100"
          style="width: 100%"
        ></div>
      </div>
      <form @submit.prevent="createProduct" class="needs-validation" novalidate>
        <div class="form-row">
          <div class="form-group col-md-12">
            <label for="productName">Nombre</label>
            <input v-model="productName" type="text" class="form-control" id="productName" required />
            <div class="invalid-feedback">
              El nombre es obligatorio.
            </div>
          </div>

          <div class="form-group col-md-12">
            <label for="productPrice">Precio</label>
            <input v-model="productPrice" type="text" class="form-control" id="productPrice" required />
            <div class="invalid-feedback">
              El precio es obligatorio.
            </div>
          </div>
        </div>

        <div class="form-group">
          <label for="productDescription">Descripción</label>
          <textarea v-model="productDescription" class="form-control" id="productDescription"></textarea>
        </div>

        <div class="form-group">
          <label for="productImage">Imagen</label>
          <input
            type="file"
            @change="handleImageUpload"
            class="form-control"
            id="productImage"
            accept="image/*"
          />
          <div class="invalid-feedback">
            Por favor, selecciona una imagen.
          </div>
        </div>

        <div class="form-row">
          <div class="form-group col-md-12">
            <label for="productQuantity">Cantidad</label>
            <input v-model="productQuantity" type="text" class="form-control" id="productQuantity" />
          </div>
        </div>

        <div class="form-row">
          <div class="form-group col-md-6">
            <label for="productCategory">Categoría</label>
            <select v-model="productCategory" class="form-control" id="productCategory" required>
              <option value="" disabled selected>Selecciona una categoría...</option>
              <option v-for="category in categories" :key="category.id" :value="category.id">{{ category.categoryName }}</option>
            </select>
            <div class="invalid-feedback">
              Selecciona una categoría.
            </div>
          </div>
        </div>

        <button type="submit" class="btn btn-dark form-group col-md-12">Crear Producto</button>
      </form>
    </div>
  </div>
</template>

<script>
export default {
  data() {
    return {
      showSuccessAlert: false,
      showErrorAlert: false,
      showProgressBar: false,
      productName: '',
      productPrice: '',
      productDescription: '',
      productCategory: '',
      productQuantity: '',
      productImage: null,
      categories: []
    };
  },
  methods: {
    async getCategories() {
      try {
        const response = await fetch('../api/Category/GetAllCategories', {
          method: 'GET',
          headers: {
            'Content-Type': 'application/json',
          },
        });

        if (response.ok) {
          const data = await response.json();
          this.categories = data;
          console.log(this.categories)
        } else {
          console.error('Error al obtener las categorías.');
        }
      } catch (error) {
        console.error('Error en la petición:', error);
      }
    },

    async createProduct() {
      try {
        this.showProgressBar = true;

        const formData = new FormData();
        formData.append('Name', this.productName);
        formData.append('Price', parseFloat(this.productPrice));
        formData.append('Description', this.productDescription);
        formData.append('Quantity', parseInt(this.productQuantity));
        formData.append('CategoryId', parseInt(this.productCategory));
        formData.append('File', this.productImage);

        const response = await fetch('../api/Product/AddProduct', {
          method: 'POST',
          body: formData,
        });

        if (response.ok) {
          this.showSuccessAlert = true;
          setTimeout(() => {
            this.$router.push('/admin');
          }, 2000);
        } else {
          this.showErrorAlert = true;
          console.error('Error al crear el producto.');
        }
      } catch (error) {
        this.showErrorAlert = true;
        console.error('Error en la petición:', error);
      } finally {
        this.showProgressBar = false;
      }
    },

    handleImageUpload(event) {
      const file = event.target.files[0];
      if (file) {
        this.productImage = file;
      }
    },
  },

  mounted() {
    this.getCategories();
  },
};
</script>
