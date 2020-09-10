using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZusApiCon.Classes
{

    // UWAGA: Wygenerowany kod może wymagać co najmniej programu .NET Framework 4.5 lub .NET Core/Standard 2.0.
    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class Oswiadczenie
    {

        private string trescField;

        private System.DateTime dataField;

        private System.DateTime czasField;

        private string tokenField;

        /// <remarks/>
        public string Tresc
        {
            get
            {
                return this.trescField;
            }
            set
            {
                this.trescField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date")]
        public System.DateTime Data
        {
            get
            {
                return this.dataField;
            }
            set
            {
                this.dataField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "time")]
        public System.DateTime Czas
        {
            get
            {
                return this.czasField;
            }
            set
            {
                this.czasField = value;
            }
        }

        /// <remarks/>
        public string Token
        {
            get
            {
                return this.tokenField;
            }
            set
            {
                this.tokenField = value;
            }
        }
    }


}
