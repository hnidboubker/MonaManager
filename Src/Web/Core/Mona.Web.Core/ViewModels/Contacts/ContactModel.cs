using Mona.Server.Domain.Entities;

namespace Mona.Web.Core.ViewModels.Contacts
{
    public class ContactModel
    {
        public long Id { get; set; }
        public int Code { get; set; }
        public string Picture { get; set; }
        public ContactType ContactType { get; set; }
        public string FullName { get; set; }

        public string PhoneNumber { get; set; }
        public string Email { get; set; }
    }
}