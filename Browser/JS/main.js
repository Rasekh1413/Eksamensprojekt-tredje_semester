//PT will be a reference to 'PackageType'

const baseURl =''
const app = Vue.createApp({
    data() {
        return {
            shelfInDB:[],
            showShelfList:[{ID:1,Status:true,PackageTypeName:'Lavendel duftlys',MAC:'098556'},{ID:2,Status:true,PackageTypeName:'Berry BodyScrup',MAC:'9649h'}],
            shelf:'',
            PTInDB:[],
            showPTList:[{Name:'Lavendel duftlys',Description:'Duftlys med duft af lavenden'},{Name:'Berry BodyScrup',Description:'Bodyscrub med kaffegrums duft af bær'}],
            PT:[]


        }
    },
    methods: {
        //Methods using shelf
        getAllShelf(){

        },
        deleteShelf(){

        },
        UpdateShelfPackagtype(){

        },
        UpdateShelfStatus(){

        },
        //Methods usign Packagetype
        getAllPT(){

        },
        addPT(){

        },
        deletePT(){

        },
        updatePT(){

        },
        getPTByName(){

        }
        ,
        //Methods for filthering

        //Methods for sorting


    }
})
