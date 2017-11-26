<%@ Page Title="" Language="C#" MasterPageFile="~/OperatorMaster.Master" AutoEventWireup="true" CodeBehind="Forecast.aspx.cs" Inherits="RTP.TESWebServer.Forecast" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="js/plugin/alasql.min.js"></script>
    <script src="js/plugin/xlsx.core.min.js"></script>
    <style>
        body {
            margin-top: 55px;
        }

        .checkbox label:after,
        .radio label:after {
            content: '';
            display: table;
            clear: both;
        }

        .checkbox .cr,
        .radio .cr {
            position: relative;
            display: inline-block;
            border: 1px solid #a9a9a9;
            border-radius: .25em;
            width: 1.3em;
            height: 1.3em;
            float: left;
            margin-right: .5em;
        }

        .radio .cr {
            border-radius: 50%;
        }

            .checkbox .cr .cr-icon,
            .radio .cr .cr-icon {
                position: absolute;
                font-size: .8em;
                line-height: 0;
                top: 50%;
                left: 20%;
            }

            .radio .cr .cr-icon {
                margin-left: 0.04em;
            }

        .checkbox label input[type="checkbox"],
        .radio label input[type="radio"] {
            display: none;
        }

            .checkbox label input[type="checkbox"] + .cr > .cr-icon,
            .radio label input[type="radio"] + .cr > .cr-icon {
                transform: scale(3) rotateZ(-20deg);
                opacity: 0;
                transition: all .3s ease-in;
            }

            .checkbox label input[type="checkbox"]:checked + .cr > .cr-icon,
            .radio label input[type="radio"]:checked + .cr > .cr-icon {
                transform: scale(1) rotateZ(0deg);
                opacity: 1;
            }

            .checkbox label input[type="checkbox"]:disabled + .cr,
            .radio label input[type="radio"]:disabled + .cr {
                opacity: .5;
            }

        table {
            border-collapse: collapse;
        }

        .ulli {
            list-style: none;
        }

        .divide {
            border-right: 1px solid #ccc;
            padding-right: 10px;
            margin-right: -10px;
        }

        @media only screen and (max-width: 360px) {
            body {
                margin-top: 80px;
            }
        }

        @media only screen and (max-width: 768px) {
            body {
                margin-top: 165px;
            }
        }


        @media only screen and (max-width: 980px) {
            body {
                margin-top: 100px;
            }
        }

        h4, .h4, h5, .h5, h6, .h6 {
            margin-top: 4px;
            margin-bottom: 4px;
        }
    </style>
    <script>
        $(document).ready(function () {
            $("#navText").text("Thermal Energy Storage Real Time Forecast");
        })
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container dvBlock" ng-app="myApp">
        <h2>Thermal Energy Storage Forecast</h2>
        <div class="row">

            <div class="col-lg-2 col-md-2 col-xs-12  divide" ng-controller="equipmentStatusController">
                <div class="row" style="padding: 5px;">
                    <table class="tbl">
                        <tr>
                            <th style="font-style: italic; text-align: right; width: 50%">Equipment</th>
                            <th style="font-style: italic; text-align: right">Available</th>
                        </tr>
                    </table>
                    <div class="dvBlockSq">
                        <h2 style="font-style: italic">CT</h2>
                        <table class="tbl">
                            <%--<tr>
                                <th style="font-style: italic; text-align: right"></th>
                            </tr>--%>

                            <tr ng-repeat="group in groupName|filter:{group:'1',dayAhead:'DA'}">
                                <td style="text-align: right; width: 50%">
                                    <h6>{{group.aliasName}}</h6>
                                </td>
                                <td style="text-align: center">
                                    <h6>{{group.value}}</h6>
                                </td>
                            </tr>

                        </table>
                    </div>


                    <div class="col-lg-12 dvBlockSq" style="margin-top: 2px;">
                        <h2 style="font-style: italic">Chiller</h2>
                        <table class="tbl">
                            <tr ng-repeat="group in groupName|filter:{group:'4',dayAhead:'DA'}">
                                <td style="text-align: right; width: 50%">
                                    <h6>{{group.aliasName}}</h6>
                                </td>
                                <td style="text-align: center">
                                    <h6>{{group.value}}</h6>
                                </td>
                            </tr>

                        </table>
                    </div>

                    <div class="dvBlockSq" style="margin-top: 2px">
                        <h2 style="font-style: italic">Sec Pump</h2>
                        <table class="tbl">

                            <tr ng-repeat="group in groupName|filter:{group:'5',dayAhead:'DA'}">
                                <td style="text-align: right; width: 50%">
                                    <h6>{{group.aliasName}}</h6>
                                </td>
                                <td style="text-align: center">
                                    <h6>{{group.value}}</h6>
                                </td>
                            </tr>

                        </table>
                    </div>

                    <div class="dvBlockSq" style="margin-top: 2px">
                        <h2 style="font-style: italic">Duct Burn</h2>
                        <table class="tbl">
                            <tr ng-repeat="group in groupName|filter:{group:'2',dayAhead:'DA'}">
                                <td style="text-align: right; width: 50%">
                                    <h6>{{group.aliasName}}</h6>
                                </td>
                                <td style="text-align: center">
                                    <h6>{{group.value}}</h6>
                                </td>
                            </tr>

                        </table>
                    </div>

                    <div class="dvBlockSq" style="margin-top: 2px">
                        <h2 style="font-style: italic">Steam Turbine</h2>
                        <table class="tbl">
                            <tr ng-repeat="group in groupName|filter:{group:'3',dayAhead:'DA'}">
                                <td style="text-align: right; width: 50%">
                                    <h6>{{group.aliasName}}</h6>
                                </td>
                                <td style="text-align: center">
                                    <h6>{{group.value}}</h6>
                                </td>
                            </tr>

                        </table>
                    </div>

                    <div class="col-lg-12 dvBlockSq" style="margin-top: 2px;">
                        <h2 style="font-style: italic">Cooling coil</h2>
                        <table class="tbl">
                            <tr ng-repeat="group in groupName|filter:{group:'4',dayAhead:'DA'}">
                                <td style="text-align: right; width: 50%">
                                    <h6>{{group.aliasName}}</h6>
                                </td>
                                <td style="text-align: center">
                                    <h6>{{group.value}}</h6>
                                </td>
                            </tr>

                        </table>
                    </div>
                </div>

            </div>


            <!--Chart Start-->
            <div class="col-lg-9 col-md-9 col-xs-12" style="margin-left: 25px;" ng-controller="forecastController">
                <div class="col-lg-5" style="margin-top: 10px;">
                    <input id="ViewAllCopy" class="btn btn-default" type="button" value="{{btnLabel}}" title='Charts' ng-click="showTableChart()" />
                    <button type="button" class="btn btn-default" ng-click="callRTDAChart()" data-target="#vote">{{btnText}}</button>
                </div>
                <div class="col-lg-4" style="padding: 10px;">
                    <span style="margin-top: 6px; color: #777; font-weight: bold">{{selectedChart}}</span><span> ({{rtDate}})</span>
                </div>

                <div class="col-lg-2" style="padding-top: 6px;">
                    <button type="button" class="btn btn-default" ng-click="" data-target="#vote">Search</button>
                </div>

                <div class="col-lg-1" style="padding-top: 6px;">
                    <input type="button" class="btn btn-default" value="Export Table" ng-show="expTable" ng-click="exportTable()" />
                </div>

                <!-- Modal -->
                <div class="modal fade" id="vote" tabindex="-1" role="dialog" aria-labelledby="voteLabel" aria-hidden="true">
                    <div class="modal-dialog">
                        <div class="panel panel-primary">
                            <div class="panel-heading">
                                <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
                                <h6 class="panel-title" id="voteLabel">Please select a combination</h6>
                            </div>
                            <div class="modal-body">
                                <ul class="list-group">
                                    <li class="list-group-item">
                                        <label class="checkbox-inline">
                                            <input type="checkbox" value="">1X1</label>
                                    </li>
                                    <li class="list-group-item">
                                        <li class="list-group-item">
                                            <label class="checkbox-inline">
                                                <input type="checkbox" value="">1X2</label>
                                        </li>
                                    </li>
                                    <li class="list-group-item">
                                        <li class="list-group-item">
                                            <label class="checkbox-inline">
                                                <input type="checkbox" value="" />1X3</label>
                                        </li>
                                    </li>

                                </ul>
                            </div>
                            <div class="modal-footer">
                                <button type="button" class="btn btn-success btn-vote">Okay</button>
                            </div>
                        </div>
                    </div>
                </div>

                <div ng-show="tableShow">
                    <ul ng-repeat="retData in retData.textFileResult">
                        <li>{{retData}}</li>
                    </ul>
                </div>

                <%----------Chart series -------------------------------------------------%>
                <div ng-show="chartShow">
                    <div class="row">
                        <div id="container1" style="height: 150px; padding-left: 0.3%;"></div>
                    </div>
                    <div class="row">
                        <div id="container2" style="height: 150px; margin-top: 5%;"></div>
                    </div>
                    <div class="row">
                        <div id="container3" style="height: 150px;"></div>
                    </div>
                    <div class="row">
                        <div id="container4" style="height: 150px;"></div>
                    </div>
                </div>

                <!-- Adding table charts -->
                <div ng-show="tableShow" style="height: 300px">
                    <div class="row">
                        <div class="col-lg-12">
                            <table class="table table-responsive">
                                <thead>
                                    <tr>
                                        <th>Hour</th>
                                        <th ng-repeat="alias in tableData1">{{alias.name}}</th>
                                        <th ng-repeat="alias in tableData2">{{alias.name}}</th>
                                        <th ng-repeat="alias in tableData3">{{alias.name}}</th>
                                        <th ng-repeat="alias in tableData4">{{alias.name}}</th>

                                    </tr>
                                    <tr>
                                        <th></th>
                                        <td ng-repeat="engUnit in tableData1">{{engUnit.EngUnits}}</td>
                                        <td ng-repeat="engUnit in tableData2">{{engUnit.EngUnits}}</td>
                                        <td ng-repeat="engUnit in tableData3">{{engUnit.EngUnits}}</td>
                                        <td ng-repeat="engUnit in tableData4">{{engUnit.EngUnits}}</td>
                                    </tr>
                                </thead>
                                <tbody>
                                    <tr>
                                        <td>
                                            <!--0 column hours-->
                                            <table class="table table-sm table-inverse">
                                                <tr ng-repeat="num in [1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24]">
                                                    <td>{{num}}</td>
                                                </tr>
                                            </table>
                                        </td>

                                        <td>
                                            <!--1 column AmbPress-->
                                            <table class="table table-sm table-inverse">
                                                <tr ng-repeat="num in columnObj.AmbPress track by $index">
                                                    <td>{{num|number:2 }}</td>
                                                </tr>
                                            </table>
                                        </td>
                                        <td>
                                            <!--2 column AmbRH-->
                                            <table class="table table-sm table-inverse">
                                                <tr ng-repeat="num in columnObj.AmbRH track by $index">
                                                    <td>{{num|number:2 }}</td>
                                                </tr>
                                            </table>
                                        </td>

                                        <td>
                                            <!--3 column AmbTemp-->
                                            <table class="table table-sm table-inverse">
                                                <tr ng-repeat="num2 in columnObj.AmbTemp track by $index">
                                                    <td>{{num2|number:2 }}</td>
                                                </tr>
                                            </table>
                                        </td>

                                        <!--4 column AmbTdew-->
                                        <td>
                                            <table class="table table-sm table-inverse">
                                                <tr ng-repeat="num2 in columnObj.AmbTdew track by $index">
                                                    <td>{{num2|number:2 }}</td>

                                                </tr>
                                            </table>
                                        </td>

                                        <!--5 column CT2Gen-->
                                        <td style="background-color: #f7f1ef">
                                            <table class="table table-sm table-inverse">
                                                <tr ng-repeat="num2 in columnObj.CT2Gen track by $index" style="background-color: #f7f1ef">
                                                    <td>{{num2|number:2 }}</td>

                                                </tr>
                                            </table>
                                        </td>

                                        <!--6 CT3Gen-->
                                        <td style="background-color: #f7f1ef">
                                            <table class="table table-sm table-inverse">
                                                <tr ng-repeat="num in columnObj.CT3Gen track by $index" style="background-color: #f7f1ef">
                                                    <td>{{num|number:2 }}</td>
                                                </tr>
                                            </table>
                                        </td>
                                        <!--7-->
                                        <td style="background-color: #f7f1ef">
                                            <table class="table table-sm table-inverse">
                                                <tr ng-repeat="num in columnObj.CT4Gen track by $index" style="background-color: #f7f1ef">
                                                    <td>{{num|number:2 }}</td>
                                                </tr>
                                            </table>
                                        </td>

                                        <!--8-->
                                        <td style="background-color: #cfe6f7">
                                            <table class="table table-sm table-inverse">
                                                <tr ng-repeat="num in columnObj.STGen track by $index" style="background-color: #cfe6f7">
                                                    <td>{{num|number:2 }}</td>
                                                </tr>
                                            </table>
                                        </td>
                                        <!--9-->
                                        <td style="background-color: #c2c3c4">
                                            <table class="table table-sm table-inverse">
                                                <tr ng-repeat="num in columnObj.NetPower track by $index" style="background-color: #c2c3c4">
                                                    <td>{{num|number:2 }}</td>
                                                </tr>
                                            </table>
                                        </td>

                                        <!--10-->
                                        <td style="background-color: #c2c3c4">
                                            <table class="table table-sm table-inverse">
                                                <tr ng-repeat="num in columnObj.NetHR track by $index" style="background-color: #c2c3c4">
                                                    <td>{{num|number:2 }}</td>
                                                </tr>
                                            </table>
                                        </td>
                                        <!--11-->
                                        <td>
                                            <table class="table table-sm table-inverse">
                                                <tr ng-repeat="num in columnObj.TankLevel track by $index">
                                                    <td>{{num}}</td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>

                        </div>

                    </div>
                </div>

            </div>
        </div>
    </div>
</asp:Content>
