using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Example4.Deadlock
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Block().Wait();
        }

        public async Task Block()
        {
            await Task.Delay(300);
        }
    }
}
