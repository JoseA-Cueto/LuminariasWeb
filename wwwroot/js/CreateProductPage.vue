<template>
  <div class="container">
    
      <div class="col-md-6"> <!-- Cambié col-md-8 a col-md-6 para ocupar el 50% del ancho -->

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
          <div class="progress-bar progress-bar-striped progress-bar-animated" role="progressbar" 
               aria-valuenow="100" aria-valuemin="0" aria-valuemax="100" style="width: 100%"></div>
        </div>
        <form @submit.prevent="createProduct" class="needs-validation" novalidate>
          <div class="form-row">
            <div class="form-group col-md-12">
              <label for="productName">Nombre</label>
              <input v-model="Name" type="text" class="form-control" id="productName" required />
              <div class="invalid-feedback">
                El nombre es obligatorio.
              </div>
            </div>

            <div class="form-group col-md-12">
              <label for="productPrice">Precio</label>
              <input v-model="Price" type="text" class="form-control" id="productPrice" required />
              <div class="invalid-feedback">
                El precio es obligatorio.
              </div>
            </div>
          </div>

          <div class="form-group">
            <label for="productDescription">Descripción</label>
            <textarea v-model="Description" class="form-control" id="productDescription"></textarea>
          </div>

          <div class="form-row">
            <div class="form-group col-md-12">
              <label for="productQuantity">Cantidad</label>
              <input v-model="Quantity" type="text" class="form-control" id="productQuantity" />
            </div>

            <div class="form-group col-md-12">
              <label for="productCategoryIdInput">CategoryId</label>
              <input v-model="CategoryId" type="text" class="form-control" id="productCategoryIdInput" required />
              <div class="invalid-feedback">
                Ingresa un CategoryId válido.
              </div>
            </div>
          </div>

          <div class="form-row">
            <div class="form-group col-md-12">
              <label for="productCategoryInput">Categoría</label>
              <input v-model="Category" type="text" class="form-control" id="productCategoryInput" required />
              <div class="invalid-feedback">
                Ingresa una categoría.
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
      productData: {
        Name: '',
        Price: 0,
        Description: '',
        Quantity: 0,
        CategoryId: 0,
        Category: '',
      },
    };
  },
  methods: {
    async createProduct() {
      try {
        this.showProgressBar = true;
        // Agregamos un console.log para imprimir los datos que se están enviando
        console.log('Datos que se envían al servidor:', this.productData);

        console.log(this.productData.Name)
        const response = await fetch('../api/Product/AddProduct', {
          method: 'POST',
          headers: {
            'Content-Type': 'application/json',
          },
          body: JSON.stringify(this.productData)
          
        });
        console.log(this.productData.Name)
        if (response.ok) {
          this.showSuccessAlert = true;
          setTimeout(() => {
            this.$router.push('/admin');
          }, 2000);
        } else {
          console.error('Error al crear el producto.');
        }
      } catch (error) {
        this.showErrorAlert = true;
      }
       finally {
          this.showProgressBar = false; // Oculta la barra de progreso después de la petición
      }
    }
    
  } 
};
</script>
