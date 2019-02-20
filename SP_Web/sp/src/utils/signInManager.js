import axios from "axios";
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
           console.log(user.username);
           var singnInParam= new URLSearchParams();         
           singnInParam.append("username",user.username);
           singnInParam.append("password",user.password);
           singnInParam.append("client_id","pc");
           singnInParam.append( "client_secret","yemobai");
           singnInParam.append("grant_type","password");
           singnInParam.append("scope","offline_access profile sp_api openid");
          var url=apiConfig[0]["signin"];
          var result= await axios.post(url,singnInParam,{headers:{'Content-Type': 'application/x-www-form-urlencoded'}})
          .then(function(response){
            var data=response.data;
            var isSaveLocalStorge=true;
            //保存用户的token
            SaveToken(data,isSaveLocalStorge);
            //同时向sotre容器提交acces_token与refresh_token
            return true;;
        }).catch(function(error){
            
            console.log("用户登陆出现错误");
            console.log(error);
            var msg="后端服务器错误";
            return false;
        });
        return result;
    },
     SignInTest(){
             store.commit("CommitToken",{access_token:"113",refresh_token:"456"});           
     },Test(){
         alert("111");
     },SignOut(userName){
            localStorage.removeItem("sp_token");
            localStorage.removeItem("sp_user");
             store.commit("RemoveUser");
             var isSignOut=true;
             store.commit("CommitIsSignOutValue",isSignOut);
     },CheckSignIn(){
         if(store.state.token.access_token==""){
              //取出当前存在localStorge中的保存的token;
             var token=  localStorage.getItem("sp_token");
             if(token==null){
                 return false;
             }else{
                token=JSON.parse(token);
                var isSaveLocalStorge=false;
                SaveToken(token,isSaveLocalStorge);
                //重新赋值给store中的token;
                var user=localStorage.getItem("sp_user");
                if(user!=null){
                    user=JSON.parse(user);
                    user={userName:user.userName,id:user.sub,role:user.role,nickName:user.nickName,avatar:user.avatar};
                    store.commit("CommitUser",user);
                    var isSignIn=true;
                    store.commit("CommitIsSignInValue",isSignIn);
                    return true;
                }else{
                  return false;
                }
               
             }
              
         }else{
             return true;
         }
     }, async RefreshTokenAsync(){
          var refresh_token=store.state.token.refresh;
          var refreshTokenParams=new URLSearchParams();
          refreshTokenParams.append("grant_type", "refresh_token"),
          refreshTokenParams.append("client_id","pc"),
          refreshTokenParams.append("client_secret","yemobai"),
          refreshTokenParams.append("refresh_token",refresh_token);
          var url=apiConfig[0]["signin"];
          var result=axios.post(url,refreshTokenParams,{headers:{'Content-Type':'application/x-www-form-urlencoded'}})
          .then(response=>{
              var data=response.data;
              var isSaveLocalStorge=true;
              //保存用户的token
              SaveToken(data,isSaveLocalStorge);
              return true;
          }).catch(error=>{
              console.log("RefreshToken方法中post请求错误："+error);
              return false;
          });  
          return result;   
     }
}
function SaveToken(token,isSaveLocalStorge){

    var userToken=token;
    //把token提交到store中
    store.commit("CommitToken",{access_token:userToken.access_token,refresh_token:userToken.refresh_token,expires_in:userToken.expires_in})
    if(isSaveLocalStorge==true){
        var stringToken=JSON.stringify(token)
        localStorage.setItem("sp_token",stringToken);
    }
   
}