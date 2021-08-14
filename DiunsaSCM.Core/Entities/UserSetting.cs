namespace DiunsaSCM.Core.Entities
{
    public class UserSetting : AuditableEntity
    {
        public long Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
    }
}