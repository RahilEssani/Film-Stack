
$(document).ready(function () {
    $("#btnsubmit").click(function (e) {
        e.stopPropagation();
        e.preventDefault();
        console.log("HELLO");
        console.log($("#name").val());
        console.log($("#comment").val());
        console.log($("#movieID").text());
        var Cdata = {
            Name : $("#name").val(),
            Comment : $("#comment").val(),
            movieID : $("#movieID").text()
        }
        console.log(Cdata.Name);
        console.log(Cdata.Comment);
        console.log(Cdata.movieID);
        
        if (Cdata != null) {
            $.ajax({
                type: "POST",
                url: "/Home/AddComment",
                contentType: "application/json; charset=utf-8",
                data: JSON.stringify(Cdata),
                success: function (result) {
                    if (result != null) {
                        $("#name").val('');
                        $("#comment").val('');
                        $("#user-comment").append(result);

                    } else {
                        alert("Something went wrong");
                    } 
                },
                error: function () {
                    alert('Empty Comment');
                    console.log('Failed ');
                }
            });
        }
    });
});   