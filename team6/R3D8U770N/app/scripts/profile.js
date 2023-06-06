async function profileInit() {
    try {
        const response = await fetch("/requests/profile.php", {
            method: "GET",
            headers: {
                Authorization: localStorage.getItem("jwt")
            }
        });
        if (response.ok) { 
            const json = await response.json();
            if (json) {
                for (let prop in json) {
                    elem = document.getElementById("t" + prop);
                    if (elem) elem.textContent = json[prop];
                }

                document.getElementById("profileDataHeader").classList.remove("d-none");
                document.getElementById("profileData").classList.remove("d-none");

                if (json.role !== "Admin") {
                    document.getElementById("redBtnHeader").remove();
                    document.getElementById("redBtnForm").remove();
                }
                else {
                    document.getElementById("redBtnHeader").classList.remove("d-none");
                    document.getElementById("redBtnForm").classList.remove("d-none");
                    document.getElementById("finalButton").addEventListener("click", async (e) => {
                        e.preventDefault();
                        try {
                            const val = document.getElementById("btnPassword").value;
                            const response = await fetch("/requests/red_button.php?btn=" + val, {
                                method: "POST",
                                body: {
                                    code: document.getElementById("btnPassword").value
                                },
                                headers: {
                                    Authorization: localStorage.getItem("jwt")
                                }
                            });
                            if (response.ok) { 
                                const json = await response.json();
                                if (json) {
                                    alert("Задача выполнена. Вы получили флаг: " + json.flag);
                                }
                                else {
                                    alert("Неверный код");
                                }
                            }
                            else {
                                alert("Ошибка");
                            }
                        }
                        catch {
                            alert("Ошибка");
                        }
                    });
                }
            }
            else {
                localStorage.removeItem("jwt");
                location.href = "/index.php";
            }
        }
        else {
            localStorage.removeItem("jwt");
            location.href = "/index.php";
        }
    }
    catch(error) {
        localStorage.removeItem("jwt");
        location.href = "/index.php";
    }
}
profileInit();