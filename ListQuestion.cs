using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Lesson8
{
    class ListQuestion
    {
        string fileName;

        List<Question> List;  // Объявление списка объектов "вопросы и truefalse"

        public string FileName
        {
            set { FileName = value;}
    
        }

        public ListQuestion (string fileName)
        {
            this.fileName = fileName;
            List = new List<Question> ();
        }

        public void Add(string text, bool TrueFalse)  // Добавка объекта ВОПРОС к спуску
        {
            Question q = new Question();
            List.Add(q);
        }

        public void Remove(int index) // Удаление объекта ВОПРОС к по индексу
        {
            if (List != null && index<List.Count && index >=0) List.RemoveAt(index);
        }

        public int Count
        {
            get { return List.Count; }
        }

        public Question this[int index]
        {
            get { return List[index]; }
        }


        public void Save()
        {
            XmlSerializer xmlFormat = new XmlSerializer(typeof(List<Question>));
            Stream fStream = new FileStream(fileName, FileMode.Create, FileAccess.Write);
            xmlFormat.Serialize(fStream, List);
            fStream.Close();
        }



        public void Load()
        {
            XmlSerializer xmlFormat = new XmlSerializer(typeof(List<Question>));
            Stream fStream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            List = (List<Question>)xmlFormat.Deserialize(fStream);
            fStream.Close(); 
            
        }

    }


}
