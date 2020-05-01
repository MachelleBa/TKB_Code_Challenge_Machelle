using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace Machelle_Bakker_Code_Challenge_TKB_April_2020.Model
{
    class XMLProcessing //this should be a singleton
    {

        public List<ListDictionary> readXMLFile(String fileName)
        {
            XmlDocument docum = new XmlDocument();
            List<ListDictionary> debtors = new List<ListDictionary>();

            docum.Load(fileName); //should have a try catch to prevent file not found errors


            foreach (XmlNode node in docum.DocumentElement)
            {
                ListDictionary debtor = new ListDictionary();

                foreach (XmlNode childNode in node.ChildNodes)
                {
                    string nodeName = childNode.Name;
                    string nodeContent = childNode.InnerText;

                    debtor.Add(nodeName, nodeContent);

                }

                debtors.Add(debtor);
            }

            return debtors;
        }

        public List<Debtor> readXMLFileObjects(String fileName) 
        {
            XmlDocument docum = new XmlDocument();
            List<Debtor> debtors = new List<Debtor>();

            docum.Load( fileName);


            foreach (XmlNode node in docum.DocumentElement)
            {
                Debtor debtor;
                string number = ""; //number and name will be filled regardless as they are NOT NULL restricted in the database
                string name = "";
                string telephone = null;
                string mobile = null;
                string email = null;
                bool isClosed = false; //Default = 0


                foreach (XmlNode childNode in node.ChildNodes)
                {

                    string nodeName = childNode.Name;
                    string nodeContent = childNode.InnerText;

                    switch (nodeName)
                    {
                        case "Number":
                            number = nodeContent;
                            break;

                        case "Name":
                            name = nodeContent;
                            break;

                        case "Telephone":
                            telephone = nodeContent;
                            break;

                        case "Mobile":
                            mobile = nodeContent;
                            break;

                        case "Email":
                            email = nodeContent;
                            break;

                        case "isClosed":
                            isClosed = bool.Parse(nodeContent);
                            break;



                    }
                    debtor = new Debtor(number, name, telephone, mobile, email, isClosed);
                    debtors.Add(debtor);
                }

                
            }
            return debtors;
        }
    }
}
