import Vue from 'vue';
import { createApp } from 'vue';
import HelloWorld from './HelloWorld.vue';
import Carousel from './Carousel.vue';
import navBar from './navBar.vue'
import HomePage from './HomePage.vue'
import Footer from './Footer.vue'

const app = createApp({
    components:{
        'hello-world': HelloWorld,
        'carousel': Carousel,
        'nav-bar': navBar,
        'home-page': HomePage,
        'footer': Footer
    }
});
app.mount('#app');