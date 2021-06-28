using BibliotecaClasses;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace ProjetoEscola
{
    public partial class form_Professores : Form
    {
        #region Atributos

        private form_Menus _form_Menus;

        private List<Professor> _professores;

        private Professor _professor;

        private Data _data;

        private int _contadorID;

        #endregion

        #region Construtores

        public form_Professores(form_Menus form_Menus)
        {
            InitializeComponent();
            _form_Menus = form_Menus;
            this.Icon = ProjetoEscola.Properties.Resources.icon;
            LerInfoTxt();
            ContarID(_professores);
        }

        #endregion

        #region Botões Principais

        /// <summary>
        /// Evento que mostra a GroupBox para criar o professor
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_criarProfessor_Click(object sender, EventArgs e)
        {
            GBCriarVisivel();
        }

        /// <summary>
        /// Evento que mostra a GroupBox para atualizar o professor
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_atualizarProfessor_Click(object sender, EventArgs e)
        {
            GBAtualizarVisivel();
        }

        /// <summary>
        /// Evento que elimina o/os professor/es selecionado/os
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_eliminarProfessor_Click(object sender, EventArgs e)
        {
            EliminarProfessores();
        }

        /// <summary>
        /// Evento que mostra o form de Menus e fecha o form dos professores
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_voltar_Click(object sender, EventArgs e)
        {
            _form_Menus.Show();
            this.Close();
        }

        #endregion

        #region Botões da Group Box 'Criar Professor'

        /// <summary>
        /// Evento que cria um novo professor utilizando as informações inseridas nos campos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_criar_Click(object sender, EventArgs e)
        {
            _data = new Data(dtp_criarData.Text);

            CriarProfessor(tb_criarNome.Text, tb_criarMorada.Text, tb_criarTelemovel.Text, tb_criarEmail.Text, _data);
        }

        /// <summary>
        /// Evento que utiliza um método para limpar todas as TextBox contidas na GroupBox de criação de professor
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_limpar_Click(object sender, EventArgs e)
        {
            LimparCampos(gb_criarProfessor);
        }

        /// <summary>
        /// Evento que esconde a GroupBox de criação de professores
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            LimparCampos(gb_criarProfessor);
            GBCriarVisivel();
        }

        #endregion

        #region Botões da Group Box 'Atualizar Professor'

        /// <summary>
        /// Evento que atualiza as informações do professor selecionado, utilizando as informações contidas nos campos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_atualizar_Click(object sender, EventArgs e)
        {
            _data = new Data(dtp_updateData.Text);

            string professorAntigo = @"Professores/" + lv_listaProfessores.SelectedItems[0].SubItems[1].Text + " " + lv_listaProfessores.SelectedItems[0].SubItems[2].Text + ".txt";


            // Se os campos estiverem todos preenchidos e o número de telemóvel for válido
            if (VerificarGroupBox(tb_updateNome.Text, tb_updateMorada.Text, tb_updateTelemovel.Text, tb_updateEmail.Text, _data) && VerificarTelemovel(tb_updateTelemovel.Text))
            {
                // Atualiza o professor selecionado na tabela
                lv_listaProfessores.SelectedItems[0].SubItems[1].Text = lbl_numero2.Text;
                lv_listaProfessores.SelectedItems[0].SubItems[2].Text = tb_updateNome.Text;
                lv_listaProfessores.SelectedItems[0].SubItems[3].Text = tb_updateMorada.Text;
                lv_listaProfessores.SelectedItems[0].SubItems[4].Text = tb_updateTelemovel.Text;
                lv_listaProfessores.SelectedItems[0].SubItems[5].Text = tb_updateEmail.Text;
                lv_listaProfessores.SelectedItems[0].SubItems[6].Text = _data.ToString();

                _professor = new Professor
                {
                    Id = Convert.ToInt32(lbl_numero2.Text),
                    Nome = tb_updateNome.Text,
                    Morada = tb_updateMorada.Text,
                    Telemovel = tb_updateTelemovel.Text,
                    Email = tb_updateEmail.Text,
                    DataNascimento = _data
                };

                // Atualiza o txt do professor
                AtualizarTxt(professorAntigo,_professor);
            }
        }

        /// <summary>
        /// Evento que utiliza um método para limpar todas as TextBox contidas na GroupBox de atualização de dados
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_limpar2_Click(object sender, EventArgs e)
        {
            LimparCampos(gb_atualizarProfessor);
        }

        /// <summary>
        /// Evento que esconde a GroupBox de atualização de dados
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_cancelar2_Click(object sender, EventArgs e)
        {
            btn_atualizar.Enabled = true;
            LimparCampos(gb_atualizarProfessor);
            GBAtualizarVisivel();
        }

        #endregion

        #region Eventos

        /// <summary>
        /// Evento que passa as informações do professor selecionado para os campos da GroupBox de edição. Caso seja selecionado mais do que um professor, retorna uma mensagem
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lv_listaProfessores_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (gb_atualizarProfessor.Visible == true && lv_listaProfessores.SelectedItems.Count == 1)
            {
                lbl_numero2.Text = lv_listaProfessores.SelectedItems[0].SubItems[1].Text;
                tb_updateNome.Text = lv_listaProfessores.SelectedItems[0].SubItems[2].Text;
                tb_updateMorada.Text = lv_listaProfessores.SelectedItems[0].SubItems[3].Text;
                tb_updateTelemovel.Text = lv_listaProfessores.SelectedItems[0].SubItems[4].Text;
                tb_updateEmail.Text = lv_listaProfessores.SelectedItems[0].SubItems[5].Text;
                dtp_updateData.Text = lv_listaProfessores.SelectedItems[0].SubItems[6].Text;

                btn_atualizar.Enabled = true;
            }
            else if (gb_atualizarProfessor.Visible == true && lv_listaProfessores.SelectedItems.Count > 1)
            {
                MessageBox.Show("Só pode editar um professor de cada vez!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btn_atualizar.Enabled = false;
            }
        }

        /// <summary>
        /// Evento que enquanto o form de professores é fechado, mostra o form de Menus
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void form_GerirProfessores_FormClosing(object sender, FormClosingEventArgs e)
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
        /// Caso exista, lês as informações do ficheiro txt e preenche a tabela e a lista de professores
        /// </summary>
        private List<Professor> LerInfoTxt()
        {
            _professores = new List<Professor>(); // Criar uma nova lista vazia

            foreach (var ficheiro in Directory.GetFiles(@"Professores/", "*.txt"))
            {
                StreamReader sr;

                if (File.Exists(ficheiro)) // Se o ficheiro existir, ele vai preencher a tabela e cria uma lista com os professores todos
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

                        // Criar novo professor e passar-lhe as várias informações para as propriedades (presentes na linha) para depois adicioná-lo à lista
                        Professor novoProfessor = new Professor();
                        novoProfessor.Id = Convert.ToInt32(campos[0]);
                        novoProfessor.Nome = campos[1];
                        novoProfessor.Morada = campos[2];
                        novoProfessor.Telemovel = campos[3];
                        novoProfessor.Email = campos[4];
                        novoProfessor.DataNascimento = _data;

                        _professores.Add(novoProfessor); // Adicionar o novo professor à lista
                        AdicionarLinha(novoProfessor); // Adicionar o novo professor à tabela
                    }

                    sr.Close(); // Fecha o documento
                }
            }

            return _professores; // Retorna a lista após criada (com ou sem valores)
        }

        /// <summary>
        /// Adiciona uma nova linha à tabela
        /// </summary>
        /// <param name="novoProfessor"></param>
        private void AdicionarLinha(Professor novoProfessor)
        {
            // Criar um array que representa a linha a adicionar
            string[] linha = { "", novoProfessor.Id.ToString(), novoProfessor.Nome, novoProfessor.Morada, novoProfessor.Telemovel, novoProfessor.Email, novoProfessor.DataNascimento.ToString() };

            // Criar o objeto item que contem a informação inserida na linha
            ListViewItem item = new ListViewItem(linha);

            // Adicionar o item/linha à tabela de Professores
            lv_listaProfessores.Items.Add(item);
        }

        /// <summary>
        /// Se não existirem professores criados, o contador (ID) de professores começa a 1, senão começa depois do ultimo ID criado
        /// </summary>
        private void ContarID(List<Professor> Professores)
        {
            if (Professores.Count == 0) // Se a lista estiver vazia
            {
                _contadorID = 1; // Contador começa a 1
            }
            else // Se tiver professores
            {
                Professor professor = Professores.ElementAt(Professores.Count - 1); // Vai buscar o último professor da lista
                _contadorID = professor.Id + 1; // Contador de ID passa a ser o ID do ultimo professor na lista +1
            }

            lbl_numero.Text = _contadorID.ToString();
        }

        /// <summary>
        /// Mostra a groupBox 'Criar Professor' se estiver oculta, caso contrário esconde-a
        /// </summary>
        private void GBCriarVisivel()
        {
            if (gb_criarProfessor.Visible == false)
            {
                gb_criarProfessor.Visible = true;
                btn_criarProfessor.Enabled = false;
                btn_atualizarProfessor.Enabled = false;
                btn_eliminarProfessor.Enabled = false;
                tb_criarNome.Focus(); // Coloca o cursor na caixa de texto Nome 
            }
            else
            {
                gb_criarProfessor.Visible = false;
                btn_criarProfessor.Enabled = true;
                btn_atualizarProfessor.Enabled = true;
                btn_eliminarProfessor.Enabled = true;
            }
        }

        /// <summary>
        /// Selecionando 1 item da tabela, mostra a groupBox 'Atualizar Professor', caso contrário esconde-a.
        /// </summary>
        private void GBAtualizarVisivel()
        {
            if (gb_atualizarProfessor.Visible == false)
            {
                if (_professores.Count == 0) // Se não existirem professores criados
                {
                    MessageBox.Show("Não existem professores criados para serem editados!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (_professores.Count != 0 && lv_listaProfessores.SelectedItems.Count == 0) // Se houver professores mas não estiver selecionado
                {
                    MessageBox.Show("Selecione o professor que quer atualizar!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (_professores.Count != 0 && lv_listaProfessores.SelectedItems.Count == 1) // Quando é selecionado 1 professor
                {
                    // Mostra a groupBox Criar Professor e desativa os botões de adicionar, atualizar e eliminar Professor
                    gb_atualizarProfessor.Visible = true;
                    btn_criarProfessor.Enabled = false;
                    btn_atualizarProfessor.Enabled = false;
                    btn_eliminarProfessor.Enabled = false;
                    tb_updateNome.Focus(); // Coloca o cursor na caixa de texto Nome

                    // Introduz as informações do professor nas respetivas textBox para edição
                    lbl_numero2.Text = lv_listaProfessores.SelectedItems[0].SubItems[1].Text;
                    tb_updateNome.Text = lv_listaProfessores.SelectedItems[0].SubItems[2].Text;
                    tb_updateMorada.Text = lv_listaProfessores.SelectedItems[0].SubItems[3].Text;
                    tb_updateTelemovel.Text = lv_listaProfessores.SelectedItems[0].SubItems[4].Text;
                    tb_updateEmail.Text = lv_listaProfessores.SelectedItems[0].SubItems[5].Text;
                    dtp_updateData.Text = lv_listaProfessores.SelectedItems[0].SubItems[6].Text;
                }
                else // Quando existem professores e é selecionado mais do que um professor
                {
                    MessageBox.Show("Só pode atualizar um professor de cada vez!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                gb_atualizarProfessor.Visible = false;
                btn_criarProfessor.Enabled = true;
                btn_atualizarProfessor.Enabled = true;
                btn_eliminarProfessor.Enabled = true;
            }

        }

        /// <summary>
        /// Elimina os professores selecionados na tabela e atualiza o ficheiro txt e a lista
        /// </summary>
        private void EliminarProfessores()
        {
            if (lv_listaProfessores.SelectedItems.Count >= 1) // Se tiver um ou mais professores selecionados
            {
                // Aparece uma mensagem para confirmar a eliminação dos professores
                if (MessageBox.Show("Deseja eliminar os professores selecionados?", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    foreach (ListViewItem item in lv_listaProfessores.SelectedItems)
                    {
                        string ficheiro = @"Professores/" + item.SubItems[1].Text + " " + item.SubItems[2].Text + ".txt"; // 1 Pedro.txt

                        if (File.Exists(ficheiro))
                        {
                            File.Delete(ficheiro);
                        }

                        item.Remove(); // Remove-o da listView
                    }
                }
            }
            else // Se não tiver nenhum professor selecionado
            {
                MessageBox.Show("Selecione pelo menos um professor para eliminá-lo!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Atualiza o txt do professor selecionado, apagando o antigo e criando um novo
        /// </summary>
        private void AtualizarTxt(string professorAntigo, Professor professorNovo)
        {
            if (File.Exists(professorAntigo))
            {
                File.Delete(professorAntigo);
            }

            CriarTxt(professorNovo);
        }

        /// <summary>
        /// Cria um professor novo, adicionando as suas informações à tabela e à lista
        /// </summary>
        private void CriarProfessor(string nome, string morada, string telemovel, string email, Data data)
        {
            // Se todos os campos estiverem preenchidos e o telemovel for válido
            if (VerificarGroupBox(nome, morada, telemovel, email, data) && VerificarTelemovel(telemovel)) 
            {
                // Cria um novo professor
                _professor = new Professor
                {
                    Id = _contadorID,
                    Nome = nome,
                    Morada = morada,
                    Telemovel = telemovel,
                    Email = email,
                    DataNascimento = data
                };

                // Gravar professor novo no ficheiro txt
                CriarTxt(_professor);

                // Adiciona o professor criado à lista Professor
                _professores.Add(_professor);

                // Adiciona o professor à tabela
                AdicionarLinha(_professor);

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
        /// Grava a lista de professores num ficheiro de texto .txt
        /// </summary>
        private void CriarTxt(Professor novoProfessor)
        {
            // Criar um txt para guardar as infos dos professores
            string ficheiro = @$"Professores/{novoProfessor.ToString()}.txt";

            //id;nome;morada;telemovel;email;dataNascimento
            string info = $"{novoProfessor.Id};{novoProfessor.Nome};{novoProfessor.Morada};{novoProfessor.Telemovel};{novoProfessor.Email};{novoProfessor.DataNascimento}";

            // Criar referência para o objeto
            StreamWriter sw = new StreamWriter(ficheiro, true);
            // False - escreve por cima
            // True - mantém o que lá está e adiciona mais texto

            if (!File.Exists(ficheiro)) // Se o ficheiro não existir
            {
                sw = File.CreateText(ficheiro); // Cria o ficheiro
            }

            sw.Write(info); // Escreve no ficheiro criado
            sw.Close(); // Fecha o ficheiro
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

        #endregion        
    }
}
