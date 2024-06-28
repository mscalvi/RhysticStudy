namespace WinForms02
{
    partial class TelaPrincipal
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            TabelaFuncionarios = new DataGridView();
            BtnNovo = new Button();
            BtnEditar = new Button();
            BtnExcluir = new Button();
            ((System.ComponentModel.ISupportInitialize)TabelaFuncionarios).BeginInit();
            SuspendLayout();
            // 
            // TabelaFuncionarios
            // 
            TabelaFuncionarios.AllowUserToAddRows = false;
            TabelaFuncionarios.AllowUserToDeleteRows = false;
            TabelaFuncionarios.AllowUserToResizeRows = false;
            TabelaFuncionarios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            TabelaFuncionarios.EditMode = DataGridViewEditMode.EditProgrammatically;
            TabelaFuncionarios.Location = new Point(12, 12);
            TabelaFuncionarios.MaximumSize = new Size(1080, 720);
            TabelaFuncionarios.Name = "TabelaFuncionarios";
            TabelaFuncionarios.Size = new Size(776, 362);
            TabelaFuncionarios.TabIndex = 0;
            // 
            // BtnNovo
            // 
            BtnNovo.Location = new Point(12, 386);
            BtnNovo.Name = "BtnNovo";
            BtnNovo.Size = new Size(103, 52);
            BtnNovo.TabIndex = 1;
            BtnNovo.Text = "Novo";
            BtnNovo.UseVisualStyleBackColor = true;
            BtnNovo.Click += NovoAction;
            // 
            // BtnEditar
            // 
            BtnEditar.Location = new Point(121, 386);
            BtnEditar.Name = "BtnEditar";
            BtnEditar.Size = new Size(103, 52);
            BtnEditar.TabIndex = 2;
            BtnEditar.Text = "Editar";
            BtnEditar.UseVisualStyleBackColor = true;
            BtnEditar.Click += EditarAction;
            // 
            // BtnExcluir
            // 
            BtnExcluir.Location = new Point(230, 386);
            BtnExcluir.Name = "BtnExcluir";
            BtnExcluir.Size = new Size(103, 52);
            BtnExcluir.TabIndex = 3;
            BtnExcluir.Text = "Excluir";
            BtnExcluir.UseVisualStyleBackColor = true;
            BtnExcluir.Click += ExcluirAction;
            // 
            // TelaPrincipal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(BtnExcluir);
            Controls.Add(BtnEditar);
            Controls.Add(BtnNovo);
            Controls.Add(TabelaFuncionarios);
            Name = "TelaPrincipal";
            Text = "Tela Principal";
            ((System.ComponentModel.ISupportInitialize)TabelaFuncionarios).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView TabelaFuncionarios;
        private Button BtnNovo;
        private Button BtnEditar;
        private Button BtnExcluir;
    }
}
