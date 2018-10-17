import Vue from 'vue';

var modelString = document.getElementById("app-model").innerHTML;
var modelJson = JSON.parse(modelString);

var app = new Vue({
    el: '#app',
    data: {
        model: modelJson
    }
});

alert("");
console.log("aa");