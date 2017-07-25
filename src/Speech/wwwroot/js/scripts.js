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

    // Show process text when click an image
    $("img#schedule-img").click(function () {
        $("div.consultation").hide();
        $("div.evaluation").hide();
        $("div.recommendations").hide();
        $("div.sessions").hide();
        $("div.instruction").hide();
        $("div.schedule").show();
    })
    $("img#consultation-img").click(function () {
        $("div.schedule").hide();
        $("div.evaluation").hide();
        $("div.recommendations").hide();
        $("div.sessions").hide();
        $("div.instruction").hide();
        $("div.consultation").show();
    })
    $("img#eval-img").click(function () {
        $("div.schedule").hide();
        $("div.consultation").hide();
        $("div.recommendations").hide();
        $("div.sessions").hide();
        $("div.instruction").hide();
        $("div.evaluation").show();
    })
    $("img#recommendations-img").click(function () {
        $("div.schedule").hide();
        $("div.consultation").hide();
        $("div.evaluation").hide();
        $("div.sessions").hide();
        $("div.instruction").hide();
        $("div.recommendations").show();
    })
    $("img#sessions-img").click(function () {
        $("div.schedule").hide();
        $("div.consultation").hide();
        $("div.evaluation").hide();
        $("div.recommendations").hide();
        $("div.instruction").hide();
        $("div.sessions").show();
    })


    ////scroll down to section of page
    //$("#company").click(function () {
    //    $('html,body').animate({
    //        scrollTop: $(".company").offset().top
    //    }, 'slow');
    //});
    //$("#therapist").click(function () {
    //    $('html,body').animate({
    //        scrollTop: $(".therapist").offset().top
    //    }, 'slow');
    //});
    //$("#teletherapy").click(function () {
    //    $('html,body').animate({
    //        scrollTop: $(".teletherapy").offset().top
    //    }, 'slow');
    //});
    //    //up arrow
    //$(".up-arrow").click(function () {
    //    $("html, body").animate({ scrollTop: 0 }, "slow");
    //});


    //Displays result of marking a goal as met
    $('.complete').click(function () {
        var route = '#completed-goal-' + this.id;
        $.ajax({
            type: 'GET',
            url: '../Complete/' + this.id,
            success: function (result) {
                $(route).html(result);
            }
        });
    });
});

