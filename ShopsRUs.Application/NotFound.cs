namespace ShopsRUs.Application
{
    public class NotFound
    {
        public string Description { get; set; }
        public NotFound(string description)
        {
            Description = description;
        }
    }

    public class Error
    {
        public string Description { get; set; }
        public Error(string description)
        {
            Description = description;
        }
    }
}
