// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$('.escolhaMes').on('change', function () {
    var ordem = $('.escolhaMes').val();
    $.ajax({
        url: "Despesas/GastosMes",
        method: "POST",
        data: { ordem: ordem },
        success: function (dados) {
            $('canvas#graficoGastosMes').remove();
            $('div.graficoGastosMes').append('<canvas id="graficoGastosMes" style="width:300px; height:300px"></canvas>');

            var ctx = document.getElementById('graficoGastosMes').getContext('2d');

            var grafico = new Chart(ctx, {
                type: 'doughnut',

                data:
                {
                    labels: PegarTiposDespesa(dados),
                    datasets: [
                        {
                            label: "Gastos por Despesa",
                            backgroundColor: PegarCores(dados.length),
                            hoverbackgroundColor: PegarCores(dados.length),
                            data: PegarValores(dados)
                        }
                    ]
                },
                options: {
                    responsive: false,
                    title: {
                        display: true,
                        text: "Gastos Por Despesa"
                    }
                }
            });
        }
    });

});


function CarregarDadosMes() {

    var ordem = $(".escolhaMes").val();
    $.ajax({
        url: "Despesas/GastosMes",
        method: "POST",
        data: { ordem: 1 },
        success: function (dados) {
            $('canvas#graficoGastosMes').remove();
            $('div.graficoGastosMes').append('<canvas id="graficoGastosMes" style="width:300px; height:300px"></canvas>');

            var ctx = document.getElementById('graficoGastosMes').getContext('2d');

            var grafico = new Chart(ctx, {
                type: 'doughnut',

                data:
                {
                    labels: PegarTiposDespesa(dados),
                    datasets: [
                        {
                            label: "Gastos por Despesa",
                            backgroundColor: PegarCores(dados.length),
                            hoverbackgroundColor: PegarCores(dados.length),
                            data: PegarValores(dados)
                        }
                    ]
                },
                options: {
                    responsive: false,
                    title: {
                        display: true,
                        text: "Gastos Por Despesa"
                    }
                }
            });
        }
    });
}
function CarregarDadosGastosTotais() {
    $.ajax({
        url: 'Despesas/GastosTotais',
        method: 'POST',
        success: function (dados) {
            new Chart(document.getElementById("GraficoGastosTotais"), {
                type: 'line',

                data: {
                    labels: PegarMeses(dados),

                    datasets: [{
                        label: "Total Gasto",
                        data: PegarValores(dados),
                        backgroundColor: "ecf0f1",
                        borderColor: "#2980b9",
                        fill: false,
                        spanGaps: false
                    }]
                },
                options: {
                    title: {
                        display: true,
                        text: "Total Gasto"
                    }
                }
            });
        }
    });
}
$('.escolhaMes').on('change', function () {
    var ordem = $('.escolhaMes').val();

    $.ajax({
        url: "Despesas/GastosTotaisMes",
        method: "POST",
        data: { ordem: ordem },
        success: function (dados) {
            $('canvas#GraficoGastoTotalMes').remove();
            $('div.GraficoGastoTotalMes').append('<canvas id="GraficoGastoTotalMes" style="width:300px; height:300px"></canvas>');

            var ctx = document.getElementById('GraficoGastoTotalMes').getContext('2d');

            var grafico = new Chart(ctx, {
                type: 'doughnut',

                data:
                {
                    labels: ['Restante', 'Total Gasto'],
                    datasets: [
                        {
                            label: "Total Gasto",
                            backgroundColor: ["#27ae60", "#0392bb"],
                            data: [(dados.salario - dados.valorTotalGasto), dados.valorTotalGasto]
                        }
                    ]
                },
                options: {
                    responsive: false,
                    title: {
                        display: true,
                        text: "Total gasto no mês"
                    }
                }
            });
        }
    });

});

function CarregarDadosGastosTotaisMes() {
   
        $.ajax({
            url: "Despesas/GastosTotaisMes",
            method: "POST",
            data: { ordem: 1 },
            success: function (dados) {
                $('canvas#GraficoGastoTotalMes').remove();
                $('div.GraficoGastoTotalMes').append('<canvas id="GraficoGastoTotalMes" style="width:300px; height:300px"></canvas>');

                var ctx = document.getElementById('GraficoGastoTotalMes').getContext('2d');

                var grafico = new Chart(ctx, {
                    type: 'doughnut',

                    data:
                    {
                        labels: ['Restante', 'Total Gasto'],
                        datasets: [
                            {
                                label: "Total Gasto",
                                backgroundColor: ["#27ae60", "#0392bb"],
                                data: [(dados.salario - dados.valorTotalGasto), dados.valorTotalGasto]
                            }
                        ]
                    },
                    options: {
                        responsive: false,
                        title: {
                            display: true,
                            text: "Total gasto no mês"
                        }
                    }
                });
            }
        });
   
}
function PegarValores(data) {
    var valores = [];
    var tamanho = data.length;
    var indice = 0;

    while (indice < tamanho) {
        valores.push(data[indice].valores);
        indice++;
    }

    return valores;
}

function PegarTiposDespesa(data) {
    var labels = [];
    var tamanho = data.length;
    var indice = 0;

    while (indice < tamanho) {
        labels.push(data[indice].tiposDespesas);
        indice++;
    }

    return labels;
}

function PegarMeses(dados) {
    var label = [];
    var tamanho = dados.length;
    var indice = 0;

    while (indice < tamanho) {
        label.push(dados[indice].nomeMeses[0]);
        indice++;
    }

    return label;
}

function PegarCores(qtd) {
    var cores = [];

    while (qtd >= 0) {
        var r = Math.floor(Math.random() * 255);
        var g = Math.floor(Math.random() * 255);
        var b = Math.floor(Math.random() * 255);

        cores.push("rgb(" + r + "," + g + "," + b + ")");

        qtd--;
    }
    return cores;
}
