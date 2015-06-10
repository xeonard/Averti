<?php
    session_start();
    
?>
<html>
<head>
	<title>Averti Festival</title>
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <link href="css/bootstrap.css" rel="stylesheet">
    <link rel="stylesheet" href="css/menu.css" >
    <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.11.0/jquery.min.js"></script>
    <script src="js/java.js"></script>
	<script src="js/bootstrap.js"></script>
</head>
<body>
    
	<?php include 'php/navigation.php'; ?>
        
     <div class="home">
		<div class="dates">
			<h1>
				Averti Festival
			</h1>
			<h2>12/12/12</h2>
		</div>
		<div class="buttons">
			<a href="tickets.html">Buy Tickets</a>
			<a href="learnmore.html">Learn More</a>
		</div>
	</div>
	
		
    	<div class="learn-more" style="padding-top: 20px;" >
    		<div class="container">
    			<h1>Summary</h1>
    			<div class="col-md-4"> 

    				<img src="Images/img.jpg" height="200" width="300">
    				<h4>Day 1</h4>

    				<p>During this day you will have an amezing day in a forest with a banch of activities. In the evening you will enjoy the rock concert.</p>
    			</div>
    			<div class="col-md-4">
    				<img src="Images/imgconcert.jpg" height="200" width="300">
    				<h4>Day 2</h4>
    				<p>During second day you will have a chance to fight for the winning in a paintball game. In the evening the pop music concert will take place.</p>
    			</div>
    			<div class="col-md-4">
    				<img src="Images/beachimg.jpg" height="200" width="300">
    				<h4>Day 3</h4>
    				<p>Third day will take place near the lake. You will be able to take part in diferent water sport activities such as volleyball, canoeing, beach football, etc.</p>
    			</div>
    		</div>
   		</div>
		
   		<div class="Question">
   				<h4 style="padding-top: 20px;">You have any question?</h4>
   				<p>Contact us by <a href="mailto:averti@gmail.com" target="_top">E-Mail</a>!</p>
   				<p><img src="Images/dimalogo.png" height="100"></p>
   		</div>
   		
   		<!--sign up form-->
   		<div class="signup" >
      		<form action="php/registration.php" method="POST">
      			<label for="email">Email</label>
      			<input type="text" id="email" name="email">
      			<label for="username">Username</label>
      			<input type="text" id="username" name="username">
                        <label for="name">Name</label>
      			<input type="text" id="password" name="name">
      			<label for="password">Password</label>
      			<input type="password" id="password" name="password">
      				<div id="lower">
      					<input type="submit" value="Sign Up" onclick="window.location.href='profile.html'">
      					<input type="reset" value="Close" class="btnCloseSignUp">
      				</div>
      		</form>
      	</div>
      	
      	<!--login form-->
        <div class="login">
      		<form action="php/login.php" method="POST">
      			<label for="username">Username</label>
      			<input type="text" id="username" name="username">
      			<label for="password">Password</label>
      			<input type="text" id="password" name="password">
      				<div id="lower">
      					<input type="submit" value="Login">
      					<input type="reset" value="Close" class="btnCloseLogin">
      				</div>
      		</form>
      	</div>
</html>