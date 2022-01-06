// Write your Javascript code.

ShowPopUp = function (URL, Title) {
    
    $.ajax({
        type: "GET",
        url: URL,
        success: function (result) {
            $('#form-modal .modal-body').html(result);
            $('#form-modal .modal-title').html(Title);
            $('#form-modal').modal('show');

        }
    })
}

ClosePopUp = function () {
    $('#form-modal').modal('hide');
}

searchResult = function (URL) {
    let searched = document.getElementById('LiveSearch').value;

    $.ajax({
        type: "POST",
        url: URL,
        data: { value: searched},
        success: function (result) {
            $('#render').html( result) 
           console.log('Success Search')
        },
        error: function (er) {
            console.log(er)
        }
    })
    
}

AjaxSubmitForm = form => {
    $.ajax({
        type: 'POST',
        url: form.action,
        data: new FormData(form),
        contentType: false,
        processData: false,
        success: function (result) {
            if (result.isValid) {
                console.log('here');
            } else {
                $('#form-modal .modal-body').html(result);
            }
        },
        error: function (error) {
            console.log(error);
        }
    })
}

