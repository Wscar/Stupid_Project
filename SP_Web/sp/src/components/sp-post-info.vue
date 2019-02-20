<template>
    <div class="sp-post-info-main">
        <div class="sp-post-info-sub">
         <div class="sp-post-info-header">
             <router-link :to="{name:'Home'}">SP</router-link>
            <span>|</span>
             <router-link :to="{name:'Home'}">C#</router-link>
        </div>
        <div class="sp-post-info-title">
           <h1>如何看待.net程序员即将失业</h1>
        </div>
        <div class="sp-post-info-author">
             <span>作者:</span>
            <span>夜莫白</span>
        </div>
        <div class="sp-post-info-context">
            <p>.net 岗位太少了额</p>
        </div>
        <div class="sp-post-info-sub-bottom"></div>
        </div>
              
        <div class="sp-post-info-comment">
            <div class="sp-post-info-comment-header">
                <span>1条回复</span>
                <span>|</span>
                <span>2019-1-23</span>
            </div>
            <ul>
                <li><div class="sp-post-info-comment-list">
                     <div class="comment-avater">
                         <img>
                     </div>
                     <div class="comment-info">
                     <div class="comment-info-body">
                      <div class="comment-info-body-title">
                       <span class="comment-info-body-tiltle-author">夜莫白</span> 
                       <span>|</span>
                       <span class="comment-info-body-title-reply-time">发表于2019-1-23</span>   
                      </div>
                      <div class="comment-conetxt">
                        <p>工作失误，最多开除，或者让员工分期赔偿，坐牢是不可能的，当然若不是失误而是主观，那就另说了。</p>
                          <p> 大部分情况下不但不要赔偿，甚至会送上特别安慰，因为导致开发团队集体离心的风险太大了。但要是开发团队只是牛马，那就另说了。</p>
                     </div>  
                     </div>     
                    </div>
                    </div>
                    </li>
                <li><div class="sp-post-info-comment-list">
                     <div class="comment-avater">
                         <img>
                     </div>
                     <div class="comment-info">
                     <div class="comment-info-body">
                      <div class="comment-info-body-title">
                       <span class="comment-info-body-tiltle-author" >夜莫白</span> 
                       <span>|</span>
                       <span class="comment-info-body-title-reply-time">发表于2019-1-23</span>   
                      </div>
                      <div class="comment-conetxt">
                          <p>工作失误，最多开除，或者让员工分期赔偿，坐牢是不可能的，当然若不是失误而是主观，那就另说了。</p>
                          <p> 大部分情况下不但不要赔偿，甚至会送上特别安慰，因为导致开发团队集体离心的风险太大了。但要是开发团队只是牛马，那就另说了。</p>
                     </div>  
                     </div>     
                    </div>
                    </div>
                    </li>
            </ul>
        </div>
         <div class="sp-post-reply">
                <div class="sp-post-reply-title">
                    添加一条新回复
                </div>
                <div class="sp-post-reply-context">
                    <el-input
                    type="textarea"
                    :autosize="{ minRows: 2, maxRows: 4}"
                    placeholder="请输入内容"
                    size="medium"
                    >
                    </el-input>

                </div>
                <div class="sp-post-reply-submit">
                 <div style="margin-left:20px">
                     <el-button type="primary">回复</el-button>
                 </div>
  
                </div>
            </div>
    </div>
</template>
<script>
export default {
}
</script>
<style>
.sp-post-info-main{
    width: 75%;
    float: left;
}
.sp-post-info-header{
    color: #778087;
    margin-left: 20px;
}
.sp-post-info-header a{
    text-decoration: none;
    color: #778087;
    font-size: 18px;
}
.sp-post-info-header a:hover{
    color: #4d5256;
    text-decoration: underline;
}
.sp-post-info-author{
    height: 50px;
    line-height: 50px;
    background-color: #f9f9f9;
}
.sp-post-info-title{
    margin-left: 20px;
}
.sp-post-info-author span{
    margin-left: 20px;
}
.sp-post-info-sub{
    background-color: white;
}
.sp-post-info-sub-bottom{
    width: 100%;
    height: 20px;
     background-color:gray;
     border-radius: 5px;
}


.sp-post-info-context p{
    margin-left: 20px;
}
.sp-post-info-comment{
  background-color: white;
  border-radius: 5px;
  margin-top: 30px;

}
.sp-post-info-comment-header{
    color: #999;
    height: 30px;
}
.sp-post-info-comment-header span{
     line-height: 30px;
}
.sp-post-info-comment li{
     width: 100%;
      border-top: 1px solid;
     overflow: auto;
  
}
.sp-post-info-comment-list{
   width: 100%;
   clear: both;

 min-height: 50px;
   height: auto;
}
.comment-avater{
    float: left;
}
.comment-info{
    margin-left: 20px;
     width:  80%;
    float: left;
}
.comment-avater img{
   width:  50px;
   height: 50px;
   background-color: red;
   border-radius: 10px;
}
.comment-info-body-title{
    width: 100%;
    height: 20px;
}
.comment-info-body-title span{
    display: block;
    float: left;
    line-height: 20px;
}
.comment-conetxt{
    margin-top: 5px;
}
.comment-conetxt p{
  margin: 0;
  text-align: left;
  margin-bottom: 8px;

}
.comment-info-body-tiltle-author{
    color: #7d7d7d;
    font-weight: bold;
}
.comment-info-body-title-reply-time{
   color: #7d7d7d;
   font-size: 13px;
}
.sp-post-reply{
    margin-top: 30px;
    background-color: white;
    border-radius: 5px;
}
.sp-post-reply-title{
    text-indent: 2em;
    height: 30px;
    line-height: 30px;
    font-size: 14px;
}
</style>
