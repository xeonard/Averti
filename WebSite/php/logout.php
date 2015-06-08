<?php
//start session 
session_start();
//if there is a session for username
if( isset( $_SESSION['username'] ))
{
//then unset it 
	unset($_SESSION['username']);
	unset($_SESSION['ID']);
	session_destroy();
}
//if there is coolie for username
if (isset ($_COOKIE['username']))
{
//then unset cookie 
unset ($_COOKIE['username']);
	setcookie('username', null,-1);
	setcookie('ID',null,-1);
}
// get back to the login page
header ("Location: login.php");
exit;
?>