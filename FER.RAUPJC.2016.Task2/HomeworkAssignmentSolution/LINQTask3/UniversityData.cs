using LINQTask2;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQTask3
{
    public static class UniversityData
    {
        private const int NUMBER_OF_UNIVIRSITIES = 10;
        private const int MAX_STUDENTS_PER_UNIVERSITY = 3;

        public static University[] GetAllCroatianUniversities()
        {
            Random random = new Random();
            var faculties = PickFaculties(random);
            var students = StudentData.GenerateStudents(random);

            var universities = new List<University>();

            foreach (string faculty in faculties)
            {
                universities.Add(new University
                {
                    Name = faculty,
                    Students = GetRandomStudents(random, students)
                });
            }

            return universities.ToArray();
        }
        
        private static Student[] GetRandomStudents(Random random, IList<Student> students)
        {
            var randomStudents = new HashSet<Student>();
            for (int i=0; i<MAX_STUDENTS_PER_UNIVERSITY; i++)
            {
                randomStudents.Add(students[random.Next(students.Count)]);
            }
            return randomStudents.ToArray();
        }

        private static IEnumerable<string> PickFaculties(Random random)
        {
            var faculties = new HashSet<string>();

            for (int i=0; i<NUMBER_OF_UNIVIRSITIES; i++)
            {
                if ( !faculties.Add(_croatianFaculties[random.Next(_croatianFaculties.Count)]) )
                {
                    i--;
                }
            }

            return faculties;
        }

        private static IList<string> _croatianFaculties = new List<string>()
        {
            "Agronomski fakultet u Zagrebu",
            "Akademija dramske umjetnosti u Zagrebu",
            "Akademija likovnih umjetnosti u Zagrebu",
            "Arhitektonski fakultet u Zagrebu",
            "Edukacijsko-rehabilitacijski fakultet u Zagrebu",
            "Ekonomski fakultet u Osijeku",
            "Ekonomski fakultet u Splitu",
            "Ekonomski fakultet u Zagrebu",
            "Fakultet elektrotehnike i računarstva",
            "Fakultet elektrotehnike, računarstva i informacijskih tehnologija u Osijeku",
            "Fakultet elektrotehnike, strojarstva i brodogradnje u Splitu",
            "Fakultet kemijskog inženjerstva i tehnologije u Zagrebu",
            "Fakultet organizacije i informatike u Varaždinu",
            "Fakultet političkih znanosti u Zagrebu",
            "Fakultet prometnih znanosti u Zagrebu",
            "Fakultet strojarstva i brodogradnje",
            "Fakultet za odgojne i obrazovne znanosti u Osijeku",
            "Farmaceutsko-biokemijski fakultet u Zagrebu",
            "Filozofski fakultet u Osijeku",
            "Filozofski fakultet u Splitu",
            "Filozofski fakultet u Zadru",
            "Filozofski fakultet u Zagrebu",
            "Geodetski fakultet u Zagrebu",
            "Geotehnički fakultet u Varaždinu",
            "Građevinski fakultet u Osijeku",
            "Građevinski fakultet u Zagrebu",
            "Grafički fakultet u Zagrebu",
            "Hrvatski studiji",
            "Katolički bogoslovni fakultet u Đakovu",
            "Katolički bogoslovni fakultet u Zagrebu",
            "Kineziološki fakultet u Zagrebu",
            "Medicinski fakultet u Osijeku",
            "Medicinski fakultet u Rijeci",
            "Medicinski fakultet u Splitu",
            "Medicinski fakultet u Zagrebu",
            "Metalurški fakultet u Sisku",
            "Odjel za biologiju Sveučilišta Josipa Jurja Strossmayera u Osijeku",
            "Odjel za fiziku Sveučilišta Josipa Jurja Strossmayera u Osijeku",
            "Odjel za informatiku Sveučilišta u Rijeci",
            "Poljoprivredni fakultet u Osijeku",
            "Pomorski fakultet u Splitu",
            "Dodatak:Popis zagrebačkih fakulteta",
            "Pravni fakultet u Osijeku",
            "Pravni fakultet u Splitu",
            "Pravni fakultet u Zagrebu",
            "Prehrambeno-biotehnološki fakultet u Zagrebu",
            "Prehrambeno-tehnološki fakultet u Osijeku",
            "Prirodoslovno-matematički fakultet u Splitu",
            "Prirodoslovno-matematički fakultet u Zagrebu",
            "Stomatološki fakultet u Zagrebu",
            "Strojarski fakultet u Slavonskom Brodu",
            "Studij dizajna",
            "Škola narodnog zdravlja 'Andrija Štampar'",
            "Šumarski fakultet u Zagrebu",
            "Translacijska istraživanja u biomedicini",
            "Učiteljski fakultet u Zagrebu",
            "Veterinarski fakultet u Zagrebu",
            "Vojnotehnički fakultet"
        };
    }
}
