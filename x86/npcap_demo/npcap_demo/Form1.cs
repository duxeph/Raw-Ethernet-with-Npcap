using SharpPcap;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PcapDotNet.Core;

namespace npcap_demo
{
    public partial class Form1 : Form
    {
        [DllImport("for_npcap.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int send_raw_packet(string iface, byte[] packet, int length);

        public Form1()
        {
            InitializeComponent();

            // using sharppcap
            var devices = CaptureDeviceList.Instance;

            if (devices.Count < 1)
            {
                Console.WriteLine("No interfaces found! Is Npcap installed?");
                return;
            }

            Console.WriteLine("Available interfaces:\n");

            int i = 0;
            foreach (var dev in devices)
            {
                Console.WriteLine($"{i++}. {dev.Name}");
                Console.WriteLine($"   {dev.Description}");
                Console.WriteLine();
            }

            // using pcap.net
            var allDevices = LivePacketDevice.AllLocalMachine;

            if (allDevices.Count == 0)
            {
                Console.WriteLine("No interfaces found! Is Npcap installed?");
                return;
            }

            Console.WriteLine("Available Interfaces:\n");

            for (i = 0; i < allDevices.Count; ++i)
            {
                var device = allDevices[i];
                Console.WriteLine($"{i + 1}. {device.Name}");
                Console.WriteLine($"   Description: {device.Description}");

                foreach (var address in device.Addresses)
                {
                    Console.WriteLine($"   Address: {address.Address}");
                }

                Console.WriteLine();
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            byte[] frame = new byte[] {
                0x08, 0x97, 0x98, 0xD2, 0x7A, 0x18, // dest MAC
                0x08, 0x97, 0x98, 0xD2, 0x7A, 0x18, // src MAC
                0x81, 0x00, // VLAN ID
                0x00, 0x0A, // VLAN Tag
                0x88, 0xA7, // EtherType
                0x01, 0x02, 0x03 // Payload
            };

            int result = send_raw_packet(textBox1.Text, frame, frame.Length);
            Console.WriteLine($"Result: {result}");
        }

    }
}
