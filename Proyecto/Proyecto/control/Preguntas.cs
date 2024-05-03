using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto.control
{
    internal class Preguntas
    {
        #region Atributos
        protected string[] arrayPreguntas = new string[10];
        protected string[,] arrayOpciones = new string[10, 3];
        protected string[] arrayCorrectas = new string[10];

        protected string[] arrayPreguntasNivel2 = new string[10];
        protected string[,] arrayOpcionesNivel2 = new string[10, 3];
        protected string[] arrayCorrectasNivel2 = new string[10];
        #endregion

        #region Constructor
        #endregion

        #region Metodos y Funciones
        public string[] ArrayPreguntas
        {
            get { return arrayPreguntas; }
            set { arrayPreguntas = value; }
        }
        public string[,] ArrayOpciones
        {
            get { return arrayOpciones; }
            set { arrayOpciones = value; }
        }
        public string[] ArrayCorrectas
        {
            get { return arrayCorrectas; }
            set { arrayCorrectas = value; }
        }
        public string[] ArrayPreguntasNivel2
        {
            get { return arrayPreguntasNivel2; }
            set { arrayPreguntasNivel2 = value; }
        }
        public string[,] ArrayOpcionesNivel2
        {
            get { return arrayOpcionesNivel2; }
            set { arrayOpcionesNivel2 = value; }
        }
        public string[] ArrayCorrectasNivel2
        {
            get { return arrayCorrectasNivel2; }
            set { arrayCorrectasNivel2 = value; }
        }

        public void llenarArrayPreguntas() //Metodo para llenar el array de preguntas
        {
            arrayPreguntas[0] = "¿Cuál es la capital de Francia?";
            arrayPreguntas[1] = "¿Cuál es la capital de España?";
            arrayPreguntas[2] = "¿Cuál es la capital de Alemania?";
            arrayPreguntas[3] = "¿Cuál es la capital de Italia?";
            arrayPreguntas[4] = "¿Cuál es la capital de Inglaterra?";
            arrayPreguntas[5] = "¿Cuál es la capital de Rusia?";
            arrayPreguntas[6] = "¿Cuál es la capital de China?";
            arrayPreguntas[7] = "¿Cuál es la capital de Japón?";
            arrayPreguntas[8] = "¿Cuál es la capital de Australia?";
            arrayPreguntas[9] = "¿Cuál es la capital de Argentina?";
        }
        public void llenarArrayOpciones() //Metodo para llenar el array de opciones
        {
            arrayOpciones[0, 0] = "Paris";
            arrayOpciones[0, 1] = "Londres";
            arrayOpciones[0, 2] = "Berlin";

            arrayOpciones[1, 0] = "Paris";
            arrayOpciones[1, 1] = "Madrid";
            arrayOpciones[1, 2] = "Lisboa";

            arrayOpciones[2, 0] = "Hamburgo";
            arrayOpciones[2, 1] = "Munich";
            arrayOpciones[2, 2] = "Berlin";

            arrayOpciones[3, 0] = "Venecia";
            arrayOpciones[3, 1] = "Milan";
            arrayOpciones[3, 2] = "Roma";

            arrayOpciones[4, 0] = "Londres";
            arrayOpciones[4, 1] = "Liverpool";
            arrayOpciones[4, 2] = "Manchester";

            arrayOpciones[5, 0] = "Moscu";
            arrayOpciones[5, 1] = "San Petersburgo";
            arrayOpciones[5, 2] = "Kazan";

            arrayOpciones[6, 0] = "Shanghai";
            arrayOpciones[6, 1] = "Pekin";
            arrayOpciones[6, 2] = "Hong Kong";

            arrayOpciones[7, 0] = "Kioto";
            arrayOpciones[7, 1] = "Osaka";
            arrayOpciones[7, 2] = "Tokio";

            arrayOpciones[8, 0] = "Canberra";
            arrayOpciones[8, 1] = "Sidney";
            arrayOpciones[8, 2] = "Melbourne";

            arrayOpciones[9, 0] = "Rosario";
            arrayOpciones[9, 1] = "Cordoba";
            arrayOpciones[9, 2] = "Buenos Aires";
        }
        public void llenarArrayCorrectas() //Metodo para llenar el array de correctas
        {
            arrayCorrectas[0] = "Paris";
            arrayCorrectas[1] = "Madrid";
            arrayCorrectas[2] = "Berlin";
            arrayCorrectas[3] = "Roma";
            arrayCorrectas[4] = "Londres";
            arrayCorrectas[5] = "Moscu";
            arrayCorrectas[6] = "Pekin";
            arrayCorrectas[7] = "Tokio";
            arrayCorrectas[8] = "Canberra";
            arrayCorrectas[9] = "Buenos Aires";
        }

        public void llenarArrayPreguntasNivel2() //Metodo para llenar el array de preguntas en ingles de colores
        {
            arrayPreguntasNivel2[0] = "What color is the blue?";
            arrayPreguntasNivel2[1] = "What color is the green?";
            arrayPreguntasNivel2[2] = "What color is the red?";
            arrayPreguntasNivel2[3] = "What color is the black?";
            arrayPreguntasNivel2[4] = "What color is the purple?";
            arrayPreguntasNivel2[5] = "What color is the white?";
            arrayPreguntasNivel2[6] = "What color is the orange?";
            arrayPreguntasNivel2[7] = "What color is the yellow?";
            arrayPreguntasNivel2[8] = "What color is the pink?";
            arrayPreguntasNivel2[9] = "What color is the brown?";
        }
        public void llenarArrayOpcionesNivel2() //Metodo para llenar el array con la opciones al azar
        {
            arrayOpcionesNivel2[0, 0] = "Azul";
            arrayOpcionesNivel2[0, 1] = "Verde";
            arrayOpcionesNivel2[0, 2] = "Rojo";

            arrayOpcionesNivel2[1, 0] = "Morado";
            arrayOpcionesNivel2[1, 1] = "Blanco";
            arrayOpcionesNivel2[1, 2] = "Verde";

            arrayOpcionesNivel2[2, 0] = "Negro";
            arrayOpcionesNivel2[2, 1] = "Naranja";
            arrayOpcionesNivel2[2, 2] = "Rojo";

            arrayOpcionesNivel2[3, 0] = "Negro";
            arrayOpcionesNivel2[3, 1] = "Verde";
            arrayOpcionesNivel2[3, 2] = "Rojo";

            arrayOpcionesNivel2[4, 0] = "Cafe";
            arrayOpcionesNivel2[4, 1] = "Morado";
            arrayOpcionesNivel2[4, 2] = "Rosado";

            arrayOpcionesNivel2[5, 0] = "Azul";
            arrayOpcionesNivel2[5, 1] = "Verde";
            arrayOpcionesNivel2[5, 2] = "Blanco";

            arrayOpcionesNivel2[6, 0] = "Rojo";
            arrayOpcionesNivel2[6, 1] = "Naranja";
            arrayOpcionesNivel2[6, 2] = "Amarillo";

            arrayOpcionesNivel2[7, 0] = "Cafe";
            arrayOpcionesNivel2[7, 1] = "Amarillo";
            arrayOpcionesNivel2[7, 2] = "Verde";

            arrayOpcionesNivel2[8, 0] = "Rosado";
            arrayOpcionesNivel2[8, 1] = "Verde";
            arrayOpcionesNivel2[8, 2] = "Blanco";

            arrayOpcionesNivel2[9, 0] = "Cafe";
            arrayOpcionesNivel2[9, 1] = "Verde";
            arrayOpcionesNivel2[9, 2] = "Negro";
        }
        public void llenarArrayCorrectasNivel2() //Metodo para llenar el array de correctas
        {
            arrayCorrectasNivel2[0] = "Azul";
            arrayCorrectasNivel2[1] = "Verde";
            arrayCorrectasNivel2[2] = "Rojo";
            arrayCorrectasNivel2[3] = "Negro";
            arrayCorrectasNivel2[4] = "Morado";
            arrayCorrectasNivel2[5] = "Blanco";
            arrayCorrectasNivel2[6] = "Naranja";
            arrayCorrectasNivel2[7] = "Amarillo";
            arrayCorrectasNivel2[8] = "Rosado";
            arrayCorrectasNivel2[9] = "Cafe";
        }

        #endregion
    }
}
