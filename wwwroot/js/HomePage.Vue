<template>
    <div class="body">
      <navBar></navBar>
      <nav class="navigation">
        <router-link to="/catalog" class="bnav">Ir al Catálogo</router-link>
        <a href="#about" class="bnav">¿Quiénes Somos?</a>
      </nav>
      <Carousel></Carousel>
      <section class="Info">
        <img src="../imgInfo.png" alt="">
        <div class="infoText">
          <h1 id="about">¿Quiénes somos?</h1>
          <p>
            Lorem ipsum dolor sit, amet consectetur adipisicing elit. Recusandae ad assumenda vero eaque, mollitia
            iste ratione, iure, sunt earum dolore aspernatur sint obcaecati dolores numquam. Natus officiis beatae
            quas velit. Lorem ipsum dolor sit amet consectetur adipisicing elit. Tempore porro assumenda repellendus,
            nemo et iste aspernatur inventore dicta quaerat magnam odio temporibus delectus necessitatibus ratione
            velit pariatur dignissimos eos natus.
          </p>
          <div class="buttons">
            <router-link to="/access" class="btn btn-warning">Opciones de Administrador</router-link>
          </div>
        </div>
      </section>
      <Footer></Footer>
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
     .body{
        background-image: url('../OIG1.0CB9ZzXs6xTeIr5I.jpeg');
        background-repeat: repeat;
   }
  
   .Info{
        display: flex;
        justify-content: space-evenly;
        align-items: center;
        padding: 70px;
        background-color: #fff;
        width: 70%;
        margin: auto;
    }
    .Info h1, p{
        color: #e6c369;
        text-shadow: 2px 2px 2px 2px ;
        
    }
    .Info img{
        max-width: 40%;
        padding: 10px;
    }
  
    .navigation {
      display: flex;
      justify-content: center;
      background-color: rgb(17, 17, 17);
    }
  
    .bnav {
      color: #e6c369;
      padding: 10px;
      text-decoration: none;
      font-family: Verdana, Geneva, Tahoma, sans-serif;
      box-shadow: 0 2px 4px rgba(0, 0, 0, 0.1);
    }
  
    .bnav:hover {
      color: black;
      background-color: #e6c369;
    }
  
    .buttons {
      display: flex;
      justify-content: space-evenly;
      align-items: center;
    }
  
    @media (max-width: 768px) {
      .Info {
        width: 90%;
      }
  
      .Info img {
        display: none;
      }
  
      .Info .infoText {
        padding: 20px;
      }
    }
  </style>
  
   