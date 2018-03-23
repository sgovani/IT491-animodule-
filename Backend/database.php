<?php

$host = "sql2.njit.edu";

$username = "sg873";
$password = "gMi5xfCcU";
$dbname = "AnimoduleDevDB";

function connectToDB(){

	$host = "sql2.njit.edu";

	$username = "sg873";
	$password = "gMi5xfCcU";
	$dbname = "AnimoduleDevDB";


	$conn = mysqli_connect($host, $username, $password, $dbname);

	if (!$conn) {
    		die("Connection failed: " . mysqli_connect_error());
	}
	return $conn;
}


function registration($email, $firstname, $lastname, $password) {

  echo $email;
  echo $firstname;
  echo $lastname;
  echo $password;

	$tempConn = connectToDB();
	$query = "INSERT into Login (Email, Password) values ('".$email."','".$password."');" ;

  echo $query;
	$result = mysqli_query($tempConn, $query);

	return $result;
}

function authentication($username, $password){
	$databasePW = getUsersPW($username);

	if ($databasePW == $password){
		return true;
	}
	return false;
}

function getUsersPW($username){
	$tempConn = connectToDB();

	$sql = "SELECT Password WHERE Email = '". $username . "' FROM Login";
	$result = mysqli_query($tempConn, $sql);
}

?>
