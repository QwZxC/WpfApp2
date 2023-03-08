namespace ClassLibrary1
{
    public class Special
    {
        public int Id { get; set; }
        public string Code { get;  set; }
        public string Name { get; set; }

        public Special(string code, string name) 
        {
            Code = code;
            Name = name;
        }
    }
}