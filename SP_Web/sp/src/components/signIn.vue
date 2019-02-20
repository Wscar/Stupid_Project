<template>
    <div class="signin">
         <el-container>
             <el-header>Hello</el-header>          
               <el-main style="  margin: 0  auto;">             
                 <el-form ref="form" label-position="left" :model="user"  size="medium" label-width="80px">
                     <el-form-item label="账号">
                         <el-input v-model="user.username" ></el-input>
                     </el-form-item>
                      <el-form-item label="密码" >
                         <el-input v-model="user.password" type="password"></el-input>
                     </el-form-item>
                      <el-form-item >
                        <el-button-group>
                            <el-button  size="medium" type="primary" @click="signin">立即登陆</el-button>
                            <el-button  size="medium" type="primary" @click="go">立即注册</el-button>
                        </el-button-group>
                    </el-form-item>
                 </el-form>                         
               </el-main>                                      
         </el-container>
    </div>
</template>
<script>
export default {
    data(){
        return{
            user:{
                username:"夜莫白",
                password:"123",
            }
        }
    },methods:{
        go(){
            this.$router.push({name:"SignUp"})
        }, async signin(){
           
           
          var signInResult=  await this.$signInManager.SignIn(this.user);
          if(signInResult==true){
              this.$store.commit("CommitIsSignInValue",signInResult);
            this.$router.push({name:"Home"});
            //  this.$signInManager.SignInTest();
            // console.log(this.$store.state.token.refresh);
        }

            
        
    }
}
}
</script>
<style>
 .el-header{
     background-color: #e2e2e2;
     line-height: 60px;
     text-align: center;
     margin-top: 10px;
 }

</style>
