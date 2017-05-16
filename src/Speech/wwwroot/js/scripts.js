$(document).ready(function () {
    console.log("scripts working");
    $("#DemoCarousel").carousel();

    //Carousel Actions
    $(".start").click(function () {
        $("#DemoCarousel").carousel('cycle');
    });
    $(".pause").click(function () {
        $("#DemoCarousel").carousel('pause');
    });

    //Carousel Controls
    $(".prevSlide").click(function () {
        $("#DemoCarousel").carousel('prev');
    });
    $(".nextSlide").click(function () {
        $("#DemoCarousel").carousel('next');
    });

    //Carousel Indicators
    $(".slide-1").click(function () {
        $("#DemoCarousel").carousel(0);
    });
    $(".slide-2").click(function () {
        $("#DemoCarousel").carousel(1);
    });
    $(".slide-3").click(function () {
        $("#DemoCarousel").carousel(2);
    });
});