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