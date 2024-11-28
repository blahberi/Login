namespace Login.Server
{
    internal class Email
    {
        public IEnumerable<string> Recipients { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
    }
}
