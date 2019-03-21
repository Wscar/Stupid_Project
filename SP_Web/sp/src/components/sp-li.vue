<template>
    <ul class="sp-ul">
       <li  class="sp-li" v-for="item in title " :key="item.name" @click="go">
        <router-link :to="{name:'sp-forum-info',params:{name:item.name,id:item.id}}">{{item.name}} </router-link>
       </li>
    </ul>
</template>
<script>
export default {
    data(){
        return {
           isLiClick:false,
           defaultLiClass:true
        }
    },props:["title"],
    methods:{
        go(){
            
        }
    }        
}
</script>
<style>
   .sp-li{
       float: left;
       margin-left: 10px;
       line-height: 30px;  
       font-size: 14px;   
   }
   .sp-li a{
       text-decoration: none;
       color: #778087;
   }
   .sp-li a:hover{
       color: #4d5256;
       text-decoration: underline;
   }
  
   .sp-li-click{
       float: left;
       margin-left: 10px;
       line-height: 30px;  
       font-size: 14px;   
       background-color: #334;
       color: white;
   }

</style>


