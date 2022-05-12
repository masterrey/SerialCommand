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
            portaserial.PortName = "COM"+numericUpDown1.Value.ToString();
            
            try
            {
                portaserial.Open();
            }catch (Exception ex)
            {
               label1.Text=ex.Message;
            }

            if (portaserial.IsOpen)
            {
                label1.Text = "Connected...";
                button1.Enabled = false;
                button2.Enabled = true;
                button3.Enabled = true;
                button4.Enabled = true;
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            portaserial.WriteLine("LED5 "+trackBar1.Value.ToString());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            portaserial.WriteLine("LED5 0");
            portaserial.WriteLine("LED6 0");
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            potencia=trackBar1.Value;
        }
        //chama a funcao da porta serial a cada 1 seg
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (portaserial!=null && portaserial.IsOpen)
            {

                if (portaserial.BytesToRead > 0) { 
                        String mensagem = portaserial.ReadLine();
                    if (mensagem.Contains("BTN"))
                    {

                        if (mensagem.Substring(4).Contains("1"))
                        {
                            checkBox1.Checked = true;
                        }
                        if (mensagem.Substring(4).Contains("0"))
                        {
                            checkBox1.Checked = false;
                        }
                    }
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            portaserial.WriteLine("LED6 " + trackBar1.Value.ToString());
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (portaserial != null)
            {
                portaserial.Close();


                if (!portaserial.IsOpen)
                {
                    label1.Text = "Closed.";
                    button1.Enabled = true;
                    button2.Enabled = false;
                    button3.Enabled = false;
                    button4.Enabled = false;
                }
            }
        }
    }
}