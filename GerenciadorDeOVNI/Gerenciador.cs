using BibliotecaOVNI;
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
        BibliotecaOVNI.OVNI ovni;

        public Gerenciador(BibliotecaOVNI.OVNI ovini)// Obrigatoriamente deve-se inciar passando um OVINI
        {
            InitializeComponent();

            // "Copiando" o ovini vindo de outra janela para obj global
            this.ovni = ovini;

            // atualizar informações:
            AtualizarInformacoes();

            // Popular o combobox com os planetas validos
            cmdPlanetas.Items.AddRange(BibliotecaOVNI.OVNI.PlanetasValidos);

        }





        private void btnLigar_Click(object sender, EventArgs e)
        {
            if (ovni.Ligar())
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
            lblTripulantes.Text = $"Tripulantes: {ovni.QtdTripulantes}";
            lblAbduzidos.Text = $"Abduzidos: {ovni.QtdAbduzidos}";
            lblSituacao.Text = $"Situação: {(ovni.Situacao ? "Ligado" : "Desligado")}";
            lblPlaneta.Text = $"Planeta Atual: {ovni.PlanetaAtual}";
            cmdPlanetas.Text = ovni.PlanetaAtual;

            // Atualizar os botões Ligar e Desligar:
            btnDesligar.Enabled = ovni.Situacao;
            btnLigar.Enabled = !ovni.Situacao;

            // Ativar/desativar o grb de acordo de acordo com o status da nave:
            grbabduzidos.Enabled = ovni.Situacao;
            grbPlaneta.Enabled = ovni.Situacao;
            gbrTripulantes.Enabled = ovni.Situacao;

            if (ovni.PlanetaAtual == "Terra")
            {
                pibTerra.Image = Properties.Resources.hug;
            }
            else
            {
                pibTerra.Image= null;
            }

            pibTerra.Image = ovni.PlanetaAtual == "terra" ? Properties.Resources.hug: null;

        }

        private void btnDesligar_Click(object sender, EventArgs e)
        {
            if (ovni.Desligar())
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

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Tripulantes Adicionado!",
                   "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnRemover_Click(object sender, EventArgs e)
        {
            if (ovni.RemoverTripulante())
            {
                MessageBox.Show("Tripulante Removido!",
                "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(" Não é possivel remover mais tripulante!",
                "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // Atualizar as informações
            AtualizarInformacoes();


        }

        private void btnAbduzir_Click(object sender, EventArgs e)
        {

           if (!ovni.Abduzir())
            {
                MessageBox.Show("Abduzir Tripulante!",
                 "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
           else
            {
                MessageBox.Show(" Não é possivel abduzir!",
               "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // Atualizar as informações
            AtualizarInformacoes();
        }
           
         

        private void btnExcluir_Click(object sender, EventArgs e)
        {
             
            MessageBox.Show(" Não é possivel abduzir!",
                "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnMudarPlaneta_Click(object sender, EventArgs e)
        {
           if (ovni.MudarPlaneta(cmdPlanetas.Text))
            {
                MessageBox.Show("Voce mudou de planeta!",
                "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
           else
            {
                MessageBox.Show(" Não é possivel mudar de planeta!",
               "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);

                // Atualizar as informações
                AtualizarInformacoes();
            }
        }

        private void btnRetonar_Click(object sender, EventArgs e)
        {
          if  (ovni.RetornarAoPlanetaDeOrigem(cmdPlanetas.Text))
            {
                MessageBox.Show("Retornar planeta de origem!",
               "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
          else
            {
                MessageBox.Show(" Não é possivel Retornar ao Planeta de origem!",
              "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);


                // Atualizar as informações
                AtualizarInformacoes();
            }


        }
    }
}
