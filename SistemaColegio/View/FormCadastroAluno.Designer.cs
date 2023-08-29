namespace SistemaColegio.View
{
    partial class FormCadastroAluno
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormCadastroAluno));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel3 = new System.Windows.Forms.Panel();
            this.novo = new System.Windows.Forms.Button();
            this.AlterarNaoEstudando = new System.Windows.Forms.Button();
            this.AlterarEstudando = new System.Windows.Forms.Button();
            this.situacao = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.nome = new System.Windows.Forms.TextBox();
            this.ra = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.editar = new System.Windows.Forms.Button();
            this.salvar = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.classe = new System.Windows.Forms.ComboBox();
            this.dataNasc = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.sexo = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.voltar = new System.Windows.Forms.Button();
            this.sair = new System.Windows.Forms.Button();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.hora = new System.Windows.Forms.Label();
            this.data = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.buscar = new System.Windows.Forms.TextBox();
            this.grid = new System.Windows.Forms.DataGridView();
            this.timerCadAlunos = new System.Windows.Forms.Timer(this.components);
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Transparent;
            this.panel3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel3.BackgroundImage")));
            this.panel3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel3.Controls.Add(this.novo);
            this.panel3.Controls.Add(this.AlterarNaoEstudando);
            this.panel3.Controls.Add(this.AlterarEstudando);
            this.panel3.Controls.Add(this.situacao);
            this.panel3.Controls.Add(this.label7);
            this.panel3.Controls.Add(this.nome);
            this.panel3.Controls.Add(this.ra);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.editar);
            this.panel3.Controls.Add(this.salvar);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.classe);
            this.panel3.Controls.Add(this.dataNasc);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.sexo);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Location = new System.Drawing.Point(25, 152);
            this.panel3.Margin = new System.Windows.Forms.Padding(2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(470, 498);
            this.panel3.TabIndex = 7;
            // 
            // novo
            // 
            this.novo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("novo.BackgroundImage")));
            this.novo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.novo.FlatAppearance.BorderSize = 0;
            this.novo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.novo.Location = new System.Drawing.Point(98, 426);
            this.novo.Margin = new System.Windows.Forms.Padding(2);
            this.novo.Name = "novo";
            this.novo.Size = new System.Drawing.Size(75, 50);
            this.novo.TabIndex = 27;
            this.novo.UseVisualStyleBackColor = true;
            this.novo.Click += new System.EventHandler(this.novo_Click);
            // 
            // AlterarNaoEstudando
            // 
            this.AlterarNaoEstudando.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("AlterarNaoEstudando.BackgroundImage")));
            this.AlterarNaoEstudando.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.AlterarNaoEstudando.Enabled = false;
            this.AlterarNaoEstudando.FlatAppearance.BorderSize = 0;
            this.AlterarNaoEstudando.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AlterarNaoEstudando.Location = new System.Drawing.Point(260, 56);
            this.AlterarNaoEstudando.Margin = new System.Windows.Forms.Padding(2);
            this.AlterarNaoEstudando.Name = "AlterarNaoEstudando";
            this.AlterarNaoEstudando.Size = new System.Drawing.Size(75, 50);
            this.AlterarNaoEstudando.TabIndex = 26;
            this.AlterarNaoEstudando.UseVisualStyleBackColor = true;
            this.AlterarNaoEstudando.Click += new System.EventHandler(this.AlterarNaoEstudando_Click);
            // 
            // AlterarEstudando
            // 
            this.AlterarEstudando.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("AlterarEstudando.BackgroundImage")));
            this.AlterarEstudando.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.AlterarEstudando.Enabled = false;
            this.AlterarEstudando.FlatAppearance.BorderSize = 0;
            this.AlterarEstudando.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AlterarEstudando.Location = new System.Drawing.Point(136, 56);
            this.AlterarEstudando.Margin = new System.Windows.Forms.Padding(2);
            this.AlterarEstudando.Name = "AlterarEstudando";
            this.AlterarEstudando.Size = new System.Drawing.Size(75, 50);
            this.AlterarEstudando.TabIndex = 25;
            this.AlterarEstudando.UseVisualStyleBackColor = true;
            this.AlterarEstudando.Click += new System.EventHandler(this.AlterarEstudando_Click);
            // 
            // situacao
            // 
            this.situacao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.situacao.Enabled = false;
            this.situacao.Font = new System.Drawing.Font("Microsoft Yi Baiti", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.situacao.Location = new System.Drawing.Point(220, 29);
            this.situacao.Margin = new System.Windows.Forms.Padding(2);
            this.situacao.Multiline = true;
            this.situacao.Name = "situacao";
            this.situacao.Size = new System.Drawing.Size(129, 23);
            this.situacao.TabIndex = 24;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Mongolian Baiti", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(115, 28);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(101, 24);
            this.label7.TabIndex = 23;
            this.label7.Text = "Situação:";
            // 
            // nome
            // 
            this.nome.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nome.Enabled = false;
            this.nome.Font = new System.Drawing.Font("Microsoft Yi Baiti", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nome.Location = new System.Drawing.Point(132, 181);
            this.nome.Margin = new System.Windows.Forms.Padding(2);
            this.nome.Multiline = true;
            this.nome.Name = "nome";
            this.nome.Size = new System.Drawing.Size(257, 23);
            this.nome.TabIndex = 18;
            this.nome.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.nomeAluno_KeyPress);
            // 
            // ra
            // 
            this.ra.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ra.Enabled = false;
            this.ra.Font = new System.Drawing.Font("Microsoft Yi Baiti", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ra.Location = new System.Drawing.Point(108, 130);
            this.ra.Margin = new System.Windows.Forms.Padding(2);
            this.ra.Multiline = true;
            this.ra.Name = "ra";
            this.ra.Size = new System.Drawing.Size(55, 23);
            this.ra.TabIndex = 17;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Mongolian Baiti", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(57, 130);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 24);
            this.label5.TabIndex = 14;
            this.label5.Text = "RA:";
            // 
            // editar
            // 
            this.editar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("editar.BackgroundImage")));
            this.editar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.editar.Enabled = false;
            this.editar.FlatAppearance.BorderSize = 0;
            this.editar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.editar.Location = new System.Drawing.Point(287, 427);
            this.editar.Margin = new System.Windows.Forms.Padding(2);
            this.editar.Name = "editar";
            this.editar.Size = new System.Drawing.Size(50, 49);
            this.editar.TabIndex = 10;
            this.editar.UseVisualStyleBackColor = true;
            this.editar.Click += new System.EventHandler(this.editarAluno_Click);
            // 
            // salvar
            // 
            this.salvar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("salvar.BackgroundImage")));
            this.salvar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.salvar.Enabled = false;
            this.salvar.FlatAppearance.BorderSize = 0;
            this.salvar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.salvar.Location = new System.Drawing.Point(204, 427);
            this.salvar.Margin = new System.Windows.Forms.Padding(2);
            this.salvar.Name = "salvar";
            this.salvar.Size = new System.Drawing.Size(50, 49);
            this.salvar.TabIndex = 9;
            this.salvar.UseVisualStyleBackColor = true;
            this.salvar.Click += new System.EventHandler(this.salvarAluno_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Mongolian Baiti", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(57, 333);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 24);
            this.label4.TabIndex = 7;
            this.label4.Text = "Classe:";
            // 
            // classe
            // 
            this.classe.BackColor = System.Drawing.Color.White;
            this.classe.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.classe.Enabled = false;
            this.classe.Font = new System.Drawing.Font("Microsoft Yi Baiti", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.classe.FormattingEnabled = true;
            this.classe.Location = new System.Drawing.Point(144, 332);
            this.classe.Margin = new System.Windows.Forms.Padding(2);
            this.classe.Name = "classe";
            this.classe.Size = new System.Drawing.Size(64, 28);
            this.classe.TabIndex = 6;
            // 
            // dataNasc
            // 
            this.dataNasc.Enabled = false;
            this.dataNasc.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dataNasc.Location = new System.Drawing.Point(266, 286);
            this.dataNasc.Margin = new System.Windows.Forms.Padding(2);
            this.dataNasc.Name = "dataNasc";
            this.dataNasc.Size = new System.Drawing.Size(105, 20);
            this.dataNasc.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Mongolian Baiti", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(57, 283);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(211, 24);
            this.label3.TabIndex = 4;
            this.label3.Text = "Data de nascimento:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Mongolian Baiti", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(57, 231);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 24);
            this.label2.TabIndex = 3;
            this.label2.Text = "Sexo:";
            // 
            // sexo
            // 
            this.sexo.BackColor = System.Drawing.Color.White;
            this.sexo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.sexo.Enabled = false;
            this.sexo.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.sexo.Font = new System.Drawing.Font("Microsoft Yi Baiti", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sexo.FormattingEnabled = true;
            this.sexo.Items.AddRange(new object[] {
            "Feminino",
            "Masculino",
            "Outro"});
            this.sexo.Location = new System.Drawing.Point(123, 229);
            this.sexo.Margin = new System.Windows.Forms.Padding(2);
            this.sexo.Name = "sexo";
            this.sexo.Size = new System.Drawing.Size(101, 28);
            this.sexo.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Mongolian Baiti", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(57, 181);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "Nome:";
            // 
            // voltar
            // 
            this.voltar.BackColor = System.Drawing.Color.Transparent;
            this.voltar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("voltar.BackgroundImage")));
            this.voltar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.voltar.FlatAppearance.BorderSize = 0;
            this.voltar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.voltar.Location = new System.Drawing.Point(885, 20);
            this.voltar.Margin = new System.Windows.Forms.Padding(2);
            this.voltar.Name = "voltar";
            this.voltar.Size = new System.Drawing.Size(45, 44);
            this.voltar.TabIndex = 15;
            this.voltar.UseVisualStyleBackColor = false;
            this.voltar.Click += new System.EventHandler(this.voltarCadProfessor_Click);
            // 
            // sair
            // 
            this.sair.BackColor = System.Drawing.Color.Transparent;
            this.sair.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("sair.BackgroundImage")));
            this.sair.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.sair.FlatAppearance.BorderSize = 0;
            this.sair.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.sair.Location = new System.Drawing.Point(935, 20);
            this.sair.Margin = new System.Windows.Forms.Padding(2);
            this.sair.Name = "sair";
            this.sair.Size = new System.Drawing.Size(45, 44);
            this.sair.TabIndex = 13;
            this.sair.UseVisualStyleBackColor = false;
            this.sair.Click += new System.EventHandler(this.sairCadProfessor_Click);
            // 
            // pictureBox5
            // 
            this.pictureBox5.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox5.Image")));
            this.pictureBox5.Location = new System.Drawing.Point(8, 1);
            this.pictureBox5.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(246, 147);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox5.TabIndex = 12;
            this.pictureBox5.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(586, 20);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(345, 206);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 14;
            this.pictureBox1.TabStop = false;
            // 
            // hora
            // 
            this.hora.AutoSize = true;
            this.hora.BackColor = System.Drawing.Color.Transparent;
            this.hora.Font = new System.Drawing.Font("Microsoft Tai Le", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hora.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.hora.Location = new System.Drawing.Point(881, 666);
            this.hora.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.hora.Name = "hora";
            this.hora.Size = new System.Drawing.Size(73, 29);
            this.hora.TabIndex = 17;
            this.hora.Text = "HORA";
            // 
            // data
            // 
            this.data.AutoSize = true;
            this.data.BackColor = System.Drawing.Color.Transparent;
            this.data.Font = new System.Drawing.Font("Microsoft Tai Le", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.data.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.data.Location = new System.Drawing.Point(20, 666);
            this.data.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.data.Name = "data";
            this.data.Size = new System.Drawing.Size(68, 29);
            this.data.TabIndex = 16;
            this.data.Text = "DATA";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(90, 44);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(22, 23);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 19;
            this.pictureBox2.TabStop = false;
            // 
            // buscar
            // 
            this.buscar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.buscar.Font = new System.Drawing.Font("Microsoft Yi Baiti", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buscar.Location = new System.Drawing.Point(116, 44);
            this.buscar.Margin = new System.Windows.Forms.Padding(2);
            this.buscar.Multiline = true;
            this.buscar.Name = "buscar";
            this.buscar.Size = new System.Drawing.Size(305, 23);
            this.buscar.TabIndex = 20;
            this.buscar.Click += new System.EventHandler(this.buscar_Click);
            this.buscar.TextChanged += new System.EventHandler(this.buscarCadAluno_TextChanged);
            // 
            // grid
            // 
            this.grid.AllowUserToAddRows = false;
            this.grid.AllowUserToDeleteRows = false;
            this.grid.AllowUserToResizeColumns = false;
            this.grid.AllowUserToResizeRows = false;
            this.grid.BackgroundColor = System.Drawing.Color.Linen;
            this.grid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.IndianRed;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.DarkGray;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grid.DefaultCellStyle = dataGridViewCellStyle2;
            this.grid.GridColor = System.Drawing.Color.MistyRose;
            this.grid.Location = new System.Drawing.Point(52, 84);
            this.grid.Margin = new System.Windows.Forms.Padding(2);
            this.grid.Name = "grid";
            this.grid.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.DarkGray;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grid.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.grid.RowHeadersWidth = 62;
            this.grid.RowTemplate.Height = 28;
            this.grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grid.Size = new System.Drawing.Size(395, 392);
            this.grid.TabIndex = 5;
            this.grid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridCadAlunos_CellClick);
            // 
            // timerCadAlunos
            // 
            this.timerCadAlunos.Tick += new System.EventHandler(this.timerCadAlunos_Tick);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel2.BackgroundImage")));
            this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel2.Controls.Add(this.pictureBox2);
            this.panel2.Controls.Add(this.buscar);
            this.panel2.Controls.Add(this.grid);
            this.panel2.Location = new System.Drawing.Point(510, 152);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(470, 498);
            this.panel2.TabIndex = 18;
            // 
            // FormCadastroAluno
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Maroon;
            this.ClientSize = new System.Drawing.Size(1005, 699);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.hora);
            this.Controls.Add(this.data);
            this.Controls.Add(this.voltar);
            this.Controls.Add(this.sair);
            this.Controls.Add(this.pictureBox5);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.panel3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FormCadastroAluno";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cadastro de alunos";
            this.Load += new System.EventHandler(this.FormCadastroAluno_Load);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox nome;
        private System.Windows.Forms.TextBox ra;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button editar;
        private System.Windows.Forms.Button salvar;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox classe;
        private System.Windows.Forms.DateTimePicker dataNasc;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox sexo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button voltar;
        private System.Windows.Forms.Button sair;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label hora;
        private System.Windows.Forms.Label data;
        private System.Windows.Forms.DataGridView grid;
        private System.Windows.Forms.TextBox buscar;
        private System.Windows.Forms.Timer timerCadAlunos;
        private System.Windows.Forms.Button novo;
        private System.Windows.Forms.Button AlterarNaoEstudando;
        private System.Windows.Forms.Button AlterarEstudando;
        private System.Windows.Forms.TextBox situacao;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Panel panel2;
    }
}