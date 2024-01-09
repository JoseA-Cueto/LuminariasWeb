<template>
  <div class="card" style="width: 18rem;">
    <img class="card-img-top" :src="product.imageUrl" alt="Product Image">
    <div class="card-body">
      <h5 class="card-title">{{ product.name }}</h5>
      <p class="card-text">{{ product.price }}</p>
      <a href="#"><i class="material-icons">shopping_cart</i></a>
    </div>
  </div>
</template>

<script>
export default {
  props: {
    productId: {
      type: Number,
      required: true,
    },
  },
  data() {
    return {
      product: {
        imageUrl: '', //aqui iría la url de la imagen, solo dios sabe como vamos a hacer eso
        name: '',
        price: 0,
      },
    };
  },
  mounted() {
    this.fetchProduct();
  },
  methods: {
    async fetchProduct() {
      try {
        const response = await fetch('Product/GetProductById/${this.productId}');
        if (!response.ok) {
          throw new Error('Error al obtener el producto');
        }
        const data = await response.json();
        this.product = data;
      } catch (error) {
        console.error(error);
      }
    },
  },
};
</script>
