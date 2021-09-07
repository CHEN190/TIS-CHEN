using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TIS_NTHU
{
    public partial class FormSnapShot : Form
    {
        public FormSnapShot()
        {
            InitializeComponent();
        }
        private Bitmap m_Bitmap;
        private bool m_SavedFg = false;

        public void save_in_path(string FF, int num)
        {

            string filepath = FF + "\\" + num.ToString() + ".Tiff";
            m_Bitmap.Save(filepath, System.Drawing.Imaging.ImageFormat.Tiff);
            //num++;
        }
        /*
        private void SaveImage()
        {
            if (null != m_Bitmap)
            {
                if (DialogResult.OK == saveFileDialog1.ShowDialog())
                {
                    m_Bitmap.Save(saveFileDialog1.FileName, System.Drawing.Imaging.ImageFormat.Bmp);
                    m_SavedFg = true;
                }
            }
        }
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveImage();
        }

        private void FormSnapShot_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!m_SavedFg)
            {
                if (DialogResult.Yes == System.Windows.Forms.MessageBox.Show("Do You Want To Save The Image?", "Save Image", System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Question))
                {
                    SaveImage();
                }
            }
            if (m_Bitmap != null)
            {
                pictureBox1.Image = null;
                m_Bitmap.Dispose();
                m_Bitmap = null;
            }
        }

        private void FormSnapShot_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Apps)
            {
                contextMenuStrip1.Show(this, this.PointToClient(MousePosition));
            }
        }*/


        public bool bUpdateSnapShot(int nWidth, int nHeight, byte[] pbyteImg, uint nBufferSize, System.Drawing.Imaging.PixelFormat pixelFormat)
        {
            Bitmap bitmap = new Bitmap(nWidth, nHeight, pixelFormat);


            switch (pixelFormat)
            {
                case (System.Drawing.Imaging.PixelFormat.Format8bppIndexed):
                    //Palette
                    {

                        System.Drawing.Imaging.ColorPalette colorPalette = bitmap.Palette;
                        for (int pixelValue = 0; pixelValue <= 255; pixelValue++)
                        {
                            colorPalette.Entries[pixelValue] = Color.FromArgb(pixelValue, pixelValue, pixelValue);
                        }
                        bitmap.Palette = colorPalette;
                    }
                    break;
            }

            //Copy
            System.Drawing.Imaging.BitmapData bitmapData = bitmap.LockBits(new Rectangle(0, 0, nWidth, nHeight), System.Drawing.Imaging.ImageLockMode.WriteOnly, pixelFormat);
            System.Runtime.InteropServices.Marshal.Copy(pbyteImg, 0, bitmapData.Scan0, (int)nBufferSize);
            bitmap.UnlockBits(bitmapData);

            if (m_Bitmap != null)
            {
                //pictureBox1.Image = null;
                m_Bitmap.Dispose();
            }

            m_Bitmap = bitmap;
            this.ClientSize = new Size(nWidth, nHeight);
            this.MaximumSize = this.Size;
            //pictureBox1.Location = new Point(0, 0);
            //pictureBox1.Image = m_Bitmap;
            m_SavedFg = false;

            return (true);
        }



    }
}
