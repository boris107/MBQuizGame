namespace Data.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public UserPrivelege Privilege { get; set; }
        public enum UserPrivelege
        {
            Admin,
            User,
            Guest
        }
    }
}