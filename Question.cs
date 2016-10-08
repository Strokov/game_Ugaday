using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson8
{
    [Serializable]
    public class Question
    {
        public string text { get; set; } // свойство вызова и установки
        public bool TrueFalse { get; set; }  // свойство вызова и установки

        public Question()  // Для возможности сериализации создаем пустой конструктор
            {
            }

        public Question(string text, bool TrueFalse)  // Конструктор для задания свойств классу
        {
            this.TrueFalse = TrueFalse;
            this.text = text;
        }

    }
}
