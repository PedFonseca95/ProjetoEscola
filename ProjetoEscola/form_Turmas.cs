using BibliotecaClasses;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace ProjetoEscola
{
    public partial class form_Turmas : Form
    {
        #region Atributos                
        private form_Menus _form_Menus;

        private form_novaDisciplina _form_novaDisciplina;

        private form_adicionaAluno _form_adicionaAluno;

        #endregion

        public form_Turmas(form_Menus form_Menus)
        {
            InitializeComponent();
            this.Icon = ProjetoEscola.Properties.Resources.icon;
            _form_Menus = form_Menus;
            PreencherComboBox();
            CarregaTurmas();
        }
                
        #region Eventos

        #region Impedir que o user dê resize às colunas das ListView

        private void lv_disciplinas_ColumnWidthChanging(object sender, ColumnWidthChangingEventArgs e)
        {
            e.Cancel = true;
            e.NewWidth = lv_disciplinas.Columns[e.ColumnIndex].Width;
        }

        private void lv_listaTurmas_ColumnWidthChanging(object sender, ColumnWidthChangingEventArgs e)
        {
            e.Cancel = true;
            e.NewWidth = lv_listaTurmas.Columns[e.ColumnIndex].Width;
        }

        private void lv_alunos_ColumnWidthChanging(object sender, ColumnWidthChangingEventArgs e)
        {
            e.Cancel = true;
            e.NewWidth = lv_alunos.Columns[e.ColumnIndex].Width;
        }

        #endregion

        /// <summary>
        /// Evento que abre um form para adicionar disciplinas à turma
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_novaDisciplina_Click(object sender, EventArgs e)
        {
            _form_novaDisciplina = new form_novaDisciplina(this);
            _form_novaDisciplina.Show();
            this.Enabled = false;
        }

        /// <summary>
        /// Evento que abre um form para adicionar alunos à turma
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_adicionarAluno_Click(object sender, EventArgs e)
        {
            _form_adicionaAluno = new form_adicionaAluno(this);
            _form_adicionaAluno.Show();
            this.Enabled = false;
        }

        /// <summary>
        /// Evento que atualiza os campos com a informação da turma selecionada
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lv_listaTurmas_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            LimpaCampos();
            CarregaInfoTurma();
        }

        /// <summary>
        /// Evento que guarda as informações da turma
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_guardar_Click(object sender, EventArgs e)
        {
            // Verificar se todos os campos estão preenchidos
            if (cb_diretorTurma.Text == "" || tb_turma.Text == "" || tb_curso.Text == "" || lv_disciplinas.Items.Count == 0 || lv_alunos.Items.Count == 0)
            {
                MessageBox.Show("Preencha todos os campos antes de guardar as alterações", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            // Se todos os campos estiverem preenchidos
            if (cb_diretorTurma.Text != "" && tb_turma.Text != "" && tb_curso.Text != "" && lv_disciplinas.Items.Count > 0 && lv_alunos.Items.Count > 0)
            {
                if (lv_listaTurmas.SelectedItems.Count == 1) // Se houver alguma turma selecionada
                {
                    GuardarTurma(lv_listaTurmas.SelectedItems[0].SubItems[1].Text); // Atualiza o ficheiro da turma selecionada
                    LimpaCampos();
                }
                else
                {
                    bool existe = false;

                    foreach (ListViewItem item in lv_listaTurmas.Items)
                    {
                        if (item.SubItems[1].Text.ToLower() == tb_turma.Text.ToLower())
                        {
                            MessageBox.Show("Já existe uma turma com esse nome", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            existe = true;
                            break;
                        }
                    }

                    // Se não existir nenhuma turma com o novo nome (caso não esteja nenhuma turma selecionada)
                    if (!existe)
                    {
                        GuardarTurma(tb_turma.Text); // Cria a nova turma com o nome escolhido
                        LimpaCampos();
                    }
                }
            }
        }

        /// <summary>
        /// Evento que elimina a turma selecionada
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_eliminarTurma_Click(object sender, EventArgs e)
        {
            EliminarTurma();
        }

        /// <summary>
        /// Evento que remove as disciplinas selecionadas na lista de disciplinas da turma
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_removerDisciplina_Click(object sender, EventArgs e)
        {
            RemoverDisciplinas();
        }

        /// <summary>
        /// Evento que remove os alunos selecionados na lista de Alunos da turma
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_removerAluno_Click(object sender, EventArgs e)
        {
            RemoverAlunos();
        }

        /// <summary>
        /// Evento que fecha o form das turmas
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_voltar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Evento que mostra o form dos menus
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void form_Turmas_FormClosing(object sender, FormClosingEventArgs e)
        {
            _form_Menus.Show();
        }

        /// <summary>
        /// Evento que vai atualizando a data e hora nas labels
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            lbl_data.Text = "Ano Letivo: " + DateTime.Now.Year.ToString() + "/" + DateTime.Now.AddYears(1).Year.ToString();
            lbl_horas.Text = "Horas: " + DateTime.Now.ToLongTimeString();
        }

        #endregion

        #region Métodos        

        /// <summary>
        /// Guarda a nova turma e as suas informações num ficheiro txt e adiciona-a à lista de turmas. Caso o txt exista, apaga-o e cria um novo com as novas informações
        /// </summary>
        private void GuardarTurma(string nomeAntigo) // Passo-lhe este parametro para guardar o nome da turma antes da edição, para depois apagar o ficheiro correspondente
        {
            string ficheiroAntigo = @"Turmas/" + nomeAntigo + ".txt";

            // Apaga o antigo caso exista
            if (File.Exists(ficheiroAntigo))
            {
                File.Delete(ficheiroAntigo);
            }

            // Cria um novo objeto turma
            Turma novaTurma = new Turma
            {
                Nome = tb_turma.Text,
                Curso = tb_curso.Text,
                DiretorTurma = new Professor { Nome = cb_diretorTurma.Text },
                Disciplinas = new List<Disciplina>(),
                Alunos = new List<Aluno>()
            };

            // Adiciona as disciplinas à lista de disciplinas da Turma
            foreach (ListViewItem item in lv_disciplinas.Items)
            {
                Disciplina disciplina = new Disciplina
                {
                    Nome = item.SubItems[1].Text
                };

                novaTurma.Disciplinas.Add(disciplina);
            }

            // Mesma lógica de cima mas para os alunos
            foreach (ListViewItem item in lv_alunos.Items)
            {
                Aluno aluno = new Aluno
                {
                    Nome = item.SubItems[1].Text
                };

                novaTurma.Alunos.Add(aluno);
            }

            // Caminho do novo ficheiro de texto com o nome escolhido
            string ficheiroNovo = @"Turmas/" + novaTurma.Nome + ".txt";

            string linhaDisciplinas = "";

            // Contador auxiliar para determinar se estamos no primeiro campo a adicionar ou não
            int contaCampo = 1;

            // Vai criar uma string correspondente à linha no txt com todas as disciplinas
            foreach (Disciplina disciplina in novaTurma.Disciplinas)
            {
                if (contaCampo == 1) // Primeiro elemento
                {
                    linhaDisciplinas += disciplina.Nome; // Adiciona-o à linha sem o ;
                    contaCampo++;
                }
                else
                {
                    linhaDisciplinas += ";" + disciplina.Nome; // Adiciona os restantes com ; antes
                }
            }

            // Mesma lógica de cima mas para os alunos
            string linhaAlunos = "";
            contaCampo = 1;
            foreach (Aluno aluno in novaTurma.Alunos)
            {
                if (contaCampo == 1)
                {
                    linhaAlunos += aluno.Nome;                    
                    contaCampo++;
                }
                else
                {
                    linhaAlunos += ";" + aluno.Nome;
                }

                InscreverAluno(aluno);
            }

            // turma;curso
            // diretor de turma
            // disciplina;disciplina;disciplina...
            // aluno;aluno;aluno;aluno...
            string info = $"{novaTurma.Nome};{novaTurma.Curso}" +
                $"\n{novaTurma.DiretorTurma.Nome}" +
                $"\n{linhaDisciplinas}" +
                $"\n{linhaAlunos}";

            StreamWriter sw = new StreamWriter(ficheiroNovo, false);
            // False - escreve por cima
            // True - mantém o que lá está e adiciona mais texto

            if (!File.Exists(ficheiroNovo)) // Se o ficheiro não existir
            {
                sw = File.CreateText(ficheiroNovo); // Cria o ficheiro                
            }

            sw.Write(info); // Escreve no ficheiro criado
            sw.Close(); // Fecha o ficheiro

            AdicionaTurmaLista(nomeAntigo,novaTurma);
        }

        /// <summary>
        /// Verifica quais os professores que existem, e adiciona-os à comboBox
        /// </summary>
        private void PreencherComboBox()
        {
            foreach (var ficheiro in Directory.GetFiles(@"Professores/", "*.txt"))
            {
                string professor = Path.GetFileNameWithoutExtension(ficheiro);

                cb_diretorTurma.Items.Add(professor);
            }
        }

        /// <summary>
        /// Após criar ou atualizar uma turma, atualiza a lista de turmas, adicionando ou alterando a linha correspondente
        /// </summary>
        /// <param name="turma"></param>
        private void AdicionaTurmaLista(string turmaAntiga, Turma turmaNova)
        {
            string[] linha = { "", turmaNova.Nome, turmaNova.Curso };

            ListViewItem itemNovo = new ListViewItem(linha);

            // Se houver items na lista
            if (lv_listaTurmas.Items.Count > 0)
            {
                bool alterado = false;

                foreach (ListViewItem item in lv_listaTurmas.Items)
                {
                    // Se existir algum item da lista com o mesmo nome da turma criada
                    if (item.SubItems[1].Text == turmaAntiga)
                    {
                        item.SubItems[1].Text = itemNovo.SubItems[1].Text;
                        item.SubItems[2].Text = itemNovo.SubItems[2].Text;
                        alterado = true;
                        break;
                    }
                }

                if (alterado == false)
                {
                    // Se não existir nenhuma correspondencia                    
                    lv_listaTurmas.Items.Add(itemNovo); // Adiciona o novo item                    
                }
            }
            // Se não houver items na lista
            else
            {
                lv_listaTurmas.Items.Add(itemNovo); // Adiciona o novo item
            }
        }

        /// <summary>
        /// Se houver turmas criadas, carrega-as para a listview
        /// </summary>
        private void CarregaTurmas()
        {
            foreach (var file in Directory.GetFiles(@"Turmas/", "*.txt"))
            {
                if (File.Exists(file))
                {
                    // Lê a primeira linha do txt que contem -> Turma;Curso;DiretorTurma
                    string linha = " ;" + File.ReadLines(file).Skip(0).Take(1).First();
                    string[] campos = new string[2];
                    campos = linha.Split(';');

                    ListViewItem item = new ListViewItem(campos);

                    lv_listaTurmas.Items.Add(item);
                }
            }
        }

        /// <summary>
        /// Selecionando uma turma, carrega as respetivas informações para os campos
        /// </summary>
        private void CarregaInfoTurma()
        {
            // Se houver uma turma selecionada
            if (lv_listaTurmas.SelectedItems.Count == 1)
            {
                string ficheiro = $@"Turmas/{lv_listaTurmas.SelectedItems[0].SubItems[1].Text}.txt";

                // Se existir um ficheiro da turma escolhida
                if (File.Exists(ficheiro))
                {
                    // Lê a primeira linha - Nome da Turma e Curso
                    string primeiraLinha = File.ReadLines(ficheiro).Skip(0).Take(1).First();
                    
                    // Conta quantos elementos há na linha
                    int tamanho = primeiraLinha.Split(';').Length;

                    // Define um array com base no número de elementos da linha
                    string[] campos = new string[tamanho - 1];

                    // Passa os elementos da linha para o array
                    campos = primeiraLinha.Split(';');
                    tb_turma.Text = campos[0];
                    tb_curso.Text = campos[1];


                    // Lê a segunda linha - Diretor de Turma
                    string segundaLinha = File.ReadLines(ficheiro).Skip(1).Take(1).First();
                    cb_diretorTurma.Text = segundaLinha;


                    // Lê a terceira linha - Disciplinas
                    string terceiraLinha = File.ReadLines(ficheiro).Skip(2).Take(1).First();

                    // Conta quantos elementos há na linha
                    tamanho = terceiraLinha.Split(';').Length;

                    // Define um array com base no número de elementos da linha
                    campos = new string[tamanho - 1];

                    // Passa os elementos da linha para o array
                    campos = terceiraLinha.Split(';');

                    // Preenche a tabela de disciplinas
                    foreach (var campo in campos)
                    {                 
                        // O primeiro campo está vazio porque a primeira coluna da tabela está oculta
                        // Por causa do alinhamento de texto que não funciona, dai ter ocultado
                        string[] linha = { "" , campo };
                        ListViewItem item = new ListViewItem(linha);
                        lv_disciplinas.Items.Add(item);
                    }


                    // Lê a quarta linha - Alunos
                    string quartaLinha = File.ReadLines(ficheiro).Skip(3).Take(1).First();

                    // Conta quantos elementos há na linha
                    tamanho = quartaLinha.Split(';').Length;

                    // Define um array com base no número de elementos da linha
                    campos = new string[tamanho - 1];

                    // Passa os elementos da linha para o array
                    campos = quartaLinha.Split(';');

                    // Preenche a tabela de disciplinas
                    foreach (var campo in campos)
                    {
                        // O primeiro campo está vazio porque a primeira coluna da tabela está oculta
                        // Por causa do alinhamento de texto que não funciona, dai ter ocultado
                        string[] linha = { "", campo };
                        ListViewItem item = new ListViewItem(linha);
                        lv_alunos.Items.Add(item);
                    }
                }
            }
        }

        /// <summary>
        /// Elimina a turma selecionada da tabela e o respetivo ficheiro txt
        /// </summary>
        private void EliminarTurma()
        {
            // Selecionando uma turma
            if (lv_listaTurmas.SelectedItems.Count == 1)
            {
                // Aparece uma mensagem para confirmar a eliminação
                if (MessageBox.Show("Deseja eliminar a turma selecionada?", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    foreach (ListViewItem item in lv_listaTurmas.SelectedItems)
                    {
                        // Exemplo -> CET57.txt
                        string ficheiro = @"Turmas/" + item.SubItems[1].Text + ".txt";                        

                        // Se existir um ficheiro da turma escolhida
                        if (File.Exists(ficheiro))
                        {      
                            // Lê a quarta linha - Alunos
                            string quartaLinha = File.ReadLines(ficheiro).Skip(3).Take(1).First();

                            // Conta quantos elementos há na linha
                            int tamanho = quartaLinha.Split(';').Length;

                            // Define um array com base no número de elementos da linha
                            string[] campos = new string[tamanho - 1];

                            // Passa os elementos da linha para o array
                            campos = quartaLinha.Split(';');

                            // Move os alunos da turma, para a pasta de Alunos sem Turma
                            foreach (var campo in campos)
                            {
                                string aluno = @"Turmas/Alunos com Turma/" + campo + ".txt";
                                string destino = @"Turmas/Alunos sem Turma/" + campo + ".txt";
                                File.Move(aluno, destino);
                            }

                            // Apaga o ficheiro da turma
                            File.Delete(ficheiro);
                        }

                        item.Remove(); // Remove-o da listView
                    }
                }
            }
            else // Se não tiver nenhuma turma selecionada
            {
                MessageBox.Show("Selecione a turma que pretende eliminar!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Remove as disciplinas selecionadas na tabela
        /// </summary>
        private void RemoverDisciplinas()
        {
            if (lv_disciplinas.SelectedItems.Count >= 1) // Se tiver uma ou mais disciplinas selecionadas
            {
                // Aparece uma mensagem para confirmar a eliminação das disciplinas
                if (MessageBox.Show("Deseja remover as disciplinas selecionadas?", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    foreach (ListViewItem item in lv_disciplinas.SelectedItems)
                    {
                        item.Remove(); // Remove da listView
                    }
                }
            }
            else // Se não tiver nenhuma disciplina selecionado
            {
                MessageBox.Show("Selecione pelo menos uma disciplina para removê-la!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        /// <summary>
        /// Remove os alunos selecionados na tabela
        /// </summary>
        private void RemoverAlunos()
        {
            if (lv_alunos.SelectedItems.Count >= 1) // Se tiver um ou mais alunos selecionados
            {
                // Aparece uma mensagem para confirmar a eliminação dos alunos
                if (MessageBox.Show("Deseja remover os alunos selecionados?", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    foreach (ListViewItem item in lv_alunos.SelectedItems)
                    {
                        // Move o ficheiro do aluno selecionado para a pasta de Alunos sem Turma
                        string ficheiro = $@"Turmas/Alunos com Turma/{item.SubItems[1].Text}.txt";
                        string destino = $@"Turmas/Alunos sem Turma/{item.SubItems[1].Text}.txt";

                        if (File.Exists(ficheiro))
                        {
                            File.Move(ficheiro, destino);
                        }                       

                        item.Remove(); // Remove-o da listView
                    }
                }
            }
            else // Se não tiver nenhum aluno selecionado
            {
                MessageBox.Show("Selecione pelo menos um aluno para removê-lo!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        /// <summary>
        /// Limpa todas informações da turma nos campos
        /// </summary>
        private void LimpaCampos()
        {
            cb_diretorTurma.Text = "";
            tb_turma.Text = "";
            tb_curso.Text = "";

            foreach (ListViewItem item in lv_disciplinas.Items)
            {
                item.Remove();
            }

            foreach (ListViewItem item in lv_alunos.Items)
            {
                item.Remove();
            }
        }

        /// <summary>
        /// Move o ficheiros txt do aluno para a pasta de Alunos com Turma
        /// </summary>
        private void InscreverAluno(Aluno aluno)
        {
            string ficheiro = @"Turmas/Alunos sem Turma/" + aluno.Nome + ".txt";
            string destino = @"Turmas/Alunos com Turma/" + aluno.Nome + ".txt";

            // Se não estiver inscrito (ficheiro não estiver na pasta)
            if (!File.Exists(destino))
            {
                File.Move(ficheiro, destino);
            }            
        }

        #endregion

        
    }
}
