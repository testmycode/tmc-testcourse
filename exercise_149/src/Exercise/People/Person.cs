namespace Exercise
{
    public class Person
    {
        protected string name;
        protected string address;

        public Person(string name, string address) {
            this.name = name;
            this.address = address;
        }

        public override string ToString()
        {
            return $"{name}, {address}";
        }
    }
}