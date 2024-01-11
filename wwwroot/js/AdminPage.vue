<template>
<div>
 <nav class="navbar navbar-dark bg-dark">
  
    <img src="../FAVICON.png" width="auto" height="50" alt="">
    <h3 style="color: white">Opciones de Administrador</h3>
  
  <button type="button" class="btn btn-dark">Crear Producto</button>
</nav>

    <div>
      <table class="table">
        <thead>
          <tr>
            <th scope="col">ID</th>
            <th scope="col">Nombre</th>
            <th scope="col">Precio</th>
            <th scope="col">Descripción</th>
            <th scope="col">Cantidad</th>
            <th scope="col">Acciones</th>
          </tr>
        </thead>
        <tbody>
          <tr v-for="product in products" :key="product.id">
            <th scope="row">{{ product.id }}</th>
            <td>{{ product.name }}</td>
            <td>{{ product.price }}</td>
            <td>{{ product.description }}</td>
            <td>{{ product.quantity }}</td>
            <td>

            <button class="btn btn-success" >
                <i class="material-icons">edit</i> 
            </button>
            <button class="btn btn-danger" >
                <i class="material-icons">delete</i> 
            </button>
            <button class="btn btn-primary">
                <i class="material-icons">info</i> 
            </button>
              
            </td>
          </tr>
        </tbody>
      </table>
     
    </div>
    <div class="d-flex justify-content-center" >
      <div v-if="loading" class="spinner-border " role="status">
        <span class="sr-only"></span>
    </div>
    </div>
  </div>
</template>

<script>


export default {
  
  data() {
    return {
      products: [],
      loading: false, // Agregamos la variable de carga
    };
  },
  mounted() {
    this.fetchProducts();
  },
  methods: {
    async fetchProducts() {
      try {
        this.loading = true; // Activamos el spinner al inicio de la petición
        const response = await fetch('../api/Product/GetAllProducts');
        if (!response.ok) {
          throw new Error('Error en la petición al servidor');
        }

        const data = await response.json();
        this.products = data;
      } catch (error) {
        console.error('Error en la petición:', error);
      } finally {
        this.loading = false; // Desactivamos el spinner al finalizar la petición
      }
    }
  },
};
</script>


