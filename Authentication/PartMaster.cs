using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Data.OleDb;
using ExcelDataReader;
using Microsoft.VisualBasic;
using System.Xml;
using ClosedXML.Excel;


namespace Authentication
{
    public partial class PartMaster : Form
    {
        public PartMaster()
        {
            InitializeComponent();
        }

        public DataSet ds = new DataSet();

        public DataTable GLOBAL_DataSource = new DataTable();

        Application_Profile AP = new Application_Profile();


        public DataTable GetDatatable()
        {
            DataTable dt_result = new DataTable();
            try
            {
                dt_result.Columns.Add("LAYOUT_ID");
                dt_result.Columns.Add("MRK_UNIQUE_ID");
                dt_result.Columns.Add("LINE_NO");
                dt_result.Columns.Add("COL_1");
                dt_result.Columns.Add("COL_2");
                dt_result.Columns.Add("COL_3");
                dt_result.Columns.Add("COL_4");
                dt_result.Columns.Add("COL_5");
                dt_result.Columns.Add("COL_6");
                dt_result.Columns.Add("COL_7");
                dt_result.Columns.Add("COL_8");
                dt_result.Columns.Add("COL_9");
                dt_result.Columns.Add("COL_10");
                dt_result.Columns.Add("COL_11");
                dt_result.Columns.Add("COL_12");
                dt_result.Columns.Add("COL_13");
                dt_result.Columns.Add("COL_14");
                dt_result.Columns.Add("COL_15");
                dt_result.Columns.Add("COL_16");
                dt_result.Columns.Add("COL_17");
                dt_result.Columns.Add("COL_18");
                dt_result.Columns.Add("COL_19");
                dt_result.Columns.Add("COL_20");
                dt_result.Columns.Add("COL_21");
            }
            catch (Exception)
            {

                throw;
            }
            return dt_result;
        }

        

       
        public string IDname = ""; 
       
        public string fileName = "Default";
        

        

        

       
        //public interface IView
        //{
        //    bool CanClose();
        //}
        //private bool CanCurrentViewClose()
        //{
        //    if (panel1.Controls.Count == 0)
        //        return true;

        //    IView v = panel1.Controls[0] as IView;
        //    return v.CanClose();

        //}
        //private void SwitchView(IView newView)
        //{
        //    if (groupBox1.Controls.Count > 0)
        //    {
        //        UserControl oldView = groupBox1.Controls[0] as UserControl;
        //        groupBox1.Controls.Remove(oldView);
        //        oldView.Dispose();
        //    }
        //    groupBox1.Controls.Add(newView);
        //    newView.Dock = Dock.Fill;
        //}

    }
}
