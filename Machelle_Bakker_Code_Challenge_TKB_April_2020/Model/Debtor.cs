using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Machelle_Bakker_Code_Challenge_TKB_April_2020.Model
{
    class Debtor
    {

        private string number; //this is a string (varchar) in the database, hence the string typing here
        private string name;
        private string telephone;
        private string mobile;
        private string email;
        private bool isClosed;

        public Debtor() { } //empty constructor to allow existing objects with no determined attributes

        public Debtor(string number, string name)
        {
            this.number = number;
            this.name = name;
            this.telephone = null;
            this.mobile = null;
            this.email = null;
            this.isClosed = false;
        }
        public Debtor(string number, string name, string telephone, string mobile, string email, bool isClosed)
        {
            this.number = number;
            this.name = name;
            this.telephone = telephone;
            this.mobile = mobile;
            this.email = mobile;
            this.isClosed = isClosed;
        }

        public string getNumber()
        {
            return this.number;
        }

        public string getName()
        {

            return this.name;
        }

        public string getTelephone()
        {
            return this.telephone;
        }
        
        public string getMobile()
        {
            return this.mobile;
        }

        public string getEmail()
        {
            return this.email;
        }

        public bool getIsClosed()
        {
            return this.isClosed;
        }
    }
}
