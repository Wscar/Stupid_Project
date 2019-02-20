import Vue from "vue";
import vuex from 'vuex';
Vue.use(vuex);
export default new vuex.Store({
    state:{
        token:{access_token:'',refresh:"",expires_in:"",}, 
        user:{userName:"",id:"",nickName:"",avatar:"",role:"",},
        isSignOut:true ,
        isSignIn:false ,
        areas:[],
        area:{id:null,name:""},
        forums:null,
        forum:{id:null,name:"",userId:null,areaId:""}    
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
        },CommitIsSignInValue(state,isSignIn){
            state.isSignIn=isSignIn;
        },CommitAreas(state,areas){
                  state.areas=[];
                  areas.forEach(item=>{
                   state.areas.push({id:item.id,name:item.name,forums:item.forumVMs});
                  });
        }
    }
})