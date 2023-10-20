using Microsoft.Data.SqlClient;

namespace DemoDisconnectedLayer
{
    public partial class frmMyStore : Form
    {
        public frmMyStore()
        {
            InitializeComponent();
        }

        DataSet dsMystore = new DataSet();
        private void frmMyStore_Load(object sender, EventArgs e)
        {
            string ConnectionString = "Server=(local); uid=sa; pwd=3011; database=MyStore";
            string SQL = "Select ProductID, ProductName, UnitsInStock From Products ; Select * From Categories";
            try
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter(SQL, ConnectionString);
                dataAdapter.Fill(dsMystore);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Get data from database");
            }
        }

        private void btnViewProducts_Click(object sender, EventArgs e)
        {
            dvgData.DataSource = dsMystore.Table[0];
        }

        private void btnViewCategories_Click(object sender, EventArgs e)
        {
            dvgData.DataSource = dsMystore.Table[1];
        }

        private void btnClose_Click(object sender, EventArgs e)=>this.Close();
    }
}