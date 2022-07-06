        var tabladata;



        tabladata = $("#tabla").DataTable({
            responsive: true,
        ordering: false,
        "ajax": {
            url: '@Url.Action("ListarParticipantes", "Home")',
        type: "GET",
        dataType: "json"
        },
        "columns": [
        {"data": "PART_RUT" },
        {"data": "PART_NOMBRE" },
        {"data": "PART_FONO" },
        {"data": "PART_EMAIL" },
        {"data": "PART_INSTITUCION" },

        {
            "defaultContent": '<button type="button" class="btn btn-primary btn-sm btn-editar ">Editar</button>' + '<button type="button" class="btn btn-danger btn-sm ms-2 btn-eliminar">Borrar</button>',
        "orderable": false,
        "searchable": false,
        "width": "120px"
            }

        ],
        "language": {
            "url": "https://cdn.datatables.net/plug-ins/1.11.3/i18n/es_es.json"
        }

    });

        function abrirModal(json) {
            $("#txtRut").val("");
        $("#txtNombre").val("");
        $("#txtFono").val("");
        $("#txtEmail").val("");
        $("#txtInstitucion").val("");

        if (json != null) {
            $("#txtRut").val(json.PART_RUT);
        $("#txtNombre").val(json.PART_NOMBRE);
        $("#txtFono").val(json.PART_FONO);
        $("#txtEmail").val(json.PART_EMAIL);
        $("#txtInstitucion").val(json.PART_INSTITUCION);
            }


        $("#modalParticipantes").modal("show");
        }



        $("#tabla tbody").on("click", '.btn-editar', function () {

            var filaSeleccionada = $(this).closest("tr");

        var data = tabladata.row(filaSeleccionada).data();

        console.log(data)
        abrirModal(data)

        })


        function Guardar() {
            var Participante = {
            PART_RUT: $("txtRut").val(),
        PART_NOMBRE: $("txtNombre").val(),
        PART_FONO: $("txtFono").val(),
        PART_EMAIL: $("txtEmail").val(),
        PART_INSTITUCION: $("txtInstitucion").val()
                
            }


        tabladata.row.add(Participante).draw(false);
            
            
        }

