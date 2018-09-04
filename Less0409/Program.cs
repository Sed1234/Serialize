using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Runtime.Serialization.Formatters.Soap;
using System.Xml.Serialization;
using System.Net;

namespace Less0409
{
    [Serializable]
    public class Person
    {

        public Person(string name, int year)
        {
            Name = name;
            Year = year;
        }

        public string Name { get; set; }
        public int Year { get; set; }
        public Person()
        { }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Person person = new Person("Yen", 20);
            Person person1 = new Person("Van", 15);
            //exmpl1(person);
            // exmpl2(person);
            exmpl3(person1);
            int CountUser = 5;
            GetUsers(CountUser);
        }
        static void exmpl1(Person person)
        {

            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fs = new FileStream("person.dat", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, person);
            }

            using (FileStream fs = new FileStream("person.dat", FileMode.Open))
            {
                Person obj = formatter.Deserialize(fs) as Person;
            }
        }

        static void exmpl2(Person person)
        {
            SoapFormatter formatter = new SoapFormatter();
            using (FileStream fs = new FileStream("person1.dat", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, person);
            }

            using (FileStream fs = new FileStream("person1.dat", FileMode.Open))
            {
                Person obj = formatter.Deserialize(fs) as Person;
            }
        }

        static void exmpl3(Person person)
        {
            XmlSerializer formatter = new XmlSerializer(typeof(Person));
            using (FileStream fs = new FileStream("person2.xml", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, person);
            }

            using (FileStream fs = new FileStream("person2.xml", FileMode.Open))
            {
                Person obj = formatter.Deserialize(fs) as Person;
            }
        }

        static void GetUsers(int countUser)
        {
            string url = "https://randomuser.me/api/?results=" + countUser;
        
            using (WebClient client = new WebClient())
            {
                string json = client.DownloadString(url);
                var data = Newtonsoft.Json.JsonConvert.DeserializeObject<user>(json);
            }
        }

    }
    public class user
    {
      public  List<results> results = new List<results>();
    }
    public class results
    {
        public string gender { get; set; }
        public Name name { get; set; }
    }
    public class Name
    {
        public string Title { get; set; }
        public string  first { get; set; }
        public string  last { get; set; }
    }

}

