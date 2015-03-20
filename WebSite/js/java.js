
$(document).ready(function(){
	$('.login').hide();
	//Method for showing the log in form
  $('#login').click(function(){
	$('.login').show("slow");
  });
  
  	//method for closing the log in form
  $('.btnClose').click(function(){
	$('.login').hide("slow");
  });
});

