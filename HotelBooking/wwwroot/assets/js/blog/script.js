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
  //gallery
  $(document).ready(function(){
    $('.list').click(function(){
      const value=$(this).attr('data-filter');
      if(value == 'All'){
        $('.itemBox').show('1000');
      }else{
        $('.itemBox').not('.'+value).hide('1000');
        $('.itemBox').filter('.'+value).show('1000');
      }
    })
    //add active class on selected item
    $('.list').click(function () {
      $(this).addClass('active').siblings().removeClass('active');
      })
    //gallery slayd and zoom image
    $('[data-fancybox]').fancybox({
      animationEffect : "slide"
    })
  })