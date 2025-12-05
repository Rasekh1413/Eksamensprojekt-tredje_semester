// PT will be a reference to 'PackageType'
const baseURL = 'http://localhost:5155/api/';
const baseURLShelf = baseURL + 'Shelf/';
const baseURLPt = baseURL + 'PackageType/';

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
            axios.put(baseURLShelf + mac + '/' + this.newptName)
                .then(response => { console.log(response); })
                .catch(error => { console.log(error); });
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
                .then(response => { console.log(response); })
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

    },

        // ✅ Auto-load on page load + auto-refresh every 10 seconds
        mounted() {
        // Load immediately when the page loads
        this.getAllShelf();
        this.getAllPT();

        // Refresh shelves every 10 seconds
        this.shelfTimer = setInterval(() => {
            this.getAllShelf();
        }, 10000);

        // Refresh package types every 10 seconds
        this.ptTimer = setInterval(() => {
            this.getAllPT();
        }, 10000);
    },

    beforeUnmount() {
        clearInterval(this.shelfTimer);
        clearInterval(this.ptTimer);
    }
});

app.mount('#app');
