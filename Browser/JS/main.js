//PT will be a reference to 'PackageType'
const baseURL='http://localhost:5155/api/'
const baseURLShelf =baseURL+'Shelf/'
const baseURLPt=baseURL+'PackageType/'

const app = Vue.createApp({
    data() {
        return {
            shelfInDB:[],
            showShelfList:[],
            shelf:'',
            newptName:'',
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
        deleteShelf(mac){
            console.log("Er i metoden DeleteShelf")
            axios.delete(baseURLShelf+mac)
            .then(
                response =>{
                    console.log(response)
                }
            ).catch(
                error=>{
                    console.log(error)
                }
            )
            this.getAllShelf()
        },
        UpdateShelfPackagtype(mac){
            console.log("Er i metoden UpdateShelf")
            axios.update(baseURLShelf+mac+'/'+newptName)
            .then(
                response =>{
                    console.log(response)
                }
            ).catch(
                error=>{
                    console.log(error)
                }
            )
            this.getAllShelf()
        },

        //Methods usign Packagetype
        getAllPT(){
            console.log("Er i metoden GetAllPt")
            axios.get(baseURLPt)
            .then(
                response=>{
                    console.log(response.data)
                    this.PTInDB = response.data
                    this.showPTList= this.PTInDB
                }
            ).catch(
                error=>{
                    console.log(error)
                }
            )
            console.log("Færdig i metoden GetAllPt")

        },
        addPT(){
            console.log("Er i metoden xxx")
        },
        deletePT(){
            console.log("Er i metoden xxx")


        },
        updatePT(){
            console.log("Er i metoden xxx")

        },
        getPTByName(){
            console.log("Er i metoden xxx")

        }
        ,
        //Methods for filthering

        //Methods for sorting


    }
})
