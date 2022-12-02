$(document).ready(function () {
    $("#searchbtn").click(function (e) {
        $("#h3_head").html('<h3 id="h3_head">Loading...!</h3>');
        e.stopPropagation();
        e.preventDefault();
        console.log("HELLO");
        console.log($("#genre").val());
        console.log($("#ddlYears").val());
        /*console.log($("#movieID").text());*/
        var Cdata = new FormData();
        Cdata.append("genre", $("#genre").val());
        Cdata.append("year", $("#ddlYears").val());
        if (Cdata != null) {
            $.ajax({
                type: "POST",
                url: "/Home/SearchMovie",
                cache: false,
                contentType: false,
                processData: false,
                data: Cdata,
                success: function (result) {
                    if (typeof result != "object") {
                        $('#movie_data').html(result);
                    } else {
                        $("#h3_head").html('<h3 id="h3_head">No Data Found!</h3>');
                    }
                },
                error: function () {
                    alert('Empty search');
                    console.log('Failed ');
                }
            });
        }
    });
});   