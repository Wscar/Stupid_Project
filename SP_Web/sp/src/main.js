// The Vue build version to load with the `import` command
// (runtime-only or standalone) has been set in webpack.base.conf with an alias.
import Vue from 'vue'
import App from './App'
//import router from './router'
import VueRouter from 'vue-router';
Vue.config.productionTip = false
import Home from './components/home.vue';
import  Header from './components/mainHeader.vue'; 
Vue.component('home',Home);
Vue.component('mainHeader', Header);
/* eslint-disable no-new */
Vue.use(VueRouter);
//创建路由对象
const router=new VueRouter(
  {
   mode:'history',
  routes:
  [
   {path:"/",  component:Home,name:"Home" }
  ]

 })
new Vue({
  el: '#app',
  router:router,
  components: { App },
  template: '<App/>'
})
