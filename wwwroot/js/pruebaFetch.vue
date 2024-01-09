<template>
  <div>
    <h1>Lámparas</h1>
    <ul>
      <li v-for="lamp in lamps" :key="lamp.id">
        <h2>{{ lamp.name }}</h2>
        <p>{{ lamp.description }}</p>
      </li>
    </ul>
  </div>
</template>

<script>
export default {
  data() {
    return {
      lamps: [],
    };
  },
  mounted() {
    this.fetchLamps();
  },
  methods: {
    async fetchLamps() {
      try {
        const response = await fetch('Home/GetLamps');
        if (!response.ok) {
          throw new Error(`HTTP error! Status: ${response.status}`);
        }

        const data = await response.json();
        this.lamps = data;
      } catch (error) {
        console.error('Error fetching lamps:', error);
      }
    },
  },
};
</script>

<style scoped>
/* Estilos específicos del componente si es necesario */
</style>
