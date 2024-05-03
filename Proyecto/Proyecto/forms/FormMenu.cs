using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto.forms
{
    public partial class FormMenu : Form
    {
        #region Atributos
        Boolean iniciar = false;
        #endregion
        public FormMenu()
        {
            InitializeComponent();
        }

        private void btnSalir_Click(object sender, EventArgs e) //Evento click del boton salir
        {
            //Cierra la aplicacion
            Application.Exit();
        }
        private void btnJugar_Click(object sender, EventArgs e) //Evento click del boton jugar
        {
            iniciarTimer();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            if (iniciar)
            {

                if (pnlSuperior.Width <= pnlInferior.Width)
                {
                    pnlSuperior.Width += 20;
                }
                else
                {

                    //Crea una nueva instancia de la clase FormJuego
                    FormJuego nuevoJuego = new FormJuego();
                    FormNivel_2 nuevoNivel = new FormNivel_2();
                    //Oculta el formulario actual
                    this.Hide();
                    //Muestra el formulario FormJuego
                    nuevoNivel.Show();
                    timer.Stop();
                }
            }
        }
        private Boolean iniciarTimer()
        {

            iniciar = true;
            return iniciar;
        }
    }
}
