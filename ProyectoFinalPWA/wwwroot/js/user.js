var dataTable;
$(document).ready(function () {
    loadDataTable();
})

function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": { url:'/Admin/User/getall' },
        "columns": [
            { data: 'name', "width": "25%" },
            { data: 'email', "width": "15%" },
            { data: 'phoneNumber', "width": "10%" },
            { data: 'company.name', "width": "15%" },
            { data: 'role', "width": "10%" },
            {
                data: {id: '{id', lockoutEnd: 'lockoutEnd'},
                "render": function (data) {
                    var today = new Date().getTime();
                    var lockout = new Date(data.lockoutEnd).getTime();

                    if (lockout > today) {
                        return `
                                <div class="text-center">
                                <a onclick=LockUnlock('${data.id}') class="btn btn-danger text-white" style="cursor:pointer; width: 150px; margin-bottom: 10px;">
                                        <i class="bi bi-lock-fill"></i>  Bloquear
                                    </a>
                                    
                                     <a href="/admin/user/RoleManagement?userId=${data.id}" class="btn btn-danger text-white" style="cursor:pointer; width: 150px;">
                                        <i class="bi bi-pencil-square"></i>  Permisos
                                    </a>
                                </div>`
                    } else {
                        return `
                                <div class="text-center">
                                    <a onclick=LockUnlock('${data.id}') class="btn btn-success text-white" style="cursor:pointer; width: 150px; margin-bottom: 10px;">
                                        <i class="bi bi-unlock-fill"></i>  Desbloquear
                                    </a>

                                     <a href="/admin/user/RoleManagement?userId=${data.id}" class="btn btn-danger text-white" style="cursor:pointer; width: 150px;">
                                        <i class="bi bi-pencil-square"></i>  Permisos
                                    </a>
                                </div>`
                    }

                  
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

function LockUnlock(id) {
    $.ajax({
        type: "POST",
        url: "/Admin/User/LockUnlock",
        data: JSON.stringify(id),
        contentType: 'application/json',
        success: function (data) {
            if (data.success) {
                toastr.success(data.message);
                dataTable.ajax.reload();
            }
        }
    })
}