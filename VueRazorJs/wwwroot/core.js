var modelString = document.getElementById("app-model").innerHTML;
var modelJson = JSON.parse(modelString);

var dataSourceString = document.getElementById("app-datasource").innerHTML;
var dataSourceJson = JSON.parse(dataSourceString);

var app = new Vue({
    el: '#app',
    data: {
        model: modelJson,
        datasource: dataSourceJson
    }
});

function updateDataSource() {
    var dataSourceString = document.getElementById("app-datasource").innerHTML;
    var dataSourceJson = JSON.parse(dataSourceString);

    app.datasource = dataSourceJson;
}

var actualPage = 0;
var pageCount = $(".page-index").length;

function paging(pageNumber) {
    if (typeof pageNumber == 'number' && pageNumber < pageCount && pageNumber >= 0) {
        console.log(pageNumber);
        $.ajax({
            url: "/Index/one?pagenumber=" + pageNumber,
            type: "GET",
            success: function (data) {
                $("#app-datasource").html(data);
                updateDataSource();
                actualPage = pageNumber;
            }
        });
    }
}

function previousPage() {
    let page = actualPage - 1;
    paging(page);
}

function nextPage() {
    let page = actualPage + 1;
    paging(page);
}

function movePage(pageNumber) {
    paging(pageNumber);
}