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
    public partial class FormJuego : Form
    {
        #region Atributos
        //Inicializacion de las variables para las vidas, puntuacion y contador de preguntas
        int vidas = 3, puntuacion = 0, contPreguntas = 0;




        SoundPlayer freno = new SoundPlayer("\\Resources\\freno.wav");
        //Inicializacion del objeto de la clase Preguntas
        Preguntas nuevasPreguntas;
        #endregion
        public FormJuego()
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
            //Llamar al método para verificar las paredes
            paredDerecha(imgFerraryArriba);
            paredDerecha(imgLamboArriba);
            paredDerecha(imgTaxiArriba);
            paredIzquierda(imgCisternaArriba);
            paredIzquierda(imgRetroArriba);
            paredDerecha(imgFerraryAbajo);
            paredDerecha(imgTaxiAbajo);
            paredIzquierda(imgBusAbajo);
            //Incrementar la puntuación
            puntuacion++;
            //Mostrar la puntuación en el lblPuntuacion
            txtPuntuacion.Text = "" + puntuacion;
            //Llamar al método para verificar los bordes de la rana
            bordesRana(imgRana);
            //Llamar al método para verificar la colisión
            colisionCarros();
            //Llamar al método para verificar la colisión con las preguntas
            colisionPreguntas();
            //Llamar al método para verificar la colisión con las respuestas
            colisionRespuestas();
            //Llamar al método para finalizar el juego
            finJuego();
        }
        public void moverImagenes() //Método para mover las imágenes
        {
            //Mover las imágenes de arriba de izquierda a derecha
            imgLamboArriba.Left = imgLamboArriba.Left + 10;
            imgFerraryArriba.Left = imgFerraryArriba.Left + 10;
            imgTaxiArriba.Left = imgTaxiArriba.Left + 10;
            //Mover las imágenes de arriba de derecha a izquierda
            imgCisternaArriba.Left = imgCisternaArriba.Left - 10;
            imgRetroArriba.Left = imgRetroArriba.Left - 10;
            //Mover las imágenes de abajo de izquierda a derecha
            imgFerraryAbajo.Left = imgFerraryAbajo.Left + 10;
            imgTaxiAbajo.Left = imgTaxiAbajo.Left + 10;
            //Mover las imágenes de abajo de derecha a izquierda
            imgBusAbajo.Left = imgBusAbajo.Left - 10;
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
        public void bordesRana(PictureBox ranita) //funcion para impedir que la rana se salga de la pantalla
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
        public void colisionCarros() //Metodo para la colision de la rana con los carros
        {
            //si la rana colisiona con un carro se muestra la imagen de la rana aplastada y se quita una vida
            if (imgRana.Bounds.IntersectsWith(imgFerraryArriba.Bounds))
            {
                //se muestra la imagen de la rana aplastada
                imgRana.Image = Proyecto.Properties.Resources.ranaAplastada;

                //llamado a la funcion quitarVidas
                quitarVidas();

                //suena el freno
                freno.Play();

                //si las vidas son mayores a 0 la rana vuelve a la posicion original
                if (vidas > 0)
                {
                    //la rana vuelve a la posicion original
                    imgRana.Location = new Point(600, 599);
                }
                else     //si las vidas son iguales a 0 se detiene el tiempo, suena el freno y se muestra la imagen de GAMEOVER
                {
                    //se detiene el tiempo
                    timer.Stop();
                }
            }
            else if (imgRana.Bounds.IntersectsWith(imgLamboArriba.Bounds))
            {
                //se muestra la imagen de la rana aplastada
                imgRana.Image = Proyecto.Properties.Resources.ranaAplastada;

                //llamado a la funcion quitarVidas
                quitarVidas();

                //suena el freno
                freno.Play();

                //si las vidas son mayores a 0 la rana vuelve a la posicion original
                if (vidas > 0)
                {
                    //la rana vuelve a la posicion original
                    imgRana.Location = new Point(600, 599);
                }
                else     //si las vidas son iguales a 0 se detiene el tiempo, suena el freno y se muestra la imagen de GAMEOVER
                {
                    //se detiene el tiempo
                    timer.Stop();
                }
            }
            else if (imgRana.Bounds.IntersectsWith(imgTaxiArriba.Bounds))
            {
                //se muestra la imagen de la rana aplastada
                imgRana.Image = Proyecto.Properties.Resources.ranaAplastada;

                //llamado a la funcion quitarVidas
                quitarVidas();

                //suena el freno
                freno.Play();

                //si las vidas son mayores a 0 la rana vuelve a la posicion original
                if (vidas > 0)
                {
                    //la rana vuelve a la posicion original
                    imgRana.Location = new Point(600, 599);
                }
                else     //si las vidas son iguales a 0 se detiene el tiempo, suena el freno y se muestra la imagen de GAMEOVER
                {
                    //se detiene el tiempo
                    timer.Stop();
                }
            }
            else if (imgRana.Bounds.IntersectsWith(imgCisternaArriba.Bounds))
            {
                //se muestra la imagen de la rana aplastada
                imgRana.Image = Proyecto.Properties.Resources.ranaAplastada;

                //llamado a la funcion quitarVidas
                quitarVidas();

                //suena el freno
                freno.Play();

                //si las vidas son mayores a 0 la rana vuelve a la posicion original
                if (vidas > 0)
                {
                    //la rana vuelve a la posicion original
                    imgRana.Location = new Point(600, 599);
                }
                else     //si las vidas son iguales a 0 se detiene el tiempo, suena el freno y se muestra la imagen de GAMEOVER
                {
                    //se detiene el tiempo
                    timer.Stop();


                }
            }
            else if (imgRana.Bounds.IntersectsWith(imgRetroArriba.Bounds))
            {
                //se muestra la imagen de la rana aplastada
                imgRana.Image = Proyecto.Properties.Resources.ranaAplastada;

                //llamado a la funcion quitarVidas
                quitarVidas();

                //suena el freno
                freno.Play();

                //si las vidas son mayores a 0 la rana vuelve a la posicion original
                if (vidas > 0)
                {
                    //la rana vuelve a la posicion original
                    imgRana.Location = new Point(600, 599);
                }
                else     //si las vidas son iguales a 0 se detiene el tiempo, suena el freno y se muestra la imagen de GAMEOVER
                {
                    //se detiene el tiempo
                    timer.Stop();
                }
            }
            else if (imgRana.Bounds.IntersectsWith(imgFerraryAbajo.Bounds))
            {
                //se muestra la imagen de la rana aplastada
                imgRana.Image = Proyecto.Properties.Resources.ranaAplastada;

                //llamado a la funcion quitarVidas
                quitarVidas();

                //suena el freno
                freno.Play();

                //si las vidas son mayores a 0 la rana vuelve a la posicion original
                if (vidas > 0)
                {
                    //la rana vuelve a la posicion original
                    imgRana.Location = new Point(600, 599);
                }
                else     //si las vidas son iguales a 0 se detiene el tiempo, suena el freno y se muestra la imagen de GAMEOVER
                {
                    //se detiene el tiempo
                    timer.Stop();
                }
            }
            else if (imgRana.Bounds.IntersectsWith(imgTaxiAbajo.Bounds))
            {
                //se muestra la imagen de la rana aplastada
                imgRana.Image = Proyecto.Properties.Resources.ranaAplastada;

                //llamado a la funcion quitarVidas
                quitarVidas();

                //suena el freno
                freno.Play();

                //si las vidas son mayores a 0 la rana vuelve a la posicion original
                if (vidas > 0)
                {
                    //la rana vuelve a la posicion original
                    imgRana.Location = new Point(600, 599);
                }
                else     //si las vidas son iguales a 0 se detiene el tiempo, suena el freno y se muestra la imagen de GAMEOVER
                {
                    //se detiene el tiempo
                    timer.Stop();
                }
            }
            else if (imgRana.Bounds.IntersectsWith(imgBusAbajo.Bounds))
            {
                //se muestra la imagen de la rana aplastada
                imgRana.Image = Proyecto.Properties.Resources.ranaAplastada;

                //llamado a la funcion quitarVidas
                quitarVidas();

                //suena el freno
                freno.Play();

                //si las vidas son mayores a 0 la rana vuelve a la posicion original
                if (vidas > 0)
                {
                    //la rana vuelve a la posicion original
                    imgRana.Location = new Point(600, 599);
                }
                else     //si las vidas son iguales a 0 se detiene el tiempo, suena el freno y se muestra la imagen de GAMEOVER
                {
                    //se detiene el tiempo
                    timer.Stop();
                }
            }
        }
        public void colisionPreguntas() //Metodo para la colision de la rana con las preguntas
        {
            if (imgRana.Bounds.IntersectsWith(imgPregunta.Bounds))
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
            if (imgRana.Bounds.IntersectsWith(txtRespuesta_1.Bounds))
            {
                //Se valida si la respuesta es correcta con el array de respuestas correctas
                if (txtRespuesta_1.Text.Equals(nuevasPreguntas.ArrayCorrectas[contPreguntas]))
                {
                    //se incrementa la puntuacion
                    puntuacion += 100;
                    //se muestra la puntuacion en el lblPuntuacion
                    txtPuntuacion.Text = "" + puntuacion;

                    //se muestra la imagen de la rana en la posicion original
                    imgRana.Location = new Point(600, 599);
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
                    imgRana.Location = new Point(600, 599);
                }

            }
            //Si la rana coliciona con el lblrespuesta_2
            if (imgRana.Bounds.IntersectsWith(txtRespuesta_2.Bounds))
            {

                //Se valida si la respuesta es correcta con el array de respuestas correctas
                if (txtRespuesta_2.Text.Equals(nuevasPreguntas.ArrayCorrectas[contPreguntas]))
                {
                    //se incrementa la puntuacion
                    puntuacion += 100;
                    //se muestra la puntuacion en el lblPuntuacion
                    txtPuntuacion.Text = "" + puntuacion;

                    //se muestra la imagen de la rana en la posicion original
                    imgRana.Location = new Point(600, 599);
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
                    imgRana.Location = new Point(600, 599);
                }

            }
            //Si la rana coliciona con el lblrespuesta_3
            if (imgRana.Bounds.IntersectsWith(txtRespuesta_3.Bounds))
            {
                //Se valida si la respuesta es correcta con el array de respuestas correctas
                if (txtRespuesta_3.Text.Equals(nuevasPreguntas.ArrayCorrectas[contPreguntas]))
                {
                    //se incrementa la puntuacion
                    puntuacion += 100;
                    //se muestra la puntuacion en el lblPuntuacion
                    txtPuntuacion.Text = "" + puntuacion;

                    //se muestra la imagen de la rana en la posicion original
                    imgRana.Location = new Point(600, 599);
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
                    imgRana.Location = new Point(600, 599);
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
                    imgCorazon_3.Image = Proyecto.Properties.Resources.ranaAplastada;
                    break;
                case 2:
                    imgCorazon_2.Image = Proyecto.Properties.Resources.ranaAplastada;
                    break;
                case 3:
                    imgCorazon_1.Image = Proyecto.Properties.Resources.ranaAplastada;
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
                imgRana.Left += 10;

                //se muestra la imagen de la rana mirando a la derecha
                imgRana.Image = Proyecto.Properties.Resources.ranaDerecha;
            }
            //se mueve la rana a la izquierda
            if (e.KeyCode == Keys.A)
            {
                //se decrementa la posicion de la rana en el eje X
                imgRana.Left -= 10;

                //se muestra la imagen de la rana mirando a la izquierda
                imgRana.Image = Proyecto.Properties.Resources.ranaIzquierda;
            }
            //se mueve la rana hacia arriba
            if (e.KeyCode == Keys.W)
            {
                //se decrementa la posicion de la rana en el eje Y
                imgRana.Top -= 10;

                //se muestra la imagen de la rana mirando hacia arriba
                imgRana.Image = Proyecto.Properties.Resources.ranaFrente;
            }
            //se mueve la rana hacia abajo
            if (e.KeyCode == Keys.S)
            {
                //se incrementa la posicion de la rana en el eje Y
                imgRana.Top += 10;

                //se muestra la imagen de la rana mirando hacia abajo
                imgRana.Image = Proyecto.Properties.Resources.ranaAtras;
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
            //Si las vidas son iguales a 0 Se mostrara el formMenu
            if (vidas == 0)
            {

            }

        }
    }
}
