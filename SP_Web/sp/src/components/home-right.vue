<template>
     <div     :class="isSignIn?'home-main-right':'home-main-right-noLogIn'">
                  <div class="home-main-right-user" v-if="isSignIn">
                     <ul>
                         <li><div class="home-main-right-user-avatar">
                              <img  align="left" :src='this.avatarSrc'>
                              <span >{{this.$store.state.user.nickName}}</span>
                             </div>
                         </li>
                         <li class="home-mian-right-user-other">收藏节点</li>
                         <li class="home-mian-right-user-other"><router-link :to="{name:'new'}">创建新主题</router-link></li>
                         <li class="home-mian-right-user-other">未读提醒</li>
                     </ul>
                  </div>
                  <div class="home-main-right-login" v-if="isSignIn!=true">
                     <router-link :to="{name:'SignUp'}">立即注册</router-link>
                     <br>
                     <span @click="test">已注册用户请</span><span>&nbsp;&nbsp;<router-link :to="{name:'SignIn'}">登陆</router-link></span>
                  </div>                 
              </div>
</template>
<script>
export default {
     data(){
        return{text:'1',
        isSignIn:this.$store.state.isSignIn,
         avatarSrc:null,
         isSignOut:true,
            forums:[{
                name:"C#",route:"/"
            },{name:"JAVA",},{name:"程序员"},{name:"centos"}],
            isShow:true
        }
    },async mounted() {                
            if(this.isSignIn){
            var accessToken=this.$store.state.token.access_token;
            await this.$userManager.GetUserInfo(accessToken)
            this.avatarSrc=  await this.$userManager.GetUserAvatarAsync(this.$store.state.user.avatar,this.$store.state.token.access_token);          
        }  
    },watch:{
         
    },methods:{
        test(){
            
            alert("哈哈哈");
        }
    }
}
</script>
<style>
.home-main-right{
  width: 23%;

  height: 500px;
  float: right;; 
}
.home-main-right-noLogIn{
    width: 23%;
  background-color:white;
  height: 120px;
  float: right;; 
}
.home-main-right-user{
    width: 100%;
    height: 300px;

}
.home-main-right-user li{
    height: 70px;
    margin-bottom: 5px;
    background-color:white;
    text-align: center;
  
}
.home-main-right-user-avatar img{
  width: 70px;
  height: 70px;;
}
.home-main-right-user-avatar span{
   
    width: 100px;
    overflow:hidden;
    text-overflow:ellipsis;
    white-space:nowrap;
    word-break:keep-all;
    display:block;
    line-height: 70px;
}
.home-mian-right-user-other{
    line-height: 70px;
}
.home-mian-right-user-other a{
    text-decoration: none;
    color: black;
}
.home-mian-right-user-other a:hover{
    font-weight: bold;
}

.home-main-right-login{
    margin-top: 20px;
    width: 100%;
    height: 40px;
    text-align:center;
    line-height: 40px;
    background-color: white;
}
.home-main-right-login a{
    text-decoration: none;
     font-weight: bold;
}
.home-main-right-login  a:hover{
   color: black;
}
</style>
