<!DOCTYPE html>
<html lang="en">
<head>
	<meta charset="UTF-8">
	<title>Averti Festival</title>
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <link href="css/bootstrap.css" rel="stylesheet">
    <link rel="stylesheet" href="css/profile.css" >
    <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.11.0/jquery.min.js"></script>
    <script src="js/java.js"></script>
	<script src="js/bootstrap.js"></script>
</head>
<body>
	<div class="nav">
      <div class="container" >
          <nav class="navbar navbar-default navbar-fixed-top" style="background:#ff6f3a;">
              <div class="container" >
                  <ul  class="nav nav-pills">
                      <li><a href="index.html">Home</a></li>
                      <li><a href="learnmore.html">Learn More</a></li>
                      <li><a href="tickets.html">Tickets</a></li>


                      <li class="navbar-right"><a href="profile.html">Profile</a></li>
                  </ul>
              </div>
          </nav>
    </div>
    <div class="head">
    	<h1>Tickets</h1>
    </div>
    
    <div class="buytable">
    	<div class="eventinfo">
    		<div class="headline"><h3>Event information</h3></div>
    		<p>Event name:    Averti Festival</p>
    		<p>Location:      Park Kuierpad, Valkenswaard, Netherlands</p>
    		<p>Date:          14th August 2015 - 16th August 2015</p>
    		<div class="divideline"></div>
    	</div>
    	<div class="table">
    		<table class="table table-striped">
    			<tr>
    				<th>Ticket</th>
    				<th>Price</th>
    				<th>Amount</th>
    				<th>Buy</th>
  				</tr>
  				<tr>
    				<td>Normal Ticket</td>
    				<td>€55</td>
    				<td>
   						<select name="amount" class="small" style="margin-top: -4px;">
    						<option value="1">1</option>
    						<option value="2">2</option>
    						<option value="3">3</option>
    						<option value="4">4</option>
    						<option value="5">5</option>
    						<option value="6">6</option>
    					</select>
    				</td>
    				<td>
    					<input type="submit" value="Buy" class="btnBuy">
    				</td>
  				</tr>
  				<tr>
    				<td>Ticket+camping</td>
    				<td>€85</td>
    				<td>
   						<select name="amount" class="small" style="margin-top: -4px;">
    						<option value="1">1</option>
    						<option value="2">2</option>
    						<option value="3">3</option>
    						<option value="4">4</option>
    						<option value="5">5</option>
    						<option value="6">6</option>
    					</select>
    				</td>
    				<td>
    					<input type="submit" value="Buy" class="btnBuy">
    				</td>
  				</tr>
    		</table>
    	</div>
    </div>
</body>
</html>