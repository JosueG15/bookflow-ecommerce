var dataTable;
$(document).ready(function () {
    var url = window.location.search;
    if (url.includes("inprocess")) {
        loadDataTable("inprocess");
    } else if (url.includes("approved")) {
        loadDataTable("approved");
    } else if (url.includes("completed")) {
        loadDataTable("completed");
    } else if (url.includes("pending")) {
        loadDataTable("pending");
    } else {
        loadDataTable("all");
    }
})

function loadDataTable(status) {
    dataTable = $('#tblData').DataTable({
        "ajax": { url:'/Admin/Order/getall?status=' + status},
        "columns": [
            { data: 'id', "width": "5%" },
            { data: 'name', "width": "25%" },
            { data: 'phoneNumber', "width": "20%" },
            { data: 'applicationUser.email', "width": "20%" },
            { data: 'orderStatus', "width": "10%" },
            {
                data: 'orderTotal',
                "width": "10%",
                "render": function (data, type, row) {
                    return '$' + parseFloat(data).toFixed(2);
                }
            },
            {
                data: 'id',
                "render": function (data) {
                    return `
                    <div class="w-75 btn-group" role="group">
                        <a href="/admin/order/details?orderId=${data}" class="btn btn-primary mx-2"> <i class="bi bi-pencil-square"></i></a>
                    </div>`
                },
                "width": "10%"
            }
        ],
        "language": {
            "info": "Mostrando pagina _PAGE_ de _PAGES_",
            "infoEmpty": "No hay informacion disponible",
            "infoFiltered": "(filtrado de _MAX> registros disponibles)",
            "lengthMenu": "Mostrando _MENU_ registros por pagina",
            "zeroRecords": "Sin registros disponibles",
            "search": "Buscar"
        },
        "dom": 'Bfrtip',
        "buttons": [
            'copy', 'csv', 'excel', 'pdf'
        ],
        responsive: true
    });
}