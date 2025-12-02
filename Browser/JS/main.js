//PT will be a reference to 'PackageType'

const baseURl =''
const app = Vue.createApp({
    data() {
        return {
            shelfInDB:[],
            showShelfList:[{ID:1,Status:true,PackageTypeName:'Duftlys',MAC:'098556'},{ID:2,Status:true,PackageTypeName:'BodyScup',MAC:'9649h'}],
            shelf:'',
            PTInDB:[],
            showPTList:[],
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
