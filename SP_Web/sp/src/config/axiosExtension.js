import axios from 'axios';
import router from 'vue-router';
axios.interceptors.request.use(
    config=> {
        console.log("这是axios里面拦截器,请求地址是"+config.url);
        return config;
    }
     
);
axios.interceptors.response.use(response=>{
 return response;   
},error=>{
    if(error.response.status=="401"){
      
    }
   return Promise.reject(error);
})
export default axios;