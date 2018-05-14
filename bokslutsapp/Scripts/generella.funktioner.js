
function talformat_2dec(belopp) { //Funktion för att formattera tusentalsseparation till 2 decimaler
    return (parseFloat(belopp).toLocaleString("se-SE", {
        minimumFractionDigits: 2,
        maximumFractionDigits: 3
    }));
}

function talformat_0dec(belopp) { //Funktion för att formattera tusentalsseparation till 0 decimaler
    return (parseFloat(belopp).toLocaleString("se-SE", {
        minimumFractionDigits: 0,
        maximumFractionDigits: 0
    }));
}

function beräkningsformat(belopp) { //Funktion för att omvandla talrepresentationen till float
    return belopp.replace(/\s+/g, '');
}

function Beräkningsformat(belopp) { //Funktion för att omvandla talrepresentationen till float
    var temp = belopp.replace(",", ".");
    return temp.replace(/\s+/g, '');
}

function kontoValidering(konto) { //Funktion för att validera att konton består av exakt 4 tecken
    if (!isNaN(konto) && konto.length == 4) {
        addKonteringsrad()
        return konto;
    }
    else {
        Meddelande(4, "Felaktigt konto.");
        return this.value=null;
    }
}

function calcSum(klassSumma) { //Funktion för summering av kolumner
    var summa = 0;
    //iterate through each textboxes and add the values
    $(klassSumma).each(function () {
        var cellvärde = Beräkningsformat(this.value);

        //add only if the value is number
        if (!isNaN(cellvärde) && cellvärde.length != 0) {
            summa += parseFloat(cellvärde);
            //$(this).css("background-color", "#FEFFB0");
        }
        else if (cellvärde.length != 0) {
            //$(this).css("background-color", "red");
        }
    });
    return summa;
}
/*
//Funktioner för radfunktioner
function raderKontroll(mall, radAntStart) { //Styrfunktion över rader
    if ($(mall).find('tr:last input').val() != "") {
        addRad(mall);
    }
    else if ($(mall).find('tr:last input').val() == "") {
        removeRad(mall, radAntStart);
    }
}

function rader_init(mall, radAntStart) { //Funktion som vid initieringen lägger till 4 rader.
    for (var i = 0; i < radAntStart; i++) {
        addRad(mall);
    }
}

function addRad(mall) { //Funktion för att skapa nya konteringsrader
    var klon = $(mall).find('tr:last').clone();
    //var klon = $('.mall1:last').clone();
    klon.find('input[type=text]').val(null);
    return $(mall).append(klon);
    calcSum(".beräknKonto");
}

function removeRad(mall, radAntStart) { //Funktion för att ta bort rader
    if ($(mall).find('tr').length > radAntStart) {
        return $(mall).find('tr:last').remove();
    }
}
//Slut på radfunktioner
*/
function Meddelande(medNr, medText) { //Funktion för att skriva ut meddelanden
    if (medNr == 1) { //Succuess
        $('#Meddelande').html('<div class="alert alert-success"><strong>Meddelande: </strong>' + medText + '</div>').show(500).delay(3500).hide(500);
    }
    if (medNr == 2) { //Info
        $('#Meddelande').html('<div class="alert alert-info">< strong >Info: </strong >' + medText + '</div>').show(500).delay(3500).hide(500);
    }
    if (medNr == 3) { //Varning
        $('#Meddelande').html('<div class="alert alert-warning"><strong>Varning: </strong>' + medText + '</div>').show(500).delay(3500).hide(500);
    }
    if (medNr == 4) { //Fel
        $('#Meddelande').html('<div class="alert alert-danger"><strong>Fel: </strong>' + medText + '</div>').show(500).delay(3500).hide(500);
    }
}