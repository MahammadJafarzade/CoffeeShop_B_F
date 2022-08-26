$('.slick-slider').slick({
  dots: true,
  infinite: false,
  speed: 300,
  slidesToShow: 4,
  slidesToScroll: 1,
  infinite: true,
  responsive: [
    {
      breakpoint: 1024,
      settings: {
        slidesToShow: 3,
        slidesToScroll: 1,
        infinite: true,
        dots: true
      }
    },
    {
      breakpoint: 600,
      settings: {
        slidesToShow: 2,
        slidesToScroll: 1
      }
    },
    {
      breakpoint: 480,
      settings: {
        slidesToShow: 1,
        slidesToScroll: 1
      }
    }
    // You can unslick at a given breakpoint now by adding:
    // settings: "unslick"
    // instead of a settings object
  ]
});
$('.slick-blog').slick({
  dots: true,
  infinite: false,
  speed: 300,
  slidesToShow: 3,
  slidesToScroll: 1,
  infinite: true,
  responsive: [
    {
      breakpoint: 1024,
      settings: {
        slidesToShow: 2,
        slidesToScroll: 1,
        infinite: true,
        dots: true
      }
    },
    {
      breakpoint: 600,
      settings: {
        slidesToShow: 1,
        slidesToScroll: 1
      }
    },
    // You can unslick at a given breakpoint now by adding:
    // settings: "unslick"
    // instead of a settings object
  ]
});


$('.media-info').slick({
  dots: true,
  infinite: false,
  speed: 300,
  slidesToShow: 4,
  slidesToScroll: 1,
  infinite: true,
  responsive: [
    {
      breakpoint: 1248,
      settings: {
        slidesToShow: 3,
        slidesToScroll: 1,
        infinite: true,
        dots: true
      }
    },
    {
      breakpoint: 992,
      settings: {
        slidesToShow: 2,
        slidesToScroll: 1,
        infinite: true,
        dots: true
    }
  },
    {
      breakpoint: 768,
      settings: {
        slidesToShow: 1,
        slidesToScroll: 1,
        infinite: true,
        dots: true
      }
    },
    // You can unslick at a given breakpoint now by adding:
    // settings: "unslick"
    // instead of a settings object
  ]
});
function getVals(){
  let parent=this.parentNode;
  let slides=parent.getElementsByTagName("input");
  let slide1 = parseFloat(slides[0].value);
  let slide2 = parseFloat(slides[1].value);
  if(slide1>slide2){
    let tmp=slide2; slide2=slide1; slide1=tmp;
  }
  let displayElement=parent.getElementsByClassName("range-values")[0];
  displayElement.innerHTML="$" + slide1 + "-$" + slide2;
}
window.onload=function(){
  let sliderSections=document.getElementsByClassName("range-slider");
  for(let x = 0; x<sliderSections.length; x++){
    let sliders = sliderSections[x].getElementsByTagName("input");
    for(let y = 0; y<sliderSections.length; y++){
      if(sliders[y].type === "range"){
        sliders[y].oninput=getVals;
        sliders[y].oninput();
      }
    }
  }
}
AOS.init({
  duration: 1000,
});
 //Get the button
 var mybutton = document.getElementById("myBtn");
        
 // When the user scrolls down 20px from the top of the document, show the button
 window.onscroll = function() {scrollFunction()};
 
 function scrollFunction() {
   if (document.body.scrollTop > 30 || document.documentElement.scrollTop > 30) {
     mybutton.style.display = "block";
   } else {
     mybutton.style.display = "none";
   }
 }
 
 // When the user clicks on the button, scroll to the top of the document
 function topFunction() {
   document.body.scrollTop = 0;
   document.documentElement.scrollTop = 0;
 }
