import Vue from "vue";
import vuex from 'vuex';
Vue.use(vuex);
export default new vuex.Store({
    state:{
        token:{access_token:"",refresh:"",expires_in:"",}, 
        user:{userName:"",id:"",nickName:"",avatar:"",role:"",},
        isSignOut:true      
    },mutations:{
        CommitToken(state,token){
            state.token.access_token=token.access_token;
            state.token.refresh=token.refresh_token;
        },
        CommitUser(state,user){
            state.user.userName=user.userName;
            state.user.id=user.id;
            state.user.nickName=user.nickName;
            state.user.avatar=user.avatar;
            state.user.role=user.role;
        },RemoveUser(state){
            state.user.userName=null;
            state.user.id=null;
            state.user.nickName=null;
            state.user.avatar=null;
            state.user.role=null;
        },CommitIsSignOutValue(state,isSignOut){
            state.isSignOut=isSignOut;
        }
    }
})