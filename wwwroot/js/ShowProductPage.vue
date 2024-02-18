<template>
  <div class="container">
    <div class="col-md-6">
      <h2 class="text-center mb-4">{{ productName }}</h2>
      <div v-if="showProgressBar" class="progress">
        <div class="progress-bar progress-bar-striped progress-bar-animated" role="progressbar" aria-valuenow="100" aria-valuemin="0" aria-valuemax="100" style="width: 100%"></div>
      </div>
      <form @submit.prevent="getBack" class="needs-validation" novalidate>
        <div class="form-row">
          <div class="form-group col-md-12">
            <label for="productName">Nombre</label>
            <input class="form-control" type="text" v-model="productName" readonly>
            <div class="invalid-feedback">El nombre es obligatorio.</div>
          </div>
          <div class="form-group col-md-12">
            <label for="productPrice">Precio</label>
            <input class="form-control" type="text" v-model="productPrice" readonly>
            <div class="invalid-feedback">El precio es obligatorio.</div>
          </div>
        </div>
        <div class="form-group">
          <label for="productDescription">Descripción</label>
          <input class="form-control" type="text" v-model="productDescription" readonly>
        </div>
        <div class="form-row">
          <div class="form-group col-md-12">
            <label for="productQuantity">Cantidad</label>
            <input class="form-control" type="text" v-model="productQuantity" readonly>
          </div>
        </div>
        <div class="form-row">
          <div class="form-group col-md-12">
            <label for="productCategory">Categoría</label>
            <input class="form-control" type="text" v-model="productCategory" readonly>
            <div class="invalid-feedback"></div>
          </div>
        </div>
        <div class="text-center">
          <img :style="{ width: '120px' }" :src="productImagePath" class="rounded" alt="Imagen del producto" v-if="!isEmptyOrSpaces(productImagePath)" />
        </div>
        <button type="submit" class="btn btn-dark form-group col-md-12">Volver</button>
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
      productCategoryID: 0,
      productCategory: '',
      productQuantity: '',
      productImagePath: ''
    };
  },
  mounted() {
    this.fetchProductDetails();
  },
  methods: {
    async getCategory(productCategoryID) {
      try {
        const response = await fetch(`../api/Category/GetCategoryById/${productCategoryID}`, {
          method: 'GET',
          headers: {
            'Content-Type': 'application/json',
          },
        });

        if (response.ok) {
          const data = await response.json();
          this.productCategory = data.categoryName;
          console.log(this.productCategory);
        } else {
          console.error('Error al obtener las categorías.');
        }
      } catch (error) {
        console.error('Error en la petición:', error);
      }
    },
    async fetchProductDetails() {
      try {
        this.showProgressBar = true;
        const productId = this.$route.params.id;
        const response = await fetch(`../api/Product/GetProductById/${productId}`);
        if (!response.ok) {
          throw new Error('Error en la petición al servidor');
        }
        const productDetails = await response.json();
        console.log('Detalles del producto:', productDetails);
        this.productName = productDetails.name;
        this.productPrice = productDetails.price;
        this.productDescription = productDetails.description;
        this.productQuantity = productDetails.quantity;
        this.productCategoryID = productDetails.categoryId;
        this.productImagePath = productDetails.ImagePath;
        await this.getCategory(this.productCategoryID);
      } catch (error) {
        console.error('Error en la petición:', error);
      } finally {
        this.showProgressBar = false;
      }
    },
    getBack() {
      this.$router.push('/admin');
    },
    isEmptyOrSpaces(value) {
      return value === null || value.match(/^ *$/) !== null;
    }
  }
};
</script>
