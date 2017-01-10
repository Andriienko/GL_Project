$(document).ready(function() {
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

function insertNews(news) {
    var target = $('#News');
    target.empty();
    for (var i = 0; i < news.length; i++) {
        target.append("<h2 class=\"tittle\">" + news[i].Tittle + "</h2><br/>");
        target.append("<p class=\"content\">" + news[i].Content + "</p>");
    }
}