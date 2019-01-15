<template>
  <div id="app">  
        <router-view></router-view>
  </div>
</template>
<script>

export default {
   data(){
     return{name:"app"}
   },created(){
        history.pushState(null, null, document.URL);
     window.addEventListener('popstate', function () {
    history.pushState(null, null, document.URL);
     });
    //  window.addEventListener("beforeunload",()=>{
    //       console.log("触发了app.vue页面中create方法"+this.$store.state.token.access_token);
    //  });
    console.log("触发了app.vue页面中create方法"+this.$store.state.token.access_token);
   }
}
</script>

<style>
li{
   list-style: none;
   text-align: center;
   margin: 0;
   padding: 0;
}
ul{
  margin: 0;
  padding: 0;
}
</style>
