<template>
  <div>
    <div v-if="showSuccessAlert" class="position-fixed top-0 start-0 m-3">
      <div class="alert alert-primary" role="alert">
        Autenticación exitosa
      </div>
    </div>

    <div v-if="showErrorAlert" class="position-fixed top-0 start-0 m-3">
      <div class="alert alert-danger" role="alert">
        Error al autenticarse, inténtalo de nuevo.
      </div>
    </div>

    <div class="container">
      <form class="form" @submit="login">
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
    };
  },
  methods: {
    async login(event) {
      event.preventDefault();
      this.showProgressBar = true;
      
      const url = '../api/User/GetUserById'; // Reemplaza con la URL del endpoint de autenticación en tu backend
      const data = {
        method: 'POST',
        headers: {
      'Content-Type': 'application/json'
      },
        usuario: this.usuario,
        contrasena: this.contrasena
      };

      try {
        const response = await fetch(url, {
          
          body: JSON.stringify({usuario: this.usuario, contrasena: this.contrasena })
        });

        if (response.ok) {
          const responseData = await response.json();
          const autenticacionExitosa = responseData.autenticacionExitosa; // Reemplaza con el nombre de la propiedad adecuada en la respuesta del servidor
          if (autenticacionExitosa) {
            this.showSuccessAlert = true;
            setTimeout(() => {
              this.$router.push('/admin');
            }, 2000);
          } else {
            this.showErrorAlert = true;
            setTimeout(() => {
              this.showErrorAlert = false;
            }, 2000);
          }
        } else {
          this.showErrorAlert = true;
          setTimeout(() => {
            this.showErrorAlert = false;
          }, 2000);
          console.error('Error al autenticarse.');
        }
      } catch (error) {
        this.showErrorAlert = true;
        console.error(error);
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
  widows: 90%;
  margin-top: 10px;
}
input {
  margin-top: 10px;
}
</style>