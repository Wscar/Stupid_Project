 import apiConfig from '../config/apiConfig.js';
 //import axios from '../config/axiosExtension.js';
 import axios from "axios";
 import store from '../store/index.js';
export default{
    async  GetHomeAreasAsync(){
        if(store.areas==null){
            var url = apiConfig[0]["getAreas"].url;
            var areas= await axios.get(url).then(response=>{          
               
                return response.data;               
           }).catch(error=>{  return {"status":-1,msg:error} });
           return areas;
        }else{
            return store.areas;
        }
        
    },Test(){
        console.log("test");
    },
         async  CreatePostAsync(post){
        var url=apiConfig[0]["createPost"];
        var authKey="Bearer "+store.state.token.access_token;
        var config={headers:{"Authorization":authKey}};
        var result= await axios.post(url,post,config)
        .then(response=>{
            return response.data;
        }).catch(error=>{
            return  {status:-1,msg:"后端服务错误"+error};
        });
        return result;
    },async GetHomePost(){
        
    }
}