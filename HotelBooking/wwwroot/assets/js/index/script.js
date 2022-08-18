let loader = document.getElementById("preloader")
    window.addEventListener('load',function(){
        loader.style.display = "none";
    });
    $('#top-btn').fadeOut();

    $(window).on('scroll', function(){
      if($(this).scrollTop()>40){
        $('#top-btn').fadeIn();
      }else{
        $('#top-btn').fadeOut();
      }
    })

    $('#top-btn').click(function(){
      $('html, body').animate({scrollTop:0}, 800);  
    })
$(document).ready(function(){
    config = {
        altInput: true,
        altFormat: "F j, Y",
        dateFormat: "Y-m-d",
    }
    flatpickr("input[type=datetime-local]", config);

    $('#booking .downmenu').click(function(){
        $('.dropdown').toggleClass("active")
    })

    $('.owl-carousel').owlCarousel({
        loop:false,
        margin:10,
        dots: true,
        items:5,
        responsive:{
            0:{
                items:1
            },
            600:{
                items:1
            },
            850:{
                items:1
            },
            992:{
                items:2
            },
            1000:{
                items:2
            },
            1300:{
                items:3
            }
            
        }
    })
    //counter
    $('.counter').counterUp({
        delay:10,
        time:1200
    })
    //animation js
    AOS.init();
})
