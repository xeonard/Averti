<?php
//start the session 
session_start();
//if session of this page is set, then this page has visited once
if( isset( $_SESSION['username'] ))
{
	// unset($_SESSION['username']);
	echo "welcome ". $_SESSION['username'];
}
?>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head >

<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<link rel="stylesheet" type="text/css" href="mystyle.css">
<link rel="shortcut icon" href="" >
<title>Iran website</title>
</head>


<body  >
<div id= "site">
	<div id="header">
		<div id="logo">
			<img id="logo-pic" border="0" src="images (1).PNG" width="60" height="50">
		</div>
		<h3 id="headername">
				</h3>
	</div>
	
	
		<div id="nav">
			<div id="nav_wrapper">
				<ul>
					<li><a href="index.php">Home</a></li>
					<li><a href="#History">History</a>
						<ul>
							<li><a href=""></a></li>
							<li><a href="">Sassanid </a></li>
							<li><a href=""></a></li>
						</ul>
					</li>
					<li><a href""></a>
						<ul>
							<li><a href=""></a></li>
							<li><a href=""></a></li>
							<li><a href=""></a></li>
							<li><a href=""></a></li>
							<li><a href=""></a></li>
						</ul>
					
					</li>
					
					<li><a href="Contact.php">Contact</a></li>
					<li><a href="#About">About</a>
						<ul>
							<li><a href=https://www.facebook.com/>facebook</a></li>
							<li><a href=http://en.wikipedia.org/wiki/??>Wikipedia</a></li>
							<li><a href=http://www.youtube.com/watch?v=]???>youtube</a></li>
						</ul>
					<?php
					// if session is set and user has logged in then make some pages accessable 
					if( isset( $_SESSION['username'] ))
					{
					 echo '<li><a href="logout.php">logout</a></li>';
					 echo '<li><a href="Personal_page.php">profile</a></li>';
					 echo '<li><a href="Contact.php">Contact</a></li>';
					}
					else 
					{
						echo '<li><a href="Login.php">login</a></li>';
					}
					?>
				</ul>

			</div>
	</div>
	
	
	<div id="content">
		
			<form action="login.php" method="post">
Username: <input type="text" name="username"><br><br>
password : 	<input type="password" name="password">
<input type="submit" value="Submit"><br><br>

do you want to remember password : 	<input type="checkbox" name="rememberme"><br><br>

		</form>
		<form action="register.php">
		register for the first time : <input type="submit" name="register" value="register">
		</form>
	<?php
if (isset ($_POST["username"])&&isset($_POST["password"]))
{
$name = $_POST["username"];
$pass = $_POST["password"];
$con=mysqli_connect("athena01.fhict.local","dbi297945","test","dbi297945");
// Check connection
if(! $con)
{
    die('Connection Failed'.mysql_error());
}
//select data from database
$result = mysqli_query($con,"SELECT username, password FROM visitors WHERE username = '$name'") or die(mysqli_error());
//loop on the result of selection to find data
while($row = mysqli_fetch_array($result, MYSQLI_ASSOC)) 
{
//if there is a user with this password
	if($row["username"]==$name && $row["password"]==$pass)
	{
	//then user is in the website already 
		echo"You are a validated user.";
		echo "welcome ". $name;
		
		if( isset( $_SESSION['username'] ) )
	   {
		  echo "you are already in the webiste";
	   }
	   else
	   {
	   //else make a new session for username
		  $_SESSION['username'] = $name;
		  if (!isset ($_COOKIE['username'])){
		  //if there is no cookie then make new cookie for this user
		  setcookie('username', $name, time()+60*60*24*365);
		  }
		  echo '<script>parent.window.location.reload(true);</script>';
	   }
			
	}
	else
	{
		echo"Sorry, your credentials are not valid, Please try again.";
	}
}
}
?>
		
	</div>

</div>

</body>
</html>