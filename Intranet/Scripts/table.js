$(document).ready(function () {
    $('#tabla').dataTable({
        "language": {
            //"url": "//cdn.datatables.net/plug-ins/1.10.16/i18n/Spanish.json",
            "sProcessing": "Procesando...",
            "sLengthMenu": "Mostrar _MENU_ registros",
            "sZeroRecords": "No se encontraron resultados",
            "sEmptyTable": "Ningún dato disponible en esta tabla",
            "sInfo": "Mostrando _START_ al _END_ de _TOTAL_ registros ",
            "sInfoEmpty": "Mostrando registros del 0 al 0 de un total de 0 registros",
            "sInfoFiltered": "(filtrado de un total de _MAX_ registros)",
            "sInfoPostFix": "",
            "sSearch": "Buscar:",
            "sUrl": "",
            "sInfoThousands": ",",
            "sLoadingRecords": "Cargando...",
            "oPaginate": {
                "sFirst": "Primero",
                "sLast": "Último",
                "sNext": "Siguiente",
                "sPrevious": "Anterior"
            }
        },
        "bLengthChange": false,
        "pageLength": 20
    });
});

$(document).ready(function () {
    var table = $('#tablaComisiones').dataTable({       
        language: {
            //"url": "//cdn.datatables.net/plug-ins/1.10.16/i18n/Spanish.json",
            "sProcessing": "Procesando...",
            "sLengthMenu": "Mostrar _MENU_ registros",
            "sZeroRecords": "No se encontraron resultados",
            "sEmptyTable": "Ningún dato disponible en esta tabla",
            "sInfo": "Mostrando _START_ al _END_ de _TOTAL_ registros ",
            "sInfoEmpty": "Mostrando registros del 0 al 0 de un total de 0 registros",
            "sInfoFiltered": "(filtrado de un total de _MAX_ registros)",
            "sInfoPostFix": "",
            "sSearch": "Buscar:",
            "sUrl": "",
            "sInfoThousands": ",",
            "sLoadingRecords": "Cargando...",
            "oPaginate": {
                "sFirst": "Primero",
                "sLast": "Último",
                "sNext": "Siguiente",
                "sPrevious": "Anterior"
            }
        },
        scrollY: '60vh',
        scrollCollapse: true,
        paging: false,
        columnDefs: [
            { "visible": false , "targets": 0 }
        ],
        order: [[0, 'asc'], [2, 'desc'], [1, 'asc']],
        rowGroup: {
            dataSrc: 0,
            startRender: null,
            endRender: function (rows, group) {
                var cobradoBP = rows
                    .data()
                    .pluck(3)
                    .reduce(function (a, b) {
                        return a + b.replace(/[^\d]/g, '') * 1;
                    }, 0);
                cobradoBP = $.fn.dataTable.render.number('.', ',', 0, '$').display(cobradoBP);

                var comisionVen = rows
                    .data()
                    .pluck(4)
                    .reduce(function (a, b) {
                        return a + b.replace(/[^\d]/g, '') * 1;
                    }, 0);
                comisionVen = $.fn.dataTable.render.number('.', ',', 0, '$').display(comisionVen);

                var comisionSuc = rows
                    .data()
                    .pluck(5)
                    .reduce(function (a, b) {
                        return a + b.replace(/[^\d]/g, '') * 1;
                    }, 0);
                comisionSuc = $.fn.dataTable.render.number('.', ',', 0, '$').display(comisionSuc);

                var aCobrar = rows
                    .data()
                    .pluck(6)
                    .reduce(function (a, b) {
                        return a + b.replace(/[^\d]/g, '') * 1;
                    }, 0);
                aCobrar = $.fn.dataTable.render.number('.', ',', 0, '$').display(aCobrar);

                var restaCobrar = rows
                    .data()
                    .pluck(7)
                    .reduce(function (a, b) {
                        return a + b.replace(/[^\d]/g, '') * 1;
                    }, 0);
                restaCobrar = $.fn.dataTable.render.number('.', ',', 0, '$').display(restaCobrar);

                return $('<tr class="group" />')
                    .append('<td colspan="2">Totales Sucursal ' + group + '</td>')
                    .append('<td align="right">' + cobradoBP + '</td>')
                    .append('<td align="right">' + comisionVen + '</td>')
                    .append('<td align="right">' + comisionSuc + '</td>')
                    .append('<td align="right">' + aCobrar + '</td>')
                    .append('<td align="right">' + restaCobrar + '</td>');
            }
        }

/* Funciona OK
        "drawCallback": function (settings) {
            var api = this.api();
            var rows = api.rows({ page: 'current' }).nodes();
            var last = null;

            api.column(0, { page: 'current' }).data().each(function (group, i) {
                if (last !== group) {
                    $(rows).eq(i).before(
                        '<tr class="group"><td colspan="7">' + group + '</td></tr>'
                    );
                    last = group;
                }
            });
        }
*/
    });

    // Order by the grouping
    $('#tablaComisiones tbody').on('click', 'tr.group', function () {
        var currentOrder = table.order()[0];
        if (currentOrder[0] === 0 && currentOrder[1] === 'asc') {
            table.order([0, 'desc']).draw();
        }
        else {
            table.order([0, 'asc']).draw();
        }
    });
});