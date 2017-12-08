using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace Protocol
{
    public partial class ContactsN : Form
    {
        List<SavedDatasources> LstSDS;
        List<SavedDataCon> LstSDC;
        DataView GlobalDV;
        String FormTableName;

        bool InsertState;
        bool SelectState = true;
        bool AllowChangeTab;
        public List<String> ReturnEmailList;
        public ContactsN()
        {
            LstSDS = new List<SavedDatasources>();
            LstSDC = new List<SavedDataCon>();

            FormTableName = "Contacts";

            InitializeComponent();
            SetMenuState("Browse");
            UpdateHeader(dataGridView1);
            AllowChangeTab = false;

            AutoCompleteStringCollection col = new AutoCompleteStringCollection();
            SearchText2.AutoCompleteCustomSource = col;
            textSelectedMails.Visible = false;

            ShowDataToGrid(dataGridView1);

            StoreBinding();
        }

/// <summary>
/// ////////////////////////////////////////////////////
        public ContactsN(string parFormTableName, Boolean Trig)
        {
            LstSDS = new List<SavedDatasources>();
            LstSDC = new List<SavedDataCon>();

            FormTableName = parFormTableName;

            InitializeComponent();
            SetMenuState("Browse");
            UpdateHeader(dataGridView1);
            AllowChangeTab = false;

            AutoCompleteStringCollection col = new AutoCompleteStringCollection();
            SearchText2.AutoCompleteCustomSource = col;
            textSelectedMails.Visible = false;
            ShowDataToGrid(dataGridView1);
            StoreBinding();
        }



        public ContactsN(string DummyState):this()
        {

            if ((ReturnEmailList is null) || (ReturnEmailList.Count == 0))
            {
                ReturnEmailList = new List<String>();
            }
            dataGridView1.MultiSelect = true;
            textSelectedMails.Visible = true;
            SetMenuState("Selection");
            textSelectedMails.Visible = true;
        }

        private void Contacts_Load(object sender, EventArgs e)
        {
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            frmFilter a = new frmFilter();
            a.PopulateForm(dataGridView1);
            a.Show();
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InsertState = true;
            AllowChangeTab = true;
            tabControl1.SelectedTab = tabPage3;
            panel3.Visible = false;
            SetMenuState("Update");
            ClearBinding();
        }
        private void updToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AllowChangeTab = true;
            tabControl1.SelectedTab = tabPage3;
            panel3.Visible = false;
            SetMenuState("Update");
            RestoreBinding();
        }
        private void postToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Control ctl = (Control)this.ActiveControl;
            Control ctl1 = GetNextControl(ctl, true);
            ctl1.Focus();
            errorProvider1.Clear();

            Dictionary<string, TableFieldItem> tfd = stTableFields.TableFieldsDic;
            Boolean ErrorsFound = false;

            foreach (SavedDataCon lsd in LstSDC)
            {
                string aa = FormTableName.ToUpper() + "." + lsd.DBField.ToString().Trim().ToUpper();
                TableFieldItem tfi = tfd[aa];
                if ( (tfi.Required) && (!(lsd.FormField.Text.Trim().Length > 0)))
                {
                    errorProvider1.SetError(lsd.FormField, "Παρακαλώ κάντε καταχώρηση στο πεδίο.");
                    ErrorsFound = true;
                }
            }

            if (ErrorsFound)
            {
                MessageBox.Show("Αδύνατη η καταχώρηση");
                return;
            }

            if (InsertState)
            {
                DataTable dt = GlobalDV.ToTable();
                DataRow dr = dt.NewRow();

                string fields = "id";
                string valu = getNextIdAndUpdateTable_TableIds(FormTableName).ToString();

                DataView drv01 = (DataView)dataGridView1.DataSource;
                String SortPrev = drv01.Sort;
                DataRowView drv = GlobalDV.AddNew();
                DataRowView drv1 = drv01.AddNew();

                foreach (SavedDataCon lsd in LstSDC)
                {
                    if (lsd.FormField.Text.Trim().Length > 0)
                    {
                        dr[lsd.DBField] = lsd.FormField.Text;
                        drv[lsd.DBField] = lsd.FormField.Text;
                        drv1[lsd.DBField] = lsd.FormField.Text;
                        fields = fields + ',' + lsd.DBField;
                        valu = valu + ',' + lsd.FormField.Text;
                    }
                }

                int NumId = GetTableKey(FormTableName);
                dr["id"] = NumId;
                drv["id"] = NumId;
                drv1["id"] = NumId;
                PerformInsert(fields, valu);

                dataGridView1.DataSource = drv01;

                RestoreBinding();
            }
            else
            {
                int IdNum = 0;
                String IdNumS="";
                DataTable dt = GlobalDV.ToTable();
                DataColumn[] keys = new DataColumn[1];
                keys[0] = dt.Columns["id"];
                dt.PrimaryKey = keys;
                DataRow dr = dt.NewRow();

                DataView drv01 = (DataView)dataGridView1.DataSource;
                String SortPrev = drv01.Sort;

                DataGridViewRow CurRow = dataGridView1.CurrentRow;
                if (!(CurRow is null))
                { 
                    IdNumS = (CurRow.Cells["id"].Value).ToString();
                IdNum = Int32.Parse(IdNumS);
            }
                else
                    IdNum = -1;

//                drv01.FindRows(CurRow.Cells["id"]);
                drv01.Delete(CurRow.Index);

                dt.Rows.Find(IdNum);

//                dt.Rows[0].Delete();

                DataRowView drv = GlobalDV.AddNew();
                DataRowView drv1 = drv01.AddNew();

                string fields = "";
                string valu = "";

                foreach (SavedDataCon lsd in LstSDC)
                {
                    dr[lsd.DBField] = lsd.FormField.Text;
                    drv[lsd.DBField] = lsd.FormField.Text;
                    drv1[lsd.DBField] = lsd.FormField.Text;
                    fields = fields + ',' + lsd.DBField;
                        valu = valu + ',' + lsd.FormField.Text;
                }

                PerformUpdate(fields, valu);
                dataGridView1.DataSource = drv01;
                drv01.Sort = SortPrev;
                drv01.ApplyDefaultSort = true;

                for (int rowIndex=0; rowIndex<dataGridView1.RowCount; rowIndex++)
                   if (dataGridView1.Rows[rowIndex].Cells["id"].Value.ToString()==IdNumS)
                {
                    dataGridView1.ClearSelection();
                    dataGridView1.Rows[rowIndex].Selected = true;
                    dataGridView1.FirstDisplayedScrollingRowIndex = rowIndex;
                    dataGridView1.CurrentCell = dataGridView1.Rows[rowIndex].Cells["id"];
                    dataGridView1.Focus();
                    break;
                }


                //contactsTableAdapter.Update(dr);
                RestoreBinding();
            }

            AllowChangeTab = true;
            tabControl1.SelectedTab = tabPage1;
            panel3.Visible = true;
            SetMenuState("Browse");
            InsertState = false;
            errorProvider1.Clear();
        }

        private void cancelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AllowChangeTab = true;
            tabControl1.SelectedTab = tabPage1;
            panel3.Visible = true;
            SetMenuState("Browse");
            RestoreBinding();
            InsertState = false;
            errorProvider1.Clear();
        }
        private void ClearBinding()
        {
            foreach (SavedDataCon lsd in LstSDC)
            {
                lsd.FormField.Text = "";
            }
        }

        private void StoreBinding()
        {
        }

        private void RestoreBinding()
        {
            foreach (SavedDataCon lsd in LstSDC)
            {
                GlobalDV.RowFilter = "";
                DataGridViewRow CurRow = dataGridView1.CurrentRow;
                if (!(CurRow is null))
                    GlobalDV.RowFilter = "id=" + CurRow.Cells["id"].Value.ToString();
                if (lsd.FormField is TextBox)
                {
                    lsd.FormField.Text = GlobalDV[0][lsd.DBField.ToString()].ToString();
                }
                if (lsd.FormField is DateTimePicker)
                {
                    DateTime dt = new DateTime();
                    if (DateTime.TryParse(GlobalDV[0][lsd.DBField.ToString()].ToString(), out dt))
                        ((DateTimePicker)lsd.FormField).Value = dt;
                }
                if (lsd.FormField is MaskedTextBox)
                {
                    int num;
                    int.TryParse(GlobalDV[0][lsd.DBField.ToString()].ToString(), out num);
                    ((MaskedTextBox)lsd.FormField).Text = GlobalDV[0][lsd.DBField.ToString()].ToString();
                }
                if (lsd.FormField is CheckBox)
                {
                    Boolean bol;
                    Boolean.TryParse(GlobalDV[0][lsd.DBField.ToString()].ToString(), out bol);
                    ((CheckBox)lsd.FormField).Checked = bol;
                }
                if (lsd.FormField is ComboBox)
                {
                    int num;
                    int.TryParse(GlobalDV[0][lsd.DBField.ToString()].ToString(),out num);
                    ((ComboBox)lsd.FormField).SelectedValue = num;
                }
            }
        }

        private void filterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String aaa;
            ToolStripMenuItem Tsmi = (ToolStripMenuItem)sender;
            var Parent = (ContextMenuStrip)Tsmi.GetCurrentParent();
            Control ParentSourceControl = Parent.SourceControl;

            frmFilter a = new frmFilter();
            a.PopulateForm((DataGridView)ParentSourceControl);
            a.ShowDialog();
            aaa=a.KSleo;

            var BS0 = ((DataGridView)ParentSourceControl).DataSource;
            if (BS0 is DataView)
            {
                if (((DataView)BS0).RowFilter is null)
                    ((DataView)BS0).RowFilter = aaa;
                else
                    ((DataView)BS0).RowFilter = ((DataView)BS0).RowFilter + aaa;
            }
            if (BS0 is BindingSource)
                if (((BindingSource)dataGridView1.DataSource).Filter == "")
                    ((BindingSource)dataGridView1.DataSource).Filter = aaa;
                else
                    ((BindingSource)dataGridView1.DataSource).Filter = ((BindingSource)dataGridView1.DataSource).Filter + aaa;
        }

       private void button2_Click(object sender, EventArgs e)
        {
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
        }

        private void filterOnlyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem Tsmi = (ToolStripMenuItem)sender;
            var Par = (ContextMenuStrip)Tsmi.GetCurrentParent();
            Control ff = Par.SourceControl;
            var BS0 = dataGridView1.DataSource;
            if (BS0 is DataView)
                ((DataView)BS0).RowFilter = "";
            if (BS0 is BindingSource)
              ((BindingSource)dataGridView1.DataSource).Filter = "";
        }

        private void filterExactToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem Tsmi = (ToolStripMenuItem)sender;
            var Par = (ContextMenuStrip)Tsmi.GetCurrentParent();
            Control ff = Par.SourceControl;
            var BS0 = ((DataGridView)ff).DataSource;
            int ro = ((DataGridView)ff).CurrentCell.RowIndex;
            int co = ((DataGridView)ff).CurrentCell.ColumnIndex;
            string txt = ((DataGridView)ff).CurrentCell.Value.ToString();
            string txt1 = ((DataGridView)ff).Columns[co].DataPropertyName.ToString();
            string aaa = txt1 + " = '" + txt + "'";

            if (BS0 is DataView)
            {
                if (((DataView)BS0).RowFilter is null)
                    ((DataView)BS0).RowFilter = aaa;
                else
                    ((DataView)BS0).RowFilter = ((DataView)BS0).RowFilter +  aaa;
            }
            if (BS0 is BindingSource)
                if (((BindingSource)BS0).Filter is null)
                    ((BindingSource)BS0).Filter = aaa;
                else
                    ((BindingSource)BS0).Filter = ((BindingSource)BS0).Filter + aaa;
        }

        private void export2ExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
                {
                    excelFormsInterop eF = new excelFormsInterop();
                    DataView BS0 = (DataView)dataGridView1.DataSource;
                    eF.ExportDataViewToExcel(BS0, true, true, FormTableName.ToUpper());
                    eF.Visible = true;
                }
                catch (Exception ex)
                {
                    string exMess = ex.Message; //do nothing - constructor catches the exception
                                                //MessageBox.Show(exMess);
                }
        }

        private BindingSource ReturnBindingSourceMenu(object sender)
        {
            ToolStripMenuItem Tsmi = (ToolStripMenuItem)sender;
            var Par = (ContextMenuStrip)Tsmi.GetCurrentParent();
            Control ff = Par.SourceControl;
            BindingSource BS = (BindingSource)((DataGridView)ff).DataSource;
            return BS;
        }
        private DataGridView ReturnDataGridViewMenu(object sender)
        {
            ToolStripMenuItem Tsmi = (ToolStripMenuItem)sender;
            var Par = (ContextMenuStrip)Tsmi.GetCurrentParent();
            Control ff = Par.SourceControl;
            DataGridView DGV = (DataGridView)ff;
            return DGV;
        }

        private void SearchText_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void UpdateHeader(DataGridView Dgv)
        {
/*            BindingSource bs = (BindingSource)dataGridView1.DataSource;
            DataSet dsTempDataTable = (DataSet)bs.DataSource;
            DataTable dt = dsTempDataTable.Tables[0]; // use table index/name to get the exact table
            int a = 1;
            foreach (DataColumn dc in dt.Columns)
            {
                foreach (DataGridViewColumn gc in dataGridView1.Columns)
                 if (gc.DataPropertyName == dc.ColumnName)
                    {
                        gc.HeaderText = dc.Caption.ToString();
                        gc.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
                    }


            }
*/
        }

        private void SearchText_Enter(object sender, EventArgs e)
        {
            if (((TextBox)sender).Name == "SearchText0")
            {
                if (this.SearchText1.Text.Trim().Length > 0)
                {
                    MessageBox.Show("Υπάρχει καταχώσηση σε άλλο πεδίο εύρεσης");
                    this.SearchText1.Select();
                        }
                if (this.SearchText2.Text.Trim().Length > 0)
                {
                    MessageBox.Show("Υπάρχει καταχώσηση σε άλλο πεδίο εύρεσης");
                    this.SearchText2.Select();
                }
                if (this.SearchText3.Text.Trim().Length > 0)
                {
                    MessageBox.Show("Υπάρχει καταχώσηση σε άλλο πεδίο εύρεσης");
                    this.SearchText3.Select();
                }
            }
            if (((TextBox)sender).Name == "SearchText1")
            {
                if (this.SearchText0.Text.Trim().Length > 0)
                {
                    MessageBox.Show("Υπάρχει καταχώσηση σε άλλο πεδίο εύρεσης");
                    this.SearchText0.Select();
                }
                if (this.SearchText2.Text.Trim().Length > 0)
                {
                    MessageBox.Show("Υπάρχει καταχώσηση σε άλλο πεδίο εύρεσης");
                    this.SearchText2.Select();
                }
                if (this.SearchText3.Text.Trim().Length > 0)
                {
                    MessageBox.Show("Υπάρχει καταχώσηση σε άλλο πεδίο εύρεσης");
                    this.SearchText3.Select();
                }
            }
            if (((TextBox)sender).Name == "SearchText2")
                {
                    if (this.SearchText1.Text.Trim().Length > 0)
                    {
                        MessageBox.Show("Υπάρχει καταχώσηση σε άλλο πεδίο εύρεσης");
                        this.SearchText1.Select();
                    }
                    if (this.SearchText0.Text.Trim().Length > 0)
                    {
                        MessageBox.Show("Υπάρχει καταχώσηση σε άλλο πεδίο εύρεσης");
                        this.SearchText0.Select();
                    }
                if (this.SearchText3.Text.Trim().Length > 0)
                {
                    MessageBox.Show("Υπάρχει καταχώσηση σε άλλο πεδίο εύρεσης");
                    this.SearchText3.Select();
                }

            }
            if (((TextBox)sender).Name == "SearchText3")
            {
                if (this.SearchText0.Text.Trim().Length > 0)
                {
                    MessageBox.Show("Υπάρχει καταχώσηση σε άλλο πεδίο εύρεσης");
                    this.SearchText0.Select();
                }
                if (this.SearchText2.Text.Trim().Length > 0)
                {
                    MessageBox.Show("Υπάρχει καταχώσηση σε άλλο πεδίο εύρεσης");
                    this.SearchText2.Select();
                }
                if (this.SearchText1.Text.Trim().Length > 0)
                {
                    MessageBox.Show("Υπάρχει καταχώσηση σε άλλο πεδίο εύρεσης");
                    this.SearchText1.Select();
                }
            }


        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        public int GetTableKey(string TableName)
        { 
         int NewId = 0;
         /*string constr = "Data Source = MSSQL1;Password=8093570;Persist Security Info=True;User ID=GramV3; Initial Catalog=GramV3-Dev;Data Source=avindomc\\sqlserverr2;Initial File Name=''";
                SqlConnection con = new SqlConnection();
                con.ConnectionString = constr;
                con.Open();
                SqlCommand cmd = new SqlCommand("UpdateKey", con);

                cmd.Parameters.Add(new SqlParameter("@TableName", "Contacts"));
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    MessageBox.Show(rdr[2].ToString());
                    NewId = (int)rdr[2];
                    //Console.WriteLine("Product: {0,-35} Total: {1,12} Total2: {1,12}", rdr[1], rdr[2], rdr[2]);
                }
            */
            return NewId;
         }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AllowChangeTab = true;
            tabControl1.SelectedTab = tabPage3;
            RestoreBinding();

            DialogResult dialogResult = MessageBox.Show("Είστε σίγουροι ότι θέλετε να διαγράψετε την εγγραφή", "Διαγραφή", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                BindingSource bs = (BindingSource)dataGridView1.DataSource;
                DataSet dsTempDataTable = (DataSet)bs.DataSource;
                DataTable dt = dsTempDataTable.Tables[0];
                DataRow datar;
                foreach (DataGridViewRow dr in dataGridView1.SelectedRows)
                {
                    datar = dt.Rows[dr.Index];
                    contactsTableAdapter.Delete((int)datar["id"]);
                    dt.Rows.Remove(datar);
                }
            }
            AllowChangeTab = true;
            tabControl1.SelectedTab = tabPage1;

        }

        private void επιλογήToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if ((ReturnEmailList is null) ||  (ReturnEmailList.Count == 0))
            { 
               ReturnEmailList = new List<String>();
            }
            dataGridView1.MultiSelect = true;
            textSelectedMails.Visible = true;
            SetMenuState("Selection");
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (SelectState)
            {
                if (!(ReturnEmailList is null))
                {
                    foreach (DataGridViewRow dr in dataGridView1.SelectedRows)
                    {
                        String ro = dr.Cells["email"].Value.ToString();
                        if (ro.Trim().Length < 1)
                        {
                            MessageBox.Show("Η επαφή " + dr.Cells["LastName"].Value.ToString() + " " + dr.Cells["FirstName"].Value.ToString() + " δεν έχει διεύθυνση email.");
                        }
                        else
                        {
                            ReturnEmailList.Add(ro.ToString());
                            //MessageBox.Show(dr.Cells["LastName"].Value.ToString()+" "+ dr.Cells["FirstName"].Value.ToString());
                        }
                    }
                    textSelectedMails.Text = string.Join(",", ReturnEmailList);
                    this.Text = "Διευθυνσιογράφος (" + ReturnEmailList.Count.ToString() + ")";
                }
            }
            else
            { }
        }

        private void επιλεγμέναToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string s = string.Join(",", ReturnEmailList);
            MessageBox.Show(string.Join(",", ReturnEmailList)); 
            //foreach (String a in ReturnEmailList)
            //{ MessageBox.Show(a); }
        }


        public List<Control> GetAllControls(Control searchWithin, List<Control> returnList)
        {

            foreach (Control ctrlt in searchWithin.Controls)
            {
                if (ctrlt.GetType().Name.ToUpper() == "MENUSTRIP")
                { 
                    returnList.Add(ctrlt);
                }
                    if (ctrlt.HasChildren)
                    foreach (Control ctrl in ctrlt.Controls)
                        if (ctrl.HasChildren)
                            GetAllControls(ctrl, returnList);
                        else
                            returnList.Add(ctrl);
                else //if searchWithin.HasChildren = False Then
                    foreach (Control ctrl in ctrlt.Controls)
                        returnList.AddRange(GetAllControls(ctrl, returnList));
            }
            return returnList;
        }


        private void SetMenuState(string TagState)
        {
            List<Control> FormControls = new List<Control>();

            FormControls = GetAllControls(this, FormControls);
            foreach (Control c in FormControls)
            {
                if (c.GetType().Name.ToUpper() == "MENUSTRIP")
                {
                    foreach (System.Windows.Forms.ToolStripItem item in ((System.Windows.Forms.MenuStrip)c).Items)
                    {
                        try
                        {
                            if (item.Tag.ToString().ToUpper() == TagState.ToUpper())
                                item.Visible = true;
                            else
                                item.Visible = false;
                        }
                        catch (Exception ex)
                        { }
                    }
                }
            }
        }

        private void έξοδοςToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridView1.MultiSelect = false;
            textSelectedMails.Visible = false;
            SetMenuState("Browse");
        }

        private void SearchTextKeyDown(object sender, KeyEventArgs e)
        {
            BindingSource BS = (BindingSource)(dataGridView1).DataSource;
            String LikeStr = ((TextBox)sender).Tag.ToString();

            if (((TextBox)sender).Text.Trim().Length > 0)
            {
                BS.Filter = LikeStr + " Like '%" + ((TextBox)sender).Text.Trim() + "%'";
            }
            else
            {
                BS.Filter = "";
            }
        }

        private void tabControl1_TabIndexChanged(object sender, EventArgs e)
        {


        }

        private void tabControl1_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (AllowChangeTab)
            {
                AllowChangeTab = false;
            }
            else
            {
                e.Cancel = true;
                AllowChangeTab = false;
            }
        }

        private void SearchTextKeyUp(object sender, KeyEventArgs e)
        {
            DataView BS = (DataView)(dataGridView1).DataSource;
            String LikeStr = ((TextBox)sender).Tag.ToString();

            if (((TextBox)sender).Text.Trim().Length > 2)
            {
                BS.RowFilter = LikeStr + " Like '%" + ((TextBox)sender).Text.Trim() + "%'";
            }
            else
            {
                BS.RowFilter = "";
            }
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show(sender.ToString());
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show(sender.ToString());
                    }

        private void προβολήToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AllowChangeTab = true;
            if (tabControl1.SelectedTab == tabPage1)
            {
                tabControl1.SelectedTab = tabPage3;
                RestoreBinding();
            }
            else
            {
                tabControl1.SelectedTab = tabPage1;
            };

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        public class MyDetails
        {
            public string name;
            public string lname;
            private int id;
            public int Id
            {
                get { return id; }
                set { id = value; }
            }
        }

        public void ShowDataToGrid(DataGridView Grid)
        {
            SqlConnection sqlConn = new SqlConnection(DBInfo.connectionString);
            string SelectSt = "SELECT * FROM " + FormTableName;
            //                          "ORDER BY C.Name, P.Year, PR.Name, P.Sn ";

            SqlCommand cmd = new SqlCommand(SelectSt, sqlConn);

            SqlDataReader reader;
            DataTable Schemadt;
            sqlConn.Open();
            reader = cmd.ExecuteReader();
            Schemadt = reader.GetSchemaTable();


            Dictionary<string, TableFieldItem> tfd = stTableFields.TableFieldsDic;

            try
            {

                DataTable dt = new DataTable();
                
                foreach (DataRow myField in Schemadt.Rows)
                {
                    //dt.Columns.Add(myField["ColumnName"].ToString());
                    string aa = FormTableName.ToUpper() + "." + myField["ColumnName"].ToString().Trim().ToUpper();

                    String a1 = myField["ColumnName"].ToString().Trim();
                    int len = myField["ColumnName"].ToString().Trim().Length;
                    String a2 = myField["ColumnName"].ToString().Trim().ToUpper().Substring(len - 2, 2);   //Left(len-2);

                    TableFieldItem tfi = tfd[aa];
                    if (tfi is null)
                        dt.Columns.Add(myField["ColumnName"].ToString());
                    else
                    {
                        DataColumn dc = new DataColumn(myField["ColumnName"].ToString());
                        dc.Caption  = tfi.Description.ToString();
                        dt.Columns.Add(dc);
                    }
                    //String a1 = myField["ColumnName"].ToString().Trim();
                    //int len = myField["ColumnName"].ToString().Trim().Length;
                    //String a2 = myField["ColumnName"].ToString().Trim().ToUpper().Substring(len - 2, 2);   //Left(len-2);

                    if ((a2.ToUpper() == "ID") && (len>2) )
                    {
                        try
                        {
                            DataGridViewComboBoxColumn DGVC = new DataGridViewComboBoxColumn();
                            int Len = myField["ColumnName"].ToString().Length;
                            String TableNamme = myField["ColumnName"].ToString().Left(Len - 2);

                            if (TableNamme == "Procedure")
                                TableNamme = "Proced";
                            if (TableNamme == "Folder")
                                TableNamme = "VFolders";

                            SqlConnection sqlConn0 = new SqlConnection(DBInfo.connectionString);
                            string SelectSt0 = "SELECT id, name FROM  " + TableNamme;
                            SqlCommand cmd0 = new SqlCommand(SelectSt0, sqlConn0);
                            sqlConn0.Open();
                            SqlDataReader reader0 = cmd0.ExecuteReader();

                            DataTable dt0 = new DataTable();
                            dt0.Columns.Add("Id");
                            dt0.Columns.Add("Name");

                            while (reader0.Read())
                            {
                                DataRow dr1 = dt0.NewRow();
                                int num;
                                int.TryParse(reader0[0].ToString(), out num);
                                dr1[0] = num;
                                dr1[1] = reader0[1].ToString();
                                dt0.Rows.Add(dr1);
                            }
                            //DataGridViewComboBoxColumn DGVC = new DataGridViewComboBoxColumn();
                            DGVC.DataSource = dt0;
                            DGVC.DataPropertyName = myField["ColumnName"].ToString();
                            DGVC.DisplayMember = "Name";
                            DGVC.ValueMember = "Id";
                            Grid.Columns.Add(DGVC);
                            reader0.Close();
                        }
                        finally
                        {
                            //MessageBox.Show("AAAA");
                        }
                    }
                }

                DataColumn[] keys = new DataColumn[1];
                keys[0] = dt.Columns["id"];
                dt.PrimaryKey = keys;

                while (reader.Read())
                {
                    DataRow dr1 = dt.NewRow();
                    for (int c = 0; c <= (reader.FieldCount - 1); c++)
                        dr1[c] = reader[c].ToString();
                    dt.Rows.Add(dr1);

                }
                DataView BS = new DataView(dt);
                BS.ApplyDefaultSort = true;
                GlobalDV = new DataView(dt);
                Grid.DataSource = BS;

                //Grid.Columns.Add(DGVC);

                Grid.Columns["Id"].SortMode = DataGridViewColumnSortMode.Automatic;

                foreach (DataGridViewColumn dgvc in Grid.Columns)
                {
                    string aa = FormTableName.ToUpper() + "." + dgvc.Name.ToString().Trim().ToUpper();
                    if (tfd.ContainsKey(aa))
                    {
                        TableFieldItem tfi = tfd[aa];
                        if (!(tfi is null))
                            dgvc.HeaderText = tfi.Description.ToString();
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("The following error occurred: " + ex.Message);
            }
            sqlConn.Close();
            sqlConn.Open();

            reader = cmd.ExecuteReader(CommandBehavior.KeyInfo);
            Schemadt = reader.GetSchemaTable();

            PopulateForm(reader, Schemadt, panel4);


        }

        int CurTop;
        
        public void PopulateForm(SqlDataReader SqlDr, DataTable dt, Panel ControlContainer)
        {
            CurTop = 0;
            foreach (DataRow myField in dt.Rows)
            {
                String aaa = myField["ColumnName"].ToString();
                if (myField["ColumnName"].ToString().EndsWith("Id") && (myField["ColumnName"].ToString().Trim().Length > 2))
                {
                    CreateLCB0(myField, ControlContainer);
                }
                else
                {
                    CreateEdit(myField, ControlContainer);
                }
            }
        }

        public void CreateEdit(DataRow sdc, Panel ControlContainer)
        {
            Control LEdit;
            Label LLabel;
            String DataTypeName;

            CurTop = CurTop + 30;

            DataTypeName = sdc["DataTypeName"].ToString();
            switch (DataTypeName)
            {
                case "int":
                    LEdit = new MaskedTextBox();
                    ((MaskedTextBox)LEdit).Mask = "00000";
                    LEdit.Name = "NumEdtF" + sdc["ColumnName"].ToString();
                    if (sdc["ColumnName"].ToString().ToUpper() == "ID")
                        LEdit.Enabled = false;
                    break;
                case "datetime":
                    LEdit = new DateTimePicker();
                    LEdit.Name = "DateEdtF" + sdc["ColumnName"].ToString();
                    //                    ((DateTimePicker)LEdit).for
                    break;
                case "date":
                    LEdit = new DateTimePicker();
                    LEdit.Name = "DateEdtF" + sdc["ColumnName"].ToString();
                    //                    ((DateTimePicker)LEdit).for
                    break;
                case "string":
                    LEdit = new TextBox();
                    LEdit.Name = "TxtEdtF" + sdc["ColumnName"].ToString();
                    break;
                case "bit":
                    LEdit = new CheckBox();
                    LEdit.Name = "TxtEdtF" + sdc["ColumnName"].ToString();
                    break;
                case "nvarchar":
                    LEdit = new TextBox();
                    LEdit.Name = "TxtEdtF" + sdc["ColumnName"].ToString();
                    break;
                default:
                    LEdit = new TextBox();
                    LEdit.Name = "OtherEdtF" + sdc["ColumnName"].ToString();
                    break;
            }

            LEdit.AutoSize = false;
            LEdit.Top = CurTop;
            LEdit.Left = 150;
            LEdit.Height = 21;
            LEdit.Font = new Font(LEdit.Font.FontFamily, 12);
            if (LEdit is DateTimePicker)
                LEdit.Width = 250;
            else
                LEdit.Width = ((int)sdc["ColumnSize"] * 10);
            LEdit.Tag = 1;

            if (LEdit.Width > 700)
                LEdit.Width = 700;

            Width = (int)sdc["ColumnSize"];
//            if (Width > 200)
//                LEdit.Width = 190;
//            else
//                LEdit.Width = Width;


            if (LEdit is TextBox)
               ((TextBox)LEdit).MaxLength = (int)sdc["ColumnSize"];
//            if (LEdit is MaskedTextBox)
//                ((MaskedTextBox)LEdit).MaxLength = (int)sdc["NumericPrecision"];


            //LEdit.Text = Width.ToString();
            //LEdit.Text = sdc["ColumnSize"].ToString();
            LEdit.Visible = true;
            //LEdit.Text = "";
            this.toolTip1.SetToolTip(LEdit, sdc["ColumnName"].ToString());
            ControlContainer.Controls.Add(LEdit);

            SavedDataCon Sdc = new SavedDataCon(sdc["ColumnName"].ToString(), LEdit);
            LstSDC.Add(Sdc);

            LLabel = new Label();
            LLabel.Name = 'L' + sdc["ColumnName"].ToString();

            Dictionary<string, TableFieldItem> tfd = stTableFields.TableFieldsDic;
            string aa = FormTableName.ToUpper() + "." + sdc["ColumnName"].ToString().Trim().ToUpper();
            TableFieldItem tfi = tfd[aa];
            if (!(tfi is null))
                LLabel.Text = tfi.Description.ToString();
            else
                LLabel.Text = tfi.Description.ToString();
//            LLabel.Text = sdc["ColumnName"].ToString();
            LLabel.Top = CurTop;
            LLabel.Left = 10;
            LLabel.Height = 21;
            LLabel.Font = new Font(LEdit.Font.FontFamily, 12);
            LLabel.Width = 130;
            LLabel.Height = CurTop + 120;
            LLabel.AutoSize = true;
            ControlContainer.Controls.Add(LLabel);

        }

        public void CreateLCB0(DataRow sdc, Panel ControlContainer)
        {
            ComboBox LComboBox;
            Label    LLabel;
            String   DataTypeName;

            CurTop = CurTop + 30;

            DataTypeName = sdc["DataTypeName"].ToString();

            int Len = sdc["ColumnName"].ToString().Length;
             String TableNamme = sdc["ColumnName"].ToString().Left(Len - 2);

            if (TableNamme == "Procedure")
                TableNamme = "Proced";
            if (TableNamme == "Folder")
                TableNamme = "VFolders";


            SqlConnection sqlConn = new SqlConnection(DBInfo.connectionString);
            string SelectSt = "SELECT id, name FROM  " + TableNamme;
            SqlCommand cmd = new SqlCommand(SelectSt, sqlConn);
            sqlConn.Open();
            SqlDataReader reader = cmd.ExecuteReader();


            DataTable dt = new DataTable();
            dt.Columns.Add("Id");
            dt.Columns.Add("Name");

            while (reader.Read())
            {
                DataRow dr1 = dt.NewRow();
                int num;
                int.TryParse(reader[0].ToString(), out num);
                dr1[0] = num;
                dr1[1] = reader[1].ToString();
                dt.Rows.Add(dr1);
            }


            LComboBox = new ComboBox();
            LComboBox.Name = "Cb" + sdc["ColumnName"].ToString();


            LComboBox.DataSource  = dt;
            LComboBox.DisplayMember = "Name";
            LComboBox.ValueMember = "Id";
            //LComboBox.ValueMember = sdc["ColumnName"].ToString();

//            while (reader.Read())
//            {
                //ComboboxItem tm = new ComboboxItem();
//                tm.Text = Convert.ToString(reader[1]);
//                tm.Value = (int)reader[0];
//                LComboBox.Items.Insert(LComboBox.Items.Count, tm);
//            }
            reader.Close();
            this.toolTip1.SetToolTip(LComboBox, sdc["ColumnName"].ToString());

            LComboBox.Top = CurTop;
            LComboBox.Left = 150;
            LComboBox.Height = 21;
            LComboBox.Font = new Font(LComboBox.Font.FontFamily, 12);
            LComboBox.Width = ((int)sdc["ColumnSize"] * 9);
            LComboBox.Width = 240;

            ControlContainer.Controls.Add(LComboBox);

            SavedDataCon Sdc = new SavedDataCon(sdc["ColumnName"].ToString(), LComboBox);
            LstSDC.Add(Sdc);

            LLabel = new Label();
            LLabel.Name = 'L' + sdc["ColumnName"].ToString();

            Dictionary<string, TableFieldItem> tfd = stTableFields.TableFieldsDic;
            string aa = FormTableName.ToUpper() + "." + sdc["ColumnName"].ToString().Trim().ToUpper();
            TableFieldItem tfi = tfd[aa];
            if (!(tfi is null))
                LLabel.Text = tfi.Description.ToString();
            else
                LLabel.Text = tfi.Description.ToString();
            //            LLabel.Text = sdc["ColumnName"].ToString();
            LLabel.Top = CurTop;
            LLabel.Left = 10;
            LLabel.Height = 21;
            LLabel.Font = new Font(LComboBox.Font.FontFamily, 12);
            LLabel.Width = 130;
            LLabel.Height = CurTop + 120;
            LLabel.AutoSize = true;
            ControlContainer.Controls.Add(LLabel);

        }



        public void PerformInsert(String Items, String Values)
        {
            SqlConnection sqlConn = new SqlConnection(DBInfo.connectionString);
            string InsertSt = "INSERT INTO [dbo].["+ FormTableName + "] ("+ Items+") VALUES ("+ Values+")";

            try
            {
                sqlConn.Open();
                SqlCommand cmd = new SqlCommand(InsertSt, sqlConn);
                cmd.CommandType = CommandType.Text;
                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Η εγγραφή ενημερώθηκε επιτυχώς!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("The following error occurred: " + ex.Message);
            }
        }
        public void PerformUpdate(String Items, String Values)
        {
            SqlConnection sqlConn = new SqlConnection(DBInfo.connectionString);
            string InsertSt = "UPDATE [dbo].["+ FormTableName + "] SET ";
            string InsertSt1 = "";
            string InsertSt2 = "";

            char[] delimiterChars = { ','};

            string[] itemwords  = Items.Split(delimiterChars);
            string[] valuewords = Values.Split(delimiterChars);

            for(int x=0; x < (itemwords.Length-1); x++)
            {
                if (itemwords[x].Trim().Length > 0)
                {
                    if (itemwords[x].ToUpper() == "ID")
                    { InsertSt2 = " WHERE " + itemwords[x] + " = " + valuewords[x]; }
                    else
                    { InsertSt1 = InsertSt1 +  itemwords[x] + " = '" + valuewords[x] + "',"; }
                }
            }

            if (InsertSt1.EndsWith(","))
                InsertSt1 = InsertSt1.Left((InsertSt1.Length - 1));

            try
            {
                sqlConn.Open();
                SqlCommand cmd = new SqlCommand(InsertSt+ InsertSt1+ InsertSt2, sqlConn);
                cmd.CommandType = CommandType.Text;
                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Η εγγραφή ενημερώθηκε επιτυχώς!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("The following error occurred: " + ex.Message);
            }
        }

        private int getNextIdAndUpdateTable_TableIds(string tableName)
        {
            int ret = 0;

            if (tableName.Trim().Length > 0)
            {
                SqlConnection sqlConn = new SqlConnection(DBInfo.connectionString);
                string UpdSt = "UPDATE [dbo].[TableIds] SET NUM = NUM + 1 " +
                    "OUTPUT inserted.NUM " +
                    "WHERE TABLENAME = '" + tableName + "'";
                try
                {
                    sqlConn.Open();
                    SqlCommand cmd = new SqlCommand(UpdSt, sqlConn);
                    cmd.CommandType = CommandType.Text;

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        ret = Convert.ToInt32(reader["NUM"].ToString());
                    }
                    reader.Close();
                    //cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("The following error occurred: " + ex.Message);
                }
            }

            return ret;
        }

    }
}
