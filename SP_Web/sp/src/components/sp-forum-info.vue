<template>
    <div class="sp-forum-main">
        <div class="sp-forum-header">
           <div class="sp-forum-header_title">
              <div class="sp-forum-header-title-node">
                   <span style="color:#03c8ff">SP</span>
                &nbsp;
               <span>|</span>
                &nbsp;
               <span >{{this.forum.name}}</span>
              </div>
              <div class="sp-forum-header-title-nodeinfo">
                  <span>主题总数</span>
                  <span>1</span>
              </div>
           </div>
           <div class="sp-forum-header-body">
              <div style="width :100%;height:25px;"></div>
             <el-button type="primary">创建新主题</el-button>
           </div>
        </div>
        <div class="sp-forum-body">
            
            <!--分页--> 
            <div class="sp-forum-body-page">
            <ul>
                <li>1</li>
                <li>2</li>
                <li>3</li>
                <li>4</li>
                <li>5</li>
            </ul>
            
            </div>
           <div class="sp-forum-body-post-list">
                <sp-post-list></sp-post-list>    
           </div>
           <div  class="sp-forum-body-bottom" >
               <div style="width:100%; height:30px; background-color: white;"></div>
                <sp-create-post node="C#"></sp-create-post>
                
           </div>
        </div>
    </div>
</template>
<script>
export default {
    data(){
        return{
            forum:{
                name:null
            }
        }
    },watch:{
       
    },mounted() {
          this.forum.name=this.$route.params.name;
    }
}
</script>
<style>
  .sp-forum-main{
      width: 75%;
      height: 100%;
      border-radius: 5px;
     

      float: left;
  }
  .sp-forum-header{
      width: 100%;
      height: 120px;
      background-color: #001d25;
     border-radius: 5px 5px 0 0;
  }
  .sp-forum-header_title{
      margin-left: 50px;
      color: white;
      height: 50px;;
  }
  .sp-forum-header-title-node{
      float: left;
  }
  .sp-forum-header-title-nodeinfo{
      float: right;;
      margin-right: 30px;
  }
  .sp-forum-header-body{
      height: 70px;
      width: 100%;
  }
  .el-button{
      background-color: white;
      color: black;
      font-size: 18px;
      border-color: black;
      
  }
  .sp-forum-body-page{
      width: 100%;
      height: 40px;
      background-color: red;
  }
  .sp-forum-body-page li{
        float: left;
        background-color: white;
        color: black;
        border-radius: 3px;
        border: 1px solid;
        margin-left: 10px;
       margin-top: 10px;      
        width: 20px;
        height: 20px;;
  }
  .sp-forum-body-post-list{
      width: 100%;
      height: 1000px;
      background-color: aquamarine    
     
  }
 
  
</style>
