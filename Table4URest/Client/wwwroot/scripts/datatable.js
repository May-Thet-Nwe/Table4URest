function AddDataTable(table) { /*to specify datatable on html table*/
    $(document).ready(function () { /*to execute after html doc*/
        $(table).DataTable();
    })
}
function DataTablesDispose(table) { /*removes datatable */
    $(document).ready(function () {
        $(table).DataTable().destroy();
        var element = document.querySelector(table + '_wrapper');
        element.parentNode.removeChild(element);
    })
}