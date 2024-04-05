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
        protected int[] arrayCorrectas = new int[10];
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
        public int[] ArrayCorrectas
        {
            get { return arrayCorrectas; }
            set { arrayCorrectas = value; }
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
            arrayCorrectas[0] = 0;
            arrayCorrectas[1] = 1;
            arrayCorrectas[2] = 2;
            arrayCorrectas[3] = 2;
            arrayCorrectas[4] = 0;
            arrayCorrectas[5] = 0;
            arrayCorrectas[6] = 1;
            arrayCorrectas[7] = 2;
            arrayCorrectas[8] = 0;
            arrayCorrectas[9] = 2;
        }
        #endregion
    }
}
