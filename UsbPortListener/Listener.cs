using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsbPortListener
{

    public delegate void SerialReceived(string data);
    public class Listener : System.IO.Ports.SerialPort
    {
       public SerialReceived OnSerialReceived { get; set; }

        void OnSerialReceivedHandler(string data)
        {
            if (OnSerialReceived != null)
                OnSerialReceived(data);

        }

       public  Listener(string portName, int baudRate) : base(portName, baudRate )
       {

            this.DataReceived += Listener_DataReceived;
       }

        private void Listener_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            System.IO.Ports.SerialPort p = sender as System.IO.Ports.SerialPort;
            OnSerialReceivedHandler(p.ReadExisting());
        }
    }
}
