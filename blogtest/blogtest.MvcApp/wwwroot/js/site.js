

$(document).ready(function () {

    $(function () {
        $("#grid").find("table th").eq(1).hide();
        $("#grid").kendoGrid({
            dataSource: {
                transport: {
                    read:
                    {
                        url: "GetAll",
                        dataType: "json",   //reading data
                    },
                    destroy:
                    {
                        url: "Delete",
                        type: "GET"
                    },
                },
                schema: {
                    model: {
                        id: "id",
                        fields: {
                            id: {
                                type: "string"
                            },
                            namePost: {
                                type: "string"
                            },
                            description: {
                                type: "string"
                            },
                            creationDate: {
                                type: "string"
                            },
                            comment: {
                                type: "string"
                            }
                        }
                    }
                },
                pageSize: 5
            },
            pageable: {
                pageSizes: [5, 10, 20, "all"],
                numeric: false
            },
            sortable: true,
            columns: [{
                field: "namePost",
                title: " Name post",
                filterable: false
            }, {
                field: "creationDate",
                width: 300,
                title: "Creation Date"
            },


            {
                title: "Action",
                width: 200,
                template: `<a role="button" class="k-button k-button-icontext k-grid-edit" href="Create/#=id#">Edit</a> 
                           <a role="button" class="k-button k-button-icontext k-grid-delete" href="Delete/#=id#">Delete</a>`
                , filterable: false


            }]





        });
    });


});  
