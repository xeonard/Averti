<?php
require('PDO.php');
session_start();
if(isset($_POST['submit']))
{
 //whether the username is blank
 if($_POST['username'] == '')
 {
  $_SESSION['error']['username'] = "Username is required.";
 }
 //whether the email is blank
 if($_POST['email'] == '')
 {
  $_SESSION['error']['email'] = "Email is required.";
 }
 else
 {
  //whether the email format is correct
     $Syntax='/^([a-zA-Z0-9])+([a-zA-Z0-9._-])*@([a-zA-Z0-9_-])+([a-zA-Z0-9._-]+)+$/';
   if(preg_match($Syntaxe, $_POST['email']))
      return true;
   else
   $_SESSION['error']['email'] = "Your email is not valid.";
   }
 //whether the password is blank
 if($_POST['password'] == '')
 {
  $_SESSION['error']['password'] = "Password is required.";
 }
  //whether the name is blank
 if($_POST['name'] == '')
 {
  $_SESSION['error']['name'] = "Name is required.";
 }
 
  if ( empty( $_POST ) ) {
?>
<form name="registration" action="registration.php" method="POST">
  <label for='username'>Username: </label>
  <input type="text" name="username"/>
  <label for='password'>Password: </label>
  <input type="password" name="password"/>
  <label for='name'>name: </label>
  <input type="text" name="name"/>
  <label for='email'>Email: </label>
  <input type="text" name="email"/>
  <br/>
  <button type="button" class="btn btn-primary">Submit</button>
</form>
<?php
} else {
	$db = connection();
	$form = $_POST;
	$username = $form[ 'username' ];
	$password = $form[ 'password' ];
	$name = $form[ 'name' ];
	$email = $form[ 'email' ];
        
	$conn = connection();
        $stmt = $conn->prepare("Select MAX(`personalID`)+1 AS personalID FROM person ");
        $stmt->execute();
        $array = null;
        $personalID = null;
        
        $results = $stmt->fetchAll(); 
        foreach ($results as $result) {
            $personalID =$result['personalID'];
        }
        
        echo 'personal id: ' . $personalID;
	$sql = "INSERT INTO person (personalID, name, email, username, password) 
	VALUES ( :personalID, :name,  :email, :username, :password)";
	$query = $db->prepare( $sql );
	$result = $query->execute( array( ':personalID'=>$personalID, ':username'=>$username, ':password'=>$password, 
		':name'=>$name, ':email'=>$email ) );
	if ( $result ){
 		 echo "<p>Thank you. You have been registered</p>";
	} else {
		  echo "<p>Sorry, there has been a problem inserting your details. Please try again</p>";
	}
}
}

?>