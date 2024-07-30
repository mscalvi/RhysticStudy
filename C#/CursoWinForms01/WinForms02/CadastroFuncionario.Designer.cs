namespace WinForms02
{
    partial class CadastroFuncionario
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
            LabelNome = new Label();
            LabelEmail = new Label();
            LabelSalario = new Label();
            MsgErro = new Label();
            TextNome = new TextBox();
            TextEmail = new TextBox();
            TextSalario = new TextBox();
            SexoMasculino = new RadioButton();
            SexoFeminino = new RadioButton();
            TipoClt = new RadioButton();
            TipoPj = new RadioButton();
            TipoAutonomo = new RadioButton();
            GroupSexo = new GroupBox();
            GrupoContrato = new GroupBox();
            BtnCriar = new Button();
            GroupSexo.SuspendLayout();
            GrupoContrato.SuspendLayout();
            SuspendLayout();
            // 
            // LabelNome
            // 
            LabelNome.AutoSize = true;
            LabelNome.Location = new Point(12, 52);
            LabelNome.Name = "LabelNome";
            LabelNome.Size = new Size(43, 15);
            LabelNome.TabIndex = 0;
            LabelNome.Text = "Nome:";
            // 
            // LabelEmail
            // 
            LabelEmail.AutoSize = true;
            LabelEmail.Location = new Point(12, 96);
            LabelEmail.Name = "LabelEmail";
            LabelEmail.Size = new Size(39, 15);
            LabelEmail.TabIndex = 1;
            LabelEmail.Text = "Email:";
            // 
            // LabelSalario
            // 
            LabelSalario.AutoSize = true;
            LabelSalario.Location = new Point(12, 140);
            LabelSalario.Name = "LabelSalario";
            LabelSalario.Size = new Size(45, 15);
            LabelSalario.TabIndex = 4;
            LabelSalario.Text = "Salário:";
            // 
            // MsgErro
            // 
            MsgErro.AutoSize = true;
            MsgErro.ForeColor = Color.Crimson;
            MsgErro.Location = new Point(140, 386);
            MsgErro.Name = "MsgErro";
            MsgErro.Size = new Size(48, 15);
            MsgErro.TabIndex = 6;
            MsgErro.Text = "Socorro";
            // 
            // TextNome
            // 
            TextNome.Location = new Point(12, 70);
            TextNome.Name = "TextNome";
            TextNome.Size = new Size(369, 23);
            TextNome.TabIndex = 7;
            // 
            // TextEmail
            // 
            TextEmail.Location = new Point(12, 114);
            TextEmail.Name = "TextEmail";
            TextEmail.Size = new Size(369, 23);
            TextEmail.TabIndex = 8;
            // 
            // TextSalario
            // 
            TextSalario.Location = new Point(12, 158);
            TextSalario.Name = "TextSalario";
            TextSalario.Size = new Size(369, 23);
            TextSalario.TabIndex = 9;
            // 
            // SexoMasculino
            // 
            SexoMasculino.AutoSize = true;
            SexoMasculino.Checked = true;
            SexoMasculino.Location = new Point(6, 22);
            SexoMasculino.Name = "SexoMasculino";
            SexoMasculino.Size = new Size(80, 19);
            SexoMasculino.TabIndex = 10;
            SexoMasculino.TabStop = true;
            SexoMasculino.Text = "Masculino";
            SexoMasculino.UseVisualStyleBackColor = true;
            // 
            // SexoFeminino
            // 
            SexoFeminino.AutoSize = true;
            SexoFeminino.Location = new Point(106, 22);
            SexoFeminino.Name = "SexoFeminino";
            SexoFeminino.Size = new Size(75, 19);
            SexoFeminino.TabIndex = 11;
            SexoFeminino.Text = "Feminino";
            SexoFeminino.UseVisualStyleBackColor = true;
            // 
            // TipoClt
            // 
            TipoClt.AutoSize = true;
            TipoClt.Checked = true;
            TipoClt.Location = new Point(6, 32);
            TipoClt.Name = "TipoClt";
            TipoClt.Size = new Size(44, 19);
            TipoClt.TabIndex = 12;
            TipoClt.TabStop = true;
            TipoClt.Text = "CLT";
            TipoClt.UseVisualStyleBackColor = true;
            // 
            // TipoPj
            // 
            TipoPj.AutoSize = true;
            TipoPj.Location = new Point(106, 32);
            TipoPj.Name = "TipoPj";
            TipoPj.Size = new Size(35, 19);
            TipoPj.TabIndex = 13;
            TipoPj.Text = "PJ";
            TipoPj.UseVisualStyleBackColor = true;
            // 
            // TipoAutonomo
            // 
            TipoAutonomo.AutoSize = true;
            TipoAutonomo.Location = new Point(206, 32);
            TipoAutonomo.Name = "TipoAutonomo";
            TipoAutonomo.Size = new Size(83, 19);
            TipoAutonomo.TabIndex = 14;
            TipoAutonomo.Text = "Autonomo";
            TipoAutonomo.UseVisualStyleBackColor = true;
            // 
            // GroupSexo
            // 
            GroupSexo.Controls.Add(SexoMasculino);
            GroupSexo.Controls.Add(SexoFeminino);
            GroupSexo.Location = new Point(400, 52);
            GroupSexo.Name = "GroupSexo";
            GroupSexo.Size = new Size(324, 59);
            GroupSexo.TabIndex = 15;
            GroupSexo.TabStop = false;
            GroupSexo.Text = "Sexo";
            // 
            // GrupoContrato
            // 
            GrupoContrato.Controls.Add(TipoClt);
            GrupoContrato.Controls.Add(TipoPj);
            GrupoContrato.Controls.Add(TipoAutonomo);
            GrupoContrato.Location = new Point(400, 117);
            GrupoContrato.Name = "GrupoContrato";
            GrupoContrato.Size = new Size(324, 64);
            GrupoContrato.TabIndex = 16;
            GrupoContrato.TabStop = false;
            GrupoContrato.Text = "Tipo de contrato:";
            // 
            // BtnCriar
            // 
            BtnCriar.Location = new Point(12, 386);
            BtnCriar.Name = "BtnCriar";
            BtnCriar.Size = new Size(103, 52);
            BtnCriar.TabIndex = 18;
            BtnCriar.Text = "Criar";
            BtnCriar.UseVisualStyleBackColor = true;
            BtnCriar.Click += SalvarAction;
            // 
            // CadastroFuncionario
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(BtnCriar);
            Controls.Add(GrupoContrato);
            Controls.Add(GroupSexo);
            Controls.Add(TextSalario);
            Controls.Add(TextEmail);
            Controls.Add(TextNome);
            Controls.Add(MsgErro);
            Controls.Add(LabelSalario);
            Controls.Add(LabelEmail);
            Controls.Add(LabelNome);
            Name = "CadastroFuncionario";
            Text = "Cadastro de Funcionário";
            GroupSexo.ResumeLayout(false);
            GroupSexo.PerformLayout();
            GrupoContrato.ResumeLayout(false);
            GrupoContrato.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label LabelNome;
        private Label LabelEmail;
        private Label LabelSalario;
        private Label MsgErro;
        private TextBox TextNome;
        private TextBox TextEmail;
        private TextBox TextSalario;
        private RadioButton SexoMasculino;
        private RadioButton SexoFeminino;
        private RadioButton TipoClt;
        private RadioButton TipoPj;
        private RadioButton TipoAutonomo;
        private GroupBox GroupSexo;
        private GroupBox GrupoContrato;
        private Button BtnCriar;
    }
}