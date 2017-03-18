using LINQTask2;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQTask3
{
    public static class StudentData
    {
        private const int MIN_STUDENT_NUMBER = 10;
        private const int MAX_STUDENT_NUMBER = 20;

        public static IList<Student> GenerateStudents(Random random)
        {
            int maleStudentNumber = random.Next(MIN_STUDENT_NUMBER / 2, MAX_STUDENT_NUMBER / 2);
            int femaleStudentNumber = random.Next(MIN_STUDENT_NUMBER / 2, MAX_STUDENT_NUMBER / 2);

            var students = new HashSet<Student>();

            for (int i=0; i < maleStudentNumber; i++)
            {
                string name = _maleNames[random.Next(_maleNames.Count)] + " " +_surnames[random.Next(_surnames.Count)];
                Student student = new Student(name, name.GetHashCode().ToString());
                student.Gender = Gender.Male;
                students.Add(student);
                
            }
            for (int i = 0; i < femaleStudentNumber; i++)
            {
                string name = _femaleNames[random.Next(_femaleNames.Count)] + " " + _surnames[random.Next(_surnames.Count)];
                Student student = new Student(name, name.GetHashCode().ToString());
                student.Gender = Gender.Female;
                students.Add(student);
            }
            
            return students.ToList();
        }

        private static IList<string> _surnames = new List<string>()
        {
            "Horvat",
            "Kovačević",
            "Babić",
            "Marić",
            "Novak",
            "Jurić",
            "Kovačić",
            "Vuković",
            "Knežević",
            "Marković",
            "Matić",
            "Petrović",
            "Trpimirović"
        };

        private static IList<string> _maleNames = new List<string>()
        {
            "Ivan",
            "Josip",
            "Luka",
            "Stjepan",
            "Marko",
            "Tomislav",
            "Filip",
            "Karlo",
            "Petar",
            "Vojnomir",
            "Ljudevit",
            "Ratislav",
            "Višeslav",
            "Borna",
            "Vladislav",
            "Mislav",
            "Trpimir",
            "Zdeslav",
            "Iljko",
            "Domagoj",
            "Branimir",
            "Krešimir",
            "Miroslav",
            "Zvonimir",
            "Suronja"
        };

        private static IList<string> _femaleNames = new List<string>()
        {
            "Marija",
            "Ana",
            "Ivana",
            "Mirjana",
            "Katarina",
            "Nada",
            "Dragica",
            "Ljubica",
            "Vesna",
            "Marina",
            "Lucija",
            "Dora",
            "Lana",
            "Sara",
            "Petra",
            "Iva",
            "Ena",
            "Mia",
            "Danica",
            "Lada",
            "Morana",
            "Rusalka"
        };
    }
}
