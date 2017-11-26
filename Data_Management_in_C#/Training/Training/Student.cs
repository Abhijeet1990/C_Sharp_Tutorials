using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training
{
    class Student
    {
        public int id;
        public double grade;

        public Student(int id,double grade)
        {
            this.id = id;
            this.grade = grade;
        } 

        public void Display()
        {
            Console.WriteLine("ID = " + id);
            Console.WriteLine("grade = " + grade);
        }
        public static Student operator + (Student s1,Student s2)
        {
            Student newStudent = new Student(s1.id + s2.id, s1.grade + s2.grade);
            return newStudent;
        }
        public static Student operator +(Student s1, int i)
        {
            Student newStudent = new Student(s1.id + i, s1.grade + i);
            return newStudent;
        }
        public static bool operator < (Student s1,Student s2)
        {
            if(s1.grade<s2.grade)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool operator >(Student s1, Student s2)
        {
            if (s1.grade > s2.grade)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static implicit operator int(Student s1 )
        {
            return s1.id;
        }
    }
}



