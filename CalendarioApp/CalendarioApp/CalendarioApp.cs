using AppCore.Interfaces;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalendarioApp
{
    public partial class CalendarioApp : Form
    {
        private ICalendarioService calendarioService;
        public CalendarioApp(ICalendarioService calendarioService)
        {
            this.calendarioService = calendarioService;
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            FmrSolicitud frmsolicitud = new FmrSolicitud();
            frmsolicitud.calendarioService = calendarioService;
            frmsolicitud.ShowDialog();
            dataGridView1.DataSource = calendarioService.FindAll();
        }

        private void CalendarioApp_Load(object sender, EventArgs e)
        {
            cmbFinder.Items.AddRange(Enum.GetValues(typeof(Finder)).Cast<object>().ToArray());
            cmbEstado.Items.AddRange(Enum.GetValues(typeof(Estado)).Cast<object>().ToArray());
            cmbTipo.Items.AddRange(Enum.GetValues(typeof(Tipo)).Cast<object>().ToArray());
        }

        private void cmbFinder_SelectedIndexChanged(object sender, EventArgs e)
        {
            //switch (cmbFinder.SelectedIndex)
            //{
            //    case 0:
            //        cmbTipo.Visible = true;
            //        cmbEstado.Visible = false;
                 
            //        break;
            //    case 1:
            //        cmbTipo.Visible = false;
            //        cmbEstado.Visible = true;
                   
            //        break;
            //    case 2:
            //        cmbTipo.Visible = false;
            //        cmbEstado.Visible = false;
                    
            //        break;
            //}
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            switch (cmbFinder.SelectedIndex)
            {
                case 0:
                    dataGridView1.DataSource = calendarioService.FindAll(p => p.Tipo == (Tipo)cmbTipo.SelectedIndex);
                  
                    break;
                case 1:
                    dataGridView1.DataSource = calendarioService.FindAll(p => p.Estado == (Estado)cmbEstado.SelectedIndex);
                
                    break;
                case 2:
                    dataGridView1.DataSource = calendarioService.FindAll();
                    break;
                default:
                    MessageBox.Show("No selecciono ningun criterio");
                    return;
            }
        }

        private void cmbEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbFinder_SelectedIndexChanged(sender, e);
        }

        private void cmbTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbFinder_SelectedIndexChanged(sender, e);
        }
    }
}
