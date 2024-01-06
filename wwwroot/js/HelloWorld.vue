
<template>
    <div>
      <h1 v-show="showMessage">{{ message }}</h1>
      <button @click="toggleVisibility">Toggle Visibility</button>
    </div>
  </template>
  
  <script>
  export default {
    data() {
      return {
        message: 'Hola, Vue y .NET',
        showMessage: true,
      };
    },
    methods: {
      toggleVisibility() {
        this.showMessage = !this.showMessage;
      },
    },
  };
  </script>
  
  