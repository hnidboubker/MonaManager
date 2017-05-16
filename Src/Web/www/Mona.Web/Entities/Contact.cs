using System;

namespace Mona.Web.Entities
{
    public class Contact
    {
        public long Id { get; set; }
        public int Code { get; set; }
        public string Picture { get; set; }
        public ContactType ContactType { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string FullName
        {
            get { return String.Format("{0}{1}{2}", LastName, " ", FirstName); }
        }

        public string PhoneNumber { get; set; }
        public string Email { get; set; }

        public string TwiterAddress { get; set; }
        public string FaceBookAddress { get; set; }
    }
}