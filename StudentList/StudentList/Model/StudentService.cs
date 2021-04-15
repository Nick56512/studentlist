using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentList.Model
{
    class StudentService
    {
        private string OpenFile()
        {
            OpenFileDialog openFile = new OpenFileDialog();
            if(openFile.ShowDialog()!=false)
            {
                return openFile.FileName;
            }
            return null;
        }
        public IEnumerable<Student> GetAll()
        {
            List<Student> students = new List<Student>();
            string text = File.ReadAllText(OpenFile());
            string[] arr = text.Split(new char[] {'\n'},StringSplitOptions.RemoveEmptyEntries);
            foreach (var item in arr)
            {
                try
                {
                    string[] st = text.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    Student student = new Student();
                    student.Name = st[0];
                    student.Lastname = st[1];
                    student.Age = Convert.ToInt32(st[2]);
                    students.Add(student);
                }
                catch{ }
            }
            return students;
        }
        
    }
}
