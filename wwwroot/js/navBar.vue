<template>
<nav>
    <div class="logo">
        <img src="../FAVICON.png" alt="">
        <img src="../TEXTO.png" alt="">
    </div>
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
        position: sticky;
        top: 0;
        width: 100%; 
        z-index: 1000; 
        background-color: #3d5e94;
        display: flex;
        justify-content: space-between;
        align-items: center;
        padding: 10px;
        box-shadow: 1px 1px 1px 1px;
    }
    .logo{
        display: flex;
        align-items: center;
    }
    .logo img{
        max-height: 75px;
        width: auto;
        padding: 5px;
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

