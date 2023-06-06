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
                        <a class="nav-link" href="/users.php">Users List</a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link active" href="/profile.php">Profile</a>
                    </li>
                </ul>
            </div>
        </nav>
    </header>

    <h3 class="m-3 text-center">Profile</h3>
    <div class="d-flex flex-column align-items-center">
        <h4 id="profileDataHeader" class="d-none">Your profile data</h4>
        <table class="table table-bordered w-50 d-none" id="profileData">
            <thead>
                <tr>
                <th scope="col">Property</th>
                <th scope="col">Value</th>
                </tr>
            </thead>
            <tbody>
                <tr>
                    <th scope="row">Full Name</th>
                    <td id="tfullName">Loading</td>
                </tr>
                <tr>
                    <th scope="row">Login</th>
                    <td id="tlogin">Loading</td>
                </tr>
                <tr>
                    <th scope="row">Email</th>
                    <td id="temail">Loading</td>
                </tr>
                <tr>
                    <th scope="row">Gender</th>
                    <td id="tgender">Loading</td>
                </tr>
                <tr>
                    <th scope="row">Birth Date</th>
                    <td id="tbirthDate">Loading</td>
                </tr>
                <tr>
                    <th scope="row">Address</th>
                    <td id="taddress">Loading</td>
                </tr>
                <tr>
                    <th scope="row">Phone Number</th>
                    <td id="tphoneNumber">Loading</td>
                </tr>
                <tr>
                    <th scope="row">Role</th>
                    <td id="trole">Loading</td>
                </tr>
            </tbody>
        </table>

        <h4 id="redBtnHeader" class="d-none">Red button</h4>
        <div class="m-4 w-50 border border-primary p-2 rounded d-flex flex-column align-items-center d-none" id="redBtnForm">
            <div class="form-group">
                <label for="btnPassword">Input your secret code</label>
                <input class="form-control" id="btnPassword" placeholder="Secret code">
            </div>
            <button type="button" class="btn btn-danger mt-3" id="finalButton">FLAG CAPTURE</button>
        </div>
    </div>
    <script src="./scripts/profile.js"></script>
</body>
</html>