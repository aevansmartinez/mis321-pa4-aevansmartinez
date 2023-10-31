let count = 0;
let myExercises = [];
const url = 'http://localhost:5248/api/Exercise';

async function handleOnLoad(){
    let response = await fetch(url);
    let data = await response.json();
    myExercises = data;
    if(!myExercises){myExercises = []}
    
    let html= `      
        <div class="banner">
            <h1>Tide Fit</h1>
        </div>
        <div id='tableBody'></div>
        
        <form onsubmit= "return false">
            <label for="activityType">Activity Type:</label><br>
            <input type="text" id="activityType" name="activityType"><br>

            <label for="distance">Distance:</label><br>
            <input type="text" id="distance" name="distance"><br>

            <label for="date">Date Completed:</label><br>
            <input type="text" id="date" name="date"><br>

            <button onclick="PostExercise()" class="btn btn-primary">Add Exercise</button>
        </form>`;
    document.getElementById('app').innerHTML=html;
    populateTable();
}
async function PostExercise(){ //adds exercise to table ~~~~~~~~~~~~~~~~~~~~~~~~ DONE
    const activityTypeConst = document.getElementById('activityType').value;
    const distanceConst = document.getElementById('distance').value;
    const dateCompletedConst = document.getElementById('date').value;

    let exercise = {
        id: 0,
        activityType: activityTypeConst,
        distance: distanceConst,
        dateCompleted: dateCompletedConst,//new Date().toISOString(),
        pinned: false,
        deleted: false,
      };

    let exerciseID = await fetch (url, {
        method: "POST",
        headers: {
            Accept: "application/json",
            "Content-Type": "application/json",
        },
        body: JSON.stringify(exercise),
        });
        
    exercise.id = await exerciseID.json();
    myExercises.push(exercise);
    populateTable();
}
async function PutExercise(myExercise){ //pin or delete an exercise ~~~~~~ DONE
    let newUrl = url + "/" + myExercise.id;
    await fetch (newUrl, {
        method: "PUT",
        headers: {
            Accept: "application/json",
            "Content-Type": "application/json",
        },
        body: JSON.stringify(myExercise),
        });
    populateTable();
}
function SortArray(){
    myExercises.sort(function (a,b){
        if (a.pinned != b.pinned){
            if (a.pinned == true) return -1;
            else return 1;
        }
        if (a.dateCompleted < b.dateCompleted) return 1;
        else return -1;
    });
}
async function handleExerciseDeleteSoft(id){ //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ DONE
    let tempExercise = myExercises.find(function (a){
        return a.id == id;
    });
    tempExercise.deleted = !tempExercise.deleted;
    await PutExercise(tempExercise);
}
async function handleExercisePin(findId){  //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ DONE
    let tempExercise = myExercises.find(function (a){
        return a.id == findId;
    });
    tempExercise.pinned = !tempExercise.pinned;
    await PutExercise(tempExercise);
}
function populateTable(){
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
    SortArray();
    myExercises.forEach(function(exercise){
        let pinButton = "Unpin"
        if (exercise.distance==undefined){
            exercise.distance = 0;
        }
        if (exercise.pinned == false){
            pinButton = "Pin";
        }
        if (exercise.deleted == false){
            html += `
                <tr>
                    <td>${exercise.id}</td>
                    <td>${exercise.activityType}</td>
                    <td>${exercise.distance}</td>
                    <td>${exercise.dateCompleted}</td>
                    <td><button class="btn btn-warning" onclick="handleExercisePin('${exercise.id}')">${pinButton}</button></td>
                    <td><button class="btn btn-danger" onclick="handleExerciseDeleteSoft('${exercise.id}')">Delete</button></td>
                </tr>`;
        }
    })
    html += `</table>`
    document.getElementById('tableBody').innerHTML = html;
}