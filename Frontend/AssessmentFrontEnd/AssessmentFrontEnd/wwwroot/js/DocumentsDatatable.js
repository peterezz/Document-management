$(document).ready(function () {
    $('#DocumentList').dataTable({
        "processing": true,
        "serverSide": true,
        "filter": true,
        "ajax": {
            "url": "/api/DocumentList",
            "type": "POST",
            "datatype": "json"
        },
        "columnDefs": [{
            "targets": [0],
            "visible": true,
            "searchable": false
        }],
        "columns": [
            { "data": "name", "name": "Name", "autowidth": true },
            { "data": "date", "name": "Date", "autowidth": true },
            { "data": "created", "name": "Created", "autowidth": true },

            { "data": "priority", "name": "Priority", "autowidth": true },
            { "data": "dueDate", "name": "DueDate", "autowidth": true },
           
            {
                "render": function (data, type, row) {
                    return '<a href=/Document/details?Id=' + row.documentId + ' class="btn btn-primary"  > Details </a>'
                },
                "orderable": false
            },
            {
                "render": function (data, type, row) {
                    return '<a href=/Document/update?Id=' + row.documentId + ' class="btn btn-primary"  > Edit  </a>'
                },
                "orderable": false
            },
            {
                "render": function (data, type, row) { return '<a href=/Document/delete?Id=' + row.documentId + ' class="btn btn-danger"  > Delete  </a>' },
                "orderable": false
            }

        ]
    });
});