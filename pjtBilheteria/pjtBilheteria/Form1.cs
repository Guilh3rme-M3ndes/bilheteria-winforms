using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pjtBilheteria
{
    public partial class frm_bilheteria : Form
    {
        CheckBox[,] lugares;
        Button btn_faturamento;
        Label lbl_faturamento;
        public frm_bilheteria()
        {
            InitializeComponent();
            InitializeMyComponents();
        }

        private void InitializeMyComponents()
        {
            InitializeLugares();
            InitializeBtnFaturamento();
        }

        private void InitializeLugares()
        {
            int left = 20;
            int top = 5;
            lugares = new CheckBox[15,40];
            for (int i = 0; i < 15; i++)
            {
                for (int j = 0; j < 40; j++)
                {
                    lugares[i, j] = new CheckBox();
                    lugares[i, j].Parent = pnl_poltronas;
                    lugares[i, j].Top = top;
                    lugares[i, j].Left = left;
                    lugares[i, j].Width = 40;
                    lugares[i, j].Tag = '.';
                    lugares[i, j].BringToFront();
                    lugares[i, j].Enabled = false;
                    left += 17;
                    
                }
                left = 20;
                top += 22;
            }
            lugares[14, 39].Checked = true;
            lugares[14, 39].Tag = "#";
        }
        private void InitializeBtnFaturamento()
        {
            btn_faturamento = new Button();
            btn_faturamento.Parent = this;
            btn_faturamento.Size = new Size(200, 60);
            btn_faturamento.Location = new Point(532, 446);
            btn_faturamento.Text = "Faturamento";
            btn_faturamento.Click += new EventHandler(calculaFaturamento);
            lbl_faturamento = new Label();
            lbl_faturamento.Parent = this;
            lbl_faturamento.Size = new Size(200, 60);
            lbl_faturamento.Location = new Point(532, 506);
            lbl_faturamento.Text = "R$:";
            
        }

        private void reservarPoltrona(object sender, EventArgs e)
        {
            int x = Convert.ToInt16(num_x.Value) - 1;
            int y = Convert.ToInt16(num_y.Value) - 1;
            if (lugares[y, x].Tag.ToString() == "#")
            {
                MessageBox.Show("Lugar ocupado!", "Assento indisponivel");
            }
            else
            {
                lugares[y, x].Checked = true;
                lugares[y, x].Tag = "#";
                MessageBox.Show("Reserva concluida!", "Sucesso!");
            }
        }

        private void calculaFaturamento(object sender, EventArgs e)
        {
            double faturamento = 0.0;
            for (int i = 0; i < 15; i++)
            {
                for (int j = 0; j < 40; j++)
                {
                    double preco = i < 5 ? 50.0 : i < 10 ? 30.0 : 15.0;
                    if (lugares[i, j].Tag.ToString() == "#")
                    {
                        faturamento += preco;
                    }
                }

            }
            lbl_faturamento.Text = "R$: " + faturamento.ToString();

        }

        private void frm_bilheteria_Load(object sender, EventArgs e)
        {

        }

    }
}
