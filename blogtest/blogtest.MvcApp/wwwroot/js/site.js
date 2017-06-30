//$(document).ready(function () {
//    //data source for kendo grid
//    dataSource = new kendo.data.DataSource({
//        transport: {
//            read:
//            {
//                url: "GetAllPost",
//                dataType: "json",   //reading data
//            }
//        },
//        schema:
//        {
//            model:
//            {
//                id: "ID",
//                fields: {   //column models and specifying behaviour
//                    ID: { editable: true, nullable: true, type: "string" },
//                    NamePost: { editable: true, nullable: true, type: "string" },
//                    Description: { editable: true, nullable: false, type: "string" }
//                }
//            }
//        }
//    });
//    $("#grid").kendoGrid({
//        dataSource: dataSource, //binging the above data source to grid
//        //editable: "inline",   //inline editing
//        selectable: true,       //selectable when u click on any row its color may change
//        groupable: true,
//        sortable: true,          //sortable
//        toolbar: ["create"],    //displays a button in grid toolbar 
//        columns: [              //columns in grid
//            {
//                field: "ID",
//                title: "Id",
//            },
//            {
//                field: "NamePost",
//                title: "NamePost"
//            }
//        ],
//        editable: "popup",      //edit option with popup
//        filterable: true,       //we can filter tae data using filter options   
//        columnMenu: true,
//        reorderable: true,
//        resizable: true,
//        height: "500px",
//        pageable: {
//            refresh: true,
//            pageSizes: true,
//            buttonCount: 5
//        },
//    }).data("kendoGrid");
//});


$(document).ready(function () {

    $(function () {
        $("#grid").find("table th").eq(1).hide();
        $("#grid").kendoGrid({
            dataSource: {
                transport: {
                    read:
                    {
                        url: "GetAlll",
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
                pageSizes: [2, 3, 4, "all"],
                numeric: false
            },
            sortable: true,

            pageable: true,

            columns: [{
                field: "namePost",
                title: " Name post",
                filterable: false
            }, {
                field: "description",
                title: " Description",
            }, {
                field: "creationDate",
                title: "Creation Date"
            },


            {
                title: "Action",
                template: `<a role="button" class="k-button k-button-icontext k-grid-edit" href="Create/#=id#">Edit</a> 
                           <a role="button" class="k-button k-button-icontext k-grid-delete" href="Delete/#=id#">Delete</a>`
                , filterable: false


            }]





        });
    });


});  
