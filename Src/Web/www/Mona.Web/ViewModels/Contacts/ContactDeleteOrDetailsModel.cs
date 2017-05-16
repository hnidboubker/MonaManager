using Mona.Web.Entities;

namespace Mona.Web.ViewModels.Contacts
{
    public class ContactDeleteOrDetailsModel
    {
        public long Id { get; set; }
        public int Code { get; set; }
        public string Picture { get; set; }
        public ContactType ContactType { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }


        public string PhoneNumber { get; set; }
        public string Email { get; set; }

        public string TwiterAddress { get; set; }
        public string FaceBookAddress { get; set; }
    }
}