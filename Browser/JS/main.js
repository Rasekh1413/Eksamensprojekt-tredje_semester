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
            PT:[],
            ptNewDescription:[],
            ptNewName:[]


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
            console.log(this.newptName)
            axios.put(baseURLShelf+mac+'/'+this.newptName)
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
        getShelfFromMac(mac){
            console.log("Er i metoden GetShelfFromMac")
            axios.get(baseURLShelf+mac)
            .then(
                response=>{
                    console.log(response.data)
                    this.shelf = response.data
                }
            ).catch(
                error=>{
                    console.log(error)
                }
            )
            console.log("Færdig i metoden GetAllShelf")
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
            console.log("Er i metoden addPT")
            axios.post(baseURLPt,{"name":this.ptNewName,"description":this.ptNewDescription})
            .then( response =>{
                console.log(response)
            }).catch(
                error=>{
                    console.log(error)
                }
            )
            console.log("Færdig i metoden addPT")
            this.getAllPT()
        },
        deletePT(name){
            console.log("Er i metoden deletePT")
            axios.delete(baseURLPt+name).then(
                response=>{
                    console.log(response)
                }
            ).catch(
                error=>{
                    console.log(error)
                }
            )
            console.log("Færdig i metoden deletePT")
            this.getAllPT()
        },
        updatePT(){
            console.log("Er i metoden xxx")

        },
        getPTByName(name){
            console.log("Er i metoden GetPtByName")
            console.log(name)
            axios.get(baseURLPt+name)
            .then(
                response=>{
                    console.log(response.data)
                    this.PT = response.data
                    this.ptNewDescription=this.PT.description
                }
            ).catch(
                error=>{
                    console.log(error)
                }
            )
            console.log(this.ptNewDescription)
            console.log("Færdig i metoden GetPtByName")
        }
        ,
        //Methods for filthering

        //Methods for sorting


    }
})
