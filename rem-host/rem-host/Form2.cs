using System;
using System.Drawing;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;
using System.Windows.Forms;

namespace rem_host
{
    public partial class Form2 : Form
    {
        private readonly int port;

        public Form2(TcpClient tcpClient)
        {
            this.tcpClient = tcpClient;
        }

        private TcpClient tcpClient;
        private TcpListener tcpListener;
        private NetworkStream netSteram;
        private NetworkStream netSteram2;


        private readonly Thread Listening;
        private readonly Thread GetCapture;
        private readonly Thread GetCliMousePonit;
        private Point cliCurrentMousePoint;

        public Thread GetCliMousePonit1 => GetCliMousePonit;

        public Form2(int Port)
        {
            port = Port;
            tcpClient = new TcpClient();
            Listening = new Thread(RodinaSlishit);
            GetCapture = new Thread(RecieveDudes);
            GetCliMousePonit = new Thread(RecieveCliM_point);



            InitializeComponent();
        }

        private void RecieveCliM_point()
        {
            BinaryFormatter binFormat = new BinaryFormatter();
            while (tcpClient.Connected)
            {
                netSteram2 = tcpClient.GetStream();
                cliM_pointX.Invoke((Action)delegate
                {
                    cliCurrentMousePoint = (Point)binFormat.Deserialize(netSteram2);

                    cliM_pointX.Text = "x:" + cliCurrentMousePoint.X.ToString() + "y:" + cliCurrentMousePoint.Y.ToString();
                });

            }
        }

        private void RodinaSlishit()
        {
            while (!tcpClient.Connected)
            {
                tcpListener.Start();
                tcpClient = tcpListener.AcceptTcpClient();
            }
            GetCapture.Start();
            GetCliMousePonit.Start();
        }

        private void RodinaNeSlishit()
        {
            tcpListener.Stop();
            tcpClient = null;
            if (Listening.IsAlive)
            {
                Listening.Abort();
            }
            if (GetCapture.IsAlive)
            {
                GetCapture.Abort();
            }
            if (GetCliMousePonit.IsAlive)
            {
                GetCliMousePonit.Abort();
            }
        }

        private void RecieveDudes()
        {
            BinaryFormatter binFormat = new BinaryFormatter();
            while (tcpClient.Connected)
            {
                netSteram = tcpClient.GetStream();
                pictureBox1.Invoke((Action)delegate
                {
                    pictureBox1.Image = (Image)binFormat.Deserialize(netSteram);
                });
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            tcpListener = new TcpListener(IPAddress.Any, port);
            Listening.Start();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            RodinaNeSlishit();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
}
