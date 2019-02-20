<template>
    <div class="signup">
        <el-container>
            <el-header>hello</el-header>
            <el-main  style="margin : 0 auto ;width:400px;">
                <el-form ref="user" status-icon label-position="left" :model="user"  :rules="validateRules"  size="medium" label-width="80px">
                    <el-form-item label="账号" prop="name">
                       <el-input v-model="user.name"></el-input>
                    </el-form-item>
                     <el-form-item label="昵称" prop="nickname">
                       <el-input v-model="user.nickname"></el-input>
                    </el-form-item>
                    <el-form-item label="密码"  prop="pass">
                       <el-input v-model="user.password"   type="password" auto-complete="off"></el-input>
                    </el-form-item>
                    <el-form-item label="确认密码" prop="confirmPass">
                       <el-input v-model="user.confirmPassword"  type="password" ></el-input>
                    </el-form-item>
                    <el-form-item style="text-align:center">
                        <el-button  size="medium" type="primary" @click="signUp" @mouseover="confirmPasswordEvent">立即注册</el-button>
                    </el-form-item>
                </el-form>
            </el-main>
        </el-container>
    </div>
</template>
<script>
export default {
    data(){
          var validatePass = (rule, value, callback)=>{
              if(!this.user.password){
                 // console.log("value=空,valuede值是"+this.password);
                  callback(new Error('请输入密码'));
              }else{
                  // console.log("value!=空valuede值是"+value);
                  if(this.user.confirmPassword!==""){
                     // this.$refs.user.validateField(this.user.confirmPassword);

                  }
                  callback();
              }
          
          };
          var validatePass2 = (rule, value, callback)=>{
               if(!this.user.confirmPassword){
                   callback(new Error("请再次输入密码"));
               }else if(this.user.confirmPassword!=this.user.password){
                   callback(new Error("两次密码不一致"));
               }else{
                   callback();
               }
             };
        return{
            user:{
                name:'',
                password:'',
                confirmPassword:'',
                nickname:''
            },
            validateRules:{pass:[{required: true, validator: validatePass, trigger: 'blur' }],
                          confirmPass:[{ validator: validatePass2, trigger: 'blur' }],
                          name:[{required: true, message: '请输入账号', trigger: 'blur'}],
                          nickname:[{required: true, message: '亲输入昵称', trigger: 'blur'}]
                          }

        };
    },methods:{
       async  signUp(){
           
           var validateReult=false;
          this.$refs['user'].validate((valid)=>{
              if(valid){
                 //提交用户注册请求
                  validateReult=true;
              }else{
                 validateReult=false;
              }
          });
          if(validateReult){
                var response= await  this.$signInManager.SignUp(this.user);
                        console.log(response)
                        if(response.status!=0){
                            alert("注册失败:"+response);
                        }else{
                            alert("注册成功");                      }               
          }
        },
        confirmPasswordEvent(){
           
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

