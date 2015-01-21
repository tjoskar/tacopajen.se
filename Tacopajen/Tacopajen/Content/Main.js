jQuery(document).ready(function () {

    //Open the menu
    jQuery("#hamburger").click(function () {
       
            jQuery('.rest').css('min-height', jQuery(window).height());

            jQuery('nav').css('opacity', 1);

            //set the width of primary content container -> content should not scale while animating
            var contentWidth = jQuery('#rest').width();

            //set the content with the width that it has originally
            jQuery('.rest').css('width', contentWidth);

            //display a layer to disable clicking and scrolling on the content while menu is shown
            // jQuery('#contentLayer').css('display', 'block');

            //disable all scrolling on mobile devices while menu is shown
            jQuery('.main').bind('touchmove', function(e) {
                e.preventDefault()
            });
        
    });

    //close the menu
    jQuery(".rest").click(function () {

        //enable all scrolling on mobile devices when menu is closed
        jQuery('.main').unbind('touchmove');
        jQuery('nav').css('opacity', 0);

    });
    

});