

var DialogResult = "Cancel";
var DialogWindow;
var DialogCallBack;
var IsFirstLoad = true;

function DialogClose(btnResult) {
    DialogResult = btnResult;
    DialogWindow.close();
};

function DialogCloseCallBack(e) {
    DialogWindow.unbind("close", DialogCloseCallBack);
    if (DialogCallBack !== null) {
        DialogCallBack(DialogResult);
    }
}
function DialogCloseNone(dlgResult) {
    //use when you want nothing after click
}
function ShowDialog(Title, Message, Type, Buttons, theFunction) {
    if (IsFirstLoad) {
        var body = document.getElementById("body");
        var div = document.createElement("div");
        div.id = "DialogWindow";
        body.appendChild(div);
        DialogWindow = $("#DialogWindow").kendoWindow({
            actions: ["Close"],
            draggable: false,
            modal: true,
            resizable: false,
            visible: false,
            title: "Confirm action",
        }).data("kendoWindow");
        IsFirstLoad = false;
    }
    var dialogData = '<table cellpadding="0" cellspacing="0"><tr>' +
        '<td><div>' + Message + '</div></td>' +
        '<td><div class="DialogIcon ' + Type + '"></div></td>' +
        '</tr></table><div style="text-align: center;">';
    for (var i in Buttons) {
        var s = Buttons[i];
        dialogData += '<input class="k-button" type="button" onclick="DialogClose(\'' + s + '\')" value="' + s + '">';
    }
    dialogData += '</div>';
    DialogResult = "Cancel";
    if (theFunction !== undefined) {
        DialogCallBack = theFunction;
    } else {
        DialogCallBack = null;
    }
    DialogWindow.bind("close", DialogCloseCallBack);
    DialogWindow.title(Title);
    DialogWindow.center();
    DialogWindow.content(dialogData);
    DialogWindow.open();
}