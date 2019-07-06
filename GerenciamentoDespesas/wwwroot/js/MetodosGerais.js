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
