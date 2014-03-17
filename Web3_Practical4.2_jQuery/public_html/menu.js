// Global state variable to keep track of which version of the menu is showing
var stateVegetarian = false;

// Bind the toggleVegetarian method to both buttons
$(document).ready(function()
{

    $('#btnVegetarian').click(toggleVegetarian);
    $('#btnRestore').click(toggleVegetarian);

});


// function toggleVegetarian: Toggles the state variable and calls the appropriate methods to put the menu in the correct state.
function toggleVegetarian()
{
    if (stateVegetarian === false)
    {
        stateVegetarian = true;
        detachFish();
        replaceHamburgers();
        replaceMeat();
    }
    else
    {
        stateVegetarian = false;
        restoreFish();
        restoreHamburgers();
        restoreMeat();
    }
}
//---------------------------------------------------------------------
//---------------------------------------------------------------------
function detachFish()
{

    // You want to remove each entree that has any ingredient of class 'fish'
    // Here are a couple attempts that *don't* work 
    // $('.fish').detach();			-- This selects all the ingredient <li> of class fish, but we want to remove the whole containing <li>....  
    // $('.fish').parent().detach(); 		-- This selects the ul containing the <li> of class fish, but we want to remove the  li containing that ul......

    // Remember to store the result in a variable so you can put them back in later.
    // Since all these entrees come at the beginning of the main menu <ul>, you'll be able to reattach them in a single operation...

    $fish_detach = $('.fish').parent().parent().detach();

}
//---------------------------------------------------------------------
//---------------------------------------------------------------------
function replaceHamburgers()
{
    // Because there is a one-to-one replacement of hamburger with mushrooms, you don't need to remove any nodes.
    // You just need to do a global string replace. Remember that if you select by class, you get the whole element that
    // class applies to. So be sure to replace the whole element, not just the text.
    // You will be able to restore by just reversing the operation.

    // Find the appropriate jQuery method to replace an element with some raw HTML

    $('.hamburger').replaceWith("<li class='mushrooms'>portobello mushrooms</li>");
    
}
//---------------------------------------------------------------------
//---------------------------------------------------------------------
function replaceMeat()
{
    // This one involves replacing different ingredients (all of class 'meat', but with different actual text content)
    // we will need to detach those node and save them for the later restore.
    // We will have to insert new nodes into the DOM to replace the ones we are temporarily removing 


    //Insert a tofu <li> before each element of class 'meat'	
    $('.meat').before("<li class='tofu'>tofu</li>");

    // Set all the entrees now containing tofu to class 'leaf' so they will show the image.	
    $('li:contains("tofu")').addClass('leaf');

    // Detach all the elements of class 'meat' and store them somewhere so you can restore them later	
    $meat_detach = $('.meat').detach();
}
//---------------------------------------------------------------------
//---------------------------------------------------------------------
function restoreFish()
{
    // The stored fish entree nodes conveniently belong at the front of <ul class="menu_entrees">. That is, before the first <li> in that <ul>
    // Put them there. 
    $('.menu_entrees li').first().before($fish_detach);

}
//---------------------------------------------------------------------
//---------------------------------------------------------------------
function restoreHamburgers()
{
    // Just reverse the operation you performed in replaceHamburgers(). Hopefully, you replaced the class as well as the text so
    // you can select all those nodes again...
    $('.mushrooms').replaceWith("<li class='hamburger'>hamburger</li>");
}
//---------------------------------------------------------------------
//---------------------------------------------------------------------
function restoreMeat()
{
    // This is the most complex part. You need to select all the elements of class 'tofu'. Then you need to iterate over that
    // set with an indexed function, reattach the corresponding stored node of class 'meat'
    $('.tofu').each(function(index){
        $(this).after($meat_detach[index]);
    });

    // Now get rid of the 'leaf' class from the entrees that have tofu as an ingredient			
    $('li:contains("tofu")').parent().parent().removeClass('leaf');

    // Finally, just remove all those tofu ingredients
    $tofu_detach = $('.tofu').detach();
    
}
//---------------------------------------------------------------------
//---------------------------------------------------------------------



