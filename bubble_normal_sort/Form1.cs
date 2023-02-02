using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace bubble_normal_sort
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public static string s1 = "";
        public static string s2 = "";
        public static string s3 = "";


        //public static TimeSpan GetElapsedTime(long startingTimestamp, long endingTimestamp);
        public void mass_enter(ListBox list)
        {
            Random rnd = new Random();
            Stopwatch stopWatch = new Stopwatch();

            if (list.Name == "listBox1")
            {
                stopWatch.Start();
                for (int i = 0; i < 10000; i++)
                {
                    int a = rnd.Next(0, 100);

                    list.Items.Add(a);
                }
                stopWatch.Stop();

                TimeSpan ts = stopWatch.Elapsed;

                string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                    ts.Hours, ts.Minutes, ts.Seconds,
                    ts.Milliseconds / 10);
                s2 = elapsedTime;
                label4.Text = elapsedTime;

                mass_sort(list);
            }
            else if (list.Name == "listBox2")
            {
                List<int> a = new List<int>();

                for (int i = 0; i < listBox1.Items.Count; i++)
                {
                    list.Items.Add(Convert.ToInt32(listBox1.Items[i]));
                }

                QuickSort(a, label6);
            }
        }

        public static void Swap(int x, int y, Label la)
        {
            var t = x;
            x = y;
            y = t;

            s3 = s1 + s2;

            la.Text = "1";
        }

        //метод возвращающий индекс опорного элемента
        static int Partition(List<int> array, int minIndex, int maxIndex, Label la)
        {
            var pivot = minIndex - 1;
            for (var i = minIndex; i < maxIndex; i++)
            {
                if (array[i] < array[maxIndex])
                {
                    pivot++;
                    Swap(array[pivot], array[i], la);
                }
            }

            pivot++;
            Swap(array[pivot], array[maxIndex], la);
            return pivot;
        }

        //быстрая сортировка
        static List<int> QuickSort(List<int> array, int minIndex, int maxIndex, Label la)
        {
            if (minIndex >= maxIndex)
            {
                return array;
            }

            var pivotIndex = Partition(array, minIndex, maxIndex, la);
            QuickSort(array, minIndex, pivotIndex - 1, la);
            QuickSort(array, pivotIndex + 1, maxIndex, la);

            return array;
        }

        static List<int> QuickSort(List<int> array, Label la)
        {
            return QuickSort(array, 0, array.Count - 1, la);
        }

        public void mass_sort(ListBox list)
        {
            int temp;
            for (int i = 0; i < list.Items.Count; i++)
            {
                for (int j = i + 1; j < list.Items.Count; j++)
                {
                    if (Convert.ToInt32(list.Items[i]) > Convert.ToInt32(list.Items[j]))
                    {
                        temp = Convert.ToInt32(list.Items[i]);
                        list.Items[i] = list.Items[j];
                        list.Items[j] = temp;
                    }
                }
            }
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            mass_enter(listBox1);
            stopWatch.Stop();
            // Get the elapsed time as a TimeSpan value.
            TimeSpan ts = stopWatch.Elapsed;

            // Format and display the TimeSpan value.
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                ts.Hours, ts.Minutes, ts.Seconds,
                ts.Milliseconds / 10);
            s1 = elapsedTime;
            label1.Text = elapsedTime;
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            List<int> a = new List<int>();

            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            mass_enter(listBox2);

            s3 = s1 + s2;

            

            stopWatch.Stop();
            // Get the elapsed time as a TimeSpan value.
            TimeSpan ts = stopWatch.Elapsed;

            // Format and display the TimeSpan value.
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                ts.Hours, ts.Minutes, ts.Seconds,
                ts.Milliseconds / 10);

            label2.Text = elapsedTime;
        }
    }
}
