<?php
//start session 
session_start();
//if there is a sessoin for counting 
   if( isset( $_SESSION['counter'] ) )
   {
   //then add one to that 
      $_SESSION['counter'] += 1;
   }
   else
   {
   //else make a new session and print it
      $_SESSION['counter'] = 1;
	  echo "in this session.";
   }
   echo "You have visited this page ".  $_SESSION['counter']. " Times";
   
?>