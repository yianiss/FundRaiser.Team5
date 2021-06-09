
const uri = 'index';

document.querySelector('#login_bg').addEventListener("click", function () {
    document.querySelector('#login_session').classList.add("d-none");

    document.querySelector('#Email').nodeValue = "";
    document.querySelector('#Password').nodeValue = "";

    console.log("Hide");
    

});

let login = document.querySelector('#nav-login');
if (login != null) {
    login.addEventListener("click", function () {
        document.querySelector('#login_session').classList.remove("d-none");

        document.querySelector('#Email').nodeValue = "";
        document.querySelector('#Password').nodeValue = "";
        console.log("show");
    });
}




function getUserFundingPackage() {
    fetch(`$/Get`)
        .then(response => response.json())
        .then(data => _displayProject(data))
        .catch(error => console.error('Unable to get Projects.', error));
}

function _displayProjects(data) {
    const rowProject = document.querySelector('#row_project').firstChild;
    let projectList = document.querySelector('#projectList');
    projectList.innerHTML = "";
    data.ProjectDetails.forEach(item => {
        let newProjectRow = rowProject.cloneNode(false);

        newProjectRow.querySelector(".ProjectTitle").innerText = item.ProjectTitle;
        newProjectRow.querySelector(".ProjectDescription").innerText = item.ProjectDescription;
        newProjectRow.querySelector(".ProjectCategory").innerText = item.ProjectCategory;
        newProjectRow.querySelector(".ProjectProgress").innerText = item.ProjectProgress;
        newProjectRow.querySelector(".ProjectDeadline").innerText = item.ProjectDeadline;
        newProjectRow.querySelector(".ProjectCreatorFullName").innerText = item.ProjectCreatorFullName;

        let btnProject = newProjectRow.querySelector(".projectById")

        btnProject.setAttribute('onclick', `Project/(${item.ProjectId})`);
        btnProject.setAttribute('href', 'javascript:void(0)');

        projectList.appendChild(newProjectRow);

    });
}
