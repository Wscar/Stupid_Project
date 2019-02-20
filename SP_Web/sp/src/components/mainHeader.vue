<template>
           <div>
           <div class="header-left"></div>
           <div class="header-right" >
            <ul v-if="isSignIn!=true">
            <li><router-link :to="{name:'SignIn'}">登陆</router-link></li>
            <li><router-link :to="{name:'SignUp'}">注册</router-link></li>
            </ul>
            <ul v-if="isSignIn">
            <li><router-link :to="{name:'Home'}">首页</router-link></li>
            <li><router-link :to="{name:''}">{{this.$store.state.user.nickName}}</router-link></li>
            <li><router-link :to="{name:''}">设置</router-link></li>
            <li ><a href="" @click="SignOut">退出</a></li>
            </ul>
           </div>
          </div>
        
</template>
<script>
export default {
    data(){
       return{isSignIn:this.$store.state.isSignIn}
    }, created(){         
    },methods:{
        SignOut(){
            this.$signInManager.SignOut(this.$store.state.user.username);
            this.isSignIn=false;
            this.isSignOut=true;                  
        }
    },mounted(){
            
            if(this.$store.state.isSignIn){
              this.isShow=true;
            }
    }
}
</script>
<style>
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

