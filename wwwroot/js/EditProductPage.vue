<template>
  <div class="container">
    
      <div class="col-md-6"> 

        <div v-if="showSuccessAlert" class="position-fixed top-0 start-0 m-3">
          <div class="alert alert-primary" role="alert">
            Producto editado con éxito.
          </div>
        </div>

        <div v-if="showErrorAlert" class="position-fixed top-0 start-0 m-3">
          <div class="alert alert-danger" role="alert">
            Error al editar el producto. Por favor, inténtalo de nuevo.
          </div>
        </div>

        <h2 class="text-center mb-4">Editar Producto</h2>
          <div v-if="showProgressBar" class="progress">
          <div class="progress-bar progress-bar-striped progress-bar-animated" role="progressbar" 
               aria-valuenow="100" aria-valuemin="0" aria-valuemax="100" style="width: 100%"></div>
        </div>
        <form @submit.prevent="updateProduct" class="needs-validation" novalidate>

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
            <option v-for="category in categories" :key="category.id" :value="category.id">{{ category.name }}</option>
          </select>
          <div class="invalid-feedback">
            Selecciona una categoría.
          </div>
        </div>
        </div>

          <button type="submit" class="btn btn-dark form-group col-md-12">Editar Producto</button>
          
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
      productName: '',
      productPrice: '',
      productDescription: '',
      productCategory: '',
      productQuantity:'',
      categories: [
        { id: 1, name: 'Categoría 1' },
        { id: 2, name: 'Categoría 2' },
      ]
    };
  },
  mounted() {
    this.fetchProductDetails();
    },
methods: {
    async fetchProductDetails() {
      try {
        this.showProgressBar = true;

        // Obtén el productId de las rutas usando Vue Router
        const productId = this.$route.params.id;

        const response = await fetch(`../api/Product/GetProductById/${productId}`);
        if (!response.ok) {
          throw new Error('Error en la petición al servidor');
        }

        const productDetails = await response.json();
        this.productName = productDetails.name;
        this.productPrice = productDetails.price;
        this.productDescription = productDetails.description;
        this.productCategory = productDetails.category;
        this.productQuantity = productDetails.quantity;

        console.log('Datos que se reciben al servidor:', {
        Name: this.productName,
        Price: parseFloat(this.productPrice),
        Description: this.productDescription,
        Quantity: this.productQuantity,
        CategoryId: parseInt(this.productCategory),
        });

      } catch (error) {
        console.error('Error en la petición:', error);
      } finally {
        this.showProgressBar = false;
      }
    },
    async updateProduct() {
      try {
        this.showProgressBar = true;
        const productId = this.$route.params.id;
        console.log('Datos que se envían al servidor:', {
        Name: this.productName,
        Price: parseFloat(this.productPrice),
        Description: this.productDescription,
        Quantity: this.productQuantity,
        CategoryId: parseInt(this.productCategory),
        });
        const response = await fetch(`../api/Product/UpdateProduct/${productId}`, {
          method: 'PUT',
          headers: {
            'Content-Type': 'application/json',
          },
          body: JSON.stringify({
            Name: this.productName,
            Price: parseFloat(this.productPrice),
            Description: this.productDescription,
            Quantity: this.productQuantity,
            CategoryId: parseInt(this.productCategory),
          }),
        });

        if (response.ok) {
          this.showSuccessAlert = true;
          setTimeout(() => {
            this.$router.push('/admin');
          }, 2000);
        }  else if (response.status === 404) {
         console.error('Producto no encontrado.');
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
    }
    
    
}
</script>