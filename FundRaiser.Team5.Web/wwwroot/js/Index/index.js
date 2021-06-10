
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

getProjects();


function getProjects() {
    //fetch(`hhtps/Asuresite/api/Home/Get`)
    fetch(`Home/Get`)
        .then(response => response.json())
        .then(data => _displayProjects(data))
        .catch(error => console.error('Unable to get Projects.', error));
}

function _displayProjects(data) {
    console.log(data);
    //const rowProject = document.querySelector('#project_list_template').firstChild;
    let projectList = document.querySelector('#project_list');
    console.log(projectList);
    projectList.innerHTML = "";
    let Rowtext = "";
    data.projects.forEach(item => {

        Div1 = document.createElement("div");
        Div1.classList.add("border")
        Div1.classList.add("col-md-10")
        Div1.classList.add("mx-auto")
        Div1.classList.add("m-lg-5")
        Div2 = document.createElement("div");
        Div2.classList.add("row");
        Div3 = document.createElement("div");
        Div3.classList.add("col-md-9");
        Center4 = document.createElement("center");
        h2_5 = document.createElement("h2");
        h2_5.innerHTML = item.projectTitle;
        Center4.appendChild(h2_5);
        Div3.appendChild(Center4);
        Div2.appendChild(Div3);
        Div3 = document.createElement("div");
        Div3.classList.add("col-md-3");
        Center4 = document.createElement("center");
        h2_5 = document.createElement("h2");
        h2_5.innerHTML = item.projectCreatorFullName;
        Center4.appendChild(h2_5);
        Div3.appendChild(Center4);
        Div2.appendChild(Div3);
        Div1.appendChild(Div2);


        Div2 = document.createElement("div");
        Div2.classList.add("row");
        Div3 = document.createElement("div");
        Div3.classList.add("col-md-9");
        Center4 = document.createElement("center");
        P5 = document.createElement("p");
        P5.innerHTML = "Category : "+item.projectCategory;
        Center4.appendChild(P5);
        Div3.appendChild(Center4);
        Div2.appendChild(Div3);
        Div3 = document.createElement("div");
        Div3.classList.add("col-md-3");
        Center4 = document.createElement("center");
        P5 = document.createElement("p");
        P5.innerHTML = "Progress "+ item.projectProgress+" %";
        Center4.appendChild(P5);
        Div3.appendChild(Center4);
        Div2.appendChild(Div3);
        P3 = document.createElement("p");
        P3.innerHTML = item.projectDescription;
        Div2.appendChild(P3);
        Div1.appendChild(Div2);

        Div2 = document.createElement("div");
        Div2.classList.add("row");
        Div3 = document.createElement("div");
        Div3.classList.add("col-md-9");
        Center4 = document.createElement("center");
        P5 = document.createElement("P");
        P5.innerHTML = "You can found this project until: " + item.projectDeadline;
        Center4.appendChild(P5);
        Div3.appendChild(Center4);
        Div2.appendChild(Div3);
        Div3 = document.createElement("div");
        Div3.classList.add("col-md-3");
        Center4 = document.createElement("center");
        Button5 = document.createElement("button");
        Button5.classList.add("btn");
        Button5.classList.add("btn-success");
        Button5.innerHTML = "More Info";
        Center4.appendChild(Button5);
        Div3.appendChild(Center4);
        Div2.appendChild(Div3);
        Div1.appendChild(Div2);
        Div1.appendChild(document.createElement("br"));

        console.log("Hi")
        Rowtext = "";
        //let newProjectRow = rowProject.cloneNode(false);
        Rowtext = '<div class="border col-md-10 mx-auto m-lg-5">'
            //+ '<div class="row">'
            //+ '< div class="col-md-9" > <center><h2>+' + item.ProjectTitle + '</h2></center></div >'
            //+ '<div class="col-md-3"><center><h2>' + item.ProjectCreatorFullName + '</h2></center></div>'
            //+ '</div >'
            //+ '<div class="row" >'
            //+ '<div class="col-md-9" > <center><p>' + item.ProjectCategory + '</p></center></div >'
            //+ '<div class="col-md-3" > <center><p>Progress : ' + item.ProjectProgress + '%</p></center></div >'
            //+ '<p> ' + item.ProjectDescription + '</p >'
            //+ '</div >'
            //+ '<div class="row" >'
            //+ '<div class="col-md-9" > <center><p>You can found this project until: ' + item.ProjectDeadline + '</p></center></div >'
            //+ '<div class="col-md-3" > <center><button class="btn btn-success" >More Info</button></center></div >'
            //+ '</div >'
            + '</div >';

        //Div1.innerText = Rowtext;
        //newProjectRow.querySelector(".ProjectTitle").innerText = item.ProjectTitle;
        //newProjectRow.querySelector(".ProjectDescription").innerText = item.ProjectDescription;
        //newProjectRow.querySelector(".ProjectCategory").innerText = item.ProjectCategory;
        //newProjectRow.querySelector(".ProjectProgress").innerText = item.ProjectProgress;
        //newProjectRow.querySelector(".ProjectDeadline").innerText = item.ProjectDeadline;
        //newProjectRow.querySelector(".ProjectCreatorFullName").innerText = item.ProjectCreatorFullName;

        //let btnProject = newProjectRow.querySelector(".projectById")

        //btnProject.setAttribute('onclick', `Project/(${item.ProjectId})`);
        //btnProject.setAttribute('href', 'javascript:void(0)');

        projectList.appendChild(Div1);
    });
    console.log(projectList);
}

document.querySelector('#loginbtn').addEventListener("click", function () {

    let form = document.querySelector('#loginform');
    $.ajax(
        {
            url: "/login",
            dataType: 'POST',
            data: form.serialize(),
            success: function (data) {
                alert("FormOK"); // show response from the php script.
            }
        }

    );
});

