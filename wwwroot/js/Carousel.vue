<template>
  <div class="d-flex justify-content-center">
    <div id="myCarousel" class="carousel slide w-75 h-auto shadow-lg  mb-5 " data-bs-ride="carousel">
      <!-- Indicadores -->
      <div class="carousel-indicators">
        <button type="button" data-bs-target="#myCarousel" data-bs-slide-to="0" class="active"></button>
        <button type="button" data-bs-target="#myCarousel" data-bs-slide-to="1"></button>
        <button type="button" data-bs-target="#myCarousel" data-bs-slide-to="2"></button>
      </div>

      <!-- Slides -->
      <div class="carousel-inner">
        <div class="carousel-item active">
          <img src="../Ilumínate.png" class="d-block w-100" alt="...">
        </div>
        <div class="carousel-item">
          <img src="../Ilumínate.png" class="d-block w-100" alt="...">
        </div>
        <div class="carousel-item">
          <img src="../Ilumínate.png" class="d-block w-100" alt="...">
        </div>
      </div>

      <!-- Controles -->
      <button class="carousel-control-prev" type="button" data-bs-target="#myCarousel" data-bs-slide="prev">
        <span class="carousel-control-prev-icon" aria-hidden="true"></span>
        <span class="visually-hidden">Anterior</span>
      </button>
      <button class="carousel-control-next" type="button" data-bs-target="#myCarousel" data-bs-slide="next">
        <span class="carousel-control-next-icon" aria-hidden="true"></span>
        <span class="visually-hidden">Siguiente</span>
      </button>
    </div>
  </div>
</template>

<script>
  import '../lib/bootstrap/dist/css/bootstrap.css';
  import '../lib/bootstrap/dist/js/bootstrap.bundle.js';

  export default {
  };
</script>

<style scoped>
  @media (max-width: 768px) {
    #myCarousel {
      width: 100%;
    }
  }
</style>
