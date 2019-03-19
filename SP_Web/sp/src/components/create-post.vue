<template>
    <div  v-bind:class="isShow?'sp-create-post2':'sp-create-post'">
        <div class="sp-cretate-post-header" v-if="isShow">
            <span>SP</span>
             <span>|</span>
             <span>创建一个新主题</span>
        </div>
        <div class="sp-create-post-sub">
             <el-input
                    type="textarea"
                    :autosize="{ minRows: 1, maxRows: 2}"
                    placeholder="请输入内容主题"
                    size="medium"
                    v-model="subject"
                    >
                    </el-input>
        </div>
        <div class="sp-create-post-context">
            <el-input
                    type="textarea"
                    v-model="postContext"
                    :autosize="{ minRows: 4, maxRows: 6}"
                    placeholder="请输入内容主题"
                    size="medium"                  
                    >
                    </el-input>
        </div>
        <div class="sp-create-post-submit">
                     <el-button type="primary"  @click="commitPost" >创建新主题</el-button>
                </div>
        <div class="sp-create-post-node">
          <el-select  
            placeholder="请选择板块" v-model="areaId" @change="selectAreaDropList" >
            <el-option
            v-for="item in fatherNode"
            :key="item.id"
            :label="item.name"
            :value="item.id">
            </el-option>
          </el-select>
          <el-select   v-model="forumId" @change="selectForumDropList"
            placeholder="请选择节点" >
            <el-option
            v-for="item in childNode"
            :key="item.id"
            :label="item.name"
            :value="item.id">
            </el-option>
          </el-select>
        </div>
    </div>
</template>
<script>
export default {
    data(){
        return{name:"123", isShow:true,value:null,
        fatherNode:[],
        childNode:[],
        area:null,
        forum:null,
        areaId:null,
        forumId:null,
        subject:null,
        postContext:null
        }
    },props:{
        fNode:String,
        node:String
    }, async mounted(){
        if(this.node!=null){
            this.isShow=false;
            alert(isShow);
        }else{
            this.isShow=true;
            if(this.$store.state.areas.length>0){    
                    this.$store.state.areas.forEach(item=>{
              this.fatherNode.push({id:item.id,name:item.name});        
            });        
            }else{
                console.log("this.$store.state.areas.length<0");
                var areas=await this.$postManager.GetHomeAreasAsync();
                console.log(areas);
                if(areas.status==0){                
                  this.$store.commit("CommitAreas",areas.data);            
                      this.$store.state.areas.forEach(item=>{
             this.fatherNode.push({id:item.id,name:item.name});      
              //重新请求后端的数据
            });
                }
                
           }
        
        }
    },methods:{
       selectAreaDropList(value){            
            this.$store.state.areas.forEach(item=>{
               if(item.id==value){            
                   this.childNode=item.forums;                
               }
            });
        },selectForumDropList(value){      
                this.childNode.forEach(item=>{
                    if(item.id==value){
                       this.forum=item;
                    }
                });
        },async commitPost(){          
            if(this.subject==null||this.postContext==null){
                alert("请输入主题或者内容")
                return;
            }else{
                var forumId=null;
                if(this.node!=null){
                    forumId=node;
                }else{
                    if(this.areaId!=null&&this.forumId!=null){
                        forumId=this.forumId;
                    }
                }
                var userId=this.$store.state.user.id;
                var post=this.BuildPostData(forumId,this.subject,this.postContext);
               var response=  await this.$postManager.CreatePostAsync(post);
               if(response.status==0){
                      //说明提交成功
               }
            }       
        },Test(){
            alert("哈哈哈");
        },BuildPostData(forumId,subject,context){
            var postData={"ForumId":forumId,"CreateUserId":this.$store.user.id,
                          "Subject":subject,"Context":context,"CreateUserName":this.$store.user.userName,
                          "CreateUserNickname":this.$store.user.nickName,"CreateUserAvatar":this.$store.avatar};
                        
            return  postData;
        }
    }
    
}
</script>
<style>
.sp-create-post{
    width:  100%;
    float: left;
}
.sp-create-post2{
     width:  75%;
    float: left;
}
.sp-create-post-submit{
      background-color: white;
       border-radius: 0 0 5px 5px;
  }
</style>

