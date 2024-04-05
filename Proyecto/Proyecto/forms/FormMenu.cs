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
        FormJuego nuevoJuego;
        #endregion
        public FormMenu()
        {
            InitializeComponent();

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnJugar_Click(object sender, EventArgs e)
        {

            nuevoJuego = new FormJuego();
            nuevoJuego.Show();



        }
    }
}
