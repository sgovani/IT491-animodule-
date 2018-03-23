<?php


$host = "sql.njit.edu";

$username = "sg873";
$password = "";

$dbname = "AnimoduleDevDB";


function connectToDB(){
	$conn = mysqli_connect($host, $username, $password, $dbname);
	
	if (!$conn) {
    		die("Connection failed: " . mysqli_connect_error());
	} 
	return $conn;
}


function writeToUserTable($firstname, $lastname, $password, $email) {


}

function authentication($username, $password){
	$databasePW = getUsersPW($username);

	if ($databasePW == $password){
		retun true;
	}
	return false;
}

function getUsersPW($username){
	$tempConn = connectToDB();

	$sql = "SELECT pw WHERE username = '". $username . "' FROM Users";
	$result = mysqli_query($conn, $sql);
}

?>
