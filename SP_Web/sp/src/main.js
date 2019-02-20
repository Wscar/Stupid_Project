// The Vue build version to load with the `import` command
// (runtime-only or standalone) has been set in webpack.base.conf with an alias.
import Vue from 'vue'
import App from './App'
//import router from './router'
import VueRouter from 'vue-router';
import ElementUI, { Form } from  'element-ui';
import 'element-ui/lib/theme-chalk/index.css';
Vue.config.productionTip = false
//导入Js
import signInManager from './utils/signInManager.js';
import userManager from  './utils/userManager.js';
import store from './store/index.js';
import postManager from './utils/postManager.js';
//导入组建
import Home from './components/home.vue';
import  Header from './components/mainHeader.vue'; 
import SignUp from './components/signup.vue';
import SignIn from './components/signIn.vue';
import sp_li  from './components/sp-li.vue';
import sp_post_list  from  './components/sp-post-list.vue';
import sp_post_info from './components/sp-post-info.vue';
import sp_home_right  from './components/home-right.vue';
import sp_forum_info from './components/sp-forum-info.vue';
import sp_create_post from './components/create-post.vue';


Vue.component('home',Home);
Vue.component('mainHeader', Header);
Vue.component('signup',SignUp);
Vue.component('signin',SignIn);
Vue.component('sp-li',sp_li);
Vue.component('sp-post-list',sp_post_list);
Vue.component('sp-post-info',sp_post_info);
Vue.component("sp-home-right",sp_home_right);
Vue.component("sp-create-post",sp_create_post);
/* eslint-disable no-new */
Vue.use(VueRouter);
Vue.use(ElementUI);
Vue.prototype.$signInManager=signInManager;
Vue.prototype.$userManager=userManager;  
Vue.prototype.$postManager=postManager;                      
//创建路由对象
const router=new VueRouter(
  {
   mode:'history',
  routes:
  [
  //  {path:"/",  components:{default:Home,},name:"Home" },
   {path:"/",  components:{default:Home,header:Header},name:"Home"},
   {path:'/signUp',component:SignUp,name:'SignUp'},
   {path:"/signIn",component:SignIn,name:"SignIn"},
   {path:'/postinfo',components:{default: sp_post_info,header:Header},name:"sp-info"},
   {path:'/forum/:name',components:{default:sp_forum_info,header:Header},name:"sp-forum-info"},
   {path:'/new',components:{default:sp_create_post,header:Header},name:'new',meta:{requiresAuth: true}}
  ]

 });
 router.beforeEach((to,from,next)=>{
    if(to.matched.some(record=>record.meta.requiresAuth)){  
      var check= signInManager.CheckSignIn(); 
      console.log("check的值是"+check); 
      if(check!=true){
        next({
          path:"/signIn"      
        });
        console.log(to.fullPath);
      }else{     
        next();
      }
    }else{
      next();
    }

 });
new Vue({
  el: '#app',
  router:router,
  store,
  components: { App },
  template: '<App/>'
})
