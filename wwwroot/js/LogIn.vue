<template>
  <div class="container">
    <form class="form">
        <h2>Iniciar sesión</h2>
      <div class="form-group">
        <input type="email" class="form-control" id="exampleInputEmail1" aria-describedby="emailHelp" placeholder="Usuario">
      </div>
      <div class="form-group">
        <input type="password" class="form-control" id="exampleInputPassword1" placeholder="Contraseña">
      </div>
     
      <button type="submit" class="btn btn-primary">Acceder</button>
    </form>
  </div>
</template>

<script>
export default {

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
button{
    widows: 90%;
    margin-top: 10px;
}
input{
    margin-top: 10px;

}
</style>
