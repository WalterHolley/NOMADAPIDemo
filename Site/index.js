//Initial setup

window.onload = (event) => {
    togglePrimaryDisplay("home");
};

var siteTemplates = document.getElementsByTagName("template");
var findTitle = "<h3>Find</h3>";
var searchTitle = "<h3>Search</h3>";
var createTitle = "<h3>Create</h3>";
var searchTemplate = "<tr>"
function togglePrimaryDisplay(display){
    document.getElementById(display).style.display = "block";
    switch(display){
        case "vehicles":
            document.getElementById("parts").style.display = "none";
            document.getElementById("home").style.display = "none";
            break;
        case "parts":
            document.getElementById("vehicles").style.display = "none";
            document.getElementById("home").style.display = "none";
            break;
        case "home":
            document.getElementById("vehicles").style.display = "none";
            document.getElementById("parts").style.display = "none";
    }
}

function goHome(){
    togglePrimaryDisplay("home");
}

function goParts(){
    togglePrimaryDisplay("parts");
    openPartsFind();
}

function goVehicles(){
    togglePrimaryDisplay("vehicles");
    openVehFind();
}

function openVehFind(){
    let clone = siteTemplates[3].content.cloneNode(true);
    let find = document.getElementById("vehContent");
    find.innerHTML = findTitle;
    find.appendChild(clone);
}

function openVehCreate(){
    let clone = siteTemplates[2].content.cloneNode(true);
    let create = document.getElementById("vehContent");
    create.innerHTML = createTitle;
    create.appendChild(clone);
}

function openPartsFind(){
    let clone = siteTemplates[1].content.cloneNode(true);
    let find = document.getElementById("partsContent");
    find.innerHTML = findTitle;
    find.appendChild(clone);
}

function openPartsCreate(){
    let clone = siteTemplates[0].content.cloneNode(true);
    let find = document.getElementById("partsContent");
    find.innerHTML = createTitle;
    find.appendChild(clone);
}