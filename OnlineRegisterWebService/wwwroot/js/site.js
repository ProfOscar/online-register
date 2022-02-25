const uri = 'api/students';
let students = [];

function getItems() {
    fetch(uri)
        .then(response => response.json())
        .then(data => _displayItems(data))
        .catch(error => console.error('Unable to get items.', error));
}

function _displayItems(data) {
    const tBody = document.getElementById('students');
    tBody.innerHTML = '';
    const button = document.createElement('button');
    data.forEach(item => {
        let editButton = button.cloneNode(false);
        editButton.innerText = 'Edit';
        //editButton.setAttribute('onclick', `displayEditForm(${item.id})`);
        let deleteButton = button.cloneNode(false);
        deleteButton.innerText = 'Delete';
        //deleteButton.setAttribute('onclick', `deleteItem(${item.id})`);
        let tr = tBody.insertRow();

        let td1 = tr.insertCell(0);
        let textNode = document.createTextNode(item.firstName);
        td1.appendChild(textNode);

        let td2 = tr.insertCell(1);
        textNode = document.createTextNode(item.lastName);
        td2.appendChild(textNode);

        let td3 = tr.insertCell(2);
        textNode = document.createTextNode(item.classShort);
        td3.appendChild(textNode);

        let td4 = tr.insertCell(3);
        td4.appendChild(editButton);

        let td5 = tr.insertCell(4);
        td5.appendChild(deleteButton);
    });

    students = data;
}
