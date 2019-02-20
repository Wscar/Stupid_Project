<template>       
              <div class="home-main-view">
                 <div class="home-main-area">
                    <span  :class="item.isSelect?'home-main-area-span-click':'home-main-area-span'" v-for="item in areas" :key="item.name" @click="selectAreaSpan(item)" >{{item.name}}</span>                    
                 </div>
                 <div class="home-main-forum">
                    <sp-li :title="forums"></sp-li>
                 </div>                 
                  <div class="home-mian-post-list">                     
                       <sp-post-list></sp-post-list>
                  </div>
              </div>            
</template>
<script>
export default {
      data(){
        return{text:'1',
        isSignIn:false,
         avatarSrc:null,
         isSignOut:true,
         isAreaActive:false,
            forums:[],
            areas:[]
           
        }
    },async mounted() {
            
            var result=  await  this.$postManager.GetHomeAreasAsync();          
            if(result.status==0){
               result.data.forEach(item=>{
                 this.areas.push({name:item.name,id:item.id,isSelect:false,forums:item.forumVMs})               
               }); 
              this.$store.commit("CommitAreas",result.data);         
                this.areas[0].forums.forEach(item=>{
                   this.forums.push({id:item.id,name:item.name,areaId:item.areaId});
                });
            
            }else{
               console.log(areas.msg);
            }
            //获取帖子
            var postResult= await this.$postManager.GetHomePostManager();                                    
   },methods:{
         selectAreaSpan(value){
             this.areas.forEach(item=>{
                 if(item.name==value.name){
                      item.isSelect=true;
                      this.forums=item.forums;
                 }else{
                     item.isSelect=false;
                 }
             });
             
         }
   }
}
</script>
<style>


.el-breadcrumb__item{
    font-weight: normal;
}

.home-main-view{
    width: 75%;
    height: 1000px;
    float: left;
    font-family: 微软雅黑;
    border-radius:5px;
    border:1px solid;
    background-color:white;
    border-color: white;
}
.home-main-area{
    width: 100%;
    height: 30px;
}
.home-main-area-span {
     background-color: #f5f5f5;
     border-radius: 3px;
     line-height: 30px;
     margin-right: 20px;
     font-size: 15px;
     cursor:pointer;
}
.home-main-area-span-click{
    background-color: #445;
     border-radius: 3px;
     line-height: 30px;
     margin-right: 20px;
     font-size: 15px;
     cursor:pointer;
     color: white;
}
.home-main-forum{
     width: 100%;
     height: 30px;
     background-color: #e2e2e2;
     margin-top: 10px;
}
.el-breadcrumb{
     height: 30px;
     line-height: 30px;
}
.el-breadcrumb span{
    padding-left: 5px;
}

.home-mian-post-list{
    width: 100%;
    height: 1000px;
}
</style>
