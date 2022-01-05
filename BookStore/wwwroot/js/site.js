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
            $('#main').html( result) 
           console.log('Success Search')

        }
    })
    
}