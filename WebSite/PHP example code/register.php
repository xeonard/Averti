<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head >

<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<link rel="stylesheet" type="text/css" href="mystyle.css">
<link rel="shortcut icon" href="iran_flag.ico" >
<title>Iran website</title>
</head>


<body  >
<div id= "site">
	<div id="header">
		<div id="logo">
			<img id="logo-pic" border="0" src="images (1).PNG" width="60" height="50">
		</div>
		<h3 id="headername">
		My Country
		</h3>
	</div>
	
	
		<div id="nav">
			<div id="nav_wrapper">
				<ul>
					<li><a href="index.php">Home</a></li>
					<li><a href="#History">History</a>
						<ul>
							<li><a href="]">]]</a></li>
							<li><a href="]">] ]</a></li>
							<li><a href="]">] ]</a></li>
						</ul>
					</li>
					<li><a href="#Culture">Culture</a>
						<ul>
							<li><a href="Architecture.php">Architecture</a></li>
							<li><a href="]">]</a></li>
							<li><a href="Cinema.php">Cinema</a></li>
							<li><a href="Literature.php">Literature</a></li>
							<li><a href="Recipes.php">Recipes</a></li>
						</ul>
					
					</li>
					
			
					<li><a href="#About">About</a>
						<ul>
							<li><a href=https://www.facebook.com/??>facebook</a></li>
							<li><a href=http://en.wikipedia.org/wiki/??>Wikipedia</a></li>
							<li><a href=http://www.youtube.com/watch?v=??>youtube</a></li>
						</ul>
					</li><li><a href="Login.php">login</a></li>
				</ul>

			</div>
	</div>
	
	
	<div id="content">
		
	<form action="register.php" method="post">
	name: <input type="text" name="name"><br><br>
	family: <input type="text" name="family"><br><br>
	email: <input type="text" name="email"><br><br>
	Username: <input type="text" name="username1"><br><br>
	Username config: <input type="text" name="username2"><br><br>
	password: <input type="password" name="password1"><br><br>
	password config: <input type="password" name="password2"><br><br>
	click here for submitting your information<input type="submit" name="submit">
	</form>
	<?php
	// if there is user name and password in the form
	if (isset($_POST['name'])&&isset($_POST['family']))
	{
	// take information from form
		$name = $_POST['name'];
		$family = $_POST['family'];
		$email = $_POST['email'];
		
			$username = $_POST["username1"];
			
		$password = $_POST['password1'];
		echo $name;
		echo $family;
// make connection 
$con=mysqli_connect("athena01.fhict.local","dbi297945","test","dbi297945");
// Check connection
if (mysqli_connect_errno()) {
  echo "Failed to connect to MySQL: " . mysqli_connect_error();
}

$subject = "welcome to ?? website";
$message = "now you are member of this website and we are pride that we have you as new member among us";
$name = mysqli_real_escape_string($con, $_POST['name']);
$family = mysqli_real_escape_string($con, $_POST['family']);
$username = mysqli_real_escape_string($con, $_POST["username2"]);
$password = mysqli_real_escape_string($con, $_POST["password2"]);
$email = mysqli_real_escape_string($con, $_POST['email']);
// make sql string to put in the database
$sql="INSERT INTO visitors (Name, family, email, username, password)
VALUES ('$name', '$family', '$email', '$username', '$password')";
// if there are information for this connction 
if (!mysqli_query($con,$sql)) {
  die('Error: ' . mysqli_error($con));
}
// send email to the user
echo "you will receive an Email";
mail($email, $subject, $message);
// close the connection
mysqli_close($con);
	}
	?>
		
	</div>

</div>

</body>
</html>
