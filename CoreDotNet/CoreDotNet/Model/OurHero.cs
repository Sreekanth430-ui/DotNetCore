namespace CoreDotNet.Model
{
    public class OurHero
    {
        public int Id { get; set; }
        public required string FirstName { get; set; }
        public string LastName { get; set; } = string.Empty;
        public bool isActive { get; set; } = true;
    }
    //public class OurHero
    //{
    //    public required string FirstName { get; set; }
    //    public string LastName { get; set; } = string.Empty;
    //    public bool isActive { get; set; } = true;
    //}

}
