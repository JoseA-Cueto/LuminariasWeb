import Vue from 'vue';
import { createApp } from 'vue';
import { createRouter, createWebHistory } from 'vue-router';

// Importa tus componentes Vue
import HelloWorld from './HelloWorld.vue';
import Carousel from './Carousel.vue';
import NavBar from './NavBar.vue'; 
import HomePage from './HomePage.vue';
import Footer from './Footer.vue';
import CardItem from './CardItem.vue';
import CatalogPage from './CatalogPage.vue';
import pruebaFetch from './pruebaFetch.vue';
import LogIn from './LogIn.vue';
import AdminPage from './AdminPage.vue'

// Crea la aplicación Vue
const app = createApp({
  components: {
    'hello-world': HelloWorld,
    'carousel': Carousel,
    'nav-bar': NavBar,
    'home-page': HomePage,
    'footer': Footer,
    'card-item': CardItem,
    'catalog-page': CatalogPage,
    'prueba-fetch': pruebaFetch,
    'log-in': LogIn,
    'admin-page': AdminPage
  }
});

// Configura Vue Router
const router = createRouter({
  history: createWebHistory(),
  routes: [
    { path: '/', component: HomePage },
    { path: '/catalog', component: CatalogPage },
    { path: '/access', component: LogIn },
    { path: '/admin', component: AdminPage }
  ]
});

app.use(router);

// Monta la aplicación en el elemento con el id 'app'
app.mount('#app');
