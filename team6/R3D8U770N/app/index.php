<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>Hack me</title>
    <link href="/bootstrap/bootstrap.min.css" rel="stylesheet">
    <script src="/bootstrap/bootstrap.min.js"></script>
</head>
<body>
    <header>
    <nav class="navbar navbar-expand-lg navbar-light bg-light">
    <div class="container-fluid">
        <a class="navbar-brand">Red Button</a>
        <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarSupportedContent">
        <span class="navbar-toggler-icon"></span>
        </button>
        <div class="collapse navbar-collapse" id="navbarSupportedContent">
        <ul class="navbar-nav me-auto mb-2 mb-lg-0">
            <li class="nav-item">
                <a class="nav-link active" href="/index.php">Login Form</a>
            </li>
            <li class="nav-item">
                <a class="nav-link" href="/users.php">Users List</a>
            </li>
            <li class="nav-item">
                <a class="nav-link" href="/profile.php">Profile</a>
            </li>
        </ul>
    </div>
    </nav>
    </header>

    <h3 class="m-3 text-center">Login Form</h3>
    <div class="d-flex flex-column align-items-center">
        <form class="m-4 w-50 border border-primary p-2 rounded">
            <div class="form-group">
                <label for="login">Login</label>
                <input class="form-control" id="login" placeholder="Login">
            </div>
            <div class="form-group">
                <label for="password">Password</label>
                <input type="password" class="form-control" id="password" placeholder="Password">
            </div>
            <button class="btn btn-primary mt-1" id="loginButton">Log In</button>
        </form>
    </div>
    <script src="/scripts/index.js"></script>
</body>
</html>