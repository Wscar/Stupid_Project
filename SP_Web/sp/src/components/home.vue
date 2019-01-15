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
            <li><router-link :to="{name:''}">首页</router-link></li>
            <li><router-link :to="{name:''}">{{this.$store.state.user.nickName}}</router-link></li>
            <li><router-link :to="{name:''}">设置</router-link></li>
            <li ><a href="" @click="SignOut">退出</a></li>
            </ul>
           </div>
         </el-header>
         <el-main>
             <div class="home-main">
              <div class="home-main-view">
                  <router-view></router-view>
              </div>
              <div class="home-main-right">
                  <div class="home-main-right-user" v-if="isSignIn">
                     <ul>
                         <li><div class="home-main-right-user-avatar">
                              <img  align="left" :src='this.avatarSrc'>
                              <span >{{this.$store.state.user.nickName}}</span>
                             </div>
                         </li>
                         <li>收藏节点</li>
                         <li>创作主体</li>
                         <li>未读提醒</li>
                     </ul>
                  </div>
              </div>
             </div>
         </el-main>
     </el-container>
   
   
</template>
<script>
export default {
      data(){
        return{text:'1',
        isSignIn:false,
         avatarSrc:null,
         isSignOut:true
        }
    },async mounted() {
            
             if(this.isSignIn){
            var accessToken=this.$store.state.token.access_token;
            console.log("在Home.vue页面中accessToken的值是"+this.$store.state.token.access_token);
            await this.$userManager.GetUserInfo(accessToken)
            console.log("home.vue页面中mounted方法中avatar的值是"+this.$store.state.user.avatar)
            this.avatarSrc=  await this.$userManager.GetUserAvatarAsync(this.$store.state.user.avatar,this.$store.state.token.access_token);       
            console.log("home.vue页面中mounted方法中 this.avatarSrc的值是"+this.avatarSrc);
        
        
        }                                           
   },created(){
       
       if(this.$store.state.token.access_token!=""){
          
           this.isSignIn=true;
       }else{
           console.log("进入了home.vue的create方法里面的else语句");
             this.$signInManager.CheckSignIn();
              this.isSignIn=true;
       }
   },methods:{
        SignOut(){
            this.$signInManager.SignOut(this.$store.state.user.username);
            this.$store.commit("RemoveUser");
            this.isSignIn=false;
            this.isSignOut=true;
            this.$store.commit("CommitIsSignOutValue",this.isSignOut);
            
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
.home-main{
    width:  70%;
    margin:  0 auto;
    height: 1000px;
    background-color: red;
}
.home-main-view{
    width: 75%;
    background-color: gray;
    height: 1000px;
    float: left;
}
.home-main-right{
  width: 23%;
  background-color: aquamarine;
  height: 1000px;
  float: right;; 
}
.home-main-right-user{
    width: 100%;
    height: 300px;
    background-color: aqua
}
.home-main-right-user li{
    height: 70px;
    margin-bottom: 5px;
    background-color: blue;
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
</style>
