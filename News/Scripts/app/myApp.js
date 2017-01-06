$(document).ready(function() {
    function getUsers() {
        $.ajax({
            url: "User/GetUsers",
            type: "Get",
            dataType:"json",
            success: function (response) {
                insertData(response);
            }
        });
    }
    getUsers();

    $('#userId').on('click', function () {
        sortUsers("ID");
    });
    $('#userName').on('click',function () {
        sortUsers("First Name");
    });
    $('#userLastName').on('click', function () {
        sortUsers("Last Name");
    });
    $('#userEmail').on('click', function () {
        sortUsers("Email");
    });

    /*-----------News-----------------*/
    function getNews() {
        $.ajax({
            url: "News/GetNews",
            type: "Get",
            dataType: "json",
            success: function (news) {
                insertNews(news);
            }
        });
    }
    getNews();
});
/*----------------------------------------*/
function insertData(data) {
    var target = $('#users');
    target.empty();
    for (var i = 0; i < data.length; i++) {
        var user = data[i];
        var newTr = $("<tr></tr>");
        newTr.attr('id', "user" + user.UserId);
        insertTd(newTr, new Array(user.UserId, user.FirstName, user.LastName, user.Email));
        newTr.on('click', function () {
            showDetails($(this).attr('id').substring(4));
        });
        target.append(newTr);
        //$('user' + i + ' #userId').text(user.UserId);
    }
}

function insertTd(tr, prop) {
    for (var i = 0; i < prop.length; i++) {
        var newTd = $("<td></td>");
        newTd.text(prop[i]);
        tr.append(newTd);
    }
}

function showDetails(data) {
    $.ajax({
        url: "User/Details",
        type: "Get",
        data: { id: data },
        success: function (response) {
            //insertData(response);
            $('#details').empty();
            $('#details').append(response);
        }
    });
}
function reloadUsers(users) {
    console.log("reloading");
    $('#details').empty();
    insertData(users);
}
function sortUsers(predicate) {
    $.ajax({
        url: "User/Sort",
        type: "Get",
        data: { by: predicate },
        success: function (response) {
            insertData(response);
        }
    });
}

function insertNews(news) {
    var target = $('#News');
    target.empty();
    for (var i = 0; i < news.length; i++) {
        target.append("<h2 class=\"tittle\">" + news[i].Tittle + "</h2><br/>");
        target.append("<p class=\"content\">" + news[i].Content + "</p>");
    }
}


