using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BingoManager.Banco;

namespace BingoManager
{
    public partial class StartScreen : Form
    {
        int ReturnBtnFunc = 1;
        int CellColor = 0;

        public StartScreen()
        {
            InitializeComponent();
        }

        //Botões
        private void btnCreate_Click(object sender, EventArgs e)
        {
            StartPanel.Enabled = false;
            StartPanel.Visible = !StartPanel.Visible;

            CreationPanel.Enabled = true;
            CreationPanel.Visible = !CreationPanel.Visible;

            TitleChange();
        }

        private void btnNewList_Click(object sender, EventArgs e)
        {
            CreationPanel.Enabled = false;

            NewList listCreation = new NewList(this);
            listCreation.Show();

            btnReturnStart.Enabled = false;
        }

        private void btnNewCompany_Click(object sender, EventArgs e)
        {
            CreationPanel.Enabled = false;

            NewCompany companyCreation = new NewCompany(this);
            companyCreation.Show();

            btnReturnStart.Enabled = false;
        }

        private void btnNewCards_Click(object sender, EventArgs e)
        {
            CreationPanel.Enabled = false;

            NewCard cardCreation = new NewCard(this);
            cardCreation.Show();

            btnReturnStart.Enabled = false;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            StartPanel.Enabled = false;
            StartPanel.Visible = !StartPanel.Visible;

            EditPanel.Enabled = true;
            EditPanel.Visible = !EditPanel.Visible;

            TitleChange();
        }

        private void EditLists_Click(object sender, EventArgs e)
        {
            EditPanel.Enabled = false;
            EditPanel.Visible = false;

            ListEditPanel.Enabled = true;
            ListEditPanel.Visible = true;

            AttTables();
        }

        //Atualização de Tabelas
        public void AttTables()
        {
            AllCompanyList.DataSource = Banco.CompanyDataAccess.ShowAllCompany();
            
            // Configure DataGridView columns
            AllCompanyList.Columns.Clear();

            DataGridViewCheckBoxColumn selectColumn = new DataGridViewCheckBoxColumn();
            selectColumn.Name = "Select";
            selectColumn.HeaderText = "";
            selectColumn.Width = 50; // Largura da coluna de seleção
            AllCompanyList.Columns.Add(selectColumn);

            DataGridViewColumn nameColumn = new DataGridViewTextBoxColumn();
            nameColumn.Name = "Name";
            nameColumn.HeaderText = "Nome";
            nameColumn.DataPropertyName = "Name"; // Ensure it matches the column name in the DataTable
            nameColumn.Width = 200;
            nameColumn.ReadOnly = true;
            AllCompanyList.Columns.Add(nameColumn);

            DataGridViewColumn cardNameColumn = new DataGridViewTextBoxColumn();
            cardNameColumn.Name = "CardName";
            cardNameColumn.HeaderText = "Nome para Cartela";
            cardNameColumn.DataPropertyName = "CardName"; // Ensure it matches the column name in the DataTable
            cardNameColumn.Width = 200;
            cardNameColumn.ReadOnly = true;
            AllCompanyList.Columns.Add(cardNameColumn);

            DataGridViewImageColumn logoColumn = new DataGridViewImageColumn();
            logoColumn.Name = "Logo";
            logoColumn.HeaderText = "Logo";
            logoColumn.DataPropertyName = "Logo"; // Ensure it matches the column name in the DataTable
            logoColumn.Width = 100;
            logoColumn.ReadOnly = true;
            logoColumn.ImageLayout = DataGridViewImageCellLayout.Zoom; // To resize the image within the cell
            AllCompanyList.Columns.Add(logoColumn);

            // Adjust DataGridView properties
            AllCompanyList.AllowUserToAddRows = false;
            AllCompanyList.AllowUserToDeleteRows = false;
            AllCompanyList.AllowUserToResizeColumns = false;
            AllCompanyList.AllowUserToResizeRows = false;
            AllCompanyList.ReadOnly = false;
            AllCompanyList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            AllCompanyList.RowHeadersWidth = 50; // Fix width of row header
            AllCompanyList.RowHeadersVisible = false; // Hide the row header if not needed

            // Event handlers for changing row color based on checkbox state
            AllCompanyList.CellValueChanged += AllCompanyList_CellValueChanged;
            AllCompanyList.CurrentCellDirtyStateChanged += AllCompanyList_CurrentCellDirtyStateChanged;
            AllCompanyList.CellFormatting += AllCompanyList_CellFormatting;
        }

        private void AllCompanyList_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (AllCompanyList.Columns[e.ColumnIndex] is DataGridViewImageColumn)
            {
                string imagePath = e.Value?.ToString();
                if (!string.IsNullOrEmpty(imagePath))
                {
                    // Construir o caminho completo da imagem
                    string fullPath = Path.Combine(Application.StartupPath, "Images", imagePath);

                    if (File.Exists(fullPath))
                    {
                        try
                        {
                            e.Value = Image.FromFile(fullPath);
                            e.FormattingApplied = true;
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Erro ao carregar imagem: {ex.Message}");
                            e.Value = null;
                        }
                    }
                    else
                    {
                        e.Value = null;
                    }
                }
            }
        }

        private void AllCompanyList_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (AllCompanyList.CurrentCell is DataGridViewCheckBoxCell)
            {
                AllCompanyList.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void AllCompanyList_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == AllCompanyList.Columns["Select"].Index)
            {
                DataGridViewCheckBoxCell checkBoxCell = (DataGridViewCheckBoxCell)AllCompanyList.Rows[e.RowIndex].Cells["Select"];
                DataGridViewRow row = AllCompanyList.Rows[e.RowIndex];

                if ((bool)checkBoxCell.Value)
                {
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        cell.Style.BackColor = Color.Empty; // Remove a cor de fundo
                        cell.Style.SelectionBackColor = Color.Empty; // Remove a cor de fundo na seleção
                        cell.Style.ForeColor = Color.Empty; // Remove a cor do texto
                    }
                    row.DefaultCellStyle.BackColor = Color.LightBlue;
                    CellColor = 1;
                }
                else
                {
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        cell.Style.BackColor = Color.Empty; // Remove a cor de fundo
                        cell.Style.SelectionBackColor = Color.Empty; // Remove a cor de fundo na seleção
                        cell.Style.ForeColor = Color.Empty; // Remove a cor do texto
                    }
                    row.DefaultCellStyle.BackColor = Color.White;
                    CellColor = 0;
                }
            }
        }

        private void AllCompanyList_SelectionChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewCell cell in ((DataGridView)sender).SelectedCells)
            {
                if (CellColor == 1)
                {
                    cell.Style = new DataGridViewCellStyle()
                    {
                        BackColor = Color.LightBlue,
                        SelectionBackColor = Color.LightBlue,
                        SelectionForeColor = Color.Black
                    };
                } else
                {
                    cell.Style = new DataGridViewCellStyle()
                    {
                        BackColor = Color.White,
                        SelectionBackColor = Color.White,
                        SelectionForeColor = Color.Black
                    };
                }
            }
        }

        private void AllCompanyList_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            foreach (DataGridViewCell cell in ((DataGridView)sender).SelectedCells)
            {
                if (CellColor == 1)
                {
                    cell.Style = new DataGridViewCellStyle()
                    {
                        BackColor = Color.LightBlue,
                        SelectionBackColor = Color.LightBlue,
                        SelectionForeColor = Color.Black
                    };
                }
                else
                {
                    cell.Style = new DataGridViewCellStyle()
                    {
                        BackColor = Color.White,
                        SelectionBackColor = Color.White,
                        SelectionForeColor = Color.Black
                    };
                }
            }
        }

        //Return and Close Button
        private void btnReturnStart_Click(object sender, EventArgs e)
        {
            if (ReturnBtnFunc == 1)
            {
                this.Close();
            }
            if (ReturnBtnFunc == 2)
            {
                CreationPanel.Enabled = false;
                CreationPanel.Visible = false;

                EditPanel.Enabled = false;
                EditPanel.Visible = false;

                ListEditPanel.Enabled = false;
                ListEditPanel.Visible = false;

                StartPanel.Enabled = true;
                StartPanel.Visible = true;

                TitleChange();
            }
        }

        public void TitleChange()
        {
            if (StartPanel.Visible)
            {
                BingoTitle.Text = "Bingo Manager";
                btnReturnStart.Text = "Fechar";
                ReturnBtnFunc = 1;
            }
            if (CreationPanel.Visible)
            {
                BingoTitle.Text = "Bingo Manager";
                btnReturnStart.Text = "Voltar";
                ReturnBtnFunc = 2;
            }
            if (EditPanel.Visible)
            {
                BingoTitle.Text = "Bingo Manager";
                btnReturnStart.Text = "Voltar";
                ReturnBtnFunc = 2;
            }
            if (ListEditPanel.Visible)
            {
                BingoTitle.Text = "Editar Listas";
                btnReturnStart.Text = "Voltar";
                ReturnBtnFunc = 2;
            }
        }
    }
}
