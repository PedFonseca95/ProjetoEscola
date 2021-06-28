using System;
using System.Drawing;
using System.Windows.Forms;

namespace ProjetoEscola
{
    public partial class form_LogIn : Form
    {
        #region Construtores
        public form_LogIn()
        {
            InitializeComponent();
            this.Icon = ProjetoEscola.Properties.Resources.icon;
        }
        #endregion

        #region Eventos

        /// <summary>
        /// Entra no programa caso sejam inseridas as credenciais corretas
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_entrar_Click(object sender, EventArgs e)
        {
            if (tb_utilizador.Text == "" && tb_password.Text == "")
            {
                lbl_mensagem.Text = "* Insira o utilizador\n* Insira a password";
                lbl_mensagem.ForeColor = Color.Black;
            }
            else if (tb_utilizador.Text != "" && tb_password.Text == "")
            {
                lbl_mensagem.Text = "* Insira a password";
                lbl_mensagem.ForeColor = Color.Black;
            }
            else if (tb_utilizador.Text == "" && tb_password.Text != "")
            {
                lbl_mensagem.Text = "* Insira o utilizador";
                lbl_mensagem.ForeColor = Color.Black;
            }
            else
            {
                if (tb_utilizador.Text.ToLower() == "admin")
                {
                    if (tb_password.Text == "1234")
                    {
                        form_Menus menuPrincipal = new form_Menus(this);
                        menuPrincipal.Show();
                        this.Hide();
                    }
                    else
                    {
                        lbl_mensagem.Text = "* Password incorreta";
                        lbl_mensagem.ForeColor = Color.Red;
                    }
                }
                else
                {
                    lbl_mensagem.Text = "* Utilizador inválido";
                    lbl_mensagem.ForeColor = Color.Red;
                }
            }
        }

        /// <summary>
        /// Mostra as informações do autor
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_sobre_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Autor: Pedro Ricardo Pereira da Fonseca" +
                "\nTurma: CET57" +
                "\nUFCD: Programação de Computadores - orient. obj" +
                "\nData: 11/06/2021" +
                "\nVersão: 1.0", "Sobre", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        #endregion

        #region Métodos Auxiliares

        /// <summary>
        /// Limpa o texto nas textBox utilizador e password
        /// </summary>
        public void LimpaCampos()
        {
            tb_utilizador.ResetText();
            tb_password.ResetText();
            tb_utilizador.Select();
        }

        #endregion
    }
}
