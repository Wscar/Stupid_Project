import axios from "axios"
import apiConfig from '../config/apiConfig.js';
import store from '../store/index.js';
export default {
    //用户注册
      async SignUp(user){
          var url=apiConfig[0]["signup"];
           var registerUser={"userName":user.name,"passWord":user.password,"nickname":user.nickname}                
          var result=  await axios.post(url,registerUser,{headers:{'Content-Type': 'application/json'}})
          .then(function(response){
              var data=response.data;
              return data;
          }).catch(function(error){
              console.log("用户注册出现错误"+error)
              var msg="后端服务器错误";
              return msg;
          });
          return result;
      },     
       async SignIn(user){
             //还需要
          var signInUser={"userName":user.userName,"password":user.passWord};
          var url=apiConfig[0]["signin"];
          var result= await axios.post(url,signInUser,{headers:{'Content-Type': 'application/json'}})
          .then(function(response){
            var data=response.data;
            //保存用户的token
            SaveToken(data,user.userName);
            //同时向sotre容器提交acces_token与refresh_token
            return data;
        }).catch(function(error){
            console.log("用户注册出现错误"+error)
            var msg="后端服务器错误";
            return msg;
        });
        return result;
    },
     SignInTest(){
             store.commit("CommitToken",{access_token:"113",refresh_token:"456"});           
     },Test(){
         alert("111");
     }
}
function SaveToken(token,userName){
    var userToken=JSON.stringify(token);
    localStorage.setItem(userName,userToken);
}