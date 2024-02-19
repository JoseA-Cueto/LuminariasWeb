<template>
<nav>
    <div class="logo">
        <img src="../FAVICON.png" alt="">
        
    </div>
    <img clas src="../TEXTO.png" alt="">
    <div class="buys">
       
         <i class="material-icons">shopping_cart</i>


         <i class="material-icons">account_balance_wallet</i>
    </div>
</nav>

</template>

<script>
export default {

}
</script>

<style scoped>
    nav{
        top: 0;
        width: 100%; 
        z-index: 1000; 
        background-color: #3d5e94;
        display: flex;
        justify-content: space-between;
        align-items: center;
        padding: 10px;
        box-shadow: 0 2px 4px rgba(0, 0, 0, 0.1);
        
    }
    .logo{
        display: flex;
        align-items: center;
    }
    .logo img{
        max-height: 50px;
        width: auto;
        padding: 5px;
    }
    img{
        max-height: 60px;
        width: auto;
       
    }
    .buys{
        color: white;
        display: flex;
        align-items: center;
    }
    .buys i{
        margin: 20px;
        cursor: pointer;

    }
</style>

