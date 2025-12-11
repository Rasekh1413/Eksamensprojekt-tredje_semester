// PT will be a reference to 'PackageType'
const baseURL = 'api/';
const baseURLShelf = baseURL + 'Shelf/';
const baseURLPt = baseURL + 'PackageType/';

const SortShelfPTAsc='sortShelfPTAsc'
const SortShelfPTDesc='sortShelfPTDesc'
const SortShelfNumberAsc='sortShelfNumberAsc'
const SortShelfNumberDesc='sortShelfNumberDesc'

const FilterPt='filterPt'
const FilterStatus ='filterStatus'

var sortBy =''
var filterBy=''


const app = Vue.createApp({
    data() {
        return {
            shelfInDB: [],
            showShelfList: [],
            shelf: '',
            newptName: '',
            PTInDB: [],
            showPTList: [],
            PT: [],
            ptNewDescription: [],
            ptNewName: [],
            selectedShelf:null,
            selectedPT:null,
            chosenStatus:'all',
            chosenPt:'all'
        }
    },
    methods: {
        // Methods using shelf
        getAllShelf() {
            console.log("Er i metoden GetAllShelf");
            axios.get(baseURLShelf)
                .then(response => {
                    console.log(response.data);
                    this.shelfInDB = response.data;
                    this.showShelfList = this.shelfInDB;
                    this.filterShelf()
                    this.sortShelf()
                })
                .catch(error => { console.log(error); });
        },

        deleteShelf(mac) {
            console.log("Er i metoden DeleteShelf");
            axios.delete(baseURLShelf + mac)
                .then(response => { console.log(response); })
                .catch(error => { console.log(error); });
            this.getAllShelf();
        },

        UpdateShelfPackagtype(mac) {
            console.log("Er i metoden UpdateShelf");
            console.log(this.newptName);
            if (this.newptName != null)
            {
                axios.put(baseURLShelf + mac + '/' + this.newptName)
                    .then(response => { console.log(response); })
                    .catch(error => { console.log(error); });
            }
            else
            {
                axios.put(baseURLShelf + mac)
                    .then(response => { console.log(response); })
                    .catch(error => { console.log(error); });
            }
            this.getAllShelf();
        },

        getShelfFromMac(mac) {
            console.log("Er i metoden GetShelfFromMac");
            axios.get(baseURLShelf + mac)
                .then(response => {
                    console.log(response.data);
                    this.shelf = response.data;
                })
                .catch(error => { console.log(error); });
        },
        toggleSelectionShelf(mac){
            if(this.selectedShelf===mac){
                this.selectedShelf=null
                this.shelf=''
            }
            else{
                this.selectedShelf=mac
                this.getShelfFromMac(mac)
            }

        },

        // Methods using PackageType
        getAllPT() {
            console.log("Er i metoden GetAllPt");
            axios.get(baseURLPt)
                .then(response => {
                    console.log(response.data);
                    this.PTInDB = response.data;
                    this.showPTList = this.PTInDB;
                })
                .catch(error => { console.log(error); });
        },

        addPT() {
            console.log("Er i metoden addPT");
            axios.post(baseURLPt, { "name": this.ptNewName, "description": this.ptNewDescription })
                .then(response => { console.log(response); })
                .catch(error => { console.log(error); });
            this.getAllPT();
        },

        deletePT(name) {
            console.log("Er i metoden deletePT");
            axios.delete(baseURLPt + name)
                .then(response => { console.log(response); })
                .catch(error => { console.log(error); });
            this.getAllPT();
        },

        updatePT() {
            console.log("Er i metoden UpdatePT");
            axios.put(baseURLPt, { "name": this.PT.name, "description": this.ptNewDescription })
                .then(response => 
                    { 
                        console.log(response); 
                        this.ptNewDescription=''
                        this.ptNewName=''
                    })
                .catch(error => { console.log(error); });
            this.getAllPT();
        },

        getPTByName(name) {
            console.log("Er i metoden GetPtByName");
            console.log(name);
            axios.get(baseURLPt + name)
                .then(response => {
                    console.log(response.data);
                    this.PT = response.data;
                    this.ptNewDescription = this.PT.description;
                    this.ptNewName = this.PT.name;
                })
                .catch(error => { console.log(error); });
            console.log(this.ptNewDescription);
            console.log("Færdig i metoden GetPtByName");
        },
            toggleSelectionPT(name){
            console.log(name)
            if(this.selectedPT===name){
                this.selectedPT=null
                this.PT=''
                this.ptNewDescription=''
                this.ptNewName=''
            }
            else{
                this.selectedPT=name
                this.getPTByName(name)
            }
        },
        //Filtrering af shelf (Bind: ptNewName)
        filterPt(){
            filterBy='filterPt'
            console.log(this.chosenPt)
            if(this.chosenPt!='all'){
                this.showShelfList = this.showShelfList.filter(s=>s.packageTypeName==this.chosenPt)
            }
        },
        filterStatus(){
            filterBy=FilterStatus
            console.log(this.chosenStatus)

            if(this.chosenStatus != "all") 
            {
                this.showShelfList = this.showShelfList.filter(s=>s.isStocked==this.chosenStatus)
            }
            console.log(this.showShelfList)
        },

        //Sortering af Shelf
        sortShelfPTAsc(){
            sortBy=SortShelfPTAsc
            let obj1 = []

            //Objekter uden null værdi tilføjes til arrayet og sorteres
            for (const obj2 of this.showShelfList)
            {
                if (obj2.packageTypeName != null)
                {
                    obj1.push(obj2)
                }
            }
            obj1.sort((shelfPt1, shelfPt2) => shelfPt1.packageTypeName.localeCompare(shelfPt2.packageTypeName))

            //Objekterne med null tilføjes til listen
            for (const obj2 of this.showShelfList)
            {
                if (obj2.packageTypeName == null)
                {
                    obj1.push(obj2)
                }
            }
            this.showShelfList = obj1
        },
        sortShelfPTDesc(){
            sortBy=SortShelfPTDesc
            this.sortShelfPTAsc()
            this.showShelfList.reverse()
        },
        sortShelfNumberAsc(){
            sortBy=SortShelfNumberAsc
            this.showShelfList.sort((shelf1, shelf2) => shelf1.id - shelf2.id)
        },
        sortShelfNumberDesc(){
            sortBy=SortShelfNumberDesc
            this.showShelfList.sort((shelf1, shelf2) => shelf2.id - shelf1.id)
        },
        sortShelf(){
            if(sortBy==SortShelfPTAsc)
            {
                this.sortShelfPTAsc()
            }
            else if( sortBy==SortShelfPTDesc)
            {
                this.sortShelfPTDesc()
            }
            else if( sortBy==SortShelfNumberAsc)
            {
                this.sortShelfNumberAsc()
            }
            else if( sortBy==SortShelfNumberDesc)
            {
                this.sortShelfNumberDesc()
            }
        },
        filterShelf(){
            this.showShelfList = this.shelfInDB
            this.filterStatus()
            this.filterPt()
        }
    },

        // ✅ Auto-load on page load + auto-refresh every 10 seconds
        mounted() {
        // Load immediately when the page loads
        this.getAllShelf();
        this.getAllPT();


        // Refresh shelves every 10 seconds
        this.shelfTimer1 = setInterval(() => {
            this.getAllPT();
            this.getAllShelf();
        }, 1000);
        // Refresh sort every 10 miliseconds
        this.shelfTimer2 = setInterval(() => {
            this.filterShelf()
            this.sortShelf()
        }, 100);

        // Refresh package types every 10 seconds
        /*this.ptTimer = setInterval(() => {
            this.getAllPT();
        }, 10000);*/
    },

    beforeUnmount() {
        clearInterval(this.shelfTimer1);
        clearInterval(this.shelfTimer2);
        clearInterval(this.ptTimer);
    }
});

app.mount('#app');
