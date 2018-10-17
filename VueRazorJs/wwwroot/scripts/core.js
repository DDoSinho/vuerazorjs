"use strict";
exports.__esModule = true;
var vue_1 = require("vue");
var modelString = document.getElementById("app-model").innerHTML;
var modelJson = JSON.parse(modelString);
var app = new vue_1["default"]({
    el: '#app',
    data: {
        model: modelJson
    }
});
alert("");
console.log("aaa");
