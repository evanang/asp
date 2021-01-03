$(document).ready(function () {
    $('#MessageContainer').hide();
    // insert modal
    $('#myModal').on('show.bs.modal', function (event) {

        CleanForm();
        let button = $(event.relatedTarget)
        let BookID = button.data('id')
        let Type = button.data('type')
        let modal = $(this)
        
        modal.find('.modal-title').text(Type + " Book Data");

        if (Type == "Edit") {
            $.ajax({
                type: "POST",
                url: Address + "/Book/Edit",
                data: {
                    BookID : BookID
                },
                success: function (Data) {
                    $('#MessageContainer').hide();
                    let JSONData = Data.Data;
                    if (JSONData != "") {
                        $("#txtBookID").val(JSONData.BookID);
                        $("#txtBookName").val(JSONData.BookName);
                        $("#txtBookDesc").val(JSONData.BookDesc);
                        $("#txtBookQty").val(JSONData.BookQty);

                    }
                    else {
                        $('#MessageContainer').show();
                        $('#Message').text("Invalid request");
                    }
                },
                error: function (data) {
                    $('#MessageContainer').show();
                    $('#Message').text("Invalid request");
                }
            });
        }

    });


    //Borrow Modal
    $('#borrowModal').on('show.bs.modal', function (event) {

        CleanBorrowForm();
        let button = $(event.relatedTarget)
        let BookID = button.data('id')
        let Type = button.data('type')
        let modal = $(this)
        
        modal.find('.modal-title').text(Type + " Book Data");

        $.ajax({
            type: "POST",
            url: Address + "/Book/Edit",
            data: {
                BookID: BookID
            },
            success: function (Data) {
                  
                let JSONData = Data.Data;

                if (JSONData != "") {
                        
                    $("#borrowBookID").val(JSONData.BookID);
                    $("#borrowBookName").val(JSONData.BookName);
                    $("#borrowBookDesc").val(JSONData.BookDesc);
                    $("#borrowBookQty").val(JSONData.BookQty);

                    if (JSONData.BookQty <= 0) {
                        $('#BorrowMessageContainer').show();
                        $('#BorrowMessage').text("The book is not available!");
                    }

                } else {
                    $('#BorrowMessageContainer').show();
                    $('#BorrowMessage').text("Invalid request");
                }
            },
            error: function (data) {
                $('#BorrowMessageContainer').show();
                $('#BorrowMessage').text("Invalid request");
            }
        });
    });
});

function CleanForm() {
    $("#txtBookID").val("")
    $("#txtBookQty").val("");
    $("#txtBookDesc").val("");
    $("#txtBookName").val("");
    $('#MessageContainer').hide();
    $('#Message').text("");
}

function CleanBorrowForm() {
    $("#borrowBookID").val("")
    $("#borrowBookQty").val("");
    $("#borrowBookDesc").val("");
    $("#borrowBookName").val("");
    $('#BorrowMessageContainer').hide();
    $('#BorrowMessage').text("");
}

function LoadResult(Data) {
    var Value = JSON.parse(JSON.stringify(Data));

    if (Value.Status == "Success") {
        $('#MessageContainer').show();
        $('#Message').text(Value.Message);

        setTimeout(function () {
            window.location = Value.URL;
        }, 2000)
    }
    else {
        $('#MessageContainer').show();
        $('#Message').text(Value.Message);
    }
}


function addData() {
    CleanForm()
}