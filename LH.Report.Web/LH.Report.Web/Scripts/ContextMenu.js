function OnContextMenuShowing(s, e) {
    var contextMenu = s.GetContextMenu();
    var selectedElement = GetSelectedElement();
    var isImageSelected = IsImageElement(selectedElement);
    
    SetContextMenuItemVisible(contextMenu, "AddTitle", isImageSelected && !selectedElement.title);
    SetContextMenuItemVisible(contextMenu, "ChangeTitle", isImageSelected && selectedElement.title);
    SetContextMenuItemVisible(contextMenu, "RemoveTitle", isImageSelected && selectedElement.title);
}
function SetContextMenuItemVisible(contextMenu, itemName, visible) {
    var item = contextMenu.GetItemByName(itemName);
    if(item)
        item.SetVisible(visible);
}
function OnCustomCommand(s, e) {
    switch(e.commandName) {
        case "AddTitle":
            UpdateImageTitle(GetSelectedElement());
            break;
        case "ChangeTitle":
            UpdateImageTitle(GetSelectedElement());
            break;
        case "RemoveTitle":
            RemoveImageTitle(GetSelectedElement());
            break;
    }
}

function GetSelectedElement() {
    return heContextMenu.GetSelection().GetSelectedElement();
}
function IsImageElement(element) {
    return element && element.tagName.toLowerCase() == "img";
}

function UpdateImageTitle(element) {
    if(IsImageElement(element)) {
        var title = prompt("Please specify the title:", element.title);
        if(title != null)
            element.title = title;
    }
}
function RemoveImageTitle(element) {
    if(IsImageElement(element))
        element.title = "";
}