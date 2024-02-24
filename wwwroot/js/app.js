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
import LogIn from './LogIn.vue';
import AdminPage from './AdminPage.vue';
import CreateProductPage from './CreateProductPage.vue';
import EditProductPage from './EditProductPage.vue';
import ShowProductPage from './ShowProductPage.vue';
import AdminCategoriesPage from './AdminCategoriesPage.vue';
import AdminProductsPage from './AdminProductsPage.vue';
import EditCategoryPage from './EditCategoryPage.vue';
import ShowCategoryPage from './ShowCategoryPage.vue';
import CreateCategoryPage from './CreateCategoryPage.vue';

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
    'log-in': LogIn,
    'admin-page': AdminPage,
    'create-pruduct': CreateProductPage,
    'create-category': CreateCategoryPage,
    'edit-product-page': EditProductPage,
    'show-product-page':ShowProductPage,
    'admin-products-page': AdminProductsPage,
    'edit-category-page': EditCategoryPage,
    'show-category-page': ShowCategoryPage,
  }
});

// Configura Vue Router
const router = createRouter({
  history: createWebHistory(),
  routes: [
    { path: '/', component: HomePage },
    { path: '/catalog', component: CatalogPage },
    { path: '/access', component: LogIn },
    { path: '/admin', component: AdminPage, meta: { requiresAuth: true } },
    { path: '/admin/categories', component: AdminCategoriesPage, meta: { requiresAuth: true } },
    { path: '/createproduct', component: CreateProductPage, meta: { requiresAuth: true } },
    { path: '/createcategory', component: CreateCategoryPage, meta: { requiresAuth: true } },
    { path: '/editproduct/:id', name: 'EditProduct', component: EditProductPage, props: true, meta: { requiresAuth: true } },
    { path: '/editcategory/:id', name: 'EditCategory', component: EditCategoryPage, props: true, meta: { requiresAuth: true } },
    { path: '/showproduct/:id', name: 'ShowProduct', component: ShowProductPage, props: true, meta: { requiresAuth: true } },
    { path: '/showcategory/:id', name: 'ShowCategory', component: ShowCategoryPage, props: true, meta: { requiresAuth: true } },
  ]
});

// Implementa guards de navegación para verificar la autenticación
router.beforeEach((to, from, next) => {
  const isAuthenticated = localStorage.getItem('token') !== null; // Verifica si el token está presente en localStorage

  if (to.meta.requiresAuth && !isAuthenticated) {
    next('/access'); // Si la ruta requiere autenticación y el usuario no está autenticado, redirige a la página de acceso
  } else {
    next(); // De lo contrario, permite la navegación normalmente
  }
});

app.use(router);

// Monta la aplicación en el elemento con el id 'app'
app.mount('#app');
