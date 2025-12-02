const app = Vue.createApp({
    data() {
        return {
            title:'Velkommen til min Tamplate',
            indhold:['v-for','v-if','v-on:click','v-Show'],
            showIndhold:true
        }
    },
    methods: {
        ChangeShowIndholdStatus(){
            if(this.showIndhold==true){
                this.showIndhold=false
            }
            else{
                this.showIndhold=true
            }
                
        }
    }
})
