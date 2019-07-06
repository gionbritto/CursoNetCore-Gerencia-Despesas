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