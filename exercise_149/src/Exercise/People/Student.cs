namespace Exercise
{
    public class Student : Person
    {
        private int credits;

        public Student(string name, string address) : base(name, address) {
            credits = 0;
        }

        public void Study() {
            credits++;
        }

        public override string ToString()
        {
            return $"{base.ToString()} credits: {credits}";
        }
    }
}