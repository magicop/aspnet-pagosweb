jQuery(document).ready(function () {

    //$.validator.addMethod('validatenew', function () {
    //    return ($('#codigoProductoOld').val() != $('#codigoProductoNew').val())
    //}, "El código de producto antiguo no puede ser el mismo que el nuevo.");

    //VALIDACIONES $.VALIDATE
    $.extend($.validator.messages, {
        required: "Este campo es obligatorio.",
        remote: "Por favor, rellena este campo.",
        email: "Por favor, escribe una dirección de correo válida",
        url: "Por favor, escribe una URL válida.",
        date: "Por favor, escribe una fecha válida.",
        dateISO: "Por favor, escribe una fecha (ISO) válida.",
        number: "Por favor, escribe un número entero válido.",
        digits: "Por favor, escribe sólo dígitos.",
        creditcard: "Por favor, escribe un número de tarjeta válido.",
        equalTo: "Por favor, escribe el mismo valor de nuevo.",
        accept: "Ingrese una imagen, pdf o word",
        maxlength: $.validator.format("Por favor, no escribas más de {0} caracteres."),
        minlength: $.validator.format("Por favor, no escribas menos de {0} caracteres."),
        rangelength: $.validator.format("Por favor, escribe un valor entre {0} y {1} caracteres."),
        range: $.validator.format("Por favor, escribe un valor entre {0} y {1}."),
        max: $.validator.format("Por favor, escribe un valor menor o igual a {0}."),
        min: $.validator.format("Por favor, escribe un valor mayor o igual a {0}.")
    });

    jQuery(document).off("click");
    jQuery(document).on("click", "#btnBuscar", function (e) {


        $.validator.setDefaults({
            debug: true,
            success: "valid"
        });

        $form = $("#FormBuscarPago");

        $form.validate({
            submitHandler: function ($form) {
                $("error").addClass("alert alert-primary");
                $form.submit();
            },
            rules: {
                rutPago: {
                    minlength: 8,
                    maxlength: 8,
                    number: true
                },
                idFolio: {
                    minlength: 6,
                    maxlength: 6,
                    number: true
                },
                fechaDesde: {
                    required: true
                },
                fechaHasta: {
                    required: true
                },
                CodIsapre: {
                    required: true
                },
                montoPago: {
                    min: 1,
                    max: 9999999
                },
                beneficiario: {
                    required: true
                }
            },
            messages: {
                rutPago: {
                    minlength: "El largo del rut debe ser minimo de 8 caracteres",
                    maxlength: "El largo del rut debe ser maximo de 8 caracteres",
                    number: "Solo se pueden agregar números"
                },
                idFolio: {
                    minlength: "El largo del folio debe ser minimo de 6 caracteres",
                    maxlength: "El largo del folio debe ser maximo de 6 caracteres",
                    number: "Solo se pueden agregar números"
                },
                fechaDesde: {
                    required: "Debe ingresar la fecha de inicio"
                },
                fechaHasta: {
                    required: "Debe ingresar la fecha de término"
                },
                CodIsapre: {
                    required: "Debe seleccionar la isapre correspondiente"
                },
                montoPago: {
                    min: "El largo del monto debe ser mayor a {0}",
                    max: "El largo del monto debe ser menor a {0}"
                },
                beneficiario: {
                    required: "Debe ingresar el beneficiario"
                }
            },
            errorElement: 'div',
            errorLabelContainer: '.errorTxt'
        });


    });

    //jQuery(document).off("click");
    //jQuery(document).on("click", "#btnConsultar", function (e) {


    //    $.validator.setDefaults({
    //        debug: true,
    //        success: "valid"
    //    });

    //    $form = $("#FormConsultaDeudas");

    //    $form.validate({
    //        submitHandler: function ($form) {
    //            $("error").addClass("alert alert-primary");
    //            $form.submit();
    //        },
    //        rules: {
    //            CodPeriodo: {
    //                required: true
    //            }
    //        },
    //        messages: {
    //            CodPeriodo: {
    //                required: "Debe seleccionar el periodo de deuda"
    //            }
    //        },
    //        errorElement: 'div',
    //        errorLabelContainer: '.errorTxt'
    //    });
    //});

    


   
});