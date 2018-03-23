<?php
error_reporting(0);


/*
 curl -d '{"email":"mailing", "fName":"testing", "lName":"testinglastname", "passw":"password"}' -H "Content-Type: application/json" -X POST http://afsaccess1.njit.edu/~sg873/registration.php
*/

require_once "database.php";
$userJSON  = json_decode(file_get_contents('php://input'), true);

$email = $userJSON['email'];
$firstname = $userJSON['fName'];
$lastname  = $userJSON['lName'];
$password = $userJSON['passw'];

echo $email;
echo $firstname;
echo $lastname;
echo $password;

$response = registration($email, $firstname, $lastname, $password);


$array = array(
        "response" => $response,
);
echo json_encode($array, JSON_PRETTY_PRINT);



?>
