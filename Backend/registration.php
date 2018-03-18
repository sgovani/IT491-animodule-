<?php
ini_set("display_errors", 1);
ini_set("log_errors",1);
ini_set("error_log", "/tmp/error.log");
error_reporting( E_ALL & ~E_DEPRECATED & ~E_STRICT);
error_log("Hello, errors!");
include ('client.php');
$email = $_POST['email'];
$firstname = $_POST['fName'];
$lastname  = $_POST['lName'];
$password = $_POST['passw']; 
$response = registration($email,$firstname,$lastname,$password);
if($response != true)
  {
    echo "Registration Failed. Please try a different email";
    header( "Refresh:2; url=registration.html", true, 303);
  }
  else
  {
    echo "Thank you for Registering!";
    header( "Refresh:2; url=login.html", true, 303);
  }
?>