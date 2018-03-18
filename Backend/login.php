<?php
session_start();
error_reporting(0); // Disable all errors.

include ('client.php');

$user = $_POST['user'];
$pass = $_POST['pass'];
// $response = authentication($user, $pass);

/*
if($response == false)  {
    	echo "Login Failed. Please enter correct credentials or register for an account";
  	header( "Refresh:5; url=login.html", true, 303);
}
else {
  echo "Login Successful!";
  $_SESSION['user'] = $user;
  header( "Refresh:5; url=main.php", true, 303);
}
*/

echo($user +" "+ $pass);

?>
