namespace Api.Entities
{
    public class User:BaseEntity
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }
        public int RoleId { get; set; }
        public int CustomerId { get; set; }

    }
}