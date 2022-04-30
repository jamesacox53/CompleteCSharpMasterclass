using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace Section_15_Part_2___Linq_to_SQL
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        LinqToSqlDataClassesDataContext dataContext;
        
        public MainWindow()
        {
            InitializeComponent();

            try
            {
                ConnectToDatabase();
                // InsertUniversities();
                // InsertStudents();
                // InsertLectures();
                // InsertStudentsAndLectures();
                // getUniversityOfToni();
                // getAllLecturesOfToni();
                // getAllStudentsOfMaths();
                // getAllStudentsFromYale();
                // getAllStudentsFromBeijingTech();
                // getAllUniversitiesWithTransgenderStudents();
                // getAllLecturesTaughtAtYale();
                // getAllLecturesTaughtAtBeijingTech();
                // updateLinda();
                // deleteLeyla();
            }
            catch (Exception)
            {
                return;
            }
        }

        private void ConnectToDatabase()
        {
            string passwordComponent = ";Password=InsertPasswordHere";

            string connectComponent = "Data Source=LAPTOP-LG6PN2GE\\JAMESMSSQLSERVER;Initial Catalog=CSharpMasterclassDB;User ID=sa";

            string connectionString = connectComponent + passwordComponent;

            dataContext = new LinqToSqlDataClassesDataContext(connectionString);
        }

        public void InsertUniversities() 
        {
            // dataContext.ExecuteCommand("delete from University");
            
            InsertBeijingTechUniversity();

            MainDataGrid.ItemsSource = dataContext.Universities;
        }

        private void InsertYaleUniversity() 
        {
            University yale = new University();

            yale.Name = "Yale";

            dataContext.Universities.InsertOnSubmit(yale);
            dataContext.SubmitChanges();
        }

        private void InsertBeijingTechUniversity()
        {
            University beijingTech = new University();

            beijingTech.Name = "Beijing Tech";

            dataContext.Universities.InsertOnSubmit(beijingTech);
            dataContext.SubmitChanges();
        }

        public void InsertStudents()
        {
            University yale = dataContext.Universities.First(uni => uni.Name.Equals("Yale"));
            University beijingTech = dataContext.Universities.First(uni => uni.Name.Equals("Beijing Tech"));

            List<Student> students = new List<Student>();

            students.Add(new Student { Id = 1, Name = "Carla", Gender = "Female", UniversityId = yale.Id });
            students.Add(new Student { Id = 2, Name = "Toni", Gender = "Male", UniversityId = yale.Id });
            students.Add(new Student { Id = 3, Name = "Leyla", Gender = "Female", UniversityId = beijingTech.Id });
            students.Add(new Student { Id = 4, Name = "James", Gender = "Trans-Gender", UniversityId = beijingTech.Id });
            students.Add(new Student { Id = 5, Name = "Linda", Gender = "Female", UniversityId = beijingTech.Id });

            dataContext.Students.InsertAllOnSubmit(students);
            
            dataContext.SubmitChanges();

            MainDataGrid.ItemsSource = dataContext.Students;
        }

        public void InsertLectures() 
        {
            dataContext.Lectures.InsertOnSubmit(new Lecture { Name = "Maths" });
            dataContext.Lectures.InsertOnSubmit(new Lecture { Name = "Computer Science" });
            dataContext.Lectures.InsertOnSubmit(new Lecture { Name = "History" });
            dataContext.Lectures.InsertOnSubmit(new Lecture { Name = "English" });
            dataContext.Lectures.InsertOnSubmit(new Lecture { Name = "Physics" });

            dataContext.SubmitChanges();

            MainDataGrid.ItemsSource = dataContext.Lectures;
        }

        public void InsertStudentsAndLectures()
        {
            Student carla = dataContext.Students.First(student => student.Name.Equals("Carla"));
            Student toni = dataContext.Students.First(student => student.Name.Equals("Toni"));
            Student leyla = dataContext.Students.First(student => student.Name.Equals("Leyla"));
            Student james = dataContext.Students.First(student => student.Name.Equals("James"));
            Student linda = dataContext.Students.First(student => student.Name.Equals("Linda"));

            Lecture maths = dataContext.Lectures.First(lecture => lecture.Name.Equals("Maths"));
            Lecture computerScience = dataContext.Lectures.First(lecture => lecture.Name.Equals("Computer Science"));
            Lecture history = dataContext.Lectures.First(lecture => lecture.Name.Equals("History"));
            Lecture english = dataContext.Lectures.First(lecture => lecture.Name.Equals("English"));
            Lecture physics = dataContext.Lectures.First(lecture => lecture.Name.Equals("Physics"));

            dataContext.StudentLectures.InsertOnSubmit(new StudentLecture { StudentId = carla.Id, LectureId = maths.Id });
            dataContext.StudentLectures.InsertOnSubmit(new StudentLecture { StudentId = toni.Id, LectureId = maths.Id });
            dataContext.StudentLectures.InsertOnSubmit(new StudentLecture { StudentId = toni.Id, LectureId = computerScience.Id });
            dataContext.StudentLectures.InsertOnSubmit(new StudentLecture { StudentId = toni.Id, LectureId = history.Id });
            dataContext.StudentLectures.InsertOnSubmit(new StudentLecture { StudentId = leyla.Id, LectureId = english.Id });
            dataContext.StudentLectures.InsertOnSubmit(new StudentLecture { StudentId = james.Id, LectureId = physics.Id });
            dataContext.StudentLectures.InsertOnSubmit(new StudentLecture { StudentId = linda.Id, LectureId = history.Id });
            dataContext.StudentLectures.InsertOnSubmit(new StudentLecture { StudentId = linda.Id, LectureId = english.Id });
            dataContext.StudentLectures.InsertOnSubmit(new StudentLecture { StudentId = linda.Id, LectureId = physics.Id });

            dataContext.SubmitChanges();

            MainDataGrid.ItemsSource = dataContext.StudentLectures;
        }

        public void getUniversityOfToni()
        {
            getUniversityOfStudent("Toni");
        }

        public void getUniversityOfStudent(String student)
        {
            Student studentElement = dataContext.Students.First(stu => stu.Name.Equals(student));

            University university = studentElement.University;

            List<University> universities = new List<University>();

            universities.Add(university);

            MainDataGrid.ItemsSource = universities;
        }

        public void getAllLecturesOfToni() 
        {
            getAllLecturesOfStudent("Toni");
        }

        public void getAllLecturesOfStudent(String student) 
        {
            Student studentElement = dataContext.Students.First(stu => stu.Name.Equals(student));

            var lectures = from studentLec in studentElement.StudentLectures select studentLec.Lecture;

            MainDataGrid.ItemsSource = lectures;
        }

        public void getAllStudentsOfMaths()
        {
            getAllStudentsOfLecture("Maths");
        }

        public void getAllStudentsOfLecture(String lecture)
        {
            Lecture lectureElement = dataContext.Lectures.First(lec => lec.Name.Equals(lecture));

            var students = from studentLec in lectureElement.StudentLectures select studentLec.Student;

            MainDataGrid.ItemsSource = students;
        }

        public void getAllStudentsFromYale()
        {
            getAllStudentsFromUniversity("Yale");
        }

        public void getAllStudentsFromBeijingTech()
        {
            getAllStudentsFromUniversity("Beijing Tech");
        }

        public void getAllStudentsFromUniversity(String university)
        {
            University universityElement = dataContext.Universities.First(uni => uni.Name.Equals(university));

            var studentsFromUniversity = from student in universityElement.Students select student;

            MainDataGrid.ItemsSource = studentsFromUniversity;
        }

        public void getAllUniversitiesWithTransgenderStudents() 
        {
            var universities = from student in dataContext.Students where student.Gender.Equals("Trans-Gender") select student.University;

            MainDataGrid.ItemsSource = universities;
        }

        public void getAllLecturesTaughtAtYale()
        {
            getAllLecturesTaughtAtUniversity("Yale");
        }

        public void getAllLecturesTaughtAtBeijingTech()
        {
            getAllLecturesTaughtAtUniversity("Beijing Tech");
        }

        public void getAllLecturesTaughtAtUniversity(String university)
        {
            University universityElement = dataContext.Universities.First(uni => uni.Name.Equals(university));

            var lecturesAtUniversity = from student in universityElement.Students
                                       join studentLecture in dataContext.StudentLectures
                                       on student.Id equals studentLecture.StudentId
                                       select studentLecture.Lecture;

            lecturesAtUniversity = lecturesAtUniversity.Distinct();

            MainDataGrid.ItemsSource = lecturesAtUniversity;
        }

        public void updateLinda()
        {
            Student linda = dataContext.Students.FirstOrDefault(stu => stu.Name.Equals("Linda"));

            if (linda == null)
            {
                return;
            }
            else
            {
                linda.Name = "Londa";
            }

            dataContext.SubmitChanges();

            MainDataGrid.ItemsSource = dataContext.Students;
        }

        public void deleteLeyla() 
        {
            Student leyla = dataContext.Students.FirstOrDefault(stu => stu.Name.Equals("Leyla"));

            if (leyla == null)
            {
                return;
            }
            else
            {
                dataContext.Students.DeleteOnSubmit(leyla);
            }

            dataContext.SubmitChanges();

            MainDataGrid.ItemsSource = dataContext.Students;
        }
    }
}
