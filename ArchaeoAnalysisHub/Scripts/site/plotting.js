$(document).ready(function () {
    $.getJSON("/api/plotting/getAnalysesToPlot", function (analyses) {
        if (analyses.length == 0) {
            return;
        }
        console.log(analyses.length);
        console.log(analyses);
        analyses.forEach(function (element) {
            var button = $("[data-analysis-id=" + element.analysisId + "]");
            button
                .removeClass("btn-default")
                .addClass("btn-info")
                .text("Plotting");
        });
    });
});

$(document).ready(function () {
    $(".js-toggle-plotting").click(function (e) {
        console.log('test')
        var button = $(e.target);
        if (button.text() == 'Plot?') {
            $.post("/api/plotting/plot", { AnalysisId: button.attr("data-analysis-id") })
                .done(function () {
                    button
                        .removeClass("btn-default")
                        .addClass("btn-info")
                        .text("Plotting");
                })
                .fail(function () {
                    alert("Something failed!");
                });
        }
        else {
            $.post("/api/plotting/unplot", { AnalysisId: button.attr("data-analysis-id") })
                .done(function () {
                    button
                        .removeClass("btn-info")
                        .addClass("btn-default")
                        .text("Plot?");
                })
                .fail(function () {
                    alert("Something failed!");
                });
        }
    });
});