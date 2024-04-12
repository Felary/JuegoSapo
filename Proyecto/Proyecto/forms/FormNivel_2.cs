using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Proyecto.control;

namespace Proyecto.forms
{
    public partial class FormNivel_2 : Form
    {
        #region Atributos
        //Inicializacion de las variables para las vidas, puntuacion y contador de preguntas
        int vidas = 3, puntuacion = 0, contPreguntas = 0;
        //Creacion de una instancia de la clase FormMenu
        FormMenu menu;
        //Inicializa los objetos de la clase SoundPlayer
        SoundPlayer grito = new SoundPlayer(@"e:\sonidos\grito.wav");
        //Inicializacion del objeto de la clase Preguntas
        Preguntas nuevasPreguntas;
        #endregion
        public FormNivel_2() //Constructor de la clase FormJuego
        {
            InitializeComponent();
            //se inicializa el objeto de la clase Preguntas
            nuevasPreguntas = new Preguntas();
            //se llena el array de preguntas y opciones
            llenarArrays();
        }
        private void timer_Tick(object sender, EventArgs e) //Método para iniciar el juego
        {
            //Llamar al método para mover las imágenes
            moverImagenes();
            //Llamar al método para verificar las paredes de los monstruos
            paredDerecha(imgCalaveraNegraArriba);
            paredDerecha(imgMonstruoAmarilloArriba);
            paredDerecha(imgFantasmaVerdeArriba);
            paredIzquierda(imgBolitaAzulArriba);
            paredIzquierda(imgMonstruoDinoArriba);
            paredIzquierda(imgMonstruoRosaArriba);
            paredIzquierda(imgMonstruoRosaMedio);
            paredIzquierda(imgCalaveraNegraMedio);
            paredIzquierda(imgMonstruoDinoMedio);
            paredDerecha(imgBolitaAzulMedio);
            paredDerecha(imgMonstruoAmarilloMedio);
            paredDerecha(imgFantasmaVerdeMedio);
            paredDerecha(imgMonstruoAmarilloAbajo);
            paredDerecha(imgBolitaAzulAbajo);
            paredDerecha(imgMonstruoRosaAbajo);
            paredIzquierda(imgMonstruoDinoAbajo);
            paredIzquierda(imgCalaveraNegraAbajo);
            paredIzquierda(imgFantasmaVerdeAbajo);

            //Incrementar la puntuación
            puntuacion++;
            //Mostrar la puntuación en el lblPuntuacion
            txtPuntuacion.Text = "" + puntuacion;
            //Llamar al método para verificar los bordes de la rana
            bodesRafael(imgRafael);
            //Llamar al método para verificar la colisión
            colisionMonstruos();
            //Llamar al método para verificar la colisión con las preguntas
            //colisionPreguntas();
            //Llamar al método para verificar la colisión con las respuestas
            //colisionRespuestas();
            //Llamar al método para finalizar el juego
            finJuego();
            //Se llama al metodo para aumentar la velocidad de los carros
            //velocidadCarros();
        }
        public void moverImagenes() //Método para mover las imágenes
        {
            //Mover las imágenes de arriba de izquierda a derecha
            imgCalaveraNegraArriba.Left = imgCalaveraNegraArriba.Left + 10;
            imgMonstruoAmarilloArriba.Left = imgMonstruoAmarilloArriba.Left + 10;
            imgFantasmaVerdeArriba.Left = imgFantasmaVerdeArriba.Left + 10;
            //Mover las imágenes de arriba de derecha a izquierda
            imgBolitaAzulArriba.Left = imgBolitaAzulArriba.Left - 10;
            imgMonstruoDinoArriba.Left = imgMonstruoDinoArriba.Left - 10;
            imgMonstruoRosaArriba.Left = imgMonstruoRosaArriba.Left - 10;


            //Mover las imágenes de en medio de derecha a izquierda
            imgMonstruoRosaMedio.Left = imgMonstruoRosaMedio.Left - 10;
            imgCalaveraNegraMedio.Left = imgCalaveraNegraMedio.Left - 10;
            imgMonstruoDinoMedio.Left = imgMonstruoDinoMedio.Left - 10;

            //Mover las imágenes de en medio de izquierda a derecha
            imgBolitaAzulMedio.Left = imgBolitaAzulMedio.Left + 10;
            imgMonstruoAmarilloMedio.Left = imgMonstruoAmarilloMedio.Left + 10;
            imgFantasmaVerdeMedio.Left = imgFantasmaVerdeMedio.Left + 10;


            //Mover las imágenes de abajo de izquierda a derecha
            imgMonstruoAmarilloAbajo.Left = imgMonstruoAmarilloAbajo.Left + 10;
            imgBolitaAzulAbajo.Left = imgBolitaAzulAbajo.Left + 10;
            imgMonstruoRosaAbajo.Left = imgMonstruoRosaAbajo.Left + 10;

            //Mover las imágenes de abajo de derecha a izquierda
            imgMonstruoDinoAbajo.Left = imgMonstruoDinoAbajo.Left - 10;
            imgCalaveraNegraAbajo.Left = imgCalaveraNegraAbajo.Left - 10;
            imgFantasmaVerdeAbajo.Left = imgFantasmaVerdeAbajo.Left - 10;
        }
        public void paredDerecha(PictureBox carrito) //funcion para el retorno de los carros de izquierda a derecha
        {
            //si el carro se sale del limite se muestra en el otro extremo
            if (carrito.Location.X > 930)
            {
                //se muestra el carro en el otro extremo
                carrito.Location = new Point(-200, carrito.Location.Y);
            }
        }
        public void paredIzquierda(PictureBox carrito) //funcion para el retorno de los carros de derecha a izquierda
        {
            //si el carro se sale del limite se muestra en el otro extremo
            if (carrito.Location.X < -200)
            {
                //se muestra el carro en el otro extremo
                carrito.Location = new Point(930, carrito.Location.Y);
            }
        }
        public void bodesRafael(PictureBox ranita) //funcion para impedir que la rana se salga de la pantalla
        {
            //si la rana llega al limite inferior no puede continuar
            if (ranita.Location.Y > 600)
            {
                //la rana no puede moverse mas hacia abajo
                ranita.Location = new Point(ranita.Location.X, 600);
            }

            //si la rana llega al limite izquierdo no puede continuar
            if (ranita.Location.X < 0)
            {
                //la rana no puede moverse mas hacia la izquierda
                ranita.Location = new Point(0, ranita.Location.Y);
            }
            //si la rana llega al limite derecho no puede continuar
            if (ranita.Location.X > 910)
            {
                //la rana no puede moverse mas hacia la derecha
                ranita.Location = new Point(910, ranita.Location.Y);
            }
            //si la rana llega al limite superior no puede continuar
            if (ranita.Location.Y < 227)
            {
                //la rana no puede moverse mas hacia arriba
                ranita.Location = new Point(ranita.Location.X, 227);
            }
        }
        public void colisionMonstruos() //Metodo para la colision de la rana con los carros
        {
            //si la rafael colisiona con un monstruo se muestra la imagen de la muerte y se quita una vida
            if (imgRafael.Bounds.IntersectsWith(imgCalaveraNegraArriba.Bounds))
            {
                //se muestra la imagen de la rana aplastada
                imgRafael.Image = Proyecto.Properties.Resources.muerte;

                //llamado a la funcion quitarVidas
                quitarVidas();

                //suena el grito
                grito.Play();

                //si las vidas son mayores a 0 la rana vuelve a la posicion original
                if (vidas > 0)
                {
                    //la rana vuelve a la posicion original
                    imgRafael.Location = new Point(600, 599);
                }
                else     //si las vidas son iguales a 0 se detiene el tiempo, suena el grito y se muestra la imagen de GAMEOVER
                {
                    //se detiene el tiempo
                    timer.Stop();
                }
            }
            //si la rafael colisiona con un monstruo se muestra la imagen de la muerte y se quita una vida
            else if (imgRafael.Bounds.IntersectsWith(imgFantasmaVerdeArriba.Bounds))
            {
                //se muestra la imagen de la rana aplastada
                imgRafael.Image = Proyecto.Properties.Resources.muerte;

                //llamado a la funcion quitarVidas
                quitarVidas();

                //suena el grito
                grito.Play();

                //si las vidas son mayores a 0 la rana vuelve a la posicion original
                if (vidas > 0)
                {
                    //la rana vuelve a la posicion original
                    imgRafael.Location = new Point(600, 599);
                }
                else     //si las vidas son iguales a 0 se detiene el tiempo, suena el grito y se muestra la imagen de GAMEOVER
                {
                    //se detiene el tiempo
                    timer.Stop();
                }
            }
            //si la rafael colisiona con un monstruo se muestra la imagen de la muerte y se quita una vida
            else if (imgRafael.Bounds.IntersectsWith(imgMonstruoAmarilloArriba.Bounds))
            {
                //se muestra la imagen de la rana aplastada
                imgRafael.Image = Proyecto.Properties.Resources.muerte;

                //llamado a la funcion quitarVidas
                quitarVidas();

                //suena el grito
                grito.Play();

                //si las vidas son mayores a 0 la rana vuelve a la posicion original
                if (vidas > 0)
                {
                    //la rana vuelve a la posicion original
                    imgRafael.Location = new Point(600, 599);
                }
                else     //si las vidas son iguales a 0 se detiene el tiempo, suena el grito y se muestra la imagen de GAMEOVER
                {
                    //se detiene el tiempo
                    timer.Stop();
                }
            }
            //si la rafael colisiona con un monstruo se muestra la imagen de la muerte y se quita una vida
            else if (imgRafael.Bounds.IntersectsWith(imgBolitaAzulArriba.Bounds))
            {
                //se muestra la imagen de la rana aplastada
                imgRafael.Image = Proyecto.Properties.Resources.muerte;

                //llamado a la funcion quitarVidas
                quitarVidas();

                //suena el grito
                grito.Play();

                //si las vidas son mayores a 0 la rana vuelve a la posicion original
                if (vidas > 0)
                {
                    //la rana vuelve a la posicion original
                    imgRafael.Location = new Point(600, 599);
                }
                else     //si las vidas son iguales a 0 se detiene el tiempo, suena el grito y se muestra la imagen de GAMEOVER
                {
                    //se detiene el tiempo
                    timer.Stop();
                }
            }
            //si la rafael colisiona con un monstruo se muestra la imagen de la muerte y se quita una vida
            else if (imgRafael.Bounds.IntersectsWith(imgMonstruoDinoArriba.Bounds))
            {
                //se muestra la imagen de la rana aplastada
                imgRafael.Image = Proyecto.Properties.Resources.muerte;

                //llamado a la funcion quitarVidas
                quitarVidas();

                //suena el grito
                grito.Play();

                //si las vidas son mayores a 0 la rana vuelve a la posicion original
                if (vidas > 0)
                {
                    //la rana vuelve a la posicion original
                    imgRafael.Location = new Point(600, 599);
                }
                else     //si las vidas son iguales a 0 se detiene el tiempo, suena el grito y se muestra la imagen de GAMEOVER
                {
                    //se detiene el tiempo
                    timer.Stop();
                }
            }
            //si la rafael colisiona con un monstruo se muestra la imagen de la muerte y se quita una vida
            else if (imgRafael.Bounds.IntersectsWith(imgMonstruoRosaArriba.Bounds))
            {
                //se muestra la imagen de la rana aplastada
                imgRafael.Image = Proyecto.Properties.Resources.muerte;

                //llamado a la funcion quitarVidas
                quitarVidas();

                //suena el grito
                grito.Play();

                //si las vidas son mayores a 0 la rana vuelve a la posicion original
                if (vidas > 0)
                {
                    //la rana vuelve a la posicion original
                    imgRafael.Location = new Point(600, 599);
                }
                else     //si las vidas son iguales a 0 se detiene el tiempo, suena el grito y se muestra la imagen de GAMEOVER
                {
                    //se detiene el tiempo
                    timer.Stop();
                }
            }


            //si la rafael colisiona con un monstruo se muestra la imagen de la muerte y se quita una vida
            else if (imgRafael.Bounds.IntersectsWith(imgCalaveraNegraMedio.Bounds))
            {
                //se muestra la imagen de la rana aplastada
                imgRafael.Image = Proyecto.Properties.Resources.muerte;

                //llamado a la funcion quitarVidas
                quitarVidas();

                //suena el grito
                grito.Play();

                //si las vidas son mayores a 0 la rana vuelve a la posicion original
                if (vidas > 0)
                {
                    //la rana vuelve a la posicion original
                    imgRafael.Location = new Point(600, 599);
                }
                else     //si las vidas son iguales a 0 se detiene el tiempo, suena el grito y se muestra la imagen de GAMEOVER
                {
                    //se detiene el tiempo
                    timer.Stop();
                }
            }
            //si la rafael colisiona con un monstruo se muestra la imagen de la muerte y se quita una vida
            else if (imgRafael.Bounds.IntersectsWith(imgFantasmaVerdeMedio.Bounds))
            {
                //se muestra la imagen de la rana aplastada
                imgRafael.Image = Proyecto.Properties.Resources.muerte;

                //llamado a la funcion quitarVidas
                quitarVidas();

                //suena el grito
                grito.Play();

                //si las vidas son mayores a 0 la rana vuelve a la posicion original
                if (vidas > 0)
                {
                    //la rana vuelve a la posicion original
                    imgRafael.Location = new Point(600, 599);
                }
                else     //si las vidas son iguales a 0 se detiene el tiempo, suena el grito y se muestra la imagen de GAMEOVER
                {
                    //se detiene el tiempo
                    timer.Stop();
                }
            }
            //si la rafael colisiona con un monstruo se muestra la imagen de la muerte y se quita una vida
            else if (imgRafael.Bounds.IntersectsWith(imgMonstruoAmarilloMedio.Bounds))
            {
                //se muestra la imagen de la rana aplastada
                imgRafael.Image = Proyecto.Properties.Resources.muerte;

                //llamado a la funcion quitarVidas
                quitarVidas();

                //suena el grito
                grito.Play();

                //si las vidas son mayores a 0 la rana vuelve a la posicion original
                if (vidas > 0)
                {
                    //la rana vuelve a la posicion original
                    imgRafael.Location = new Point(600, 599);
                }
                else     //si las vidas son iguales a 0 se detiene el tiempo, suena el grito y se muestra la imagen de GAMEOVER
                {
                    //se detiene el tiempo
                    timer.Stop();
                }
            }
            //si la rafael colisiona con un monstruo se muestra la imagen de la muerte y se quita una vida
            else if (imgRafael.Bounds.IntersectsWith(imgBolitaAzulMedio.Bounds))
            {
                //se muestra la imagen de la rana aplastada
                imgRafael.Image = Proyecto.Properties.Resources.muerte;

                //llamado a la funcion quitarVidas
                quitarVidas();

                //suena el grito
                grito.Play();

                //si las vidas son mayores a 0 la rana vuelve a la posicion original
                if (vidas > 0)
                {
                    //la rana vuelve a la posicion original
                    imgRafael.Location = new Point(600, 599);
                }
                else     //si las vidas son iguales a 0 se detiene el tiempo, suena el grito y se muestra la imagen de GAMEOVER
                {
                    //se detiene el tiempo
                    timer.Stop();
                }
            }
            //si la rafael colisiona con un monstruo se muestra la imagen de la muerte y se quita una vida
            else if (imgRafael.Bounds.IntersectsWith(imgMonstruoDinoMedio.Bounds))
            {
                //se muestra la imagen de la rana aplastada
                imgRafael.Image = Proyecto.Properties.Resources.muerte;

                //llamado a la funcion quitarVidas
                quitarVidas();

                //suena el grito
                grito.Play();

                //si las vidas son mayores a 0 la rana vuelve a la posicion original
                if (vidas > 0)
                {
                    //la rana vuelve a la posicion original
                    imgRafael.Location = new Point(600, 599);
                }
                else     //si las vidas son iguales a 0 se detiene el tiempo, suena el grito y se muestra la imagen de GAMEOVER
                {
                    //se detiene el tiempo
                    timer.Stop();
                }
            }
            //si la rafael colisiona con un monstruo se muestra la imagen de la muerte y se quita una vida
            else if (imgRafael.Bounds.IntersectsWith(imgMonstruoRosaMedio.Bounds))
            {
                //se muestra la imagen de la rana aplastada
                imgRafael.Image = Proyecto.Properties.Resources.muerte;

                //llamado a la funcion quitarVidas
                quitarVidas();

                //suena el grito
                grito.Play();

                //si las vidas son mayores a 0 la rana vuelve a la posicion original
                if (vidas > 0)
                {
                    //la rana vuelve a la posicion original
                    imgRafael.Location = new Point(600, 599);
                }
                else     //si las vidas son iguales a 0 se detiene el tiempo, suena el grito y se muestra la imagen de GAMEOVER
                {
                    //se detiene el tiempo
                    timer.Stop();
                }
            }

            //si la rafael colisiona con un monstruo se muestra la imagen de la muerte y se quita una vida
            else if (imgRafael.Bounds.IntersectsWith(imgCalaveraNegraAbajo.Bounds))
            {
                //se muestra la imagen de la rana aplastada
                imgRafael.Image = Proyecto.Properties.Resources.muerte;

                //llamado a la funcion quitarVidas
                quitarVidas();

                //suena el grito
                grito.Play();

                //si las vidas son mayores a 0 la rana vuelve a la posicion original
                if (vidas > 0)
                {
                    //la rana vuelve a la posicion original
                    imgRafael.Location = new Point(600, 599);
                }
                else     //si las vidas son iguales a 0 se detiene el tiempo, suena el grito y se muestra la imagen de GAMEOVER
                {
                    //se detiene el tiempo
                    timer.Stop();
                }
            }
            //si la rafael colisiona con un monstruo se muestra la imagen de la muerte y se quita una vida
            else if (imgRafael.Bounds.IntersectsWith(imgFantasmaVerdeAbajo.Bounds))
            {
                //se muestra la imagen de la rana aplastada
                imgRafael.Image = Proyecto.Properties.Resources.muerte;

                //llamado a la funcion quitarVidas
                quitarVidas();

                //suena el grito
                grito.Play();

                //si las vidas son mayores a 0 la rana vuelve a la posicion original
                if (vidas > 0)
                {
                    //la rana vuelve a la posicion original
                    imgRafael.Location = new Point(600, 599);
                }
                else     //si las vidas son iguales a 0 se detiene el tiempo, suena el grito y se muestra la imagen de GAMEOVER
                {
                    //se detiene el tiempo
                    timer.Stop();
                }
            }
            //si la rafael colisiona con un monstruo se muestra la imagen de la muerte y se quita una vida
            else if (imgRafael.Bounds.IntersectsWith(imgMonstruoAmarilloAbajo.Bounds))
            {
                //se muestra la imagen de la rana aplastada
                imgRafael.Image = Proyecto.Properties.Resources.muerte;

                //llamado a la funcion quitarVidas
                quitarVidas();

                //suena el grito
                grito.Play();

                //si las vidas son mayores a 0 la rana vuelve a la posicion original
                if (vidas > 0)
                {
                    //la rana vuelve a la posicion original
                    imgRafael.Location = new Point(600, 599);
                }
                else     //si las vidas son iguales a 0 se detiene el tiempo, suena el grito y se muestra la imagen de GAMEOVER
                {
                    //se detiene el tiempo
                    timer.Stop();
                }
            }
            //si la rafael colisiona con un monstruo se muestra la imagen de la muerte y se quita una vida
            else if (imgRafael.Bounds.IntersectsWith(imgBolitaAzulAbajo.Bounds))
            {
                //se muestra la imagen de la rana aplastada
                imgRafael.Image = Proyecto.Properties.Resources.muerte;

                //llamado a la funcion quitarVidas
                quitarVidas();

                //suena el grito
                grito.Play();

                //si las vidas son mayores a 0 la rana vuelve a la posicion original
                if (vidas > 0)
                {
                    //la rana vuelve a la posicion original
                    imgRafael.Location = new Point(600, 599);
                }
                else     //si las vidas son iguales a 0 se detiene el tiempo, suena el grito y se muestra la imagen de GAMEOVER
                {
                    //se detiene el tiempo
                    timer.Stop();
                }
            }
            //si la rafael colisiona con un monstruo se muestra la imagen de la muerte y se quita una vida
            else if (imgRafael.Bounds.IntersectsWith(imgMonstruoDinoAbajo.Bounds))
            {
                //se muestra la imagen de la rana aplastada
                imgRafael.Image = Proyecto.Properties.Resources.muerte;

                //llamado a la funcion quitarVidas
                quitarVidas();

                //suena el grito
                grito.Play();

                //si las vidas son mayores a 0 la rana vuelve a la posicion original
                if (vidas > 0)
                {
                    //la rana vuelve a la posicion original
                    imgRafael.Location = new Point(600, 599);
                }
                else     //si las vidas son iguales a 0 se detiene el tiempo, suena el grito y se muestra la imagen de GAMEOVER
                {
                    //se detiene el tiempo
                    timer.Stop();
                }
            }
            //si la rafael colisiona con un monstruo se muestra la imagen de la muerte y se quita una vida
            else if (imgRafael.Bounds.IntersectsWith(imgMonstruoRosaAbajo.Bounds))
            {
                //se muestra la imagen de la rana aplastada
                imgRafael.Image = Proyecto.Properties.Resources.muerte;

                //llamado a la funcion quitarVidas
                quitarVidas();

                //suena el grito
                grito.Play();

                //si las vidas son mayores a 0 la rana vuelve a la posicion original
                if (vidas > 0)
                {
                    //la rana vuelve a la posicion original
                    imgRafael.Location = new Point(600, 599);
                }
                else     //si las vidas son iguales a 0 se detiene el tiempo, suena el grito y se muestra la imagen de GAMEOVER
                {
                    //se detiene el tiempo
                    timer.Stop();
                }
            }
        }
        public void colisionPreguntas() //Metodo para la colision de la rana con las preguntas
        {
            if (imgRafael.Bounds.IntersectsWith(imgPregunta.Bounds))
            {
                //Se oculta la imagen de la pregunta y la flecha
                imgPregunta.Visible = false;
                imgFlecha.Visible = false;

                //Se mueve de lugar la imgPregunta para que no colisione con la rana
                imgPregunta.Location = new Point(3, 12);

                //Se muestra el lblPregunta y las opciones de respuesta
                lblPregunta.Visible = true;
                txtRespuesta_1.Visible = true;
                txtRespuesta_2.Visible = true;
                txtRespuesta_3.Visible = true;

                //Se actualiza la pregunta en el lblPregunta
                lblPregunta.Text = nuevasPreguntas.ArrayPreguntas[contPreguntas];

                //Se actualiza las opciones de respuesta en los lblRespuesta_1, lblRespuesta_2 y lblRespuesta_3
                txtRespuesta_1.Text = nuevasPreguntas.ArrayOpciones[contPreguntas, 0];
                txtRespuesta_2.Text = nuevasPreguntas.ArrayOpciones[contPreguntas, 1];
                txtRespuesta_3.Text = nuevasPreguntas.ArrayOpciones[contPreguntas, 2];

            }
        }
        public void colisionRespuestas() //Metodo para la colision de la rana con las respuestas
        {
            //Si la rana coliciona con el lblrespuesta_1 
            if (imgRafael.Bounds.IntersectsWith(txtRespuesta_1.Bounds))
            {
                //Se valida si la respuesta es correcta con el array de respuestas correctas
                if (txtRespuesta_1.Text.Equals(nuevasPreguntas.ArrayCorrectas[contPreguntas]))
                {
                    //se incrementa la puntuacion
                    puntuacion += 100;
                    //se muestra la puntuacion en el lblPuntuacion
                    txtPuntuacion.Text = "" + puntuacion;

                    //se muestra la imagen de la rana en la posicion original
                    imgRafael.Location = new Point(600, 599);
                    //se oculta el lblPregunta y las opciones de respuesta
                    lblPregunta.Visible = false;
                    txtRespuesta_1.Visible = false;
                    txtRespuesta_2.Visible = false;
                    txtRespuesta_3.Visible = false;
                    //se muestra la imagen de la pregunta y la flecha
                    imgPregunta.Visible = true;
                    imgFlecha.Visible = true;
                    //Se aumenta el progressbar en un 10%
                    progressBar.Value += 10;
                    //Se reubica la imgPregunta a su posicion original
                    imgPregunta.Location = new Point(212, 599);
                    //Se incrementa el contador de preguntas
                    contPreguntas++;
                }
                //Si la respuesta es incorrecta se resta puntuacion
                else
                {
                    //se decrementa la puntuacion
                    puntuacion -= 100;
                    //se muestra la puntuacion en el lblPuntuacion
                    txtPuntuacion.Text = "" + puntuacion;
                    //se muestra la imagen de la rana en la posicion original
                    imgRafael.Location = new Point(600, 599);
                }

            }
            //Si la rana coliciona con el lblrespuesta_2
            if (imgRafael.Bounds.IntersectsWith(txtRespuesta_2.Bounds))
            {

                //Se valida si la respuesta es correcta con el array de respuestas correctas
                if (txtRespuesta_2.Text.Equals(nuevasPreguntas.ArrayCorrectas[contPreguntas]))
                {
                    //se incrementa la puntuacion
                    puntuacion += 100;
                    //se muestra la puntuacion en el lblPuntuacion
                    txtPuntuacion.Text = "" + puntuacion;

                    //se muestra la imagen de la rana en la posicion original
                    imgRafael.Location = new Point(600, 599);
                    //se oculta el lblPregunta y las opciones de respuesta
                    lblPregunta.Visible = false;
                    txtRespuesta_1.Visible = false;
                    txtRespuesta_2.Visible = false;
                    txtRespuesta_3.Visible = false;
                    //se muestra la imagen de la pregunta y la flecha
                    imgPregunta.Visible = true;
                    imgFlecha.Visible = true;
                    //Se aumenta el progressbar en un 10%
                    progressBar.Value += 10;
                    //Se reubica la imgPregunta a su posicion original
                    imgPregunta.Location = new Point(212, 599);
                    //Se incrementa el contador de preguntas
                    contPreguntas++;
                }
                //Si la respuesta es incorrecta se resta puntuacion
                else
                {
                    //se decrementa la puntuacion
                    puntuacion -= 100;
                    //se muestra la puntuacion en el lblPuntuacion
                    txtPuntuacion.Text = "" + puntuacion;
                    //se muestra la imagen de la rana en la posicion original
                    imgRafael.Location = new Point(600, 599);
                }

            }
            //Si la rana coliciona con el lblrespuesta_3
            if (imgRafael.Bounds.IntersectsWith(txtRespuesta_3.Bounds))
            {
                //Se valida si la respuesta es correcta con el array de respuestas correctas
                if (txtRespuesta_3.Text.Equals(nuevasPreguntas.ArrayCorrectas[contPreguntas]))
                {
                    //se incrementa la puntuacion
                    puntuacion += 100;
                    //se muestra la puntuacion en el lblPuntuacion
                    txtPuntuacion.Text = "" + puntuacion;

                    //se muestra la imagen de la rana en la posicion original
                    imgRafael.Location = new Point(600, 599);
                    //se oculta el lblPregunta y las opciones de respuesta
                    lblPregunta.Visible = false;
                    txtRespuesta_1.Visible = false;
                    txtRespuesta_2.Visible = false;
                    txtRespuesta_3.Visible = false;
                    //se muestra la imagen de la pregunta y la flecha
                    imgPregunta.Visible = true;
                    imgFlecha.Visible = true;
                    //Se aumenta el progressbar en un 10%
                    progressBar.Value += 10;
                    //Se reubica la imgPregunta a su posicion original
                    imgPregunta.Location = new Point(212, 599);
                    //Se incrementa el contador de preguntas
                    contPreguntas++;
                }
                //Si la respuesta es incorrecta se resta puntuacion
                else
                {
                    //se decrementa la puntuacion
                    puntuacion -= 100;
                    //se muestra la puntuacion en el lblPuntuacion
                    txtPuntuacion.Text = "" + puntuacion;
                    //se muestra la imagen de la rana en la posicion original
                    imgRafael.Location = new Point(600, 599);
                }
            }
        }
        public void quitarVidas() //Metodo para quitar vidas
        {
            //se muestra la imagen de la rana aplastada dependiendo de la cantidad de vidas que le queden
            switch (vidas)
            {
                case 1:
                    //se muestra la imagen de la rana aplastada en el picturebox
                    imgCorazon_3.Image = Proyecto.Properties.Resources.muerte;
                    break;
                case 2:
                    imgCorazon_2.Image = Proyecto.Properties.Resources.muerte;
                    break;
                case 3:
                    imgCorazon_1.Image = Proyecto.Properties.Resources.muerte;
                    break;
            }
            //se decrementa la cantidad de vidas
            vidas--;
        }
        private void FormJuego_KeyDown(object sender, KeyEventArgs e) //Funcion para mover la rana
        {

            //se mueve la rana a la derecha
            if (e.KeyCode == Keys.D)
            {
                //se incrementa la posicion de la rana en el eje X
                imgRafael.Left += 10;

                //se muestra la imagen de la rana mirando a la derecha
                imgRafael.Image = Proyecto.Properties.Resources.rafaelDerecha;
            }
            //se mueve la rana a la izquierda
            if (e.KeyCode == Keys.A)
            {
                //se decrementa la posicion de la rana en el eje X
                imgRafael.Left -= 10;

                //se muestra la imagen de la rana mirando a la izquierda
                imgRafael.Image = Proyecto.Properties.Resources.rafaelIzquierda;
            }
            //se mueve la rana hacia arriba
            if (e.KeyCode == Keys.W)
            {
                //se decrementa la posicion de la rana en el eje Y
                imgRafael.Top -= 10;

                //se muestra la imagen de la rana mirando hacia arriba
                imgRafael.Image = Proyecto.Properties.Resources.rafaelFrente;
            }
            //se mueve la rana hacia abajo
            if (e.KeyCode == Keys.S)
            {
                //se incrementa la posicion de la rana en el eje Y
                imgRafael.Top += 10;

                //se muestra la imagen de la rana mirando hacia abajo
                imgRafael.Image = Proyecto.Properties.Resources.rafaelAtras;
            }
        }
        public void llenarArrays() //Metodo para llenar los arrays de preguntas y opciones
        {
            //Llenar el array de preguntas
            nuevasPreguntas.llenarArrayPreguntas();
            //Llenar el array de opciones
            nuevasPreguntas.llenarArrayOpciones();
            //Llenar el array de respuestas correctas
            nuevasPreguntas.llenarArrayCorrectas();
        }
        private void finJuego() //Metodo para finalizar el juego
        {
            //Si las vidas son iguales a 0 Se mostrara la ventana formMenu
            if (vidas == 0)
            {
                //Detiene el timer
                timer.Stop();
                //Creacion de una instancia de la clase FormMenu
                menu = new FormMenu();
                //Muestra el formMenu
                menu.Show();
                //Cierra el formJuego
                this.Close();
                //Muestra un cuadro de dialogo donde le pregunta al usuario si desea reinicar el juego y muestra la puntuacion
                MessageBox.Show("GAME OVER\nPuntuación: " + puntuacion, "GAME OVER", MessageBoxButtons.OK);

                //utiliza el return para salir del metodo
                return;
            }
            //Si el contador de preguntas es igual a 10
            if (contPreguntas == 10)
            {
                //Detiene el timer
                timer.Stop();
                //Creacion de una instancia de la clase FormMenu
                menu = new FormMenu();
                //Muestra el formMenu
                menu.Show();
                //Cierra el formJuego
                this.Close();
                //Muestra un cuadro de dialogo donde se felicita al usuario por haber ganado y muestra la puntuacion
                MessageBox.Show("¡Felicidades! Has ganado\nPuntuación: " + puntuacion, "¡Felicidades!", MessageBoxButtons.OK);
                //utiliza el return para salir del metodo
                return;
            }
            /*
            //Si las vidas son iguales a 0 Se mostrara el formMenu
            if (vidas == 0)
            {
                //Muestra un cuadro de dialogo donde le pregunta al usuario si desea reinicar el juego y muestra la puntuacion
                DialogResult dialogResult = MessageBox.Show("¿Desea reiniciar el juego? Puntuación: " + puntuacion, "GAME OVER", MessageBoxButtons.YesNo);
                //Si el usuario presiona el boton de si
                if (dialogResult == DialogResult.Yes)
                {
                    //Se reinicia el juego
                    reiniciarJuego();
                }
                //Si el usuario presiona el boton de no
                else if (dialogResult == DialogResult.No)
                {
                    Application.Exit();
                }
            }*/
        }
        private void velocidadCarros() //Metodo para aumentar la velocidad de los carros segun el numero de la pregunta
        {


        }
    }
}
