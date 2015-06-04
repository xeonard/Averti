<?php
?>
<div class="nav">
      <div class="container" >
          <nav class="navbar navbar-default navbar-fixed-top" style="background:#ff6f3a;">
              <div class="container" >
                  <ul  class="nav nav-pills">
                      <li><a href="index.php">Home</a></li>
                      <li><a href="learnmore.php">Learn More</a></li>
                      <li><a href="tickets.php">Tickets</a></li>
                      
                      <?php 
                      if(isset($_SESSION['username'])){
                        echo '<li class="navbar-right">
                        <a href="profile.php">Profile</a>
                        </li>';
                      }
                      else {
                      echo '<li class="navbar-right">
                            <a id="signup">Sign Up</a>
                        </li>
                        <li class="navbar-right">
                            <a id="login">Log In</a>
                        </li>';
                      }
                      
                      ?>
                  </ul>
              </div>
          </nav>
    </div>

