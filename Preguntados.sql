CREATE DATABASE PREGUNTADOS;

USE PREGUNTADOS;

CREATE TABLE Categorias(
    IdCategoria INT NOT NULL PRIMARY KEY IDENTITY(1, 1),
    Nombre VARCHAR(200) NOT NULL,
    Foto TEXT NOT NULL
);

CREATE TABLE Dificultades(
    IdDificultad INT NOT NULL PRIMARY KEY IDENTITY(1, 1),
    Nombre VARCHAR(200) NOT NULL
);

CREATE TABLE Preguntas(
    IdPregunta INT NOT NULL PRIMARY KEY IDENTITY(1, 1),
    IdCategoria INT NOT NULL FOREIGN KEY REFERENCES Categorias(IdCategoria),
    IdDificultad INT NOT NULL FOREIGN KEY REFERENCES Dificultades(IdDificultad),
    Enunciado VARCHAR(200) NOT NULL,
    Foto TEXT NOT NULL
);

CREATE TABLE Respuestas(
    IdRespuesta INT NOT NULL PRIMARY KEY IDENTITY(1, 1),
    IdPregunta INT NOT NULL FOREIGN KEY REFERENCES Preguntas(IdPregunta),
    Opcion INT NOT NULL,
    Contenido VARCHAR(200) NOT NULL,
    Correcta BIT NOT NULL,
    Foto TEXT NOT NULL
);
INSERT INTO Dificultades (Nombre) VALUES ('Facil');
INSERT INTO Dificultades (Nombre) VALUES ('Medio');
INSERT INTO Dificultades (Nombre) VALUES ('Dificil');


insert into Categorias(Nombre,Foto) values ('Futbol Europeo', 'https://a3.espncdn.com/combiner/i?img=%2Fphoto%2F2022%2F0211%2Fr973052_1296x729_16%2D9.jpg');
insert into Categorias(Nombre,Foto) values ('Futbol Sudamericano', 'https://resizer.glanacion.com/resizer/v2/el-gol-de-K72K6KDI6JFG3NLOF7F4EBDNAI.jpg?auth=1a097fa58d9ca6ca5a70364edaccc282fcc190204ee70f6492d5802ac6d0ca8d&width=880&height=586&quality=70&smart=true');
insert into Categorias(Nombre ,Foto) values('Decada 2000','https://www.coervercoaching.com/wp-content/uploads/2019/02/Ronaldinho_Real_Madrid-Milan-e1549895206735-1024x655.jpg') ;

insert into Preguntas(IdCategoria, IdDificultad, Enunciado, Foto) values(4,1,'¿Cuál es el nombre del torneo de clubes más prestigioso de Europa?', 'https://www.ole.com.ar/2019/05/08/RxAcoR1ih_720x0__1.jpg');
insert into Preguntas(IdCategoria, IdDificultad, Enunciado, Foto) values(4,1,'¿Qué selección ganó la Eurocopa 2016?', 'https://images.pagina12.com.ar/styles/focal_3_2_960x640/public/2024-06/848849-trofeo-20y-20pelota-20euro-202024.jpg?h=885011cc&itok=7LXybzPg');
insert into Preguntas(IdCategoria, IdDificultad, Enunciado, Foto) values(4,1,'¿Qué club es conocido por sus colores blanco y negro en Italia?', 'https://image.spreadshirtmedia.com/image-server/v1/products/T1459A839PA3861PT28D1027674207W8333H10000/views/1,width=1200,height=630,appearanceId=839,backgroundColor=F2F2F2/bianconeri-turin-sticker.jpg');
insert into Preguntas(IdCategoria, IdDificultad, Enunciado, Foto) values(4,1,'¿Cuál es el país anfitrión del club FC Bayern Múnich?', 'https://images2.minutemediacdn.com/image/upload/c_crop,w_4000,h_2250,x_0,y_199/c_fill,w_720,ar_16:9,f_auto,q_auto,g_auto/images/GettyImages/mmsport/90min_es_international_web/01hvdecb13p5a8953dm6.jpg');
insert into Preguntas(IdCategoria, IdDificultad, Enunciado, Foto) values(4,1,'¿Qué selección ganó la Copa del Mundo en 2010?', 'https://fotografias.larazon.es/clipping/cmsimages02/2019/08/09/1481A0EC-82CB-4A69-8734-4573A5DE4D79/98.jpg?crop=680,383,x0,y4&width=1900&height=1069&optimize=low&format=webply');


insert into Preguntas(IdCategoria,IdDificultad,Enunciado,Foto) VALUES (4,2,'¿Cuál es el máximo goleador de la historia de la Liga de Campeones de la UEFA?','https://editorial.uefa.com/resources/0246-0e98e0aed53b-074f228dc0a2-1000/ucl_branding.jpeg');
insert into Preguntas(IdCategoria,IdDificultad,Enunciado,Foto) VALUES (4,2,'¿Qué equipo inglés ganó la Premier League en la temporada 2021-2022?','https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSNJhe9PDuxsWKxEbtVjcUrzMWy0ELjMd15uQ&s');
insert into Preguntas(IdCategoria,IdDificultad,Enunciado,Foto) VALUES (4,2,'¿Qué club es conocido por su apodo "El Atleti"?','https://imagenes.20minutos.es/files/image_640_360/uploads/imagenes/2024/03/13/sommer-y-griezmann.jpeg');
insert into Preguntas(IdCategoria,IdDificultad,Enunciado,Foto) VALUES (4,2,'¿Quién fue el máximo goleador de la Liga Española en la temporada 2022-2023?','https://i.pinimg.com/originals/f1/74/64/f17464898f6cdd95c777f632623dff41.jpg');
insert into Preguntas(IdCategoria,IdDificultad,Enunciado,Foto) VALUES (4,2,'¿Qué club italiano ganó la Serie A en la temporada 2022-2023?','https://images.daznservices.com/di/library/DAZN_News/2e/da/sorteggio-calendario-serie-a-tim-2021-2022_1mrzug9um05lr1p8pcyhymwd1p.png?t=-952716806');

insert into Preguntas(IdCategoria,IdDificultad,Enunciado,Foto) VALUES (4,3,'¿Cuál es el récord de puntos en una sola temporada de la Premier League?','https://upload.wikimedia.org/wikipedia/en/thumb/f/f2/Premier_League_Logo.svg/1200px-Premier_League_Logo.svg.png');
insert into Preguntas(IdCategoria,IdDificultad,Enunciado,Foto) VALUES (4,3,'¿Qué jugador tiene el récord de más partidos jugados en la Champions League?','https://editorial.uefa.com/resources/0246-0e98e0aed53b-074f228dc0a2-1000/ucl_branding.jpeg');
insert into Preguntas(IdCategoria,IdDificultad,Enunciado,Foto) VALUES (4,3,'¿Cuál es el único club que ha ganado la Liga de Campeones de la UEFA sin perder un solo partido en la fase de grupos y la fase eliminatoria en una temporada?','https://estaticos-cdn.prensaiberica.es/clip/e6898958-167a-47a1-8b26-83890a0d17d7_alta-libre-aspect-ratio_default_0.jpg');
insert into Preguntas(IdCategoria,IdDificultad,Enunciado,Foto) VALUES (4,3,'¿Qué equipo fue el primero en ganar el triplete (Liga, Copa y Liga de Campeones) en una sola temporada?','https://www.mundodeportivo.com/files/image_449_220/uploads/2017/03/09/60e76b85b02cc.jpeg');
insert into Preguntas(IdCategoria,IdDificultad,Enunciado,Foto) VALUES (4,3,'¿Cuál es el estadio con mayor capacidad en Europa?','https://www.vipealo.com/blog/wp-content/uploads/2022/02/AdobeStock_315861649-1.jpeg');