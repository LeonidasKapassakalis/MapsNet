using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using System.Data.SQLite;

namespace Maps
{
    public partial class Form1 : Form
    {
        DataView GlobalDV;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ShowDataToGrid(dataGridView1);
            gMap.MapProvider = GMap.NET.MapProviders.GoogleMapProvider.Instance;
            GMap.NET.GMaps.Instance.Mode = GMap.NET.AccessMode.ServerOnly;
            gMap.SetPositionByKeywords("Paris, France");
            gMap.ShowCenter = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            gMap.SetPositionByKeywords("Paris, France"); //("Athens, Greece");
            gMap.Zoom = 13;
            gMap.ZoomAndCenterMarkers("Paris, France"); //("Athens, Greece");

            GMap.NET.WindowsForms.GMapOverlay markers = new GMap.NET.WindowsForms.GMapOverlay("markers");
            GMap.NET.WindowsForms.GMapMarker marker =
                new GMap.NET.WindowsForms.Markers.GMarkerGoogle(
                    new GMap.NET.PointLatLng(48.8617774, 2.349272),
                    GMap.NET.WindowsForms.Markers.GMarkerGoogleType.blue_pushpin);
            markers.Markers.Add(marker);
            gMap.Overlays.Add(markers);
        }
        private void gMap_OnMarkerClick(GMap.NET.WindowsForms.GMapMarker item, MouseEventArgs e)
        {
            Console.WriteLine(String.Format("Marker {0} was clicked.", item.Tag));
            MessageBox.Show("Help");
        }

        public void ShowDataToGrid(DataGridView Grid)
        {
            string dbFilePath = @"sqldb.db";
            SQLiteConnectionStringBuilder aaa = new SQLiteConnectionStringBuilder();
            aaa.DataSource = dbFilePath;
            SQLiteConnection sqlConn = new SQLiteConnection(aaa.ConnectionString);
            string SelectSt = "SELECT * FROM " + "GeoData";
            //                          "ORDER BY C.Name, P.Year, PR.Name, P.Sn ";

            SQLiteCommand cmd = new SQLiteCommand(SelectSt, sqlConn);

            SQLiteDataReader reader;
            DataTable Schemadt;
            sqlConn.Open();
            reader = cmd.ExecuteReader();
            Schemadt = reader.GetSchemaTable();


            //Dictionary<string, TableFieldItem> tfd = stTableFields.TableFieldsDic;

            try
            {

                DataTable dt = new DataTable();

                foreach (DataRow myField in Schemadt.Rows)
                {
                    //dt.Columns.Add(myField["ColumnName"].ToString());
                    //string aa = FormTableName.ToUpper() + "." + myField["ColumnName"].ToString().Trim().ToUpper();

                    //String a1 = myField["ColumnName"].ToString().Trim();
                    //int len = myField["ColumnName"].ToString().Trim().Length;
                    //String a2 = myField["ColumnName"].ToString().Trim().ToUpper().Substring(len - 2, 2);   //Left(len-2);

                    //TableFieldItem tfi = tfd[aa];
                    //if (tfi is null)
                        dt.Columns.Add(myField["ColumnName"].ToString());
                    //else
                    //{
                        //DataColumn dc = new DataColumn(myField["ColumnName"].ToString());
                        //dc.Caption = tfi.Description.ToString();
                        //dt.Columns.Add(dc);
                    //}
                    //String a1 = myField["ColumnName"].ToString().Trim();
                    //int len = myField["ColumnName"].ToString().Trim().Length;
                    //String a2 = myField["ColumnName"].ToString().Trim().ToUpper().Substring(len - 2, 2);   //Left(len-2);

                    /*if ((a2.ToUpper() == "ID") && (len > 2))
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

                            SQLiteConnection sqlConn0 = new SQLiteConnection("sqldb.db");
                            string SelectSt0 = "SELECT id, name FROM  " + TableNamme;
                            SQLiteCommand cmd0 = new SQLiteCommand(SelectSt0, sqlConn0);
                            sqlConn0.Open();
                            SQLiteDataReader reader0 = cmd0.ExecuteReader();

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
                    }*/
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

                //Grid.Columns["Id"].SortMode = DataGridViewColumnSortMode.Automatic;

                //foreach (DataGridViewColumn dgvc in Grid.Columns)
                //{
//                    string aa = FormTableName.ToUpper() + "." + dgvc.Name.ToString().Trim().ToUpper();
  //                  if (tfd.ContainsKey(aa))
    //                {
      //                  TableFieldItem tfi = tfd[aa];
        //                if (!(tfi is null))
          //                  dgvc.HeaderText = tfi.Description.ToString();
            //        }
                //}

            }
            catch (Exception ex)
            {
                MessageBox.Show("The following error occurred: " + ex.Message);
            }
            sqlConn.Close();
            sqlConn.Open();

            //reader = cmd.ExecuteReader(CommandBehavior.KeyInfo);
            //Schemadt = reader.GetSchemaTable();

            //PopulateForm(reader, Schemadt, panel4);


        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            gMap.SetPositionByKeywords("Paris, France"); //("Athens, Greece");
            gMap.Zoom = 13;
            gMap.ZoomAndCenterMarkers("Paris, France"); //("Athens, Greece");

            GMap.NET.WindowsForms.GMapOverlay markers = new GMap.NET.WindowsForms.GMapOverlay("markers");
            GMap.NET.WindowsForms.GMapMarker marker =
                new GMap.NET.WindowsForms.Markers.GMarkerGoogle(
                    new GMap.NET.PointLatLng(48.8617774, 2.349272),
                    GMap.NET.WindowsForms.Markers.GMarkerGoogleType.blue_pushpin);
            markers.Markers.Add(marker);
            gMap.Overlays.Add(markers);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Double lo = 0;
            Double la=0;
            String loc ="";
            GMap.NET.WindowsForms.GMapOverlay markers1 = new GMap.NET.WindowsForms.GMapOverlay("markers1");
            foreach (DataGridViewRow drrow in dataGridView1.SelectedRows)
                {
                
                Double.TryParse(drrow.Cells["Longitude"].Value.ToString(),out lo);
                Double.TryParse(drrow.Cells["Latitude"].Value.ToString(),out la);
                loc = drrow.Cells["Longitude"].Value.ToString() + " , " + drrow.Cells["Latitude"].Value.ToString();
                GMap.NET.WindowsForms.GMapMarker marker1 =
                new GMap.NET.WindowsForms.Markers.GMarkerGoogle(
                    new GMap.NET.PointLatLng(la,lo),
                    GMap.NET.WindowsForms.Markers.GMarkerGoogleType.blue_pushpin);
                markers1.Markers.Add(marker1);
            }
///            markers.Markers.Add(marker);
            gMap.Overlays.Add(markers1);
            gMap.SetPositionByKeywords(loc);
            gMap.ZoomAndCenterMarkers(loc);
            gMap.Position = new GMap.NET.PointLatLng(la,lo);

        }

        private void FilterLonLat(float Lon,float Lat)
        {
            float fromLon, toLon;
            float fromLat, toLat;

            fromLon = Lon - (float)0.0007;
            fromLat = Lat - (float)0.0007;
            toLon   = Lon - (float)0.0007;
            toLat   = Lat - (float)0.0007;

            String aaa = "Longtitude >=" + fromLon.ToString() + " AND " + "Longtitude <=" + toLon.ToString() +
                         "Latitude >=" + fromLat.ToString() + " AND " + "Latitude <=" + toLat.ToString();

            if (GlobalDV.RowFilter is null)
            {
                GlobalDV.RowFilter = aaa;
            }
            else
            {
                GlobalDV.RowFilter = GlobalDV.RowFilter + aaa;
            }

        }

    }
}
