<template>
    <div class="mian">
        <mainHeader></mainHeader>
        <div class="body">我是body</div>
    </div>
   
   
</template>
<script>
export default {
      data(){
        return{text:'1'}
    }
}
</script>
<style>
.mian{
   width: 100%;
   height: 100%;
   background-color: #e2e2e2;
}
.body{
    width: 70%;
    background-color: red;
    margin: 0 auto;    
}
</style>
