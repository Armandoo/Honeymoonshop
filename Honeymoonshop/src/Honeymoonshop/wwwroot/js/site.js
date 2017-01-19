
$(document).ready(function () {
    initFilterImages()
    toggleMerken();
    toggleStijlen();
    toggleKleuren();
    toggleNeklijnen();
    toggleSilhouettes();
    toggleImage();
    //toggleActievePagina();
    slider();
    button1active();

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

        /*Carousel sleep actie*/
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

        $("body").mouseup(function (e) { down = false; });



    /*Ajax onclick afspraak*/
        $(".selecttime").click(function () {
            $(".tijdstipbuttons").children().remove();
            $(".tijdstipbuttons").text("");

            $.ajax({
                method: "POST",
                datatype: "JSON",
                url: "/afspraak/GetTijden",
                data: jQuery.param({ date: $("#dueDate").val() })                
            })
            .done(function (msg) {
                for (var i = 0; i < msg.length; i++) {
                    var tijd = msg[i];
                    var disabled = "";
                    var checked = "";
                    if (!tijd.isBeschikbaar) { disabled = " disabled='disabled'"; }
                    if (tijd.isChecked) { checked = " checked='checked'"; }
                    $(".tijdstipbuttons").append('<input type="radio" name="tijdstip" id="tijdstip" class="tijdstip" value="' + tijd.tijd + ':00" ' + disabled + checked + ' >' + tijd.tijd + '<br>');

                }
            })
        })

})

function initFilterImages() {
    $("input:checked.filter-checkbox").parents(".rbfilter").each(function () {
        $(".rb.outer", this).toggle();
        $(".rb.inner", this).toggle();
    })
    $("input:checked.filter-checkbox").parents(".rbkleur").each(function () {
        $(this).addClass("bold");
    })


}

function toggleImage() {
    $(".rbfilter").click(function () {
        $(".rb.outer", this).toggle();
        $(this).children("input").prop("checked", !$(this).children("input").is(':checked'));
        $(".rb.inner", this).toggle();
    
    });

    $(".rbkleur").click(function () {
        $(this).children("input").prop("checked", !$(this).children("input").is(':checked'));
        if ($(this).hasClass("bold")) {
            $(this).removeClass("bold");
        } else {
            $(this).addClass("bold");
        }

    });
};
        
 

function toggleActievePagina(){
$('.navbar-nav a').click(function () {
    
    $(".navbar-nav li a").removeClass("actief");
    $(this).addClass('actief');
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
    $("#slider").slider();
}



function getDate() {
    $("#datumtekst").text(document.getElementById("dueDate").value);
    $("#datumkiezen").hide();
    $(".kalenderstap2").show();
    $("#tijdkiezen").show();
}

function selectDate() {
    $("#datumkiezen").show()
    $(".kalenderstap2").hide();
    $("#tijdkiezen").hide();
}

/*homepage 1 t/m 4 buttons*/
function button1active() {
    $(".button1").css("background-color", "#F0597C").css("border-color", "#F0597C");
    $(".button2, .button3, .button4").css("background-color", "grey").css("border-color", "grey");
    $("#nummerafbeelding").text(1);
    $("#dewinkel").show();
    $("#onzespecialisten, #naaiatelier, #servicepunten").hide();
};

function button2active() {
    $(".button2").css("background-color", "#F0597C").css("border-color", "#F0597C");
    $(".button1, .button3, .button4").css("background-color", "grey").css("border-color", "grey");
    $("#nummerafbeelding").text(2);
    $("#onzespecialisten").show();
    $("#dewinkel, #naaiatelier, #servicepunten").hide();
};

function button3active() {
    $(".button3").css("background-color", "#F0597C").css("border-color", "#F0597C");
    $(".button1, .button2, .button4").css("background-color", "grey").css("border-color", "grey");
    $("#nummerafbeelding").text(3);
    $("#naaiatelier").show();
    $("#onzespecialisten, #dewinkel, #servicepunten").hide();
};

function button4active() {
    $(".button4").css("background-color", "#F0597C").css("border-color", "#F0597C");
    $(".button1, .button2, .button3").css("background-color", "grey").css("border-color", "grey");
    $("#nummerafbeelding").text(4);
    $("#servicepunten").show();
    $("#onzespecialisten, #naaiatelier, #dewinkel").hide();    
};