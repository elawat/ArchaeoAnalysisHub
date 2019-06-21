$(document).ready(function () {
    var elements = $(".wordcloud");
    for (var i = 0; i < elements.length; i++) {
        var wordsList = [];
        var element = elements[i];
        var symbols = $("th." + element.id);
        var percentages = $("td." + element.id);
        for (j = 0; j < symbols.length; j++) {
            wordsList.push({ text: symbols[j].innerText, weight: Math.round(parseInt(percentages[j].innerText, 10) / 10) });
        }
        $("#" + element.id).jQCloud(wordsList,
            {
                steps: 5,
                width: 100,
                height: 100
            }
        );
    }
});