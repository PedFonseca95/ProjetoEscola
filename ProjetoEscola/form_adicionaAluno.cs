using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetoEscola
{
    public partial class form_adicionaAluno: Form
    {
        #region Atributos

        private form_Turmas _form_Turmas;

        #endregion

        #region Construtores

        public form_adicionaAluno(form_Turmas form_Turmas)
        {
            InitializeComponent();
            this.Icon = ProjetoEscola.Properties.Resources.icon;
            _form_Turmas = form_Turmas;
            CarregaAlunos();
        }

        #endregion

        #region Métodos

        /// <summary>
        /// Vai à pasta onde estão os ficheiros de cada aluno, e adiciona cada aluno existente à comboBox
        /// </summary>
        private void CarregaAlunos()
        {
            foreach (var ficheiro in Directory.GetFiles(@"Turmas/Alunos sem Turma/", "*.txt"))
            {
                string aluno = Path.GetFileNameWithoutExtension(ficheiro);

                cb_aluno.Items.Add(aluno);

                // Verifica se o aluno adicionado já existe na turma
                foreach (ListViewItem item2 in _form_Turmas.lv_alunos.Items)
                {
                    // Caso exista, remove-o da comboBox
                    if (aluno == item2.SubItems[1].Text)
                    {
                        cb_aluno.Items.Remove(aluno);
                    }
                }
            }
        }

        #endregion

        #region Eventos

        /// <summary>
        /// Evento que adiciona o aluno selecionado à lista de alunos da turma
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_adicionar_Click(object sender, EventArgs e)
        {
            // Criar um array que representa a linha a adicionar
            string[] linha = { "", cb_aluno.Text };

            // Criar o objeto item que contem a informação inserida na linha
            ListViewItem item = new ListViewItem(linha);

            // Adicionar o item/linha à tabela de Alunos
            _form_Turmas.lv_alunos.Items.Add(item);

            // Remove o aluno da comboBox após ser adicionado
            cb_aluno.Items.Remove(cb_aluno.SelectedItem);
        }

        /// <summary>
        /// Evento que fecha o form atual
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_voltar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Evento que enquanto o form é fechado, ativa o form das Turmas
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void form_adicionaAluno_FormClosing(object sender, FormClosingEventArgs e)
        {
            _form_Turmas.Enabled = true;
        }

        /// <summary>
        /// Evento que altera a propriedade Enabled do botão 'Adicionar' consoante o texto que está no controlo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cb_aluno_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_aluno.Text == "")
            {
                btn_adicionar.Enabled = false;
            }
            else
            {
                btn_adicionar.Enabled = true;
            }
        }

        #endregion

    }
}
