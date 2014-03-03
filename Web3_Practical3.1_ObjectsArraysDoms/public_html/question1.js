var teams = [ 
    new team("Tigers",14),
    new team("Dragons",6),
    new team("Fluffy Ducks",23) 
];

/***************************
 * Sort teams ascending
 ***************************/
teams.sort(function (a, b) {
    if (a.score < b.score)
      return 1;
    if (a.score > b.score)
      return -1;
    // a must be equal to b
    return 0;
});

function team(name, score)
{
	this.name = name;
	this.score = score;
}

function displayWinningTeam()
{
    alert(teams[0].name + " won with " + teams[0].score + " points");
}

/*************
 * Question 1a
 *************/
//function displayWinningTeam(){
//    var team = {
//        team1Name: "Otago",
//        team2Name: "Canterbury",
//        team1Score: 100,
//        team2Score: 156
//    };
//
//    if(team["team1Score"] > team["team2Score"])
//    {
//        alert(team["team1Name"] + " wins");
//    }
//    else
//    {
//        alert(team["team2Name"] + " wins");
//    }
//}

function init()
{
    var button = document.getElementById("bDisplay");
    button.onclick = displayWinningTeam;
}

window.onload = init;