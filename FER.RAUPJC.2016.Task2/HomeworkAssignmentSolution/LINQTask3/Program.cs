using LINQTask2;
using System;
using System.Linq;

namespace LINQTask3
{
    class Program
    {
        static void Main(string[] args)
        {
            University[] universities = UniversityData.GetAllCroatianUniversities();

            Student[] allCroatianStudents = universities.SelectMany(uni => uni.Students)
                                                        .Distinct()
                                                        .ToArray();

            Student[] croatianStudentsOnMultipleUniversities = universities.SelectMany(uni => uni.Students)
                                                                           .GroupBy(stud => stud)
                                                                           .Select(group => new { group.Key, Enrolled = group.Count() })
                                                                           .Where(s => s.Enrolled > 1)
                                                                           .Select(s => s.Key)
                                                                           .ToArray();

            Student[] studentsOnMaleOnlyUniversities = universities.Except(universities.Where(uni => uni.Students.Any(stud => stud.Gender.Equals(Gender.Female))))
                                                                   .SelectMany(uni => uni.Students)
                                                                   .Distinct()
                                                                   .ToArray();

            WriteArray(universities);
            WriteArray(allCroatianStudents);
            WriteArray(croatianStudentsOnMultipleUniversities);
            WriteArray(studentsOnMaleOnlyUniversities);
            Console.ReadKey();
        }

        static void WriteArray<T> (T[] array)
        {
            array.ToList().ForEach(t => Console.WriteLine(t));
            Console.WriteLine();
        }
    }
}
