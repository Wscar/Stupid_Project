import apiConfig from "../config/apiConfig";
import axios from 'axios';
import store from "../store/index.js";
import signInManager from './signInManager.js';
export default {
     async  GetUserAvatarAsync(avatarName,token){
         var url=apiConfig[0]["imageApiUrl"]+"\\"+avatarName;
         var authKey="Bearer "+token;
         var  imageSrc=await axios.get(url,{responseType:"blob",headers:{"Authorization":authKey}})
         .then(function(response){
                
                var blob=response.data;
                var src=window.URL.createObjectURL(blob);
                return src;
            
         }).catch(function(error){
               if(error.response.status=="401"){
                   alert("登陆过期重新登陆");
                   signInManager.SignOut(true);              
               }else{
                    console.log("获取用户头像出错"+error.response.data);
               }
         });
         return imageSrc;
     },
       ChangePassWord(){
               alert("草泥马");
     },
     async GetUserInfo(access_token){
        var authKey="Bearer "+access_token;
        var url=apiConfig[0]["userInfo"]
        var user=await axios.get(url,{headers:{"Authorization":authKey}})
          .then(function(response){
               var data=response.data;
                   CommitUserInfo(data);
                   SvaeUserInfo(data);
                   return data;
          }).catch(function(error){
             console.log("GetUserInfo方法中出错"+error);
               
          })
              
          return user;;
     }
}
  function  CommitUserInfo(data){
               var user={userName:data.userName,id:data.sub,role:data.role,nickName:data.nickName,avatar:data.avatar};
                store.commit("CommitUser",user);
                
   }
   function SvaeUserInfo(data){
        var user=JSON.stringify(data);
         localStorage.setItem("sp_user",user);
   }
   
