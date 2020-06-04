jQuery(document).ready(function () {

    $.validator.addMethod('filesize', function (value, element, param) {
        param = param * 1048576;
        return this.optional(element) || (element.files[0].size <= param)
    }, 'El archivo debe pesar menos de {0} megabytes');


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
    jQuery(document).on("click", "#btn-adjuntar", function (e) {


        $.validator.setDefaults({
            debug: true,
            success: "valid"
        });

        $form = $("#form-adjuntar");
        
        $form.validate({
            submitHandler: function ($form) {
                $("body").addClass("loading");
                $form.submit();
            },
            rules: {
                agregararchivo: {
                    extension: "jpg|jpeg|png|gif|pdf|docx|doc",
                    filesize: 5 //Megabytes
                },
                uploadFile: {
                    required: true
                },
                IdMotivo: {
                    required: true,
                },
                IdDocumento: {
                    required: true,
                    min:1
                },
                Observacion: {
                    required: true,
                }
            },
            messages: {
                uploadFile: {
                    required: "Debes adjuntar un archivo"
                },
                IdMotivo: {
                    required: "Indica motivo",
                },
                IdDocumento: {
                    required: "Indica documento",
                    min: "Indica documento"
                },
                Observacion: {
                    required: "Indica observaciones",
                }
            },
            errorElement: 'div',
            errorLabelContainer: '.errorTxt'
        });
    });
});