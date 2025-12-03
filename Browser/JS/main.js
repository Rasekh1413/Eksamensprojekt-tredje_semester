//PT will be a reference to 'PackageType'
const baseURL='http://localhost:5155/api/'
const baseURLShelf =baseURL+'Shelf'
const baseURLPt=baseURL+'PackageType'

const app = Vue.createApp({
    data() {
        return {
            shelfInDB:[],
            showShelfList:[],
            shelf:'',
            PTInDB:[],
            showPTList:[],
            PT:[]


        }
    },
    methods: {
        //Methods using shelf
        getAllShelf(){
            console.log("Er i metoden GetAllShelf")
            axios.get(baseURLShelf)
            .then(
                response=>{
                    console.log(response.data)
                    this.shelfInDB = response.data
                    this.showShelfList= this.shelfInDB
                }
            ).catch(
                error=>{
                    console.log(error)
                }
            )
            console.log("Færdig i metoden GetAllShelf")
        },
        deleteShelf(){

        },
        UpdateShelfPackagtype(){

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
