//preloader
let loader = document.getElementById("preloader")
    window.addEventListener('load',function(){
        loader.style.display = "none";
    });
    //bact to top
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
    //slider
    $('.owl-carousel').owlCarousel({
      stagePadding: 50,
      loop:true,
      margin:10,
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
  //video
  $('#videolink').magnificPopup({
    type:'inline',
    midClick:true

  })
  //animation js
  AOS.init();