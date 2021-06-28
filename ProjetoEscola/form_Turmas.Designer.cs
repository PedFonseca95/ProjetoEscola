
namespace ProjetoEscola
{
    partial class form_Turmas
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lv_listaTurmas = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.ch_turma = new System.Windows.Forms.ColumnHeader();
            this.ch_curso = new System.Windows.Forms.ColumnHeader();
            this.label13 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.btn_eliminarTurma = new System.Windows.Forms.Button();
            this.lv_disciplinas = new System.Windows.Forms.ListView();
            this.columnHeader = new System.Windows.Forms.ColumnHeader();
            this.ch_disciplina = new System.Windows.Forms.ColumnHeader();
            this.lv_alunos = new System.Windows.Forms.ListView();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.ch_aluno = new System.Windows.Forms.ColumnHeader();
            this.btn_removerDisciplina = new System.Windows.Forms.Button();
            this.btn_novaDisciplina = new System.Windows.Forms.Button();
            this.btn_adicionarAluno = new System.Windows.Forms.Button();
            this.btn_removerAluno = new System.Windows.Forms.Button();
            this.cb_diretorTurma = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_guardar = new System.Windows.Forms.Button();
            this.btn_voltar = new System.Windows.Forms.Button();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.label15 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel_disciplinas = new System.Windows.Forms.Panel();
            this.panel_alunos = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tb_turma = new System.Windows.Forms.TextBox();
            this.tb_curso = new System.Windows.Forms.TextBox();
            this.lbl_horas = new System.Windows.Forms.Label();
            this.lbl_data = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel_disciplinas.SuspendLayout();
            this.panel_alunos.SuspendLayout();
            this.SuspendLayout();
            // 
            // lv_listaTurmas
            // 
            this.lv_listaTurmas.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.ch_turma,
            this.ch_curso});
            this.lv_listaTurmas.FullRowSelect = true;
            this.lv_listaTurmas.GridLines = true;
            this.lv_listaTurmas.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lv_listaTurmas.HideSelection = false;
            this.lv_listaTurmas.Location = new System.Drawing.Point(-1, 97);
            this.lv_listaTurmas.MultiSelect = false;
            this.lv_listaTurmas.Name = "lv_listaTurmas";
            this.lv_listaTurmas.Size = new System.Drawing.Size(266, 395);
            this.lv_listaTurmas.TabIndex = 3;
            this.lv_listaTurmas.TileSize = new System.Drawing.Size(228, 34);
            this.lv_listaTurmas.UseCompatibleStateImageBehavior = false;
            this.lv_listaTurmas.View = System.Windows.Forms.View.Details;
            this.lv_listaTurmas.ColumnWidthChanging += new System.Windows.Forms.ColumnWidthChangingEventHandler(this.lv_listaTurmas_ColumnWidthChanging);
            this.lv_listaTurmas.SelectedIndexChanged += new System.EventHandler(this.lv_listaTurmas_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "";
            this.columnHeader1.Width = 0;
            // 
            // ch_turma
            // 
            this.ch_turma.Text = "Turma";
            this.ch_turma.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ch_turma.Width = 115;
            // 
            // ch_curso
            // 
            this.ch_curso.Text = "Curso";
            this.ch_curso.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ch_curso.Width = 130;
            // 
            // label13
            // 
            this.label13.BackColor = System.Drawing.Color.SteelBlue;
            this.label13.ForeColor = System.Drawing.Color.White;
            this.label13.Location = new System.Drawing.Point(-1, 490);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(722, 26);
            this.label13.TabIndex = 18;
            this.label13.Text = "© Copyright Pedro Fonseca 2021 v1.0";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::ProjetoEscola.Properties.Resources.logo;
            this.pictureBox2.Location = new System.Drawing.Point(9, 6);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(43, 62);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 24;
            this.pictureBox2.TabStop = false;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.BackColor = System.Drawing.Color.SteelBlue;
            this.label16.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label16.Location = new System.Drawing.Point(58, 36);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(105, 13);
            this.label16.TabIndex = 23;
            this.label16.Text = " Colégio Valsassina";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.BackColor = System.Drawing.Color.SteelBlue;
            this.label17.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label17.ForeColor = System.Drawing.Color.Black;
            this.label17.Location = new System.Drawing.Point(128, 6);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(82, 30);
            this.label17.TabIndex = 22;
            this.label17.Text = "Alunos";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.BackColor = System.Drawing.Color.SteelBlue;
            this.label18.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label18.ForeColor = System.Drawing.Color.White;
            this.label18.Location = new System.Drawing.Point(58, 6);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(76, 30);
            this.label18.TabIndex = 21;
            this.label18.Text = "Inovar";
            // 
            // label19
            // 
            this.label19.BackColor = System.Drawing.Color.SteelBlue;
            this.label19.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label19.Location = new System.Drawing.Point(0, -2);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(721, 75);
            this.label19.TabIndex = 20;
            // 
            // label14
            // 
            this.label14.BackColor = System.Drawing.Color.Silver;
            this.label14.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label14.ForeColor = System.Drawing.Color.Black;
            this.label14.Location = new System.Drawing.Point(-1, 73);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(722, 26);
            this.label14.TabIndex = 25;
            this.label14.Text = "Gestão de Turmas";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn_eliminarTurma
            // 
            this.btn_eliminarTurma.BackColor = System.Drawing.Color.White;
            this.btn_eliminarTurma.BackgroundImage = global::ProjetoEscola.Properties.Resources.remove;
            this.btn_eliminarTurma.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_eliminarTurma.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_eliminarTurma.ForeColor = System.Drawing.Color.Black;
            this.btn_eliminarTurma.Location = new System.Drawing.Point(97, 99);
            this.btn_eliminarTurma.Name = "btn_eliminarTurma";
            this.btn_eliminarTurma.Size = new System.Drawing.Size(19, 20);
            this.btn_eliminarTurma.TabIndex = 30;
            this.btn_eliminarTurma.UseVisualStyleBackColor = false;
            this.btn_eliminarTurma.Click += new System.EventHandler(this.btn_eliminarTurma_Click);
            // 
            // lv_disciplinas
            // 
            this.lv_disciplinas.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader,
            this.ch_disciplina});
            this.lv_disciplinas.FullRowSelect = true;
            this.lv_disciplinas.GridLines = true;
            this.lv_disciplinas.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lv_disciplinas.HideSelection = false;
            this.lv_disciplinas.Location = new System.Drawing.Point(0, 0);
            this.lv_disciplinas.Name = "lv_disciplinas";
            this.lv_disciplinas.Size = new System.Drawing.Size(222, 312);
            this.lv_disciplinas.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lv_disciplinas.TabIndex = 31;
            this.lv_disciplinas.TileSize = new System.Drawing.Size(228, 34);
            this.lv_disciplinas.UseCompatibleStateImageBehavior = false;
            this.lv_disciplinas.View = System.Windows.Forms.View.Details;
            this.lv_disciplinas.ColumnWidthChanging += new System.Windows.Forms.ColumnWidthChangingEventHandler(this.lv_disciplinas_ColumnWidthChanging);
            // 
            // columnHeader
            // 
            this.columnHeader.Width = 0;
            // 
            // ch_disciplina
            // 
            this.ch_disciplina.Text = "Disciplina";
            this.ch_disciplina.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ch_disciplina.Width = 200;
            // 
            // lv_alunos
            // 
            this.lv_alunos.CheckBoxes = true;
            this.lv_alunos.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader2,
            this.ch_aluno});
            this.lv_alunos.FullRowSelect = true;
            this.lv_alunos.GridLines = true;
            this.lv_alunos.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lv_alunos.HideSelection = false;
            this.lv_alunos.Location = new System.Drawing.Point(0, 0);
            this.lv_alunos.Name = "lv_alunos";
            this.lv_alunos.Size = new System.Drawing.Size(221, 312);
            this.lv_alunos.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lv_alunos.TabIndex = 32;
            this.lv_alunos.TileSize = new System.Drawing.Size(228, 34);
            this.lv_alunos.UseCompatibleStateImageBehavior = false;
            this.lv_alunos.View = System.Windows.Forms.View.Details;
            this.lv_alunos.ColumnWidthChanging += new System.Windows.Forms.ColumnWidthChangingEventHandler(this.lv_alunos_ColumnWidthChanging);
            // 
            // columnHeader2
            // 
            this.columnHeader2.Width = 0;
            // 
            // ch_aluno
            // 
            this.ch_aluno.Text = "Aluno";
            this.ch_aluno.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ch_aluno.Width = 200;
            // 
            // btn_removerDisciplina
            // 
            this.btn_removerDisciplina.BackColor = System.Drawing.Color.White;
            this.btn_removerDisciplina.BackgroundImage = global::ProjetoEscola.Properties.Resources.remove;
            this.btn_removerDisciplina.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_removerDisciplina.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_removerDisciplina.ForeColor = System.Drawing.Color.Black;
            this.btn_removerDisciplina.Location = new System.Drawing.Point(182, 0);
            this.btn_removerDisciplina.Name = "btn_removerDisciplina";
            this.btn_removerDisciplina.Size = new System.Drawing.Size(19, 20);
            this.btn_removerDisciplina.TabIndex = 34;
            this.btn_removerDisciplina.UseVisualStyleBackColor = false;
            this.btn_removerDisciplina.Click += new System.EventHandler(this.btn_removerDisciplina_Click);
            // 
            // btn_novaDisciplina
            // 
            this.btn_novaDisciplina.BackColor = System.Drawing.Color.White;
            this.btn_novaDisciplina.BackgroundImage = global::ProjetoEscola.Properties.Resources.add;
            this.btn_novaDisciplina.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_novaDisciplina.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_novaDisciplina.ForeColor = System.Drawing.Color.Black;
            this.btn_novaDisciplina.Location = new System.Drawing.Point(164, 0);
            this.btn_novaDisciplina.Name = "btn_novaDisciplina";
            this.btn_novaDisciplina.Size = new System.Drawing.Size(19, 20);
            this.btn_novaDisciplina.TabIndex = 33;
            this.btn_novaDisciplina.UseVisualStyleBackColor = false;
            this.btn_novaDisciplina.Click += new System.EventHandler(this.btn_novaDisciplina_Click);
            // 
            // btn_adicionarAluno
            // 
            this.btn_adicionarAluno.BackColor = System.Drawing.Color.White;
            this.btn_adicionarAluno.BackgroundImage = global::ProjetoEscola.Properties.Resources.add;
            this.btn_adicionarAluno.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_adicionarAluno.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_adicionarAluno.ForeColor = System.Drawing.Color.Black;
            this.btn_adicionarAluno.Location = new System.Drawing.Point(164, 0);
            this.btn_adicionarAluno.Name = "btn_adicionarAluno";
            this.btn_adicionarAluno.Size = new System.Drawing.Size(19, 20);
            this.btn_adicionarAluno.TabIndex = 35;
            this.btn_adicionarAluno.UseVisualStyleBackColor = false;
            this.btn_adicionarAluno.Click += new System.EventHandler(this.btn_adicionarAluno_Click);
            // 
            // btn_removerAluno
            // 
            this.btn_removerAluno.BackColor = System.Drawing.Color.White;
            this.btn_removerAluno.BackgroundImage = global::ProjetoEscola.Properties.Resources.remove;
            this.btn_removerAluno.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_removerAluno.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_removerAluno.ForeColor = System.Drawing.Color.Black;
            this.btn_removerAluno.Location = new System.Drawing.Point(182, 0);
            this.btn_removerAluno.Name = "btn_removerAluno";
            this.btn_removerAluno.Size = new System.Drawing.Size(19, 20);
            this.btn_removerAluno.TabIndex = 36;
            this.btn_removerAluno.UseVisualStyleBackColor = false;
            this.btn_removerAluno.Click += new System.EventHandler(this.btn_removerAluno_Click);
            // 
            // cb_diretorTurma
            // 
            this.cb_diretorTurma.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_diretorTurma.FormattingEnabled = true;
            this.cb_diretorTurma.Location = new System.Drawing.Point(395, 107);
            this.cb_diretorTurma.Name = "cb_diretorTurma";
            this.cb_diretorTurma.Size = new System.Drawing.Size(144, 23);
            this.cb_diretorTurma.TabIndex = 37;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(271, 108);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 17);
            this.label1.TabIndex = 38;
            this.label1.Text = "Diretor de Turma: ";
            // 
            // btn_guardar
            // 
            this.btn_guardar.BackColor = System.Drawing.Color.Silver;
            this.btn_guardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_guardar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btn_guardar.ForeColor = System.Drawing.Color.Black;
            this.btn_guardar.Location = new System.Drawing.Point(545, 96);
            this.btn_guardar.Name = "btn_guardar";
            this.btn_guardar.Size = new System.Drawing.Size(114, 41);
            this.btn_guardar.TabIndex = 39;
            this.btn_guardar.Text = "Guardar Alterações";
            this.btn_guardar.UseVisualStyleBackColor = false;
            this.btn_guardar.Click += new System.EventHandler(this.btn_guardar_Click);
            // 
            // btn_voltar
            // 
            this.btn_voltar.BackColor = System.Drawing.Color.Silver;
            this.btn_voltar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_voltar.ForeColor = System.Drawing.Color.Black;
            this.btn_voltar.Location = new System.Drawing.Point(656, 96);
            this.btn_voltar.Name = "btn_voltar";
            this.btn_voltar.Size = new System.Drawing.Size(65, 41);
            this.btn_voltar.TabIndex = 40;
            this.btn_voltar.Text = "Voltar";
            this.btn_voltar.UseVisualStyleBackColor = false;
            this.btn_voltar.Click += new System.EventHandler(this.btn_voltar_Click);
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.SteelBlue;
            this.pictureBox3.Image = global::ProjetoEscola.Properties.Resources.turma;
            this.pictureBox3.Location = new System.Drawing.Point(582, -2);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(139, 78);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 43;
            this.pictureBox3.TabStop = false;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.BackColor = System.Drawing.Color.SteelBlue;
            this.label15.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label15.ForeColor = System.Drawing.Color.White;
            this.label15.Location = new System.Drawing.Point(403, 48);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(95, 17);
            this.label15.TabIndex = 42;
            this.label15.Text = "Administrador";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::ProjetoEscola.Properties.Resources.fotoadmin;
            this.pictureBox1.Location = new System.Drawing.Point(504, 6);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(54, 60);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 41;
            this.pictureBox1.TabStop = false;
            // 
            // panel_disciplinas
            // 
            this.panel_disciplinas.Controls.Add(this.btn_removerDisciplina);
            this.panel_disciplinas.Controls.Add(this.btn_novaDisciplina);
            this.panel_disciplinas.Controls.Add(this.lv_disciplinas);
            this.panel_disciplinas.Location = new System.Drawing.Point(271, 180);
            this.panel_disciplinas.Name = "panel_disciplinas";
            this.panel_disciplinas.Size = new System.Drawing.Size(223, 312);
            this.panel_disciplinas.TabIndex = 44;
            // 
            // panel_alunos
            // 
            this.panel_alunos.Controls.Add(this.btn_removerAluno);
            this.panel_alunos.Controls.Add(this.btn_adicionarAluno);
            this.panel_alunos.Controls.Add(this.lv_alunos);
            this.panel_alunos.Location = new System.Drawing.Point(500, 180);
            this.panel_alunos.Name = "panel_alunos";
            this.panel_alunos.Size = new System.Drawing.Size(221, 312);
            this.panel_alunos.TabIndex = 35;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(271, 152);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 17);
            this.label2.TabIndex = 45;
            this.label2.Text = "Turma:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(478, 154);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 17);
            this.label3.TabIndex = 46;
            this.label3.Text = "Curso:";
            // 
            // tb_turma
            // 
            this.tb_turma.Location = new System.Drawing.Point(326, 151);
            this.tb_turma.Name = "tb_turma";
            this.tb_turma.Size = new System.Drawing.Size(146, 23);
            this.tb_turma.TabIndex = 47;
            // 
            // tb_curso
            // 
            this.tb_curso.Location = new System.Drawing.Point(530, 151);
            this.tb_curso.Name = "tb_curso";
            this.tb_curso.Size = new System.Drawing.Size(183, 23);
            this.tb_curso.TabIndex = 48;
            // 
            // lbl_horas
            // 
            this.lbl_horas.AutoSize = true;
            this.lbl_horas.BackColor = System.Drawing.Color.SteelBlue;
            this.lbl_horas.Font = new System.Drawing.Font("Segoe UI Semibold", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lbl_horas.ForeColor = System.Drawing.Color.White;
            this.lbl_horas.Location = new System.Drawing.Point(272, 52);
            this.lbl_horas.Name = "lbl_horas";
            this.lbl_horas.Size = new System.Drawing.Size(40, 13);
            this.lbl_horas.TabIndex = 50;
            this.lbl_horas.Text = "Horas:";
            // 
            // lbl_data
            // 
            this.lbl_data.AutoSize = true;
            this.lbl_data.BackColor = System.Drawing.Color.SteelBlue;
            this.lbl_data.Font = new System.Drawing.Font("Segoe UI Semibold", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lbl_data.ForeColor = System.Drawing.Color.White;
            this.lbl_data.Location = new System.Drawing.Point(62, 52);
            this.lbl_data.Name = "lbl_data";
            this.lbl_data.Size = new System.Drawing.Size(64, 13);
            this.lbl_data.TabIndex = 49;
            this.lbl_data.Text = "Ano Letivo:";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // form_Turmas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(720, 515);
            this.Controls.Add(this.lbl_horas);
            this.Controls.Add(this.lbl_data);
            this.Controls.Add(this.tb_curso);
            this.Controls.Add(this.tb_turma);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cb_diretorTurma);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.btn_eliminarTurma);
            this.Controls.Add(this.lv_listaTurmas);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.btn_guardar);
            this.Controls.Add(this.btn_voltar);
            this.Controls.Add(this.panel_disciplinas);
            this.Controls.Add(this.panel_alunos);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "form_Turmas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Colégio Valsassina - Gestão de Turmas";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.form_Turmas_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel_disciplinas.ResumeLayout(false);
            this.panel_alunos.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ColumnHeader columnHeader12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader ch_turma;
        private System.Windows.Forms.Button btn_eliminarTurma;
        private System.Windows.Forms.ColumnHeader columnHeader;
        private System.Windows.Forms.ColumnHeader ch_disciplina;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader ch_aluno;
        private System.Windows.Forms.Button btn_removerDisciplina;
        private System.Windows.Forms.Button btn_novaDisciplina;
        private System.Windows.Forms.Button btn_adicionarAluno;
        private System.Windows.Forms.Button btn_removerAluno;
        private System.Windows.Forms.ComboBox cb_diretorTurma;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ColumnHeader ch_curso;
        private System.Windows.Forms.Button btn_guardar;
        private System.Windows.Forms.Button btn_voltar;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel_disciplinas;
        private System.Windows.Forms.Panel panel_alunos;
        public System.Windows.Forms.ListView lv_listaTurmas;
        public System.Windows.Forms.ListView lv_disciplinas;
        public System.Windows.Forms.ListView lv_alunos;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tb_turma;
        private System.Windows.Forms.TextBox tb_curso;
        private System.Windows.Forms.Label lbl_horas;
        private System.Windows.Forms.Label lbl_data;
        private System.Windows.Forms.Timer timer1;
    }
}