$(function () {
    $('.header-click').click(function () {
        var sort = SortTable(this);
        GetEvents({
            StatusEvent: $('#status').val(),
            Category: $('#categories').val(),
            SortByField: $(this).data('clickdata'),
            SortMethod: sort
        });
    });

    $('#applyFilters').click(function () {
        GetEvents({ StatusEvent: $('#status').val(), Category: $('#categories').val(), SortByField: '' });
    });

    $('#cleanFilters').click(function () {
        $('#status,#categories').val('');
        GetEvents({});
    });

    function GetEvents(search) {
        $("#bodyEvents").empty();
        $.ajax({
            url: 'https://localhost:44300/api/Event',
            dataType: 'json',
            method: 'POST',
            data: JSON.stringify(search),
            contentType: 'application/json',
            success: function (data) {
                if (data && data.events && data.events.length > 0) {
                    $(data.events).each(function (index, element) {
                        var elementRow = $('<tr>');
                        var elementID = $("<td>", { "text": element.id });
                        var elementTitle = $("<td>", { "text": element.title });
                        var elementIsClosed = $("<td>", { "text": element.isClosed ? 'Yes' : 'No' });
                        var elementLink = $('<td>').append($("<a>", { "href": "\EventDetail?e=" + element.id, "text": "Details" }));
                        elementRow.append(elementID);
                        elementRow.append(elementTitle);
                        elementRow.append(elementIsClosed);
                        elementRow.append(elementLink);
                        $('#bodyEvents').append(elementRow);

                    });
                }
                else {
                    alert('Data not found!');
                }
            },
            error: function (error) {
                console.log(error);
                alert('Data not found!');
            }
        });
    }

    function GetCategories() {
        $('#categories option').empty();
        $.ajax({
            url: 'https://localhost:44300/api/Category',
            dataType: 'json',
            contentType: 'application/json',
            success: function (data) {
                if (data) {
                    $(data).each(function (index, element) {
                        var option = $("<option>", { "value": element.id, 'text': element.title });
                        $('#categories').append(option);
                    });
                }
                else {

                }
            },
            error: function (error) {
                console.log(error);
            }
        });
    }

    function init() {
        GetEvents({});
        GetCategories();
    }
    init();
});