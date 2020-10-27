using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    class Program
    {
        static void Main(string[] args)
        {
            Form f1 = new Form();
            f1.Text = "Hallo";

            Button b1 = new Button();
            b1.Text = "Click me";
            b1.Location = new Point { X = 20, Y = 50 };

            f1.Controls.Add(b1);

            b1.Click += Hallo;

            f1.ShowDialog();
        }

        static void Hallo(object sender, EventArgs e)
        {
            Console.WriteLine("Hallo");
            Button b1 = sender as Button;
            b1.BackColor = Color.Red;
        }
    }
}
