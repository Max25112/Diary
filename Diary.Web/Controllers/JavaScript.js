$("#cases").change(function () {
    var case = $("#cases option:selected").val();
    if (case== "general")
{
    //show 2 form fields here and show div
    $("#general").show();
}
        });