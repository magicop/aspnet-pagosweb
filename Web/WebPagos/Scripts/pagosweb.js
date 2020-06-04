
$(document).ready(function () {

    $('#TblPagos').DataTable({
        "pageLength": 20,
        "pagingType": "full_numbers",
        "bLengthChange": false,
        "bInfo": false,
        "oLanguage": {
            "sSearch": "Búsqueda rápida",
            buttons: {
                print: 'Imprimir',
                copy: 'Copiar'
            },
            "oPaginate": {
                "sFirst": "Primero",
                "sLast": "Último",
                "sNext": "Siguiente",
                "sPrevious": "Anterior"
            }
        },
        dom: 'Bfrtip',
        buttons: [
        {
            extend: 'copyHtml5',
            exportOptions: {
                columns: [0, 6]
            }
        },
        //'excelHtml5',
        //{
        //    extend: 'excelHtml5',
        //    text: 'Excel',
        //    exportOptions: {
        //        modifier: {
        //            page: 'current'
        //        }
        //    }
        //},
        'pdfHtml5',
        //{
        //    extend: 'pdfHtml5',
        //    exportOptions: {
        //        columns: [0, 6]
        //    }
        //},
        'print'
        ]
    });

    $('#TblDeudas').DataTable({
        "pageLength": 20,
        "pagingType": "full_numbers",
        "bLengthChange": false,
        "bInfo": false,
        "oLanguage": {
            "sSearch": "Búsqueda rápida",
            buttons: {
                print: 'Imprimir',
                copy: 'Copiar'
            },
            "oPaginate": {
                "sFirst": "Primero",
                "sLast": "Último",
                "sNext": "Siguiente",
                "sPrevious": "Anterior"
            }
        },
        dom: 'Bfrtip',
        buttons: [
        {
            extend: 'copyHtml5',
            exportOptions: {
                columns: [0, 6]
            }
        },
        'excelHtml5',
        //{
        //    extend: 'excelHtml5',
        //    text: 'Excel',
        //    exportOptions: {
        //        modifier: {
        //            page: 'current'
        //        }
        //    }
        //},
        'pdfHtml5',
        //{
        //    extend: 'pdfHtml5',
        //    exportOptions: {
        //        columns: [0, 6]
        //    }
        //},
        'print'
        ]
    });

    
});
