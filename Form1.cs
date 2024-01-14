using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace лабораторная_8
{
    public partial class Form1 : Form
    {
        private int[,] a; // Объявляем массив как поле класса
        public Form1()
        {
            InitializeComponent();
            Form1_Load(null, null);
        }
        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.RowCount = 3; // Кол‐во строк
            dataGridView1.ColumnCount = 5; // Кол‐во столбцов
            a = new int[3, 5]; // Инициализируем массив
            // Заполняем матрицу случайными числами
            Random rand = new Random();
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    a[i, j] = rand.Next(-100, 100);
                }
            }
            // Выводим матрицу в dataGridView1
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    dataGridView1.Rows[i].Cells[j].Value = a[i, j].ToString();
                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (a != null) // Проверяем, что массив уже создан
            {
                if (dataGridView1.Rows.Count > 0) // Проверяем, есть ли строки в таблице
                {
                    // Поиск наименьшего элемента в каждой строке
                    int[] minElements = new int[3];
                    for (int i = 0; i < 3; i++)
                    {
                        int min = int.MaxValue;
                        for (int j = 0; j < 4; j++)
                        {
                            if (a[i, j] < min)
                            {
                                min = a[i, j];
                            }
                        }
                        minElements[i] = min;
                    }
                    // Выводим результаты вычислений
                    for (int i = 0; i < 3; i++)
                    {
                        dataGridView1.Rows[i].Cells[4].Value = minElements[i].ToString();
                    }
                }
                else
                {
                    MessageBox.Show("Таблица пуста.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Создайте массив с помощью кнопки 'Создать массив'", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 1) // Проверяем, есть ли строки в таблице
            {
                dataGridView1.Rows.Clear(); // Очищаем все строки в таблице
            }
            else
            {
                MessageBox.Show("Таблица уже пуста", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error); // Выводим сообщение, что таблица уже пуста
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            button2.Click += button2_Click;
            button2.Text = "Создать массив";
            button1.Click += button1_Click;
            button1.Text = "Выполнить";
            dataGridView1.ColumnCount = 5; // Устанавливаем количество столбцов для вывода результатов
            button3.Click += button3_Click;
            button3.Text = "Очистить таблицу";
        }
    }
}