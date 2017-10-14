var app = angular.module('app', []);
app.controller('mainController', ['$scope', 'mainService', function (scope, mainService) {

    scope.students = [];
    scope.selectedPage = 1;
    scope.getStudents = function (page, columnName) {

        mainService.getAll(page, columnName).then(function (result) {
            var data = result.data

            if (data) {
                scope.students = data.students;
                scope.numOfPage = data.numOfPage

                scope.pagerItems = [];

                for (var i = 1; i <= scope.numOfPage; i++) {
                    {
                        scope.pagerItems.push(i)
                    }
                }

            }

        });
    }

    scope.goToPage = function (page,columnName ) {
        scope.selectedPage = page;
        scope.getStudents(page,columnName);
    }
    scope.init = function () {
        scope.getStudents();

    }
    scope.init();


}]);


app.factory('mainService', ['$http', function (http) {

    var httpMgr = function (action, data, method) {
        return http({
            method: method || 'GET',
            url: '/Home/' + action,
            params: data
        });
    }

    var getAll = function (pageNumber, columnName  ) {

        return httpMgr('GetAllStudent', { colunName: columnName, pageNumber: pageNumber });
    }




    return {
        getAll: getAll
    }
}]);

app.directive('sortByColumn', ['mainService', function (mainService) {

    return {

        link: function (scope, element, attrs) {
            element.on('click', function () {
                var elem = $(this);
                var columnName = elem.attr("data-column-name");
                
                var test = mainService.getAll({ colunName: columnName })

                //scope.$apply(function () {
                //    scope.students.sort(function (a, b) {

                //        debugger;

                //    })
                //})

            })

        }

    }

}]);