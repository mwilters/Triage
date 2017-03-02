
var myApp = angular.module('TriageAnalyticsApp', ['ngRoute']);

    $(document)
        .ready(function () {
            // Load the Visualization API and the corechart package.
            //google.charts.load('current', { 'packages': ['corechart'] });

            // Set a callback to run when the Google Visualization API is loaded.
            //google.charts.setOnLoadCallback(drawChart);
            //google.charts.setOnLoadCallback(drawScatterChart);
            // Callback that creates and populates a data table,
            // instantiates the pie chart, passes in the data and
            // draws it.
        });

    myApp.controller('AnalyticsCtlr', ['$scope', '$http','$window',
          function ($scope, $http, $window) {

              $scope.AnalyticsInitializer = function () {
                  //added this here and removed the default load function
                  google.charts.load('current', { 'packages': ['corechart', 'bar'] });

                  $scope.drawCharts();

              };

              $scope.drawCharts = function () {
                  var parameters = {
                  };

                  var config = {
                      params: parameters
                  };

                  $http.get('api/Analytics', config).success(function (data, status, headers, config) {
                      $scope.data = data;

                      ////////Charts//////
                      google.charts.setOnLoadCallback(drawClinicalTrialsLevels);
                      google.charts.setOnLoadCallback(drawPathReviewLevels);
                      google.charts.setOnLoadCallback(drawDiagnosisLevels);
                      google.charts.setOnLoadCallback(drawDoctorLevels);
                  }).
                  error(function (data, status, headers, config) {
                      alert("Error");
                  });
              }

              function drawClinicalTrialsLevels() {

                  var data = google.visualization.arrayToDataTable([
                  ['Task', 'Hours per Day'],
                  ['Title',0]
                  ]);

                  var hasClinicalTrials = 0;
                  var notClinicalTrials = 0;

                  //Loop through $scope.data and count clinical trials
                  for (i = 0; i < $scope.data.length; i++) {
                      if ($scope.data[i].clinicalTrials) {
                          hasClinicalTrials++;
                      }
                      else {
                          notClinicalTrials++;
                      }
                  }

                  data.addRows([
                    ['On Clinical Trials', hasClinicalTrials],
                    ['Not On Clinical Trials', notClinicalTrials],
                  ]);

                  // Set chart options
                  var options = {
                      'title': 'Clinical Trials Distribution',
                      'width': 400,
                      'height': 300
                  };

                  // Instantiate and draw our chart, passing in some options.
                  var chart = new google.visualization.PieChart(document.getElementById('clinicalTrials_chart_div'));
                  chart.draw(data, options);
              }

              function drawPathReviewLevels() {

                  var data = google.visualization.arrayToDataTable([
                  ['Task', 'Hours per Day'],
                  ['Title', 0]
                  ]);

                  var hasPathReview = 0;
                  var notPathReview = 0;

                  //Loop through $scope.data and count path reviews
                  for (i = 0; i < $scope.data.length; i++) {
                      if ($scope.data[i].pathReview) {
                          hasPathReview++;
                      }
                      else {
                          notPathReview++;
                      }
                  }

                  data.addRows([
                    ['Path Reviewed', hasPathReview],
                    ['Not Path Reviewed', notPathReview],
                  ]);

                  // Set chart options
                  var options = {
                      'title': 'Path Review Distribution',
                      'width': 400,
                      'height': 300
                  };

                  // Instantiate and draw our chart, passing in some options.
                  var chart = new google.visualization.PieChart(document.getElementById('pathReview_chart_div'));
                  chart.draw(data, options);
              }

              function drawDiagnosisLevels() {
                  var desc = "";
                  var totalQty = 0;

                  var data = google.visualization.arrayToDataTable([
                       ['Diagnosis', 'Diagnosis', { role: 'annotation' }],
                       ['Total', totalQty, totalQty],
                  ]);

                  var obj = { };
                  for (var i = 0, j = $scope.data.length; i < j; i++) {
                      obj[$scope.data[i].diagnosis.description] = (obj[$scope.data[i].diagnosis.description] || 0) + 1;
                  }

                  for (var key in obj) {
                      desc = key.toString();
                      totalQty = obj[key];
                      data.addRow([desc, totalQty, totalQty]);
                  }

                  var options = {
                      'title': 'Diagnosis Distribution',
                      legend: { position: 'right', maxLines: 1 },
                      hAxis: {
                          title: 'Diagnosis',
                      },
                      bar: { groupWidth: '50%' },
                      bars: 'horizontal',
                      colors: ['#0c7ec2'],
                      backgroundColor: { fill: 'transparent' },
                  };

                  var chart = new google.visualization.ColumnChart(document.getElementById('diagnosis_chart_div'));
                  chart.draw(data, options);
              }

              function drawDoctorLevels() {
                  var desc = "";
                  var totalQty = 0;

                  var data = google.visualization.arrayToDataTable([
                       ['Doctors', 'Patients', { role: 'annotation' }],
                       ['Total', totalQty, totalQty],
                  ]);

                  var obj = {};
                  for (var i = 0, j = $scope.data.length; i < j; i++) {
                      obj[$scope.data[i].doctor.name] = (obj[$scope.data[i].doctor.name] || 0) + 1;
                  }

                  for (var key in obj) {
                      desc = key.toString();
                      totalQty = obj[key];
                      data.addRow([desc, totalQty, totalQty]);
                  }

                  var options = {
                      'title': 'Patient Distribution',
                      legend: { position: 'right', maxLines: 1 },
                      hAxis: {
                          title: 'Doctor',
                      },
                      bar: { groupWidth: '50%' },
                      bars: 'horizontal',
                      colors: ['#39c051'],
                      backgroundColor: { fill: 'transparent' },
                  };

                  var chart = new google.visualization.ColumnChart(document.getElementById('doctor_chart_div'));
                  chart.draw(data, options);
              }
          
    }]);

