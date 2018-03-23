<?php
error_reporting(0);


/*
 curl -d '{"fName":"testing", "lName":"testinglastname", "email":"mailing",  "passw":"password"}' -H "Content-Type: application/json" -X POST http://afsaccess1.njit.edu/~sg873/registration.php
*/

require_once "database.php";

$email = $_POST['email'];
$firstname = $_POST['fName'];
$lastname  = $_POST['lName'];
$password = $_POST['passw']; 



$response = registration($email, $firstname, $lastname, $password);


$array = array(
        "response" => $response,
);
echo json_encode($array, JSON_PRETTY_PRINT);



?>
