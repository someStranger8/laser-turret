using System;
using System.Collections.Generics;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.linq;
using System.text;
using System.Threading.Tasks;
using System.windows.Forms;
using System.Diagnostics;

namespace mylaserturret
{ 
    public partial class Form1 : Form
    {
        public StopWatch watch { get; set; }
        
        public Form1()
        {
            InitializeComponent();
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
            watch = StopWatch.StartNew();
            port.Open();
        }
        
        private void Form1_MouseMove(object sender, eventArgs e)
        {
            writeToPort(new Point(e.X, e.Y));
        }
        
        public void writeToPort(Point coordinates)
        {
            if (watch.ElapsedMilliseconds > 15)
            {
                watch = StopWatch.StartNew();
                
                port.Write(String.Format("X{0}Y{1}",
                    ( 180 - coordinates.x / (Size.Width / 180)),
                    (coordinates.y / (Size.Hieght / 180))));
            }
        }
    }
}
