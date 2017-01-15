
$(document).ready(function () {
    toggleMerken();
    toggleStijlen();
    toggleKleuren();
    toggleNeklijnen();
    toggleSilhouettes();
    //toggleImage();
    toggleActievePagina();
    slider();

    

    $("#slider").slider().on('slideStop', function (ev) {


        var minPrijs = $("#slider").data("slider").getValue()[0];
        var maxPrijs = $("#slider").data("slider").getValue()[1];

        $(".minprijs").text(minPrijs);
        $(".maxprijs").text(maxPrijs);

        $('input:hidden[name=minPrijs]').val( minPrijs);
        $('input:hidden[name=maxPrijs]').val( maxPrijs);
    });

    $('select[name=sorteer] option:selected').each(function () {
        
        console.log("a");
    });

    $("#datepicker").datepicker({
        minDate: +0,
        language: "nl",
        prevText: '<span class="glyphicon glyphicon-menu-left"></span>',
        nextText: '<span class="glyphicon glyphicon-menu-right"></span>',
        onSelect: function () {
            $("#dueDate").val($("#datepicker").datepicker({dateFormat : 'dd/mm/yyyy'}).val());
        }
    });

        var x,y,top,left,down;
        $(".slide-items").mousedown(function(e){
            e.preventDefault();
            down=true;
            x=e.pageX;
            y=e.pageY;
            top=$(this).scrollTop();
            left=$(this).scrollLeft();
        });

        $("body").mousemove(function(e){
            if(down){
                var newX=e.pageX;
                var newY=e.pageY;

                console.log(y+", "+newY+", "+top+", "+(top+(newY-y)));

                //$(".slide-container").scrollTop(top-newY+y);
                $(".slide-container").scrollLeft(left-newX+x);
            }
        });

        $("body").mouseup(function(e){down=false;});

})

/*function toggleImage() {
    $(".rbfilter").click(function () {

        
       
        $(".rb.outer", this).toggle();
        $(this).children("input").prop("checked", !$(this).children("input").is(':checked'));
 
        
        $(".rb.inner", this).toggle();
    
    });
};*/
        /*
        if ($(".rb.inner").show()) {
            $('.merk').prop('checked', true);
        }

        else {
            $(".rb.inner", this).toggle();
            $('.merk').prop('unchecked', false);
        }
*/        
 

function toggleActievePagina(){
$('.navbar-nav a').click(function () {
    
    $(".navbar-nav li a").removeClass("actief");
    $(this).addClass('actief');
    
        alert("a");
        
        
    });
}

function toggleMerken() {
    $(".merken").toggle();
}

function toggleKleuren() {
    $(".kleuren").toggle();
}

function toggleStijlen() {
    $(".stijlen").toggle();
}

function toggleNeklijnen() {
    $(".neklijnen").toggle();
}

function toggleSilhouettes() {
    $(".silhouettes").toggle();
}

function slider() {
    $("#slider").slider({});
};


/*document.filterprijsform.minprijs.oninput = function () {
    document.filterprijsform.priceOutputMinPrijs.value = document.filterprijsform.minprijs.value;
}

document.filterprijsform.maxprijs.oninput = function () {
    document.filterprijsform.priceOutputMaxPrijs.value = document.filterprijsform.maxprijs.value;
}*/
