var stations;
var targetUrl = "https://api.jcdecaux.com/vls/v1";
function retrieveAllContracts() {
    var apiKey = document.getElementById("apiKey").value;
    var url = targetUrl+"/contracts?apiKey="+apiKey;
    var xhr = new XMLHttpRequest();
    xhr.open("GET", url, true);
    xhr.setRequestHeader("Accept", "application/json");
    xhr.onload = contractsRetrieved;
    xhr.send();
}

function contractsRetrieved() {
    var response = JSON.parse(this.responseText);
    var contractDataList = document.getElementById("contractsList");
    response.forEach(function (contract) {
        var single_contract = document.createElement("option");
        single_contract.setAttribute("value", contract.name);
        contractDataList.appendChild(single_contract);
    })
    //console.log(response);
}

function retrieveContractStations() {
    var apiKey = document.getElementById("apiKey").value;
    var contractName = document.getElementById("contracts").value;
    //console.log(contractName);
    var url = targetUrl+"/stations?contract=" + contractName + "&apiKey=" + apiKey;
    var xhr = new XMLHttpRequest();
    xhr.open("GET", url, true);
    xhr.setRequestHeader("Accept", "application/json");
    xhr.onload = stationsRetrieved;
    xhr.send();
}

function stationsRetrieved() {
    var response = JSON.parse(this.responseText);
    stations = response;
    //console.log(stations);
}

function getClosestStation() {
    var userLat = document.getElementById("lat").value;
    var userLon = document.getElementById("long").value;
    var closestStation = {};
    var distances = [];
    stations.forEach(function (station) {
        var stationLat = station.position.lat;
        var stationLon = station.position.lng;
        //find the smallest distance between 
        var distance = getDistanceFrom2GpsCoordinates(userLat, userLon, stationLat, stationLon);
        distances.push(distance);
    })
    var minDistance = Math.min.apply(null, distances);
    var index = distances.indexOf(minDistance);
    closestStation = stations[index];
    console.log(closestStation);
    var p = document.createElement("p");
    p.innerHTML = JSON.stringify(closestStation);
    var result = document.getElementById("result");
    result.appendChild(p);
}

function getDistanceFrom2GpsCoordinates(lat1, lon1, lat2, lon2) {
    // Radius of the earth in km
    var earthRadius = 6371;
    var dLat = deg2rad(lat2-lat1);
    var dLon = deg2rad(lon2-lon1);
    var a =
        Math.sin(dLat/2) * Math.sin(dLat/2) +
        Math.cos(deg2rad(lat1)) * Math.cos(deg2rad(lat2)) *
        Math.sin(dLon/2) * Math.sin(dLon/2)
    ;
    var c = 2 * Math.atan2(Math.sqrt(a), Math.sqrt(1-a));
    var d = earthRadius * c; // Distance in km
    return d;
}

function deg2rad(deg) {
    return deg * (Math.PI/180)
}