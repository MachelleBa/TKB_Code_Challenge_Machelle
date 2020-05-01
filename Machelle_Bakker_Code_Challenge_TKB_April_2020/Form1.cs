using Machelle_Bakker_Code_Challenge_TKB_April_2020.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Windows.Forms;

namespace Machelle_Bakker_Code_Challenge_TKB_April_2020
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        OpenFileDialog ofd = new OpenFileDialog();
        DatabaseAccess db = new DatabaseAccess();

        private void button1_Click(object sender, EventArgs e) //Select File button
        {            

            ofd.InitialDirectory = AppDomain.CurrentDomain.BaseDirectory + "/xml";
            ofd.Filter = "XML|*.xml";
 

            if (ofd.ShowDialog() == DialogResult.OK ) {

                lbl_selected_file_name.Text = String.Empty;
                lbl_selected_file_name.Text = ofd.SafeFileName;

                printCurrentXMLFileContent(ofd.FileName);
              
            }
                                              
        }

        public void printCurrentXMLFileContent(string fileName)
        {
            XMLProcessing xml = new XMLProcessing();
            List<ListDictionary> debtors = xml.readXMLFile(fileName);
            lv_debtors.Items.Clear();

            foreach (var item in debtors)
            {
                foreach (DictionaryEntry de in item)
                {
                    lv_debtors.Items.Add(de.Key + " " + de.Value);
                }
            }

        }
        private void printCurrentDatabaseContent()
        {
            DatabaseAccess db = new DatabaseAccess();
            List<Debtor> debtors = db.pullAllDebtorsFromDatabaseObjects();

            foreach (Debtor debtor in debtors)
            {
                lv_debtors.Items.Add(debtor.getNumber());
                lv_debtors.Items.Add(debtor.getName());
                lv_debtors.Items.Add(debtor.getTelephone());
                lv_debtors.Items.Add(debtor.getMobile());
                lv_debtors.Items.Add(debtor.getEmail());
                lv_debtors.Items.Add(debtor.getIsClosed().ToString());

            }

        }

        private void button2_Click(object sender, EventArgs e) //Update content to selected XML File
        {
           //this one breaks...
           // db.updateXMLtoDatabase(ofd.FileName);
        }
    }
}
