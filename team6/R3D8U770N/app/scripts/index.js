const loginClick = async (e) => {
    e.preventDefault();
    const login = document.getElementById("login").value;
    const password = document.getElementById("password").value;
    
    try {
        const response = await fetch("/requests/login.php", {
            method: "POST",
            body: JSON.stringify({
                login,
                password
            })
        });
        if (response.ok) { 
            const json = await response.json();
            if (json) {
                localStorage.setItem("jwt", json.token);
                location.href = "/profile.php";
            }
            else {
                alert("Неверные данные входа");
            }
        }
        else {
            alert("Неверные данные входа");
        }
    }
    catch(error) {
        alert("Неизвестная ошибка");
    } 
}

document.getElementById("loginButton").addEventListener("click", (e) => loginClick(e));