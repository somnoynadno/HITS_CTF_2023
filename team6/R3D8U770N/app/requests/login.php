<?php
header("Content-Type: application/json; charset=utf-8");
include("config.php");
include_once __DIR__ . "../../helpers/jwt.php";

$Link = new mysqli(DB_SERVER, DB_USER, DB_PASSWORD, DB_DATABASE);


if ($Link->connect_error) {
    http_response_code(500);
    die("Database connection error");
}

$reqBody = json_decode(file_get_contents("php://input"));
$stmt = $Link->prepare("SELECT userid, role FROM users WHERE login = ? and password = ?");
$stmt->bind_param("ss", ...[$reqBody->login, $reqBody->password]);
$stmt->execute();

$result = $stmt->get_result();

if (!$result->num_rows) {
    http_response_code(400);
    echo "Invalid login or password";
} else {
    $user = $result->fetch_assoc();
    echo json_encode(["token" => generateJWT($user["userid"], $user["role"])]);
}

