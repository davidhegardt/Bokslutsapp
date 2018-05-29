
function talformat_2dec(belopp) { //Funktion för att formattera tusentalsseparation till 2 decimaler
    var tal = parseFloat(belopp.toString().replace(",", ".")).toFixed(2).replace(".", ",");
    return addSeparator(tal);
}

function talformat_0dec(belopp) { //Funktion för att formattera tusentalsseparation till 0 decimaler
    var tal = parseFloat(belopp.toString().replace(",", ".")).toFixed(0).replace(".", ",");
    return addSeparator(tal);
}

function addSeparator(nStr) { //Funktion för tusentalsavgränsning
    nStr += '';
    x = nStr.split('.');
    x1 = x[0];
    x2 = x.length > 1 ? '.' + x[1] : '';
    var rgx = /(\d+)(\d{3})/;
    while (rgx.test(x1)) {
        x1 = x1.replace(rgx, '$1' + ' ' + '$2');
    }
    return x1 + x2;
}

function Beräkningsformat(belopp) { //Funktion för att omvandla talrepresentationen till float
    //var temp1 = belopp.replace(/[\u00AD\u2010\u2011\u2012\u2013\u2014\u2015\u2043\uFE58\uFE63\uFE0D]/g, '\u2212');
    var temp1 = belopp.replace(/\u2013|\u2014/g, "-");
    var temp2 = temp1.replace(",", ".");
    return temp2.replace(/\s+/g, '');
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
            if (cellvärde[0] == '−') {
                summa -= parseFloat(cellvärde);
            }
            else {
                summa += parseFloat(cellvärde);
            }
    
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