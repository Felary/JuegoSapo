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

namespace Proyecto.forms
{
    public partial class FormJuego : Form
    {
        #region Atributos
        int vidas = 3, puntuacion = 0;
        SoundPlayer freno = new SoundPlayer(@"F:\SONIDOS\freno.wav");
        #endregion
        public FormJuego()
        {
            InitializeComponent();
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
        }
        public void colisionCarros() //funcion para la colision de la rana con los carros
        {
            //si la rana colisiona con un carro se muestra la imagen de la rana aplastada y se quita una vida
            if (imgRana.Bounds.IntersectsWith(imgFerraryArriba.Bounds))
            {
                //se muestra la imagen de la rana aplastada
                imgRana.Image = Proyecto.Properties.Resources.ranaAplastada;

                //llamado a la funcion quitarVidas
                quitarVidas();

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

                    //suena el freno
                    freno.Play();
                }
            }
            else if (imgRana.Bounds.IntersectsWith(imgLamboArriba.Bounds))
            {
                //se muestra la imagen de la rana aplastada
                imgRana.Image = Proyecto.Properties.Resources.ranaAplastada;

                //llamado a la funcion quitarVidas
                quitarVidas();

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

                    //suena el freno
                    freno.Play();
                }
            }
            else if (imgRana.Bounds.IntersectsWith(imgTaxiArriba.Bounds))
            {
                //se muestra la imagen de la rana aplastada
                imgRana.Image = Proyecto.Properties.Resources.ranaAplastada;

                //llamado a la funcion quitarVidas
                quitarVidas();

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

                    //suena el freno
                    freno.Play();
                }
            }
            else if (imgRana.Bounds.IntersectsWith(imgCisternaArriba.Bounds))
            {
                //se muestra la imagen de la rana aplastada
                imgRana.Image = Proyecto.Properties.Resources.ranaAplastada;

                //llamado a la funcion quitarVidas
                quitarVidas();

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

                    //suena el freno
                    freno.Play();
                }
            }
            else if (imgRana.Bounds.IntersectsWith(imgRetroArriba.Bounds))
            {
                //se muestra la imagen de la rana aplastada
                imgRana.Image = Proyecto.Properties.Resources.ranaAplastada;

                //llamado a la funcion quitarVidas
                quitarVidas();

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

                    //suena el freno
                    freno.Play();
                }
            }
            else if (imgRana.Bounds.IntersectsWith(imgFerraryAbajo.Bounds))
            {
                //se muestra la imagen de la rana aplastada
                imgRana.Image = Proyecto.Properties.Resources.ranaAplastada;

                //llamado a la funcion quitarVidas
                quitarVidas();

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

                    //suena el freno
                    freno.Play();
                }
            }
            else if (imgRana.Bounds.IntersectsWith(imgTaxiAbajo.Bounds))
            {
                //se muestra la imagen de la rana aplastada
                imgRana.Image = Proyecto.Properties.Resources.ranaAplastada;

                //llamado a la funcion quitarVidas
                quitarVidas();

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

                    //suena el freno
                    freno.Play();
                }
            }
            else if (imgRana.Bounds.IntersectsWith(imgBusAbajo.Bounds))
            {
                //se muestra la imagen de la rana aplastada
                imgRana.Image = Proyecto.Properties.Resources.ranaAplastada;

                //llamado a la funcion quitarVidas
                quitarVidas();

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

                    //suena el freno
                    freno.Play();
                }
            }
        }
        public void colisionPreguntas() //funcion para la colision de la rana con las preguntas
        {
            if (imgRana.Bounds.IntersectsWith(imgPregunta.Bounds))
            {
                imgPregunta.Visible = false;
                imgFlecha.Visible = false;
            }
        }
        public void quitarVidas() //funcion para quitar vidas
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
        private void FormJuego_KeyDown(object sender, KeyEventArgs e) //Método para mover la rana
        {
            //se mueve la rana a la derecha
            if (e.KeyCode == Keys.Right)
            {
                //se incrementa la posicion de la rana en el eje X
                imgRana.Left += 10;

                //se muestra la imagen de la rana mirando a la derecha
                imgRana.Image = Proyecto.Properties.Resources.ranaDerecha;
            }
            //se mueve la rana a la izquierda
            if (e.KeyCode == Keys.Left)
            {
                //se decrementa la posicion de la rana en el eje X
                imgRana.Left -= 10;

                //se muestra la imagen de la rana mirando a la izquierda
                imgRana.Image = Proyecto.Properties.Resources.ranaIzquierda;
            }
            //se mueve la rana hacia arriba
            if (e.KeyCode == Keys.Up)
            {
                //se decrementa la posicion de la rana en el eje Y
                imgRana.Top -= 10;

                //se muestra la imagen de la rana mirando hacia arriba
                imgRana.Image = Proyecto.Properties.Resources.ranaFrente;
            }
            //se mueve la rana hacia abajo
            if (e.KeyCode == Keys.Down)
            {
                //se incrementa la posicion de la rana en el eje Y
                imgRana.Top += 10;

                //se muestra la imagen de la rana mirando hacia abajo
                imgRana.Image = Proyecto.Properties.Resources.ranaAtras;
            }
        }

    }
}
