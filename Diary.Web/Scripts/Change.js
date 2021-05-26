$('div').hide()

$('#cases').change(function () {
    var value = this.value;
    $('div').hide()
    $('#' + this.value).show();
});