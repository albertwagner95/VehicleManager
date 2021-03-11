// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

//Table vehicleHistory
$(document).ready(function () {
    var table = $('#example').DataTable({

        lengthChange: true,
        searching: false,
        buttons: [
            { extend: 'copy', className: 'btn btn-primary glyphicon glyphicon-duplicate' },
            { extend: 'csv', className: 'btn btn-primary glyphicon glyphicon-save-file' },
            { extend: 'excel', className: 'btn btn-primary glyphicon glyphicon-list-alt' },
            { extend: 'pdf', className: 'btn btn-primary glyphicon glyphicon-file' },
            { extend: 'print', className: 'btn btn-primary glyphicon glyphicon-print' }
        ],

        "language": {
            "info": "Pozycje od _START_ do _END_ z _TOTAL_ łącznie",
            "infoEmpty": "Pozycji 0 z 0 dostępnych",
            "lengthMenu": "Pokaż _MENU_ pozycji",
            "paginate": {
                "first": "Pierwszy",
                "last": "Ostatni",
                "next": "Następny",
                "previous": "Wstecz"
            },
            "buttons": {
                "collection": "Collection <span class='ui-button-icon-primary ui-icon ui-icon-triangle-1-s'\/>",
                "colvis": "Wybierz kolumny",
                "colvisRestore": "Resetuj widoki",
                "copy": "Skopiuj",
                "copyKeys": "Press ctrl or u2318 + C to copy the table data to your system clipboard.<br><br>To cancel, click this message or press escape.",
                "copySuccess": {
                    "1": "Skopiowano 1 wierwsz do schowka",
                    "_": "Skopiowano %d wierszy do schowka"
                },
                "copyTitle": "Skopiuj do schowka",
                "csv": "CSV",
                "excel": "Excel",
                "pageLength": {
                    "-1": "Pokaż wszystkie",
                    "1": "Pokaż 1 wiersz",
                    "_": "Pokaż %d wierszy"
                },
                "pdf": "PDF",
                "print": "Drukuj"
            }
        }
    });

    table.buttons().container()
        .appendTo('#example_wrapper .col-md-6:eq(0)');
});

//bootstrap data-toogle    
$(document).ready(function () {
    $('[data-toggle="tooltip"]').tooltip();
});


 