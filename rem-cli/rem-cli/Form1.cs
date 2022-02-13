using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Drawing.Imaging;
using System.Runtime.Serialization.Formatters.Binary;
using Gma.System.MouseKeyHook;
using System.Runtime.InteropServices;

using System.IO;

namespace rem_cli
{
    public partial class Form1 : Form
    {
        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool trackCursorPos(int x, int y);
        private IKeyboardMouseEvents m_Events;
        private readonly TcpClient tcpCli = new TcpClient();
        private NetworkStream netStream;
        private Point cliMousePoint = new Point();    
        private int PortNum;
        


        private static Image CatchDesktop()
        {
            Rectangle bounds = Screen.PrimaryScreen.Bounds;
            Bitmap screenshots = new Bitmap(bounds.Width, bounds.Height, PixelFormat.Format32bppArgb);
            Graphics graphics = Graphics.FromImage(screenshots);
            graphics.CopyFromScreen(bounds.X, bounds.Y, 0, 0, bounds.Size, CopyPixelOperation.SourceCopy);
            return screenshots;
        }
    
        private void SendDudes()
        {
            BinaryFormatter bFormatter = new BinaryFormatter();
            netStream = tcpCli.GetStream();
            bFormatter.Serialize(netStream, CatchDesktop());
        }

        private void SendMousePos()
        {

            BinaryFormatter bFormatter = new BinaryFormatter();
            netStream = tcpCli.GetStream();
            bFormatter.Serialize(netStream, cliMousePoint);
            
        }


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            btnShare.Enabled = false;
            timer1.Interval = 120;
            Unsubscribe();
            Subscribe(Hook.GlobalEvents());
        }

        private void btnCon_Click(object sender, EventArgs e)
        {
            PortNum = int.Parse(txtPort.Text);
            try
            {
                tcpCli.Connect(txtIP.Text, PortNum);
                btnCon.Text = "Connncted";
                MessageBox.Show("Работает заебал");
                btnCon.Enabled = false;
                btnShare.Enabled = true;

            }

            catch(Exception)
            {
                MessageBox.Show("Не работает заебал");
                btnCon.Text = "Пососешь,ок?";
            }

        }

        private void btnShare_Click(object sender, EventArgs e)
        {
            if (btnShare.Text.StartsWith("Share")) 
            {              
                timer1.Start();
                btnShare.Text = "Останови это дерьмо";
            }
            else
            {
                timer1.Stop();
                btnShare.Text = "ShareMyScreen";
            }
        }

        private void Subscribe (IKeyboardMouseEvents events)
        {
            m_Events = events;
            m_Events.MouseMove += M_Events_MouseMove;
        }

        private void M_Events_MouseMove(object sender, MouseEventArgs e)
        {
            cliMousePoint = e.Location;
        }

        private void Unsubscribe()
        {
            if (m_Events == null) return;
            m_Events.MouseMove -= M_Events_MouseMove;
            m_Events.Dispose();
            m_Events = null;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            SendDudes();
            SendMousePos();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Unsubscribe();
        }
    }
}
