let buttonClicked = false;
const categorias = ["Historia", "Ciencia", "Geografía", "Arte", "Deportes"];
const colores = ["#FF6F61", "#6B5B95", "#88B04B", "#F7CAC9", "#92A8D1"];
const numSecciones = categorias.length;
const anguloPorSeccion = 2 * Math.PI / numSecciones;
const canvas = document.getElementById("canvas");
const ctx = canvas.getContext("2d");
const Username = document.getElementById("Username");
const ruleta = document.getElementById("ruleta");
const botonNombre = document.getElementById("botonUsuario");
const nombre = document.getElementById("nombreUsuario");

ruleta.style.visibility="hidden";

let anguloInicial = 0;

function dibujarRuleta() {
    for (let i = 0; i < numSecciones; i++) {
        const anguloFinal = anguloInicial + anguloPorSeccion;
        ctx.beginPath();
        ctx.moveTo(canvas.width / 2, canvas.height / 2);
        ctx.arc(canvas.width / 2, canvas.height / 2, canvas.width / 2, anguloInicial, anguloFinal);
        ctx.fillStyle = colores[i];
        ctx.fill();
        ctx.strokeStyle = "#FFFFFF"; // Borde blanco para un diseño más limpio
        ctx.lineWidth = 2;
        ctx.stroke();
        ctx.save();

        ctx.translate(canvas.width / 2, canvas.height / 2);
        ctx.rotate(anguloInicial + anguloPorSeccion / 2);
        ctx.textAlign = "right";
        ctx.fillStyle = "#FFFFFF";
        ctx.font = "bold 18px Arial";
        ctx.fillText(categorias[i], canvas.width / 2 - 20, 10);
        ctx.restore();

        anguloInicial = anguloFinal;
    }
}

function ingresarUsuario(){
    if(nombre.value != ""){
        event.preventDefault();
        Username.style.visibility ="hidden";
        ruleta.style.visibility="visible";
    }
    else{
        botonNombre.disabled = true;
    }
}

function girarRuleta() {
    if (buttonClicked) return; // No permitir más clics mientras gira
    buttonClicked = true;

    // Calcular una rotación a la derecha
    const rotacion = Math.floor(Math.random() * 3600) + 360;
    const duracion = 5; // duración en segundos
    canvas.style.transition = `transform ${duracion}s ease-out`;
    canvas.style.transform = `rotate(${rotacion}deg)`;

    setTimeout(() => {
        const anguloFinal = rotacion % 360;
        const indiceGanador = Math.floor(numSecciones - (anguloFinal / 360) * numSecciones) % numSecciones;

        document.getElementById("resultado").textContent = `¡La categoría es: ${categorias[indiceGanador]}! y su usuario es ${nombre.value}`;
        document.getElementById("continuarBtn").style.display = 'block'; // Mostrar el botón Continuar
        document.getElementById("girarBtn").disabled = true; // Deshabilitar el botón Girar
        canvas.style.transition = "none"; // Para permitir más giros posteriores
    }, duracion * 1000);
}

function continuar() {
    document.getElementById("continuarBtn").style.display = 'none'; // Ocultar el botón Continuar
    document.getElementById("girarBtn").disabled = false; // Habilitar el botón Girar
}

dibujarRuleta();
