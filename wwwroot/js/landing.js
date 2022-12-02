let slideIndex = 0;
showSlides();

function showSlides() {
    let i;
    let slides = document.getElementsByClassName("mySlides1");
    let slides2 = document.getElementsByClassName("mySlides2");
    let slides3 = document.getElementsByClassName("mySlides3");
    for (i = 0; i < slides.length; i++) {
        slides[i].style.display = "none";
    }
    for (i = 0; i < slides2.length; i++) {
        slides2[i].style.display = "none";
    }
    for (i = 0; i < slides3.length; i++) {
        slides3[i].style.display = "none";
    }
    slideIndex++;
    if (slideIndex > slides.length) { slideIndex = 1 }
    slides[slideIndex - 1].style.display = "flex";
    if (slideIndex > slides2.length) { slideIndex = 1 }
    slides2[slideIndex - 1].style.display = "flex";
    if (slideIndex > slides3.length) { slideIndex = 1 }
    slides3[slideIndex - 1].style.display = "flex";
    setTimeout(showSlides, 30000); // Change image every 60 seconds
}

