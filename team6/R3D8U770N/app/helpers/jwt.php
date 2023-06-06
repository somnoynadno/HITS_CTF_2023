<?php
function generateJWT($userid, $role)
{
    $secret = "a84bbc643de832c34bc643de8faa5df";
    $header = json_encode(["typ" => "JWT", "alg" => "HS256"]);
    $now = time();

    $payload_data = [
        "userid" => $userid,
        "nbf" => $now,
        "exp" => $now + 999999,
        "iat" => $now
    ];

    if ($role == "Admin") {
        $payload_data += ["secretcode" => "red_button_button_red_777"]; 
    }

    $payload = json_encode($payload_data);
    $base64_header = base64url_encode($header);
    $base64_payload = base64url_encode($payload);

    $signature = hash_hmac("sha256", $base64_header . "." . $base64_payload, $secret, true);
    $base64_signature = base64url_encode($signature);

    return $base64_header . "." . $base64_payload . "." . $base64_signature;
}

function jwt_userid($jwt)
{
    if (is_null($jwt)) {
        return false;
    }

    if (!preg_match("/^[^\.]+\.[^\.]+\.[^\.]+$/", $jwt)) {
        return false;
    }

    $secret = "a84bbc643de832c34bc643de8faa5df";
    $tokenParts = explode(".", $jwt);
    $header = base64_decode($tokenParts[0]);
    $payload = base64_decode($tokenParts[1]);

    if (!$header || !$payload) {
        return false;
    }

    $signature_provided = $tokenParts[2];

    $expiration = json_decode($payload)->exp;
    $is_token_expired = $expiration < time();

    $base64_header = base64url_encode($header);
    $base64_payload = base64url_encode($payload);
    $signature = hash_hmac("sha256", $base64_header . "." . $base64_payload, $secret, true);
    $base64_signature = base64url_encode($signature);

    $is_signature_valid = ($base64_signature === $signature_provided);

    if ($is_token_expired) {
        return false;
    }

    if (!$is_signature_valid) {
        return false;
    }

    return json_decode($payload)->userid;
}

function get_user_id($jwt) {
    $tokenParts = explode(".", $jwt);
    $payload = base64_decode($tokenParts[1]);
    $payload = json_decode($payload, true);
    return $payload["nameid"];
}

function base64url_encode($str)
{
    return rtrim(strtr(base64_encode($str), "+/", "-_"), "=");
}