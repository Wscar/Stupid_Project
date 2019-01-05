import Vue from "vue";
import vuex from 'vuex';
Vue.use(vuex);
export default new vuex.Store({
    state:{
        token:{access_token:"",refresh:"zzz"},       
    },mutations:{
        CommitToken(state,token){
            state.token.access_token=token.access_token;
            state.token.refresh=token.refresh_token;
        }
    }
})