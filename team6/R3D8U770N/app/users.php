<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>Hack me</title>
    <link href="./bootstrap/bootstrap.min.css" rel="stylesheet">
    <script src="./bootstrap/bootstrap.min.js"></script>
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
                        <a class="nav-link" href="/index.php">Login Form</a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link active" href="/users.php">Users List</a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link" href="/profile.php">Profile</a>
                    </li>
                </ul>
            </div>
        </nav>
    </header>

    <h3 class="m-3 text-center">Users List</h3>
    <div class="d-flex justify-content-around mx-3 d-none" id="usersListMain">

        <ul id="usersList" class="list-group">
            <li class="list-group-item" id="template">Загрузка</li>
        </ul>
        <table class="table table-bordered w-50" id="userData">
            <thead>
                <tr>
                <th scope="col">Property</th>
                <th scope="col">Value</th>
                </tr>
            </thead>
            <tbody>
                <tr>
                    <th scope="row">Full Name</th>
                    <td id="tlfullName">Loading</td>
                </tr>
                <tr>
                    <th scope="row">Email</th>
                    <td id="tlemail">Loading</td>
                </tr>
                <tr>
                    <th scope="row">Gender</th>
                    <td id="tlgender">Loading</td>
                </tr>
                <tr>
                    <th scope="row">Birth Date</th>
                    <td id="tlbirthDate">Loading</td>
                </tr>
                <tr>
                    <th scope="row">Address</th>
                    <td id="tladdress">Loading</td>
                </tr>
                <tr>
                    <th scope="row">Phone Number</th>
                    <td id="tlphoneNumber">Loading</td>
                </tr>
                <tr>
                    <th scope="row">Role</th>
                    <td id="tlrole">Loading</td>
                </tr>
            </tbody>
        </table>
        <script src="./scripts/users.js"></script>
    </div>
</body>
</html>