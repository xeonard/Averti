
$(document).ready(function(){
	//Hides forms
	$('.login').hide();
	$('.signup').hide();
	
	//Method for showing the log in form
  $('#login').click(function(){
	$('.login').show("slow");
	$('.signup').hide();
  });
  
  	//method for closing the log in form
  $('.btnCloseLogin').click(function(){
	$('.login').hide();
  });
	
	//Method for showing the sign up form
  $('#signup').click(function(){
	$('.signup').show("slow");
	$('.login').hide();
  });
  
  	//method for closing the sign up form
  $('.btnCloseSignUp').click(function(){
	$('.signup').hide("slow");
  });
	
	//show map on profile page
  $('.btnmap').click(function(){
	 $('.map').show(); 
	 $('.profinfo').hide();
  });
	
	//show profile info on profile page
	$('.btnprofinfo').click(function(){
	 $('.map').hide(); 
	 $('.profinfo').show();
  });
});

