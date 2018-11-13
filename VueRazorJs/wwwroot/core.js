class AsyncHttpRequest {
    static get(url, callback, error, options) {
        var xhttp = new XMLHttpRequest();
        xhttp.onreadystatechange = function () {
            if (this.readyState == 4 && this.status == 200) {
                callback(this.response);
            }
        };

        xhttp.onerror = error;

        xhttp.open("GET", url, true);
        xhttp.send();
    }
}

class VueAppContainer {
    constructor(vueApps) {
        this.vueApps = vueApps;
    }

    getVueInstance(id) {
        return this.vueApps.find(v => v.key == id).value;
    }

    setVueInstance(id, app) {
        let findedApp = this.vueApps.find(v => v.key == id);
        let index = this.vueApps.indexOf(findedApp);

        console.log(app);

        this.vueApps[index] = {
            key: id,
            value: app
        };
    }
}

var VueFactory = (function () {
    var vueApps;

    function createInstances() {
        let vueRazorApps = document.getElementsByClassName("vue-razor-app");

        let apps = [];

        for (let i = 0; i < vueRazorApps.length; i++) {
            let id = vueRazorApps.item(i).id;

            if (id) {
                var vueInstance = create(id);

                apps.push({
                    key: id,
                    value: vueInstance
                });
            }
        }

        return new VueAppContainer(apps);
    }

    function create(id) {
        var appDiv = document.getElementById(id);

        var modelDiv = document.getElementById(id + "-model");
        var datasourceDiv = appDiv.querySelector(".datasource");
        var pageCount = appDiv.querySelectorAll(".page-index").length;

        var data = {};
        var methods = {};

        if (modelDiv) {
            data.model = JSON.parse(modelDiv.innerHTML);
        }

        if (datasourceDiv) {
            data.datasource = JSON.parse(datasourceDiv.innerHTML);
        }

        if (pageCount > 0) {
            data.pageCount = pageCount;
            data.actualPage = 0;
            data.pagingUrl = appDiv.querySelector(".vue-razor-table-paginator").getAttribute("url");

            methods.paging = function (pageNumber) {
                var that = this;
                if (typeof pageNumber == 'number' && pageNumber < this.pageCount && pageNumber >= 0) {
                    AsyncHttpRequest.get(that.pagingUrl + pageNumber, function (data) {
                        //TODO: fix id
                        let tableDiv = document.getElementById('rendervuerazortable');
                        tableDiv.innerHTML = data;

                        that.actualPage = pageNumber;

                        vueFactory.setVueInstance(id, create(id));
                    });
                }
            }

            methods.movePage = function (pageNumber) {
                this.paging(pageNumber);
            }
        }

        return new Vue({
            el: "#" + id,
            data: data,
            methods: methods
        });
    }

    return {
        getInstance: function () {
            if (!vueApps) {
                vueApps = createInstances();
            }
            return vueApps;
        }
    };
})();

var vueFactory = VueFactory.getInstance();


/*$.ajax({
    url: that.pagingUrl + pageNumber,
    type: "GET",
    success: function (data) {
        $("#" + id + "-datasource").html(data);

        var dataSourceString = document.getElementById(id + "-datasource").innerHTML;
        var dataSourceJson = JSON.parse(dataSourceString);
        that.datasource = dataSourceJson;
        that.actualPage = pageNumber;
    }
});*/