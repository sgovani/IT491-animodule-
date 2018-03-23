<?php

/*
   line for testing
   curl -d '{"email":"uses", "passw":"password"}' -H "Content-Type: application/json" -X POST http://afsaccess1.njit.edu/~sg873/login.php
*/
require_once "database.php";

session_start();
error_reporting(0); // Disable all errors.

include ('client.php');


$CredentialsJSON  = json_decode(file_get_contents('php://input'), true);

$user = $CredentialsJSON['email'];
$pass = $CredentialsJSON['passw'];

$response = authentication($user, $pass);

$array = array(
        "response" => $response,
);
echo json_encode($array, JSON_PRETTY_PRINT);


?>
