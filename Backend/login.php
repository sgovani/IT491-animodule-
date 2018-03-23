<?php

/* 
   line for testing
   curl -d '{"user":"uses", "pass":"password"}' -H "Content-Type: application/json" -X POST http://afsaccess1.njit.edu/~sg873/login.php
*/
require_once "database.php";

session_start();
error_reporting(0); // Disable all errors.

include ('client.php');

$user = $_POST['user'];
$pass = $_POST['pass'];


$response = authentication(i$user, $pass);

$array = array(
        "response" => $response,
);
echo json_encode($array, JSON_PRETTY_PRINT);


?>
