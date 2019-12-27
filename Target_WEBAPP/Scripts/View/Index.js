function showEditModal(id) {
    window.location.href = rootDir + "Home/NewAgenda?id=" + id;
}

function Delete(id) {
    $.ajax({
        url: rootDir + 'Home/Delete?id=' + id,
        method: "GET"
    }).done(function() {
        window.location.href = rootDir + 'Home/Index';
    });
}

function Save() {
    var data = {};
    var id = $("input[name='ID']").val();
    var nome = $("input[name='Nome']").val();
    var dtinicio = $("input[name='DataInicio']").val();
    var dtfim = $("input[name='DataFinal']").val();
    var e = document.getElementById("tipoAgendamento");
    var tipo = e.options[e.selectedIndex].value;
    var obs = $("input[name='Observacao']").val();

    data.ID = id;
    data.Nome = nome;
    data.DataInicio = dtinicio;
    data.DataFinal = dtfim;
    data.tipoAgendamento = tipo;
    data.Observacao = obs;

    if (id == 0) {
        $.ajax({
            url: rootDir + 'Home/SalvarAgenda',
            method: 'POST',
            data: data
        }).done(function (data) {
            window.location.href = rootDir + 'Home/Index';
        });
    } else {
        $.ajax({
            url: rootDir + 'Home/AtualizarDados?id=' + id,
            method: 'POST',
            data: data
        }).done(function (data) {
            window.location.href = rootDir + 'Home/Index';
        });
    }



    return false;
}