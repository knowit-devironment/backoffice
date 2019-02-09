using Quobject.SocketIoClientDotNet.Client;
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

namespace backoffice
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var socket = IO.Socket("http://ec2-13-53-174-238.eu-north-1.compute.amazonaws.com:3000/");
            socket.On(Socket.EVENT_CONNECT, () =>
            {
                socket.Emit("hi");

            });

            socket.On("image", (data) =>
            {
                Console.WriteLine(data);
            });
            Thread.Sleep(100000);
        }
    }
}
