namespace DiunsaSCM.Core.Models
{
    public class UserSettingDTO : AuditableModel
    {
        public long Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
    }
}