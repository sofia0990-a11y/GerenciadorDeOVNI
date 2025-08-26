using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GerenciadorDeOVNI
{
    public partial class Gerenciador : Form
    {
        private object ovini;

        public Gerenciador(BibliotecaOVNI.OVNI ovini)// Obrigatoriamente deve-se inciar passando um OVINI
        {
            InitializeComponent();

            // "Copiando" o ovini vindo de outra janela para obj global
            this.ovini = ovini;

            // atualizar informações:
            AtualizarInformacoes();

            // Popular o combobox com os planetas validos
            cmdPlanetas.Items.AddRange(BibliotecaOVNI.OVNI.PlanetasValidos);

        }
    
    }
   
         
        
        private void btnLigar_Click(object sender, EventArgs e)
       {
            if (ovini.Ligar())
            {
                MessageBox.Show("O OVINI  foi ligado!",
                "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(" O OVINI está liagado",
                "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // Atualizar as informações
            AtualizarInformacoes();

       }

        private void AtualizarInformacoes()
        {
           lblTripulantes.Text =$"tripulantes: {ovini.QtdTripulantes}");
            lblAbduzidos.Text = $"Abduzidos: "
            cmdPlanetas.Text = ovini.PlanetaAtual;

            btnDesligar.Enabled = ovini.Situacao;
            btnLigar.Enabled = ovini.Situacao;
            grbTripulantes
           

        }

        private void btnDesligar_Click(object sender, EventArgs e)
        {
            if (ovini.Desligar())
            {
                MessageBox.Show("O OVINI  foi Desligado!",
                "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(" O OVINI está Desliagado!",
                "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // Atualizar as informações
            AtualizarInformacoes();

        }
    }
