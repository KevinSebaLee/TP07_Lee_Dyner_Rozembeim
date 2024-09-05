document.addEventListener('DOMContentLoadedf', function(){
    console.log("Hola");
    setTimeout(function () {
        window.location.replace('@Url.Action("Jugar")');
    }, 4000);
});