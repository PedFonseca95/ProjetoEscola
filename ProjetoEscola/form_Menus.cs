using System;
using System.IO;
using System.Windows.Forms;

namespace ProjetoEscola
{
    public partial class form_Menus : Form
    {
        #region Atributos

        private form_LogIn _form_LogIn;

        private form_Alunos _form_GerirAlunos;

        private form_Professores _form_GerirProfessores;

        private form_Turmas _form_Turmas;

        private form_Notas _form_Notas;

        #endregion

        #region Construtores

        public form_Menus(form_LogIn formLogIn)
        {
            InitializeComponent();
            this.Icon = ProjetoEscola.Properties.Resources.icon;
            _form_LogIn = formLogIn; // Criar referência para o FormLogin
        }

        #endregion

        #region Eventos

        /// <summary>
        /// Evento que fecha completamente a aplicação, sem depender do form de inicialização (FormLogin)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormMenuPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// Evento que fecha o form atual e retorna ao form de LogIn
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_sair_Click(object sender, System.EventArgs e)
        {
            _form_LogIn.LimpaCampos();
            _form_LogIn.Show();
            this.Hide();
        }

        /// <summary>
        /// Evento que abre o menu de gestão de alunos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_alunos_Click(object sender, System.EventArgs e)
        {
            _form_GerirAlunos = new form_Alunos(this);
            _form_GerirAlunos.Show();
            this.Hide();
        }

        /// <summary>
        /// Evento que abre o menu de gestão de professores
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_professores_Click(object sender, System.EventArgs e)
        {
            _form_GerirProfessores = new form_Professores(this);
            _form_GerirProfessores.Show();
            this.Hide();
        }

        /// <summary>
        /// Evento que abre o menu de gestão de turmas
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_turmas_Click(object sender, System.EventArgs e)
        {
            if (VerificarProfessoresAlunos())
            {
                _form_Turmas = new form_Turmas(this);
                _form_Turmas.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Não existem alunos e/ou professores criados. Crie-os primeiro antes de criar novas turmas!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        /// <summary>
        /// Evento que abre o menu de gestão de notas
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_notas_Click(object sender, EventArgs e)
        {
            if (VerificaTurmas())
            {
                _form_Notas = new form_Notas(this);
                _form_Notas.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Não existem alunos inscritos. Crie primeiro uma turma com os respetivos alunos, para editar as notas", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        /// <summary>
        /// Evento que é utilizado para ir atualizado a data e hora nas labels
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick(object sender, System.EventArgs e)
        {
            lbl_data.Text = "Ano Letivo: " + DateTime.Now.Year.ToString() + "/" + DateTime.Now.AddYears(1).Year.ToString();
            lbl_horas.Text = "Horas: " + DateTime.Now.ToLongTimeString();
        }

        #endregion

        #region Métodos

        /// <summary>
        /// Verifica se já existem professores e alunos criados
        /// </summary>
        private bool VerificarProfessoresAlunos()
        {
            int contaAlunos = 0;
            int contaProfessores = 0;

            foreach (var ficheiro in Directory.GetFiles(@"Professores/", "*.txt"))
            {
                contaProfessores++;
            }

            foreach (var ficheiro in Directory.GetFiles(@"Alunos/", "*.txt"))
            {
                contaAlunos++;
            }

            if (contaAlunos != 0 && contaProfessores != 0)
            {
                return true; // Existem alunos e professores
            }
            else
            {
                return false; // Pelo menos um dos dois não existe
            }
        }

        /// <summary>
        /// Verifica se já existem turmas criadas
        /// </summary>
        /// <returns></returns>
        private bool VerificaTurmas()
        {
            int contador = 0; 

            foreach (var ficheiro in Directory.GetFiles(@"Turmas/","*.txt"))
            {
                contador++;
            }

            if (contador == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        #endregion
        
    }
}
