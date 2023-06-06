<?php
header("Content-Type: application/json; charset=utf-8");

include("config.php");
include_once __DIR__ . "../../helpers/crypto.phpp";

$Link = new mysqli(DB_SERVER, DB_USER, DB_PASSWORD, DB_DATABASE);
if ($Link->connect_error) {
    http_response_code(500);
    die("Database connection error");
}

$result = $Link->query("SELECT userid, login FROM users");
$users = $result->fetch_all(MYSQLI_ASSOC);
if (!$users) {
    http_response_code(400);
}
else {
    foreach($users as $key => $value) {
        $users[$key]["userid"] = encode($users[$key]["userid"]);
     }
    
    echo json_encode($users);
}

