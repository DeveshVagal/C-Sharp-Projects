using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AForge.Video;
using ZXing;
using AForge.Video.DirectShow;

namespace CodeTests
{
    public partial class QRCodeScanner : Form
    {
        public QRCodeScanner()
        {
            InitializeComponent();
        }

        FilterInfoCollection filterInfoCollection;
        VideoCaptureDevice captureDevice;
        private void QRCodeScanner_Load(object sender, EventArgs e)
        {
            filterInfoCollection = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach (FilterInfo filterInfo in filterInfoCollection)
                cboDevice.Items.Add(filterInfo.Name);
            cboDevice.SelectedIndex = -1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            captureDevice = new VideoCaptureDevice(filterInfoCollection[cboDevice.SelectedIndex].MonikerString);
            captureDevice.NewFrame += captureDevice_NewFrame;
            captureDevice.Start();
            timer1.Start();
        }

        private void captureDevice_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            pictureBox.Image = (Bitmap)eventArgs.Frame.Clone();
        }

        private void QRCodeScanner_FormClosing(object sender, FormClosingEventArgs e)
        {
                if (captureDevice.IsRunning)
                {
                    captureDevice.Stop();
                }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if(pictureBox.Image != null)
            {
                BarcodeReader barcodereader = new BarcodeReader();
                Result result = barcodereader.Decode((Bitmap)pictureBox.Image);
                if(result != null)
                {
                    txtQRCode.Text = result.ToString();
                    timer1.Stop();

                    if (captureDevice.IsRunning)
                    {
                        captureDevice.Stop();
                    }
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (captureDevice.IsRunning)
            {
                captureDevice.Stop();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtQRCode.Text = "";
        }
    }
}
