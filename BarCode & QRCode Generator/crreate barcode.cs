using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CodeTests
{
    public partial class crreate_barcode : Form
    {
        public crreate_barcode()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
                Zen.Barcode.Code128BarcodeDraw brCode = Zen.Barcode.BarcodeDrawFactory.Code128WithChecksum;
                picBarcode.Image = brCode.Draw(textBarCode.Text,100);
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Zen.Barcode.CodeQrBarcodeDraw qrcode = Zen.Barcode.BarcodeDrawFactory.CodeQr;
            picBarcode.Image = qrcode.Draw(txtqrcode.Text, 100);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "PNG|*.png" })
            {
                if(sfd.ShowDialog() == DialogResult.OK)
                {
                    picBarcode.Image.Save(sfd.FileName);
                }
            }
        }
    }
}
