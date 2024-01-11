<template>
    <navBar></navBar>
    <Carousel></Carousel>
    <section class="Info">
        <img src="../imgInfo.png" alt="">
        <div class="infoText">
        <h1>¿Quiénes somos?</h1>

        <!--Descripcion que no tengo-->
        <p>Lorem ipsum dolor sit, amet consectetur adipisicing elit. Recusandae ad assumenda 
            vero eaque, mollitia iste ratione, iure, sunt earum dolore
            aspernatur sint obcaecati dolores numquam. Natus officiis beatae quas velit.
             Lorem ipsum dolor sit amet consectetur adipisicing elit. 
            Tempore porro assumenda repellendus, nemo et iste aspernatur inventore
             dicta quaerat magnam odio temporibus delectus 
            necessitatibus ratione velit pariatur dignissimos eos natus.
        </p>
            <!--Botonera-->
            <div class="buttons">
                <router-link to="/catalog" class="btn btn-warning" >Ir al Catálogo</router-link>

                <!--Este no va a pinchar porque la novia de ale puso 2 botones y yo solo se para que es uno solo-->
                <router-link to="/access" class="btn btn-warning" >Opciones de Administrador</router-link>
            </div>
        </div>
    </section>
    <Footer></Footer>
   
</template>

<script>

    import  Carousel  from './Carousel.vue';
    import navBar from './navBar.vue';
    import Footer from './Footer.vue'

    export default {
  
            components: {
                Carousel,
                navBar,
                Footer
             }   

    }   
</script>

<style scoped>
    .Info{
        display: flex;
        justify-content: space-evenly;
        align-items: center;
        padding: 70px;
    }
    .Info h1, p{
        color: #e6c369;
        text-shadow: 2px 2px 2px 2px ;
        
    }
    .Info img{
        max-width: 40%;
        padding: 70px;
    }
    .buttons{
        display: flex;
        justify-content: space-evenly;
        align-items: center;
    }
</style>