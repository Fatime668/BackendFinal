    //preloader
let loader = document.getElementById("preloader")
    window.addEventListener('load',function(){
        loader.style.display = "none";
    });
    //preloader
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
    //datetime
  
    
    //range slider
    //$( function() {
    //    $( "#slider-range" ).slider({
    //      range: true,
    //      min: 49,
    //      max: 259,
    //      values: [ 49, 259 ],
    //      slide: function( event, ui ) {
    //        $( "#amount" ).val( "$" + ui.values[ 0 ] + " - $" + ui.values[ 1 ] );
    //      }
    //    });
    //    $( "#amount" ).val( "$" + $( "#slider-range" ).slider( "values", 0 ) +
    //      " - $" + $( "#slider-range" ).slider( "values", 1 ) );
    //  } );
    //  $(".price").click(function(){
    //    $(".price .dropdown").toggleClass("active")
    //  })
    //range slider

   