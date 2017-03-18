using LINQTask2;
using System.Text;

namespace LINQTask3
{
    public class University
    {
        public string Name { get; set; }

        public Student[] Students { get; set; }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(Name + " : ");
            foreach (Student stud in Students)
            {
                builder.Append(stud.Name + ", ");
            }
            return builder.ToString();
        }
    }
}
