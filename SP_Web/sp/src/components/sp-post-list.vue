<template>
    <ul>
        <li class="sp-post-list">
            <div>
                <div class="sp-post-list-avatar">
                    <img>
                </div>
                <div class="sp-post-list-body">
                    <div class="sp-post-list-body-tiltle">
                        <span><router-link :to="{name:'sp-info'}">如何看待.net程序员失业</router-link></span>
                    </div>
                    <div class="sp-post-list-foot">
                        <ul>
                            <li class="sp-post-list-foot-lan">
                             <div>
                                 C#
                             </div>
                             </li>                               
                            <li>|</li>
                            <li class="sp-post-list-foot-author">夜莫白</li>
                            <li>|</li>
                            <li >6分钟前</li>
                            <li>|</li>
                            <li>
                                <span>最后回复来自于</span><span>xxxxx</span>
                            </li>
                        </ul>
                    </div>
                </div>
            </div>
        </li>
    </ul>
</template>
<script>
export default {
    
}
</script>
<style>
.sp-post-list{
    height: 50px;
    width: 100%;
    border-top: 1px solid;
}
.sp-post-list-avatar{
    width: 50px;
    height: 50px;
    background-color: green;
    float: left;
}
.sp-post-list-body li{
    margin-top: 5px;
   margin-left: 20px;
    float: left;
    line-height: 25px;
    text-align: left;;
}
.sp-post-list-body{
    float: left;
}
.sp-post-list-body-tiltle{
    width:  100%;
    height: 20px;
}
.sp-post-list-body-tiltle span{
    display: block;
    width: 100%;
    height: 20px;
    text-align: left;
    margin-left: 20px;
}
.sp-post-list-foot {
    height: 25px;
    width: 100%;
     color: #999;
     font-size: 14px;
}
.sp-post-list-foot span{
    display: block;
    float: left;
}
.sp-post-list-foot-lan div{
   width: 20px;
   height: 25%;
   background-color: #e2e2e2;
   border-radius: 3px;
 
}
.sp-post-list-foot-author{
 color: black;
}
</style>
