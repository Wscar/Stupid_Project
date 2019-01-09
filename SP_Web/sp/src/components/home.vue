<template>
     <el-container>
         <el-header>
           <div class="header-left"></div>
           <div class="header-right" >
            <ul v-if="isSignIn!=true">
            <li><router-link :to="{name:'SignIn'}">登陆</router-link></li>
            <li><router-link :to="{name:'SignUp'}">注册</router-link></li>
            </ul>
            <ul v-if="isSignIn">
            <li><router-link :to="{name:'SignIn'}">首页</router-link></li>
            <li><router-link :to="{name:'SignUp'}">{{this.$store.state.user.nickName}}</router-link></li>
            <li><router-link :to="{name:'SignIn'}">设置</router-link></li>
            <li><router-link :to="{name:'SignIn'}">退出</router-link></li>
            </ul>
           </div>
         </el-header>
     </el-container>
   
   
</template>
<script>
export default {
      data(){
        return{text:'1',
        isSignIn:true
        }
    }
}
</script>
<style>
.el-header{
     background-color: #e2e2e2;
}
.header-left{
    width: 70%;
   
    float: left;
    height: 60px;
}
.header-right{
     width: 30%;
     float: left;
     height: 60px;
}
.header-right li{
    line-height: 60px;
    float: left;
    padding-right: 20px;
}
.header-right a{
    text-decoration: none;
     color: #757575;
}  
</style>
