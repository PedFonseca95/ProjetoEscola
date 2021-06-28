
namespace ProjetoEscola
{
    partial class form_Notas
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
            this.label13 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.btn_alteraNota = new System.Windows.Forms.Button();
            this.lv_disciplinas = new System.Windows.Forms.ListView();
            this.columnHeader = new System.Windows.Forms.ColumnHeader();
            this.ch_disciplina = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.btn_voltar = new System.Windows.Forms.Button();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.label15 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lbl_horas = new System.Windows.Forms.Label();
            this.lbl_data = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.lv_alunos = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.nud_nota = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_nota)).BeginInit();
            this.SuspendLayout();
            // 
            // label13
            // 
            this.label13.BackColor = System.Drawing.Color.SteelBlue;
            this.label13.ForeColor = System.Drawing.Color.White;
            this.label13.Location = new System.Drawing.Point(-1, 490);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(619, 26);
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
            this.label19.Size = new System.Drawing.Size(618, 75);
            this.label19.TabIndex = 20;
            // 
            // label14
            // 
            this.label14.BackColor = System.Drawing.Color.Silver;
            this.label14.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label14.ForeColor = System.Drawing.Color.Black;
            this.label14.Location = new System.Drawing.Point(-1, 73);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(619, 26);
            this.label14.TabIndex = 25;
            this.label14.Text = "Gestão de Turmas";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn_alteraNota
            // 
            this.btn_alteraNota.BackColor = System.Drawing.Color.White;
            this.btn_alteraNota.BackgroundImage = global::ProjetoEscola.Properties.Resources.confirmar;
            this.btn_alteraNota.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_alteraNota.FlatAppearance.BorderSize = 0;
            this.btn_alteraNota.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_alteraNota.ForeColor = System.Drawing.Color.Black;
            this.btn_alteraNota.Location = new System.Drawing.Point(373, 113);
            this.btn_alteraNota.Name = "btn_alteraNota";
            this.btn_alteraNota.Size = new System.Drawing.Size(19, 22);
            this.btn_alteraNota.TabIndex = 30;
            this.btn_alteraNota.UseVisualStyleBackColor = false;
            this.btn_alteraNota.Click += new System.EventHandler(this.btn_alteraNota_Click);
            // 
            // lv_disciplinas
            // 
            this.lv_disciplinas.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader,
            this.ch_disciplina,
            this.columnHeader3});
            this.lv_disciplinas.FullRowSelect = true;
            this.lv_disciplinas.GridLines = true;
            this.lv_disciplinas.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lv_disciplinas.HideSelection = false;
            this.lv_disciplinas.Location = new System.Drawing.Point(233, 147);
            this.lv_disciplinas.MultiSelect = false;
            this.lv_disciplinas.Name = "lv_disciplinas";
            this.lv_disciplinas.Size = new System.Drawing.Size(385, 345);
            this.lv_disciplinas.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lv_disciplinas.TabIndex = 31;
            this.lv_disciplinas.TileSize = new System.Drawing.Size(228, 34);
            this.lv_disciplinas.UseCompatibleStateImageBehavior = false;
            this.lv_disciplinas.View = System.Windows.Forms.View.Details;
            this.lv_disciplinas.ColumnWidthChanging += new System.Windows.Forms.ColumnWidthChangingEventHandler(this.lv_disciplinas_ColumnWidthChanging);
            this.lv_disciplinas.SelectedIndexChanged += new System.EventHandler(this.lv_disciplinas_SelectedIndexChanged);
            // 
            // columnHeader
            // 
            this.columnHeader.Width = 0;
            // 
            // ch_disciplina
            // 
            this.ch_disciplina.Text = "Disciplinas";
            this.ch_disciplina.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ch_disciplina.Width = 300;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Notas";
            this.columnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btn_voltar
            // 
            this.btn_voltar.BackColor = System.Drawing.Color.Silver;
            this.btn_voltar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_voltar.ForeColor = System.Drawing.Color.Black;
            this.btn_voltar.Location = new System.Drawing.Point(427, 97);
            this.btn_voltar.Name = "btn_voltar";
            this.btn_voltar.Size = new System.Drawing.Size(191, 27);
            this.btn_voltar.TabIndex = 40;
            this.btn_voltar.Text = "Voltar";
            this.btn_voltar.UseVisualStyleBackColor = false;
            this.btn_voltar.Click += new System.EventHandler(this.btn_voltar_Click);
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.SteelBlue;
            this.pictureBox3.Image = global::ProjetoEscola.Properties.Resources.aluno2;
            this.pictureBox3.Location = new System.Drawing.Point(483, -2);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(135, 82);
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
            this.label15.Location = new System.Drawing.Point(326, 47);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(95, 17);
            this.label15.TabIndex = 42;
            this.label15.Text = "Administrador";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::ProjetoEscola.Properties.Resources.fotoadmin;
            this.pictureBox1.Location = new System.Drawing.Point(427, 5);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(54, 60);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 41;
            this.pictureBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(233, 113);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 17);
            this.label2.TabIndex = 45;
            this.label2.Text = "Nota:";
            // 
            // lbl_horas
            // 
            this.lbl_horas.AutoSize = true;
            this.lbl_horas.BackColor = System.Drawing.Color.SteelBlue;
            this.lbl_horas.Font = new System.Drawing.Font("Segoe UI Semibold", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lbl_horas.ForeColor = System.Drawing.Color.White;
            this.lbl_horas.Location = new System.Drawing.Point(225, 51);
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
            // lv_alunos
            // 
            this.lv_alunos.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.lv_alunos.FullRowSelect = true;
            this.lv_alunos.GridLines = true;
            this.lv_alunos.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lv_alunos.HideSelection = false;
            this.lv_alunos.Location = new System.Drawing.Point(-1, 97);
            this.lv_alunos.MultiSelect = false;
            this.lv_alunos.Name = "lv_alunos";
            this.lv_alunos.Size = new System.Drawing.Size(228, 395);
            this.lv_alunos.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lv_alunos.TabIndex = 51;
            this.lv_alunos.TileSize = new System.Drawing.Size(228, 34);
            this.lv_alunos.UseCompatibleStateImageBehavior = false;
            this.lv_alunos.View = System.Windows.Forms.View.Details;
            this.lv_alunos.ColumnWidthChanging += new System.Windows.Forms.ColumnWidthChangingEventHandler(this.lv_alunos_ColumnWidthChanging);
            this.lv_alunos.SelectedIndexChanged += new System.EventHandler(this.lv_alunos_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Width = 0;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Alunos";
            this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader2.Width = 200;
            // 
            // nud_nota
            // 
            this.nud_nota.Location = new System.Drawing.Point(280, 112);
            this.nud_nota.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.nud_nota.Name = "nud_nota";
            this.nud_nota.Size = new System.Drawing.Size(87, 23);
            this.nud_nota.TabIndex = 52;
            this.nud_nota.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // form_Notas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(617, 515);
            this.Controls.Add(this.nud_nota);
            this.Controls.Add(this.lbl_horas);
            this.Controls.Add(this.lbl_data);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.btn_alteraNota);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.btn_voltar);
            this.Controls.Add(this.lv_alunos);
            this.Controls.Add(this.lv_disciplinas);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "form_Notas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Colégio Valsassina - Gestão de Notas";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.form_Notas_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_nota)).EndInit();
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
        private System.Windows.Forms.Button btn_alteraNota;
        private System.Windows.Forms.ColumnHeader columnHeader;
        private System.Windows.Forms.ColumnHeader ch_disciplina;
        private System.Windows.Forms.ColumnHeader ch_aluno;
        private System.Windows.Forms.Button btn_voltar;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.PictureBox pictureBox1;
        public System.Windows.Forms.ListView lv_disciplinas;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbl_horas;
        private System.Windows.Forms.Label lbl_data;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        public System.Windows.Forms.ListView lv_alunos;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.NumericUpDown nud_nota;
    }
}