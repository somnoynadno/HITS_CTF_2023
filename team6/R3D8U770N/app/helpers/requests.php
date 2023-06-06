<?php
function get_params()
{
    $params = new stdClass();
    $query  = explode("&", $_SERVER["QUERY_STRING"]);
    foreach ($query as $param) {
       if (strpos($param, "=") === false) $param += "=";
       list($key, $value) = explode("=", $param, 2);
       if ($key == "q") continue;
       $params->$key[] = $value; 
    }
    return $params;
}


function get_body()
{
    return json_decode(file_get_contents("php://input"));
}

function get_method()
{
    return $_SERVER["REQUEST_METHOD"];
}