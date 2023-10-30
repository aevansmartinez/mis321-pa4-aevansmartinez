let count = 0;
let myExercises = [];

const url = 'http://localhost:5248/api/Exercise';

async function handleOnLoad(){
    //myExercises=JSON.parse(localStorage.getItem('myExercises'));
    let response = await fetch(url);
    let data = await response.json();
    console.log(data);

    if(!myExercises){myExercises = []}
    let html= `      
        <div class="banner">
            <h1>Tide Fit</h1>
        </div>
        <div id='tableBody'></div>
        
        <form onsubmit= "return false">
            <label for="ID">Exercise ID:</label><br>
            <input type="text" id="ID" name="ID"><br>

            <label for="activityType">Activity Type:</label><br>
            <input type="text" id="activityType" name="activityType"><br>

            <label for="distance">Distance:</label><br>
            <input type="text" id="distance" name="distance"><br>

            <label for="date">Date Completed:</label><br>
            <input type="text" id="date" name="date"><br>

            <button onclick="handleExerciseAdd()" class="btn btn-primary">Add Exercise</button>
        </form>`;
    document.getElementById('app').innerHTML=html;
    populateTable();
}

function getExercises(){
    fetch(url).then(function(response){
        console.log(response);
        return response.json();
    }).then(function (json){
        let html = "<ul>";
        json.forEach((exercise)=>{
            html += "<li>" + exercise.ActivityType + ", distance:" + exercise.Distance + "</li>";
        });
        html += "</ul>";
        document.getElementById("exercises").innerHTML = html;
    }).catch(function (error){
        console.log(error);
    });
}

async function SaveExercise(){
    let exercise = {id: '192', ActivityType: 'running', Distance: 3.1, DateCompleted: "2023-09-12"}
    await fetch(url, {
        method: "POST",
        body: JSON.stringify(exercise),
        headers: {
            "Content-type": "application/json; charset=UTF-8"
        }
    })
}

async function deleteExercise(){
    await fetch(url + '/1', {
        method: "DELETE",
        body: JSON.stringify(exercise),
        headers: {
            "Content-type" : "application/json; charset=UTF=8"
        }
    })
}

function handleExerciseAdd(){
    let exercise = {ID: document.getElementById('ID').value, ActivityType: document.getElementById('activityType').value, 
        Distance: document.getElementById('distance').value, DateCompleted: document.getElementById('date').value,
        Pinned: false};
    myExercises.push(exercise);
    SortTable()
    localStorage.setItem('myExercises', JSON.stringify(myExercises));
    populateTable();
    document.getElementById('ID').value = '';
    document.getElementById('activityType').value = '';
    document.getElementById('distance').value = '';
    document.getElementById('date').value = '';
}

function SortTable(){
    myExercises.sort(function (a,b){
        if (a.Pinned != b.Pinned){
            if (a.Pinned == true) return -1;
            else return 1;
        }
        return new Date(b.DateCompleted) - new Date(a.DateCompleted);
    });
}

function handleExerciseDeleteSoft(id){
    let tempExercise = myExercises.find(function (a){
        return a.id == id;
    });
    tempExercise.deleted = !tempExercise.deleted;
    localStorage.setItem('myExercises', JSON.stringify(myExercises));
    populateTable();
}

function handleExercisePin(id){
    let tempExercise = myExercises.find(function (a){
        return a.ID == id;
    });
    tempExercise.Pinned = !tempExercise.Pinned;
    SortTable();
    localStorage.setItem('myExercises', JSON.stringify(myExercises));
    populateTable();
}

function populateTable(){
    let index = 1;
    let html = `
    <table class="table table-striped">
            <tr>
                <th>Exercise ID</th>
                <th>Activity Type</th>
                <th>Distance</th>
                <th>Date Completed</th>
                <th>Pin</th>
                <th>Delete</th>
            </tr>`;
    myExercises.forEach(function(exercise){
        let pinButton = "Unpin"
        if (exercise.Distance==undefined){
            exercise.Distance = 0;
        }
        if(exercise.Pinned==undefined || exercise.Pinned == false){
            exercise.Pinned = false;
            pinButton = "Pin";
        }
        html += `
            <tr>
                <td>${exercise.ID}</td>
                <td>${exercise.ActivityType}</td>
                <td>${exercise.Distance}</td>
                <td>${exercise.DateCompleted}</td>
                <td><button class="btn btn-warning" id ="pin${index}" onclick="handleExercisePin('${exercise.ID}')">${pinButton}</button></td>
                <td><button class="btn btn-danger" onclick="handleExerciseDelete('${exercise.ID}')">Delete</button></td>
            </tr>`;
        index++;

    })
    html += `</table>`
    document.getElementById('tableBody').innerHTML = html;
}

// function myFunction() {
//     document.getElementById("demo").innerHTML = "Hello World";
// }

// function handleExerciseDelete(id){
//     myExercises = myExercises.filter(exercise => exercise.ID != id);
//     localStorage.setItem('myExercises', JSON.stringify(myExercises));
//     populateTable();
// }