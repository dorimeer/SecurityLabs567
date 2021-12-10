namespace SecuritySobolDori.Labs567.BLL.DTO
{
    public class AccountDTO
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        
        public override bool Equals(object? obj)
        {
            if (obj is null) return false;
            return GetHashCode() == obj.GetHashCode();
        }

        public override int GetHashCode() => (Id, Name, Surname, PhoneNumber, Email, Password).GetHashCode();
    }
}