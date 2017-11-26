/// <reference path="../angular.min.js" />


// create a module.. we have to associate this module with ng-app directive
var myApp = angular.module("myModule", [])
                    
                    .controller("techController", function ($scope) {
                        var technologies = [
                            {
                                name: "C#", likes: 0, dislikes: 0
                            },
                            {
                                name: "ASP", likes: 0, dislikes: 0
                            },
                            {
                                name: "SQL", likes: 0, dislikes: 0
                            },
                        ]
                        $scope.technologies = technologies;
                        $scope.incrementLikes = function (technology) {
                            technology.likes++;
                        }
                        $scope.incrementDislikes = function (tehcnology) {
                            technology.dislikes++;
                        }
                    })
                    .controller("empController", function ($scope, $http) {
                                   $http.post('GetEmployee.asmx/GetEmployeeOne')
                                        .then(function (response) {
                                                    $scope.employees = response.data;
                                                });
                                          });
                    //.controller("empController", function ($scope) {
                    //        var employees= [{firstName: "David",lastName: "Davis",dateOfBirth: new Date("January 21,1990"),gender: 1,salary: 55670.08}
                    //                         , { firstName: "Daina", lastName: "Ross", dateOfBirth: new Date("January 29,1989"), gender: 2, salary: 64000.78 },
                    //                            { firstName: "Dave", lastName: "Davise", dateOfBirth: new Date("January 20,1990"), gender: 1, salary: 45670.08 }
                    //                         , { firstName: "Dinesh", lastName: "rajkumari", dateOfBirth: new Date("January 28,1989"), gender: 2, salary: 74000.78 }];
                    //        $scope.employees = employees;
                    //        $scope.rowLimit = 3;
                    //        $scope.sortColumn = "firstName";
                    //        $scope.reverseSort = false;
                    //        $scope.sortData = function (column) {
                    //            $scope.reverseSort = ($scope.sortColumn == column) ? !$scope.reverseSort : false;
                    //            $scope.sortColumn = column;
                    //        }

                    //        $scope.getSortClass = function (column) {
                    //            if ($scope.sortColumn == column)
                    //            { return $scope.reverseSort ? '.arrow-down' : 'arrow-up'; }
                    //            else return '';
                    //        }

                    //        $scope.search = function (item) {
                    //            if ($scope.searchText == undefined) {
                    //                return true;
                    //            }
                    //            else {
                    //                if ((item.firstName.toLowerCase().indexOf($scope.searchText.toLowerCase()) != -1) ||
                    //                    (item.gender.toLowerCase().indexOf($scope.searchText.toLowerCase()) != -1))
                    //                { return true; }
                    //                false;
                    //            }
                    //        }

//}
                    
