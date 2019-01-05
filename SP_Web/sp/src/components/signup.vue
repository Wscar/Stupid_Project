<template>
    <div class="signup">
        <el-container>
            <el-header>hello</el-header>
            <el-main  style="margin : 0 auto ;width:400px;">
                <el-form ref="form" label-position="left" :model="user"  size="medium" label-width="80px">
                    <el-form-item label="账号">
                       <el-input v-model="user.name"></el-input>
                    </el-form-item>
                     <el-form-item label="昵称">
                       <el-input v-model="user.nickname"></el-input>
                    </el-form-item>
                    <el-form-item label="密码">
                       <el-input v-model="user.password"></el-input>
                    </el-form-item>
                    <el-form-item label="确认密码">
                       <el-input v-model="user.confirmPassword"></el-input>
                    </el-form-item>
                    <el-form-item style="text-align:center">
                        <el-button  size="medium" type="primary" @click="signUp">立即注册</el-button>
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
                name:"",
                password:"",
                confirmPassword:"",
                nickname:""
            }

        }
    },methods:{
       async  signUp(){
          
          var response=await  this.$signInManager.SignUp(this.user);
          console.log(response)
          if(response.status!=0){
              alert("注册失败:"+response.msg);
          }else{
              alert("注册成功");
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
}
</style>

