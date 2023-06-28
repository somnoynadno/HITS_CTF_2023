// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
let boardId;
$(document).ready(init);

function init() {
    boardId = $("#board-id").val();
    setBoardListeners();
}

function setBoardListeners() {
    $("[send]").on("click", (e) => {
        sendMessage();
    });
    $("#message-input").on("keypress", (e) => {
        let key = e.which;
        if (key == 13)
            sendMessage();
    });
    $("#openManagementModalButton").on("click", (e) => {
        $("#manageUsersDialog").modal('show');
        setUserListeners();
    });

    setChatListeners();
}

function setChatListeners() {
    $("[remove-message]").on("click", (e) => {
        let id = e.target.getAttribute("message-id");
        deleteMessage(id);
    })
}
function setUserListeners() {
    $(".addMemberButton").on("click", (e) => {
        let id = e.currentTarget.getAttribute("id");
        console.log(e.currentTarget);
        addMember(id);
    });

    $(".kickButton").on("click", (e) => {
        let id = e.currentTarget.getAttribute("id");
        console.log(e.currentTarget);
        kickMember(id);
    });
}

function sendMessage() {
    let message = $("#message-input").val();
    if (message) {
        message = new CreateMessageDTO(message);
        console.log(message);
        $.post(`${baseUrl()}/message/send?boardId=${boardId}`, JSON.stringify({ "Content": message.Content }))
            .done(() => {
                $("#message-container").load(`${baseUrl()}/board/board/${boardId} #message-content`, setChatListeners)
                $("#message-input").val("");
            })
            .fail((jqXHR, textStatus, errorThrown) => {
                console.log(errorThrown);
            });;
    }
}

function deleteMessage(messageId) {
    console.log(messageId);
    $.post(`${baseUrl()}/message/delete?messageId=${messageId}`)
        .done(() => {
            $("#message-container").load(`${baseUrl()}/board/board/${boardId} #message-content`, setChatListeners)
        })
        .fail((jqXHR, textStatus, errorThrown) => {
            console.log(errorThrown);
        });;
}

function addMember(memberId) {
    $.post(`${baseUrl()}/board/${boardId}/add?memberId=${memberId}`)
        .done(() => {
            reloadModal(boardId)
        })
        .fail((jqXHR, textStatus, errorThrown) => {
            console.log(errorThrown);
        });
}

function kickMember(memberId) {
    $.post(`${baseUrl()}/board/${boardId}/kick?memberId=${memberId}`)
        .done(() => {
            reloadModal(boardId)
        })
        .fail((jqXHR, textStatus, errorThrown) => {
            console.log(errorThrown);
        });
}

function reloadModal(boardId) {
    $("#modalContainer").load(`${baseUrl()}/board/board/${boardId} .modal-body`, setUserListeners)
}

class CreateMessageDTO {
    constructor(content) {
        this.Content = content;
    }
}