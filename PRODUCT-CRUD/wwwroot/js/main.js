var prodId = '';
$(document).ready(function () {
    showProduct();
    $("#btnUpdateProduct").click(function () {

        if (prodId != '') {
            updateProduct(prodId)
        }
        else {
            alert("No proper id found for update!")
        }

    });
});

function createProduct() {
    var url = "/Product";
    var product = {};

    if ($('#txtName').val() === '' || $('#txtDescription').val() === '' || $('#txtPrice').val() === ''){alert("No field can be left blank");}
    else {
        product.Name = $('#txtName').val();
        product.Description = $('#txtDescription').val();
        product.Price = $('#txtPrice').val();                

        if (product) {
            $.ajax({
                url: url,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                data: JSON.stringify(product),
                type: "Post",
                success: function (result) {
                    clearForm();
                    showProduct();
                },
                error: function (msg) {
                    alert(msg);
                }

            });
        }
    }
}

function showProduct() {
    var url = "/product/getallproducts";

    $.ajax({
        url: url,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        type: "Get",
        success: function (result) {
            if (result) {
                $("#tblProductBody").html('');
                var row = '';
                for (var i = 0; i < result.length; i++) {
                    row = row
                        + "<tr>"
                        + "<td>" + result[i].name + "</td>"
                        + "<td>" + result[i].description + "</td>"
                        + "<td>" + result[i].price + "</td>"                                               
                        + "<td><button class='btn btn-primary' onClick='editProduct(" + result[i].productID + ")'>Edit</button>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<button class='btn btn-danger' onClick='deleteProduct(" + result[i].productID + ")'>Delete</button></td>"
                }
                if (row != '') {
                    $("#tblProductBody").append(row);
                }
            }
        },
        error: function (msg) {
            alert(msg);
        }

    });
}

function deleteProduct(id) {
    var url = "/Product/" + id;
    $.ajax({
        url: url,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        type: "Delete",
        success: function (result) {
            clearForm();
            alert("Deleted Successfully!")
            /*alert(JSON.stringify(result));*/
            showProduct();
        },
        error: function (msg) {
            alert(msg);
        }
    });
}

function editProduct(id) {
    var url = "/Product/" + id;
    $.ajax({
        url: url,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        type: "Get",
        success: function (result) {
            if (result) {
                prodId = result.productID;
                $('#txtName').val(result.name);
                $('#txtDescription').val(result.description);
                $('#txtPrice').val(result.price);                               
            }
            $("#btnCreateProduct").prop('disabled', true);
            $("#btnUpdateProduct").prop('disabled', false);

        },
        error: function (msg) {
            alert(msg);
        }

    });
}

function updateProduct(id) {
    var url = "/Product/" + id;
    var product = {};
    product.productID = id;
    product.name = $('#txtName').val();
    product.description = $('#txtDescription').val();
    product.price = $('#txtPrice').val();    
   

    if (product) {
        $.ajax({
            url: url,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            data: JSON.stringify(product),
            type: "Put",
            success: function (result) {
                clearForm();
                showProduct();
                $("#btnCreateProduct").prop('disabled', false);
                $("#btnUpdateProduct").prop('disabled', true);
            },
            error: function (msg) {
                alert(msg);
            }
        });
    }
}

function clearForm() {
    $('#txtName').val('');
    $('#txtDescription').val('');
    $('#txtPrice').val('');    
}
