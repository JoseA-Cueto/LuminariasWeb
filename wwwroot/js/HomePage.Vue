<template>
  
      <navBar></navBar>
      <Carousel></Carousel>
      <ul class="nav nav-tabs bg-secondary" id="myTab" role="tablist">
  <li class="nav-item " role="presentation">
    <button class="nav-link active" id="home-tab" data-bs-toggle="tab" data-bs-target="#home" type="button" role="tab" aria-controls="home" aria-selected="true">¿Quienes Somos?</button>

  </li>
  <li class="nav-item" role="presentation">
    <button class="nav-link" id="profile-tab" data-bs-toggle="tab" data-bs-target="#profile" type="button" role="tab" aria-controls="profile" aria-selected="false">Contacto</button>

  </li>
  <li class="nav-item" role="presentation">
    <button class="nav-link" id="contact-tab" data-bs-toggle="tab" data-bs-target="#contact" type="button" role="tab" aria-controls="contact" aria-selected="false">Catalogo</button>

  </li>
</ul>
<div class="tab-content" id="myTabContent">
  <div class="tab-pane fade show active" id="home" role="tabpanel" aria-labelledby="home-tab">...</div>
  <div class="tab-pane fade" id="profile" role="tabpanel" aria-labelledby="profile-tab">...</div>
  <div class="tab-pane fade" id="contact" role="tabpanel" aria-labelledby="contact-tab">...</div>
</div>


        <!--Cards-->
  <div class="card-group container-fluid pt-5 shadow-lg  mb-5 ">
      <div class="card ">
        <img src="../ExampleImg.jpg" class="img-thumbnail mx-3 mt-3" alt="">
        <div class="card-body">
          <h5 class="card-title">Card title</h5>
          <p class="card-text">This is a wider card with supporting text below as a natural lead-in to additional content. This content is a little bit longer.</p>
          
        </div>
      </div>
      <div class="card px-4 pt- 3">
        <img src="../ExampleImg.jpg" class="img-thumbnail mx-3 mt-3" alt="">
        <div class="card-body">
          <h5 class="card-title">Card title</h5>
          <p class="card-text">This card has supporting text below as a natural lead-in to additional content.</p>
          
        </div>
      </div>
      <div class="card px-4 pt- 3">
        <img src="../ExampleImg.jpg" class="img-thumbnail mx-3 mt-3" alt="">
        <div class="card-body">
          <h5 class="card-title">Card title</h5>
          <p class="card-text">This is a wider card with supporting text below as a natural lead-in to additional content. This card has even longer content than the first to show that equal height action.</p>
          
        </div>
      </div>
</div>
  </template>
  
  <script>
    import Carousel from './Carousel.vue';
    import navBar from './navBar.vue';
    import Footer from './Footer.vue';
  
    export default {
      components: {
        Carousel,
        navBar,
        Footer
      }
    }
  </script>
  
  <style scoped>

  </style>
  
   