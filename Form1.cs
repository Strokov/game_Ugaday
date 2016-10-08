using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lesson8
{
    public partial class Form1 : Form
    {
        ListQuestion database=null;
        int x = 0;
        int verno = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void menuExit_Click(object sender, EventArgs e)
        {
           if (MessageBox.Show("Вы уверены?","Предупреждение", MessageBoxButtons.YesNo)==DialogResult.Yes) this.Close();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                database = new ListQuestion(sfd.FileName);
                database.Add("ты козел?", true);
                database.Save();
                numUpDown.Minimum = 1;
                numUpDown.Maximum = 1;
                numUpDown.Value = 1;
            }                
        }

        private void numUpDown_ValueChanged(object sender, EventArgs e)
        {
            textBox1.Text = database[(int)numUpDown.Value-1].text;
            chBoxTrFalse.Checked = database[(int)numUpDown.Value - 1].TrueFalse;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (database == null)
            {
                MessageBox.Show("Создайте базу данных!", "Сообщение");
                return;
            }

            database.Add((database.Count+1).ToString(), true);
            numUpDown.Maximum = database.Count;
            numUpDown.Value = database.Count;
        }

        private void btnRem_Click(object sender, EventArgs e)
        {
            if (database == null || numUpDown.Maximum == 1) MessageBox.Show("Откройте или создайте базу загадок","Сообщение");
            else
            {
                  x++;
                  textBox1.Text = database[x].text;
                  numUpDown.Value = x + 1;
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (database != null) database.Save();
            else MessageBox.Show("Создайте базу данных!","Сообщение");
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                database = new ListQuestion(ofd.FileName);
                database.Load();
                numUpDown.Minimum = 1;
                numUpDown.Maximum = database.Count;
                numUpDown.Value = 1;
            }
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Text = Clipboard.GetText();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            database[(int)numUpDown.Value - 1].text = textBox1.Text;
            database[(int)numUpDown.Value - 1].TrueFalse = chBoxTrFalse.Checked;

            if (database != null) database.Save();
            else MessageBox.Show("Создайте базу данных!", "Сообщение");
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (database == null)
            {
                MessageBox.Show("Создайте базу данных!", "Сообщение");
                return;
            }
            
            if (database != null)
            {
                MessageBox.Show("Напечатайте текст в поле ниже и поставьте флажок ПРАВДА или нет. \n Затем нажмите в меню СОХРАНИТЬ изменения ЗАГАДоК", "Инструкция");
                database.Add((database.Count + 1).ToString(), true);
                numUpDown.Maximum = database.Count;
                numUpDown.Value = database.Count;
            }
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (database == null) MessageBox.Show("Создайте базу данных!", "Сообщение");
            else
            {
                database[(int)numUpDown.Value - 1].text = textBox1.Text;
                database[(int)numUpDown.Value - 1].TrueFalse = chBoxTrFalse.Checked;
                database.Save();
                MessageBox.Show("Загадка под номером " + numUpDown.Value + " в базе сохранена", "Спасибо!");
            }
        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Вы уверены, что хотите удалить загадку номер " + numUpDown.Value, "Предупреждение", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
            if (database == null || numUpDown.Maximum == 1) return;
            database.Remove((int)numUpDown.Value);
            numUpDown.Maximum--;
            if (numUpDown.Value > 1) numUpDown.Value = numUpDown.Value;
            }

        }

        private void иГРАТЬToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (database == null) MessageBox.Show("Создайте/откройте сначала базу данных загадок!", "Сообщение");
            else
            {
                MessageBox.Show("На загадки отвечайте кнопками ВЕРЮ / НЕ ВЕРЮ и СЛЕДУЮЩАЯ. В конце считаем баллы:))", "Здравствуйте! Приятной игры!");
                textBox1.Text = database[0].text;
            }
       
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (database[x].TrueFalse == true) verno++;
            if (x == (database.Count-1))
            {
                MessageBox.Show("Закончились загадки. Вы отгадали "+ verno +" загадок", "Спасибо за игру!" );
                x = 0;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (database[x].TrueFalse == false) verno++;
            if (x == (database.Count - 1))
            {
                MessageBox.Show("Закончились загадки. Вы отгадали " + verno + " загадок", "Спасибо за игру!");
                x = 0;
            }
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
           SaveFileDialog ofd = new SaveFileDialog();
           if (ofd.ShowDialog() == DialogResult.OK) database.Save();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Игра Верю-Не верю. Версия 1.0. Очень глючная! \n Пожелания по доработке программы и ошибках в коде прошу направлять по адресу: pavig@yandex.ru \n Разработчик программы StrokovPI. Все права защищены:)", "О программе");
        }
    }
}
