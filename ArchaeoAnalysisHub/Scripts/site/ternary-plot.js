$(document).ready(function () {

    var symbolA = $("#symbolA").children("option:selected").val();
    var symbolB = $("#symbolB").children("option:selected").val();
    var symbolC = $("#symbolC").children("option:selected").val();

    var labelsDto = {
        LabelA: symbolA,
        LabelB: symbolB,
        LabelC: symbolC
    };

    $.getJSON("/api/plotting/getPointsForTernaryPlot",
        labelsDto,
        function (points) {
            if (points.length == 0) {
                alert("No analysis selected.")
                return;
            }

            for (i = 0; i < points.length; i++) {
                var obj = points[i];
            }

            //ACTIVATE!
            var plot_opts = {
                side: 400,
                margin: { top: 70, left: 150, bottom: 150, right: 150 },
                axis_labels: [symbolA, symbolB, symbolC],
                axis_ticks: d3.range(0, 101, 20),
                minor_axis_ticks: d3.range(0, 101, 5)
            }

            var tp = ternaryPlot('#plot', plot_opts);

            var d = []
            for (var i = 0; i < points.length; i++) {
                var obj = points[i];
                d.push({
                    vertexAValue: obj.vertexAValue,
                    vertexBValue: obj.vertexBValue,
                    vertexCValue: obj.vertexCValue,
                    label: obj.label,
                    colour: '#' + (0x1000000 + (Math.random()) * 0xffffff).toString(16).substr(1, 6)
                })
            }
            tp.data(d, function (d) { return [d.vertexAValue, d.vertexBValue, d.vertexCValue, d.label, d.colour] });

            // Update list of analysis
            d3.select('#analyses-list')
                .selectAll('li')
                .data(d)
                .enter()
                .append('li')
                .text(function (d) { return d.label; })
                .style('color', function (d) { return d.colour; });
        });
});


function ternaryPlot(selector, userOpt) {

    var plot = {
        dataset: []
    };

    var opt = {
        width: 100,
        height: 500,
        side: 700,
        margin: { top: 50, left: 50, bottom: 50, right: 50 },
        axis_labels: ['A', 'B', 'C'],
        axis_ticks: [0, 20, 40, 60, 80, 100],
        tickLabelMargin: 10,
        axisLabelMargin: 40
    }

    for (var o in userOpt) {
        opt[o] = userOpt[o];
    }

    var svg = d3.select(selector).append('svg')
        .attr("width", opt.width + '%')
        .attr("height", opt.height);

    var axes = svg.append('g').attr('class', 'axes');

    var w = opt.side;
    var h = Math.sqrt(opt.side * opt.side - (opt.side / 2) * (opt.side / 2));

    var corners = [
        [opt.margin.left, h + opt.margin.top], // a
        [w + opt.margin.left, h + opt.margin.top], //b
        [(w / 2) + opt.margin.left, opt.margin.top]] //c

    //axis names
    axes.selectAll('.axis-title')
        .data(opt.axis_labels)
        .enter()
        .append('g')
        .attr('class', 'axis-title')
        .attr('transform', function (d, i) {
            return 'translate(' + corners[i][0] + ',' + corners[i][1] + ')';
        })
        .append('text')
        .text(function (d) { return d; })
        .attr('text-anchor', function (d, i) {
            if (i === 0) return 'end';
            if (i === 2) return 'middle';
            return 'start';

        })
        .attr('transform', function (d, i) {
            var theta = 0;
            if (i === 0) theta = 120;
            if (i === 1) theta = 60;
            if (i === 2) theta = -90;

            var x = opt.axisLabelMargin * Math.cos(theta * 0.0174532925),
                y = opt.axisLabelMargin * Math.sin(theta * 0.0174532925);
            return 'translate(' + x + ',' + y + ')'
        });


    //ticks
    //(TODO: this seems a bit verbose/ repetitive!);
    var n = opt.axis_ticks.length;
    if (opt.minor_axis_ticks) {
        opt.minor_axis_ticks.forEach(function (v) {
            var coord1 = coord([v, 0, 100 - v]);
            var coord2 = coord([v, 100 - v, 0]);
            var coord3 = coord([0, 100 - v, v]);
            var coord4 = coord([100 - v, 0, v]);

            axes.append("line")
                .attr(lineAttributes(coord1, coord2))
                .classed('a-axis minor-tick', true);

            axes.append("line")
                .attr(lineAttributes(coord2, coord3))
                .classed('b-axis minor-tick', true);

            axes.append("line")
                .attr(lineAttributes(coord3, coord4))
                .classed('c-axis minor-tick', true);
        });
    }

    opt.axis_ticks.forEach(function (v) {
        var coord1 = coord([v, 0, 100 - v]);
        var coord2 = coord([v, 100 - v, 0]);
        var coord3 = coord([0, 100 - v, v]);
        var coord4 = coord([100 - v, 0, v]);

        axes.append("line")
            .attr(lineAttributes(coord1, coord2))
            .classed('a-axis tick', true);

        axes.append("line")
            .attr(lineAttributes(coord2, coord3))
            .classed('b-axis tick', true);

        axes.append("line")
            .attr(lineAttributes(coord3, coord4))
            .classed('c-axis tick', true);


        //tick labels
        axes.append('g')
            .attr('transform', function (d) {
                return 'translate(' + coord1[0] + ',' + coord1[1] + ')'
            })
            .append("text")
            .attr('transform', 'rotate(60)')
            .attr('text-anchor', 'end')
            .attr('x', -opt.tickLabelMargin)
            .text(function (d) { return v; })
            .classed('a-axis tick-text', true);

        axes.append('g')
            .attr('transform', function (d) {
                return 'translate(' + coord2[0] + ',' + coord2[1] + ')'
            })
            .append("text")
            .attr('transform', 'rotate(-60)')
            .attr('text-anchor', 'end')
            .attr('x', -opt.tickLabelMargin)
            .text(function (d) { return (100 - v); })
            .classed('b-axis tick-text', true);

        axes.append('g')
            .attr('transform', function (d) {
                return 'translate(' + coord3[0] + ',' + coord3[1] + ')'
            })
            .append("text")
            .text(function (d) { return v; })
            .attr('x', opt.tickLabelMargin)
            .classed('c-axis tick-text', true);

    })

    function lineAttributes(p1, p2) {
        return {
            x1: p1[0], y1: p1[1],
            x2: p2[0], y2: p2[1]
        };
    }

    function coord(arr) {
        var a = arr[0], b = arr[1], c = arr[2];
        var sum, pos = [0, 0];
        sum = a + b + c;
        if (sum !== 0) {
            a /= sum;
            b /= sum;
            c /= sum;
            pos[0] = corners[0][0] * a + corners[1][0] * b + corners[2][0] * c;
            pos[1] = corners[0][1] * a + corners[1][1] * b + corners[2][1] * c;
            pos[2] = arr[3]; // label;
            pos[3] = arr[4]; // colour
        }
        return pos;
    }

    plot.data = function (data, accessor, bindBy) { //bind by is the dataset property used as an id for the join
        plot.dataset = data;

        var circles = svg.selectAll("circle")
            .data(data.map(function (d) { return coord(accessor(d)); }), function (d, i) {
                if (bindBy) {
                    return plot.dataset[i][bindBy];
                }
                return i;
            });

        circles.enter()
            .append("circle");

        circles.transition()
            .attr("cx", function (d) { return d[0]; })
            .attr("cy", function (d) { return d[1]; })
            .attr("r", 6);

        circles
            .attr("title", function (d) { return d[2]; })
            .attr("id", function (d) { return d[2]; })
            .style("fill", function (d) { return d[3]; })
            .style("stroke", function (d) { return d[3]; });

        circles.append("title").text(function (d) { return 'Analysis id: ' + d[2]; });

        return this;
    }

    plot.getPosition = coord;

    return plot;
}