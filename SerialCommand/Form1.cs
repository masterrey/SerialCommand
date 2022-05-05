using System.IO.Ports;

namespace SerialCommand
{
    public partial class Form1 : Form
    {
        SerialPort portaserial;
        int potencia = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            portaserial=new SerialPort();
            portaserial.BaudRate = 9600;
            portaserial.PortName = "COM13";
            try
            {
                portaserial.Open();
            }catch (Exception ex)
            {
               label1.Text=ex.Message;
            }
            timer1.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            portaserial.WriteLine(trackBar1.Value.ToString());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            portaserial.WriteLine("0");
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            potencia=trackBar1.Value;
        }
        //chama a funcao da porta serial a cada 1 seg
        private void timer1_Tick(object sender, EventArgs e)
        {
            portaserial.WriteLine(trackBar1.Value.ToString());
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}