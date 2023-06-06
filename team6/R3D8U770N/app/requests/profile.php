<?php
header("Content-Type: application/json; charset=utf-8");
include("config.php");
include_once __DIR__ . "../../helpers/jwt.php";

$Link = new mysqli(DB_SERVER, DB_USER, DB_PASSWORD, DB_DATABASE);


if ($Link->connect_error) {
    http_response_code(500);
    die("Database connection error");
}

$header = apache_request_headers()["Authorization"];

$userid = jwt_userid(($header));
if (!$userid) {
    http_response_code(400);
    exit;
}


$stmt = $Link->prepare("SELECT users_info.*, users.role, users.login
                        FROM users
                        JOIN users_info USING(`userid`)
                        WHERE userid = ?");
$stmt->bind_param("s", $userid);
$stmt->execute();

$result = $stmt->get_result();

if (!$result->num_rows) {
    http_response_code(400);
} else {
    $user = $result->fetch_assoc();
    echo json_encode($user);
}
