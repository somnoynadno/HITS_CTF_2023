<?php
header("Content-Type: application/json; charset=utf-8");
include_once __DIR__ . "../../helpers/requests.php";
include_once __DIR__ . "../../helpers/crypto.phpp";
include("config.php");

$Link = new mysqli(DB_SERVER, DB_USER, DB_PASSWORD, DB_DATABASE);


if ($Link->connect_error) {
    http_response_code(500);
    die("Database connection error");
}

parse_str($_SERVER["QUERY_STRING"], $output);

if (!$output["user"]) {
    http_response_code(400);
    exit;
}


$query = $Link->query("SELECT users_info.*, users.role
                        FROM users
                        JOIN users_info USING(`userid`)
                        WHERE userid = '" . decode($output["user"]) . "'");

$result = $query->fetch_assoc();

if (!$result) {
    http_response_code(400);
} else {
    echo json_encode($result);
}
