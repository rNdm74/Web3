window.onload = init;

function init()
{
    var button = document.getElementById("bDisplay");
    button.onclick = displayWinningTeam;
}

function displayWinningTeam()
{
    // Create array of teams
    var teams = [
        new team("Tigers", 14),
        new team("Dragons", 6),
        new team("Fluffy Ducks", 23)
    ];

    // Sort teams ascending order
    teams.sort(function(a, b) {
        if (a.score < b.score)
            return 1;
        if (a.score > b.score)
            return -1;
        // a must be equal to b
        return 0;
    });

    // Display winning team to screen
    alert(teams[0].name + " won with " + teams[0].score + " points");
}

function team(name, score)
{
    this.name = name;
    this.score = score;
}

/***************
 * Question 1a *
 ***************/
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