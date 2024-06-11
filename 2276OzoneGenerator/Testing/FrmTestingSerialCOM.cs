using System;
using System.IO.Ports;
using System.Windows.Forms;

namespace _2276OzoneGenerator.Testing
{
    public partial class FrmTestingSerialCOM : Form
    {
        private SerialPort _serialPort;

        public FrmTestingSerialCOM()
        {
            InitializeComponent();
            InitializeCustomComponents();
        }

        private void InitializeCustomComponents()
        {
            // ComboBox for available serial ports
            ComboBox cmbSerialPorts = new ComboBox { Left = 10, Top = 10, Width = 150 };
            cmbSerialPorts.Items.AddRange(SerialPort.GetPortNames());
            this.Controls.Add(cmbSerialPorts);

            // Button to connect
            Button btnConnect = new Button { Left = 170, Top = 10, Width = 100, Text = "Connect" };
            btnConnect.Click += (sender, args) => ConnectToSerialPort(cmbSerialPorts.SelectedItem.ToString());
            this.Controls.Add(btnConnect);

            // Button to disconnect
            Button btnDisconnect = new Button { Left = 280, Top = 10, Width = 100, Text = "Disconnect" };
            btnDisconnect.Click += (sender, args) => DisconnectFromSerialPort();
            this.Controls.Add(btnDisconnect);

            // ComboBox for selecting protocol
            ComboBox cmbProtocol = new ComboBox { Left = 10, Top = 40, Width = 150 };
            cmbProtocol.Items.AddRange(new string[] { "ASCII", "RTU" });
            this.Controls.Add(cmbProtocol);

            // ComboBox for Baudrate
            ComboBox cmbBaudRate = new ComboBox { Left = 10, Top = 70, Width = 150 };
            cmbBaudRate.Items.AddRange(new string[] { "9600", "19200", "38400", "57600", "115200" });
            this.Controls.Add(cmbBaudRate);

            // ComboBox for Parity
            ComboBox cmbParity = new ComboBox { Left = 10, Top = 100, Width = 150 };
            cmbParity.Items.AddRange(Enum.GetNames(typeof(Parity)));
            this.Controls.Add(cmbParity);

            // ComboBox for Stop Bits
            ComboBox cmbStopBits = new ComboBox { Left = 10, Top = 130, Width = 150 };
            cmbStopBits.Items.AddRange(Enum.GetNames(typeof(StopBits)));
            this.Controls.Add(cmbStopBits);

            // ComboBox for Data Bits
            ComboBox cmbDataBits = new ComboBox { Left = 10, Top = 160, Width = 150 };
            cmbDataBits.Items.AddRange(new string[] { "5", "6", "7", "8" });
            this.Controls.Add(cmbDataBits);

            // TextBox for sending commands
            TextBox txtSend = new TextBox { Left = 10, Top = 190, Width = 370 };
            this.Controls.Add(txtSend);

            // Button to send commands
            Button btnSend = new Button { Left = 390, Top = 190, Width = 100, Text = "Send" };
            btnSend.Click += (sender, args) => SendCommand(txtSend.Text);
            this.Controls.Add(btnSend);

            // TextBox for receiving data
            TextBox txtReceive = new TextBox { Left = 10, Top = 220, Width = 480, Height = 200, Multiline = true };
            this.Controls.Add(txtReceive);

            // Initialize SerialPort
            _serialPort = new SerialPort();
            _serialPort.DataReceived += (sender, args) => txtReceive.Invoke(new MethodInvoker(delegate
            {
                txtReceive.AppendText(_serialPort.ReadExisting());
            }));
        }

        private void ConnectToSerialPort(string portName)
        {
            if (_serialPort.IsOpen)
                _serialPort.Close();

            _serialPort.PortName = portName;
            _serialPort.BaudRate = int.Parse(((ComboBox)this.Controls[4]).SelectedItem.ToString()); // Baudrate
            _serialPort.Parity = (Parity)Enum.Parse(typeof(Parity), ((ComboBox)this.Controls[5]).SelectedItem.ToString()); // Parity
            _serialPort.StopBits = (StopBits)Enum.Parse(typeof(StopBits), ((ComboBox)this.Controls[6]).SelectedItem.ToString()); // Stop Bits
            _serialPort.DataBits = int.Parse(((ComboBox)this.Controls[7]).SelectedItem.ToString()); // Data Bits
            _serialPort.Handshake = Handshake.None;

            try
            {
                _serialPort.Open();
                MessageBox.Show("Connected successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error connecting to serial port: " + ex.Message);
            }
        }

        private void DisconnectFromSerialPort()
        {
            if (_serialPort.IsOpen)
            {
                _serialPort.Close();
                MessageBox.Show("Disconnected successfully!");
            }
        }

        private void SendCommand(string command)
        {
            if (_serialPort.IsOpen)
            {
                _serialPort.Write(command);
            }
            else
            {
                MessageBox.Show("Serial port is not open.");
            }
        }
    }
}
