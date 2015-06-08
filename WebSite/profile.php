<?php
    include 'php/PDO.php';
    session_start();
    if(!isset($_SESSION['username'])){
    header( "refresh:0; url=index.php" );
}
?>

<html>
<head>
	<title>Averti Festival</title>
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <link href="css/bootstrap.css" rel="stylesheet">
    <link rel="stylesheet" href="css/profile.css" >
    <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.11.0/jquery.min.js"></script>
    <script src="js/java.js"></script>
	<script src="js/bootstrap.js"></script>
</head>
<body>
	<?php include 'php/navigation.php'; ?>
  
   <div class="profile">
  		<div class="photo">
  			<nav id="nav_profile"> 
				<ul>
					<li><a href="#" class="btnprofinfo">Profile information</a></li>
					<li><a href="#" class="btneditinfo">Edit information</a></li>
					<li><a href="#" class="btnchat">Chat</a></li>
				</ul>
	</nav>
  		</div>
  		<div class="vertical"></div>
  		
  		<div class="profinfo">
  			<img src="Images/profpic.png" alt="Profile Picture" height="200px"> <br> <br>
                        <?php
                            $information = getarrayfromtable($_SESSION['username']);
                        
 
                            echo '<p>Name: '. $information['name'] .'</p>'.
                            '<p>Last Name: '. $information['lastname'] .'</p>
                            <p>Email: '. $information['email'] .'</p>'.
                            '<p>Address: '. $information['address'] .' Johannes van der Waalsweg 92A</p>
                            <p>Birthday: '. $information['bday'] . '28/10/1996</p>
                            <p>Telephone number:',  $information['phone'] .'</p>
                            <p>Sex: '. $information['sex'] .'</p>
                            <p>Paypal id: ' . $information['paypall'] . '</p>
                            <p>Camping information:  reserved camping spot ' . information['camp'] . '</p>';
                        ?>
  		</div>
  		
  		<div class="editinfo">
  			<img src="Images/profpic.png" alt="Profile Picture" height="200px"> <br> <br>
  			<form>
      			<label for="name">Name</label>
      			<input type="text" id="name" name="name"><br>
      			<label for="lastname">Last Name</label>
      			<input type="text" id="lastname" name="lastname"><br>
      			<label for="email">Email</label>
      			<input type="text" id="email" name="email"><br>
      			<label for="address">Address</label>
      			<input type="text" id="address" name="address"><br>
      			<label for="telephone">Telephone number</label>
      			<input type="text" id="telephone" name="telephone"><br>
      			<label for="sex">Sex</label>
      			<input type="radio" id="sex" name="sex" value="Male"><br>
      			<label for="paypall">Paypall id</label>
      			<input type="text" id="paypall" name="paypall"><br>
      			<input type="submit" value="Submit">
      			<input type="submit" value="Upload picture">
      		</form>
  		</div>
  		<div class="chat">
   			<a class="twitter-timeline" href="https://twitter.com/bunindmytro" data-widget-id="580666679291691008">Tweets by @bunindmytro</a> <script>!function(d,s,id){var js,fjs=d.getElementsByTagName(s)[0],p=/^http:/.test(d.location)?'http':'https';if(!d.getElementById(id)){js=d.createElement(s);js.id=id;js.src=p+"://platform.twitter.com/widgets.js";fjs.parentNode.insertBefore(js,fjs);}}(document,"script","twitter-wjs");</script>
	   </div>
   </div>  
   
   <br>
   <div class="Question">
 		<p><img src="Images/dimalogo.png" height="100"></p>
   	</div>
</body>   	
</html>