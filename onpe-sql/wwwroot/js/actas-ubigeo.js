$(document).ready(function () {
    var ambitoInicial = $("#cdgoAmbito").val();
    actualizarLabels(ambitoInicial);

    limpiarDesde("departamento");
    obtenerDepartamentos();

    $("#cdgoAmbito").change(function () {
        var valor = $(this).val();
        actualizarLabels(valor);

        limpiarDesde("departamento");
        if (valor !== "") obtenerDepartamentos();
    });

    $("#cdgoDep").change(function () {
        var id = $(this).val();

        limpiarDesde("provincia");
        if (id !== "") obtenerProvincias();
    });

    $("#cdgoProv").change(function () {
        var id = $(this).val();

        limpiarDesde("distrito");
        if (id !== "") obtenerDistritos();
    });

    $("#cdgoDist").change(function () {
        var id = $(this).val();

        limpiarDesde("local");
        if (id !== "") obtenerLocales();
    });

    $("#actas_ubigeo").change(function () {
        var id = $(this).val();

        limpiarDesde("")
        if (id !== "") obtenerGruposVotacion();
    });
});

// Funciones de ayuda 
function actualizarLabels(valor) {
    if (valor === "P") {
        $("#lblDepartamento").text("Departamento:");
        $("#lblProvincia").text("Provincia:");
        $("#lblDistrito").text("Distrito:");
    } else {
        $("#lblDepartamento").text("Continente:");
        $("#lblProvincia").text("País:");
        $("#lblDistrito").text("Ciudad:");
    }
}

function limpiarDesde(nivel) {
    const opcionDefault = "<option value=''>--SELECCIONE--</option>";
    $("#GruposVotacion").empty();
    switch (nivel) {
        case "departamento": $("#cdgoDep, #cdgoProv, #cdgoDist, #actas_ubigeo").empty().append(opcionDefault).prop("disabled", true);break;
        case "provincia": $("#cdgoProv, #cdgoDist, #actas_ubigeo").empty().append(opcionDefault).prop("disabled", true); break;
        case "distrito": $("#cdgoDist, #actas_ubigeo").empty().append(opcionDefault).prop("disabled", true); break;
        case "local": $("#actas_ubigeo").empty().append(opcionDefault).prop("disabled", true); break;
        default: break;
    }
}

// Funciones para obtener los datos

function obtenerDepartamentos() {
    var _ambito = $("#cdgoAmbito").val();
    $.ajax({
        url: "/Actas/verDepartamentos",
        type: "GET",
        dataType: "json",
        data: { ambito: _ambito },
        success: function (response) {
            $("#cdgoDep").empty().append("<option value=''>--SELECCIONE--</option>");
            $.each(response, function (index, elemento) {
                $("#cdgoDep").append($("<option>").val(elemento.id).text(elemento.detalle));
            });
            $("#cdgoDep").prop("disabled", false);
        }
    });
}

function obtenerProvincias() {
    var _id = $("#cdgoDep").val();
    $.ajax({
        url: "/Actas/verProvincias",
        type: "GET",
        dataType: "json",
        data: { id: _id },
        success: function (response) {
            $("#cdgoProv").empty().append("<option value=''>--SELECCIONE--</option>");
            $.each(response, function (index, elemento) {
                $("#cdgoProv").append($("<option>").val(elemento.id).text(elemento.detalle));
            });
            $("#cdgoProv").prop("disabled", false);
        }
    });
}

function obtenerDistritos() {
    var _id = $("#cdgoProv").val();
    $.ajax({
        url: "/Actas/verDistritos",
        type: "GET",
        dataType: "json",
        data: { id: _id },
        success: function (response) {
            $("#cdgoDist").empty().append("<option value=''>--SELECCIONE--</option>");
            $.each(response, function (index, elemento) {
                $("#cdgoDist").append($("<option>").val(elemento.id).text(elemento.detalle));
            });
            $("#cdgoDist").prop("disabled", false);
        }
    });
}

function obtenerLocales() {
    var _id = $("#cdgoDist").val();
    $.ajax({
        url: "/Actas/verLocales",
        type: "GET",
        dataType: "json",
        data: { id: _id },
        success: function (response) {
            $("#actas_ubigeo").empty().append("<option value=''>--SELECCIONE--</option>");
            $.each(response, function (index, elemento) {
                $("#actas_ubigeo").append($("<option>").val(elemento.id).text(elemento.detalle));
            });
            $("#actas_ubigeo").prop("disabled", false);
        }
    });
}

function obtenerGruposVotacion() {
    var _id = $("#actas_ubigeo").val();
    $.ajax({
        url: "/Actas/_GruposVotacion",
        type: "GET",
        dataType: "html",
        data: { id: _id },
        success: function (htmlrecibido) {
            $("#GruposVotacion").html(htmlrecibido);
        }
    });
}