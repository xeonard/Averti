<?php
/**
 * Created by PhpStorm.
 * User: Ruud
 * Date: 1-6-2015
 * Time: 9:51
 */

session_start();
//connection details
$host = "athena01.fhict.local";
$username = "dbi252284";
$password ="fCPIXLUNGi";
$db = "dbi252284";

try {
    $con = mysql_connect($host, $username, $password);
    mysql_select_db($db, $con);

    /**
     * @param $userId
     * @return array
     */
    function getUserData($userId)
    {

        $query = mysql_query("select * from person where personalID = '$userId'limit 1");

        return mysql_fetch_array($query, 1);
    }





}catch (PDOException $e) {

    echo $e;
}