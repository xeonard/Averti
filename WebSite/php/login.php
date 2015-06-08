<?php
require('PDO.php');
if(isset($_POST['username'])){

    $conn = connection();
    $userName = $_POST['username'];
    $passWord = $_POST['password'];

    $sql ="select personalID from person where username = '$userName' and password = '$passWord'limit 1";
    $query = $conn->prepare($sql);
    $query->execute();
    $getdata= $query->fetchAll();
    if($getdata) {

        $_SESSION['personalID'] = $getdata['personalID'];
        $_SESSION['username'] = $userName;
        
        echo 'You logged in succesfully. Redirecting to profile page...';
        header('refresh:1; url=../profile.php');
    }else{

        echo "Log in or password is incorrect, redirecting back...";
        header( "refresh:1; url=../index.php" );
    }
}
 else {
     echo "Something went wrong";
}
?>
