$(document).ready(function () {
    $('#outerdiv').append(
        $('<div>').prop({
            id: 'innerdiv',
            innerHTML: 'Hi there!',
            className: 'border pad'
        })
    );
});


/*
$(document).ready(function () {
    $('<div id="innerdiv" class="border pad">Hi there!</div>').appendTo('#outerdiv');
});  */