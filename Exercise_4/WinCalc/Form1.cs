using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinCalc
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            decimal a = nrA.Value;
            decimal b = nrB.Value;

            //decimal result = Add(a, b);
            //UpdateAnswer(result);

            var result = await AddAsync(a, b);
            UpdateAnswer(result);

            //var ctx = SynchronizationContext.Current;

            //Func<decimal, decimal, decimal> add = Add;
            //add.BeginInvoke(a, b, ar2 =>
            //{
            //    var result = add.EndInvoke(ar2);
            //    ctx.Post(UpdateAnswer, result);
            //    //UpdateAnswer(result);
            //}, null);

            //Task.Run(() =>
            //{
            //    var result = Add(a, b);
            //    return result;
            //}).ContinueWith(pt =>{
            //    ctx.Post(UpdateAnswer, pt.Result);
            //});        
        }

        private void UpdateAnswer(object result)
        {
            lblAnswer.Text = result.ToString();
        }

        private decimal Add(decimal a, decimal b)
        {
            Task.Delay(10000).Wait();
            return a + b;
        }
        private Task<decimal> AddAsync(decimal a, decimal b)
        {
            return Task.Run(() => Add(a, b));
        }
    }
}
