namespace LINQTask2
{
    public class Student
    {
        public string Name { get; set; }

        public string Jmbag { get; set; }

        public Gender Gender { get; set; }

        public Student(string name, string jmbag)
        {
            Name = name;
            Jmbag = jmbag;
        }

        public override bool Equals(object obj)
        {
            var stud = obj as Student;
            if (stud == null)
            {
                return false;
            }
            return Jmbag.Equals(stud.Jmbag);
        }

        public override int GetHashCode()
        {
            return Jmbag.GetHashCode();
        }

        public override string ToString()
        {
            return Jmbag + " : " + Name + " (" + Gender + ")";
        }
    }

    public enum Gender
    {
        Male,
        Female
    }
}
