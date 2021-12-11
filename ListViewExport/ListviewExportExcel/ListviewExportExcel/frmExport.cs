namespace ListviewExportExcel
{
    public partial class frmExport : Form
    {
        public frmExport()
        {
            InitializeComponent();
        }

        private void frmExport_Load(object sender, EventArgs e)
        {
            lvlContatos.View = View.Details;
            lvlContatos.FullRowSelect = true;
            lvlContatos.GridLines = true;  
            lvlContatos.LabelEdit = true;

            lvlContatos.Columns.Add("Nome",300, HorizontalAlignment.Left);
            lvlContatos.Columns.Add("Celular", 150, HorizontalAlignment.Right) ;
            lvlContatos.Columns.Add("Email",300 , HorizontalAlignment.Left);

            txtNome.Select();
        }


        private void btnInserir_Click(object sender, EventArgs e)
        {
            if (txtNome.Text.Trim().Equals(String.Empty))
            {
                MessageBox.Show("Informe Nome", this.Text,MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
            else if (!msktextCelular.MaskCompleted)
            {
                    
                MessageBox.Show("Informe Celular", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

             }
            else if (txtEmail.Text.Trim().Equals(String.Empty))
            {

                MessageBox.Show("Informe Email", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            ListViewItem lvi = new ListViewItem(txtNome.Text.Trim());
            lvi.SubItems.Add(msktextCelular.Text);
            lvi.SubItems.Add(txtEmail.Text.Trim());

            lvlContatos.Items.Add(lvi);

            txtNome.Text = String.Empty;
            msktextCelular.Text = String.Empty;
            txtEmail.Text = String.Empty;





        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            txtNome.Text = String.Empty;
            msktextCelular.Text = String.Empty;
            txtEmail.Text = String.Empty;
            lvlContatos.Items.Clear();
            
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            Microsoft.Office.Interop.Excel.Application app = new Microsoft.Office.Interop.Excel.Application();
            app.Visible = true;
            Microsoft.Office.Interop.Excel.Workbook wb = app.Workbooks.Add(1);
            Microsoft.Office.Interop.Excel.Worksheet ws = (Microsoft.Office.Interop.Excel.Worksheet) app.Worksheets[1];
            int linha = 1;
            int coluna = 1;

            ws.Cells[1, 1] = lvlContatos.Columns[0].Text;
            ws.Cells[1, 2] = lvlContatos.Columns[1].Text;
            ws.Cells[1, 3] = lvlContatos.Columns[2].Text;

            linha++;

            foreach (ListViewItem lvi in lvlContatos.Items  )
            {
                coluna = 1;
                foreach (ListViewItem.ListViewSubItem lvs in lvi.SubItems)
                {
                   
                    ws.Cells[linha, coluna] = lvs.Text;
                    coluna++;

                }
                linha++;
            }


        }

        
    }
}