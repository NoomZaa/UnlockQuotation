using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;



namespace UnlockQuotation
{
    public partial class Form1 : Form
    {

        public SqlConnection cnn;

        public string quotation = "";

       

        private void Form1_Load(object sender, System.EventArgs e)
        {
            
        }


        public Form1()
        {
            InitializeComponent();
            connectDatabase();

        }

        public void connectDatabase()
        {
            string connetionString = "";
            
            connetionString = "Data Source=192.168.1.1;Initial Catalog=BWG_AWSDB;Persist Security Info=True;User ID=Test;Password=Test";
            cnn = new SqlConnection(connetionString);
            try
            {
                cnn.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Can not open connection ! !");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            quotation =  txtQtc.Text;

            string sql = "select CompanyName,QuotationNo,isApproved from tbQuotationHeader LEFT JOIN tbCustomer on tbQuotationHeader.CompanyID = tbCustomer.CompanyID where QuotationNo = '" + quotation +"'";
            
            SqlDataAdapter da = new SqlDataAdapter(sql, cnn);
            DataTable dt = new DataTable();
            da.Fill(dt);

            

            if (dt != null && dt.Rows.Count > 0)
            {
                DataGrid.DataSource = dt;
            }
            else
            {
                MessageBox.Show("ไม่พบข้อ");
            }


        }

        private void UnLock_Click(object sender, EventArgs e)
        {
            DialogResult Yes = MessageBox.Show("คุณค้องการเปลี่ยนสถานะ Approved จาก Y เป็น 'N' ใช่หรือไม่ ", "กรุณายืนยัน", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if(Yes == DialogResult.Yes)
            {
                string unlock = "update tbQuotationHeader set isApproved = 'N' where QuotationNo = '" + quotation + "'";
                SqlDataAdapter da = new SqlDataAdapter(unlock, cnn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                

                string sql1 = "select CompanyName,QuotationNo,isApproved from tbQuotationHeader LEFT JOIN tbCustomer on tbQuotationHeader.CompanyID = tbCustomer.CompanyID where QuotationNo = '" + quotation + "'";

                SqlDataAdapter da1 = new SqlDataAdapter(sql1, cnn);
                DataTable dt1 = new DataTable();
                da1.Fill(dt1);

                if (dt1 != null && dt1.Rows.Count > 0)
                {
                    DataGrid.DataSource = dt1;
                }
                MessageBox.Show("ดำเนินการเรียบร้อย");
                cnn.Close();
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}