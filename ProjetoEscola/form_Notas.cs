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
    public partial class form_Notas : Form
    {
        #region Atributos

        private form_Menus _form_menus;

        private Aluno _aluno;

        private Disciplina _disciplina;

        #endregion

        #region Construtores

        public form_Notas(form_Menus form_Menus)
        {
            InitializeComponent();
            this.Icon = ProjetoEscola.Properties.Resources.icon;
            _form_menus = form_Menus;
            CarregaLista();
        }

        #endregion

        #region Eventos

        /// <summary>
        /// Evento que é utilizado para ir atualizado a data e hora nas labels
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            lbl_data.Text = "Ano Letivo: " + DateTime.Now.Year.ToString() + "/" + DateTime.Now.AddYears(1).Year.ToString();
            lbl_horas.Text = "Horas: " + DateTime.Now.ToLongTimeString();
        }

        #region Impedir que se dê resize às colunas
        private void lv_alunos_ColumnWidthChanging(object sender, ColumnWidthChangingEventArgs e)
        {
            e.Cancel = true;
            e.NewWidth = lv_alunos.Columns[e.ColumnIndex].Width;
        }

        private void lv_disciplinas_ColumnWidthChanging(object sender, ColumnWidthChangingEventArgs e)
        {
            e.Cancel = true;
            e.NewWidth = lv_disciplinas.Columns[e.ColumnIndex].Width;
        }
        #endregion

        /// <summary>
        /// Evento que carrega as disciplinas do aluno selecionado
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lv_alunos_SelectedIndexChanged(object sender, EventArgs e)
        {
            CarregaDisciplinas();
        }

        /// <summary>
        /// Evento que carrega a nota da disciplina selecionada para o controlo nud_nota (NumericUpDown)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lv_disciplinas_SelectedIndexChanged(object sender, EventArgs e)
        {
            NumericUpDownNota();
        }

        /// <summary>
        /// Evento que altera a nota da disciplina selecionada na tabela e guarda as informações da tabela num ficheiro de texto
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_alteraNota_Click(object sender, EventArgs e)
        {
            AlteraNota();
            GuardaNotas();
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
        /// Evento que enquanto o form atual é fechado, mostra o form de Menus
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void form_Notas_FormClosing(object sender, FormClosingEventArgs e)
        {
            _form_menus.Show();
        }

        #endregion

        #region Métodos

        /// <summary>
        /// Verifica os alunos que estão inseridos numa turma, e carrega-os para a ListView
        /// </summary>
        private void CarregaLista()
        {
            foreach (var ficheiro in Directory.GetFiles(@"Turmas/Alunos com Turma/","*.txt"))
            {
                _aluno = new Aluno
                {
                    Nome = Path.GetFileNameWithoutExtension(ficheiro)
                };

                string[] linha = { "", _aluno.Nome };
                ListViewItem item = new ListViewItem(linha);

                lv_alunos.Items.Add(item);
            }
        }

        /// <summary>
        /// Carrega as disciplinas do aluno escolhido
        /// </summary>
        private void CarregaDisciplinas()
        {
            if (lv_alunos.SelectedItems.Count == 1)
            {
                // Reinicia a listView
                foreach (ListViewItem item in lv_disciplinas.Items)
                {
                    item.Remove();
                }

                bool temFicheiro = false;

                // Verificar se o aluno escolhido já tem um ficheiro com notas
                foreach (var ficheiro in Directory.GetFiles(@"Notas/", "*.txt"))
                {
                    string nome = Path.GetFileNameWithoutExtension(ficheiro);

                    _aluno = new Aluno
                    {
                        Nome = nome
                    };

                    // Se o aluno escolhido na lista tiver um txt criado com notas
                    if (lv_alunos.SelectedItems[0].SubItems[1].Text == _aluno.Nome)
                    {
                        temFicheiro = true;

                        // Abre o ficheiro
                        StreamReader sr = File.OpenText(ficheiro);
                        string linha = "";

                        // Ler o ficheiro até que a linha seja nula
                        while ((linha = sr.ReadLine()) != null)
                        {
                            // Dois campos -> Nome e Nota
                            string[] campos = new string[2];

                            // Caracter que vai separar as informações contidas na linha
                            campos = linha.Split(";");

                            // Criamos a disciplina com os valores da linha
                            _disciplina = new Disciplina
                            {
                                Nome = campos[0],
                                Nota = new Nota
                                {
                                    Valor = Convert.ToInt32(campos[1])
                                }
                            };

                            // Adicionamos a disciplina à listView
                            string[] linha2 = { "", _disciplina.Nome, _disciplina.Nota.Valor.ToString() };
                            ListViewItem item = new ListViewItem(linha2);
                            lv_disciplinas.Items.Add(item);
                        }
                        sr.Close();
                    }
                }

                // Se não tiver um ficheiro com notas, carrega as disciplinas no txt da turma
                if (temFicheiro == false)
                {
                    foreach (var ficheiro in Directory.GetFiles(@"Turmas/", "*.txt"))
                    {
                        // Lê a quarta linha - Alunos
                        string quartaLinha = File.ReadLines(ficheiro).Skip(3).Take(1).First();

                        // Conta quantos elementos há na linha
                        int tamanho = quartaLinha.Split(';').Length;

                        // Define um array com base no número de elementos da linha
                        string[] campos = new string[tamanho - 1];

                        // Passa os elementos da linha para o array
                        campos = quartaLinha.Split(';');

                        // Procura o aluno no array criado
                        foreach (var campo in campos)
                        {
                            // Se ele encontrar o aluno, vamos carregar as disciplinas dessa turma
                            if (campo == lv_alunos.SelectedItems[0].SubItems[1].Text)
                            {
                                // Lê a terceira linha - Disciplinas
                                string terceiraLinha = File.ReadLines(ficheiro).Skip(2).Take(1).First();

                                // Conta quantos elementos há na linha
                                tamanho = terceiraLinha.Split(';').Length;

                                // Define um array com base no número de elementos da linha
                                campos = new string[tamanho - 1];

                                // Passa os elementos da linha para o array
                                campos = terceiraLinha.Split(';');

                                // Preenche a tabela de disciplinas
                                foreach (var campo2 in campos)
                                {
                                    _disciplina = new Disciplina
                                    {
                                        Nome = campo2,
                                        Nota = new Nota { Valor = 0 }
                                    };

                                    // O primeiro campo está vazio porque a primeira coluna da tabela está oculta
                                    // Por causa do alinhamento de texto que não funciona, dai ter ocultado
                                    string[] linha = { "", _disciplina.Nome, _disciplina.Nota.Valor.ToString() };
                                    ListViewItem item = new ListViewItem(linha);
                                    lv_disciplinas.Items.Add(item);
                                }
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Passa a nota da disciplina selecionada para o controlo NumericUpDown
        /// </summary>
        private void NumericUpDownNota()
        {
            if (lv_disciplinas.SelectedItems.Count == 1)
            {
                _disciplina = new Disciplina
                {
                    Nome = lv_disciplinas.SelectedItems[0].SubItems[1].Text,
                    Nota = new Nota 
                    {
                        Valor = Convert.ToInt32(lv_disciplinas.SelectedItems[0].SubItems[2].Text) 
                    }
                };

                nud_nota.Value = _disciplina.Nota.Valor;
            }
        }

        /// <summary>
        /// Altera a nota da disciplina escolhida
        /// </summary>
        private void AlteraNota()
        {
            // Se tiver uma disciplina selecionada
            if (lv_disciplinas.SelectedItems.Count == 1)
            {
                _disciplina = new Disciplina
                {
                    Nome = lv_disciplinas.SelectedItems[0].SubItems[1].Text,
                    Nota = new Nota
                    {
                        Valor = Convert.ToInt32(nud_nota.Value)
                    }
                };

                // Edita a nota na listView
                foreach (ListViewItem item in lv_disciplinas.Items)
                {
                    if (item.SubItems[1].Text == _disciplina.Nome)
                    {
                        item.SubItems[2].Text = _disciplina.Nota.Valor.ToString();
                    }
                }
            }
        }

        /// <summary>
        /// Cria um txt com o nome do Aluno contendo as disciplinas e respetiva nota 
        /// </summary>
        private void GuardaNotas()
        {
            // Guardar para o aluno escolhido
            if (lv_alunos.SelectedItems.Count == 1 && lv_disciplinas.SelectedItems.Count == 1)
            {
                _aluno = new Aluno
                {
                    Nome = lv_alunos.SelectedItems[0].SubItems[1].Text
                };

                // Caminho do ficheiro
                string ficheiro = @$"Notas/{_aluno.Nome}.txt";   
                
                // False - escreve por cima
                // True - mantém o que lá está e adiciona mais texto
                using (StreamWriter sw = new StreamWriter(ficheiro, false))
                {
                    // Guardar cada disciplina e sua nota no txt
                    foreach (ListViewItem item in lv_disciplinas.Items)
                    {
                        // Criar a disciplina com as informações do item da tabela
                        _disciplina = new Disciplina
                        {
                            Nome = item.SubItems[1].Text,
                            Nota = new Nota
                            {
                                Valor = Convert.ToInt32(item.SubItems[2].Text)
                            }
                        };
                                              
                        string info = $"{_disciplina.Nome};{_disciplina.Nota.Valor.ToString()}";


                        sw.WriteLine(info); // Escreve no ficheiro                        
                    }

                    sw.Close(); // Fecha-o
                }          
            }
        }

        #endregion
        
    }
}
