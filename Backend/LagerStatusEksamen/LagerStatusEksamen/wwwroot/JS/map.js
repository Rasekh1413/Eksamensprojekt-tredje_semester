//Initilisere et kort, der viser det valgte cordinater og zoom level.
var map = L.map('map').setView([55.644597,12.122], 13);

//URL sættes, samt max zooom
L.tileLayer('https://tile.openstreetmap.org/{z}/{x}/{y}.png', {
    maxZoom: 19,
    attribution: '&copy; <a href="http://www.openstreetmap.org/copyright">OpenStreetMap</a>'
}).addTo(map);


var popups=[{navn:'xxx',placering:[55.644597,12.122],tekst:'Foretnings placering'},
            {navn:'leverandør1',placering:[55.647965,12.110327],tekst:'(leverandør1) af: \nBadesalt'},
            {navn:'leverandør2',placering:[55.640355, 12.117946],tekst:'(leverandør2) af: \nDuftlys'}]

for (let i=0; i<popups.length;i++)
    {
        //Opret en 'placerings markør'og bind til kortet
        let marker=L.marker(popups[i].placering).addTo(map);
        //Tilføj tekst/opup til markør
        marker.bindPopup(popups[i].tekst)

        //Teksten åbner, når musen hover over markøren
        marker.on('mouseover',function(){ 
            this.openPopup()
        })
        //Teksten luker, når musen ikke hover over markøren
        marker.on('mouseout',function(){ 
            this.closePopup()
        })
    }