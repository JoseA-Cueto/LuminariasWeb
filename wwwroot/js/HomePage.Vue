<template>
  
      <navBar></navBar>
      <Carousel></Carousel>
      <ul class="nav nav-tabs mx-5 " id="myTab" role="tablist">
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
<div class="tab-content px-5 mb-5 shadow" id="myTabContent">
  <div class="tab-pane fade show active mx-3 mt-2" id="home" role="tabpanel" aria-labelledby="home-tab">
   <p class="text-center text-break "> Lorem, ipsum dolor sit amet consectetur adipisicing elit. Quidem ratione, architecto distinctio assumenda tempore ex temporibus quos inventore non nostrum placeat dolorem animi veniam cumque molestiae praesentium fugit nam ab?
    Lorem ipsum dolor sit amet consectetur adipisicing elit. Saepe eligendi voluptatum maiores amet aliquid repellendus voluptate perferendis delectus unde quisquam iusto eveniet modi doloremque id, ullam totam itaque! Mollitia, voluptatum.
    Lorem ipsum dolor sit amet consectetur adipisicing elit. Nemo ratione optio impedit corporis quis sapiente quam ipsam iusto itaque quasi illo similique expedita harum magni, praesentium tempora quae voluptates qui?
  </p>
  </div>
  <div class="tab-pane fade grid mt-2" id="profile" role="tabpanel" aria-labelledby="profile-tab">
    <div class="row">
        <div class="col-md-6 text-center">
            <h2>Telefono</h2>
            <h3>55555555</h3>
        </div>
        <div class="col-md-6 text-center">
            <h2>Direccion</h2>
            <h3>Calle1/Calle2 y Calle 3 numero 5</h3>
        </div>
    </div>
</div>

<div class="tab-pane fade d-flex justify-content-center align-items-center mt-2" id="contact" role="tabpanel" aria-labelledby="contact-tab">
    <router-link to="/catalog">
        <button class="btn btn-primary mb-5 pb-3 mt-5">Ir al Catálogo</button>
    </router-link>
</div>

</div>


        <!--Cards-->
  <div class="card-group container-fluid pt-5 shadow  mb-5 ">
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
  
   