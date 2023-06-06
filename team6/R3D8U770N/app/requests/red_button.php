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

$result = $Link->query("SELECT 1 FROM users WHERE role = 'Admin' and userid = '" . $userid . "'");
$users = $result->fetch_all(MYSQLI_ASSOC);

if (!$result->num_rows) {
    echo json_encode(false);
    exit;
} 

parse_str($_SERVER["QUERY_STRING"], $output);
if ($output["btn"] !== "red_button_button_red_777") {
    echo json_encode(false);
}
else {
    echo json_encode(["flag" => "HITS{u53_Pr3PaR3D_57A73m3n72}"]);
}