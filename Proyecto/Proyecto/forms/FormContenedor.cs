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
    public partial class FormContenedor : Form
    {
        #region Atributos
        FormJuego nuevoJuego;
        #endregion
        public FormContenedor()
        {
            InitializeComponent();
            iniciarJuego();
        }





        #region Metodos y Funciones
        private void iniciarJuego()
        {
            if (nuevoJuego == null)
            {
                nuevoJuego = new FormJuego();
                nuevoJuego.MdiParent = this;
                nuevoJuego.FormClosed += new FormClosedEventHandler(cerrarVentana);
                nuevoJuego.Show();
            }

        }
        private void cerrarVentana(object sender, FormClosedEventArgs arg) //Accion para cuando se cierra la ventana
        {
            nuevoJuego = (sender is FormJuego) ? null : nuevoJuego;
        }
        #endregion


    }
}
