$(document).ready(function() {
    var elem = '.indexMenu li';
    $(elem).click(function() {
        $(elem).removeClass('active');
        $(this).addClass('active');
    });
});