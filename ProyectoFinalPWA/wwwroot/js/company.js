var dataTable;
$(document).ready(function () {
    loadDataTable();
})

function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": { url:'/Admin/Company/getall' },
        "columns": [
            { data: 'name', "width": "25%" },
            { data: 'streetAddress', "width": "15%" },
            { data: 'city', "width": "10%" },
            { data: 'state', "width": "15%" },
            { data: 'phoneNumber', "width": "10%" },
            {
                data: 'id',
                "render": function (data) {
                    return `
                    <div class="w-75 btn-group" role="group">
                        <a href="/admin/company/upsert?id=${data}" class="btn btn-primary mx-2"> <i class="bi bi-pencil-square"></i>  Editar </a>
                        <a onClick=Delete('/admin/company/delete/${data}') class="btn btn-danger mx-2"> <i class="bi bi-trash-fill"></i>  Eliminar </a>
                    </div>`
                },
                "width": "25%"
            }
        ],
        "language": {
            "info": "Mostrando pagina _PAGE_ de _PAGES_",
            "infoEmpty": "No hay informacion disponible",
            "infoFiltered": "(filtrado de _MAX> registros disponibles)",
            "lengthMenu": "Mostrando _MENU_ registros por pagina",
            "zeroRecords": "Sin registros disponibles",
            "search": "Buscar"
        }
    });
}

function Delete(url) {
    Swal.fire({
        title: "Esta seguro?",
        text: "No podra revertir esta accion",
        icon: "warning",
        showCancelButton: true,
        confirmButtonColor: "#3085d6",
        cancelButtonColor: "#d33",
        confirmButtonText: "Si, eliminalo!"
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                url: url,
                type: 'DELETE',
                success: function (data) {
                    dataTable.ajax.reload();
                    toastr.success(data.message);
                    //Swal.fire({
                    //    title: "Eliminado!",
                    //    text: "El producto ha sido eliminado exitosamente",
                    //    icon: "success"
                    //});
                }
            })
        }
    });
}