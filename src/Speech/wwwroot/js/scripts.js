$(document).ready(function () {
    // Activate Carousel
    $("#myCarousel").carousel();

    // Enable Carousel Indicators
    $(".item1").click(function () {
        $("#myCarousel").carousel(0);
    });
    $(".item2").click(function () {
        $("#myCarousel").carousel(1);
    });
    $(".item3").click(function () {
        $("#myCarousel").carousel(2);
    });
   
    // Enable Carousel Controls
    $(".left").click(function () {
        $("#myCarousel").carousel("prev");
    });
    $(".right").click(function () {
        $("#myCarousel").carousel("next");
    });

    // Show process text when hover over image
    $("img#schedule-img").hover(function () {
        $("div.schedule").toggle();
    })
    $("img#consultation-img").hover(function () {
        $("div.consultation").toggle();
    })
    $("img#eval-img").hover(function () {
        $("div.evaluation").toggle();
    })
    $("img#recommendations-img").hover(function () {
        $("div.recommendations").toggle();
    })
    $("img#sessions-img").hover(function () {
        $("div.sessions").toggle();
    })
});

