<template>
  <div>
    <div v-if="showSuccessAlert" class="position-fixed top-0 start-0 m-3">
      <div class="alert alert-primary" role="alert">
        Autenticación exitosa
      </div>
    </div>

    <div v-if="showErrorAlert" class="position-fixed top-0 start-0 m-3">
      <div class="alert alert-danger" role="alert">
        {{ errorMessage }}
      </div>
    </div>

    <div class="container">
      <form class="form" @submit.prevent="login">
        <h2>Iniciar sesión</h2>
        <div v-if="showProgressBar" class="progress">
          <div class="progress-bar progress-bar-striped progress-bar-animated" role="progressbar" 
               aria-valuenow="100" aria-valuemin="0" aria-valuemax="100" style="width: 100%"></div>
        </div>
        <div class="form-group">
          <input v-model="usuario" type="text" class="form-control" id="exampleInputUsername" placeholder="Usuario">
        </div>
        <div class="form-group">
          <input v-model="contrasena" type="password" class="form-control" id="exampleInputPassword1" placeholder="Contraseña">
        </div>
      
        <button type="submit" class="btn btn-primary">Acceder</button>
      </form>
    </div>
  </div>
</template>

<script>
export default {
  data() {
    return {
      usuario: '',
      contrasena: '',
      showSuccessAlert: false,
      showErrorAlert: false,
      showProgressBar: false,
      errorMessage: ''
    };
  },
  methods: {
    async login() {
      this.showProgressBar = true;
      
      const url = '../api/User/Validation';
      const data = {
        method: 'POST',
        headers: {
          'Content-Type': 'application/json'
        },
        body: JSON.stringify({ Name: this.usuario, Password: this.contrasena })
      };

      try {
        const response = await fetch(url, data);

        if (response.ok) {
          const responseData = await response.json();
          const token = responseData.token;
          localStorage.setItem('token', token); // Guardar token en localStorage
          this.showSuccessAlert = true;
          setTimeout(() => {
            this.showSuccessAlert = false;
            this.$router.push('/admin');
          }, 2000);
        } else if (response.status === 404) {
          this.errorMessage = 'El Usuario no existe';
          this.showErrorAlert = true;
          setTimeout(() => {
            this.showErrorAlert = false;
          }, 2000);
        } else {
          throw new Error('Error al autenticarse');
        }
      } catch (error) {
        console.error(error);
        this.errorMessage = 'Error al autenticarse, inténtalo de nuevo';
        this.showErrorAlert = true;
        setTimeout(() => {
          this.showErrorAlert = false;
        }, 2000);
      } finally {
        this.showProgressBar = false;
      }
    }
  }
}
</script>

<style>
.container {
  display: flex;
  justify-content: center;
  align-items: center;
  height: 100vh; 
}

.form {
  border-radius: 10px;
  box-shadow: 0px 0px 10px 5px #888888; 
  padding: 20px;
  max-width: 400px; 
  width: 100%;
}
button {
  width: 90%;
  margin-top: 10px;
}
input {
  margin-top: 10px;
}
</style>
