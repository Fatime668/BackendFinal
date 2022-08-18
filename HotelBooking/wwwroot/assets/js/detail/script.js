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
    //datetime
    $(document).ready(function(){
      config = {
        altInput: true,
        altFormat: "F j, Y",
        dateFormat: "Y-m-d",
    }
    flatpickr("input[type=datetime-local]", config);
    })
    //slider
    $('.owl-carousel').owlCarousel({
        loop:true,
        margin:60,
        nav:true,
        responsive:{
            0:{
                items:1
            },
            600:{
                items:1
            },
            1000:{
                items:1
            }
        }
    })  
$(document).ready(function(){
   
    //animation js
    AOS.init();
})