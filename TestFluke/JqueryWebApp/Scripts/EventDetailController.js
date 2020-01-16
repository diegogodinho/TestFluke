$(function () {
    $('.header-click').click(function () {
        var sort = SortTable(this);
        GetEvent({
            EventID: $('#eventID').val(),
            SortByField: $(this).data('clickdata'),
            SortMethod: sort
        });
    });
    function GetEvent(model) {
        $("#bodyCategories").empty();
        $.ajax({
            url: 'https://localhost:44300/api/Event/GetByID',
            dataType: 'json',
            method: 'POST',
            contentType: 'application/json',
            data: JSON.stringify(model),
            success: function (data) {
                $('#Title').val(data.title);
                $('#Link').val(data.link);
                $('#Description').val(data.description);
                $('#IsClosed').val(data.isClosed);
                debugger;
                if (data.closed) {
                    var newDate = formatDate(data.closed);
                    console.log(newDate);
                    $('#DataClosed').val(newDate);
                }

                $(data.categories).each(function (index, element) {
                    var elementRow = $('<tr>');
                    var elementID = $("<td>", { "text": element.id });
                    var elementTitle = $("<td>", { "text": element.title });
                    elementRow.append(elementID);
                    elementRow.append(elementTitle);
                    $('#bodyCategories').append(elementRow);
                });
            },
            error: function (error) {
                console.log(error);
            }
        });
    }

    function formatDate(date) {
        date = new Date(date);
        var dd = date.getDate();
        var mm = date.getMonth() + 1;
        var yyyy = date.getFullYear();
        if (dd < 10) {
            dd = '0' + dd;
        }
        if (mm < 10) {
            mm = '0' + mm;
        }
        return dd + '/' + mm + '/' + yyyy;
    }

    function init() {
        GetEvent({ EventID: $('#eventID').val() });
    }
    init();
});