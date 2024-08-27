const wheel = document.getElementById("wheel");
const spinBtn = document.getElementById("spin-btn");
const IrAlJuego = document.getElementById("button");
const Dificultades = document.getElementById("dificultades");
var CategoriaTocada = document.getElementById("categorias");

Dificultades.style.visibility = "hidden";
IrAlJuego.style.visibility = "hidden";

const rotationValues = [
  { minDegree: 0, maxDegree: 120, value: "Decada 2000" },
  { minDegree: 121, maxDegree: 240, value: "Futbol Europeo" },
  { minDegree: 241, maxDegree: 360, value: "Futbol Sudamericano" }
];

const data = [33.3, 33.3, 33.3];
const pieColors = ["#00aae4", "#ffd200", "#ff6961"];
let myChart = new Chart(wheel, {
  plugins: [ChartDataLabels],
  type: "pie",
  data: {
    labels: ["Futbol Europeo", "Futbol Sudamericano", "Decada 2000"],
    datasets: [
      {
        backgroundColor: pieColors,
        data: data,
      },
    ],
  },
  options: {
    responsive: true,
    animation: { duration: 0 },
    plugins: {
      tooltip: false,
      legend: {
        display: false,
      },
      datalabels: {
        color: "#ffffff",
        formatter: (_, context) => context.chart.data.labels[context.dataIndex],
        font: { size: 17 },
      },
    },
  },
});

let optionChosen;
let touchedBtn = false;
let touchedDificultades = false;

const valueGenerator = (angleValue) => {
  for (let i of rotationValues) {
    if (angleValue >= i.minDegree && angleValue <= i.maxDegree) {
      console.log(i.value);

      if(touchedBtn){
        Dificultades.style.visibility = "visible";
        spinBtn.disabled = true;
        if(touchedDificultades){
          IrAlJuego.style.visibility = "visible";
        }
      }
      else{
        spinBtn.disabled = false;
      }
      break;
    }
  }
};

Dificultades.addEventListener("click", () => {
  touchedDificultades = true;

  console.log("Apreto boton");
});

let count = 0;
let resultValue = 101;
spinBtn.addEventListener("click", () => {
  touchedBtn = true;
  spinBtn.disabled = true;
  let randomDegree = Math.floor(Math.random() * (355 - 0 + 1) + 0);
  let rotationInterval = window.setInterval(() => {
    myChart.options.rotation = myChart.options.rotation + resultValue;
    myChart.update();
    if (myChart.options.rotation >= 360) {
      count += 1;
      resultValue -= 5;
      myChart.options.rotation = 0;
    } else if (count > 15 && myChart.options.rotation == randomDegree) {
      valueGenerator(randomDegree);
      clearInterval(rotationInterval);
      count = 0;
      resultValue = 101;
    }

    setTimeout(() => {
      spinBtn.disabled = false;
    }, 2000);
  }, 10);
});