using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2276OzoneGenerator.Testing
{
    public partial class MainForm : Form
    {
        private SerialPort serialPort;

        public MainForm()
        {
            InitializeComponent();
            LoadAvailablePorts();
        }

        private void LoadAvailablePorts()
        {
            comboBoxPorts.Items.AddRange(SerialPort.GetPortNames());
            if (comboBoxPorts.Items.Count > 0)
                comboBoxPorts.SelectedIndex = 0;
        }

        private void buttonConnect_Click(object sender, EventArgs e)
        {
            if (serialPort == null)
            {
                serialPort = new SerialPort(comboBoxPorts.SelectedItem.ToString(), 9600, Parity.None, 8, StopBits.One);
                serialPort.DataReceived += new SerialDataReceivedEventHandler(DataReceivedHandler);
                serialPort.Open();
                buttonConnect.Text = "Disconnect";
                buttonSend.Enabled = true;
            }
            else
            {
                serialPort.Close();
                serialPort = null;
                buttonConnect.Text = "Connect";
                buttonSend.Enabled = false;
            }
        }

        private void buttonSend_Click(object sender, EventArgs e)
        {
            if (serialPort != null && serialPort.IsOpen)
            {
                serialPort.WriteLine(textBoxCommand.Text);
            }
        }

        private void DataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
        {
            string inData = serialPort.ReadExisting();
            Invoke(new MethodInvoker(delegate
            {
                textBoxOutput.AppendText(inData + Environment.NewLine);
            }));
        }
    }
}
