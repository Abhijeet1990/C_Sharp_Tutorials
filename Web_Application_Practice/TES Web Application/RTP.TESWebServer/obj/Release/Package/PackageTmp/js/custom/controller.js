(function () {
    angular.module("controllerModule", [])
    /*-----------1. controller used for status page chart  ----------------  */
    .controller('statusHighChart', function ($scope, http) {
        //populate status chart
        $scope.TankLevel = [];
        var d = new Date();
        $scope.hour = d.getHours();
        var min = d.getMinutes();
        $scope.hourMin = $scope.hour + '.' + min,
        http.getChartDataByColumnName(false, 'TankLevel').then(function (success) {
            if (success.status == 200) {
                var data = angular.fromJson(success.data);
                $scope.TankLevel = angular.fromJson(data.d);
                // Display only the future data as an optimal data
                for (index = 0, len = $scope.TankLevel.length ; index < len; ++index) {
                    if (index < $scope.hour) {
                        $scope.TankLevel[index] = null;
                    }
                }
                callChart();
            }
        })

        http.getHistoricalDataByColumnName(false, 'TES Tank Water Thermocline Level').then(function (success) {
            if (success.status == 200) {
                var data = angular.fromJson(success.data);
                $scope.HistoricalTankLevel = angular.fromJson(data.d);
                // Display only the future data as an optimal data
                for (index = 0, len = $scope.HistoricalTankLevel.length ; index < len; ++index) {
                    if (index > $scope.hour) {
                        $scope.HistoricalTankLevel[index] = null;
                    }
                }
                callChart();
            }
        })

        http.getHistoricalDataByColumnName(false, 'TES Mode Actual').then(function (success) {
            if (success.status == 200) {
                var data = angular.fromJson(success.data);
                $scope.HistoricalActualMode = angular.fromJson(data.d);
                // Display only the future data as an optimal data
                for (index = 0, len = $scope.HistoricalActualMode.length ; index < len; ++index) {
                    if (index > $scope.hour) {
                        $scope.HistoricalActualMode[index] = null;
                    }
                }
            }
        })

        /*------------- Gatting data for status page chart 1st series ---------------------------*/
        $scope.chillerSeries = [];
        http.getStatusSeries('Chiller').then(function (success) {
            if (success.status == 200) {
                var data = angular.fromJson(success.data);
                $scope.chillerSeries = angular.fromJson(data.d);
            }
        })

        /*------------- Gatting data for status page chart 2nd series ---------------------------*/
        $scope.secondaryPumpsSeries = [];
        http.getStatusSeries('Sec Pumps').then(function (success) {
            if (success.status == 200) {
                var data = angular.fromJson(success.data);
                $scope.secondaryPumpsSeries = angular.fromJson(data.d);
            }
        })

        $scope.numbers = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24];
        // function start for selected box 
        $scope.selectedBoxIndex = 10;
        $scope.selectedBox = function (val, index) {
            $scope.selectedBoxValue = val;
            $scope.selectedBoxIndex = index;
            //$scope.dynamicClassFlag = index;
        }
        function callChart() {
            Highcharts.chart('container', {
                chart: {
                    type: 'area'
                },
                title: {
                    text: ''
                },
                credits: {
                    enabled: false
                },
                subtitle: {
                    text: ''
                },
                xAxis: {
                    min: 0.5,
                    max: 24,
                    tickInterval: 4,
                    categories: ['0', '1', '2', '3', '4', '5', '6', '7', '8', '9', '10', '11', '12', '13', '14', '15', '16', '17', '18', '19', '20', '21', '22', '23', '24'],
                    // crosshair: true,
                    plotBands: [{ // mark the weekend
                        color: 'red',
                        from: $scope.hourMin,
                        to: $scope.hourMin,
                    }],
                    plotLines: [{
                        color: 'red',
                        width: 2,
                        value: $scope.hourMin,
                    }]
                },
                yAxis: {
                    gridLineWidth: 0,
                    lineWidth: 1,
                    tickWidth: 1,
                    tickAmount: 6,
                    min: 5,
                    max: 60,
                    title: {
                        text: ''
                    },
                },
                tooltip: {
                    pointFormat: '{series.name} <b>{point.y:,.0f} feet </b><br/> at {point.x} Hrs'
                },
                plotOptions: {
                    series: {
                        pointStart: 0
                    },
                    area: {
                        pointStart: 0,
                        marker: {
                            enabled: false,
                            symbol: 'circle',
                            radius: 2,
                            states: {
                                hover: {
                                    enabled: true
                                }
                            }
                        }
                    }
                },
                series: [
                    {
                        showInLegend: false,
                        name: 'Optimal Tank Level is',
                        data: $scope.TankLevel,

                        color: '#4480e2'
                    }
                    , {
                        showInLegend: false,
                        name: 'Tank Level was',
                        data: $scope.HistoricalTankLevel,
                        color: '#d5e0f2'
                    }
                ],
                navigation: {
                    buttonOptions: {
                        align: 'right',
                    }
                }
            });
        }
    })

    /*-----------2. controller for forecast chart  ----------------  */
   .controller('forecastController', function ($scope, $http, http, $filter) {
       $scope.btnText = 'DA',
       $scope.btnLabel = 'Table';
       $scope.selectedChart = 'REAL TIME';
       var columnsArr = [];
       var httpFlag = false;
       $scope.flag = 0;
       $scope.columnObj = {};

       /*-------- getting legend value ----------------*/
       var forecastLegend = [];
       $scope.chartSeries = {};
       http.getForecastLegend().then(function (success) {
           if (success.status == 200) {
               forecastLegend = angular.fromJson(success.data.d);
               $filter('filter')(forecastLegend, function (item) { return (item.Page == 2) }).forEach(function (item) {
                   columnsArr.push(angular.copy(item.Name));
               });
               getChartRTDA(false);
           }
       })

       $scope.$watch('flag', function () {
           if ($scope.flag == columnsArr.length && httpFlag) {

               for (var i = 1; i < 5; i++) {
                   $scope['forecast' + i] = [];
                   $scope['tableData' + i] = [];
                   var seriesData = $filter('filter')(forecastLegend, function (item) { return (item.Page == 2 && item.ChartAreaId == i) });
                   /*-------- Generating series dynamically -------*/
                   seriesData.forEach(function (item) {
                       var table = {
                           name: item.Legend,
                           data: $scope.columnObj[item.Name],
                           color: item.Color,
                           type: item.Type.toLowerCase(),
                           // min: item.MinValue,
                           // max: item.MaxValue,
                           EngUnits: item.EngUnits
                           //title: item.EngUnits
                       }

                       var data = {
                           name: item.Legend,
                           data: $scope.columnObj[item.Name],
                           color: item.Color,
                           type: item.Type.toLowerCase(),
                           // min: item.MinValue,
                           // max: item.MaxValue,
                           //EngUnits: item.EngUnits
                           //title: item.EngUnits
                       }
                       if (item.MajorAxis === 'Y2') {
                           data.yAxis = 1;
                           $scope['forecast' + i].minY = item.MinValue;
                           $scope['forecast' + i].maxY = item.MaxValue;
                           if ($scope['forecast' + i].lableY == undefined)
                               $scope['forecast' + i].lableY = item.EngUnits;
                           else
                               $scope['forecast' + i].lableY.concat(', ')
                           $scope['forecast' + i].lableY.concat(item.EngUnits);
                       }
                       else {
                           $scope['forecast' + i].push(angular.copy(data));
                           $scope['forecast' + i].min = item.MinValue;
                           $scope['forecast' + i].max = item.MaxValue;
                           if ($scope['forecast' + i].lable == undefined)
                               $scope['forecast' + i].lable = item.EngUnits;
                           else
                               $scope['forecast' + i].lable.concat(', ')
                           $scope['forecast' + i].lable.concat(item.EngUnits);
                       }

                       $scope['tableData' + i].push(angular.copy(table));
                   })
               }
               firstChart();
               NetMWhChart();
               NetHHVChart();
               feetChart();
           }
       });

       /*----- getting chart series data ----------*/
       function getChartRTDA(isTrue) {
           $scope.flag = 0;
           $scope.columnObj = {};
           columnsArr.forEach(function (column) {
               http.getChartDataByColumnName(isTrue, column).then(function (success) {
                   if (success.status == 200) {
                       var data = angular.fromJson(success.data);
                       $scope.columnObj[column] = angular.fromJson(data.d);
                       $scope.flag = $scope.flag + 1;
                       httpFlag = true;
                   }
               })
           })
       }

       var flg = 0;
       $scope.rtDate = $filter('date')(new Date(), 'fullDate');
       $scope.callRTDAChart = function () {
           if (flg == 0) {
               var todayDate = new Date();
               $scope.rtDate = $filter('date')(new Date().setDate(todayDate.getDate() + 1), 'fullDate');
               $scope.selectedChart = 'DAY AHEAD';
               $scope.btnText = 'RT';
               getChartRTDA('true');
               flg = 1;
           }
           else {
               $scope.btnText = 'DA';
               $scope.selectedChart = 'REAL TIME';
               $scope.rtDate = $filter('date')(new Date(), 'fullDate');
               getChartRTDA('false');
               flg = 0;
           }
       };
       var tmp = 0;
       $scope.expTable = false;
       $scope.chartShow = true;
       //$scope.tableShow = true;
       $scope.showTableChart = function () {
           if (tmp == 0) {
               $scope.btnLabel = 'Chart';
               $scope.expTable = true;
               $scope.tableShow = true;
               $scope.chartShow = false;
               tmp = 1;
           }
           else {

               $scope.btnLabel = 'Table'
               $scope.expTable = false;
               $scope.tableShow = false;
               $scope.chartShow = true;
               tmp = 0;
           }

       }

       //Exporting table to excel sheet
       $scope.exportTable = function () {
           var exelData = [];
           for (i = 0; i < $scope.columnObj.AmbPress.length; i++) {
               var data = {};
               data.Hour = i + 1;
               columnsArr.forEach(function (colunm) {
                   data[colunm] = $scope.columnObj[colunm][i];
               });
               exelData.push(angular.copy(data));
           }
           alasql('SELECT * INTO XLS("SiteName ' + $scope.selectedChart + ' ' + $scope.rtDate + '.xls",?) FROM ?', [mystyle, exelData]);
       }

       var mystyle = {
           sheetid: 'My Big Table Sheet',
           headers: true,
           columns: [
             { columnid: 'Hour', title: 'Hour' },
             { columnid: 'AmbPress', title: 'AmbPress/psia', width: 300 },
             { columnid: 'AmbRH', title: 'Relative Humidity/%', width: 300 },
             { columnid: 'AmbTemp', title: 'Atoms Pressure/°F ', width: 300 },
             { columnid: 'AmbTdew', title: 'Atoms Pressure/°F ', width: 300 },
             { columnid: 'CT2Gen', title: 'Net/MWh', width: 300 },
             { columnid: 'CT3Gen', title: 'Net/HHV BTU/kWh', width: 300 },
             { columnid: 'CT4Gen', title: 'Net MWh', width: 300 },
             { columnid: 'STGen', title: 'Net HHV BTU/kWh', width: 300 },
             { columnid: 'NetPower', title: 'Net HHV BTU/kWh', width: 300 },
             { columnid: 'NetHR', title: 'Net MWh', width: 300 },
             { columnid: 'TankLevel', title: 'TankLevel/feet', width: 300 }
           ],
       };

       // first chart start
       function firstChart() {
           Highcharts.chart('container1', {

               title: {
                   text: ''
               },

               subtitle: {
                   text: ''
               },

               chart: {
                   // spacingBottom: 15,
                   // spacingTop: 10,
                   spacingLeft: 22,
                   spacingRight: 22,

               },

               credits: {
                   enabled: false
               },
               exporting: {
                   enabled: false
               },

               xAxis: {
                   opposite: true,
                   min: 0.5,
                   max: 24,
                   tickInterval: 4,
                   gridLineWidth: 1,
                   categories: ['00:00h', '01:00h', '02:00h', '03:00h', '04:00h', '05:00h', '06:00h', '07:00h', '08:00h', '09:00h', '10:00h', '11:00h', '12:00h', '13:00h', '14:00h', '15:00h', '16:00h', '17:00h', '18:00h', '19:00h', '20:00h', '21:00h', '22:00h', '23:00h', '24:00h'],
                   //categories: chartSeries,
               },

               yAxis: [{
                   gridLineWidth: 2,
                   lineWidth: 1,
                   tickWidth: 1,
                   tickAmount: 6,
                   min: $scope['forecast1'].min,
                   max: $scope['forecast1'].max,
                   title: {
                       text: $scope['forecast1'].lable
                   }

               }, {
                   gridLineWidth: 2,
                   lineWidth: 1,
                   tickWidth: 1,
                   tickAmount: 6,
                   min: $scope['forecast1'].minY,
                   max: $scope['forecast1'].maxY,
                   title: {
                       text: $scope['forecast1'].lableY
                   },

                   opposite: true

               }],

               legend: {
                   layout: 'vertical',
                   align: 'left',
                   verticalAlign: 'middle'
               },

               plotOptions: {
                   series: {
                       pointStart: 0,
                       marker: {
                           enabled: false
                       },
                   },
               },

               series: $scope.forecast1,
           });
       }

       // second chart start
       function NetMWhChart() {
           Highcharts.chart('container2', {
               title: {
                   text: ''
               },

               subtitle: {
                   text: ''
               },
               chart: {
                   // spacingBottom: 15,
                   // spacingTop: 10,
                   spacingLeft: 24,
                   spacingRight: 16,

               },

               credits: {
                   enabled: false
               },
               exporting: {
                   enabled: false
               },

               xAxis: {
                   opposite: true,
                   min: 0.5,
                   max: 24,
                   labels: {
                       enabled: false
                   },
                   minorTickLength: 0,
                   tickLength: 0,
                   gridLineWidth: 1,
                   //min: 0.5,
                   //max: 24,
                   tickInterval: 4,
                   categories: ['00:00h', '01:00h', '02:00h', '03:00h', '04:00h', '05:00h', '06:00h', '07:00h', '08:00h', '09:00h', '10:00h', '11:00h', '12:00h', '13:00h', '14:00h', '15:00h', '16:00h', '17:00h', '18:00h', '19:00h', '20:00h', '21:00h', '22:00h', '23:00h', '24:00h'],
               },

               yAxis: [{
                   gridLineWidth: 2,
                   lineWidth: 1,
                   tickWidth: 1,
                   tickAmount: 6,
                   min: $scope['forecast2'].min,
                   max: $scope['forecast2'].max,
                   title: {
                       text: 'Net MWh'
                   },
                   labels: {
                       formatter: function () {
                           return this.value + '.0';
                       }
                   },
               }, {
                   gridLineWidth: 2,
                   lineWidth: 1,
                   tickWidth: 1,
                   tickAmount: 6,
                   min: $scope['forecast2'].minY,
                   max: $scope['forecast2'].maxY,
                   title: {
                       text: 'Net MWh'
                   },
                   //labels: {
                   //    formatter: function () {
                   //        return this.value + '.0';
                   //    }
                   //},
                   opposite: true
               }],

               legend: {
                   layout: 'vertical',
                   align: 'left',
                   verticalAlign: 'middle'
               },

               plotOptions: {
                   series: {
                       pointStart: 0,
                   },
               },

               series: $scope.forecast2
           });
       }
       // second chart end

       // third chart start
       function NetHHVChart() {
           Highcharts.chart('container3', {
               title: {
                   text: ''
               },

               subtitle: {
                   text: ''
               },

               credits: {
                   enabled: false
               },
               exporting: {
                   enabled: false
               },
               xAxis: {
                   opposite: true,
                   min: 0.5,
                   max: 24,
                   lineWidth: 0,
                   minorGridLineWidth: 0,
                   lineColor: 'transparent',
                   labels: {
                       enabled: false
                   },
                   minorTickLength: 0,
                   tickLength: 0,
                   gridLineWidth: 1,
                   tickInterval: 4,
                   categories: ['00:00h', '01:00h', '02:00h', '03:00h', '04:00h', '05:00h', '06:00h', '07:00h', '08:00h', '09:00h', '10:00h', '11:00h', '12:00h', '13:00h', '14:00h', '15:00h', '16:00h', '17:00h', '18:00h', '19:00h', '20:00h', '21:00h', '22:00h', '23:00h', '24:00h'],
               },

               yAxis: [{
                   gridLineWidth: 2,
                   lineWidth: 1,
                   tickWidth: 1,
                   tickAmount: 6,
                   min: $scope['forecast3'].min,
                   max: $scope['forecast3'].max,
                   title: {
                       text: 'Net HHV BTU/kWh'
                   }
               }, {
                   gridLineWidth: 2,
                   lineWidth: 1,
                   tickWidth: 1,
                   tickAmount: 6,
                   min: $scope['forecast3'].min,
                   max: $scope['forecast3'].max,
                   //min: $scope['forecast3'].minY,
                   //max: $scope['forecast3'].maxY,
                   title: {
                       text: 'Net HHV BTU/kWh'
                   },
                   opposite: true

               }],

               legend: {
                   layout: 'vertical',
                   align: 'left',
                   verticalAlign: 'middle'
               },

               plotOptions: {
                   series: {
                       pointStart: 0,
                   },
               },
               series: $scope.forecast3,
           });
       }

       // third chart end

       // fourth chart start
       function feetChart() {
           Highcharts.chart('container4', {
               title: {
                   text: ''
               },
               credits: {
                   enabled: false
               },
               subtitle: {
                   text: ''
               },
               chart: {
                   // spacingBottom: 15,
                   // spacingTop: 10,
                   spacingLeft: 12,
                   spacingRight: 16,

               },
               exporting: {
                   enabled: false
               },
               xAxis: {
                   min: 0.5,
                   minorGridLineWidth: 1,
                   max: 24,
                   tickInterval: 4,
                   gridLineWidth: 1,
                   categories: ['00:00h', '01:00h', '02:00h', '03:00h', '04:00h', '05:00h', '06:00h', '07:00h', '08:00h', '09:00h', '10:00h', '11:00h', '12:00h', '13:00h', '14:00h', '15:00h', '16:00h', '17:00h', '18:00h', '19:00h', '20:00h', '21:00h', '22:00h', '23:00h', '24:00h'],

               },
               yAxis: [{
                   gridLineWidth: 2,
                   lineWidth: 1,
                   tickWidth: 1,
                   tickAmount: 6,
                   min: $scope['forecast4'].min,
                   max: $scope['forecast4'].max,
                   title: {
                       text: 'feet'
                   }
               }, {
                   gridLineWidth: 2,
                   lineWidth: 1,
                   tickWidth: 1,
                   tickAmount: 6,
                   min: $scope['forecast4'].min,
                   max: $scope['forecast4'].max,
                   //min: $scope['forecast4'].minY,
                   //max: $scope['forecast4'].maxY,
                   title: {
                       text: 'feet'
                   },
                   opposite: true
               }],
               tooltip: {
                   pointFormat: '{series.name} is <b>{point.y:,.0f} feet </b><br/>at {point.x} Hrs'
               },
               legend: {
                   layout: 'vertical',
                   align: 'left',
                   verticalAlign: 'middle',
                   symbolHeight: 15,
                   symbolWidth: 12,
                   symbolRadius: 0
               },
               plotOptions: {
                   series: {
                       pointStart: 0
                   },
                   area: {
                       pointStart: 0,
                       marker: {
                           enabled: false,
                           symbol: 'square',
                           borderWidth: 4,
                           // borderRadius: 10,
                           states: {
                               hover: {
                                   enabled: true
                               }
                           }
                       }
                   }
               },
               series: $scope.forecast4,
           });
       }
       // fourth chart end
   })

/*------------3. controller for Optimizer goals chart  ----------------  */
   .controller('heatChartController', function ($scope, http, $filter, $rootScope) {
       /*-----first chart series data-------------------------*/
       function zeros(dimensions) {
           var array = [];
           for (var i = 0; i < dimensions[0]; ++i) {
               array.push(dimensions.length == 1 ? 0 : zeros(dimensions.slice(1)));
           }
           return array;
       }

       /* calling service for Real Time Optimization Objective radio button */
       var RealTimerdb = [];
       http.getOptimizationGoals(false, true).then(function (success) {
           if (success.status == 200) {
               var data = angular.fromJson(success.data);
               RealTimerdb = angular.fromJson(data.d);
           }
           if (RealTimerdb[0] == 0) {
               $scope.RTOptimization = 0;

           }
           else {
               $scope.RTOptimization = 1;
           }
       })

       /* calling service for Day Ahead Optimization Objective radio button */
       var DayAheadrdb = [];
       http.getOptimizationGoals(true, true).then(function (success) {
           if (success.status == 200) {
               var data = angular.fromJson(success.data);
               DayAheadrdb = angular.fromJson(data.d);
           }
           if (DayAheadrdb[0] == 0) {
               $scope.DAOptimization = 0;
           }
           else {
               $scope.DAOptimization = 1;
           }
       })

       $scope.chartDataSeries = {};
       $scope.chartDataSeries.seriesDataArray1 = zeros([24, 2]);
       $scope.chartDataSeries.seriesDataArray2 = zeros([24, 2]);
       $scope.seriesNameArray1 = [24];
       $scope.seriesNameArray2 = [24];
       $scope.ElecPrice = [];
       $scope.ElecPrice2 = [];
       http.getOptimizationGoals(false, false).then(function (success) {
           if (success.status == 200) {
               var data = angular.fromJson(success.data);
               $scope.seriesData1 = angular.fromJson(data.d);
               
               for (index = 0, len = $scope.seriesData1.length ; index < len; ++index) {
                   $scope.chartDataSeries.seriesDataArray1[index][1] = $scope.seriesData1[index].value;
                   $scope.seriesNameArray1[index] = $scope.seriesData1[index].name;
               }
               optChart2();
           }
       })
       http.getOptimizationGoals(true, false).then(function (success) {
           if (success.status == 200) {
               var data = angular.fromJson(success.data);
               $scope.seriesData2 = angular.fromJson(data.d);
               
               for (index = 0, len = $scope.seriesData2.length ; index < len; ++index) {
                   $scope.chartDataSeries.seriesDataArray2[index][1] = $scope.seriesData2[index].value;
                   $scope.seriesNameArray2[index] = $scope.seriesData2[index].name;
               }
               optChart4();
           }
       })

       /*-------- getting chart values ----------------*/
       var columnsArr = [];
       var httpFlag = false;
       var chartFlag = false;
       $scope.flag = 0;
       $scope.columnObj = {};
       var forecastLegend = [];
       $scope.chartSeries = {};
       http.getForecastLegend().then(function (success) {
           if (success.status == 200) {
               forecastLegend = angular.fromJson(success.data.d);
               $filter('filter')(forecastLegend, function (item) { return (item.Page == 3) }).forEach(function (item, index) {
                   columnsArr.push(angular.copy({ "Name": item.Name, "isToday": item.ChartAreaId == 2 ? true : false, "ChartID": item.ChartAreaId }));
               });
               $scope.flag = 0;
               $scope.columnObj = {};
               columnsArr.forEach(function (column) {
                   http.getChartDataByColumnName(column.isToday, column.Name).then(function (success) {
                       if (success.status == 200) {
                           var data = angular.fromJson(success.data);
                           $scope.columnObj[column.Name] = angular.fromJson(data.d);
                           $scope.flag = $scope.flag + 1;
                           httpFlag = true;
                       }
                   })
               })
           }
       })

       $scope.$watch('flag', function () {
           if ($scope.flag == columnsArr.length && httpFlag) {
               for (var i = 1; i < 3; i++) {
                   $scope['forecast' + i] = [];
                   var seriesData = $filter('filter')(forecastLegend, function (item) { return (item.Page == 3 && item.ChartAreaId == i) });
                   /*-------- Generating series dynamically -------*/
                   seriesData.forEach(function (item) {
                       var data = {
                           name: item.Legend,
                           data: $scope.columnObj[item.Name],
                           color: item.Color,
                           type: item.Type.toLowerCase(),
                           min: item.MinValue,
                           max: item.MaxValue,
                           //title: item.EngUnits
                       }
                       if (item.MajorAxis === 'Y2') {
                           data.yAxis = 1;
                       }
                       $scope['forecast' + i].push(angular.copy(data));
                   })
               }
               optChart1();
               optChart3();
           }
       });
       //**abhijeet
       // first chart start
       function optChart1() {
           console.log($scope.seriesData1);
           Highcharts.chart('container1', {
               title: {
                   text: ''
               },
               credits: {
                   enabled: false
               },
               subtitle: {
                   text: ''
               },
               exporting: {
                   enabled: false
               },
               xAxis: {
                   min: 0.5,
                   minorGridLineWidth: 1,
                   max: 24,
                   tickInterval: 4,
                   gridLineWidth: 1,
                   categories: ['00:00h', '01:00h', '02:00h', '03:00h', '04:00h', '05:00h', '06:00h', '07:00h', '08:00h', '09:00h', '10:00h', '11:00h', '12:00h', '13:00h', '14:00h', '15:00h', '16:00h', '17:00h', '18:00h', '19:00h', '20:00h', '21:00h', '22:00h', '23:00h', '24:00h'],

               },
               yAxis: [{
                   gridLineWidth: 2,
                   lineWidth: 1,
                   tickWidth: 1,
                   tickAmount: 7,
                   //min: 0,
                   // max: 60,
                   title: {
                       text: '$'
                   },

               }, {
                   gridLineWidth: 2,
                   lineWidth: 1,
                   tickWidth: 1,
                   tickAmount: 7,
                   //min: 0,
                   //max: 60,
                   title: {
                       text: '$'
                   },
                   opposite: true
               }],
               tooltip: {
                   pointFormat: '{series.name} is <b>{point.y:,.0f} $ </b><br/>at {point.x} Hrs'
               },
               legend: {
                   layout: 'vertical',
                   align: 'left',
                   verticalAlign: 'middle',
                   symbolHeight: 15,
                   symbolWidth: 12,
                   symbolRadius: 0
               },
               plotOptions: {
                   series: {
                       pointStart: 0
                   },
                   area: {
                       pointStart: 0,
                       marker: {
                           enabled: false,
                           symbol: 'square',
                           borderWidth: 4,
                           // borderRadius: 10,
                           states: {
                               hover: {
                                   enabled: true
                               }
                           }
                       }
                   }
               },
               series: $scope.forecast1
           });
       }
       // first chart end

       function optChart2() {
           // second chart start
           var chart2 = Highcharts.chart('containerHeat2', {

               chart: {
                   type: 'heatmap',
                   plotBackgroundImage: 'img/chartImages/HighChartOptimizer1.png',
               },
               title: {
                   text: 'Real Time Optimization Objective',
                   style: {
                       "fontSize": "12px"
                   }
               },
               xAxis: {
                   opposite: true,
                   tickLength: 0,
                   lineWidth: 0,
                   lineColor: 'transparent',
                   labels: {
                       enabled: false
                   },
               },

               yAxis: {
                   lineWidth: 0,
                   lineColor: 'transparent',
                   labels: {
                       enabled: false
                   },
                   title: null,
                   min: 0,
                   max: 1,
                   gridLineWidth: 0,
                   startOnTick: true,
                   endOnTick: false,
                   tickLength: 0

               },

               colorAxis: {
                   min: 1,
                   minColor: '#FFFFFF',
                   maxColor: '#6be51b'
               },
               credits: {
                   enabled: false
               },
               exporting: {
                   enabled: false
               },
               legend: {
                   enabled: false
               },
               tooltip: {
                   formatter: function () {
                       return '<b>' + '</b> Load is <br><b>' +
                           this.point.value + '</b>';
                   }
               },
               plotOptions: {
                   series: {
                       events: {
                           click: function (event, property) {
                               if (event.point.value == 'L') {
                                   $scope.clickedVal = 2;
                               }
                               else if (event.point.value == 'M') {
                                   $scope.clickedVal = 3;
                               }
                               else if (event.point.value == 'H') {
                                   $scope.clickedVal = 0;
                               }
                               else if (event.point.value == '') {
                                   $scope.clickedVal = 1;
                               }
                               $scope.chartDataSeries.seriesDataArray1[event.point.x][1] = angular.copy($scope.clickedVal);
                               chart2.series[0].update({
                                   data: angular.copy($scope.chartDataSeries.seriesDataArray1),
                               });
                           }
                       },
                       dataLabels: {
                           enabled: true,
                           formatter: function () {
                               varThis = this;

                               if (this.point.value == 0) {
                                   this.point.value = '';
                               }
                               else if (this.point.value == 1) {
                                   this.point.value = 'L';
                               }
                               else if (this.point.value == 2) {
                                   this.point.value = 'M';
                               }
                               else if (this.point.value == 3) {
                                   this.point.value = 'H';
                               }
                               return this.point.value;
                           }
                       }
                   }
               },
               series: [{
                   borderWidth: 1,
                   borderColor: 'black',
                   pointWidth: 128,
                   pointPadding: 1,
                   data: $scope.chartDataSeries.seriesDataArray1,
                   dataLabels: {
                       enabled: true,
                       color: 'black',
                       style: {
                           textShadow: 'none'
                       }
                   }
               }]

           });
       }
       // second chart end

       function optChart3() {
           // third chart start
           Highcharts.chart('container3', {
               chart: {
                   type: 'area'
               },
               title: {
                   text: ''
               },
               credits: {
                   enabled: false
               },
               subtitle: {
                   text: ''
               },
               exporting: {
                   enabled: false
               },
               xAxis: {
                   min: 0.5,
                   minorGridLineWidth: 1,
                   max: 24,
                   tickInterval: 4,
                   gridLineWidth: 1,
                   categories: ['00:00h', '01:00h', '02:00h', '03:00h', '04:00h', '05:00h', '06:00h', '07:00h', '08:00h', '09:00h', '10:00h', '11:00h', '12:00h', '13:00h', '14:00h', '15:00h', '16:00h', '17:00h', '18:00h', '19:00h', '20:00h', '21:00h', '22:00h', '23:00h', '24:00h'],

               },
               yAxis: [{
                   gridLineWidth: 2,
                   lineWidth: 1,
                   tickWidth: 1,
                   tickAmount: 7,
                   //min: 0,
                   //max: 60,
                   title: {
                       text: '$'
                   }
               }, {
                   gridLineWidth: 2,
                   lineWidth: 1,
                   tickWidth: 1,
                   tickAmount: 7,
                   //min: 0,
                   //max: 60,
                   title: {
                       text: '$'
                   },
                   opposite: true
               }],
               tooltip: {
                   pointFormat: '{series.name} is <b>{point.y:,.0f} $ </b><br/>at {point.x} Hrs'
               },
               legend: {
                   layout: 'vertical',
                   align: 'left',
                   verticalAlign: 'middle',
                   symbolHeight: 15,
                   symbolWidth: 12,
                   symbolRadius: 0
               },
               plotOptions: {
                   series: {
                       pointStart: 0
                   },
                   area: {
                       pointStart: 0,
                       marker: {
                           enabled: false,
                           symbol: 'square',
                           borderWidth: 4,
                           // borderRadius: 10,
                           states: {
                               hover: {
                                   enabled: true
                               }
                           }
                       }
                   }
               },
               series: $scope.forecast2,
           });
       }
       // third chart end


       function optChart4() {
           // fourth chart start
           console.log($scope.seriesData2);
           var chart4 = Highcharts.chart('containerHeat4', {

               chart: {
                   type: 'heatmap',
                   plotBackgroundImage: 'img/chartImages/HighChartOptimizer1.png',
               },

               title: {
                   text: 'Day Ahead Optimization Objective',
                   style: {
                       "fontSize": "12px"
                   }
               },

               xAxis: {
                   opposite: true,
                   tickLength: 0,
                   lineWidth: 0,
                   lineColor: 'transparent',
                   labels: {
                       enabled: false
                   },
               },

               yAxis: {
                   lineWidth: 0,
                   lineColor: 'transparent',
                   labels: {
                       enabled: false
                   },
                   title: null,
                   min: 0,
                   max: 1,
                   gridLineWidth: 0,
                   startOnTick: true,
                   endOnTick: false,
                   tickLength: 0
               },
               colorAxis: {
                   min: 1,
                   minColor: '#FFFFFF',
                   maxColor: '#6be51b'
               },
               credits: {
                   enabled: false
               },
               exporting: {
                   enabled: false
               },
               legend: {
                   enabled: false
               },
               tooltip: {
                   formatter: function () {
                       return '<b>' + this.series.xAxis.categories[this.point.x] + '</b> Load is <br><b>' +
                           this.point.value + '</b>';
                   }
               },
               plotOptions: {
                   series: {
                       events: {
                           click: function (event, property) {
                               if (event.point.value == 'L') {
                                   $scope.clickedVal = 2;
                               }
                               else if (event.point.value == 'M') {
                                   $scope.clickedVal = 3;
                               }
                               else if (event.point.value == 'H') {
                                   $scope.clickedVal = 0;
                               }
                               else if (event.point.value == '') {
                                   $scope.clickedVal = 1;
                               }
                               $scope.chartDataSeries.seriesDataArray2[event.point.x][1] = angular.copy($scope.clickedVal);
                               chart4.series[0].update({
                                   data: angular.copy($scope.chartDataSeries.seriesDataArray2),
                               });
                           }
                       },
                       dataLabels: {
                           enabled: true,
                           formatter: function () {
                               varThis = this;

                               if (this.point.value == 0) {
                                   this.point.value = '';
                               }
                               else if (this.point.value == 1) {
                                   this.point.value = 'L';
                               }
                               else if (this.point.value == 2) {
                                   this.point.value = 'M';
                               }
                               else if (this.point.value == 3) {
                                   this.point.value = 'H';
                               }
                               return this.point.value;
                           }
                       }
                   }
               },

               series: [{
                   name: '',
                   borderWidth: 1,
                   borderColor: 'black',
                   pointPadding: 128,
                   data: $scope.chartDataSeries.seriesDataArray2,
                   dataLabels: {
                       enabled: true,
                       color: 'black',
                       style: {
                           textShadow: 'none'
                       }
                   }
               }]
           });
       }
       $scope.CancelOptimizer = function () {
           alertify.confirm("Do you want to reset the form?").set('onok', function () {
               callServiceStatus();
           });
       }

       /*------- function for getting updated value of radio button ------*/
       $scope.OptimizationRT = function (isRTHeatRate) {
           if (isRTHeatRate == 'MaximizeNetPower') {
               $scope.RTOptimization = 0;
           }
           else {
               $scope.RTOptimization = 1;
           }
       }

       $scope.OptimizationDA = function (isDAHeatRate) {
           if (isDAHeatRate == 'MaximizeNetPower') {
               $scope.DAOptimization = 0;
           }
           else {
               $scope.DAOptimization = 1;
           }
       }

       //confirm popup when user want to reupdate code
       $rootScope.reUpdateOptimizer = function (sendSeries) {
           alertify.confirm("Do you want to reupdate the form?").set('onok', function () {
               $scope.UpdateOptimizerGoals(sendSeries);
           });
       }

       //function for login toggle
       var flg = 0;
       $rootScope.UpdateOptimizer = function () {
           var groupName = [];
           var optimizerSeriesObj = {};
           var rdbValue = [];
           $scope.DAOptimization = [];
           optimizerSeriesObj.chartSeries1 = [];
           optimizerSeriesObj.chartSeries2 = [];
           $scope.chartDataSeries.seriesDataArraySend1 = [];
           $scope.chartDataSeries.seriesDataArraySend2 = [];
           $scope.chartDataSeries.seriesDataArraySend1.push([{ RealTimeOptimization: $scope.RTOptimization }]);
           $scope.chartDataSeries.seriesDataArraySend2.push([{ DayAheadOptimization: $scope.DAOptimization }]);
           var Variable1 = [];
           var Variable2 = [];
           for (var i = 0; i < $scope.chartDataSeries.seriesDataArray1.length; i++) {
               Variable1.push($scope.seriesNameArray1[i]);
               $scope.chartDataSeries.seriesDataArraySend1.push(angular.copy([$scope.chartDataSeries.seriesDataArray1[i][1], Variable1[i]]));
           }
           for (var i = 0; i < $scope.chartDataSeries.seriesDataArray2.length; i++) {
               Variable2.push($scope.seriesNameArray2[i]);
               $scope.chartDataSeries.seriesDataArraySend2.push(angular.copy([$scope.chartDataSeries.seriesDataArray2[i][1], Variable2[i]]));
           }
           var sendSeries = [];
           sendSeries = $scope.chartDataSeries.seriesDataArraySend1.concat($scope.chartDataSeries.seriesDataArray2);

           if (sessionStorage.userName === null || sessionStorage.userName === undefined) {
               $('#myModal').modal('toggle');
           }
           else {
               if (flg == 0) {
                   $scope.UpdateOptimizerGoals(sendSeries);
                   flg = 1;
               }
               else {
                   $rootScope.reUpdateOptimizer(sendSeries);
               }
           }
       }

       /*-------- Updating OptimizerGoals Status values -----------------*/
       $scope.UpdateOptimizerGoals = function (groupName) {
           http.updateOptimizerGoals(groupName).then(function (success) {
               if (success.status == 200) {
                   var res = (success.data.d);
               }
           })
       }
   })

    /*-----------4. controller for getting data for status Page  ----------------  */
   .controller('operatorController', function ($scope, statusFactory, http) {
       getData();// for first load
       setInterval(function () {
           getData();
       }, 60000);

       function getData() {
           statusFactory.UpdateDashBoard().then(function () {
               $scope.status = statusFactory;
           }, function (error) {
           })
       }
       $scope.getValue = function (value, type) {
           switch (value) {
               case 0:
                   return type === 'color' ? 'idle' : 'Idle';
                   break;
               case 1:
                   return type === 'color' ? 'chargeMode' : 'Charge';
                   break;
               case 2:
                   return type === 'color' ? 'partdischarge' : 'Part Discharge';
                   break;
               case 3:
                   return type === 'color' ? 'fulldischarge' : 'Full Discharge';
                   break;
               case 4:
                   return type === 'color' ? 'chillers ' : 'Chillers ';
                   break;
               default:

           }
       }
   }
   )

    /*-----------5. controller for getting data for Equipment status page and forecast--------*/
    .controller('equipmentStatusController', function ($scope, http) {
        var statuslist = [];
        var varList = [];
        $scope.groupName = [];
        http.GetStatus().then(function (success) {
            if (success.status == 200) {
                $scope.statuses = angular.fromJson(success.data.d);
                statuslist = $scope.statuses;
                http.GetAvailabilityVariable().then(function (success) {
                    if (success.status == 200) {
                        $scope.variables = angular.fromJson(success.data.d);
                        varList = $scope.variables;
                        angular.forEach($scope.variables, function (i) {
                            angular.forEach($scope.statuses, function (j) {
                                if (j.Name == i.Variable) {
                                    var obj = {};
                                    obj.aliasName = i.Alias;
                                    obj.name = j.Name;
                                    if (j.Value == '0') {
                                        obj.color = 'red';
                                        obj.value = 'No';
                                    }
                                    else if (j.Value == '1') {
                                        obj.color = 'green';
                                        obj.value = 'Yes';
                                    }

                                    obj.dayAhead = i.DayAhead;
                                    obj.group = i.Group;
                                    $scope.groupName.push(angular.copy(obj));
                                }
                            });
                        });
                    }
                })
            }
        })
        $scope.changeColor = function (id) {
            if (id == "No")
                return { "background-color": "green" };
            else if (id == "Yes")
                return { "background-color": "red" };
        };
    })

    /*-----------6. controller for Equipment status ------------------*/
    .controller('statusController', function ($scope, http, $filter, $rootScope) {
        var statuslist = [];
        var varList = [];
        $scope.value = 0; $scope.chillers = [];
        $scope.secChillerValue = 0
        $scope.secChiller = [];
        $scope.groupName = [];
        $scope.equipmentStatus = {};
        $scope.equipmentStatus.combustionTurbinesRT = [];
        $scope.equipmentStatus.combustionTurbinesDA = [];
        $scope.equipmentStatus.chillerPackagesRT = [];
        $scope.equipmentStatus.chillerPackagesDA = [];
        $scope.equipmentStatus.secondaryChilledWaterPumpsRT = [];
        $scope.equipmentStatus.secondaryChilledWaterPumpsDA = [];
        $scope.equipmentStatus.hrsgDuctBurnersRT = [];
        $scope.equipmentStatus.hrsgDuctBurnersDA = [];
        $scope.equipmentStatus.steamTurbinesRT = [];
        $scope.equipmentStatus.steamTurbinesDA = [];
        $scope.equipmentStatus.tesTankRT = [];
        $scope.equipmentStatus.tesTankDA = [];
        http.GetStatus().then(function (success) {
            if (success.status == 200) {
                $scope.statuses = angular.fromJson(success.data.d);
                statuslist = $scope.statuses;
                http.GetAvailabilityVariable().then(function (success) {
                    if (success.status == 200) {
                        $scope.variables = angular.fromJson(success.data.d);
                        varList = $scope.variables;
                        angular.forEach($scope.variables, function (i) {
                            angular.forEach($scope.statuses, function (j) {
                                if (j.Name == i.Variable) {
                                    var obj = {};
                                    obj.aliasName = i.Alias;
                                    obj.name = j.Name;
                                    obj.variableType = i.dType;
                                    if (j.Value == '0') {
                                        obj.color = 'red';
                                        obj.value = 'No';
                                    }
                                    else if (j.Value == '1') {
                                        obj.color = 'green';
                                        obj.value = 'Yes';
                                    }

                                    obj.dayAhead = i.DayAhead;
                                    obj.group = i.Group;

                                    //for combustion turbine
                                    if (i.Group === '1' && i.DayAhead === 'RT') {
                                        $scope.equipmentStatus.combustionTurbinesRT.push(angular.copy(obj));
                                    }
                                    if (i.Group === '1' && i.DayAhead === 'DA') {
                                        $scope.equipmentStatus.combustionTurbinesDA.push(angular.copy(obj));
                                    }

                                    // for chillerPackages
                                    if (i.Group === '4' && i.DayAhead === 'RT') {
                                        $scope.equipmentStatus.chillerPackagesRT.push(angular.copy(obj));
                                    }
                                    if (i.Group === '4' && i.DayAhead === 'DA') {
                                        $scope.equipmentStatus.chillerPackagesDA.push(angular.copy(obj));
                                    }

                                    // for secondaryChilledWaterPumps
                                    if (i.Group === '5' && i.DayAhead === 'RT') {
                                        $scope.equipmentStatus.secondaryChilledWaterPumpsRT.push(angular.copy(obj));
                                    }
                                    if (i.Group === '5' && i.DayAhead === 'DA') {
                                        $scope.equipmentStatus.secondaryChilledWaterPumpsDA.push(angular.copy(obj));
                                    }

                                    // for HRSG
                                    if (i.Group === '2' && i.DayAhead === 'RT') {
                                        $scope.equipmentStatus.hrsgDuctBurnersRT.push(angular.copy(obj));
                                    }
                                    if (i.Group === '2' && i.DayAhead === 'DA') {
                                        $scope.equipmentStatus.hrsgDuctBurnersDA.push(angular.copy(obj));
                                    }

                                    // for Steam Turbines
                                    if (i.Group === '3' && i.DayAhead === 'RT') {
                                        $scope.equipmentStatus.steamTurbinesRT.push(angular.copy(obj));
                                    }
                                    if (i.Group === '3' && i.DayAhead === 'DA') {
                                        $scope.equipmentStatus.steamTurbinesDA.push(angular.copy(obj));
                                    }

                                    // for TES Tank
                                    if (i.Group === '6' && i.DayAhead === 'RT') {
                                        $scope.equipmentStatus.tesTankRT.push(angular.copy(obj));
                                    }
                                    if (i.Group === '6' && i.DayAhead === 'DA') {
                                        $scope.equipmentStatus.tesTankDA.push(angular.copy(obj));
                                    }

                                    if (i.Group === '4' && i.DayAhead === 'DA') {
                                        $scope.value = $scope.value + 1
                                        $scope.chillers.push($scope.value);
                                    }

                                    if (i.Group === '5' && i.DayAhead === 'DA') {
                                        $scope.secChillerValue = $scope.secChillerValue + 1
                                        $scope.secChiller.push($scope.secChillerValue);
                                    }
                                }
                            });
                        });
                    }
                })
            }
        })
        $scope.changeColor = function (id) {
            if (id == "No")
                return { "background-color": "green" };
            else if (id == "Yes")
                return { "background-color": "red" };
        };
        $scope.changeRunOrder = function (index, length) {
            if ($scope.chillers[index] < length)
                $scope.chillers[index] = $scope.chillers[index] + 1
            else
                $scope.chillers[index] = 1;
        }

        $scope.secondaryRunOrder = function (index, length) {
            if ($scope.secChiller[index] < length) {
                if ($scope.secChiller[index] <= length) {
                    $scope.secChiller[index] = $scope.secChiller[index] + 1
                }
                else {
                    $scope.secChiller[index] = $scope.secChiller[index] + 2
                }
            }
            else {
                $scope.secChiller[index] = 1;
            }
        }

        function callServiceStatus() {

            var statuslist = [];
            var varList = [];
            $scope.groupName = [];
            http.GetStatus().then(function (success) {
                if (success.status == 200) {
                    $scope.statuses = angular.fromJson(success.data.d);
                    statuslist = $scope.statuses;
                    http.GetAvailabilityVariable().then(function (success) {
                        if (success.status == 200) {
                            $scope.variables = angular.fromJson(success.data.d);
                            varList = $scope.variables;
                            angular.forEach($scope.variables, function (i) {
                                angular.forEach($scope.statuses, function (j, index) {
                                    if (j.Name == i.Variable) {
                                        var obj = {};
                                        obj.aliasName = i.Alias;
                                        obj.name = j.Name;
                                        if (j.Value == '0') {
                                            obj.color = 'red';
                                            obj.value = 'No';
                                        }
                                        else if (j.Value == '1') {
                                            obj.color = 'green';
                                            obj.value = 'Yes';
                                        }

                                        obj.dayAhead = i.DayAhead;
                                        obj.group = i.Group;
                                        $scope.groupName.push(angular.copy(obj));
                                    }
                                });
                            });
                        }
                    })
                }
            })
            $scope.changeColor = function (id) {
                if (id == "No")
                    return { "background-color": "green" };
                else if (id == "Yes")
                    return { "background-color": "red" };
            };
        }

        $rootScope.reupdateEquipStatus = function (sendSeries) {
            alertify.confirm("Do you want to reupdate the form?").set('onok', function () {
                $scope.updateEquipStatus(sendSeries);
            });
        }

        //function for login toggle
        $rootScope.updateEquipStatus = function () {
            if (sessionStorage.userName === null || sessionStorage.userName === undefined) {
                $('#myModal').modal('toggle');
            }
            else {
                var groupName = [];
                Object.keys($scope.equipmentStatus).forEach(function (key) {
                    $scope.equipmentStatus[key].forEach(function (obj) {
                        groupName.push(angular.copy(obj));
                    })

                })

                $scope.UpdateEquipmentStatus(groupName);
            }
        }

        // Updating Equipment Status values 
        $scope.UpdateEquipmentStatus = function (groupName) {
            http.updateEquimentStatus(groupName).then(function (success) {
                if (success.status == 200) {
                    var res = (success.data.d);
                }
            })
        }

        // Canceling EquipmentSetting values 
        $scope.CancelEquipmentStatus = function () {
            alertify.confirm("Do you want to reset the form?").set('onok', function () {
                callServiceStatus();
            });
        }

        // function for changing the button text 
        var btnTxtObj = {};
        //btnTxtObj.btnUpdate = [];
        $scope.Reverse = function (groupName, index) {
            if ($scope.equipmentStatus[groupName][index].value == "No") {
                $scope.equipmentStatus[groupName][index].value = "Yes";
            } else {
                $scope.equipmentStatus[groupName][index].value = "No";
            }
        }
    })

    /*-----------7. controller for Equipment setting ------------------*/
    .controller('settingController', function ($scope, http, $rootScope) {
        var statuslist = [];
        var varList = [];
        $scope.groupName = [];

        http.GetSettingValue().then(function (success) {
            if (success.status == 200) {
                $scope.statuses = angular.fromJson(success.data.d);
                statuslist = $scope.statuses;
                http.GetEngineerSettingVariable().then(function (success) {
                    if (success.status == 200) {
                        $scope.variables = angular.fromJson(success.data.d);
                        varList = $scope.variables;

                        angular.forEach($scope.variables, function (i) {
                            angular.forEach($scope.statuses, function (j) {
                                if (j.Name == i.Variable) {
                                    var obj = {};
                                    obj.aliasName = i.Alias;
                                    if (j.Name.indexOf("Max") >= 0) {
                                        obj.max = "true";
                                    }
                                    else if (j.Name.indexOf("Min") >= 0) {
                                        obj.max = "false";
                                    }
                                    if (j.Name.indexOf("Start") >= 0) {
                                        obj.start = "true";
                                    }
                                    else {
                                        obj.start = "false";
                                    }
                                    obj.value = j.Value;
                                    obj.name = j.Name;
                                    obj.group = i.Group;
                                    $scope.groupName.push(angular.copy(obj));
                                }
                            });

                        });
                    }
                })
            }
        })



        $scope.changeColor = function (id) {
            if (id == "No")
                return { "background-color": "green" };
            else if (id == "Yes")
                return { "background-color": "red" };
        };

        //function for login toggle
        $rootScope.UpdateInfo = function () {
            if (sessionStorage.userName === null || sessionStorage.userName === undefined) {
                $('#myModal').modal('toggle');
            }
            else {
                $scope.UpdateEquipment();
            }
        }
        function callService() {
            var statuslist = [];
            var varList = [];
            $scope.groupName = [];

            http.GetSettingValue().then(function (success) {
                if (success.status == 200) {
                    $scope.statuses = angular.fromJson(success.data.d);
                    statuslist = $scope.statuses;
                    http.GetEngineerSettingVariable().then(function (success) {
                        if (success.status == 200) {
                            $scope.variables = angular.fromJson(success.data.d);
                            varList = $scope.variables;

                            angular.forEach($scope.variables, function (i) {
                                angular.forEach($scope.statuses, function (j) {
                                    if (j.Name == i.Variable) {
                                        var obj = {};
                                        obj.aliasName = i.Alias;
                                        if (j.Name.indexOf("Max") >= 0) {
                                            obj.max = "true";
                                        }
                                        else if (j.Name.indexOf("Min") >= 0) {
                                            obj.max = "false";
                                        }
                                        if (j.Name.indexOf("Start") >= 0) {
                                            obj.start = "true";
                                        }
                                        else {
                                            obj.start = "false";
                                        }
                                        obj.value = j.Value;
                                        obj.name = j.Name;
                                        obj.group = i.Group;
                                        $scope.groupName.push(angular.copy(obj));
                                    }
                                });

                            });
                        }
                    })
                }
            })

            //calling function 
            $scope.changeColor = function (id) {
                if (id == "No")
                    return { "background-color": "green" };
                else if (id == "Yes")
                    return { "background-color": "red" };
            };
        }



        // Updating EquipmentSetting values 
        $scope.UpdateEquipment = function () {
            http.updateEquipSetting($scope.groupName).then(function (success) {
                if (success.status == 200) {
                    var res = (success.data.d);
                }
            })
        }

        // Canceling EquipmentSetting values 
        $scope.CancelEquipment = function () {
            alertify.confirm("Do you want to reset the form?").set('onok', function () {
                callService();
            });
        }

        //Authenticateing user login
        //$scope.AuthenticateUser = function () {
        //    alert('call');
        //}
    })

    /*------------ Adding controller for the ideal time out ----------- */
   .controller('IdealCtrl', function ($scope, Idle, Keepalive, $uibModal, $timeout, http) {
       /*-------- service fro getting county name from setting file -----------------*/
       http.getCountryName().then(function (success) {
           if (success.status == 200) {
               var res = angular.fromJson(success.data.d);
               $scope.CountyName = res[0].Site;
           }
       })

       $scope.started = false;
       function closeModals() {
           if ($scope.warning) {
               $scope.warning.close();
               $scope.warning = null;
           }

           if ($scope.timedout) {
               $scope.timedout.close();
               $scope.timedout = null;
           }
       }

       $scope.$on('IdleStart', function () {
           // alert('IdleStart');
           closeModals();
           $timeout(function () {
               $scope.warning = $uibModal.open({
                   templateUrl: 'warning-dialog.html',
                   windowClass: 'modal-danger'
               });
           }, 590000)

       });

       $scope.$on('IdleEnd', function () {
           closeModals();
           //  alert('IdleEnd');
       });

       $scope.$on('IdleTimeout', function () {
           // alert('IdleTimeout');
           closeModals();
           $scope.timedout = $uibModal.open({
               templateUrl: 'timedout-dialog.html',
               windowClass: 'modal-danger'
           });
           delete sessionStorage.userName;
           //sessionStorage.clear();
       });

       $scope.start = function () {
           function start() {
               closeModals();
               Idle.watch();
               $scope.started = true;
           };

           $scope.stop = function () {
               closeModals();
               Idle.unwatch();
               $scope.started = false;

           }
       }
   })
    .controller('loginCtrl', function ($scope, Idle, http, $rootScope) {
        $scope.AuthenticateUser = function () {
            var flag = sessionStorage.getItem("function");
            http.userLogin($scope.userName, $scope.password).then(function (success) {
                if (success.status == 200) {
                    $scope.res = (success.data.d);
                    //defer.resolve(true);
                    if ($scope.res > 0) {
                        sessionStorage.setItem('userName', $scope.userName);
                        $scope.$on('IdleStart', function () { });
                        Idle.watch();
                        $('#myModal').modal('toggle');
                        if (flag == 'UpdateOptimizer') {
                            $rootScope.UpdateOptimizer();
                        }
                        else if (flag == 'UpdateStatus') {
                            $rootScope.updateEquipStatus();
                        }
                        else if (flag == 'UpdateStatus') {
                            $rootScope.UpdateInfo();
                        }

                    }
                    else {
                        $scope.errormsg = 'Invalid user name or password';
                    }
                }
            })
        }



    });


})();