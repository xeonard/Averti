<?php
session_start();
if (!isset($_SESSION['username'])) {
    //header( "refresh:0; url=index.php" );
}
?>

<html>
    <head>
        <title>Averti Festival</title>
        <meta name="viewport" content="width=device-width, initial-scale=1">
        <link href="../css/bootstrap.css" rel="stylesheet">
        <link rel="stylesheet" href="../css/profile.css" >
        <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.11.0/jquery.min.js"></script>
        <script src="../js/java.js"></script>
        <script src="../js/bootstrap.js"></script>
    </head>
    <body>

        <?php include 'navigation.php'; ?>

        <div class="profile">
                <form action="upload_file.php" method="post" enctype="multipart/form-data">
        <label for="file">Filename:</label>
        upload file here<input type="file" name="file" id="file"> <br>
        push this button to upload<input type="submit" name="submit" value="Submit">
    </form>

<?php
//if there is file has been selected 
if (isset($_FILES['file'])) {
//file should have this criteria 
    $allowedExts = array("gif", "jpeg", "jpg", "png");
    $temp = explode(".", $_FILES["file"]["name"]);
    $extension = end($temp);

    if ((($_FILES["file"]["type"] == "image/gif") || ($_FILES["file"]["type"] == "image/jpeg") || ($_FILES["file"]["type"] == "image/jpg") || ($_FILES["file"]["type"] == "image/pjpeg") || ($_FILES["file"]["type"] == "image/x-png") || ($_FILES["file"]["type"] == "image/png")) && ($_FILES["file"]["size"] < 2000000) && in_array($extension, $allowedExts)) {
        if ($_FILES["file"]["error"] > 0) {
            echo "Return Code: " . $_FILES["file"]["error"] . "<br>";
        } else {
            echo "Upload: " . $_FILES["file"]["name"] . "<br>";
            echo "Type: " . $_FILES["file"]["type"] . "<br>";
            echo "Size: " . ($_FILES["file"]["size"] / 1024) . " kB<br>";
            echo "Temp file: " . $_FILES["file"]["tmp_name"] . "<br>";
            if (file_exists("upload/" . $_FILES["file"]["name"])) {
                echo $_FILES["file"]["name"] . " already exists. ";
            } else {
                //upload the file 
                move_uploaded_file($_FILES["file"]["tmp_name"], "upload/" . $_FILES["file"]["name"]);
                echo "Stored in: " . "upload/" . $_FILES["file"]["name"];
            }
        }
    } else {
        echo "Invalid file";
    }
}
?>
    <?php
    // make a connection to database
    $con = mysqli_connect("athena01.fhict.local", "dbi252284", "fCPIXLUNGi", "dbi252284");
// Check connection
    if (mysqli_connect_errno()) {
        echo "Failed to connect to MySQL: " . mysqli_connect_error();
    }
//see the other characteristic of user 
    $result = mysqli_query($con, "SELECT * FROM person WHERE personalID = '" . $_SESSION['personalID'] . "'");
    while ($row = mysqli_fetch_array($result)) {
// fetch them 
        if ($row['username'] == $_SESSION['username']) {
// print them here
            echo '<p>';
            echo "<br>";
            echo "<br>";
            echo "Your name:";
            echo $row['name'];
            echo "<br>";
            echo "Your address: ";
            echo $row['address'];
            echo "<br>";
            echo "Your telephone:";
            echo $row['telephoneNumber'];
            echo "<br>";
            echo "You are a : ";
            echo $row['Sex'];
            echo "<br>";
            echo "Your papalID is :";
            echo $row['paypalID'];
            echo '</p>';
        }
    }
    //close the connection 
    mysqli_close($con);
    ?>
            <!--
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
                             ?php
                                 $information = getarrayfromtable('Sophia');
                             
      
                                 echo '<p>Name: '. $information['name'] .'</p>'.
                                 '<p>Email: '. $information['email'] .'</p>'.
                                 '<p>Address: '. $information['address'] .'</p>
                                 <p>Birthday: '. $information['bday'] . '</p>
                                 <p>Telephone number:',  $information['phone'] .'</p>
                                 <p>Sex: '. $information['sex'] .'</p>
                                 <p>Paypal id: ' . $information['paypall'] . '</p>
                                 <p>Camping information:  reserved camping spot ' . $information['camp'] . '</p>';
                             ?>
                     </div>
        
                     
                     <div class="editinfo">
                             <img src="Images/profpic.png" alt="Profile Picture" height="200px"> <br> <br>
                             <form>
                             <label for="name">Name</label>
                             <input type="text" id="name" name="name"><br>
                     
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
            -->


    </div>








</body>   	
</html>