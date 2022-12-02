$(document).ready(function () {
    $('#b1').click(function () {
        //alert('button clicked');
        $.get('https://imdb-api.com/en/API/MostPopularMovies/k_s69w4qvu', function (result) {
            console.log(result);
            $('#1').html(result['items'][0]["rank"]);
            $('#2').html(result['items'][0]["title"]);
            $('#3').html(result['items'][0]["image"]);
            for (i = 0; i < 6; i++) {
                $("#1").append("<partial model name=\"Card.cshtml\" />");
            }
        })
    })
});