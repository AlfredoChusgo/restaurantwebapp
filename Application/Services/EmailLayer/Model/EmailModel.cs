using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.EmailLayer.Model
{
    public class EmailModel
    {
        public string ToEmailAddress { get; set; }
        public string EmailSubject { get; set; }
        public string EmailTitle { get; set; }
        public string CompanyName { get; set; }
        public string CompanyAddress { get; set; }
        public string BodyDescription { get; set; }
        public string FooterDescription { get; set; }
        public string CompanyPhoneNumber { get; set; }
        public bool ShowButton { get; set; }
        public string ButtonText { get; set; }
        public string ButtonUrl { get; set; }

        //public string EmailTitle = "Restaurant Wep App"{ get; set; }
        //public string CompanyName = "Restaurant Germany"{ get; set; }
        //public string CompanyAddress = "av. siempre viva #594"{ get; set; }
        //public string BodyDescription = "Body Description"{ get; set; }
        //public string FooterDescription = "Footer Description"{ get; set; }
        //public string CompanyPhoneNumber = "75517478"{ get; set; }
        //public string ButtonText = "ButtonText"{ get; set; }
        //public string ButtonURL = "https://google.com/"{ get; set; }
    }
}
