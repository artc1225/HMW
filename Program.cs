using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMW
{
    class Person
    {

        protected string name, lastName;

        private static int _counter = 0;

        public static int counter
        {
            get
            {
                return _counter;
            }

            private set
            {
                _counter = value;
            }
        }

        public Person(string name, string lastName)
        {

            this.name = name;

            this.lastName = lastName;

            counter++;

        }
        public string getPersonInfo() { return name + ", " + lastName; }

    };

    class Student : Person, IComparable<Student>
    {

        private string email;
        private string location;
        private double grade;

        public Student(string name, string lastName, string location, string email, double grade)
            : base(name, lastName)
        {
            this.grade = grade;
            this.location = location;
            this.email = email;
        }

        public double Grade
        {

            get
            {
                return grade;
            }
            set
            {
                if (grade >= 0 && grade <= 100)
                {
                    this.grade = value;
                }
                else Console.WriteLine("Grade can be only between 0 and 100");
            }
        }

        public bool setName(string input)
        {





            if (!input.All(Char.IsLetter))
            {

                Console.WriteLine("Name must have only letters");

                return false;

            }
            if (input.Length < 2)
            {

                Console.WriteLine("Name must have at least two characters ");

                return false;

            }

            char[] chArray = input.ToCharArray();
            int count = 0;
            foreach (char c in chArray)
            {

                if (count == 0 && !char.IsUpper(c))
                {

                    Console.WriteLine("Name must start with an uppercase letter");
                    return false;

                }

                if (count != 0 && !char.IsLower(c))
                {
                    Console.WriteLine("All letter except first one must be lowercase!");
                    return false;
                }
                count++;
            }

            input = base.name;
            return true;
        }

        public string Email { get; set; }

        public string getStudentInfo()
        {
            return "Student " + base.name + " " + base.lastName + " from " + location + " with email " + email + " Grade: " + grade.ToString();
        }



        public string Location
        {
            get
            {
                if (location == "SA")
                {
                    location = "Sarajevo";
                }

                else if (location == "TZ")
                {
                    location = "Tuzla";
                }
                return location;

            }
            set
            {
                if (location == "SA" || location == "SARAJEVO" || location == "Sarajevo" || location == "sarajevo")
                {
                    location = "SA";
                }

                else if (location == "TZ" || location == "TUZLA" || location == "Tuzla" || location == "tuzla")
                {
                    this.location = "TZ";
                }
            }

        }

        public Student() : base(string.Empty, string.Empty) { }


        ~Student()
        {

        }
        public override string ToString()
        {
            return getStudentInfo();
        }

        public int CompareTo(Student other)
        {
            return this.location.CompareTo(other.location);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {

            double average = 0;
            double total = 0;
            List<Student> students = new List<Student>
                {
                  new Student("Denis","Telalovic","Sarajevo","denis_tel@gmail.com",27),
                  new Student("Tarik","Brcaninovic","Tuzla","tare@live.com",20),
                  new Student("Vedad","Causevis","Tuzla","vedo@hotmail.com",45),
                  new Student("Anida" , "Ibisevic", "Sarajevo ","nida@gmail.com",34),
                  new Student("Ademir ", "Taletovic","Tuzla", "artc1225@aubih.edu.ba",32),

                };
            students.ForEach(student => total = total + student.Grade);
            average = total / 5;
            students.Sort();
            students.ForEach(Student => Console.WriteLine(Student.getStudentInfo() + "\n"));
            Console.WriteLine("");
            Console.WriteLine(average.ToString());
            Console.ReadLine();
        }
    }
}
