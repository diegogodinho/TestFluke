function SortTable(item) {
    var sort = $(item).data('sort');
    if (sort.length === 0) {
        sort = 'asc';
        $(item).find('i').removeClass('fa-sort');
        $(item).find('i').addClass('fa-caret-up');
    }
    else if (sort === 'asc') {
        sort = 'desc';
        $(item).find('i').removeClass('fa-caret-up');
        $(item).find('i').addClass('fa-caret-down');
    }
    else if (sort === 'desc') {
        sort = 'asc';
        $(item).find('i').removeClass('fa-caret-down');
        $(item).find('i').addClass('fa-caret-up');
    }
    $(item).data('sort', sort);
    return sort;
}