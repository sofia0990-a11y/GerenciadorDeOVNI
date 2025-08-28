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
    public partial class TelaInicial : Form
    {
        public TelaInicial()
        {
            InitializeComponent();
            // Adicionar os planetas no comboBox:
            cmdPlanetas.Items.AddRange(BibliotecaOVNI.OVNI.PlanetasValidos); 
        }

        private void btnIniciar_Click(object sender, EventArgs e)
        {
            // Verificar se o número de tripulante está vazio:
            if(txbTripulantes.Text== "")
            {
                MessageBox.Show("informe o máximo de tripulantes!", 
                    "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else if(txbAbduzidos.Text=="")
            {
                MessageBox.Show("informe a capacidade do compartimento de tripulantes!",
                   "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if(cmdPlanetas.SelectedIndex==-1)
            {
                MessageBox.Show("Selecione o planeta de origem!",
                   "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                //Variavel para receber os valores dos txb
                int MaxTripulantes = int.Parse(txbTripulantes.Text);
                int MaxAbduzidos = int.Parse(txbAbduzidos.Text);
                string PlanetaOrigem = cmdPlanetas.Text;

                // Instaciar o OVINI:
                BibliotecaOVNI.OVNI ovini = new BibliotecaOVNI.OVNI(MaxTripulantes, MaxAbduzidos, PlanetaOrigem); ;

                // Instacionar a janela "Gerenciador" para conseguir chama-la
                Gerenciador gerenciador = new Gerenciador(ovini);

                // Esconder janela atual:
                Hide();

                // Abrir a janela do Gerenciador:
                gerenciador.ShowDialog();

                // Mostra novamente a janela atual pós a Anterior fechar:
                Show();

            }

        }     
        }
    }

