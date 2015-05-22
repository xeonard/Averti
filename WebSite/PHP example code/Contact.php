<?php
//start the session
session_start();
?>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head >

<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<link rel="stylesheet" type="text/css" href="mystyle.css">
<link rel="shortcut icon" href="iran_flag.ico" >
<title>Name of our website </title>
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
							<li><a href=""></a></li>
							<li><a href=""></a></li>
						</ul>
					</li>
					<li><a href=""></a>
						<ul>
							<li><a href=""></a></li>
							<li><a href=""></a></li>
							<li><a href=""</a></li>
							<li><a href=""></a></li>
							<li><a href=""></a></li>
						</ul>
					
					</li>
					
			
					<li><a href="#About">About</a>
						<ul>
							<li><a href=https://www.facebook.com/???.???>facebook</a></li>
							<li><a href=http://en.wikipedia.org/wiki/??(if we have some information in Wiki !>Wikipedia</a></li>
							<li><a href=http://www.youtube.com/watch?v=???? (if we have some data in youtube !)>youtube</a></li>
						</ul>
					</li>
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
		
<form  action="Contact.php" method="post">
<textarea name="posttext" cols="92" rows="15" tabindex="101">
</textarea>
<input type="submit" value="Submit"><br>
</form>
<?php
//if there is any post then send this post to my email in fontys
	if (isset($_POST['posttext']))
	{
		$message = $_POST['posttext'];
		$email = 'r.halvaei@student.fontys.nl'; 
		$subject = $_SESSION['username'];
		mail($email, $subject, $message);
		}
		
?>
		
	</div>

</div>

</body>
</html>
