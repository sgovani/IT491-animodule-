<?php
error_reporting(0);


/*
 curl -d '{"fName":"testing", "lName":"testinglastname", "email":"mailing",  "passw":"password"}' -H "Content-Type: application/json" -X POST http://afsaccess1.njit.edu/~sg873/registration.php
*/

include_once "database.php";

$email = $_POST['email'];
$firstname = $_POST['fName'];
$lastname  = $_POST['lName'];
$password = $_POST['passw']; 

$response = registration($email,$firstname,$lastname,$password);

if($response != true) {
    echo "Registration Failed. Please try a different email";
    header( "Refresh:2; url=registration.html", true, 303);
} else {
    echo "Thank you for Registering!";
    header( "Refresh:2; url=login.html", true, 303);
}


?>
