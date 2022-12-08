google.load("visualization", "1", { packages: ["corechart"] });
google.setOnLoadCallback(drawChart1);
function drawChart1() {
    var data = google.visualization.arrayToDataTable([
        ['Dias', 'Vistas', 'Ventas'],
        ['Lunes', 1000, 800],
        ['Martes', 1170, 460],
        ['Miercoles', 1200, 1120],
        ['Jueves', 1030, 540],
        ['Viernes', 1000, 900],
        ['Sabado', 570, 460],
        ['Domingo', 660, 520],
    ]);

    var options = {
        title: 'Ventas en los ultimos 7 dias',
        hAxis: { title: 'Ventas', titleTextStyle: { color: '#333' } }
    };

    var chart = new google.visualization.ColumnChart(document.getElementById('chart_div1'));
    chart.draw(data, options);
}

google.load("visualization", "1", { packages: ["corechart"] });
google.setOnLoadCallback(drawChart2);
function drawChart2() {
    var data = google.visualization.arrayToDataTable([
        ['Meses', 'Vistas', 'Ventas'],
        ['JUN', 1170, 460],
        ['JUL', 760, 920],
        ['AGO', 1030, 540],
        ['SEP', 1200, 460],
        ['OCT', 860, 820],
        ['NOV', 1030, 540]
    ]);

    var options = {
        title: 'Ventas de los ultimos 6 meses',
        hAxis: { title: 'ultimos 6 meses', titleTextStyle: { color: '#333' } },
        vAxis: { minValue: 0 }
    };

    var chart = new google.visualization.AreaChart(document.getElementById('chart_div2'));
    chart.draw(data, options);
}

$(window).resize(function () {
    drawChart1();
    drawChart2();
});


//var data = google.visualization.arrayToDataTable([
//    ['Meses', 'Vistas', 'Ventas'],
//    ['JUN', 1170, 460],
//    ['JUL', 660, 1120],
//    ['AGO', 1030, 540]
//    ['SEP', 1170, 460],
//    ['OCT', 660, 1120],
//    ['NOV', 1030, 540]
//]);

//var options = {
//    title: 'Ventas de los ultimos 6 meses',
//    hAxis: { title: 'Year', titleTextStyle: { color: '#333' } },
//    vAxis: { minValue: 0 }
//};