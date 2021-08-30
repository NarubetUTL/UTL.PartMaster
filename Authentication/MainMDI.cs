using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using ExcelDataReader;
using Microsoft.VisualBasic;
using System.Xml;
using ClosedXML.Excel;
using System.IO;

namespace Authentication
{
    public partial class MainMDI : Form
    {
        public MainMDI()
        {
            InitializeComponent();
            this.IsMdiContainer = true;
        }
        AccessControl ACC = new AccessControl();
        Application_Profile APP = new Application_Profile();
        PartMaster PM = new PartMaster();
        

        private void ribbonButtonExit_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void MainMDI_Load(object sender, EventArgs e)
        {
            
            this.ACC.ACButtonClicked +=ACC_ACButtonClicked;
            this.ACC.PMButtonClicked += ACC_PMButtonClicked;


            ACC.MdiParent = this;
            ACC.Show();
            ACC.Dock = DockStyle.Fill;
        }
        private void ACC_ACButtonClicked(object sender, EventArgs e)
        {
            APP.MdiParent = this;
            ACC.Hide();
            APP.Show();
            APP.Dock = DockStyle.Fill;

        }
        private void ACC_PMButtonClicked(object sender, EventArgs e)
        {
            PM.MdiParent = this;
            ACC.Hide();

            PM.Show();
            PM.Dock = DockStyle.Fill;
        }
        public void ribbonTabAccess_ActiveChanged(object sender, EventArgs e)
        {
            if (ribbonTabAccess.Active == true)
            {
                APP.MdiParent = this;
                //ACC.Hide();
                APP.Show();
                APP.Dock = DockStyle.Fill;
            }
            
        }

        public void ribbonTabMain_ActiveChanged(object sender, EventArgs e)
        {
            if (ribbonTabMain.Active == true)
            {
                ACC.MdiParent = this;
                APP.Hide();
                ACC.Show();
                PM.Hide();
                ACC.Dock = DockStyle.Fill;
            }
            
        }

        public void buttonAC_Click(object sender, EventArgs e)
        {
            APP.MdiParent = this;
            //ACC.Hide();
            APP.Show();
        }

        private void ribbonTabConversion_ActiveChanged(object sender, EventArgs e)
        {
            if (ribbonTabConversion.Active == true)
            {
                PM.MdiParent = this;
                APP.Hide();
                PM.Show();
                PM.Dock = DockStyle.Fill;
            }
        }

        private void ribbonButtonBrowse_Click(object sender, EventArgs e)
        {
            string filePath = string.Empty;
            string fileExt = string.Empty;
            OpenFileDialog file = new OpenFileDialog(); //open dialog to choose file  
            if (file.ShowDialog() == System.Windows.Forms.DialogResult.OK) //if there is a file choosen by the user  
            {
                filePath = file.FileName; //get the path of the file  
                fileExt = Path.GetExtension(filePath); //get the file extension  
                if (fileExt.CompareTo(".xls") == 0 || fileExt.CompareTo(".xlsx") == 0)
                {
                    try
                    {
                        PM.textBoxBrowse.Text = filePath;

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString());
                    }
                }
                else
                {
                    MessageBox.Show("Please choose .xls or .xlsx file only.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error); //custom messageBox to show error  
                }

            }
        }

        private void ribbonButtonRead_CanvasChanged(object sender, EventArgs e)
        {
            try
            {
                //buttonStart.Enabled = true;
                var filePath = PM.textBoxBrowse.Text;
                using (var stream = File.Open(filePath, FileMode.Open, FileAccess.Read))
                {

                    using (var reader = ExcelReaderFactory.CreateReader(stream))
                    {
                        var result = reader.AsDataSet(new ExcelDataSetConfiguration()
                        {
                            ConfigureDataTable = (_) => new ExcelDataTableConfiguration()
                            {
                                UseHeaderRow = true
                            }
                        });


                        var dt = result.Tables[0];
                        var dt_order = dt.AsEnumerable()
                                         .OrderBy(r => r.Field<Double>("MARK_ID"))
                                         .CopyToDataTable();

                        PM.GLOBAL_DataSource = dt_order;

                        PM.dataGridViewInput.DataSource = PM.GLOBAL_DataSource;
                    }
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ribbonButtonSetIDN_Click(object sender, EventArgs e)
        {
            var myvalue = Interaction.InputBox("Please create new name.", "New Name", "Default");
            PM.IDname = myvalue;
            PM.label2.Text = myvalue;
        }

        private void ribbonButtonConverts_Click(object sender, EventArgs e)
        {
            try
            {
                var dt_result = PM.GetDatatable();
                string current_row = "1";
                string current_ID = "1";
                string next_row = "1";
                string next_ID = "1";
                var dr = dt_result.NewRow();
                var no = 0;
                int state_no1 = 1;
                int col_plus = 1;
                var mark_id = "1";
                string next_col = "1";
                string current_col = "1";
                int LayoutID = 0;
                string LayoutName = PM.IDname;
                int zeroLayout = 10;

                foreach (DataRow dataRow in PM.GLOBAL_DataSource.Rows)
                {
                    current_row = dataRow["MARK_ROW"].ToString();
                    current_col = dataRow["MARK_COLUMN"].ToString();
                    current_ID = dataRow["MARK_ID"].ToString();


                    if (current_row != next_row && col_plus != 21)
                    {
                        LayoutID++;
                        dr["LAYOUT_ID"] = LayoutName + LayoutID.ToString().PadLeft(zeroLayout, '0');
                        dt_result.Rows.Add(dr);
                        dr = dt_result.NewRow();
                        state_no1++;
                        if (state_no1 == 6)
                        {

                            for (int rrr = 6; rrr < 11; rrr++)
                            {
                                dr["MRK_UNIQUE_ID"] = mark_id;
                                for (int coll = 4; coll < 22; coll++)
                                {
                                    var concan_col = "COL_" + coll.ToString();
                                    dr[concan_col] = " ";
                                    dr["LINE_NO"] = rrr.ToString();
                                }
                                LayoutID++;
                                dr["LAYOUT_ID"] = LayoutName + LayoutID.ToString().PadLeft(zeroLayout, '0');
                                dt_result.Rows.Add(dr);
                                dr = dt_result.NewRow();

                            }
                            no = 0;
                            state_no1 = 1;


                        }
                    }

                    if (state_no1 <= 5 && current_ID != next_ID && state_no1 != 1)
                    {
                        for (int rrr = state_no1; rrr < 6; rrr++)
                        {
                            dr["MRK_UNIQUE_ID"] = mark_id;
                            for (int coll = 4; coll < 22; coll++)
                            {
                                var concan_col = "COL_" + coll.ToString();
                                dr[concan_col] = " ";
                                dr["LINE_NO"] = rrr.ToString();
                            }
                            LayoutID++;
                            dr["LAYOUT_ID"] = LayoutName + LayoutID.ToString().PadLeft(zeroLayout, '0');
                            dt_result.Rows.Add(dr);
                            dr = dt_result.NewRow();
                            state_no1++;
                        }
                        if (state_no1 >= 5)
                        {
                            for (int rrr = 6; rrr < 11; rrr++)
                            {
                                dr["MRK_UNIQUE_ID"] = mark_id;
                                for (int coll = 4; coll < 22; coll++)
                                {
                                    var concan_col = "COL_" + coll.ToString();
                                    dr[concan_col] = " ";
                                    dr["LINE_NO"] = rrr.ToString();
                                }
                                LayoutID++;
                                dr["LAYOUT_ID"] = LayoutName + LayoutID.ToString().PadLeft(zeroLayout, '0');
                                dt_result.Rows.Add(dr);
                                dr = dt_result.NewRow();

                            }
                            no = 0;
                            state_no1 = 1;
                        }
                    }

                    if (current_row == "1")
                    {
                        state_no1 = 1;
                    }

                    int rees = Convert.ToInt32(current_row) - state_no1;


                    if (Convert.ToInt32(current_row) > state_no1 && state_no1 != 5)
                    {

                        for (int rrr = state_no1; rrr < Convert.ToInt32(current_row); rrr++)
                        {
                            dr["MRK_UNIQUE_ID"] = mark_id;
                            if (no == 0)
                            {
                                dr["MRK_UNIQUE_ID"] = dataRow["MARK_ID"].ToString();
                            }
                            for (int coll = 4; coll < 22; coll++)
                            {
                                var concan_col = "COL_" + coll.ToString();
                                dr[concan_col] = " ";
                                dr["LINE_NO"] = state_no1.ToString();
                            }
                            LayoutID++;
                            dr["LAYOUT_ID"] = LayoutName + LayoutID.ToString().PadLeft(zeroLayout, '0');
                            dt_result.Rows.Add(dr);
                            dr = dt_result.NewRow();
                            state_no1++;
                        }
                    }
                    var col = dataRow["MARK_COLUMN"].ToString();
                    mark_id = dataRow["MARK_ID"].ToString();



                    var mark_data = dataRow["MARK_DATA"].ToString();

                    dr["MRK_UNIQUE_ID"] = mark_id;
                    col_plus = int.Parse(col) + 3;
                    var concat_col = "COL_" + col_plus;
                    dr[concat_col] = mark_data;
                    dr["LINE_NO"] = current_row;

                    no++;






                    if (state_no1 == 5 && col_plus == 21)
                    {
                        LayoutID++;
                        dr["LAYOUT_ID"] = LayoutName + LayoutID.ToString().PadLeft(zeroLayout, '0');

                        dt_result.Rows.Add(dr);
                        dr = dt_result.NewRow();
                        for (int rrr = 6; rrr < 11; rrr++)
                        {
                            dr["MRK_UNIQUE_ID"] = mark_id;
                            for (int coll = 4; coll < 22; coll++)
                            {
                                var concan_col = "COL_" + coll.ToString();
                                dr[concan_col] = " ";
                                dr["LINE_NO"] = rrr.ToString();
                            }
                            LayoutID++;
                            dr["LAYOUT_ID"] = LayoutName + LayoutID.ToString().PadLeft(zeroLayout, '0');
                            dt_result.Rows.Add(dr);
                            dr = dt_result.NewRow();

                        }
                        no = 0;
                        state_no1 = 1;


                    }

                    if (col_plus == 21 && no != 0)
                    {
                        LayoutID++;
                        dr["LAYOUT_ID"] = LayoutName + LayoutID.ToString().PadLeft(zeroLayout, '0');
                        dt_result.Rows.Add(dr);
                        dr = dt_result.NewRow();
                        state_no1++;
                    }

                    next_row = dataRow["MARK_ROW"].ToString();
                    next_ID = dataRow["MARK_ID"].ToString();

                    next_col = dataRow["MARK_COLUMN"].ToString();
                }


                if (current_row != "5" && dt_result.Rows.Count % 10 == 0)
                {
                    LayoutID++;
                    dr["LAYOUT_ID"] = LayoutName + LayoutID.ToString().PadLeft(zeroLayout, '0');
                    dt_result.Rows.Add(dr);
                    dr = dt_result.NewRow();

                }
                PM.GLOBAL_DataSource = dt_result;


                int modRow = PM.GLOBAL_DataSource.Rows.Count % 10;

                if (modRow != 0)
                {

                    for (int xxx = (modRow + 1) % 10; xxx < 11; xxx++)
                    {
                        dr["MRK_UNIQUE_ID"] = mark_id;
                        for (int coll = 4; coll < 22; coll++)
                        {
                            var concan_col = "COL_" + coll.ToString();
                            dr[concan_col] = " ";
                            dr["LINE_NO"] = xxx.ToString();
                        }
                        LayoutID++;
                        dr["LAYOUT_ID"] = LayoutName + LayoutID.ToString().PadLeft(zeroLayout, '0');
                        dt_result.Rows.Add(dr);
                        dr = dt_result.NewRow();

                    }
                }
                PM.dataGridViewOutput.DataSource = dt_result;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void ribbonButtonSetFileName_Click(object sender, EventArgs e)
        {
            var myvalue = Interaction.InputBox("Please create new name.", "New Name", "Default");
            PM.fileName = myvalue;
            PM.label3.Text = myvalue;
        }

        private void ribbonButtonExports_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    string[] files = Directory.GetFiles(fbd.SelectedPath);
                    try
                    {
                        using (var workbook = new XLWorkbook())

                        {

                            var worksheet = workbook.Worksheets.Add(PM.GLOBAL_DataSource, "result_part_mark");

                            var fullpath = @fbd.SelectedPath + "\\" + PM.fileName + ".xlsx";

                            //MessageBox.Show(fullpath);
                            workbook.SaveAs(fullpath);
                            MessageBox.Show("SAVE to " + fbd.SelectedPath);

                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString());
                    }
                }
            }
        }
       
    }
}
