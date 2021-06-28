using BibliotecaClasses;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace ProjetoEscola
{
    public partial class form_Alunos : Form
    {

        #region Atributos     

        private form_Menus _form_Menus;

        private List<Aluno> _alunos; // Definir uma lista para armazenar os alunos criados

        private Aluno _aluno;

        private Data _data;

        private int _contadorID; // Contador de Id automático dos Alunos

        #endregion

        #region Construtores

        public form_Alunos(form_Menus form_Menus)
        {
            InitializeComponent();
            LerInfoTxt();
            ContarID(_alunos);
            _form_Menus = form_Menus;
            this.Icon = ProjetoEscola.Properties.Resources.icon;            
        }

        #endregion

        #region Botões Principais

        /// <summary>
        /// Evento que mostra a GroupBox para criar o aluno
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_criarAluno_Click(object sender, EventArgs e)
        {
            GBCriarVisivel();
        }

        /// <summary>
        /// Evento que mostra a GroupBox para atualizar o aluno
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_atualizarAluno_Click(object sender, EventArgs e)
        {
            GBAtualizarVisivel();
        }

        /// <summary>
        /// Evento que elimina o/os aluno/os selecionado/os
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_eliminarAluno_Click(object sender, EventArgs e)
        {
            EliminarAlunos();
        }

        /// <summary>
        /// Evento que mostra o form de Menus e fecha o form dos alunos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_voltar_Click(object sender, EventArgs e)
        {
            _form_Menus.Show();
            this.Close();
        }

        #endregion

        #region Botões da Group Box 'Criar Aluno'

        /// <summary>
        /// Evento que cria um novo aluno utilizando as informações inseridas nos campos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_criar_Click(object sender, EventArgs e)
        {
            _data = new Data(dtp_criarData.Text);

            CriarAluno(tb_criarNome.Text, tb_criarMorada.Text, tb_criarTelemovel.Text, tb_criarEmail.Text, _data);
        }

        /// <summary>
        /// Evento que utiliza um método para limpar todas as TextBox contidas na GroupBox de criação de aluno
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_limpar_Click(object sender, EventArgs e)
        {
            LimparCampos(gb_criarAluno);
        }

        /// <summary>
        /// Evento que esconde a GroupBox de criação de alunos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            LimparCampos(gb_criarAluno);

            GBCriarVisivel();
        }

        #endregion

        #region Botões da Group Box 'Atualizar Aluno'

        /// <summary>
        /// Evento que atualiza as informações do aluno selecionado, utilizando as informações contidas nos campos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_atualizar_Click(object sender, EventArgs e)
        {
            _data = new Data(dtp_updateData.Text);

            string alunoAntigo = @"Alunos/" + lv_listaAlunos.SelectedItems[0].SubItems[1].Text + " " + lv_listaAlunos.SelectedItems[0].SubItems[2].Text + ".txt";
            string alunoAntigo2 = @"Turmas/Alunos sem Turma/" + lv_listaAlunos.SelectedItems[0].SubItems[1].Text + " " + lv_listaAlunos.SelectedItems[0].SubItems[2].Text + ".txt";
            string alunoAntigo3 = @"Turmas/Alunos com Turma/" + lv_listaAlunos.SelectedItems[0].SubItems[1].Text + " " + lv_listaAlunos.SelectedItems[0].SubItems[2].Text + ".txt";

            // Se os campos estiverem todos preenchidos e o número de telemóvel for válido
            if (VerificarGroupBox(tb_updateNome.Text, tb_updateMorada.Text, tb_updateTelemovel.Text, tb_updateEmail.Text, _data) && VerificarTelemovel(tb_updateTelemovel.Text))
            {
                // Atualiza o aluno selecionado na tabela
                lv_listaAlunos.SelectedItems[0].SubItems[1].Text = lbl_numero2.Text;
                lv_listaAlunos.SelectedItems[0].SubItems[2].Text = tb_updateNome.Text;
                lv_listaAlunos.SelectedItems[0].SubItems[3].Text = tb_updateMorada.Text;
                lv_listaAlunos.SelectedItems[0].SubItems[4].Text = tb_updateTelemovel.Text;
                lv_listaAlunos.SelectedItems[0].SubItems[5].Text = tb_updateEmail.Text;
                lv_listaAlunos.SelectedItems[0].SubItems[6].Text = _data.ToString();

                _aluno = new Aluno
                {
                    Id = Convert.ToInt32(lbl_numero2.Text),
                    Nome = tb_updateNome.Text,
                    Morada = tb_updateMorada.Text,
                    Telemovel = tb_updateTelemovel.Text,
                    Email = tb_updateEmail.Text,
                    DataNascimento = _data

                };
                
                if (File.Exists(alunoAntigo2))
                {
                    // Atualiza o txt do aluno
                    AtualizarTxt(alunoAntigo, _aluno, false);
                    AtualizarTxt(alunoAntigo2, _aluno, false);
                }


                if (File.Exists(alunoAntigo3))
                {
                    // Atualiza o txt do aluno
                    AtualizarTxt(alunoAntigo, _aluno, true);
                    AtualizarTxt(alunoAntigo3, _aluno, true);
                }                
            }
        }

        /// <summary>
        /// Evento que utiliza um método para limpar todas as TextBox contidas na GroupBox de atualização de dados
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_limpar2_Click(object sender, EventArgs e)
        {
            LimparCampos(gb_atualizarAluno);
        }

        /// <summary>
        /// Evento que esconde a GroupBox de atualização de dados
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_cancelar2_Click(object sender, EventArgs e)
        {
            btn_atualizar.Enabled = true;
            LimparCampos(gb_atualizarAluno);
            GBAtualizarVisivel();
        }

        #endregion

        #region Eventos

        /// <summary>
        /// Evento que passa as informações do aluno selecionado para os campos da GroupBox de edição. Caso seja selecionado mais do que um aluno, retorna uma mensagem
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lv_listaAlunos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (gb_atualizarAluno.Visible == true && lv_listaAlunos.SelectedItems.Count == 1)
            {
                lbl_numero2.Text = lv_listaAlunos.SelectedItems[0].SubItems[1].Text;
                tb_updateNome.Text = lv_listaAlunos.SelectedItems[0].SubItems[2].Text;
                tb_updateMorada.Text = lv_listaAlunos.SelectedItems[0].SubItems[3].Text;
                tb_updateTelemovel.Text = lv_listaAlunos.SelectedItems[0].SubItems[4].Text;
                tb_updateEmail.Text = lv_listaAlunos.SelectedItems[0].SubItems[5].Text;
                dtp_updateData.Text = lv_listaAlunos.SelectedItems[0].SubItems[6].Text;

                btn_atualizar.Enabled = true;
            }
            else if (gb_atualizarAluno.Visible == true && lv_listaAlunos.SelectedItems.Count > 1)
            {
                MessageBox.Show("Só pode editar um aluno de cada vez!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btn_atualizar.Enabled = false;
            }
        }

        /// <summary>
        /// Evento que enquanto o form de alunos é fechado, mostra o form de Menus
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void form_GerirAlunos_FormClosing(object sender, FormClosingEventArgs e)
        {
            _form_Menus.Show();
        }

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

        #endregion

        #region Métodos Auxiliares

        /// <summary>
        /// Se não existirem alunos criados, o contador (ID) de alunos começa a 1, senão começa depois do ultimo ID criado
        /// </summary>
        private void ContarID(List<Aluno> Alunos)
        {
            if (Alunos.Count == 0) // Se a lista estiver vazia
            {
                _contadorID = 1; // Contador começa a 1
            }
            else // Se tiver alunos
            {
                Aluno aluno = Alunos.ElementAt(Alunos.Count - 1); // Vai buscar o último aluno da lista
                _contadorID = aluno.Id + 1; // Contador de ID passa a ser o ID do ultimo aluno na lista +1
            }

            lbl_numero.Text = _contadorID.ToString();
        }

        /// <summary>
        /// Mostra a groupBox 'Criar Aluno' se estiver oculta, caso contrário esconde-a
        /// </summary>
        private void GBCriarVisivel()
        {
            if (gb_criarAluno.Visible == false)
            {
                gb_criarAluno.Visible = true;
                btn_criarAluno.Enabled = false;
                btn_atualizarAluno.Enabled = false;
                btn_eliminarAluno.Enabled = false;
                tb_criarNome.Focus(); // Coloca o cursor na caixa de texto Nome 
            }
            else
            {
                gb_criarAluno.Visible = false;
                btn_criarAluno.Enabled = true;
                btn_atualizarAluno.Enabled = true;
                btn_eliminarAluno.Enabled = true;
            }
        }

        /// <summary>
        /// Selecionando 1 item da tabela, mostra a groupBox 'Atualizar Aluno', caso contrário esconde-a.
        /// </summary>
        private void GBAtualizarVisivel()
        {
            if (gb_atualizarAluno.Visible == false)
            {
                if (_alunos.Count == 0) // Se não existirem alunos criados
                {
                    MessageBox.Show("Não existem alunos criados para serem editados!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (_alunos.Count != 0 && lv_listaAlunos.SelectedItems.Count == 0) // Se houver alunos mas não estiver selecionado
                {
                    MessageBox.Show("Selecione o aluno que quer atualizar!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (_alunos.Count != 0 && lv_listaAlunos.SelectedItems.Count == 1) // Quando é selecionado 1 aluno
                {
                    // Mostra a groupBox Criar Aluno e desativa os botões de adicionar, atualizar e eliminar Aluno
                    gb_atualizarAluno.Visible = true;
                    btn_criarAluno.Enabled = false;
                    btn_atualizarAluno.Enabled = false;
                    btn_eliminarAluno.Enabled = false;
                    tb_updateNome.Focus(); // Coloca o cursor na caixa de texto Nome

                    // Introduz as informações do aluno nas respetivas textBox para edição
                    lbl_numero2.Text = lv_listaAlunos.SelectedItems[0].SubItems[1].Text;
                    tb_updateNome.Text = lv_listaAlunos.SelectedItems[0].SubItems[2].Text;
                    tb_updateMorada.Text = lv_listaAlunos.SelectedItems[0].SubItems[3].Text;
                    tb_updateTelemovel.Text = lv_listaAlunos.SelectedItems[0].SubItems[4].Text;
                    tb_updateEmail.Text = lv_listaAlunos.SelectedItems[0].SubItems[5].Text;
                    dtp_updateData.Text = lv_listaAlunos.SelectedItems[0].SubItems[6].Text;
                }
                else // Quando existem alunos e é selecionado mais do que um aluno
                {
                    MessageBox.Show("Só pode atualizar um aluno de cada vez!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                gb_atualizarAluno.Visible = false;
                btn_criarAluno.Enabled = true;
                btn_atualizarAluno.Enabled = true;
                btn_eliminarAluno.Enabled = true;
            }

        }

        /// <summary>
        /// Elimina os alunos selecionados na tabela e atualiza o ficheiro txt e a lista
        /// </summary>
        private void EliminarAlunos()
        {
            if (lv_listaAlunos.SelectedItems.Count >= 1) // Se tiver um ou mais alunos selecionados
            {
                // Aparece uma mensagem para confirmar a eliminação dos alunos
                if (MessageBox.Show("Deseja eliminar os alunos selecionados?", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    foreach (ListViewItem item in lv_listaAlunos.SelectedItems)
                    {
                        string ficheiro = @"Alunos/" + item.SubItems[1].Text + " " + item.SubItems[2].Text + ".txt"; // 1 Pedro.txt
                        string ficheiro2 = @"Turmas/Alunos sem Turma/" + item.SubItems[1].Text + " " + item.SubItems[2].Text + ".txt";
                        string ficheiro3 = @"Turmas/Alunos com Turma/" + item.SubItems[1].Text + " " + item.SubItems[2].Text + ".txt";

                        if (File.Exists(ficheiro))
                        {
                            File.Delete(ficheiro);
                        }

                        if (File.Exists(ficheiro2))
                        {
                            File.Delete(ficheiro2);
                        }

                        // Se existir na pasta de Alunos com turma, temos que removê-lo da turma onde está inscrito
                        if (File.Exists(ficheiro3))
                        {
                            // Para cada ficheiro de turma criada
                            foreach (var file in Directory.GetFiles(@"Turmas/","*.txt"))
                            {
                                // Lê a quarta linha - Alunos
                                string quartaLinha = File.ReadLines(file).Skip(3).Take(1).First();

                                // Conta quantos elementos há na linha
                                int tamanho = quartaLinha.Split(';').Length;

                                // Define um array com base no número de elementos da linha
                                string[] campos = new string[tamanho - 1];

                                // Passa os elementos da linha para o array
                                campos = quartaLinha.Split(';');

                                string itemRemover = item.SubItems[1].Text + " " + item.SubItems[2].Text;

                                if (campos.Contains(itemRemover))
                                {
                                    // Remove o aluno da linha
                                    campos = campos.Where(x => x != itemRemover).ToArray();

                                    // Lê a linha a editar do ficheiro e guarda-a
                                    using (StreamReader reader = new StreamReader(file))
                                    {
                                        for (int i = 1; i <= 4; ++i)
                                        {
                                            string lineToWrite = reader.ReadLine();
                                        }
                                            
                                    }

                                    // Cria um array com o conteudo de todas as linhas do ficheiro
                                    string[] lines = File.ReadAllLines(file);

                                    using (StreamWriter writer = new StreamWriter(file))
                                    {
                                        for (int currentLine = 1; currentLine <= 4; currentLine++)
                                        {
                                            if (currentLine == 4) // Altera a linha dos alunos, removendo o aluno que foi eliminado
                                            {
                                                for (int i = 0; i < campos.Length; i++)
                                                {
                                                    if (i == campos.Length -1) // Quando chega ao ultimo elemento do array não coloca ;
                                                    {
                                                        writer.Write(campos[i]);
                                                    }
                                                    else // Escreve o campo + ; enquanto não chegar ao último elemento do array
                                                    {
                                                        writer.Write(campos[i] + ";");
                                                    }
                                                }                                                
                                            }
                                            else // Mantem as linhas anteriores
                                            {
                                                writer.WriteLine(lines[currentLine - 1]);
                                            }
                                        }
                                    }

                                    break; // Termina o ciclo foreach
                                }
                            }

                            File.Delete(ficheiro3);
                        }

                        item.Remove(); // Remove-o da listView
                    }                    
                }
            }
            else // Se não tiver nenhum aluno selecionado
            {
                MessageBox.Show("Selecione pelo menos um aluno para eliminá-lo!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Cria um aluno novo, adicionando as suas informações à tabela e à lista
        /// </summary>
        private void CriarAluno(string nome, string morada, string telemovel, string email, Data data)
        {
            if (VerificarGroupBox(nome, morada, telemovel, email, data) && VerificarTelemovel(telemovel)) // Se todos os campos estiverem preenchidos e o telemovel for válido
            {
                // Cria um novo aluno
                _aluno = new Aluno
                {
                    Id = _contadorID,
                    Nome = nome,
                    Morada = morada,
                    Telemovel = telemovel,
                    Email = email,
                    DataNascimento = data                    
                };                             

                // Gravar aluno novo no ficheiro txt
                CriarTxt(_aluno,false);

                // Adiciona o aluno criado à lista Alunos
                _alunos.Add(_aluno);

                // Adiciona o aluno à tabela
                AdicionarLinha(_aluno);

                // Incrementa ao contador de ids
                _contadorID++;

                // Atualiza o ID na label
                lbl_numero.Text = _contadorID.ToString();
            }
        }

        /// <summary>
        /// Verifica se todos os campos da group box estão preenchidos
        /// </summary>
        /// <returns></returns>
        private bool VerificarGroupBox(string nome, string morada, string telemovel, string email, Data data)
        {
            bool output = true;

            if (string.IsNullOrEmpty(nome) || string.IsNullOrEmpty(morada) || string.IsNullOrEmpty(telemovel) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(data.ToString()))
            {
                MessageBox.Show("Preencha todos os campos antes de submeter as alterações!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                output = false;
            }

            return output;
        }

        /// <summary>
        /// Verifica se o número inserido na textBox é válido
        /// </summary>
        /// <param name="textBox"></param>
        /// <returns></returns>
        private bool VerificarTelemovel(string telemovel)
        {
            int numero;

            if (int.TryParse(telemovel, out numero) && telemovel.Length == 9)
            {
                return true;
            }
            else
            {
                MessageBox.Show("Número de telemóvel inválido!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        /// <summary>
        /// Caso exista, lês as informações do ficheiro txt e preenche a tabela e a lista de alunos
        /// </summary>
        private List<Aluno> LerInfoTxt()
        {
            _alunos = new List<Aluno>(); // Criar uma nova lista vazia

            foreach (var ficheiro in Directory.GetFiles(@"Alunos/","*.txt"))
            {
                StreamReader sr;

                if (File.Exists(ficheiro)) // Se o ficheiro existir, ele vai preencher a tabela e cria uma lista com os alunos todos
                {
                    sr = File.OpenText(ficheiro);

                    string linha = "";

                    while ((linha = sr.ReadLine()) != null) // Até que a linha "seja nula"/não tenha nada escrito
                    {
                        // Atualizar informação na tabela
                        //id;nome;morada;telemovel;email;dataNascimento
                        string[] campos = new string[6]; // 6 porque são 6 campos/informações diferentes

                        campos = linha.Split(';'); // Caracter que vai separar as informações -> ;

                        _data = new Data(campos[5]);

                        // Criar novo aluno e passar-lhe as várias informações para as propriedades (presentes na linha) para depois adicioná-lo à lista
                        Aluno novoAluno = new Aluno();
                        novoAluno.Id = Convert.ToInt32(campos[0]);
                        novoAluno.Nome = campos[1];
                        novoAluno.Morada = campos[2];
                        novoAluno.Telemovel = campos[3];
                        novoAluno.Email = campos[4];
                        novoAluno.DataNascimento = _data;

                        _alunos.Add(novoAluno); // Adicionar o novo aluno à lista
                        AdicionarLinha(novoAluno); // Adicionar o novo aluno à tabela
                    }

                    sr.Close(); // Fecha o documento
                }
            }                       

            return _alunos; // Retorna a lista após criada (com ou sem valores)
        }

        /// <summary>
        /// Cria um ficheiro txt com as informações do aluno
        /// </summary>
        /// <param name="novoAluno">Aluno</param>
        /// <param name="temTurma">Se tem ou não turma</param>
        private void CriarTxt(Aluno novoAluno, bool temTurma)
        {
            // Criar um txt para guardar as informações do aluno
            string ficheiro = @$"Alunos/{novoAluno.ToString()}.txt";
            string ficheiro2 = @$"Turmas/Alunos sem Turma/{novoAluno.ToString()}.txt";
            string ficheiro3 = @$"Turmas/Alunos com Turma/{novoAluno.ToString()}.txt";


            //id;nome;morada;telemovel;email;dataNascimento
            string info = $"{novoAluno.Id};{novoAluno.Nome};{novoAluno.Morada};{novoAluno.Telemovel};{novoAluno.Email};{novoAluno.DataNascimento}";

            if (temTurma == false) // Se o aluno a criar/atualizar não tiver turma
            {
                // Criar referência para o objeto
                StreamWriter sw = new StreamWriter(ficheiro, false);
                StreamWriter sw2 = new StreamWriter(ficheiro2, false);
                // False - escreve por cima
                // True - mantém o que lá está e adiciona mais texto

                if (!File.Exists(ficheiro)) // Se o ficheiro não existir
                {
                    sw = File.CreateText(ficheiro); // Cria o ficheiro
                }

                if (!File.Exists(ficheiro2)) 
                {
                    sw2 = File.CreateText(ficheiro2); 
                }

                sw.Write(info); // Escreve no ficheiro criado
                sw2.Write(info);

                sw.Close(); // Fecha o ficheiro
                sw2.Close();
            }

            if (temTurma) // Se já tiver turma
            {
                // Criar referência para o objeto
                StreamWriter sw = new StreamWriter(ficheiro, false);
                StreamWriter sw3 = new StreamWriter(ficheiro3, false);
                // False - escreve por cima
                // True - mantém o que lá está e adiciona mais texto

                if (!File.Exists(ficheiro)) // Se o ficheiro não existir
                {
                    sw = File.CreateText(ficheiro); // Cria o ficheiro
                }

                if (!File.Exists(ficheiro3)) 
                {
                    sw3 = File.CreateText(ficheiro3); 
                }

                sw.Write(info); // Escreve no ficheiro criado
                sw3.Write(info);

                sw.Close(); // Fecha o ficheiro
                sw3.Close();
            }
        }

        /// <summary>
        /// Adiciona uma nova linha à tabela
        /// </summary>
        /// <param name="novoAluno"></param>
        private void AdicionarLinha(Aluno novoAluno)
        {
            // Criar um array que representa a linha a adicionar
            string[] linha = { "", novoAluno.Id.ToString(), novoAluno.Nome, novoAluno.Morada, novoAluno.Telemovel, novoAluno.Email, novoAluno.DataNascimento.ToString() };

            // Criar o objeto item que contem a informação inserida na linha
            ListViewItem item = new ListViewItem(linha);

            // Adicionar o item/linha à tabela de Alunos
            lv_listaAlunos.Items.Add(item);
        }

        /// <summary>
        /// Limpa todas as textBox da groupBox
        /// </summary>
        /// <param name="groupBox"></param>
        /// <param name="tb_telemovel"></param>
        private void LimparCampos(GroupBox groupBox)
        {
            foreach (TextBox textBox in groupBox.Controls.OfType<TextBox>())
            {
                textBox.ResetText();
            }
        }

        /// <summary>
        /// Atualiza o txt do aluno selecionado, apagando o antigo e criando um novo
        /// </summary>
        /// <param name="alunoAntigo">Caminho do ficheiro antigo</param>
        /// <param name="alunoNovo">Aluno novo</param>
        /// <param name="temTurma">Se tem ou não turma</param>
        private void AtualizarTxt(string alunoAntigo, Aluno alunoNovo,bool temTurma)
        {
            if (File.Exists(alunoAntigo))
            {
                File.Delete(alunoAntigo);
            }

            CriarTxt(alunoNovo,temTurma);
        }

        #endregion
        
    }
}



