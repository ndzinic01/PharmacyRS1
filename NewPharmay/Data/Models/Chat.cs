using NewPharmacy.Data.Models.Auth;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewPharmacy.Data.Models
{
    public class Chat
    {
        public int Id { get; set; }


        [ForeignKey(nameof(MyAppUser))]
        public int MyAppUserId { get; set; }
        public MyAppUser? MyAppUser { get; set; }


        public string Message { get; set; }
        public DateTime Date { get; set; }
        public string TypeOfMessage { get; set; }//pitanje,odgovor
        public string Status { get; set; }
    }
}
