﻿using System;
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
                nuevoJuego = new FormJuego();
                nuevoJuego.MdiParent = this;
                nuevoMenu = new FormMenu(nuevoJuego);
                nuevoMenu.MdiParent = this;
                nuevoMenu.Show();

            }
        }
        #endregion


    }
}
