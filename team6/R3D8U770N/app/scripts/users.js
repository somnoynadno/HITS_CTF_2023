const url = new URL(location.href);
const params = new URLSearchParams(url.search);
const userid = params.getAll("user");

async function usersListInit() {
    try {
        const response = await fetch("/requests/users_list.php");
        if (response.ok) { 
            const json = await response.json();
            if (json) {
                const list = document.getElementById("usersList");
                const template = document.getElementById("template");

                for (let user of json) {
                    const list_elem = template.cloneNode(true);
                    list_elem.id = user["userid"];
                    list_elem.textContent = user["login"];

                    if (user["userid"] === userid[0]) {
                        list_elem.style = "text-decoration: underline; cursor: pointer; color: blue";
                    }
                    else {
                        list_elem.style = "text-decoration: underline; cursor: pointer";
                    }

                    list_elem.addEventListener("click", function() {
                        location.href = "/users.php?user=" + this.id;
                    })

                    list.appendChild(list_elem);  
                }
                template.remove();
            }
            else {
                alert("Ошибка при получении списка")
            }
        }
        else {
            alert("Ошибка при получении списка")
        }
    }
    catch {
        alert("Ошибка при получении списка");
    }
}

async function userDataInit() {
    try {
        if (!params.has("user")) {
            document.getElementById("userData").remove();
        }
        if (!location.search) return;
        const response = await fetch("/requests/users_list_info.php"+location.search);
        if (response.ok) { 
            const json = await response.json();
            if (json) {
                for (let prop in json) {
                    elem = document.getElementById("tl" + prop);
                    if (elem) elem.textContent = json[prop];
                }
            }
            else {
                document.getElementById("userData").remove();
                alert("Ошибка при получении данных пользователя");
            }
        }
        else {
            document.getElementById("userData").remove();
            alert("Ошибка при получении данных пользователя");
        }
    }
    catch(error) {
        document.getElementById("userData").remove();
        alert("Ошибка при получении данных пользователя");
    }
}

async function listPageInit() {
    await usersListInit();
    await userDataInit();
    document.getElementById("usersListMain").classList.remove("d-none");
}
listPageInit();

