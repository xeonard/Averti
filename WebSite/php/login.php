<?php
require('PDO.php');
if(isset($_POST['loginbtn'])){


    $userName = $_POST['username'];
    $passWord = $_POST['password'];

    $cookie_name = "User" ;
    $cookie_value = $userName;
    setcookie($cookie_name,$cookie_value,time()+(86400 * 30),"/");



    $query = mysql_query("select personalID from person where username = '$userName' and password = '$passWord'limit 1");
    if( mysql_num_rows($query)==1) {

        $data= mysql_fetch_array($query,1);
        $_SESSION['personalID']= $data['personalID'];

        header('location:profile.php');
    }else{

        $error = "Invalid Login" ;
    }
//todo when user is not logged in by session it needs to be redirected to indexpage; only for the member specific pages
}
?>
<div id="logindiv">
        <form class="form" action="" id="login" method="post">
            <h3>Login Form</h3>
            <?php if(isset($error)){ ?>
            <label ><strong class="error"><?php echo $error ?></strong></label>
            <?php } ?>

            <label>Username :</label>
            <input type="text" id="username" placeholder="Enter your username"/>
            <label>Password : </label>
            <input type="password" id="password" placeholder="Enter your password"/>
            <input type="button" id="loginbtn" value="Login"/>
            <input type="button" id="cancel" value="Cancel"/>
        </form>
    </div>