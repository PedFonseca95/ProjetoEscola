using BibliotecaClasses;
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
    public partial class form_novaDisciplina : Form
    {
        #region Atributos

        private form_Turmas _form_Turmas;

        private List<Disciplina> _disciplinas;

        private Disciplina _disciplina;

        #endregion

        #region Construtor

        public form_novaDisciplina(form_Turmas form_Turmas)
        {
            InitializeComponent();
            this.Icon = ProjetoEscola.Properties.Resources.icon;
            _form_Turmas = form_Turmas;
            CarregaDisciplinas();
        }

        #endregion

        #region Eventos

        /// <summary>
        /// Evento que ativa o form de turmas enquanto fecha o form atual
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void form_novaDisciplina_FormClosing(object sender, FormClosingEventArgs e)
        {
            _form_Turmas.Enabled = true;
        }
             
        /// <summary>
        /// Evento que ativa o botão 'Adicionar' caso seja selecionada uma disciplina da comboBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cb_disciplina_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Ativa o botão se estiver algo selecionado, caso contrário o botão fica inativo
            if (cb_disciplina.Text == "")
            {
                btn_adicionar.Enabled = false;
            }
            else
            {
                btn_adicionar.Enabled = true;
            }
        }

        /// <summary>
        /// Evento que adiciona a disciplina selecionada à lista de disciplinas da turma
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_adicionar_Click_1(object sender, EventArgs e)
        {            
                // Criar um array que representa a linha a adicionar
                string[] linha = { "", cb_disciplina.Text};

                // Criar o objeto item que contem a informação inserida na linha
                ListViewItem item = new ListViewItem(linha);

                // Adicionar o item/linha à tabela de Alunos
                _form_Turmas.lv_disciplinas.Items.Add(item);

                // Remove a disciplina da comboBox após ser adicionada
                cb_disciplina.Items.Remove(cb_disciplina.SelectedItem);            
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

        #endregion

        #region Métodos

        /// <summary>
        /// Lê o txt que contem as disciplinas utilizando o método LerInfoTxt() e utiliza a lista que esse método retorna, para carregar as disciplinas na comboBox
        /// </summary>
        private void CarregaDisciplinas()
        {
            LerInfoTxt();

            // Após ler o txt, adiciona cada item da lista à comboBox
            foreach (Disciplina disciplina in _disciplinas)
            {
                cb_disciplina.Items.Add(disciplina.Nome);

                // Verifica se o item adicionado já existe na turma
                foreach (ListViewItem item2 in _form_Turmas.lv_disciplinas.Items)
                {
                    // Caso exista, remove-o da comboBox
                    if (disciplina.Nome == item2.SubItems[1].Text)
                    {
                        cb_disciplina.Items.Remove(disciplina.Nome);
                    }
                }
            }            
        }

        /// <summary>
        /// Vai ler o txt que contem todas as disciplinas e retorna uma lista com todas elas
        /// </summary>
        private List<Disciplina> LerInfoTxt()
        {
            _disciplinas = new List<Disciplina>(); // Criar uma nova lista vazia

            foreach (var ficheiro in Directory.GetFiles(@"Disciplinas/", "Disciplinas.txt")) // Vai buscar o txt
            {
                StreamReader sr;

                if (File.Exists(ficheiro)) // Se o ficheiro existir, preenche a comboBox com todas as disciplinas
                {
                    sr = File.OpenText(ficheiro);

                    string linha = "";

                    while ((linha = sr.ReadLine()) != null) // Até que a linha "seja nula"/não tenha nada escrito
                    {                        
                        string[] campos = new string[30]; // 30 porque são 30 disciplinas diferentes

                        campos = linha.Split(';'); // Caracter que vai separar as informações -> ;

                        // Vai percorrer o array e adicionar cada elemento
                        for (int i = 0; i < 30; i++)
                        {
                            // Criar a nova disciplina, passando-lhe a informação (nome) contida no campo
                            _disciplina = new Disciplina
                            {
                                Nome = campos[i]
                            };

                            _disciplinas.Add(_disciplina); // Adiciona a nova disciplina à lista
                        }                        
                    }

                    sr.Close(); // Fecha o documento
                }
            }

            return _disciplinas; // Retorna a lista após criada (com ou sem valores)
        }

        #endregion

    }
}
