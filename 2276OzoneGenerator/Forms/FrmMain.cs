using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2276OzoneGenerator
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            cbCOM.Items.AddRange(SerialPort.GetPortNames());
            InitializeNumericUpDown();
        }


        private string CalculateCRC(string input)
        {
            byte[] data = StringToByteArray(input);
            ushort crc = 0xFFFF;

            foreach (byte b in data)
            {
                crc ^= b;
                for (int i = 0; i < 8; i++)
                {
                    if ((crc & 1) != 0)
                    {
                        crc = (ushort)((crc >> 1) ^ 0xA001);
                    }
                    else
                    {
                        crc >>= 1;
                    }
                }
            }

            byte[] crcBytes = BitConverter.GetBytes(crc);
            string lowByte = crcBytes[0].ToString("X2");
            string highByte = crcBytes[1].ToString("X2");

            return input + lowByte + highByte;
        }

        private byte[] StringToByteArray(string hex)
        {
            int length = hex.Length;
            byte[] bytes = new byte[length / 2];
            for (int i = 0; i < length; i += 2)
            {
                bytes[i / 2] = Convert.ToByte(hex.Substring(i, 2), 16);
            }
            return bytes;
        }


        private void btnConnect_Click(object sender, EventArgs e)
        {
            ConnectToSerialPort(cbCOM.SelectedItem.ToString());
        }

        private void ConnectToSerialPort(string portName)
        {
            if (serialPort1.IsOpen)
                serialPort1.Close();

            serialPort1.PortName = portName;
            serialPort1.BaudRate = 9600;
            serialPort1.Parity = Parity.Even;
            serialPort1.StopBits = StopBits.One;
            serialPort1.DataBits = 8;
            serialPort1.Handshake = Handshake.None;
            serialPort1.ReceivedBytesThreshold = 14;

            try
            {
                serialPort1.Open();
                MessageBox.Show("Connected successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error connecting to serial port: " + ex.Message);
            }
        }

        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                serialPort1.Close();
                MessageBox.Show("Disconnected successfully!");
            }
        }

        string response = "";

        private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            int bytesToRead = serialPort1.BytesToRead;
            byte[] buffer = new byte[bytesToRead];
            serialPort1.Read(buffer, 0, bytesToRead);

            string receivedData = BitConverter.ToString(buffer);

            response = receivedData;

            ShowResponse();
        }

        private void ShowResponse()
        {
            if (InvokeRequired)
            {
                Invoke(new MethodInvoker(ShowResponse));
            }
            else
            {
                txtResponse.Text = $"Command Response: {response} ";

                // Traduccion de la respuesta al valor de la temperatura

                string substring = response.Substring(9, 5);

                string hexString = substring.Replace("-", "");

                int decimalValue = Convert.ToInt32(hexString, 16);

                double finalValue = decimalValue / 10.0;

                txtResponse.Text += $"\n\nCurrent Temperature: {finalValue.ToString()}";
            }
        }


        private void btnSendHexW_Click(object sender, EventArgs e)
        {
            SendHexCommand(commandHexDevice);
        }

        string commandHexDevice = "01 03 00 00 00 0A C5 CD";

        private void SendHexCommand(string hexCommand)
        {
            string[] hexBytes = hexCommand.Split(' ');
            byte[] binaryData = new byte[hexBytes.Length];
            for (int i = 0; i < hexBytes.Length; i++)
            {
                binaryData[i] = Convert.ToByte(hexBytes[i], 16);
            }
            serialPort1.Write(binaryData, 0, binaryData.Length);
        }

        // BOTON PARA CALCULAR EL CRC DE UN COMANDO

        private void btnCalculateCRC_Click(object sender, EventArgs e)
        {
            string inputCommand = txtInput.Text.Trim();
            if (IsValidHex(inputCommand))
            {
                string crcCommand = CalculateCRC(inputCommand);
                txtOutput.Text = crcCommand;
            }
            else
            {
                MessageBox.Show("The input is not a valid hexadecimal string.Please enter only hexadecimal characters(0 - 9, A - F).", "Invalid Input",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool IsValidHex(string input)
        {
            // Check if the input string is even-length
            if (input.Length % 2 != 0)
                return false;

            // Check if all characters are valid hexadecimal digits
            return input.All(c => "0123456789ABCDEFabcdef".Contains(c));
        }

        // Working correctly

        string RequestTemp_SetSP_RunChiller = "01 17 00 00 00 01 00 0B 00 02 04 01 2C 00 31 77 1D";
        private void btnCommand1_Click(object sender, EventArgs e)
        {
            SendHexCommand(RequestTemp_SetSP_RunChiller);
        }

        private void InitializeNumericUpDown()
        {
            txtSetpoint.Minimum = 18.0M;  // Configura el valor mínimo
            txtSetpoint.Maximum = 22.0M;  // Configura el valor máximo
            lastValidValue = txtSetpoint.Value;  // Guarda el valor inicial
        }

        private decimal lastValidValue;

        private void txtSetpoint_ValueChanged(object sender, EventArgs e)
        {
            if (txtSetpoint.Value < 18.0M || txtSetpoint.Value > 22.0M)
            {
                MessageBox.Show("El valor debe estar entre 18.0 y 22.0", "Valor fuera de rango", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSetpoint.Value = lastValidValue;  // Restaura el último valor válido
            }
            else
            {
                lastValidValue = txtSetpoint.Value;  // Actualiza el último valor válido
            }
        }

        string InicioConstanteHexCommandSendSetpoint = "01 17 00 00 00 01 00 0B 00 02 04";
        string InicioConstanteHexCommandSendSetpoint2 = "011700000001000B000204";

        private void btnSendSetpoint_Click(object sender, EventArgs e)
        {
            lbStatus.ForeColor = Color.Red;
            lbStatus.Text = "Running...";

            CommandToSend = CalculateCommandSendSetpoint();
        }

        private string CalculateCommandSendSetpoint()
        {
            try
            {
                string setpointValue = txtSetpoint.Value.ToString("00.0");
                string valueWithoutDot = setpointValue.Replace(".", "");

                int decimalValue;

                if (int.TryParse(valueWithoutDot, out decimalValue))
                {
                    // Convert the value from txt to HEX format 0X0000.
                    string hexValue = decimalValue.ToString("X4");

                    // Add the constant values to the command to turn on the Chiller.
                    string WithoutCRC = InicioConstanteHexCommandSendSetpoint2 + hexValue + "0031";

                    // Calculate the CRC for the RTU protocol.
                    string CompleteCommandWithCRC = CalculateCRC(WithoutCRC);

                    // Return the complete command by adding spaces every 2 characters to match the required format of the SendHexCommand function.
                    return AddSpaceBetweenPairs(CompleteCommandWithCRC);
                }
                else
                {
                    MessageBox.Show("El valor del setpoint no es válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return "";
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Error: \n" + e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return "";
            }
        }

        private string CalculateCommandStop()
        {
            try
            {
                string setpointValue = txtSetpoint.Value.ToString("00.0");
                string valueWithoutDot = setpointValue.Replace(".", "");

                int decimalValue;

                if (int.TryParse(valueWithoutDot, out decimalValue))
                {
                    // Convert the value from txt to HEX format 0X0000.
                    string hexValue = decimalValue.ToString("X4");

                    // Add the constant values to the command to turn on the Chiller.
                    string WithoutCRC = InicioConstanteHexCommandSendSetpoint2 + hexValue + "0030";

                    // Calculate the CRC for the RTU protocol.
                    string CompleteCommandWithCRC = CalculateCRC(WithoutCRC);

                    // Return the complete command by adding spaces every 2 characters to match the required format of the SendHexCommand function.
                    return AddSpaceBetweenPairs(CompleteCommandWithCRC);
                }
                else
                {
                    MessageBox.Show("El valor del setpoint no es válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return "";
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Error: \n" + e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return "";
            }
        }

        private string AddSpaceBetweenPairs(string input)
        {
            if (string.IsNullOrEmpty(input) || input.Length < 2)
            {
                return input; // Retorna el input original si es nulo o tiene menos de 2 caracteres
            }

            string result = string.Empty;
            for (int i = 0; i < input.Length; i += 2)
            {
                if (i + 2 <= input.Length)
                {
                    result += input.Substring(i, 2) + " ";
                }
                else
                {
                    result += input.Substring(i);
                }
            }

            return result.Trim(); // Elimina el espacio final
        }

        private void btnStopCommand_Click(object sender, EventArgs e)
        {
            lbStatus.ForeColor = Color.Blue;
            lbStatus.Text = "Not Running";
            CommandToSend = CalculateCommandStop();
        }

        string CommandToSend = "";

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen) 
            {
                if (!string.IsNullOrEmpty(CommandToSend))
                {
                    SendHexCommand(CommandToSend);
                }
            }

            lbDateTime.Text = DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss");
        }
    }
}
