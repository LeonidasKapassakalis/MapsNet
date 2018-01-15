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
using MsgBox;

namespace Maps
{
    public partial class Form2 : Form
    {
        DataView GlobalDV;

        public Form2()
        {
            List<string> NonDispFields = new List<string>();
            NonDispFields.Add("Id".ToUpper());
            NonDispFields.Add("Longitude".ToUpper());
            NonDispFields.Add("Latitude".ToUpper());
            NonDispFields.Add("Rating".ToUpper());
            NonDispFields.Add("Place_id".ToUpper());
            NonDispFields.Add("Locality".ToUpper());
            NonDispFields.Add("Admin_Area_level_5".ToUpper());
            NonDispFields.Add("Admin_Area_level_4".ToUpper());
            NonDispFields.Add("Admin_Area_level_3".ToUpper());
            NonDispFields.Add("Admin_Area_level_2".ToUpper());
            NonDispFields.Add("Admin_Area_level_1".ToUpper());
            NonDispFields.Add("Country".ToUpper());
            InitializeComponent();
            ShowDataToGrid(dataGridView1, NonDispFields);
            DispMap();
            //FilterLonLat((float)32.000, (float)27.000);
        }

        public Form2(double Lon, double Lat):this()
        {
            FilterLonLat(Lat, Lon);
        }



        private void Form2_Load(object sender, EventArgs e)
        {
/*            ShowDataToGrid(dataGridView1);
            gMap.MapProvider = GMap.NET.MapProviders.GoogleMapProvider.Instance;
            GMap.NET.GMaps.Instance.Mode = GMap.NET.AccessMode.ServerOnly;
            gMap.SetPositionByKeywords("Paris, France");
            gMap.ShowCenter = false;*/
        }

        private void button1_Click(object sender, EventArgs e)
        {
/*            gMap.SetPositionByKeywords("Athens, Greece"); //("Athens, Greece");
            gMap.Zoom = 13;
            gMap.ZoomAndCenterMarkers("Athens, Greece"); //("Athens, Greece");

            GMap.NET.WindowsForms.GMapOverlay markers = new GMap.NET.WindowsForms.GMapOverlay("markers");
            GMap.NET.WindowsForms.GMapMarker marker =
                new GMap.NET.WindowsForms.Markers.GMarkerGoogle(
                    new GMap.NET.PointLatLng(48.8617774, 2.349272),
                    GMap.NET.WindowsForms.Markers.GMarkerGoogleType.blue_pushpin);
            markers.Markers.Add(marker);
            gMap.Overlays.Add(markers);
*/
        }
        private void gMap_OnMarkerClick(GMap.NET.WindowsForms.GMapMarker item, MouseEventArgs e)
        {
            Console.WriteLine(String.Format("Marker {0} was clicked.", item.Tag));
            MessageBox.Show(item.Tag.ToString());
        }

        public void ShowDataToGrid(DataGridView Grid,List<string> NonDispFields)
        {
            string dbFilePath = @"Stationsdb.db";
            SQLiteConnectionStringBuilder aaa = new SQLiteConnectionStringBuilder();
            aaa.DataSource = dbFilePath;
            SQLiteConnection sqlConn = new SQLiteConnection(aaa.ConnectionString);
            string SelectSt = "SELECT * FROM " + "GeoStations";
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
                foreach (DataGridViewColumn t in Grid.Columns)
                { if (NonDispFields.Contains(t.Name.ToUpper()))
                            {
                        t.Visible = false; }
                    t.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                }


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
            gMap.SetPositionByKeywords("Athens, Greece"); //("Athens, Greece");
            gMap.Zoom = 13;
            gMap.ZoomAndCenterMarkers("Athens, Greece"); //("Athens, Greece");

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
            Double la = 0;
            String loc = "";
            GMap.NET.WindowsForms.GMapOverlay markers1 = new GMap.NET.WindowsForms.GMapOverlay("markers1");
            foreach (DataGridViewRow drrow in dataGridView1.SelectedRows)
            {

                Double.TryParse(drrow.Cells["Longitude"].Value.ToString(), out lo);
                Double.TryParse(drrow.Cells["Latitude"].Value.ToString(), out la);
                loc = drrow.Cells["Longitude"].Value.ToString() + " , " + drrow.Cells["Latitude"].Value.ToString();
                GMap.NET.WindowsForms.GMapMarker marker1 =(
                new GMap.NET.WindowsForms.Markers.GMarkerGoogle(
                    new GMap.NET.PointLatLng(la, lo),
                    GMap.NET.WindowsForms.Markers.GMarkerGoogleType.blue_pushpin));
                marker1.Tag = drrow.Cells["Address"].Value.ToString();
                markers1.Markers.Add(marker1);
            }
            ///            markers.Markers.Add(marker);
            gMap.Overlays.Add(markers1);
            gMap.SetPositionByKeywords(loc);
            gMap.ZoomAndCenterMarkers(loc);
            gMap.Position = new GMap.NET.PointLatLng(la, lo);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            gMap.Overlays.Clear();
            gMap.Refresh();
        }

        private void gMap_OnMarkerEnter(GMap.NET.WindowsForms.GMapMarker item)
        {
            this.label1.Text=item.Tag.ToString();
        }

        private void gMap_OnMarkerLeave(GMap.NET.WindowsForms.GMapMarker item)
        {
            this.label1.Text = "";
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            Double lo = 0;
            Double la = 0;
            String loc = "";
            GMap.NET.WindowsForms.GMapOverlay markers1 = new GMap.NET.WindowsForms.GMapOverlay("markers1");
            foreach (DataGridViewRow drrow in dataGridView1.SelectedRows)
            {
                Double.TryParse(drrow.Cells["Longitude"].Value.ToString(), out lo);
                Double.TryParse(drrow.Cells["Latitude"].Value.ToString(), out la);
                loc = drrow.Cells["Longitude"].Value.ToString() + " , " + drrow.Cells["Latitude"].Value.ToString();
            }
            gMap.ZoomAndCenterMarkers(loc);
            gMap.Position = new GMap.NET.PointLatLng(la, lo);
            gMap.Zoom = gMap.Zoom + 2;
        }
        private void FilterLonLat(double Lon, double Lat)
        {
            double fromLon, toLon;
            double fromLat, toLat;

            fromLon = Lon - (double)0.004;
            fromLat = Lat - (double)0.004;
            toLon   = Lon + (double)0.004;
            toLat   = Lat + (double)0.004;

            String aaa = "Longitude >= " + fromLon.ToString() + " AND " + "Longitude <= " + toLon.ToString() + " AND "+
                         "Latitude >= " + fromLat.ToString() + " AND " + "Latitude <= " + toLat.ToString();

            this.Text = aaa;

            if (GlobalDV.RowFilter is null)
            {
                GlobalDV.RowFilter = aaa;
            }
            else
            {
                GlobalDV.RowFilter = aaa;
                //GlobalDV.RowFilter = GlobalDV.RowFilter + aaa;
            }

            dataGridView1.DataSource = GlobalDV;
        }

        private void DispMap()
        {
            gMap.MapProvider = GMap.NET.MapProviders.GoogleMapProvider.Instance;
            GMap.NET.GMaps.Instance.Mode = GMap.NET.AccessMode.ServerAndCache; //ServerOnly;
            gMap.SetPositionByKeywords("Athens, Greece");
            gMap.ShowCenter = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            AddressGeocodeing();
        }

        private void AddressGeocodeing()
        {
            //GMap.NET.GeocodingProvider = 
            float tmpLatitude=0;
            float tmpLongitude=0;

            Geocoding.Google.GoogleGeocoder gk = new Geocoding.Google.GoogleGeocoder("AIzaSyCxAKDi4ZgokHWCYK_5sQ8Dg-nlcLT2myo");
            gk.Language = "EL";
            String Addr = DoBoxClick();
            foreach (Geocoding.Google.GoogleAddress aa in gk.Geocode(Addr))
            {
                //MessageBox.Show(aa.ToString());
                //MessageBox.Show(aa.Coordinates.Latitude.ToString());
                //MessageBox.Show(aa.Coordinates.Longitude.ToString());
                //MessageBox.Show(aa.FormattedAddress.ToString());
                gMap.Position = new GMap.NET.PointLatLng(aa.Coordinates.Latitude, aa.Coordinates.Longitude);
                gMap.Zoom = 22;
                tmpLatitude  = (float)aa.Coordinates.Latitude;
                tmpLongitude = (float)aa.Coordinates.Longitude;
            }
            FilterLonLat(tmpLongitude, tmpLatitude);

            //List<Geocoding.Google.GoogleAddress> aaa = (List<Geocoding.Google.GoogleAddress >)gk.Geocode("Κουσιανόφσκυ 2-6");

        }

        private String DoBoxClick()
        {
            //Set buttons language Czech/English/German/Slovakian/Spanish (default English)
            InputBox.SetLanguage(InputBox.Language.English);
            //Save the DialogResult as res
            DialogResult res = InputBox.ShowDialog("Διεύθυνση:", "Combo InputBox",   //Text message (mandatory), Title (optional)
                InputBox.Icon.Question,                                                                         //Set icon type Error/Exclamation/Question/Warning (default info)
                //InputBox.Icon.Nothing,
                InputBox.Buttons.OkCancel,                                                                      //Set buttons set OK/OKcancel/YesNo/YesNoCancel (default ok)
                InputBox.Type.TextBox,                                                                         //Set type ComboBox/TextBox/Nothing (default nothing)
                new string[] { "Item1", "Item2", "Item3" },                                                        //Set string field as ComboBox items (default null)
                true,                                                                                           //Set visible in taskbar (default false)
                new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold));                        //Set font (default by system)
            //Check InputBox result
            if (res == System.Windows.Forms.DialogResult.OK || res == System.Windows.Forms.DialogResult.Yes)
                return InputBox.ResultValue;                                                                    //Get returned value
            else
                return "";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DoBoxClick();
        }
    }
}
