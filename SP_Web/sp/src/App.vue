<template>
  <div id="app">
     <el-container  v-if="isShow">
        <el-header>
       <router-view name="header"></router-view>
        </el-header> 
         <el-main >
         <div   class="home-main">
            <router-view></router-view>
            <sp-home-right></sp-home-right>
         </div>       
         </el-main>
     </el-container>
     <div  style="background-color: #e2e2e2" v-if="isShow!=true">
        <router-view ></router-view>
        </div>
  </div>
</template>
<script>
export default {
   data(){
     return{name:"app",isShow:true}
   },watch:{
       $route(to,from){
        console.log(to.path);
        //先判断,路由是否需要验证
        if((to.path.search("/signIn")!=-1)||(to.path.search('/signUp')!=-1)){
           this.isShow=false;
        }else{
           this.isShow=true;
        }    
      }    
   },created(){           
        //检查用户是否登陆
        history.pushState(null, null, document.URL);
       window.addEventListener('popstate', function () {
       history.pushState(null, null, document.URL);   
     });
      // 浏览器刷新时  
      this.$signInManager.CheckSignIn();
    console.log("触发了app.vue页面中create方法");
   },mounted(){
            //控制router-view 的显示
           if((this.$route.path.search("/signIn")!=-1)||(this.$route.path.search('/signUp')!=-1)){
              this.isShow=false;
           }
            if(this.$store.state.isSignIn){
               this.isShow=true;
            }
   },beforeDestroy(){
      this.$signInManager.SignOut(1);
   }
   
}
</script>

<style>
.el-main{
    margin-top: 10px;
    background-color: #e2e2e2;
}
.home-main{
    width:  70%;
    margin:  0 auto;
    height: 1500px;

}
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
.el-header{
     background-color: #e2e2e2 ;
     width: 100%;
}
.el-textarea__inner{
   border-color: black;
    font-size: 15px;
}
</style>
