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
        FormMenu nuevoMenu;
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
            if (nuevoMenu == null)
            {
                nuevoMenu = new FormMenu();
                nuevoMenu.MdiParent = this;

                nuevoMenu.Show();
            }

        }

        #endregion

        private void btnJugar_Click(object sender, EventArgs e)
        {
            if (nuevoJuego == null)
            {
                nuevoJuego = new FormJuego();
                nuevoJuego.MdiParent = this;

                nuevoJuego.Show();
                this.Visible = false;
            }

        }
    }
}
