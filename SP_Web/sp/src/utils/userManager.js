import apiConfig from "../config/apiConfig";
import axios from 'axios'

export default {
     async GetUserAvatar(avatarName){
         var url=apiConfig[0]["imageApiUrl"]+"\\"+avatarName;
         var  imageSrc=await axios.get(url,{responseType:"blob"})
         .then(function(response){
            if(response.data.status==0){
                var blob=response.data.data;
                var src=window.URL.createObjectURL(blob);
                return src;
            }
         }).catch(function(error){
               console.log("获取用户头像出错");
         });
     }
}