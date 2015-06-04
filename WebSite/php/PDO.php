<?php

    function connection(){
        $host = "athena01.fhict.local";
        $username = "dbi252284";
        $password ="fCPIXLUNGi";
        $db = "dbi252284";
    
        try {
            $conn = new PDO("mysql:host=$host;dbname=$db", $username, $password);
        }
        catch (PDOException $pe) {
            die("Could not connect to the database $db :" . $pe->getMessage());
        }
        return $conn;
    }
    
    function getUserData($userId)
    {
        $conn = connection();
        $stmt = $conn->prepare("select * from person where personalID = '$userId'limit 1");
        $stmt->execute();
        
        $result = $stmt->setFetchMode(PDO::FETCH_ASSOC); 

        return $result;
    }
    
    function getarrayfromtable($username){//temperary method for profile using database from localhost
        $conn = connection();
        $stmt = $conn->prepare("select * from user Where uname = " . $username);
        $stmt->execute();
        $array = null;
        
        $results = $stmt->fetchAll(); 
        foreach ($results as $result) {
        $array = array(
            'uname'    => $result['username'],
            'name'  => $result['name'],
            'lastname'  => $result['lastname'],
            'email' => $result['email'],
            'phone' => $result['telephoneNumber'],
            'sex' => $result['Sex'],
            'address' => $result['address'],
            'wallet' => $result['walletBalance'],
            'bday' => $result['birthday'],
        );
        }
        return $array;
    }