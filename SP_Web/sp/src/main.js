// The Vue build version to load with the `import` command
// (runtime-only or standalone) has been set in webpack.base.conf with an alias.
import Vue from 'vue'
import App from './App'
//import router from './router'
import VueRouter from 'vue-router';
import ElementUI from  'element-ui';
import 'element-ui/lib/theme-chalk/index.css';
Vue.config.productionTip = false
//导入Js
import signInManager from './utils/signInManager.js';
import userManager from  './utils/userManager.js';
import store from './store/index.js';
//导入组建
import Home from './components/home.vue';
import  Header from './components/mainHeader.vue'; 
import SignUp from './components/signup.vue';
import SignIn from './components/signIn.vue';
Vue.component('home',Home);
Vue.component('mainHeader', Header);
Vue.component('signup',SignUp);
Vue.component('signin',SignIn);
/* eslint-disable no-new */
Vue.use(VueRouter);
Vue.use(ElementUI);
Vue.prototype.$signInManager=signInManager;
Vue.prototype.$userManager=userManager;                        
//创建路由对象
const router=new VueRouter(
  {
   mode:'history',
  routes:
  [
   {path:"/",  component:Home,name:"Home" },
   {path:'/signUp',component:SignUp,name:'SignUp'},
    {path:"/signIn",component:SignIn,name:"SignIn"}
  ]

 })
new Vue({
  el: '#app',
  router:router,
  store,
  components: { App },
  template: '<App/>'
})
