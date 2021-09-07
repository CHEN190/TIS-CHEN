#region -- Windows Namespace -- 
    // Windows default namespace
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.IO.Ports;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using TimersTimer = System.Timers.Timer;
    using System.Diagnostics;
    using System.Media;
#endregion
#region -- StCam Namespace --
    //Stcan namesapce (from stadard SDK)
    using SensorTechnology;
    using System.Runtime.InteropServices;
    using System.Threading;
    using System.IO;
#endregion
#region -- EmguCV Namespace -- 
    //EmguCV namespace
    using Emgu.CV;
    using System.Text.RegularExpressions;
    using Emgu.CV.CvEnum;
    using Emgu.CV.Structure;
    using Emgu.Util;
#endregion
#region -- NPOI Namespace --
    //NPOI namespace
    using NPOI.SS.UserModel;
    using NPOI.HSSF.UserModel;
    using NPOI.XSSF.UserModel;
    using NPOI.SS.Formula.Functions;
#endregion
// Main Project Start
// ----------------
// Final Edit Time : 2021/05/03
// Final Editor : PC-Chiang

namespace TIS_NTHU
{
    public partial class Form_TIS : Form
    {
        public Form_TIS()
        {
            InitializeComponent();  //initialize 
        }


        #region -- Public variable setting --
        VideoCapture toolvideo;     //declare EmguCV video object
        IWorkbook workbook = null;  //declare NPOI IWorkbook object
        public int CurPosition_Tool = 0, TarPosition_Tool = 0, TarSpeed_Tool = 0, TarAcc_Tool = 0;
        public int CurPosition_Img = 0, TarPosition_Img = 0, TarSpeed_Img = 0, TarAcc_Img = 0;
        public int tempNum;
        #endregion

        #region -- StCamera setting(from SDK) --
        //以下取自standard SDK 可不動
        private System.IntPtr m_hCamera;
        private System.IntPtr m_hWnd;
        private bool m_bStatusTransfer = false;
        private bool m_bStatusAVIFile = false;
        private bool m_bStatusPreviewWnd = false;
        private FormSnapShot m_FormSnapShot;

        [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case StCam.WM_STCAM_TRANSFER_START:
                    m_bStatusTransfer = true;
                    StatusChanged();
                    break;
                case StCam.WM_STCAM_TRANSFER_FINISH:
                    m_bStatusTransfer = false;
                    StatusChanged();
                    break;
                case StCam.WM_STCAM_AVI_FILE_START:
                    m_bStatusAVIFile = true;
                    StatusChanged();
                    break;
                case StCam.WM_STCAM_AVI_FILE_FINISH:
                    m_bStatusAVIFile = false;
                    StatusChanged();
                    break;
                case StCam.WM_STCAM_PREVIEW_WINDOW_CREATE:
                    m_bStatusPreviewWnd = true;
                    StatusChanged();
                    break;
                case StCam.WM_STCAM_PREVIEW_WINDOW_CLOSE:
                    m_bStatusPreviewWnd = false;
                    StatusChanged();
                    break;
                default:
                    base.WndProc(ref m);
                    break;
            }
        }
        private void StatusChanged()
        {
            if (m_bStatusPreviewWnd && m_bStatusTransfer)
                btn_Preview.Text = "Preview STOP";
            else
                btn_Preview.Text = "Preview START";
            if (!m_bStatusAVIFile)
            {
                btn_MeasureStart.Enabled = !m_bStatusAVIFile;
                textBox1.Text = m_bStatusAVIFile.ToString();
                Thread.Sleep(500);
                btn_MotorFree.PerformClick();
            }
        }
        #endregion

        #region -- initial setting --
        //視窗載入事件
        private void Form_TIS_Load(object sender, EventArgs e)
        {
            //電腦螢幕的寬和高
            int cwidth = System.Windows.Forms.SystemInformation.WorkingArea.Width;
            int cheight = System.Windows.Forms.SystemInformation.WorkingArea.Height;
            //視窗的寬和高
            int width = this.Size.Width;
            int height = this.Size.Height;

            // 讀取SerialPort
            string[] portName = SerialPort.GetPortNames();
            comboBox_Port1.Items.AddRange(portName);
            comboBox_Port2.Items.AddRange(portName);
            try
            {
                // 開啟相機
                m_hCamera = StCam.Open(0);
                StCam.SetReceiveMsgWindow(m_hCamera, this.Handle);
                StatusChanged();
                // StCam.SetRotationMode(m_hCamera,StCam.STCAM_ROTATION_COUNTERCLOCKWISE_90);

            }
            catch (Exception ex)
            { 
            }


            //相機曝光時間
            uint ExposureClock = uint.Parse(textBox_EXTime.Text);
            uint ExposureTime;
            StCam.SetExposureClock(m_hCamera, ExposureClock);
            StCam.GetExposureClock(m_hCamera, out ExposureTime);
            label_EXTime.Text = "Exposure Time :" + ExposureTime.ToString() + "us";

            //相機FPS
            uint VLines = uint.Parse(textBox_FPS.Text);
            float FPS;
            StCam.SetVBlankForFPS(m_hCamera, VLines);
            StCam.GetOutputFPS(m_hCamera, out FPS);
            label_FPS.Text = "FPS:" + FPS.ToString();

            StCam.CameraSetting(m_hCamera, StCam.STCAM_CAMERA_SETTING_WRITE);
        }
        //視窗關閉事件
        private void Form_TIS_FormClosing(object sender, FormClosingEventArgs e)
        {
            // 關閉SerialPort
            if (serialPort_tool.IsOpen)
            {
                serialPort_tool.Close();
            }
            if (serialPort_image.IsOpen)
            {
                serialPort_image.Close();
            }
            // 關閉相機
            if (m_hCamera != System.IntPtr.Zero)
                StCam.Close(m_hCamera);
        }
        #endregion

        #region -- system setting page --
        //Connect button 觸發事件
        //請參考Cool Muscle串列通訊
        private void btn_Connect_Click(object sender, EventArgs e)
        {
            btn_Connect.Enabled = false;
            btn_Disconnect.Enabled = true;
            try
            {
                serialPort_tool.PortName = comboBox_Port1.Text;
                serialPort_tool.BaudRate = 38400;
                serialPort_tool.Parity = Parity.None;
                serialPort_tool.DataBits = 8;
                serialPort_tool.StopBits = StopBits.One;
                serialPort_tool.Open();

                serialPort_image.PortName = comboBox_Port2.Text;
                serialPort_image.BaudRate = 38400;
                serialPort_image.Parity = Parity.None;
                serialPort_image.DataBits = 8;
                serialPort_image.StopBits = StopBits.One;
                serialPort_image.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btn_Connect.Enabled = true;
                btn_Disconnect.Enabled = false;
            }
            try
            {
                if (serialPort_tool.IsOpen)
                {
                    serialPort_tool.Write("|2.1" + '\r');
                    textBox_Tool_CurPosi.Text = "0";
                    CurPosition_Tool = 0;
                }
                if (serialPort_image.IsOpen)
                {
                    serialPort_image.Write("|2.1" + '\r');
                    textBox_Img_CurPosi.Text = "0";
                    CurPosition_Img = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        //Disconnect button 觸發事件
        //請參考Cool Muscle串列通訊
        private void btn_Disconnect_Click(object sender, EventArgs e)
        {
            btn_Connect.Enabled = true;
            btn_Disconnect.Enabled = false;
            try
            {
                serialPort_tool.Close();
                serialPort_image.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btn_Connect.Enabled = false;
                btn_Disconnect.Enabled = true;
            }
        }

        //步進送訊事件
        //請參考Cool Muscle串列通訊
        private void btn_sent_motor_Click(object sender, EventArgs e)
        {
            try
            {
                if (serialPort_tool.IsOpen)
                {
                    serialPort_tool.Write(textBox_serialport1.Text + '\r');
                    textBox_serialport1.Clear();
                }
                if (serialPort_image.IsOpen)
                {
                    serialPort_image.Write(textBox_serialport2.Text + '\r');
                    textBox_serialport2.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //NPOI 數值輸出路徑選擇
        private void btn_WearDepthOutput_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Title = "Select file";
            dialog.Filter = "xls files (*.*)|*.xls|xlsx files (*.*)|*.xlsx";
            dialog.ShowDialog();
            textBox_WearDepthOutput.Text = dialog.FileName;
        }
        #endregion

        #region -- image page --

        // 變數宣告
        string MoviePath;  //影片儲存路徑
        uint ImgCount;     //影像總數
        string imageName;  //影像名稱
        int step = 80000;  //目標步數 pulse  #這邊控制順逆轉
        int spe = 50;      //目標速度 K pulse per second
        int acc = 50;      //目標加速度 K pulse per second^2
        Mat toolimg = new Mat(2048, 1536, DepthType.Cv8U, 1); //刀具影像物件宣告

        //FPS設定觸發
        private void textBox_FPS_TextChanged(object sender, EventArgs e)
        {
            uint VLines = uint.Parse(textBox_FPS.Text);
            float FPS;
            StCam.SetVBlankForFPS(m_hCamera, VLines);
            StCam.GetOutputFPS(m_hCamera, out FPS);
            label_FPS.Text = "FPS:" + FPS.ToString();
            StCam.CameraSetting(m_hCamera, StCam.STCAM_CAMERA_SETTING_WRITE);
        }

        //曝光時間設定觸發
        private void textBox_EXTime_TextChanged(object sender, EventArgs e)
        {
            uint ExposureClock = uint.Parse(textBox_EXTime.Text);
            uint ExposureTime;
            StCam.SetExposureClock(m_hCamera, ExposureClock);
            StCam.GetExposureClock(m_hCamera, out ExposureTime);
            label_EXTime.Text = "Exposure Time :" + ExposureTime.ToString() + "us";
            StCam.CameraSetting(m_hCamera, StCam.STCAM_CAMERA_SETTING_WRITE);

        }

        //影片路徑選擇
        private void btn_FolderPath_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog FolderPath = new FolderBrowserDialog();
            if (FolderPath.ShowDialog() == DialogResult.OK)
            {
                textBox_folderPath.Text = FolderPath.SelectedPath;
            }
        }

        //量測開始觸發
        private void btn_MeasureStart_Click(object sender, EventArgs e)
        {
            btn_MeasureStart.Enabled = false;
            textBox1.Clear();

            //馬達送訊
            string K = "(.1 " + '\r' + "P.1=" + (TarPosition_Tool + step).ToString() + '\r' + "S.1=" + spe.ToString() + '\r' + "A.1=" + acc.ToString() + '\r' + "^.1" + '\r';
            serialPort_tool.Write(K);

            //相機開始錄影(勿動)
            uint frameNum = uint.Parse(textBox_TotalFrame.Text);
            bool bReval = true;
            uint nLastErrorNo = 0;
            StCam.SetAVIPriorityFileFormat(m_hCamera, StCam.STCAM_AVI_FILE_FORMAT_AVI2);
            MoviePath = textBox_folderPath.Text + "/" + textBox_MoveName.Text.ToString() + ".avi";
            int delay = int.Parse(textBox2.Text);
            if (textBox2.Text == null)
            {
                delay = 0;
            }
            Thread.Sleep(delay);
            bReval = StCam.SaveAVI(m_hCamera, MoviePath, StCam.STCAM_AVI_COMPRESSOR_UNCOMPRESSED, frameNum, IntPtr.Zero);
            if (!bReval)
            {
                nLastErrorNo = StCam.GetLastError(m_hCamera);
            }
            //Show Error Message
            if (!bReval)
            {
                // ShowErrorMsg(nLastErrorNo);
            }
        }

        //及時畫面觸發
        private void btn_Preview_Click(object sender, EventArgs e)
        {
            if (m_bStatusPreviewWnd && m_bStatusTransfer)
            {
                //Stop
                StCam.StopTransfer(m_hCamera);
                StCam.DestroyPreviewWindow(m_hCamera);
            }
            else
            {
                //Start
                // Mask設定
                StCam.SetPreviewMaskSize(m_hCamera, 0, 0, 2048, 1536);
                // 寬高比設定
                // StCam.SetPreviewWindowStyle(m_hCamera,);
                StCam.SetAspectMode(m_hCamera, 1);
                StCam.CreatePreviewWindow(m_hCamera, "Preview", StCam.WS_OVERLAPPEDWINDOW | StCam.WS_VISIBLE, 50, 280, 375, 500, System.IntPtr.Zero, System.IntPtr.Zero, true);
                StCam.StartTransfer(m_hCamera);
                StCam.GetPreviewWnd(m_hCamera, out m_hWnd);
                //SetWindowPos(m_hWnd, 0, 0, 2048, 1536, 0x4000);
            }
        }

        //擷取畫面觸發
        private void btn_Snap_Click(object sender, EventArgs e)
        {
            bool bReval = true;
            uint nLastErrorNo = 0;
            do
            {
                //Get Image Size
                uint dwSize;
                uint dwWidth;
                uint dwHeight;
                uint dwLinePitch;
                bReval = StCam.GetPreviewDataSize(m_hCamera, out dwSize, out dwWidth, out dwHeight, out dwLinePitch);
                if (!bReval)
                {
                    nLastErrorNo = StCam.GetLastError(m_hCamera);
                    break;
                }

                //Get Preview Pixel Format
                uint dwPreviewPixelFormat;
                bReval = StCam.GetPreviewPixelFormat(m_hCamera, out dwPreviewPixelFormat);
                if (!bReval)
                {
                    nLastErrorNo = StCam.GetLastError(m_hCamera);
                    break;
                }

                //Allocate Memory
                System.Drawing.Imaging.PixelFormat pixelFormat = System.Drawing.Imaging.PixelFormat.Format8bppIndexed;
                switch (dwPreviewPixelFormat)
                {
                    case (StCam.STCAM_PIXEL_FORMAT_24_BGR):
                        pixelFormat = System.Drawing.Imaging.PixelFormat.Format24bppRgb;
                        break;
                    case (StCam.STCAM_PIXEL_FORMAT_32_BGR):
                        pixelFormat = System.Drawing.Imaging.PixelFormat.Format32bppRgb;
                        break;
                }

                byte[] pbyteImageBuffer = new byte[dwSize];

                //Take Snap Shot
                uint dwNumberOfByteTrans;
                uint[] pdwFrameNo = new uint[1];
                uint dwMilliseconds = 100;
                System.Runtime.InteropServices.GCHandle gch = System.Runtime.InteropServices.GCHandle.Alloc(pbyteImageBuffer, System.Runtime.InteropServices.GCHandleType.Pinned);
                System.IntPtr ptr = gch.AddrOfPinnedObject();

                bReval = StCam.TakePreviewSnapShot(m_hCamera, ptr, dwSize, out dwNumberOfByteTrans, pdwFrameNo, dwMilliseconds);

                gch.Free();
                if (!bReval)
                {
                    nLastErrorNo = StCam.GetLastError(m_hCamera);
                    break;
                }

                if (m_FormSnapShot == null)
                {
                    m_FormSnapShot = new FormSnapShot();

                }
                m_FormSnapShot.bUpdateSnapShot((int)dwWidth, (int)dwHeight, pbyteImageBuffer, dwSize, pixelFormat);


                StCam.SaveImageW(m_hCamera, 2048, 1536, 0x00000001, ptr, "TIFF", 0);

                m_FormSnapShot.save_in_path(textBox_folderPath.Text, tempNum);
                tempNum++;
            } while (false);
            //Show Error Message
            if (!bReval)
            {
                // ShowErrorMsg(nLastErrorNo);
            }
        }

        //設為原點觸發
        private void btn_SetOrigin_Click(object sender, EventArgs e)
        {
            try
            {
                if (serialPort_tool.IsOpen)
                {
                    serialPort_tool.Write("|2.1" + '\r');
                    textBox_Tool_CurPosi.Text = "0";
                    CurPosition_Tool = 0;
                }
                if (serialPort_image.IsOpen)
                {
                    serialPort_image.Write("|2.1" + '\r');
                    textBox_Img_CurPosi.Text = "0";
                    CurPosition_Img = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //回歸原點觸發
        private void btn_MovetoOrigin_Click(object sender, EventArgs e)
        {
            try
            {
                if (serialPort_tool.IsOpen)
                {
                    serialPort_tool.Write("|1.1" + '\r');
                    textBox_Tool_CurPosi.Text = "0";
                    CurPosition_Tool = 0;
                }
                if (serialPort_image.IsOpen)
                {
                    serialPort_image.Write("|1.1" + '\r');
                    textBox_Img_CurPosi.Text = "0";
                    CurPosition_Img = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //馬達禁能觸發
        private void btn_MotorFree_Click(object sender, EventArgs e)
        {
            try
            {
                if (serialPort_tool.IsOpen)
                {
                    serialPort_tool.Write("|2.1" + '\r');
                    serialPort_tool.Write(").1" + '\r');
                    textBox_Tool_CurPosi.Text = "0";
                    CurPosition_Tool = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //馬達致能觸發
        private void btn_MotorEnable_Click(object sender, EventArgs e)
        {
            try
            {
                if (serialPort_tool.IsOpen)
                {
                    serialPort_tool.Write("|2.1" + '\r');
                    serialPort_tool.Write("(.1" + '\r');
                    textBox_Tool_CurPosi.Text = "0";
                    CurPosition_Tool = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //刀軸馬達移動
        private void btn_MoveTool_Click(object sender, EventArgs e)
        {
            if (radioButton_abs.Checked == true)
            {
                TarPosition_Tool = int.Parse(textBox_Tool_TarPosi.Text);
            }
            else
            {
                TarPosition_Tool = int.Parse(textBox_Tool_TarPosi.Text) + CurPosition_Tool;
            }
            TarSpeed_Tool = int.Parse(textBox_Tool_TarSpeed.Text);
            TarAcc_Tool = int.Parse(textBox_Tool_TarAcc.Text);

            try
            {
                if (serialPort_tool.IsOpen)
                {
                    serialPort_tool.Write("P.1=" + TarPosition_Tool.ToString() + '\r');
                    serialPort_tool.Write("S.1=" + TarSpeed_Tool.ToString() + '\r');
                    serialPort_tool.Write("A.1=" + TarAcc_Tool.ToString() + '\r');
                    serialPort_tool.Write("^.1" + '\r');
                    textBox_Tool_CurPosi.Text = TarPosition_Tool.ToString();
                    CurPosition_Tool = TarPosition_Tool;
                    TarPosition_Tool = 0;
                    TarAcc_Tool = 0;
                    TarSpeed_Tool = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //光軸馬達向上移動
        private void btn_MoveImgUP_Click(object sender, EventArgs e)
        {
            if (radioButton_abs.Checked == true)
            {
                TarPosition_Img = int.Parse(textBox_Img_TarPosi.Text);
            }
            else
            {
                TarPosition_Img = int.Parse(textBox_Img_TarPosi.Text) + CurPosition_Img;
            }
            TarSpeed_Img = int.Parse(textBox_Img_TarSpeed.Text);
            TarAcc_Img = int.Parse(textBox_Img_TarAcc.Text);

            try
            {
                if (serialPort_image.IsOpen)
                {
                    serialPort_image.Write("P.1=" + TarPosition_Img.ToString() + '\r');
                    serialPort_image.Write("S.1=" + TarSpeed_Img.ToString() + '\r');
                    serialPort_image.Write("A.1=" + TarAcc_Img.ToString() + '\r');
                    serialPort_image.Write("^.1" + '\r');
                    textBox_Img_CurPosi.Text = TarPosition_Img.ToString();
                    CurPosition_Img = TarPosition_Img;
                    TarPosition_Img = 0;
                    TarAcc_Img = 0;
                    TarSpeed_Img = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //光軸馬達向下移動
        private void btn_MoveImgDOWN_Click(object sender, EventArgs e)
        {
            if (radioButton_abs.Checked == true)
            {
                TarPosition_Img = -int.Parse(textBox_Img_TarPosi.Text);
            }
            else
            {
                TarPosition_Img = -int.Parse(textBox_Img_TarPosi.Text) + CurPosition_Img;
            }
            TarSpeed_Img = int.Parse(textBox_Img_TarSpeed.Text);
            TarAcc_Img = int.Parse(textBox_Img_TarAcc.Text);

            try
            {
                if (serialPort_image.IsOpen)
                {
                    serialPort_image.Write("P.1=" + TarPosition_Img.ToString() + '\r');
                    serialPort_image.Write("S.1=" + TarSpeed_Img.ToString() + '\r');
                    serialPort_image.Write("A.1=" + TarAcc_Img.ToString() + '\r');
                    serialPort_image.Write("^.1" + '\r');

                    textBox_Img_CurPosi.Text = TarPosition_Img.ToString();
                    CurPosition_Img = TarPosition_Img;
                    TarPosition_Img = 0;
                    TarAcc_Img = 0;
                    TarSpeed_Img = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_Move_Click(object sender, EventArgs e)
        {
            btn_MoveTool.PerformClick();
            btn_MoveImgUP.PerformClick();
        }

        //分析影像路徑設定
        private void btn_FrameFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Title = "Select file";
            dialog.ShowDialog();
            textBox_FrameFile.Text = dialog.FileName;
        }

        //影像分離觸發
        private void btn_sepFrame_Click_1(object sender, EventArgs e)
        {
            //按鈕狀態更新
            btn_sepFrame.Text = "分離中...";
            btn_sepFrame.Refresh();

            string SaveDir = textBox_seppath.Text + "\\Raw\\";
            if (Directory.Exists(SaveDir))
            {
            }
            else
            {
                Directory.CreateDirectory(@SaveDir);
            }
            
            toolvideo = new VideoCapture(textBox_FrameFile.Text);
            double count = toolvideo.GetCaptureProperty(Emgu.CV.CvEnum.CapProp.FrameCount);
            double fps = toolvideo.GetCaptureProperty(Emgu.CV.CvEnum.CapProp.Fps);
            textBox1.Text = fps.ToString() + "\r\n" + count.ToString();
            toolvideo.ImageGrabbed += Toolvideo_ImageGrabbed;
            ImgCount = 1;
            toolvideo.Start();
            btn_sepFrame.Text = "單張分離";
            btn_sepFrame.Refresh();


            //影像分離事件(觸發後執行此區直到影片結束)
        }

        //影像分離事件(觸發後執行此區直到影片結束)
        private void Toolvideo_ImageGrabbed(object sender, EventArgs e)
        {
            toolvideo.Retrieve(toolimg);
            imageName = textBox_seppath.Text + "\\Raw\\" + ImgCount.ToString() + ".tif";
            toolimg.Save(imageName);
            ImgCount++;
        }
        #endregion


        Double toolRadius = 12;
        Double systemResolution = 0.00084;  //這邊要改系統解析度 甚至創造兩個不同系統解析選項
        Double systemResolutionL = 0.00697;  //這邊要改系統解析度 甚至創造兩個不同系統解析選項 0407
        Double systemResolutionH = 0.00057;  //這邊要改系統解析度 甚至創造兩個不同系統解析選項
        #region -- image processing page --

        //選擇重建檔案路徑
        private void btn_LoadVideoPath_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog LoadPath = new FolderBrowserDialog();
            if (LoadPath.ShowDialog() == DialogResult.OK)
            {
                textBox_LoadVideoPath.Text = LoadPath.SelectedPath;
                //textBox_SaveImgPath.Text = textBox_LoadVideoPath.Text;
            }
        }
        //選擇分析檔案路徑
        private void btn_SaveImgPath_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog SavePath = new FolderBrowserDialog();
            if (SavePath.ShowDialog() == DialogResult.OK)
            {
                textBox_SaveImgPath.Text = SavePath.SelectedPath;
            }
        }
        //選擇歷程檔案路徑
        private void btn_FilePath_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog FilePath = new FolderBrowserDialog();
            if (FilePath.ShowDialog() == DialogResult.OK)
            {
                textBox_FilePath.Text = FilePath.SelectedPath;
            }
        }
        private void Toolvideo_ImageGrabbed2(object sender, EventArgs e)
        {
            toolvideo.Retrieve(toolimg);
            imageName = textBox_LoadVideoPath.Text + "\\Raw\\" + ImgCount.ToString() + ".tif";
            toolimg.Save(imageName);
            ImgCount++;
        }
        //開始重建
        private void btn_ReconStart_Click(object sender, EventArgs e)
        {
            if (textBox_LoadVideoPath.Text != String.Empty)
            {
                //計時器宣告+啟動
                Stopwatch stopWatch = new Stopwatch();
                stopWatch.Start();
                //按鈕狀態更新
                btn_ReconStart.Text = "正在重建...";
                btn_ReconStart.Refresh();

                //影像Raw分離+重建影像 0423
                if (checkBox_saveImage.Checked)
                {
                    // 影像的Raw檔案分離
                    btn_sepFrame.Text = "分離中..."; //按鈕狀態更新
                    btn_sepFrame.Refresh();

                    string SaveDir = textBox_LoadVideoPath.Text + "\\Raw\\"; //創建
                    if (Directory.Exists(SaveDir))
                    {
                    }
                    else
                    {
                        Directory.CreateDirectory(@SaveDir);
                    }

                    DirectoryInfo DiFolder_check1 = new DirectoryInfo(textBox_LoadVideoPath.Text + "\\Raw\\");
                    FileInfo[] files_check1 = DiFolder_check1.GetFiles("*.tif");

                    if (files_check1.Length != 1100)
                    {
                        toolvideo = new VideoCapture(textBox_videosel.Text);
                        double count = toolvideo.GetCaptureProperty(Emgu.CV.CvEnum.CapProp.FrameCount);
                        double fps = toolvideo.GetCaptureProperty(Emgu.CV.CvEnum.CapProp.Fps);
                        toolvideo.ImageGrabbed += Toolvideo_ImageGrabbed2;
                        ImgCount = 1;
                        toolvideo.Start();

                        btn_sepFrame.Text = "單張分離";
                        btn_sepFrame.Refresh();
                    }
                    else 
                    {
                        // 目錄下檔案個數
                        #region -- FileCount --
                        btn_ReconStart.Text = "正在重建...";
                        btn_ReconStart.Refresh();

                        DirectoryInfo DiFolder = new DirectoryInfo(textBox_LoadVideoPath.Text + "\\Raw\\");
                        FileInfo[] files = DiFolder.GetFiles("*.tif");
                        int width;
                        if (files.Length >= 1000)
                        {
                            width = 1000;
                        }
                        else
                        {
                            width = files.Length;
                        }
                        #endregion

                        //區域變數宣告
                        #region -- variable setting --
                        Image<Gray, byte> LoadImage = new Image<Gray, byte>(2048, 1536);
                        Image<Gray, byte> threshImage = new Image<Gray, byte>(2048, 1536);
                        //Image<Gray, byte> singleCol = new Image<Gray, byte>(2048, 1);

                        // Image<Gray, UInt16> temp = new Image<Gray, UInt16>(width, 2048);
                        Image<Gray, UInt16> tempL = new Image<Gray, UInt16>(width, 2048); //創造左右邊界暫存 0407
                        Image<Gray, UInt16> tempR = new Image<Gray, UInt16>(width, 2048);
                        // temp.SetValue(0);
                        tempL.SetValue(0);
                        tempR.SetValue(0);

                        // int[] downedge = new int[width];
                        int[] Ledgecount = new int[width]; // 每張圖陣列點的相對最高點(陣列min) 0407
                        int[] Redgecount = new int[width];

                        // int upedgeDistance = 1600;
                        int edgeDis = 1027; //這邊要思考一下可以取到多少是適合的 學長2048取1600 目前低倍率高度是1536該取多少 0407
                        int edgeerr = 26; // 這邊是去掉非觀測刃部分的數值 目前設計為26pixel 待驗證 0409

                        double[] minValues;
                        double[] maxValues;

                        Point[] minLocations;
                        Point[] maxLocations; //這邊不確定需不需要重設 0407


                        int ImageName;
                        #endregion

                        //重建迴圈
                        #region -- Reconstruction --
                        for (int fignum = 1; fignum <= width; fignum++)
                        {
                            ImageName = files.Length - 1000 + fignum;
                            LoadImage = new Image<Gray, byte>(textBox_LoadVideoPath.Text + "\\Raw\\" + ImageName.ToString() + ".tif");
                            CvInvoke.Threshold(LoadImage, threshImage, 0, 220, ThresholdType.Otsu);

                            for (int row = threshImage.Rows - 1; row >= 0; row--)     //下往上 
                            {
                                for (int column = 0; column < threshImage.Cols * 0.25; column++)   //左邊界0407   邊界待定義 threshImage.Cols*0.25
                                {
                                    if (threshImage.Data[row, column, 0] == 0)
                                    {
                                        tempL.Data[row, fignum - 1, 0] = (ushort)column;
                                        Ledgecount[fignum - 1] = row;
                                        break;
                                    }
                                }
                                for (int column = threshImage.Cols - 1; column >= threshImage.Cols * 0.75; column--)        //右邊界0407    邊界待定義 threshImage.Cols*0.75
                                {
                                    if (threshImage.Data[row, column, 0] == 0)
                                    {
                                        tempR.Data[row, fignum - 1, 0] = (ushort)column;
                                        Redgecount[fignum - 1] = row;
                                        break;
                                    }
                                }
                            }
                            LoadImage.Dispose();
                        }
                        threshImage.Dispose();
                        #endregion

                        //重建後Raw剪裁存檔
                        #region -- Raw-- 

                        //Raw剪裁存檔
                        // int upedge = downedge.Max() - upedgeDistance;
                        int Ledge = Ledgecount.Min();
                        int Redge = Redgecount.Min();

                        /*
                        Rectangle region = new Rectangle(0, upedge, temp.Cols, upedgeDistance);
                        Image<Gray, UInt16> profileRaw = new Image<Gray, UInt16>(region.Size);
                        profileRaw = temp.Copy(region);
                        profileRaw.Save(textBox_LoadVideoPath.Text + "\\" + "ReconRaw.Tif");  */

                        Rectangle Lregion = new Rectangle(0, Ledge, tempL.Cols, edgeDis); //創造左右region 0408 
                        Rectangle Rregion = new Rectangle(0, Redge, tempR.Cols, edgeDis); // 這邊多設定 Ledge/Redge+edgeerr 0409

                        Image<Gray, UInt16> LprofileRaw = new Image<Gray, UInt16>(Lregion.Size);
                        LprofileRaw = tempL.Copy(Lregion);
                        LprofileRaw.Save(textBox_LoadVideoPath.Text + "\\" + "LReconRaw.Tif"); // 分別將L/R region區域框起來存取 存成ReconRaw.tif型式

                        Image<Gray, UInt16> RprofileRaw = new Image<Gray, UInt16>(Rregion.Size);
                        RprofileRaw = tempR.Copy(Rregion);
                        RprofileRaw.Save(textBox_LoadVideoPath.Text + "\\" + "RReconRaw.Tif");

                        //NormalizeGray存檔

                        /*profileRaw.MinMax(out minValues, out maxValues, out minLocations, out maxLocations);
                        Image<Gray, Byte> profileNorm = new Image<Gray, Byte>(profileRaw.Size);
                        profileNorm = profileRaw.ConvertScale<Byte>((256 / (maxValues[0] - minValues[0])), minValues[0]);
                        profileNorm.Save(textBox_LoadVideoPath.Text + "\\" + "ReconNormalGray.Tif");*/
                        string SaveDirIP = textBox_LoadVideoPath.Text + "\\imgprocess\\";    //創造新的資料夾把非raw檔案存進去
                        if (Directory.Exists(SaveDirIP))
                        {
                        }
                        else
                        {
                            Directory.CreateDirectory(@SaveDirIP);
                        }

                        LprofileRaw.MinMax(out minValues, out maxValues, out minLocations, out maxLocations); //數據歸一化後存成NormalGray灰階.tif 0408
                        Image<Gray, Byte> LprofileNorm = new Image<Gray, Byte>(LprofileRaw.Size);
                        LprofileNorm = LprofileRaw.ConvertScale<Byte>((256 / (maxValues[0] - minValues[0])), minValues[0]);
                        LprofileNorm.Save(SaveDirIP + "\\" + "LReconNormalGray.Tif"); //存到新資料夾imgprocess 用SaveDirIP路徑 0409

                        RprofileRaw.MinMax(out minValues, out maxValues, out minLocations, out maxLocations);
                        Image<Gray, Byte> RprofileNorm = new Image<Gray, Byte>(RprofileRaw.Size);
                        RprofileNorm = RprofileRaw.ConvertScale<Byte>((256 / (maxValues[0] - minValues[0])), minValues[0]);
                        RprofileNorm.Save(SaveDirIP + "\\" + "RReconNormalGray.Tif");

                        //NormalizeJet存檔

                        /*CvInvoke.ApplyColorMap(profileNorm, profileNorm, ColorMapType.Jet);
                        profileNorm.Save(textBox_LoadVideoPath.Text + "\\" + "ReconNormalJet.Tif");*/

                        CvInvoke.ApplyColorMap(LprofileNorm, LprofileNorm, ColorMapType.Jet);
                        LprofileNorm.Save(SaveDirIP + "\\" + "LReconNormalJet.Tif"); //轉成Jet檔案 0408
                        CvInvoke.ApplyColorMap(RprofileNorm, RprofileNorm, ColorMapType.Jet);
                        RprofileNorm.Save(SaveDirIP + "\\" + "RReconNormalJet.Tif");
                        #endregion

                        //Projection剪裁存檔
                        #region -- Projection--

                        //resize
                        /*double Ladj = LprofileRaw.Cols * (toolRadius * Math.PI / LprofileRaw.Cols) / systemResolutionL; //resize兩邊分開做 0408
                        double Radj = RprofileRaw.Cols * (toolRadius * Math.PI / RprofileRaw.Cols) / systemResolutionL;
                        LprofileRaw = LprofileRaw.Resize((int)(Ladj), LprofileRaw.Rows, Inter.Cubic);
                        RprofileRaw = RprofileRaw.Resize((int)(Radj), RprofileRaw.Rows, Inter.Cubic);

                        //正射投影
                        Image<Gray, UInt16> LprofileRawPro = new Image<Gray, UInt16>(LprofileRaw.Size);  //進行正射0408
                        for (int row = 0; row < LprofileRawPro.Rows; row++)
                        {
                            for (int column = 0; column < LprofileRawPro.Cols; column++)
                            {
                                LprofileRawPro.Data[row, column, 0] = LprofileRaw.Data[row, ((column + row) % LprofileRawPro.Cols), 0];
                            }
                        }
                        Image<Gray, UInt16> RprofileRawPro = new Image<Gray, UInt16>(RprofileRaw.Size);
                        for (int row = 0; row < RprofileRawPro.Rows; row++)
                        {
                            for (int column = 0; column < RprofileRawPro.Cols; column++)
                            {
                                RprofileRawPro.Data[row, column, 0] = RprofileRaw.Data[row, ((column + row) % RprofileRawPro.Cols), 0];
                            }
                        }

                        //正射投影後resize
                        LprofileRawPro = LprofileRawPro.Resize(1000, LprofileRawPro.Rows, Inter.Cubic);
                        LprofileRawPro.Save(textBox_LoadVideoPath.Text + "\\" + "LReconRawPro.Tif");
                        RprofileRawPro = RprofileRawPro.Resize(1000, RprofileRawPro.Rows, Inter.Cubic);
                        RprofileRawPro.Save(textBox_LoadVideoPath.Text + "\\" + "RReconRawPro.Tif");

                        //正射後NormalizeGray存檔
                        LprofileRawPro.MinMax(out minValues, out maxValues, out minLocations, out maxLocations);
                        Image<Gray, Byte> LprofileNormPro = new Image<Gray, Byte>(LprofileRawPro.Size);
                        LprofileNormPro = LprofileRawPro.ConvertScale<Byte>((256 / (maxValues[0] - minValues[0])), minValues[0]);
                        LprofileNormPro.Save(textBox_LoadVideoPath.Text + "\\" + "LReconNormalProGray.Tif");
                        RprofileRawPro.MinMax(out minValues, out maxValues, out minLocations, out maxLocations);
                        Image<Gray, Byte> RprofileNormPro = new Image<Gray, Byte>(RprofileRawPro.Size);
                        RprofileNormPro = RprofileRawPro.ConvertScale<Byte>((256 / (maxValues[0] - minValues[0])), minValues[0]);
                        RprofileNormPro.Save(textBox_LoadVideoPath.Text + "\\" + "RReconNormalProGray.Tif");

                        //正射後NormalizeJet存檔
                        CvInvoke.ApplyColorMap(LprofileNormPro, LprofileNormPro, ColorMapType.Jet);
                        LprofileNormPro.Save(textBox_LoadVideoPath.Text + "\\" + "LReconNormalProJet.Tif"); 
                        CvInvoke.ApplyColorMap(RprofileNormPro, RprofileNormPro, ColorMapType.Jet);
                        RprofileNormPro.Save(textBox_LoadVideoPath.Text + "\\" + "RReconNormalProJet.Tif");*/
                        #endregion

                        //IamgeBox顯示
                        #region -- Imagebox--
                        imgBox_LToolReconMap.Image = LprofileNorm;  //顯示兩個視窗重建正射照片 0409
                        imgBox_RToolReconMap.Image = RprofileNorm;
                        #endregion


                    }


                }
                // 重建影像但不儲存讀寫路徑  0415
                else if (checkBox_notsave.Checked)// 尚未寫完0415
                {

                }
                //不勾選--> 讀取Raw資料夾影像進行影像處理 0415
                else  
                {
                    // 目錄下檔案個數
                    #region -- FileCount --
                    DirectoryInfo DiFolder = new DirectoryInfo(textBox_LoadVideoPath.Text + "\\Raw\\");
                    FileInfo[] files = DiFolder.GetFiles("*.tif");
                    int width;
                    if (files.Length >= 1000)
                    {
                        width = 1000;
                    }
                    else
                    {
                        width = files.Length;
                    }
                    #endregion

                    //區域變數宣告
                    #region -- variable setting --
                    Image<Gray, byte> LoadImage = new Image<Gray, byte>(2048, 1536);
                    Image<Gray, byte> threshImage = new Image<Gray, byte>(2048, 1536);
                    //Image<Gray, byte> singleCol = new Image<Gray, byte>(2048, 1);

                    // Image<Gray, UInt16> temp = new Image<Gray, UInt16>(width, 2048);
                    Image<Gray, UInt16> tempL = new Image<Gray, UInt16>(width, 2048); //創造左右邊界暫存 0407
                    Image<Gray, UInt16> tempR = new Image<Gray, UInt16>(width, 2048);
                    // temp.SetValue(0);
                    tempL.SetValue(0);
                    tempR.SetValue(0);

                    // int[] downedge = new int[width];
                    int[] Ledgecount = new int[width]; // 每張圖陣列點的相對最高點(陣列min) 0407
                    int[] Redgecount = new int[width];

                    // int upedgeDistance = 1600;
                    int edgeDis = 1027; //這邊要思考一下可以取到多少是適合的 學長2048取1600 目前低倍率高度是1536該取多少 0407
                    int edgeerr = 26; // 這邊是去掉非觀測刃部分的數值 目前設計為26pixel 待驗證 0409

                    double[] minValues;
                    double[] maxValues;

                    Point[] minLocations;
                    Point[] maxLocations; //這邊不確定需不需要重設 0407
                    Rectangle singleLine;

                    int ImageName;
                    #endregion

                    //重建迴圈
                    #region -- Reconstruction --
                    for (int fignum = 1; fignum <= width; fignum++)
                    {
                        ImageName = files.Length - 1000 + fignum;
                        LoadImage = new Image<Gray, byte>(textBox_LoadVideoPath.Text + "\\Raw\\" + ImageName.ToString() + ".tif");
                        CvInvoke.Threshold(LoadImage, threshImage, 0, 220, ThresholdType.Otsu);

                        for (int row = threshImage.Rows - 1; row >= 0; row--)     //下往上 
                        {
                            for (int column = 0; column < threshImage.Cols * 0.25; column++)   //左邊界0407   邊界待定義 threshImage.Cols*0.25
                            {
                                if (threshImage.Data[row, column, 0] == 0)
                                {
                                    tempL.Data[row, fignum - 1, 0] = (ushort)column;
                                    Ledgecount[fignum - 1] = row;
                                    break;
                                }
                            }
                            for (int column = threshImage.Cols - 1; column >= threshImage.Cols * 0.75; column--)        //右邊界0407    邊界待定義 threshImage.Cols*0.75
                            {
                                if (threshImage.Data[row, column, 0] == 0)
                                {
                                    tempR.Data[row, fignum - 1, 0] = (ushort)column;
                                    Redgecount[fignum - 1] = row;
                                    break;
                                }
                            }
                        }
                        LoadImage.Dispose();
                    }
                    threshImage.Dispose();
                    #endregion

                    //重建後Raw剪裁存檔
                    #region -- Raw-- 

                    //Raw剪裁存檔
                    // int upedge = downedge.Max() - upedgeDistance;
                    int Ledge = Ledgecount.Min();
                    int Redge = Redgecount.Min();

                    /*
                    Rectangle region = new Rectangle(0, upedge, temp.Cols, upedgeDistance);
                    Image<Gray, UInt16> profileRaw = new Image<Gray, UInt16>(region.Size);
                    profileRaw = temp.Copy(region);
                    profileRaw.Save(textBox_LoadVideoPath.Text + "\\" + "ReconRaw.Tif");  */

                    Rectangle Lregion = new Rectangle(0, Ledge, tempL.Cols, edgeDis); //創造左右region 0408 
                    Rectangle Rregion = new Rectangle(0, Redge, tempR.Cols, edgeDis); // 這邊多設定 Ledge/Redge+edgeerr 0409

                    Image<Gray, UInt16> LprofileRaw = new Image<Gray, UInt16>(Lregion.Size);
                    LprofileRaw = tempL.Copy(Lregion);
                    LprofileRaw.Save(textBox_LoadVideoPath.Text + "\\" + "LReconRaw.Tif"); // 分別將L/R region區域框起來存取 存成ReconRaw.tif型式

                    Image<Gray, UInt16> RprofileRaw = new Image<Gray, UInt16>(Rregion.Size);
                    RprofileRaw = tempR.Copy(Rregion);
                    RprofileRaw.Save(textBox_LoadVideoPath.Text + "\\" + "RReconRaw.Tif");

                    //NormalizeGray存檔

                    /*profileRaw.MinMax(out minValues, out maxValues, out minLocations, out maxLocations);
                    Image<Gray, Byte> profileNorm = new Image<Gray, Byte>(profileRaw.Size);
                    profileNorm = profileRaw.ConvertScale<Byte>((256 / (maxValues[0] - minValues[0])), minValues[0]);
                    profileNorm.Save(textBox_LoadVideoPath.Text + "\\" + "ReconNormalGray.Tif");*/
                    string SaveDirIP = textBox_LoadVideoPath.Text + "\\imgprocess\\";    //創造新的資料夾把非raw檔案存進去
                    if (Directory.Exists(SaveDirIP))
                    {
                    }
                    else
                    {
                        Directory.CreateDirectory(@SaveDirIP);
                    }

                    LprofileRaw.MinMax(out minValues, out maxValues, out minLocations, out maxLocations); //數據歸一化後存成NormalGray灰階.tif 0408
                    Image<Gray, Byte> LprofileNorm = new Image<Gray, Byte>(LprofileRaw.Size);
                    LprofileNorm = LprofileRaw.ConvertScale<Byte>((256 / (maxValues[0] - minValues[0])), minValues[0]);
                    LprofileNorm.Save(SaveDirIP + "\\" + "LReconNormalGray.Tif"); //存到新資料夾imgprocess 用SaveDirIP路徑 0409

                    RprofileRaw.MinMax(out minValues, out maxValues, out minLocations, out maxLocations);
                    Image<Gray, Byte> RprofileNorm = new Image<Gray, Byte>(RprofileRaw.Size);
                    RprofileNorm = RprofileRaw.ConvertScale<Byte>((256 / (maxValues[0] - minValues[0])), minValues[0]);
                    RprofileNorm.Save(SaveDirIP + "\\" + "RReconNormalGray.Tif");

                    //NormalizeJet存檔

                    /*CvInvoke.ApplyColorMap(profileNorm, profileNorm, ColorMapType.Jet);
                    profileNorm.Save(textBox_LoadVideoPath.Text + "\\" + "ReconNormalJet.Tif");*/

                    CvInvoke.ApplyColorMap(LprofileNorm, LprofileNorm, ColorMapType.Jet);
                    LprofileNorm.Save(SaveDirIP + "\\" + "LReconNormalJet.Tif"); //轉成Jet檔案 0408
                    CvInvoke.ApplyColorMap(RprofileNorm, RprofileNorm, ColorMapType.Jet);
                    RprofileNorm.Save(SaveDirIP + "\\" + "RReconNormalJet.Tif");
                    #endregion

                    //Projection剪裁存檔
                    #region -- Projection--

                    //resize
                    double Ladj = LprofileRaw.Cols * (toolRadius * Math.PI / LprofileRaw.Cols) / systemResolutionL; //resize兩邊分開做 0408
                    double Radj = RprofileRaw.Cols * (toolRadius * Math.PI / RprofileRaw.Cols) / systemResolutionL;
                    LprofileRaw = LprofileRaw.Resize((int)(Ladj), LprofileRaw.Rows, Inter.Cubic);
                    RprofileRaw = RprofileRaw.Resize((int)(Radj), RprofileRaw.Rows, Inter.Cubic);

                    //正射投影
                    Image<Gray, UInt16> LprofileRawPro = new Image<Gray, UInt16>(LprofileRaw.Size);  //進行正射0408
                    for (int row = 0; row < LprofileRawPro.Rows; row++)
                    {
                        for (int column = 0; column < LprofileRawPro.Cols; column++)
                        {
                            LprofileRawPro.Data[row, column, 0] = LprofileRaw.Data[row, ((column + row) % LprofileRawPro.Cols), 0];
                        }
                    }
                    Image<Gray, UInt16> RprofileRawPro = new Image<Gray, UInt16>(RprofileRaw.Size);
                    for (int row = 0; row < RprofileRawPro.Rows; row++)
                    {
                        for (int column = 0; column < RprofileRawPro.Cols; column++)
                        {
                            RprofileRawPro.Data[row, column, 0] = RprofileRaw.Data[row, ((column + row) % RprofileRawPro.Cols), 0];
                        }
                    }

                    //正射投影後resize
                    LprofileRawPro = LprofileRawPro.Resize(1000, LprofileRawPro.Rows, Inter.Cubic);
                    LprofileRawPro.Save(SaveDirIP + "\\"+ "LReconRawPro.Tif");
                    RprofileRawPro = RprofileRawPro.Resize(1000, RprofileRawPro.Rows, Inter.Cubic);
                    RprofileRawPro.Save(SaveDirIP + "\\" + "RReconRawPro.Tif");

                    //正射後NormalizeGray存檔
                    LprofileRawPro.MinMax(out minValues, out maxValues, out minLocations, out maxLocations);
                    Image<Gray, Byte> LprofileNormPro = new Image<Gray, Byte>(LprofileRawPro.Size);
                    LprofileNormPro = LprofileRawPro.ConvertScale<Byte>((256 / (maxValues[0] - minValues[0])), minValues[0]);
                    LprofileNormPro.Save(SaveDirIP + "\\" + "LReconNormalProGray.Tif");
                    RprofileRawPro.MinMax(out minValues, out maxValues, out minLocations, out maxLocations);
                    Image<Gray, Byte> RprofileNormPro = new Image<Gray, Byte>(RprofileRawPro.Size);
                    RprofileNormPro = RprofileRawPro.ConvertScale<Byte>((256 / (maxValues[0] - minValues[0])), minValues[0]);
                    RprofileNormPro.Save(SaveDirIP + "\\" + "RReconNormalProGray.Tif");

                    //正射後NormalizeJet存檔
                    CvInvoke.ApplyColorMap(LprofileNormPro, LprofileNormPro, ColorMapType.Jet);
                    LprofileNormPro.Save(SaveDirIP + "\\" +  "LReconNormalProJet.Tif"); 
                    CvInvoke.ApplyColorMap(RprofileNormPro, RprofileNormPro, ColorMapType.Jet);
                    RprofileNormPro.Save(SaveDirIP + "\\"  + "RReconNormalProJet.Tif");
                    #endregion

                    //IamgeBox顯示
                    #region -- Imagebox--
                    imgBox_LToolReconMap.Image = LprofileNorm;  //顯示兩個視窗重建正射照片 0409
                    imgBox_RToolReconMap.Image = RprofileNorm;
                    #endregion
                }

                //計時器暫停+顯示
                stopWatch.Stop();
                TimeSpan ts1 = stopWatch.Elapsed;
                label_ms.Text = "毫秒:" + ts1.Milliseconds.ToString();
                label_s.Text = "秒:" + ts1.Seconds.ToString();
                label_min.Text = "分:" + ts1.Minutes.ToString();
                stopWatch.Reset();


                //按鈕狀態更新
                btn_ReconStart.Text = "重建 Reconstrust";
                btn_ReconStart.Refresh();
                
            }
        }

        //開始磨耗分析
        private void btn_WearAnaStart_Click(object sender, EventArgs e)
        {
            //計時器宣告+啟動
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            //按鈕狀態更新
            btn_WearAnaStart.Text = "正在分析...";
            btn_WearAnaStart.Refresh();
            /*
            for (int flute = 1; flute <= 4; flute++)
            {
                VB[flute - 1] = new Image<Bgr, byte>(textBox_SaveImgPath.Text + "//F" + flute.ToString() + "-1.bmp").Rotate(90, new Bgr(0, 0, 0), false);
                CH[flute - 1] = new Image<Bgr, byte>(textBox_SaveImgPath.Text + "//F" + flute.ToString() + "-2.bmp").Rotate(90, new Bgr(0, 0, 0), false);
            }

            imageBox_VB_F1.Image = VB[0];
            imageBox_VB_F2.Image = VB[1];
            imageBox_VB_F3.Image = VB[2];
            imageBox_VB_F4.Image = VB[3];

            imageBox_CH_F1.Image = CH[0];
            imageBox_CH_F2.Image = CH[1];
            imageBox_CH_F3.Image = CH[2];
            imageBox_CH_F4.Image = CH[3];*/

            //textBox3.Text = textBox3.Text +"\r\n"+ error[0,0].ToString();
            //textBox3.Refresh();

            //其他路徑宣告
            String NNNpath = "C:\\Users\\User\\Desktop\\N\\N";   //十把新刀路徑
            string SaveDirIPC = textBox_SaveImgPath.Text + "\\imgprocess\\";    //路徑IP_Compare 0410

            string[] sArray = textBox_SaveImgPath.Text.Split('\\');
            string ToolName = sArray[sArray.Length - 1];
            /*
            for (int i = 0; i <= sArray.Length-1; i++)
            {
                textBox3.Text = textBox3.Text + "\r\n" + sArray[i].ToString();
            }*/


            //顯示磨耗刀具圖 
            string LfileName = SaveDirIPC + "\\" +"LReconNormalJet.Tif"; //textBox_LoadVideoPath.Text + "\\imgprocess\\"
            string RfileName = SaveDirIPC + "\\" + "RReconNormalJet.Tif"; //寫成無論選擇哪個檔案都會出現相對應暫存LL/RR以及顯示 0408
            if (System.IO.File.Exists(LfileName))
            {
                Image<Bgr, Byte> tempLL = new Image<Bgr, Byte>(SaveDirIPC + "\\" + "LReconNormalJet.Tif");
                imgBox_LToolReconMap.Image = tempLL;
                imgBox_LToolReconMap.Refresh();
                Image<Bgr, Byte> tempRR = new Image<Bgr, Byte>(SaveDirIPC + "\\" + "RReconNormalJet.Tif");
                imgBox_RToolReconMap.Image = tempRR;
                imgBox_RToolReconMap.Refresh();
            }
            if (System.IO.File.Exists(RfileName))
            {
                Image<Bgr, Byte> tempLL = new Image<Bgr, Byte>(SaveDirIPC + "\\" + "LReconNormalJet.Tif");
                imgBox_LToolReconMap.Image = tempLL;
                imgBox_LToolReconMap.Refresh();
                Image<Bgr, Byte> tempRR = new Image<Bgr, Byte>(SaveDirIPC + "\\" + "RReconNormalJet.Tif");
                imgBox_RToolReconMap.Image = tempRR;
                imgBox_RToolReconMap.Refresh();
            }

            //顯示磨耗深度圖
            LfileName = SaveDirIPC + "\\" + "LWearDepthJet.Tif";
            RfileName = SaveDirIPC + "\\" + "RWearDepthJet.Tif"; //可以改寫成case 0408 最後一個else部分需再改


            /*if (System.IO.File.Exists(LfileName))
            {
                Image<Bgr, Byte> tempLL = new Image<Bgr, Byte>(LfileName);
                imgBox_LWearDepthMap.Image = tempLL;
                imgBox_LWearDepthMap.Refresh();
                Image<Bgr, Byte> tempRR = new Image<Bgr, Byte>(RfileName);
                imgBox_RWearDepthMap.Image = tempRR;   //這邊顯示深度圖右邊區塊
                imgBox_RWearDepthMap.Refresh();
            }
            else if (System.IO.File.Exists(RfileName)) //
            {
                Image<Bgr, Byte> tempRR = new Image<Bgr, Byte>(RfileName);
                imgBox_RWearDepthMap.Image = tempRR;  //這邊顯示深度圖右邊區塊
                imgBox_RWearDepthMap.Refresh();
                Image<Bgr, Byte> tempLL = new Image<Bgr, Byte>(LfileName);
                imgBox_LWearDepthMap.Image = tempLL;
                imgBox_LWearDepthMap.Refresh();
            }*/          
            /*else
            {*/      //這邊框起來 假設要弄掉下邊的}也樣更著改回
                //變數宣告
                #region -- variable setting --

                //載入原圖
                Image<Gray, UInt16> LTool = new Image<Gray, UInt16>(textBox_SaveImgPath.Text + "\\" + "LReconRaw.Tif");
                Image<Gray, UInt16> RTool = new Image<Gray, UInt16>(textBox_SaveImgPath.Text + "\\" + "RReconRaw.Tif");
                //宣告多維Image
                Image<Gray, UInt16>[] LNewTool = new Image<Gray, UInt16>[10];
                Image<Gray, UInt16>[] RNewTool = new Image<Gray, UInt16>[10];

                Image<Gray, double> errorL = new Image<Gray, double>(LTool.Cols, 1);
                Image<Gray, double> minerrorL = new Image<Gray, double>(10, 1);
                Image<Gray, double> minposiL = new Image<Gray, double>(10, 1);
                Image<Gray, double> errorR = new Image<Gray, double>(RTool.Cols, 1);
                Image<Gray, double> minerrorR = new Image<Gray, double>(10, 1);
                Image<Gray, double> minposiR = new Image<Gray, double>(10, 1);

                //宣告平移計算變數
                Image<Gray, UInt16> NewToolshiftL = new Image<Gray, UInt16>(LTool.Size);
                Image<Gray, UInt16> errormapL = new Image<Gray, UInt16>(LTool.Size);
                Image<Gray, UInt16> TempLA, TempLB;
                Rectangle ROILA, ROILB;
                ROILA = new Rectangle(0, 0, LTool.Cols - 1, LTool.Rows);
                ROILB = new Rectangle(LTool.Cols - 2, 0, 1, LTool.Rows);
                TempLA = new Image<Gray, UInt16>(ROILA.Size);
                TempLB = new Image<Gray, UInt16>(ROILB.Size);
                double[] minValuesL, maxValuesL;
                Point[] minLocationsL, maxLocationsL;

                Image<Gray, UInt16> NewToolshiftR = new Image<Gray, UInt16>(RTool.Size);
                Image<Gray, UInt16> errormapR = new Image<Gray, UInt16>(RTool.Size);
                Image<Gray, UInt16> TempRA, TempRB;
                Rectangle ROIRA, ROIRB;
                ROIRA = new Rectangle(0, 0, RTool.Cols - 1, RTool.Rows);
                ROIRB = new Rectangle(RTool.Cols - 2, 0, 1, RTool.Rows);
                TempRA = new Image<Gray, UInt16>(ROIRA.Size);
                TempRB = new Image<Gray, UInt16>(ROIRB.Size);
                double[] minValuesR, maxValuesR;
                Point[] minLocationsR, maxLocationsR;

                #endregion

                //歷程追蹤比較
                string SaveDirIPCC = textBox_SaveImgPath.Text + "\\check\\";    //創造新的資料夾把最終比較檔案存進去
                if (Directory.Exists(SaveDirIPCC))
                {
                }
                else
                {
                    Directory.CreateDirectory(@SaveDirIPCC);
                }


                if (textBox_FilePath.Text.Trim() == String.Empty)
                {
                    for (int toolNum = 0; toolNum < 10; toolNum++)  //改一下0410
                    {
                        //載入並複製
                        LNewTool[toolNum] = new Image<Gray, UInt16>(NNNpath + (toolNum+1).ToString() + "\\LReconRaw.Tif"); //這邊的路徑NNNpath可能需要改 0410
                        NewToolshiftL = LNewTool[toolNum].Copy();
                        RNewTool[toolNum] = new Image<Gray, UInt16>(NNNpath + (toolNum+1).ToString() + "\\RReconRaw.Tif"); 
                        NewToolshiftR = RNewTool[toolNum].Copy();

                        //計算差值
                        errormapL = LTool.AbsDiff(NewToolshiftL);
                        errorL[0, 0] = errormapL.GetAverage();
                        errormapR = RTool.AbsDiff(NewToolshiftR);
                        errorR[0, 0] = errormapR.GetAverage();

                        //平移並計算差值
                        for (UInt16 shiftL = 1; shiftL < LTool.Cols; shiftL++)
                        {
                            TempLA = NewToolshiftL.Copy(ROILA);
                            TempLB = NewToolshiftL.Copy(ROILB);
                            NewToolshiftL.Dispose();

                            NewToolshiftL = TempLB.ConcateHorizontal(TempLA);
                            TempLA.Dispose();
                            TempLB.Dispose();
                            
                            errormapL = LTool.AbsDiff(NewToolshiftL);
                            errorL[0, shiftL] = errormapL.GetAverage();
                            errormapL.Dispose();
                        }
                        for (UInt16 shiftR = 1; shiftR < RTool.Cols; shiftR++)
                        {
                            TempRA = NewToolshiftR.Copy(ROIRA);
                            TempRB = NewToolshiftR.Copy(ROIRB);
                            NewToolshiftR.Dispose();

                            NewToolshiftR = TempRB.ConcateHorizontal(TempRA);
                            TempRA.Dispose();
                            TempRB.Dispose();

                            errormapR = RTool.AbsDiff(NewToolshiftR);
                            errorR[0, shiftR] = errormapR.GetAverage();
                            errormapR.Dispose();
                        }

                        //釋放記憶體
                        NewToolshiftR.Dispose();
                        RNewTool[toolNum].Dispose();
                        NewToolshiftL.Dispose();
                        LNewTool[toolNum].Dispose();

                        //計算磨耗最小值
                        errorL.MinMax(out minValuesL, out maxValuesL, out minLocationsL, out maxLocationsL);
                        minerrorL.Data[0, toolNum, 0] = minValuesL[0];
                        minposiL.Data[0, toolNum, 0] = minLocationsL[0].X;
                        errorR.MinMax(out minValuesR, out maxValuesR, out minLocationsR, out maxLocationsR);
                        minerrorR.Data[0, toolNum, 0] = minValuesR[0];
                        minposiR.Data[0, toolNum, 0] = minLocationsR[0].X;
                    }
                    errorL.Dispose();
                    errorR.Dispose();

                    minerrorL.MinMax(out minValuesL, out maxValuesL, out minLocationsL, out maxLocationsL);
                    LNewTool[0] = new Image<Gray, UInt16>(NNNpath + (minLocationsL[0].X + 1).ToString() + "\\LReconRaw.Tif"); //改0410
                    minerrorR.MinMax(out minValuesR, out maxValuesR, out minLocationsR, out maxLocationsR);
                    RNewTool[0] = new Image<Gray, UInt16>(NNNpath + (minLocationsR[0].X + 1).ToString() + "\\RReconRaw.Tif");

                    UInt16 shiftL2 = (ushort)minposiL.Data[0, minLocationsL[0].X, 0];
                    ROILA = new Rectangle(0, 0, LTool.Cols - shiftL2, LTool.Rows);
                    ROILB = new Rectangle(LTool.Cols - shiftL2 - 1, 0, shiftL2, LTool.Rows);

                    if (ROILB.Width == 0)      //家兩個判斷式子除錯 以防止例外情形 0410
                    {
                        TempLA = new Image<Gray, UInt16>(ROILA.Size);
                        TempLA = LNewTool[0].Copy(ROILA);
                        NewToolshiftL = TempLA.Copy();
                    }
                    else
                    {
                        TempLA = new Image<Gray, UInt16>(ROILA.Size);
                        TempLB = new Image<Gray, UInt16>(ROILB.Size);

                        TempLA = LNewTool[0].Copy(ROILA);
                        TempLB = LNewTool[0].Copy(ROILB);

                        NewToolshiftL = TempLB.ConcateHorizontal(TempLA);
                    }

                    UInt16 shiftR2 = (ushort)minposiR.Data[0, minLocationsR[0].X, 0];
                    ROIRA = new Rectangle(0, 0, RTool.Cols - shiftR2, RTool.Rows);
                    ROIRB = new Rectangle(RTool.Cols - shiftR2 - 1, 0, shiftR2, RTool.Rows);
                    //創造txt 紀錄歷程
                    using (StreamWriter sw = new StreamWriter(textBox_SaveImgPath.Text + "\\" + "Imgfiles.TXT"))
                    {
                        sw.WriteLine("歷程使用比較新刀編號:");
                        sw.WriteLine("L:" + (NNNpath + (minLocationsL[0].X + 1)).ToString());
                        sw.WriteLine("R:" + (NNNpath + (minLocationsR[0].X + 1)).ToString());
                        sw.WriteLine("--------------------");
                        sw.WriteLine("Lshiftp:" + shiftL2);
                        sw.WriteLine("Rshiftp:" + shiftR2);
                        sw.WriteLine("--------------------");
                        sw.WriteLine(DateTime.Now);
                        sw.WriteLine("--------------------");
                        sw.WriteLine("Final Editor : PC.C");
                    }
                    //
                    if (ROILB.Width == 0)
                    {
                        TempRA = new Image<Gray, UInt16>(ROIRA.Size);
                        TempRA = RNewTool[0].Copy(ROIRA);
                        NewToolshiftR = TempRA.Copy();
                    }
                    else
                    {
                        TempRA = new Image<Gray, UInt16>(ROIRA.Size);
                        TempRB = new Image<Gray, UInt16>(ROIRB.Size);

                        TempRA = RNewTool[0].Copy(ROIRA);
                        TempRB = RNewTool[0].Copy(ROIRB);

                        NewToolshiftR = TempRB.ConcateHorizontal(TempRA);
                    }

                }
                else
                {
                    //載入並複製
                    LNewTool[1] = new Image<Gray, UInt16>(textBox_FilePath.Text + "\\LReconRaw.Tif");
                    NewToolshiftL = LNewTool[1].Copy();
                    RNewTool[1] = new Image<Gray, UInt16>(textBox_FilePath.Text + "\\RReconRaw.Tif");
                    NewToolshiftR = RNewTool[1].Copy();

                    //計算差值
                    errormapL = LTool.AbsDiff(NewToolshiftL);
                    errorL[0, 0] = errormapL.GetAverage();
                    errormapR = RTool.AbsDiff(NewToolshiftR);
                    errorR[0, 0] = errormapR.GetAverage();

                    //平移並計算差值
                    for (UInt16 shiftL = 1; shiftL < LTool.Cols; shiftL++)
                    {
                        TempLA = NewToolshiftL.Copy(ROILA);
                        TempLB = NewToolshiftL.Copy(ROILB);
                        NewToolshiftL.Dispose();

                        NewToolshiftL = TempLB.ConcateHorizontal(TempLA);
                        TempLA.Dispose();
                        TempLB.Dispose();

                        errormapL = LTool.AbsDiff(NewToolshiftL);
                        errorL[0, shiftL] = errormapL.GetAverage();
                        errormapL.Dispose();
                    }
                    for (UInt16 shiftR = 1; shiftR < RTool.Cols; shiftR++)
                    {
                        TempRA = NewToolshiftR.Copy(ROIRA);
                        TempRB = NewToolshiftR.Copy(ROIRB);
                        NewToolshiftR.Dispose();

                        NewToolshiftR = TempRB.ConcateHorizontal(TempRA);
                        TempRA.Dispose();
                        TempRB.Dispose();

                        errormapR = RTool.AbsDiff(NewToolshiftR);
                        errorR[0, shiftR] = errormapR.GetAverage();
                        errormapR.Dispose();
                    }

                    //釋放記憶體
                    NewToolshiftR.Dispose();
                    RNewTool[1].Dispose();
                    NewToolshiftL.Dispose();
                    LNewTool[1].Dispose();

                    //計算磨耗最小值
                    errorL.MinMax(out minValuesL, out maxValuesL, out minLocationsL, out maxLocationsL);
                    minerrorL.Data[0, 0, 0] = minValuesL[0];
                    minposiL.Data[0, 0, 0] = minLocationsL[0].X;

                    LNewTool[0] = new Image<Gray, UInt16>(textBox_FilePath.Text + "\\LReconRaw.Tif");

                    UInt16 shiftL2 = (ushort)minposiL.Data[0, 0, 0];
                    ROILA = new Rectangle(0, 0, LTool.Cols - shiftL2, LTool.Rows);
                    ROILB = new Rectangle(LTool.Cols - shiftL2 - 1, 0, shiftL2, LTool.Rows);

                    TempLA = new Image<Gray, UInt16>(ROILA.Size);
                    TempLB = new Image<Gray, UInt16>(ROILB.Size);

                    TempLA = LNewTool[0].Copy(ROILA);
                    TempLB = LNewTool[0].Copy(ROILB);

                    NewToolshiftL = TempLB.ConcateHorizontal(TempLA);

                    errorR.MinMax(out minValuesR, out maxValuesR, out minLocationsR, out maxLocationsR);
                    minerrorR.Data[0, 0, 0] = minValuesR[0];
                    minposiR.Data[0, 0, 0] = minLocationsR[0].X;

                    RNewTool[0] = new Image<Gray, UInt16>(textBox_FilePath.Text + "\\RReconRaw.Tif");

                    UInt16 shiftR2 = (ushort)minposiR.Data[0, 0, 0];
                    ROIRA = new Rectangle(0, 0, RTool.Cols - shiftR2, RTool.Rows);
                    ROIRB = new Rectangle(RTool.Cols - shiftR2 - 1, 0, shiftR2, RTool.Rows);

                    TempRA = new Image<Gray, UInt16>(ROIRA.Size);
                    TempRB = new Image<Gray, UInt16>(ROIRB.Size);

                    TempRA = RNewTool[0].Copy(ROIRA);
                    TempRB = RNewTool[0].Copy(ROIRB);

                    NewToolshiftR = TempRB.ConcateHorizontal(TempRA);

                    //紀錄 file
                    using (StreamWriter sw = new StreamWriter(textBox_SaveImgPath.Text + "\\" + "Imgfiles.TXT"))
                    {
                        sw.WriteLine("歷程使用比較刀編號:");
                        sw.WriteLine("Tool:" + textBox_FilePath.Text);
                        sw.WriteLine("--------------------");
                        sw.WriteLine("Lshiftp:" + shiftL2);
                        sw.WriteLine("Rshiftp:" + shiftR2);
                        sw.WriteLine("--------------------");
                        sw.WriteLine(DateTime.Now);
                        sw.WriteLine("--------------------");
                        sw.WriteLine("Final Editor : PC.C");
                    }
                }


                errormapL = NewToolshiftL.AbsDiff(LTool);   //這邊改一下 0410
                Image<Gray, UInt16> submapL = new Image<Gray, UInt16>(errormapL.Size);
                submapL = NewToolshiftL.Sub(LTool);
                errormapR = NewToolshiftR.AbsDiff(RTool);
                Image<Gray, UInt16> submapR = new Image<Gray, UInt16>(errormapR.Size);
                submapR = NewToolshiftR.Sub(RTool);


                //平移
                #region
                //宣告平移計算變數
                Rectangle ROILF1, ROILF2, ROILF3, ROILF4A, ROILF4B;
                Image<Gray, UInt16> TempLF1, TempLF2,TempLF3,TempLF4A, TempLF4B;
                Rectangle ROIRF1, ROIRF2, ROIRF3, ROIRF4A, ROIRF4B;
                Image<Gray, UInt16> TempRF1, TempRF2, TempRF3, TempRF4A, TempRF4B;


                int[] FirstRowL = new int[NewToolshiftL.Cols/4];
                int[] F2RowL = new int[NewToolshiftL.Cols / 4];
                int[] F3RowL = new int[NewToolshiftL.Cols / 4];
                int[] F4RowL = new int[NewToolshiftL.Cols / 4];
                //
                /*DataTable aptable = new DataTable("All phase"); //0621創造datatable
                DataColumn ccolumn;
                DataRow rrow;
                aptable.Columns.Add("column0", System.Type.GetType("System.String"));
                //Initialize the row
                DataRow rrow = aptable.NewRow();*/

                int[,]AP =new int[1000,4]; //0621創造All phase 先試用750  0621
                int[,] APrange = new int[1000, 4];
                int AF1PositionL1 = 0;
                int AF1PositionL2 = 0;
                int AF2PositionL=0;
                int AF3PositionL=0;
                int AF4PositionL=0;
                int ALFlute1 = 0;
                int ALFlute2 = 0;
                int ALFlute3 = 0;
                int ALFlute4 = 0;
                //Excel 試建檔
                HSSFWorkbook APexcel = new HSSFWorkbook();
                ISheet sheet = APexcel.CreateSheet("sheet");
                sheet.CreateRow(0);
                sheet.GetRow(0).CreateCell(0).SetCellValue("APF1");
                sheet.GetRow(0).CreateCell(1).SetCellValue("APF2");
                sheet.GetRow(0).CreateCell(2).SetCellValue("APF3");
                sheet.GetRow(0).CreateCell(3).SetCellValue("APF4");
                sheet.GetRow(0).CreateCell(4).SetCellValue("APrangeF1");
                sheet.GetRow(0).CreateCell(5).SetCellValue("APrangeF2");
                sheet.GetRow(0).CreateCell(6).SetCellValue("APrangeF3");
                sheet.GetRow(0).CreateCell(7).SetCellValue("APrangeF4");
                for (int height = 0; height<1000; height++) //0621找全域的CH 直接輸出成EXCEL?  避免第一刃跨越問題分兩段寫0621:0-50, 50-500
                {
                    for (int column = 0; column < 50; column++)
                    {
                        FirstRowL[column] = NewToolshiftL.Data[height+26, column, 0]; 
                    }
                    AF1PositionL1 = Array.IndexOf(FirstRowL, FirstRowL.Max());  //判斷基準 AF1PositionL1 0622
                    //

                    if (AF1PositionL1 > 1 && 50> AF1PositionL1)  
                    {
                        for (int column = 0; column < NewToolshiftL.Cols / 5; column++)
                        {
                            F2RowL[column] = NewToolshiftL.Data[height + 26, AF1PositionL1 + 125 + column, 0];  //
                        }
                        AF2PositionL = AF1PositionL1 + 125 + Array.IndexOf(F2RowL, F2RowL.Max());
                        //
                        for (int column = 0; column < NewToolshiftL.Cols / 5; column++)  //
                        {
                            F3RowL[column] = NewToolshiftL.Data[height + 26, AF2PositionL + 125 + column, 0];   //
                        }
                        AF3PositionL = AF2PositionL + 125 + Array.IndexOf(F3RowL, F3RowL.Max());
                        //
                        for (int column = 0; column < NewToolshiftL.Cols / 5; column++)
                        {
                            F4RowL[column] = NewToolshiftL.Data[height + 26, AF3PositionL + 125 + column, 0];
                        }
                        AF4PositionL = AF3PositionL + 125 + Array.IndexOf(F4RowL, F4RowL.Max());
                        //
                        ALFlute1 = AF2PositionL - AF1PositionL1;
                        ALFlute2 = AF3PositionL - AF2PositionL;
                        ALFlute3 = AF4PositionL - AF3PositionL;
                        ALFlute4 = (1000 - AF4PositionL) + AF1PositionL1;
                        //
                        AP[height, 0] = AF1PositionL1;
                        AP[height, 1] = AF2PositionL;
                        AP[height, 2] = AF3PositionL;
                        AP[height, 3] = AF4PositionL;
                        APrange[height, 0] = ALFlute1;
                        APrange[height, 1] = ALFlute2;
                        APrange[height, 2] = ALFlute3;
                        APrange[height, 3] = ALFlute4;
                        //
                        sheet.CreateRow(height + 1);
                        sheet.GetRow(height + 1).CreateCell(0).SetCellValue(AP[height, 0]);
                        sheet.GetRow(height + 1).CreateCell(1).SetCellValue(AP[height, 1]);
                        sheet.GetRow(height + 1).CreateCell(2).SetCellValue(AP[height, 2]);
                        sheet.GetRow(height + 1).CreateCell(3).SetCellValue(AP[height, 3]);
                        sheet.GetRow(height + 1).CreateCell(4).SetCellValue(APrange[height, 0]);
                        sheet.GetRow(height + 1).CreateCell(5).SetCellValue(APrange[height, 1]);
                        sheet.GetRow(height + 1).CreateCell(6).SetCellValue(APrange[height, 2]);
                        sheet.GetRow(height + 1).CreateCell(7).SetCellValue(APrange[height, 3]);
                    }
                    else
                    {
                        for (int column = 0; column < (NewToolshiftL.Cols / 4) - 20; column++)
                        {
                            FirstRowL[column] = NewToolshiftL.Data[height + 26, column + (770), 0];
                        }
                        AF1PositionL2 = 770 + Array.IndexOf(FirstRowL, FirstRowL.Max());  //第二情況 用AF1PositionL2
                        //
                        for (int column = 0; column < NewToolshiftL.Cols / 5; column++)
                        {
                            F2RowL[column] = NewToolshiftL.Data[height + 26, (AF1PositionL2 - 770) + column, 0];  //
                        }
                        AF2PositionL = (AF1PositionL2 - 770) + Array.IndexOf(F2RowL, F2RowL.Max());
                        //
                        for (int column = 0; column < NewToolshiftL.Cols / 5; column++)  //
                        {
                            F3RowL[column] = NewToolshiftL.Data[height + 26, AF2PositionL + 125 + column, 0];   //
                        }
                        AF3PositionL = AF2PositionL + 125 + Array.IndexOf(F3RowL, F3RowL.Max());
                        //
                        for (int column = 0; column < NewToolshiftL.Cols / 5; column++)
                        {
                            F4RowL[column] = NewToolshiftL.Data[height + 26, AF3PositionL + 125 + column, 0];
                        }
                        AF4PositionL = AF3PositionL + 125 + Array.IndexOf(F4RowL, F4RowL.Max());
                        //
                        ALFlute1 = AF2PositionL + (1000 - AF1PositionL2);
                        ALFlute2 = AF3PositionL - AF2PositionL;
                        ALFlute3 = AF4PositionL - AF3PositionL;
                        ALFlute4 = (AF1PositionL2 - AF4PositionL);
                        //
                        AP[height, 0] = AF1PositionL2;
                        AP[height, 1] = AF2PositionL;
                        AP[height, 2] = AF3PositionL;
                        AP[height, 3] = AF4PositionL;
                        APrange[height, 0] = ALFlute1;
                        APrange[height, 1] = ALFlute2;
                        APrange[height, 2] = ALFlute3;
                        APrange[height, 3] = ALFlute4;
                        //
                        sheet.CreateRow(height + 1);
                        sheet.GetRow(height + 1).CreateCell(0).SetCellValue(AP[height, 0]);
                        sheet.GetRow(height + 1).CreateCell(1).SetCellValue(AP[height, 1]);
                        sheet.GetRow(height + 1).CreateCell(2).SetCellValue(AP[height, 2]);
                        sheet.GetRow(height + 1).CreateCell(3).SetCellValue(AP[height, 3]);
                        sheet.GetRow(height + 1).CreateCell(4).SetCellValue(APrange[height, 0]);
                        sheet.GetRow(height + 1).CreateCell(5).SetCellValue(APrange[height, 1]);
                        sheet.GetRow(height + 1).CreateCell(6).SetCellValue(APrange[height, 2]);
                        sheet.GetRow(height + 1).CreateCell(7).SetCellValue(APrange[height, 3]);
                    }
                }

               /* for (int height = 50; height < 750; height++) //0621避免第一刃跨越問題分兩段寫0621:0-50, 50-500
                {
                    for (int column = 0; column <(NewToolshiftL.Cols / 4)-20; column++)
                    {
                        FirstRowL[column] = NewToolshiftL.Data[height + 26, column+(770), 0];
                    }
                    int AF1PositionL = 770 + Array.IndexOf(FirstRowL, FirstRowL.Max());

                    //
                    for (int column = 0; column < NewToolshiftL.Cols / 5; column++)
                    {
                        F2RowL[column] = NewToolshiftL.Data[height + 26, (AF1PositionL-770) + column, 0];  //
                    }
                    int AF2PositionL = (AF1PositionL - 770)   + Array.IndexOf(F2RowL, F2RowL.Max());

                    //
                    for (int column = 0; column < NewToolshiftL.Cols / 5; column++)  //
                    {
                        F3RowL[column] = NewToolshiftL.Data[height + 26, AF2PositionL + 125 + column, 0];   //
                    }
                    int AF3PositionL = AF2PositionL + 125 + Array.IndexOf(F3RowL, F3RowL.Max());

                    //
                    for (int column = 0; column < NewToolshiftL.Cols / 5; column++)
                    {
                        F4RowL[column] = NewToolshiftL.Data[height + 26, AF3PositionL + 125 + column, 0];
                    }
                    int AF4PositionL = AF3PositionL + 125 + Array.IndexOf(F4RowL, F4RowL.Max());

                    //
                    int ALFlute1 = AF2PositionL + (1000 - AF1PositionL);
                    int ALFlute2 = AF3PositionL - AF2PositionL;
                    int ALFlute3 = AF4PositionL - AF3PositionL;
                    int ALFlute4 = (AF1PositionL - AF4PositionL);

                    AP[height, 0] = AF1PositionL;
                    AP[height, 1] = AF2PositionL;
                    AP[height, 2] = AF3PositionL;
                    AP[height, 3] = AF4PositionL;
                    APrange[height, 0] = ALFlute1;
                    APrange[height, 1] = ALFlute2;
                    APrange[height, 2] = ALFlute3;
                    APrange[height, 3] = ALFlute4;
                    //
                    sheet.CreateRow(height + 1);
                    sheet.GetRow(height + 1).CreateCell(0).SetCellValue(AP[height, 0]);
                    sheet.GetRow(height + 1).CreateCell(1).SetCellValue(AP[height, 1]);
                    sheet.GetRow(height + 1).CreateCell(2).SetCellValue(AP[height, 2]);
                    sheet.GetRow(height + 1).CreateCell(3).SetCellValue(AP[height, 3]);
                    sheet.GetRow(height + 1).CreateCell(4).SetCellValue(APrange[height, 0]);
                    sheet.GetRow(height + 1).CreateCell(5).SetCellValue(APrange[height, 1]);
                    sheet.GetRow(height + 1).CreateCell(6).SetCellValue(APrange[height, 2]);
                    sheet.GetRow(height + 1).CreateCell(7).SetCellValue(APrange[height, 3]);
                }*/


                FileStream streamWriter = new FileStream(textBox_SaveImgPath.Text + "\\" + "APexcel.xls", FileMode.Create, FileAccess.ReadWrite);
                APexcel.Write(streamWriter);
                streamWriter.Close();
                streamWriter.Dispose();
                ///
                for (int column = 0; column < NewToolshiftL.Cols/4; column++)
                {
                    FirstRowL[column] = NewToolshiftL.Data[26, column, 0]; //這邊測試是用26 0409 一定要回來驗證 重建時直接裁減再次測試0409 //0410 用1026找最小值看看
                }
                int FirstPositionL = Array.IndexOf(FirstRowL, FirstRowL.Max());  //這邊改成最大值測試看 0409
                //
                for (int column = 0; column < NewToolshiftL.Cols / 5; column++)
                {
                    F2RowL[column] = NewToolshiftL.Data[26, FirstPositionL+125+column, 0];  //避免找到麻煩+250/2 0526
                }
                int F2PositionL = FirstPositionL+125 + Array.IndexOf(F2RowL, F2RowL.Max());  
                //
                for (int column = 0; column < NewToolshiftL.Cols / 5; column++)  //不要找這麼多 /4再*0.8  0526
                {
                    F3RowL[column] = NewToolshiftL.Data[26, F2PositionL + 125+ column, 0];   //總共是+125+200
                }
                int F3PositionL = F2PositionL+125 + Array.IndexOf(F3RowL, F3RowL.Max());
                //
                for (int column = 0; column < NewToolshiftL.Cols / 5; column++)
                {
                    F4RowL[column] = NewToolshiftL.Data[26, F3PositionL+125 + column, 0];
                }
                int F4PositionL = F3PositionL+125 + Array.IndexOf(F4RowL, F4RowL.Max());



                int[] Flute1 = new int[NewToolshiftL.Cols / 4];  //這邊左邊界作為平移的標準 0408
                int[] Flute2 = new int[NewToolshiftL.Cols / 4];
                int[] Flute3 = new int[NewToolshiftL.Cols / 4];
                int[] Flute4 = new int[NewToolshiftL.Cols / 4];

                int LFlute1 = F2PositionL - FirstPositionL;//每刃長度
                int LFlute2 = F3PositionL - F2PositionL;
                int LFlute3 = F4PositionL - F3PositionL;
                int LFlute4 = (1000 - F4PositionL)+ FirstPositionL; 


                ROILA = new Rectangle(0, 0, FirstPositionL, LTool.Rows);
                ROILB = new Rectangle(FirstPositionL, 0, LTool.Cols - FirstPositionL, LTool.Rows);

                ROILF1 = new Rectangle(FirstPositionL, 0, LFlute1, LTool.Rows);
                ROILF2 = new Rectangle(F2PositionL, 0, LFlute2, LTool.Rows);
                ROILF3 = new Rectangle(F3PositionL, 0, LFlute3, LTool.Rows);
                ROILF4A = new Rectangle(F4PositionL, 0, 1000 - F4PositionL, LTool.Rows);
                ROILF4B = new Rectangle(0, 0, FirstPositionL, LTool.Rows);
                //ROILF4 = new Rectangle(F3Position, 0, LFlute3, LTool.Rows);

                TempLF1 = new Image<Gray, UInt16>(ROILF1.Size);
                TempLF2 = new Image<Gray, UInt16>(ROILF2.Size);
                TempLF3 = new Image<Gray, UInt16>(ROILF3.Size);
                TempLF4A = new Image<Gray, UInt16>(ROILF4A.Size);
                TempLF4B = new Image<Gray, UInt16>(ROILF4B.Size);

                TempLF1 = errormapL.Copy(ROILF1);
                TempLF2 = errormapL.Copy(ROILF2);
                TempLF3 = errormapL.Copy(ROILF3);
                TempLF4A = errormapL.Copy(ROILF4A);
                TempLF4B = errormapL.Copy(ROILF4B);

                errormapL = TempLF1.ConcateHorizontal(TempLF2.ConcateHorizontal(TempLF3.ConcateHorizontal(TempLF4A.ConcateHorizontal(TempLF4B))));
                /*
                TempLA = new Image<Gray, UInt16>(ROILA.Size);
                TempLB = new Image<Gray, UInt16>(ROILB.Size);
                TempLA = errormapL.Copy(ROILA);
                TempLB = errormapL.Copy(ROILB);
                errormapL = TempLB.ConcateHorizontal(TempLA);
                */

                TempLF1 = NewToolshiftL.Copy(ROILF1);
                TempLF2 = NewToolshiftL.Copy(ROILF2);
                TempLF3 = NewToolshiftL.Copy(ROILF3);
                TempLF4A = NewToolshiftL.Copy(ROILF4A);
                TempLF4B = NewToolshiftL.Copy(ROILF4B);
                NewToolshiftL = TempLF1.ConcateHorizontal(TempLF2.ConcateHorizontal(TempLF3.ConcateHorizontal(TempLF4A.ConcateHorizontal(TempLF4B))));

                /*
                TempLA = NewToolshiftL.Copy(ROILA);
                TempLB = NewToolshiftL.Copy(ROILB);
                NewToolshiftL = TempLB.ConcateHorizontal(TempLA);
                */
                TempLF1 = LTool.Copy(ROILF1);
                TempLF2 = LTool.Copy(ROILF2);
                TempLF3 = LTool.Copy(ROILF3);
                TempLF4A = LTool.Copy(ROILF4A);
                TempLF4B = LTool.Copy(ROILF4B);
                LTool = TempLF1.ConcateHorizontal(TempLF2.ConcateHorizontal(TempLF3.ConcateHorizontal(TempLF4A.ConcateHorizontal(TempLF4B))));
                /*
                TempLA = LTool.Copy(ROILA);
                TempLB = LTool.Copy(ROILB);
                LTool = TempLB.ConcateHorizontal(TempLA);
                */

                /*
                ROILA = new Rectangle(0, 0, 750, LTool.Rows);
                ROILB = new Rectangle(750, 0, LTool.Cols - 750, LTool.Rows);
                TempLA = new Image<Gray, UInt16>(ROILA.Size);
                TempLB = new Image<Gray, UInt16>(ROILB.Size);
                TempLA = errormapL.Copy(ROILA);
                TempLB = errormapL.Copy(ROILB);
                errormapL = TempLB.ConcateHorizontal(TempLA);

                TempLA = NewToolshiftL.Copy(ROILA);
                TempLB = NewToolshiftL.Copy(ROILB);
                NewToolshiftL = TempLB.ConcateHorizontal(TempLA);

                TempLA = LTool.Copy(ROILA);
                TempLB = LTool.Copy(ROILB);
                LTool = TempLB.ConcateHorizontal(TempLA);
                */
                /*
                //
                int[] FirstRowR = new int[NewToolshiftR.Cols / 4];
                int[] F2RowR = new int[NewToolshiftR.Cols / 4];
                int[] F3RowR = new int[NewToolshiftR.Cols / 4];
                int[] F4RowR = new int[NewToolshiftR.Cols / 4];
                //
                for (int column = 0; column < NewToolshiftR.Cols / 4; column++)
                {
                    FirstRowR[column] = NewToolshiftR.Data[80, column, 0]; //這邊測試是用26 0409 一定要回來驗證 重建時直接裁減再次測試0409 //0410 用1026找最小值看看
                }
                int FirstPositionR = Array.IndexOf(FirstRowR, FirstRowR.Min());  //這邊改成最大值測試看 0409
                //
                for (int column = 0; column < NewToolshiftR.Cols / 5; column++)
                {
                    F2RowR[column] = NewToolshiftR.Data[80, FirstPositionR + 125 + column, 0];  //避免找到麻煩+250/2 0526
                }
                int F2PositionR = FirstPositionR+125 + Array.IndexOf(F2RowR, F2RowR.Min());
                //
                for (int column = 0; column < NewToolshiftR.Cols / 5; column++)  //不要找這麼多 /4再*0.8  0526
                {
                    F3RowR[column] = NewToolshiftR.Data[80, F2PositionR + 125 + column, 0];   //總共是+125+200
                }
                int F3PositionR = F2PositionR+125 + Array.IndexOf(F3RowR, F3RowR.Min());
                //
                for (int column = 0; column < NewToolshiftR.Cols / 5; column++)
                {
                    F4RowR[column] = NewToolshiftR.Data[80, F3PositionR + 125 + column, 0];
                }
                int F4PositionR = F3PositionR+125 + Array.IndexOf(F4RowR, F4RowR.Min());



                int RFlute1 = F2PositionR - FirstPositionR;//每刃長度
                int RFlute2 = F3PositionR - F2PositionR;
                int RFlute3 = F4PositionR - F3PositionR;
                int RFlute4 = (1000 - F4PositionR) + FirstPositionR;


                ROIRA = new Rectangle(0, 0, FirstPositionR, RTool.Rows);
                ROIRB = new Rectangle(FirstPositionR, 0, RTool.Cols - FirstPositionR, RTool.Rows);

                ROIRF1 = new Rectangle(FirstPositionR, 0, RFlute1, RTool.Rows);
                ROIRF2 = new Rectangle(F2PositionR, 0, RFlute2, RTool.Rows);
                ROIRF3 = new Rectangle(F3PositionR, 0, RFlute3, RTool.Rows);
                ROIRF4A = new Rectangle(F4PositionR, 0, 1000 - F4PositionR, RTool.Rows);
                ROIRF4B = new Rectangle(0, 0, FirstPositionR, RTool.Rows);
                //ROIRF4 = new Rectangle(F3Position, 0, RFlute3, RTool.Rows);

                TempRF1 = new Image<Gray, UInt16>(ROIRF1.Size);
                TempRF2 = new Image<Gray, UInt16>(ROIRF2.Size);
                TempRF3 = new Image<Gray, UInt16>(ROIRF3.Size);
                TempRF4A = new Image<Gray, UInt16>(ROIRF4A.Size);
                TempRF4B = new Image<Gray, UInt16>(ROIRF4B.Size);

                TempRF1 = errormapR.Copy(ROIRF1);
                TempRF2 = errormapR.Copy(ROIRF2);
                TempRF3 = errormapR.Copy(ROIRF3);
                TempRF4A = errormapR.Copy(ROIRF4A);
                TempRF4B = errormapR.Copy(ROIRF4B);

                errormapR = TempRF1.ConcateHorizontal(TempRF2.ConcateHorizontal(TempRF3.ConcateHorizontal(TempRF4A.ConcateHorizontal(TempRF4B))));
                /*
                TempRA = new Image<Gray, UInt16>(ROIRA.Size);
                TempRB = new Image<Gray, UInt16>(ROIRB.Size);
                TempRA = errormapR.Copy(ROIRA);
                TempRB = errormapR.Copy(ROIRB);
                errormapR = TempRB.ConcateHorizontal(TempRA);
                */
                /*
                TempRF1 = NewToolshiftR.Copy(ROIRF1);
                TempRF2 = NewToolshiftR.Copy(ROIRF2);
                TempRF3 = NewToolshiftR.Copy(ROIRF3);
                TempRF4A = NewToolshiftR.Copy(ROIRF4A);
                TempRF4B = NewToolshiftR.Copy(ROIRF4B);
                NewToolshiftR = TempRF1.ConcateHorizontal(TempRF2.ConcateHorizontal(TempRF3.ConcateHorizontal(TempRF4A.ConcateHorizontal(TempRF4B))));
                */
                /*
                TempRA = NewToolshiftR.Copy(ROIRA);
                TempRB = NewToolshiftR.Copy(ROIRB);
                NewToolshiftR = TempRB.ConcateHorizontal(TempRA);
                */
                /*
                TempRF1 = RTool.Copy(ROIRF1);
                TempRF2 = RTool.Copy(ROIRF2);
                TempRF3 = RTool.Copy(ROIRF3);
                TempRF4A = RTool.Copy(ROIRF4A);
                TempRF4B = RTool.Copy(ROIRF4B);
                RTool = TempRF1.ConcateHorizontal(TempRF2.ConcateHorizontal(TempRF3.ConcateHorizontal(TempRF4A.ConcateHorizontal(TempRF4B))));
                /*
                TempRA = RTool.Copy(ROIRA);
                TempRB = RTool.Copy(ROIRB);
                RTool = TempRB.ConcateHorizontal(TempRA);
                */

                /*
                ROIRA = new Rectangle(0, 0, 750, RTool.Rows);
                ROIRB = new Rectangle(750, 0, RTool.Cols - 750, RTool.Rows);
                TempRA = new Image<Gray, UInt16>(ROIRA.Size);
                TempRB = new Image<Gray, UInt16>(ROIRB.Size);
                TempRA = errormapR.Copy(ROIRA);
                TempRB = errormapR.Copy(ROIRB);
                errormapR = TempRB.ConcateHorizontal(TempRA);

                TempRA = NewToolshiftR.Copy(ROIRA);
                TempRB = NewToolshiftR.Copy(ROIRB);
                NewToolshiftR = TempRB.ConcateHorizontal(TempRA);

                TempRA = RTool.Copy(ROIRA);
                TempRB = RTool.Copy(ROIRB);
                RTool = TempRB.ConcateHorizontal(TempLA);
                */
                
                textBox3.Clear();
                for (int column = 0; column < NewToolshiftL.Cols; column++)
                {
                    
                    textBox3.Text = textBox3.Text + "\r\n" + NewToolshiftL.Data[26, column, 0].ToString(); //這邊斟酌 0410
                    textBox3.SelectionStart = textBox3.Text.Length;
                    textBox3.ScrollToCaret();
                    textBox3.Refresh();
                    

                    int i = column / (NewToolshiftL.Cols / 4);
                    int j = column % (NewToolshiftL.Cols / 4);
                    switch (i)
                    {
                        case 0:
                            Flute1[j] = NewToolshiftL.Data[26, column, 0];
                            break;
                        case 1:
                            Flute2[j] = NewToolshiftL.Data[26, column, 0];
                            break;
                        case 2:
                            Flute3[j] = NewToolshiftL.Data[26, column, 0];
                            break;
                        case 3:
                            Flute4[j] = NewToolshiftL.Data[26, column, 0];
                            break;
                    }
                }

                #endregion

                #region TxtOutput
                // Create an instance of StreamWriter to write text to a file.
                // The using statement also closes the StreamWriter.
                using (StreamWriter sw = new StreamWriter(textBox_SaveImgPath.Text + "\\" + "Postion.TXT"))   //小寫TXT     
                {
                    sw.WriteLine("----------F1----------");
                    sw.WriteLine("F1"+":"+ FirstPositionL); 
                    sw.WriteLine("F1phase"+LFlute1);
                    sw.WriteLine("----------F2----------");
                    sw.WriteLine("F2" + ":" + F2PositionL);
                    sw.WriteLine("F2phase" + LFlute2);
                    sw.WriteLine("----------F3----------");
                    sw.WriteLine("F3" + ":" + F3PositionL);
                    sw.WriteLine("F3phase" + LFlute3);
                    sw.WriteLine("----------F4----------");
                    sw.WriteLine("F4" + ":" + F4PositionL);
                    sw.WriteLine("F4phase" + LFlute4);

                   /* sw.WriteLine("----------R----------");
                    sw.WriteLine("F1" + ":" + FirstPositionR);
                    sw.WriteLine("F1 phase" + RFlute1);
                    sw.WriteLine("F2" + ":" + F2PositionR);
                    sw.WriteLine("F2 phase" + RFlute2);
                    sw.WriteLine("F3" + ":" + F3PositionR);
                    sw.WriteLine("F3 phase" + RFlute3);
                    sw.WriteLine("F4" + ":" + F4PositionR);
                    sw.WriteLine("F4 phase" + RFlute4);
                   */

                    /*
                    sw.WriteLine((Array.IndexOf(Flute1, Flute1.Max())).ToString());
                    sw.WriteLine("250");
                    sw.WriteLine((Array.IndexOf(Flute1, Flute1.Max()) + 250).ToString());
                    sw.WriteLine("500");
                    sw.WriteLine((Array.IndexOf(Flute1, Flute1.Max()) + 500).ToString());
                    sw.WriteLine("750");
                    sw.WriteLine((Array.IndexOf(Flute1, Flute1.Max()) + 750).ToString());
                    sw.WriteLine("1000");
                    */
                }
                #endregion
                /*
                #region -- ExcelOutput--
                double A = double.Parse(textBox_Pixelsize.Text) / double.Parse(textBox_Mag.Text);

                double Volume = (double)CvInvoke.Sum(errormap).V0 * (A * A * (toolRadius * Math.PI / errormap.Cols));
                double Area = (double)CvInvoke.CountNonZero(errormap) * (A * (toolRadius * Math.PI / errormap.Cols));
                double Ave = Volume / Area;

                errormap.MinMax(out minValues, out maxValues, out minLocations, out maxLocations);

                textBox3.Text = textBox3.Text + "\r\n" + ":V:" + Volume.ToString() + ":A:" + Area.ToString() + ":Ave:" + Ave.ToString() + ":Max:" + maxValues[0].ToString();

                
                IWorkbook templateWorkbook;
                using (FileStream fs = new FileStream(@textBox_WearDepthOutput.Text, FileMode.Open, FileAccess.Read))
                {
                    templateWorkbook = new XSSFWorkbook(fs);
                }
                
                XSSFSheet sheetRaw = (XSSFSheet)templateWorkbook.GetSheetAt(0);
                int RowCount = sheetRaw.LastRowNum;

                textBox3.Text = textBox3.Text + "\r\n" + RowCount.ToString() + "A";
                textBox3.Refresh();


                string Time = DateTime.Now.ToShortDateString() + "//" + DateTime.Now.ToShortTimeString();

                sheetRaw.CreateRow(RowCount + 1);
                sheetRaw.GetRow(RowCount + 1).CreateCell(0).SetCellValue(RowCount + 1);     //編號
                sheetRaw.GetRow(RowCount + 1).CreateCell(1).SetCellValue(1);                //批次
                sheetRaw.GetRow(RowCount + 1).CreateCell(2).SetCellValue(ToolName);            //名稱
                sheetRaw.GetRow(RowCount + 1).CreateCell(3).SetCellValue(Time);             //時間
                sheetRaw.GetRow(RowCount + 1).CreateCell(4).SetCellValue(Volume);           //體積
                sheetRaw.GetRow(RowCount + 1).CreateCell(5).SetCellValue(Area);             //面積
                sheetRaw.GetRow(RowCount + 1).CreateCell(6).SetCellValue(Ave);              //平均深度
                sheetRaw.GetRow(RowCount + 1).CreateCell(7).SetCellValue(maxValues[0] * A);   //最大深度

                using (FileStream fs = new FileStream(@textBox_WearDepthOutput.Text, FileMode.Create, FileAccess.Write))
                {
                    templateWorkbook.Write(fs);
                }
                #endregion
                */

                //存檔
                #region --ImgSave--
                Rectangle ROIEM; 
                ROIEM = new Rectangle(0, 26, 1000, 1000);
                Image<Gray, UInt16> errormapLL = new Image<Gray, UInt16>(1000,1000);
                Image<Gray, UInt16> errormapRR = new Image<Gray, UInt16>(1000, 1000);
                Image<Gray, UInt16> submapLL = new Image<Gray, UInt16>(errormapLL.Size);
                Image<Gray, UInt16> submapRR = new Image<Gray, UInt16>(errormapRR.Size);

                errormapLL = errormapL.Copy(ROIEM);
                submapLL = submapL.Copy(ROIEM);
                errormapRR = errormapR.Copy(ROIEM);
                submapRR = submapR.Copy(ROIEM);

                errormapLL.Save(textBox_SaveImgPath.Text + "\\" + "LWearDepthRaw.Tif");
                errormapRR.Save(textBox_SaveImgPath.Text + "\\" + "RWearDepthRaw.Tif");
                submapLL.Save(SaveDirIPCC + "\\" + "LSubRaw.Tif");
                submapRR.Save(SaveDirIPCC + "\\" + "RSubRaw.Tif");

                Image<Gray, Byte> errormapNormL = new Image<Gray, byte>(errormapLL.Size);
                Image<Gray, Byte> errormapNormR = new Image<Gray, byte>(errormapRR.Size);

                errormapLL.MinMax(out minValuesL, out maxValuesL, out minLocationsL, out maxLocationsL);
                errormapNormL = errormapLL.ConvertScale<Byte>((256 / (maxValuesL[0] - minValuesL[0])), minValuesL[0]);
                errormapNormL.Save(SaveDirIPC + "\\" + "LWearDepthGray.Tif");
                CvInvoke.ApplyColorMap(errormapNormL, errormapNormL, ColorMapType.Jet);
                errormapNormL.Save(SaveDirIPC + "\\" + "LWearDepthJet.Tif");

                errormapRR.MinMax(out minValuesR, out maxValuesR, out minLocationsR, out maxLocationsR);
                errormapNormR = errormapRR.ConvertScale<Byte>((256 / (maxValuesR[0] - minValuesR[0])), minValuesR[0]);
                errormapNormR.Save(SaveDirIPC + "\\" + "RWearDepthGray.Tif");
                CvInvoke.ApplyColorMap(errormapNormR, errormapNormR, ColorMapType.Jet);
                errormapNormR.Save(SaveDirIPC + "\\" + "RWearDepthJet.Tif");

                //存新刀對齊
                NewToolshiftL.Save(SaveDirIPCC + "\\" + "L_Compareone.Tif");
                NewToolshiftR.Save(SaveDirIPCC + "\\" + "R_Compareone.Tif");
                //存舊刀對齊
                LTool.Save(SaveDirIPCC + "\\" + "L_Testone.Tif");
                RTool.Save(SaveDirIPCC + "\\" + "R_Testone.Tif");

                imgBox_LWearDepthMap.Image = errormapNormL;
                //imgBox_RWearDepthMap.Image = errormapNormR;  //深度圖右邊顯示


                //正射
                /*
                double Ladj = errormapLL.Cols * (toolRadius * Math.PI / errormapLL.Cols) / systemResolutionL;
                errormapLL = errormapLL.Resize((int)(Ladj), errormapLL.Rows, Inter.Cubic);

                Image<Gray, UInt16> errormapProL = new Image<Gray, UInt16>(errormapLL.Size);
                for (int row = 0; row < errormapProL.Rows; row++)
                {
                    for (int column = 0; column < errormapProL.Cols; column++)
                    {
                        errormapProL.Data[row, column, 0] = errormapLL.Data[row, ((column + row) % errormapLL.Cols), 0];
                    }
                }
                errormapProL = errormapProL.Resize(1000, errormapProL.Rows, Inter.Cubic);
                errormapProL.Save(textBox_SaveImgPath.Text + "\\" + "LWearDepthProRaw.Tif");
                //errormapPro.Save(Newpath + ToolName + "_WearDepthProRaw.Tif");


                Image<Gray, Byte> errormapProNormL = new Image<Gray, Byte>(errormapProL.Size);
                errormapProL.MinMax(out minValuesL, out maxValuesL, out minLocationsL, out maxLocationsL);
                errormapProNormL = errormapProL.ConvertScale<Byte>((256 / (maxValuesL[0] - minValuesL[0])), minValuesL[0]);
                errormapProNormL.Save(textBox_SaveImgPath.Text + "\\" + "LWearDepthProGray.Tif");


                CvInvoke.ApplyColorMap(errormapProNormL, errormapProNormL, ColorMapType.Jet);
                errormapProNormL.Save(textBox_SaveImgPath.Text + "\\" + "LWearDepthProJet.Tif");
                */
                //errormapProNorm.Save(Newpath + ToolName + "_WearDepthProJet.Tif");
                #endregion
                //Auto Labeling
                #region --Label--
                //找最大VB磨耗
                    //宣告
                Image<Gray, UInt16> VBTempLF1, VBTempLF2, VBTempLF3, VBTempLF4;
                Rectangle VBROILF1, VBROILF2, VBROILF3, VBROILF4;
                double[] VBminValuesL, VBmaxValuesLF1, VBmaxValuesLF2, VBmaxValuesLF3, VBmaxValuesLF4;
                int VBsumF1=0, VBsumF2=0, VBsumF3=0, VBsumF4=0;

                Point[] VBminLocationsL, VBmaxLocationsLF1, VBmaxLocationsLF2, VBmaxLocationsLF3, VBmaxLocationsLF4;
                Image<Gray, double> VBmaxerrorL = new Image<Gray, double>(4, 2);
                Image<Gray, double> VBmaxposiL = new Image<Gray, double>(4, 1);
                
                VBROILF1 = new Rectangle(0, 0, LFlute1, errormapLL.Rows);
                VBROILF2 = new Rectangle(LFlute1, 0, LFlute2, errormapLL.Rows);
                VBROILF3 = new Rectangle(LFlute2, 0, LFlute3, errormapLL.Rows);
                VBROILF4 = new Rectangle(LFlute3, 0, LFlute4, errormapLL.Rows);

                VBTempLF1 = errormapLL.Copy(VBROILF1); 
                VBTempLF2 = errormapLL.Copy(VBROILF2);
                VBTempLF3 = errormapLL.Copy(VBROILF3);
                VBTempLF4 = errormapLL.Copy(VBROILF4);

                //計算最大深度/位置
                VBTempLF1.MinMax(out VBminValuesL, out VBmaxValuesLF1, out VBminLocationsL, out VBmaxLocationsLF1);
                VBmaxerrorL.Data[0, 0, 0] = VBmaxValuesLF1[0];
                VBmaxposiL.Data[0, 0, 0] = VBmaxLocationsLF1[0].X;

                VBTempLF2.MinMax(out VBminValuesL, out VBmaxValuesLF2, out VBminLocationsL, out VBmaxLocationsLF2);
                VBmaxerrorL.Data[0, 1, 0] = VBmaxValuesLF2[0];
                VBmaxposiL.Data[0, 1, 0] = VBmaxLocationsLF2[0].X;

                VBTempLF3.MinMax(out VBminValuesL, out VBmaxValuesLF3, out VBminLocationsL, out VBmaxLocationsLF3);
                VBmaxerrorL.Data[0, 2, 0] = VBmaxValuesLF3[0];
                VBmaxposiL.Data[0, 2, 0] = VBmaxLocationsLF3[0].X;

                VBTempLF4.MinMax(out VBminValuesL, out VBmaxValuesLF4, out VBminLocationsL, out VBmaxLocationsLF4);
                VBmaxerrorL.Data[0, 3, 0] = VBmaxValuesLF4[0];
                VBmaxposiL.Data[0, 3, 0] = VBmaxLocationsLF4[0].X;

            //角度設定/計算
            double MicroReso = double.Parse(textBox_MicroReso.Text);
            double ShiftReso = double.Parse(textBox_ShiftReso.Text);
            Image<Gray, double> CHWcal = new Image<Gray, double>(4, 3);
            Image<Gray, double> CHDcal = new Image<Gray, double>(4, 3);
            double ang = (90 / 250);

            CHWcal.Data[0, 0, 0] = Math.PI*((ang * (VBmaxLocationsLF1[0].X - 150)) + 12-90)/180;
            CHWcal.Data[1, 0, 0] = 1 / (Math.Sin(CHWcal.Data[0, 0, 0]));
            CHWcal.Data[2, 0, 0] = VBmaxerrorL.Data[0, 0, 0] * MicroReso * CHWcal.Data[1, 0, 0];
            CHDcal.Data[0, 0, 0] = Math.PI * ((ang * (VBmaxLocationsLF1[0].X-150)) - 6) / 180;
            CHDcal.Data[1, 0, 0] = 1 / (Math.Cos(CHDcal.Data[0, 0, 0]));
            CHDcal.Data[2, 0, 0] = VBmaxerrorL.Data[0, 0, 0] * MicroReso * CHDcal.Data[1, 0, 0];

            CHWcal.Data[0, 1, 0] = Math.PI * ((ang * (VBmaxLocationsLF2[0].X - 150)) + 12 ) / 180;
            CHWcal.Data[1, 1, 0] = 1 / (Math.Sin(CHWcal.Data[0, 1, 0]));
            CHWcal.Data[2, 1, 0] = VBmaxerrorL.Data[0, 1, 0] * MicroReso * CHWcal.Data[1, 1, 0];
            CHDcal.Data[0, 1, 0] = Math.PI * ((ang * (VBmaxLocationsLF2[0].X-150)) - 6)  / 180;
            CHDcal.Data[1, 1, 0] = 1 / (Math.Cos(CHDcal.Data[0, 1, 0]));
            CHDcal.Data[2, 1, 0] = VBmaxerrorL.Data[0, 1, 0] * MicroReso * CHDcal.Data[1, 1, 0];

            CHWcal.Data[0, 2, 0] = Math.PI * ((ang * (VBmaxLocationsLF3[0].X - 150)) + 12 ) / 180;
            CHWcal.Data[1, 2, 0] = 1 / (Math.Sin(CHWcal.Data[0, 2, 0]));
            CHWcal.Data[2, 2, 0] = VBmaxerrorL.Data[0, 2, 0] * MicroReso * CHWcal.Data[1, 2, 0];
            CHDcal.Data[0, 2, 0] = Math.PI * ((ang * (VBmaxLocationsLF3[0].X-150)) - 6) / 180;
            CHDcal.Data[1, 2, 0] = 1 / (Math.Cos(CHDcal.Data[0, 2, 0]));
            CHDcal.Data[2, 2, 0] = VBmaxerrorL.Data[0, 2, 0] * MicroReso * CHDcal.Data[1, 2, 0];

            CHWcal.Data[0, 3, 0] = Math.PI * ((ang * (VBmaxLocationsLF4[0].X - 150)) + 12 ) / 180;
            CHWcal.Data[1, 3, 0] = 1 / (Math.Sin(CHWcal.Data[0, 3, 0]));
            CHWcal.Data[2, 3, 0] = VBmaxerrorL.Data[0, 3, 0] * MicroReso * CHWcal.Data[1, 3, 0];
            CHDcal.Data[0, 3, 0] = Math.PI * ((ang * (VBmaxLocationsLF4[0].X-150)) - 6 ) / 180;
            CHDcal.Data[1, 3, 0] = 1 / (Math.Cos(CHDcal.Data[0, 3, 0]));
            CHDcal.Data[2, 3, 0] = VBmaxerrorL.Data[0, 3, 0] * MicroReso * CHDcal.Data[1, 3, 0];


            //計算sum
            for (int iF1 = 0; iF1 < LFlute1; iF1++)
                {
                    for (int jF1 = 0; jF1 < errormapLL.Rows/20; jF1++)
                    {
                        VBsumF1 += VBTempLF1.Data[jF1, iF1,0];
                    }
                }
                for (int iF2 = 0; iF2 < LFlute2; iF2++)
                {
                    for (int jF2 = 0; jF2 < errormapLL.Rows/20; jF2++)
                    {
                        VBsumF2 += VBTempLF2.Data[jF2, iF2, 0];
                    }
                }
                for (int iF3 = 0; iF3 < LFlute3; iF3++)
                {
                    for (int jF3 = 0; jF3 < errormapLL.Rows/20; jF3++)
                    {
                        VBsumF3 += VBTempLF3.Data[jF3, iF3, 0];
                    }
                }
                for (int iF4 = 0; iF4 < LFlute4; iF4++)
                {
                    for (int jF4 = 0; jF4 < errormapLL.Rows/20; jF4++)
                    {
                        VBsumF4 += VBTempLF4.Data[jF4, iF4, 0];
                    }
                }

                //連續長度
                int[] VBWDF1 = new int[150];
                for (int iF1 = 150; iF1 > 0; iF1--)
                {
                    VBWDF1[iF1-1] = VBTempLF1.Data[VBmaxLocationsLF1[0].Y, iF1, 0];
                }
                int VBF1min = 150 -( 1 +Array.IndexOf(VBWDF1, VBWDF1.Min()));
                double CHF1min = VBF1min * ShiftReso;

                int[] VBWDF2 = new int[150];
                for (int iF2 = 150; iF2 > 0; iF2--)
                {
                    VBWDF2[iF2-1] = VBTempLF2.Data[VBmaxLocationsLF2[0].Y, iF2, 0];
                }
                int VBF2min = 150-(1 + Array.IndexOf(VBWDF2, VBWDF2.Min()));
                double CHF2min = VBF2min * ShiftReso;

                int[] VBWDF3 = new int[150];
                for (int iF3 = 150; iF3 > 0; iF3--)
                {
                    VBWDF3[iF3-1] = VBTempLF3.Data[VBmaxLocationsLF3[0].Y, iF3, 0];
                }
                int VBF3min = 150 -( 1 + Array.IndexOf(VBWDF3, VBWDF3.Min()));
                double CHF3min = VBF3min * ShiftReso;

                int[] VBWDF4 = new int[150];
                for (int iF4 = 150; iF4 > 0; iF4--)
                {
                    VBWDF4[iF4-1] = VBTempLF4.Data[VBmaxLocationsLF4[0].Y, iF4, 0];
                }
                int VBF4min = 150 -( 1 + Array.IndexOf(VBWDF4, VBWDF4.Min()));
                double CHF4min = VBF4min * ShiftReso;


                /*int[] VBWDF1 = new int[VBmaxLocationsLF1[0].X + 1];
                for (int iF1 = VBmaxLocationsLF1[0].X; iF1 > 0; iF1--)
                {
                    VBWDF1[VBmaxLocationsLF1[0].X - iF1] = VBTempLF1.Data[VBmaxLocationsLF1[0].Y, iF1, 0];
                }
                int VBF1min = 1 + Array.IndexOf(VBWDF1, VBWDF1.Min());

                int[] VBWDF2 = new int[VBmaxLocationsLF2[0].X + 1];
                for (int iF2 = VBmaxLocationsLF2[0].X; iF2 > 0; iF2--)
                {
                    VBWDF2[VBmaxLocationsLF2[0].X - iF2] = VBTempLF2.Data[VBmaxLocationsLF2[0].Y, iF2, 0];
                }
                int VBF2min = 1 + Array.IndexOf(VBWDF2, VBWDF2.Min());

                int[] VBWDF3 = new int[VBmaxLocationsLF3[0].X + 1];
                for (int iF3 = VBmaxLocationsLF3[0].X; iF3 > 0; iF3--)
                {

                    VBWDF3[VBmaxLocationsLF3[0].X - iF3] = VBTempLF3.Data[VBmaxLocationsLF3[0].Y, iF3, 0];
                }
                int VBF3min = 1 + Array.IndexOf(VBWDF3, VBWDF3.Min());

                int[] VBWDF4 = new int[VBmaxLocationsLF4[0].X + 1];
                for (int iF4 = VBmaxLocationsLF4[0].X; iF4 > 0; iF4--)
                {
                    VBWDF4[VBmaxLocationsLF4[0].X - iF4] = VBTempLF4.Data[VBmaxLocationsLF1[0].Y, iF4, 0];
                }
                int VBF4min = 1 + Array.IndexOf(VBWDF4, VBWDF4.Min());*/
            //CHnum/sum phase bias
            int[,] CHnum = new int[1, 4];
                int[,] CHsum = new int[1000, 4];
                int[,] CHsumF = new int[1, 4];

                for (int height=0; height<1000; height++)
                {
                    for (int j =0; j<4; j++)
                    {
                        if (APrange[height, j] > 250)
                        {
                            CHnum[0, j] = CHnum[0, j] + 1;
                            CHsum[height, j] = (APrange[height, j] - 250);
                        }
                        else if (APrange[height, j] < 250)
                        {
                            CHnum[0, j] = CHnum[0, j] + 1;
                            CHsum[height, j] = ( 250-APrange[height, j] );
                        }
                        else
                        {
                            CHnum[0, j] = CHnum[0, j] ;
                            CHsum[height, j] = 0;
                        }
                        CHsumF[0, j] += CHsum[height, j];
                    }
                }
                //Chipinig





                //Excel 輸出
                //double MicroReso = double.Parse(textBox_MicroReso.Text);
                //double ShiftReso = double.Parse(textBox_ShiftReso.Text);

                HSSFWorkbook AutoLabelexcel = new HSSFWorkbook();
                ISheet label1 = AutoLabelexcel.CreateSheet("label1");
                label1.CreateRow(0);
                label1.GetRow(0).CreateCell(0).SetCellValue("VBmaxWD_F1"); //最大深度
                label1.GetRow(0).CreateCell(1).SetCellValue("VBmaxWD_F2");
                label1.GetRow(0).CreateCell(2).SetCellValue("VBmaxWD_F3");
                label1.GetRow(0).CreateCell(3).SetCellValue("VBmaxWD_F4");
                /*label1.GetRow(0).CreateCell(4).SetCellValue("VBWDpixel_F1"); //最大深度pixel位置
                label1.GetRow(0).CreateCell(5).SetCellValue("VBWDpixel_F2");
                label1.GetRow(0).CreateCell(6).SetCellValue("VBWDpixel_F3");
                label1.GetRow(0).CreateCell(7).SetCellValue("VBWDpixel_F4");*/
                label1.GetRow(0).CreateCell(4).SetCellValue("VBsumWD_F1"); //sum
                label1.GetRow(0).CreateCell(5).SetCellValue("VBsumWD_F2");
                label1.GetRow(0).CreateCell(6).SetCellValue("VBsumWD_F3");
                label1.GetRow(0).CreateCell(7).SetCellValue("VBsumWD_F4");
                label1.GetRow(0).CreateCell(8).SetCellValue("VBWL_F1"); //連續長度
                label1.GetRow(0).CreateCell(9).SetCellValue("VBWL_F2");
                label1.GetRow(0).CreateCell(10).SetCellValue("VBWL_F3");
                label1.GetRow(0).CreateCell(11).SetCellValue("VBWL_F4");
                label1.GetRow(0).CreateCell(12).SetCellValue("CHW_F1"); //CHW
                label1.GetRow(0).CreateCell(13).SetCellValue("CHW_F2");
                label1.GetRow(0).CreateCell(14).SetCellValue("CHW_F3");
                label1.GetRow(0).CreateCell(15).SetCellValue("CHW_F4");
                label1.GetRow(0).CreateCell(16).SetCellValue("CHD_F1"); //CHD
                label1.GetRow(0).CreateCell(17).SetCellValue("CHD_F2");
                label1.GetRow(0).CreateCell(18).SetCellValue("CHD_F3");
                label1.GetRow(0).CreateCell(19).SetCellValue("CHD_F4");
                label1.GetRow(0).CreateCell(20).SetCellValue("CHWL_F1"); //CH連續長度
                label1.GetRow(0).CreateCell(21).SetCellValue("CHWL_F2");
                label1.GetRow(0).CreateCell(22).SetCellValue("CHWL_F3");
                label1.GetRow(0).CreateCell(23).SetCellValue("CHWL_F4");
                label1.GetRow(0).CreateCell(24).SetCellValue("PHnum_F1"); //PHnum
                label1.GetRow(0).CreateCell(25).SetCellValue("PHnum_F2");
                label1.GetRow(0).CreateCell(26).SetCellValue("PHnum_F3");
                label1.GetRow(0).CreateCell(27).SetCellValue("PHnum_F4");
                label1.GetRow(0).CreateCell(28).SetCellValue("PHsum_F1"); //PHsum
                label1.GetRow(0).CreateCell(29).SetCellValue("PHsum_F2");
                label1.GetRow(0).CreateCell(30).SetCellValue("PHsum_F3");
                label1.GetRow(0).CreateCell(31).SetCellValue("PHsum_F4");

                label1.CreateRow(1);
                label1.GetRow(1).CreateCell(0).SetCellValue(VBmaxValuesLF1[0] * MicroReso);
                label1.GetRow(1).CreateCell(1).SetCellValue(VBmaxValuesLF2[0] * MicroReso);
                label1.GetRow(1).CreateCell(2).SetCellValue(VBmaxValuesLF3[0] * MicroReso);
                label1.GetRow(1).CreateCell(3).SetCellValue(VBmaxValuesLF4[0] * MicroReso);
                /*label1.GetRow(1).CreateCell(4).SetCellValue(VBmaxLocationsLF1[0].X);
                label1.GetRow(1).CreateCell(5).SetCellValue(VBmaxLocationsLF2[0].X+ LFlute1);
                label1.GetRow(1).CreateCell(6).SetCellValue(VBmaxLocationsLF3[0].X+ LFlute1+ LFlute2);
                label1.GetRow(1).CreateCell(7).SetCellValue(VBmaxLocationsLF4[0].X+ LFlute1+ LFlute2+ LFlute3);*/
                label1.GetRow(1).CreateCell(4).SetCellValue(VBsumF1 * MicroReso);
                label1.GetRow(1).CreateCell(5).SetCellValue(VBsumF2 * MicroReso);
                label1.GetRow(1).CreateCell(6).SetCellValue(VBsumF3 * MicroReso);
                label1.GetRow(1).CreateCell(7).SetCellValue(VBsumF4 * MicroReso);

                label1.GetRow(1).CreateCell(8).SetCellValue(VBF1min * ShiftReso);
                label1.GetRow(1).CreateCell(9).SetCellValue(VBF2min * ShiftReso);
                label1.GetRow(1).CreateCell(10).SetCellValue(VBF3min * ShiftReso);
                label1.GetRow(1).CreateCell(11).SetCellValue(VBF4min * ShiftReso);
            
                label1.GetRow(1).CreateCell(12).SetCellValue(Math.Abs(CHWcal.Data[2, 0, 0]));
                label1.GetRow(1).CreateCell(13).SetCellValue(Math.Abs(CHWcal.Data[2, 1, 0]));
                label1.GetRow(1).CreateCell(14).SetCellValue(Math.Abs(CHWcal.Data[2, 2, 0]));
                label1.GetRow(1).CreateCell(15).SetCellValue(Math.Abs(CHWcal.Data[2, 3, 0]));

                label1.GetRow(1).CreateCell(16).SetCellValue(Math.Abs(CHDcal.Data[2, 0, 0]));
                label1.GetRow(1).CreateCell(17).SetCellValue(Math.Abs(CHDcal.Data[2, 1, 0]));
                label1.GetRow(1).CreateCell(18).SetCellValue(Math.Abs(CHDcal.Data[2, 2, 0]));
                label1.GetRow(1).CreateCell(19).SetCellValue(Math.Abs(CHDcal.Data[2, 3, 0]));

                label1.GetRow(1).CreateCell(20).SetCellValue(CHF1min);
                label1.GetRow(1).CreateCell(21).SetCellValue(CHF2min);
                label1.GetRow(1).CreateCell(22).SetCellValue(CHF3min);
                label1.GetRow(1).CreateCell(23).SetCellValue(CHF4min);

                label1.GetRow(1).CreateCell(24).SetCellValue(CHnum[0, 0]);
                label1.GetRow(1).CreateCell(25).SetCellValue(CHnum[0, 1]);
                label1.GetRow(1).CreateCell(26).SetCellValue(CHnum[0, 2]);
                label1.GetRow(1).CreateCell(27).SetCellValue(CHnum[0, 3]);
                label1.GetRow(1).CreateCell(28).SetCellValue(CHsumF[0, 0] * ShiftReso);
                label1.GetRow(1).CreateCell(29).SetCellValue(CHsumF[0, 1] * ShiftReso);
                label1.GetRow(1).CreateCell(30).SetCellValue(CHsumF[0, 2] * ShiftReso);
                label1.GetRow(1).CreateCell(31).SetCellValue(CHsumF[0, 3] * ShiftReso);

                FileStream streamWriterAL = new FileStream(textBox_SaveImgPath.Text + "\\" + "AutoLabelexcel.xls", FileMode.Create, FileAccess.ReadWrite);
                AutoLabelexcel.Write(streamWriterAL);
                streamWriterAL.Close();
                streamWriterAL.Dispose();


                string[] ssArray = textBox_SaveImgPath.Text.Split('\\');
                string ToolName3 = ssArray[ssArray.Length - 1];
                string ToolName2 = ssArray[ssArray.Length - 2];
                string ToolName1 = ssArray[ssArray.Length - 3];

                FileStream DatastreamWriterAL = new FileStream(datatextBox.Text + "\\"+ ToolName1 + ToolName2 + ToolName3 + ".xls", FileMode.Create, FileAccess.ReadWrite);
                AutoLabelexcel.Write(DatastreamWriterAL);

                DatastreamWriterAL.Close();
                DatastreamWriterAL.Dispose();

                //FileStream DatastreamWriterALL = new FileStream(datatextBox.Text + "\\" + name1textBox.Text + "_" + name2textBox.Text + "_" + name3textBox.Text + "_"+ "Batch" + name4textBox.Text + "_" + name5textBox.Text + name6textBox.Text  + ".xls", FileMode.Create, FileAccess.ReadWrite);

                FileStream DatastreamWriterALL = new FileStream(datatextBox.Text + "\\" + name1textBox.Text + "_" + name2textBox.Text + "_" + name3textBox.Text + "_" + "Batch" + name4textBox.Text + "_" + ToolName2 + ToolName3 + ".xls", FileMode.Create, FileAccess.ReadWrite);
                AutoLabelexcel.Write(DatastreamWriterALL);

                DatastreamWriterALL.Close();
                DatastreamWriterALL.Dispose();
            #endregion
            //}   //這邊做了一個標示else的忽略

            //計時器暫停+顯示
            stopWatch.Stop();
            TimeSpan ts1 = stopWatch.Elapsed;
            label_ms3.Text = "毫秒:" + ts1.Milliseconds.ToString();
            label_sec3.Text = "秒:" + ts1.Seconds.ToString();
            label_min3.Text = "歷程分析+自動標註時間_分:" + ts1.Minutes.ToString();
            stopWatch.Reset();
            //按鈕狀態更新
            btn_WearAnaStart.Text = "分析";
            btn_WearAnaStart.Refresh();
        }

        
        int Flute = 0;
        Image<Bgr, byte>[] VB = new Image<Bgr, byte>[4];
        Image<Bgr, byte>[] CH = new Image<Bgr, byte>[4];
        Image<Bgr, byte>[] VBCrop = new Image<Bgr, byte>[4];
        Image<Bgr, byte>[] CHCrop = new Image<Bgr, byte>[4];



        Rectangle[] VBImg_ROI = new Rectangle[4];
        Rectangle[] CHImg_ROI = new Rectangle[4];

        Rectangle[] VBImg_ROI2 = new Rectangle[4];
        Rectangle[] CHImg_ROI2 = new Rectangle[4];

        Rectangle[] VBbox_ROI = new Rectangle[4];
        Rectangle[] CHbox_ROI = new Rectangle[4];

        Rectangle ROIVB, ROICH, ROIVB2, ROICH2;
        //Image<Bgr, byte> F1Crop,F2Crop;
        Rectangle ImgboxRec;
        Rectangle ImageROItemp;

        bool IsMouseDown = false;
        Point StartLocation, EndLocation, ImageStartLocation, ImageEndLocation, curlocation;
        int X0, Y0;
        
        #region -- F1 --

        private void imgBox_VBF1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawLine(Pens.White, 0, curlocation.Y, imageBox_VB_F1.Width, curlocation.Y);
            e.Graphics.DrawLine(Pens.White, curlocation.X, 0, curlocation.X, imageBox_VB_F1.Height);
            //ImgboxRec = new Rectangle();
            //ImgboxRec = GetROI(StartLocation, EndLocation);
            if (VBbox_ROI[0] != null)
            {
                e.Graphics.DrawRectangle(Pens.Red, VBbox_ROI[0]);
            }
            else
            {
                /*
                Graphics g = this.pic_Img.CreateGraphics();
                g.Clear(this.pic_Img.BackColor);
                g.Dispose();//释放资源*/
            }

        }
        private void imgBox_VBF1_MouseDown(object sender, MouseEventArgs e)
        {
            IsMouseDown = true;
            StartLocation = e.Location;
            Utilities.ConvertCoordinates(imageBox_VB_F1, out X0, out Y0, StartLocation.X, StartLocation.Y);
            ImageStartLocation.X = X0;
            ImageStartLocation.Y = Y0;
        }
        private void imgBox_VBF1_MouseMove(object sender, MouseEventArgs e)
        {
            if (IsMouseDown == true)
            {
                EndLocation = e.Location;
                Utilities.ConvertCoordinates(imageBox_VB_F1, out X0, out Y0, EndLocation.X, EndLocation.Y);
                ImageEndLocation.X = X0;
                ImageEndLocation.Y = Y0;
                VBbox_ROI[0] = GetROI(StartLocation, EndLocation);
            }
            curlocation = e.Location;
            imageBox_VB_F1.Invalidate();
            imageBox_VB_F2.Invalidate();
            imageBox_VB_F3.Invalidate();
            imageBox_VB_F4.Invalidate();
            imageBox_CH_F1.Invalidate();
            imageBox_CH_F2.Invalidate();
            imageBox_CH_F3.Invalidate();
            imageBox_CH_F4.Invalidate();
        }
        private void imgBox_VBF1_MouseUp(object sender, MouseEventArgs e)
        {
            if (IsMouseDown == true)
            {
                EndLocation = e.Location;
                Utilities.ConvertCoordinates(imageBox_VB_F1, out X0, out Y0, EndLocation.X, EndLocation.Y);
                ImageEndLocation.X = X0;
                ImageEndLocation.Y = Y0;
                VBbox_ROI[0] = GetROI(StartLocation, EndLocation);

                IsMouseDown = false;
                VBImg_ROI[0] = GetROI(ImageStartLocation, ImageEndLocation);
                textBox3.Text = textBox3.Text + "\r\nX:" + GetROI(ImageStartLocation, ImageEndLocation).X;
                textBox3.Text = textBox3.Text + "\r\nY:" + GetROI(ImageStartLocation, ImageEndLocation).Y;
                textBox3.Text = textBox3.Text + "\r\nHeight:" + GetROI(ImageStartLocation, ImageEndLocation).Height;
                textBox3.Text = textBox3.Text + "\r\nWidth:" + GetROI(ImageStartLocation, ImageEndLocation).Width;
                textBox3.Text = textBox3.Text + "\r\n" + "------------";
                textBox3.Refresh();
            }
        }


        private void imgBox_CHF1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawLine(Pens.White, 0, curlocation.Y, imageBox_CH_F1.Width, curlocation.Y);
            e.Graphics.DrawLine(Pens.White, curlocation.X, 0, curlocation.X, imageBox_CH_F1.Height);

            //ImgboxRec = new Rectangle();
            //ImgboxRec = GetROI(StartLocation, EndLocation);
            if (CHbox_ROI[0] != null)
            {
                e.Graphics.DrawRectangle(Pens.Red, CHbox_ROI[0]);
            }
            else
            {
                /*
                Graphics g = this.pic_Img.CreateGraphics();
                g.Clear(this.pic_Img.BackColor);
                g.Dispose();//释放资源*/
            }

        }
        private void imgBox_CHF1_MouseDown(object sender, MouseEventArgs e)
        {
            IsMouseDown = true;
            StartLocation = e.Location;
            Utilities.ConvertCoordinates(imageBox_CH_F1, out X0, out Y0, StartLocation.X, StartLocation.Y);
            ImageStartLocation.X = X0;
            ImageStartLocation.Y = Y0;
        }
        private void imgBox_CHF1_MouseMove(object sender, MouseEventArgs e)
        {
            if (IsMouseDown == true)
            {
                EndLocation = e.Location;
                Utilities.ConvertCoordinates(imageBox_CH_F1, out X0, out Y0, EndLocation.X, EndLocation.Y);
                ImageEndLocation.X = X0;
                ImageEndLocation.Y = Y0;
                CHbox_ROI[0] = GetROI(StartLocation, EndLocation);

            }
            curlocation = e.Location;
            imageBox_VB_F1.Invalidate();
            imageBox_VB_F2.Invalidate();
            imageBox_VB_F3.Invalidate();
            imageBox_VB_F4.Invalidate();
            imageBox_CH_F1.Invalidate();
            imageBox_CH_F2.Invalidate();
            imageBox_CH_F3.Invalidate();
            imageBox_CH_F4.Invalidate();
        }
        private void imgBox_CHF1_MouseUp(object sender, MouseEventArgs e)
        {
            if (IsMouseDown == true)
            {
                EndLocation = e.Location;
                Utilities.ConvertCoordinates(imageBox_CH_F1, out X0, out Y0, EndLocation.X, EndLocation.Y);
                ImageEndLocation.X = X0;
                ImageEndLocation.Y = Y0;
                CHbox_ROI[0] = GetROI(StartLocation, EndLocation);

                IsMouseDown = false;
                CHImg_ROI[0] = GetROI(ImageStartLocation, ImageEndLocation);
                textBox3.Text = textBox3.Text + "\r\nX:" + GetROI(ImageStartLocation, ImageEndLocation).X;
                textBox3.Text = textBox3.Text + "\r\nY:" + GetROI(ImageStartLocation, ImageEndLocation).Y;
                textBox3.Text = textBox3.Text + "\r\nHeight:" + GetROI(ImageStartLocation, ImageEndLocation).Height;
                textBox3.Text = textBox3.Text + "\r\nWidth:" + GetROI(ImageStartLocation, ImageEndLocation).Width;
                textBox3.Text = textBox3.Text + "\r\n" + "------------";
                textBox3.Refresh();
            }
        }

        #endregion

        #region -- F2 --
        private void imgBox_VBF2_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawLine(Pens.White, 0, curlocation.Y, imageBox_VB_F2.Width, curlocation.Y);
            e.Graphics.DrawLine(Pens.White, curlocation.X, 0, curlocation.X, imageBox_VB_F2.Height);
            //ImgboxRec = new Rectangle();
            //ImgboxRec = GetROI(StartLocation, EndLocation);
            if (VBbox_ROI[1] != null)
            {
                e.Graphics.DrawRectangle(Pens.Red, VBbox_ROI[1]);
            }
            else
            {
                /*
                Graphics g = this.pic_Img.CreateGraphics();
                g.Clear(this.pic_Img.BackColor);
                g.Dispose();//释放资源*/
            }

        }
        private void imgBox_VBF2_MouseDown(object sender, MouseEventArgs e)
        {
            IsMouseDown = true;
            StartLocation = e.Location;
            Utilities.ConvertCoordinates(imageBox_VB_F2, out X0, out Y0, StartLocation.X, StartLocation.Y);
            ImageStartLocation.X = X0;
            ImageStartLocation.Y = Y0;
        }
        private void imgBox_VBF2_MouseMove(object sender, MouseEventArgs e)
        {
            if (IsMouseDown == true)
            {
                EndLocation = e.Location;
                Utilities.ConvertCoordinates(imageBox_VB_F2, out X0, out Y0, EndLocation.X, EndLocation.Y);
                ImageEndLocation.X = X0;
                ImageEndLocation.Y = Y0;
                VBbox_ROI[1] = GetROI(StartLocation, EndLocation);
            }
            curlocation = e.Location;
            imageBox_VB_F1.Invalidate();
            imageBox_VB_F2.Invalidate();
            imageBox_VB_F3.Invalidate();
            imageBox_VB_F4.Invalidate();
            imageBox_CH_F1.Invalidate();
            imageBox_CH_F2.Invalidate();
            imageBox_CH_F3.Invalidate();
            imageBox_CH_F4.Invalidate();
        }
        private void imgBox_VBF2_MouseUp(object sender, MouseEventArgs e)
        {
            if (IsMouseDown == true)
            {
                EndLocation = e.Location;
                Utilities.ConvertCoordinates(imageBox_VB_F2, out X0, out Y0, EndLocation.X, EndLocation.Y);
                ImageEndLocation.X = X0;
                ImageEndLocation.Y = Y0;
                VBbox_ROI[1] = GetROI(StartLocation, EndLocation);

                IsMouseDown = false;
                VBImg_ROI[1] = GetROI(ImageStartLocation, ImageEndLocation);
                textBox3.Text = textBox3.Text + "\r\nX:" + GetROI(ImageStartLocation, ImageEndLocation).X;
                textBox3.Text = textBox3.Text + "\r\nY:" + GetROI(ImageStartLocation, ImageEndLocation).Y;
                textBox3.Text = textBox3.Text + "\r\nHeight:" + GetROI(ImageStartLocation, ImageEndLocation).Height;
                textBox3.Text = textBox3.Text + "\r\nWidth:" + GetROI(ImageStartLocation, ImageEndLocation).Width;
                textBox3.Text = textBox3.Text + "\r\n" + "------------";
                textBox3.Refresh();
            }
        }


        private void imgBox_CHF2_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawLine(Pens.White, 0, curlocation.Y, imageBox_CH_F2.Width, curlocation.Y);
            e.Graphics.DrawLine(Pens.White, curlocation.X, 0, curlocation.X, imageBox_CH_F2.Height);

            //ImgboxRec = new Rectangle();
            //ImgboxRec = GetROI(StartLocation, EndLocation);
            if (CHbox_ROI[1] != null)
            {
                e.Graphics.DrawRectangle(Pens.Red, CHbox_ROI[1]);
            }
            else
            {
                /*
                Graphics g = this.pic_Img.CreateGraphics();
                g.Clear(this.pic_Img.BackColor);
                g.Dispose();//释放资源*/
            }

        }
        private void imgBox_CHF2_MouseDown(object sender, MouseEventArgs e)
        {
            IsMouseDown = true;
            StartLocation = e.Location;
            Utilities.ConvertCoordinates(imageBox_CH_F2, out X0, out Y0, StartLocation.X, StartLocation.Y);
            ImageStartLocation.X = X0;
            ImageStartLocation.Y = Y0;
        }
        private void imgBox_CHF2_MouseMove(object sender, MouseEventArgs e)
        {
            if (IsMouseDown == true)
            {
                EndLocation = e.Location;
                Utilities.ConvertCoordinates(imageBox_CH_F2, out X0, out Y0, EndLocation.X, EndLocation.Y);
                ImageEndLocation.X = X0;
                ImageEndLocation.Y = Y0;
                CHbox_ROI[1] = GetROI(StartLocation, EndLocation);

            }
            curlocation = e.Location;
            curlocation = e.Location;
            imageBox_VB_F1.Invalidate();
            imageBox_VB_F2.Invalidate();
            imageBox_VB_F3.Invalidate();
            imageBox_VB_F4.Invalidate();
            imageBox_CH_F1.Invalidate();
            imageBox_CH_F2.Invalidate();
            imageBox_CH_F3.Invalidate();
            imageBox_CH_F4.Invalidate();
        }
        private void imgBox_CHF2_MouseUp(object sender, MouseEventArgs e)
        {
            if (IsMouseDown == true)
            {
                EndLocation = e.Location;
                Utilities.ConvertCoordinates(imageBox_CH_F2, out X0, out Y0, EndLocation.X, EndLocation.Y);
                ImageEndLocation.X = X0;
                ImageEndLocation.Y = Y0;
                CHbox_ROI[1] = GetROI(StartLocation, EndLocation);

                IsMouseDown = false;
                CHImg_ROI[1] = GetROI(ImageStartLocation, ImageEndLocation);
                textBox3.Text = textBox3.Text + "\r\nX:" + GetROI(ImageStartLocation, ImageEndLocation).X;
                textBox3.Text = textBox3.Text + "\r\nY:" + GetROI(ImageStartLocation, ImageEndLocation).Y;
                textBox3.Text = textBox3.Text + "\r\nHeight:" + GetROI(ImageStartLocation, ImageEndLocation).Height;
                textBox3.Text = textBox3.Text + "\r\nWidth:" + GetROI(ImageStartLocation, ImageEndLocation).Width;
                textBox3.Text = textBox3.Text + "\r\n" + "------------";
                textBox3.Refresh();
            }
        }

        #endregion

        #region -- F3 --
        private void imgBox_VBF3_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawLine(Pens.White, 0, curlocation.Y, imageBox_VB_F3.Width, curlocation.Y);
            e.Graphics.DrawLine(Pens.White, curlocation.X, 0, curlocation.X, imageBox_VB_F3.Height);
            //ImgboxRec = new Rectangle();
            //ImgboxRec = GetROI(StartLocation, EndLocation);
            if (VBbox_ROI[2] != null)
            {
                e.Graphics.DrawRectangle(Pens.Red, VBbox_ROI[2]);
            }
            else
            {
                /*
                Graphics g = this.pic_Img.CreateGraphics();
                g.Clear(this.pic_Img.BackColor);
                g.Dispose();//释放资源*/
            }

        }
        private void imgBox_VBF3_MouseDown(object sender, MouseEventArgs e)
        {
            IsMouseDown = true;
            StartLocation = e.Location;
            Utilities.ConvertCoordinates(imageBox_VB_F3, out X0, out Y0, StartLocation.X, StartLocation.Y);
            ImageStartLocation.X = X0;
            ImageStartLocation.Y = Y0;
        }
        private void imgBox_VBF3_MouseMove(object sender, MouseEventArgs e)
        {
            if (IsMouseDown == true)
            {
                EndLocation = e.Location;
                Utilities.ConvertCoordinates(imageBox_VB_F3, out X0, out Y0, EndLocation.X, EndLocation.Y);
                ImageEndLocation.X = X0;
                ImageEndLocation.Y = Y0;
                VBbox_ROI[2] = GetROI(StartLocation, EndLocation);
            }
            curlocation = e.Location;
            imageBox_VB_F1.Invalidate();
            imageBox_VB_F2.Invalidate();
            imageBox_VB_F3.Invalidate();
            imageBox_VB_F4.Invalidate();
            imageBox_CH_F1.Invalidate();
            imageBox_CH_F2.Invalidate();
            imageBox_CH_F3.Invalidate();
            imageBox_CH_F4.Invalidate();
        }
        private void imgBox_VBF3_MouseUp(object sender, MouseEventArgs e)
        {
            if (IsMouseDown == true)
            {
                EndLocation = e.Location;
                Utilities.ConvertCoordinates(imageBox_VB_F3, out X0, out Y0, EndLocation.X, EndLocation.Y);
                ImageEndLocation.X = X0;
                ImageEndLocation.Y = Y0;
                VBbox_ROI[2] = GetROI(StartLocation, EndLocation);

                IsMouseDown = false;
                VBImg_ROI[2] = GetROI(ImageStartLocation, ImageEndLocation);
                textBox3.Text = textBox3.Text + "\r\nX:" + GetROI(ImageStartLocation, ImageEndLocation).X;
                textBox3.Text = textBox3.Text + "\r\nY:" + GetROI(ImageStartLocation, ImageEndLocation).Y;
                textBox3.Text = textBox3.Text + "\r\nHeight:" + GetROI(ImageStartLocation, ImageEndLocation).Height;
                textBox3.Text = textBox3.Text + "\r\nWidth:" + GetROI(ImageStartLocation, ImageEndLocation).Width;
                textBox3.Text = textBox3.Text + "\r\n" + "------------";
                textBox3.Refresh();
            }
        }


        private void imgBox_CHF3_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawLine(Pens.White, 0, curlocation.Y, imageBox_CH_F3.Width, curlocation.Y);
            e.Graphics.DrawLine(Pens.White, curlocation.X, 0, curlocation.X, imageBox_CH_F3.Height);

            //ImgboxRec = new Rectangle();
            //ImgboxRec = GetROI(StartLocation, EndLocation);
            if (CHbox_ROI[2] != null)
            {
                e.Graphics.DrawRectangle(Pens.Red, CHbox_ROI[2]);
            }
            else
            {
                /*
                Graphics g = this.pic_Img.CreateGraphics();
                g.Clear(this.pic_Img.BackColor);
                g.Dispose();//释放资源*/
            }

        }
        private void imgBox_CHF3_MouseDown(object sender, MouseEventArgs e)
        {
            IsMouseDown = true;
            StartLocation = e.Location;
            Utilities.ConvertCoordinates(imageBox_CH_F3, out X0, out Y0, StartLocation.X, StartLocation.Y);
            ImageStartLocation.X = X0;
            ImageStartLocation.Y = Y0;
        } 

        private void folderBrowserDialog_imgpath_HelpRequest(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e) //0222新增 移至拆裝刀位置按鈕
        {

            if (radioButton_abs.Checked == true)  //此處設想是向上移方便換刀
            {
                TarPosition_Img = int.Parse(textBox_Img_TarPosi.Text); //這邊要重新設定要到達多高(待測試)
            }
            else
            {
                TarPosition_Img = int.Parse(textBox_Img_TarPosi.Text) + CurPosition_Img;
            }
            TarSpeed_Img = int.Parse(textBox_Img_TarSpeed.Text);
            TarAcc_Img = int.Parse(textBox_Img_TarAcc.Text);

            try
            {
                if (serialPort_image.IsOpen)
                {
                    serialPort_image.Write("P.1=" + TarPosition_Img.ToString() + '\r'); //至動在這邊用複寫模式
                    serialPort_image.Write("S.1=" + TarSpeed_Img.ToString() + '\r');
                    serialPort_image.Write("A.1=" + TarAcc_Img.ToString() + '\r');
                    serialPort_image.Write("^.1" + '\r');

                    textBox_Img_CurPosi.Text = TarPosition_Img.ToString(); //顯示也會被新數值取代
                    CurPosition_Img = TarPosition_Img;
                    TarPosition_Img = 0;
                    TarAcc_Img = 0;
                    TarSpeed_Img = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Button2_Click(object sender, EventArgs e) //0222新增 回復到量測位置
        {
            if (radioButton_abs.Checked == true)  //與前面程式互相對應
            {
                TarPosition_Img = -int.Parse(textBox_Img_TarPosi.Text); //這邊要重新設定要到達多高(待測試)
            }
            else
            {
                TarPosition_Img = -int.Parse(textBox_Img_TarPosi.Text) + CurPosition_Img;
            }
            TarSpeed_Img = int.Parse(textBox_Img_TarSpeed.Text);
            TarAcc_Img = int.Parse(textBox_Img_TarAcc.Text);

            try
            {
                if (serialPort_image.IsOpen)
                {
                    serialPort_image.Write("P.1=" + TarPosition_Img.ToString() + '\r'); //至動在這邊用複寫模式
                    serialPort_image.Write("S.1=" + TarSpeed_Img.ToString() + '\r');
                    serialPort_image.Write("A.1=" + TarAcc_Img.ToString() + '\r');
                    serialPort_image.Write("^.1" + '\r');

                    textBox_Img_CurPosi.Text = TarPosition_Img.ToString(); //顯示也會被新數值取代
                    CurPosition_Img = TarPosition_Img;
                    TarPosition_Img = 0;
                    TarAcc_Img = 0;
                    TarSpeed_Img = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void textBox_Tool_TarPosi_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox_Tool_TarSpeed_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox_Move_Enter(object sender, EventArgs e)
        {

        }

        private void textBox_TotalFrame_TextChanged(object sender, EventArgs e)
        {

        }

        private void label_TotalFrame_Click(object sender, EventArgs e)
        {

        }

        private void textBox_MoveName_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox_folderPath_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox_Pixelsize_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox_FrameFile_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox_FilePath_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox_SaveImgPath_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkBox_saveImage_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label_min_Click(object sender, EventArgs e)
        {

        }

        private void label_s_Click(object sender, EventArgs e)
        {

        }

        private void label_ms_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label_Max_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox_FrameFile_TextChanged_1(object sender, EventArgs e)
        {

        }
        #endregion
        private void btn_FrameFile_Click_1(object sender, EventArgs e)  //0423 更新btn
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Title = "Select file";
            dialog.ShowDialog();
            textBox_FrameFile.Text = dialog.FileName;
        }

        private void button4_Click(object sender, EventArgs e)  //btn_sep_path 0423不知為何改不掉
        {
            FolderBrowserDialog LoadPath = new FolderBrowserDialog();
            if (LoadPath.ShowDialog() == DialogResult.OK)
            {
               textBox_seppath.Text = LoadPath.SelectedPath;
                //textBox_SaveImgPath.Text = textBox_LoadVideoPath.Text;
            }
        }

        private void checkBox_notsave_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void textBox_seppath_TextChanged(object sender, EventArgs e)
        {

        }

        private void label_VideoPath_Click(object sender, EventArgs e)
        {

        }

        private void button_videosel_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Title = "Select file";
            dialog.ShowDialog();
            textBox_videosel.Text = dialog.FileName;
        }

        private void textBox_videosel_TextChanged(object sender, EventArgs e)
        {

        }

        private void btn_ReconStart2_Click(object sender, EventArgs e)  //高倍率重建演算法
        {
            if (textBox_LoadVideoPath.Text != String.Empty)
            {
                //計時器宣告+啟動
                Stopwatch stopWatch = new Stopwatch();
                stopWatch.Start();
                //按鈕狀態更新
                btn_ReconStart2.Text = "HR正在重建...";
                btn_ReconStart2.Refresh();

                // 目錄下檔案個數
                #region -- FileCount --
                DirectoryInfo DiFolder = new DirectoryInfo(textBox_LoadVideoPath.Text + "\\Raw\\");
                FileInfo[] files = DiFolder.GetFiles("*.tif");
                int width;
                if (files.Length >= 1000)
                {
                    width = 1000;
                }
                else
                {
                    width = files.Length;
                }
                #endregion

                //區域變數宣告
                #region -- variable setting --
                Image<Gray, byte> LoadImage = new Image<Gray, byte>(2048, 1536);
                Image<Gray, byte> threshImage = new Image<Gray, byte>(2048, 1536);
                //Image<Gray, byte> singleCol = new Image<Gray, byte>(2048, 1);

                // Image<Gray, UInt16> temp = new Image<Gray, UInt16>(width, 2048);
                Image<Gray, UInt16> tempHR = new Image<Gray, UInt16>(width, 2048); //創造H邊界 0503
                // temp.SetValue(0);
                tempHR.SetValue(0);

                // int[] downedge = new int[width];
                int[] HRedgecount = new int[width]; // 每張圖陣列點的相對最高點(陣列min) 0503


                // int upedgeDistance = 1600;
                int HRedgeDis = 1000; //HR的高度取1000 0503
                //int edgeDis = 1027; //這邊要思考一下可以取到多少是適合的 學長2048取1600 目前低倍率高度是1536該取多少 0407
                //int edgeerr = 26; // 這邊是去掉非觀測刃部分的數值 目前設計為26pixel 待驗證 0409

                double[] minValues;
                double[] maxValues;

                Point[] minLocations;
                Point[] maxLocations; //這邊不確定需不需要重設 0407


                int ImageName;
                #endregion

                //重建迴圈
                #region -- Reconstruction --
                for (int fignum = 1; fignum <= width; fignum++)
                {
                    ImageName = files.Length - 1000 + fignum;
                    LoadImage = new Image<Gray, byte>(textBox_LoadVideoPath.Text + "\\Raw\\" + ImageName.ToString() + ".tif");
                    CvInvoke.Threshold(LoadImage, threshImage, 0, 220, ThresholdType.Otsu);

                    for (int row = threshImage.Rows - 1; row >= 0; row--)     //下往上 
                    {
                        for (int column = threshImage.Cols - 1; column >= threshImage.Cols ; column--)  //邊界0503    
                        {
                            if (threshImage.Data[row, column, 0] == 0)
                            {
                                tempHR.Data[row, fignum - 1, 0] = (ushort)column;
                                HRedgecount[fignum - 1] = row;
                                break;
                            }
                        }
                    }
                    LoadImage.Dispose();
                }
                threshImage.Dispose();
                #endregion

                //重建後Raw剪裁存檔
                #region -- Raw-- 

                //Raw剪裁存檔
                // int upedge = downedge.Max() - upedgeDistance;
                int HRedge = HRedgecount.Min();

                /*
                Rectangle region = new Rectangle(0, upedge, temp.Cols, upedgeDistance);
                Image<Gray, UInt16> profileRaw = new Image<Gray, UInt16>(region.Size);
                profileRaw = temp.Copy(region);
                profileRaw.Save(textBox_LoadVideoPath.Text + "\\" + "ReconRaw.Tif");  */

                Rectangle HRregion = new Rectangle(0, HRedge, tempHR.Cols, HRedgeDis); // 這邊多設定 HRedge+edgeerr???待看 0503

               

                Image<Gray, UInt16> HRprofileRaw = new Image<Gray, UInt16>(HRregion.Size);// 將 HRregion區域框起來存取 存成ReconRaw.tif型式
                HRprofileRaw = tempHR.Copy(HRregion);
                HRprofileRaw.Save(textBox_LoadVideoPath.Text + "\\" + "HReconRaw.Tif");

                //NormalizeGray存檔

                /*profileRaw.MinMax(out minValues, out maxValues, out minLocations, out maxLocations);
                Image<Gray, Byte> profileNorm = new Image<Gray, Byte>(profileRaw.Size);
                profileNorm = profileRaw.ConvertScale<Byte>((256 / (maxValues[0] - minValues[0])), minValues[0]);
                profileNorm.Save(textBox_LoadVideoPath.Text + "\\" + "ReconNormalGray.Tif");*/
                string SaveDirIP = textBox_LoadVideoPath.Text + "\\imgprocess\\";    //創造新的資料夾把非raw檔案存進去
                if (Directory.Exists(SaveDirIP))
                {
                }
                else
                {
                    Directory.CreateDirectory(@SaveDirIP);
                }

                HRprofileRaw.MinMax(out minValues, out maxValues, out minLocations, out maxLocations);//數據歸一化後存成NormalGray灰階.tif 0503
                Image<Gray, Byte> HRprofileNorm = new Image<Gray, Byte>(HRprofileRaw.Size);
                HRprofileNorm = HRprofileRaw.ConvertScale<Byte>((256 / (maxValues[0] - minValues[0])), minValues[0]);
                HRprofileNorm.Save(SaveDirIP + "\\" + "HReconNormalGray.Tif");//存到新資料夾imgprocess 用SaveDirIP路徑 0503

                //NormalizeJet存檔

                /*CvInvoke.ApplyColorMap(profileNorm, profileNorm, ColorMapType.Jet);
                profileNorm.Save(textBox_LoadVideoPath.Text + "\\" + "ReconNormalJet.Tif");*/
                CvInvoke.ApplyColorMap(HRprofileNorm, HRprofileNorm, ColorMapType.Jet);
                HRprofileNorm.Save(SaveDirIP + "\\" + "HReconNormalJet.Tif");//轉成Jet檔案 0408
                #endregion

                //Projection剪裁存檔
                #region -- Projection--

                //resize
                /*double Ladj = LprofileRaw.Cols * (toolRadius * Math.PI / LprofileRaw.Cols) / systemResolutionL; //resize兩邊分開做 0408
                double Radj = RprofileRaw.Cols * (toolRadius * Math.PI / RprofileRaw.Cols) / systemResolutionL;
                LprofileRaw = LprofileRaw.Resize((int)(Ladj), LprofileRaw.Rows, Inter.Cubic);
                RprofileRaw = RprofileRaw.Resize((int)(Radj), RprofileRaw.Rows, Inter.Cubic);

                //正射投影
                Image<Gray, UInt16> LprofileRawPro = new Image<Gray, UInt16>(LprofileRaw.Size);  //進行正射0408
                for (int row = 0; row < LprofileRawPro.Rows; row++)
                {
                    for (int column = 0; column < LprofileRawPro.Cols; column++)
                    {
                        LprofileRawPro.Data[row, column, 0] = LprofileRaw.Data[row, ((column + row) % LprofileRawPro.Cols), 0];
                    }
                }
                Image<Gray, UInt16> RprofileRawPro = new Image<Gray, UInt16>(RprofileRaw.Size);
                for (int row = 0; row < RprofileRawPro.Rows; row++)
                {
                    for (int column = 0; column < RprofileRawPro.Cols; column++)
                    {
                        RprofileRawPro.Data[row, column, 0] = RprofileRaw.Data[row, ((column + row) % RprofileRawPro.Cols), 0];
                    }
                }

                //正射投影後resize
                LprofileRawPro = LprofileRawPro.Resize(1000, LprofileRawPro.Rows, Inter.Cubic);
                LprofileRawPro.Save(textBox_LoadVideoPath.Text + "\\" + "LReconRawPro.Tif");
                RprofileRawPro = RprofileRawPro.Resize(1000, RprofileRawPro.Rows, Inter.Cubic);
                RprofileRawPro.Save(textBox_LoadVideoPath.Text + "\\" + "RReconRawPro.Tif");

                //正射後NormalizeGray存檔
                LprofileRawPro.MinMax(out minValues, out maxValues, out minLocations, out maxLocations);
                Image<Gray, Byte> LprofileNormPro = new Image<Gray, Byte>(LprofileRawPro.Size);
                LprofileNormPro = LprofileRawPro.ConvertScale<Byte>((256 / (maxValues[0] - minValues[0])), minValues[0]);
                LprofileNormPro.Save(textBox_LoadVideoPath.Text + "\\" + "LReconNormalProGray.Tif");
                RprofileRawPro.MinMax(out minValues, out maxValues, out minLocations, out maxLocations);
                Image<Gray, Byte> RprofileNormPro = new Image<Gray, Byte>(RprofileRawPro.Size);
                RprofileNormPro = RprofileRawPro.ConvertScale<Byte>((256 / (maxValues[0] - minValues[0])), minValues[0]);
                RprofileNormPro.Save(textBox_LoadVideoPath.Text + "\\" + "RReconNormalProGray.Tif");

                //正射後NormalizeJet存檔
                CvInvoke.ApplyColorMap(LprofileNormPro, LprofileNormPro, ColorMapType.Jet);
                LprofileNormPro.Save(textBox_LoadVideoPath.Text + "\\" + "LReconNormalProJet.Tif"); 
                CvInvoke.ApplyColorMap(RprofileNormPro, RprofileNormPro, ColorMapType.Jet);
                RprofileNormPro.Save(textBox_LoadVideoPath.Text + "\\" + "RReconNormalProJet.Tif");*/
                #endregion

                //IamgeBox顯示
                #region -- Imagebox-- 
                imgBox_RToolReconMap.Image = HRprofileNorm;//顯示視窗重建正射照片 0503
                #endregion


                //計時器暫停+顯示
                stopWatch.Stop();
                TimeSpan ts1 = stopWatch.Elapsed;
                label_ms.Text = "毫秒:" + ts1.Milliseconds.ToString();
                label_s.Text = "秒:" + ts1.Seconds.ToString();
                label_min.Text = "三維重建時間_分:" + ts1.Minutes.ToString();
                stopWatch.Reset();


                //按鈕狀態更新
                btn_ReconStart2.Text = "高倍率重建 ";
                btn_ReconStart2.Refresh();
            }
        }

        private void btn_period_Click(object sender, EventArgs e) //標註excel存檔
        {
            #region -- 變數宣告0621 --

            /*
            string SaveDirIPC = textBox_SaveImgPath.Text;
            double[] minValues;
            double[] maxValues;
            double d;
            Int32 dd;
            Point[] minLocations;
            Point[] maxLocations;
            Image<Gray, UInt16> Lperiod = new Image<Gray, UInt16>(SaveDirIPC + "\\" + "LWearDepthRaw.Tif");
            Image<Gray, UInt16> Rperiod = new Image<Gray, UInt16>(SaveDirIPC + "\\" + "RWearDepthRaw.Tif");
            Image<Gray, Byte> Ltemp = new Image<Gray, Byte>(Lperiod.Size);
            Image<Gray, UInt16> zeromap = new Image<Gray, UInt16>(1,1);
            Image<Gray, UInt16> numbermap = new Image<Gray, UInt16>(1, 1);
            zeromap.SetValue(0);
            //int[] nums = new uint[];
            //nums = Array.Sort(Lperiod);
            //Array.Reverse(nums);
            Gray media;
            MCvScalar desest;
            MCvScalar mediaValue;

            Rectangle ROISLT, ROILT;
            Image<Gray, UInt16> SLTool = new Image<Gray, UInt16>(Lperiod.Cols, 1);
            Lperiod.AvgSdv(out media, out desest);
            mediaValue = media.MCvScalar;
            d = media.Intensity; //這邊做兩個不確定何者會是灰階平均數
            dd = (int)(d);
            var ddd = (d);
            numbermap[1, 1] = media;
            bool a;

            for (int arraynum = 1; arraynum <= 1000; arraynum++)
            {
                for (int column = 1; column <= 1000; column++)
                {
                    switch 
                        
                    Lperiod[arraynum, column] >= 0
                    {

                    }




                    if (a = true)
                    {
                        Ltemp[arraynum, column] = Lperiod[arraynum, column];
                    }

                    else
                    {
                        Ltemp[arraynum, column] = zeromap[1, 1];
                    }

                }


            }


        */
            


            /*
            #region -- variable setting --
            string SaveDirIPC = textBox_SaveImgPath.Text ;    //路徑IP_Compare 0506 這邊改用recon不用做過nmlz
            Image<Gray, UInt16> Lperiod = new Image<Gray, UInt16>(1000, 1000); //創造左右period取樣暫存 0506
            Image<Gray, UInt16> Lerrorm = new Image<Gray, UInt16>(1000, 1000); //創造左右period取樣暫存 0506

            double[] minValues;
            double[] maxValues;

            Point[] minLocations;
            Point[] maxLocations; 
            // temp.SetValue(0);
            Lperiod.SetValue(0);
            Lerrorm.SetValue(0);

            Image<Gray, UInt16> LTool = new Image<Gray, UInt16>(SaveDirIPC + "\\" + "LWearDepthRaw.Tif");

            Rectangle ROISLT, ROILT;
            ROISLT = new Rectangle(0, 0, 1000, 1); //取最後一列
            Image<Gray, UInt16> SLTool = new Image<Gray, UInt16>(LTool.Cols, 1);
            SLTool = LTool.Copy(ROISLT);

            for (UInt16 i = 1; i<1000; i++)
            {
                for (UInt16 j = 1; j < 1000; j++)
                {
                    Lerrorm[i, j] = SLTool[i,1];
                }
            }
            Lperiod = SLTool.AbsDiff(Lerrorm);
            Lperiod.Save(textBox_SaveImgPath.Text + "\\" + "PeriodmapL.Tif");

            Lperiod.MinMax(out minValues, out maxValues, out minLocations, out maxLocations);//數據歸一化後存成NormalGray灰階.tif 0503
            Image<Gray, Byte> LperiodNorm = new Image<Gray, Byte>(Lperiod.Size);
            LperiodNorm = Lperiod.ConvertScale<Byte>((256 / (maxValues[0] - minValues[0])), minValues[0]);
            LperiodNorm.Save(SaveDirIPC + "\\" + "PeriodmapLGray.Tif");//存到新資料夾imgprocess 用SaveDirIP路徑 0503

            //NormalizeJet存檔
            */
            /*
            CvInvoke.ApplyColorMap(profileNorm, profileNorm, ColorMapType.Jet);
            profileNorm.Save(textBox_LoadVideoPath.Text + "\\" + "ReconNormalJet.Tif");*/
            /*CvInvoke.ApplyColorMap(LperiodNorm, LperiodNorm, ColorMapType.Jet);
            LperiodNorm.Save(SaveDirIPC + "\\" + "PeriodmapLJet.Tif"); */
            //轉成Jet檔案 0408
            //---//

            /*//載入原圖
            Image<Gray, UInt16> LToolT = new Image<Gray, UInt16>(textBox_SaveImgPath.Text + "\\" + "LReconRaw.Tif");
            Image<Gray, UInt16> RToolT = new Image<Gray, UInt16>(textBox_SaveImgPath.Text + "\\" + "RReconRaw.Tif");
            Rectangle ROIEM;
            ROIEM = new Rectangle(0, 26, 1000, 1000);
            Image<Gray, UInt16> LTool = new Image<Gray, UInt16>(1000, 1000);
            Image<Gray, UInt16> RTool = new Image<Gray, UInt16>(1000, 1000);
            LTool = LToolT.Copy(ROIEM);   //先做一次裁減

            //宣告多維Image

            Image<Gray, double> SerrorL = new Image<Gray, double>(LTool.Cols, 1);
            Image<Gray, double> minerrorL = new Image<Gray, double>(10, 1);
            Image<Gray, double> minposiL = new Image<Gray, double>(10, 1);
            Image<Gray, double> SerrorR = new Image<Gray, double>(RTool.Cols, 1);
            Image<Gray, double> minerrorR = new Image<Gray, double>(10, 1);
            Image<Gray, double> minposiR = new Image<Gray, double>(10, 1);

            // 宣告指標變數
            Point[] minLocationsL, maxLocationsL;
            Point[] minLocationsR, maxLocationsR;


            //宣告平移計算變數
            Image<Gray, UInt16> PeriodmapL = new Image<Gray, UInt16>(LTool.Size);
            Image<Gray, UInt16> SLTool = new Image<Gray, UInt16>(LTool.Cols, 1);
            Image<Gray, UInt16> SNewToolshiftL = new Image<Gray, UInt16>(LTool.Cols,1);
            Image<Gray, UInt16> SerrormapL = new Image<Gray, UInt16>(LTool.Cols, 1);
            Image<Gray, UInt16> TempSLA, TempSLB;
            Rectangle ROISL,ROISLT, ROISLA, ROISLB;
            ROISL = new Rectangle(0, 999, LTool.Cols, 1);
            double[] minValuesL, maxValuesL;

            //載入並複製
            SLTool = LTool.Copy(ROISL);

            //計算差值
            for (UInt16 N = 0; N < 999 ; N++)  //沿著row逐行下去算
            {                                
                ROISLT = new Rectangle(0, N, 1000, 1);
                SNewToolshiftL = LTool.Copy(ROISLT);

                for (UInt16 shiftL = 1; shiftL < 1000; shiftL++) //沿著column比較errror差異值
                { 
                    SerrormapL = SLTool.AbsDiff(SNewToolshiftL); //首項不被迴圈規範
                    SerrorL[0, 0] = SerrormapL.GetAverage();
                    ROISLA = new Rectangle(0, N, LTool.Cols - 1, 1);
                    ROISLB = new Rectangle(LTool.Cols - 1, N, 1, 1);

                    TempSLA = SNewToolshiftL.Copy(ROISLA);
                    TempSLB = SNewToolshiftL.Copy(ROISLB);

                    SNewToolshiftL = TempSLB.ConcateHorizontal(TempSLA);
                    
                    TempSLA.Dispose();
                    TempSLB.Dispose();

                    SerrormapL = SLTool.AbsDiff(SNewToolshiftL);
                    SerrorL[0, shiftL] = SerrormapL.GetAverage();
                    SerrormapL.Dispose();

                    //計算磨耗最小值的column數
                    SerrorL.MinMax(out minValuesL, out maxValuesL, out minLocationsL, out maxLocationsL);
                    minerrorL.Data[0, 0, 0] = minValuesL[0];
                    minposiL.Data[0, 0, 0] = minLocationsL[0].X;
                }

                SLTool = LTool.Copy(ROISL);

                UInt16 shiftL2 = (ushort)minposiL.Data[0, 0, 0];
                ROISLA = new Rectangle(0, N, SLTool.Cols - shiftL2,1);
                ROISLB = new Rectangle(SLTool.Cols - shiftL2 - 1, N, shiftL2,1);

                if (ROISLB.Width == 0)      //判斷式除錯 0506
                {
                    TempSLA = LTool.Copy(ROISLA);
                    SNewToolshiftL = TempSLA.Copy();
                }
                else
                {
                    TempSLA = LTool.Copy(ROISLA);
                    TempSLB = LTool.Copy(ROISLB);

                    SNewToolshiftL = TempSLB.ConcateHorizontal(TempSLA);
                }
                SerrormapL = SNewToolshiftL.AbsDiff(SLTool);//這邊注意到底怎麼寫逐行把圖拚出來的方式 0506
                for (UInt16 j = 1; j < 1000; j++)
                {
                    PeriodmapL[N, j] = SerrormapL[N, j];
                }
            }
            //存檔
            PeriodmapL.Save(textBox_SaveImgPath.Text + "\\" + "PeriodmapL.Tif");


            //---//
            
            //紀錄 file*/
        }
            


        private void imageBox_VB_F1_Click(object sender, EventArgs e)
        {

        }

        private void rabtn_VB1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btn_NextFlute_Click(object sender, EventArgs e)
        {

        }

        private void btn_PreviousFlute_Click(object sender, EventArgs e)
        {

        }

        private void label_min3_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label_extimeSetting_Click(object sender, EventArgs e)
        {

        }

        private void label_EXTime_Click(object sender, EventArgs e)
        {

        }

        private void label_FPS_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void comboBox_Port1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox_Port2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click_1(object sender, EventArgs e)
        {

        }

        private void tabPage4_Click(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click_2(object sender, EventArgs e)
        {
            btn_Connect.Enabled = true;
            btn_Disconnect.Enabled = false;
            try
            {
                serialPort_tool.Close();
                serialPort_image.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btn_Connect.Enabled = false;
                btn_Disconnect.Enabled = true;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            btn_Connect.Enabled = false;
            btn_Disconnect.Enabled = true;
            try
            {
                serialPort_tool.PortName = comboBox_Port1.Text;
                serialPort_tool.BaudRate = 38400;
                serialPort_tool.Parity = Parity.None;
                serialPort_tool.DataBits = 8;
                serialPort_tool.StopBits = StopBits.One;
                serialPort_tool.Open();

                serialPort_image.PortName = comboBox_Port2.Text;
                serialPort_image.BaudRate = 38400;
                serialPort_image.Parity = Parity.None;
                serialPort_image.DataBits = 8;
                serialPort_image.StopBits = StopBits.One;
                serialPort_image.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btn_Connect.Enabled = true;
                btn_Disconnect.Enabled = false;
            }
            try
            {
                if (serialPort_tool.IsOpen)
                {
                    serialPort_tool.Write("|2.1" + '\r');
                    textBox_Tool_CurPosi.Text = "0";
                    CurPosition_Tool = 0;
                }
                if (serialPort_image.IsOpen)
                {
                    serialPort_image.Write("|2.1" + '\r');
                    textBox_Img_CurPosi.Text = "0";
                    CurPosition_Img = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBox_autolabel_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox_WearDepthOutput_TextChanged(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void labeling_min_Click(object sender, EventArgs e)
        {

        }

        private void label_FilePath2_Click(object sender, EventArgs e)
        {

        }

        private void datatextBox_TextChanged(object sender, EventArgs e)
        {

        }



        private void button4_Click_4(object sender, EventArgs e)
        {
            FolderBrowserDialog SavexmlPath = new FolderBrowserDialog();
            if (SavexmlPath.ShowDialog() == DialogResult.OK)
            {
                datatextBox.Text = SavexmlPath.SelectedPath;
            }
        }

        private void imgBox_RToolReconMap_Click(object sender, EventArgs e)
        {

        }

        private void textBox_Img_TarAcc_TextChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            btn_Connect.Enabled = true;
            btn_Disconnect.Enabled = false;
            try
            {
                serialPort_tool.Close();
                serialPort_image.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btn_Connect.Enabled = false;
                btn_Disconnect.Enabled = true;
            }
        }

        private void groupBox_motor_Enter(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void name1textBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void name3textBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void imgBox_CHF3_MouseMove(object sender, MouseEventArgs e)
        #region
        {
            if (IsMouseDown == true)
            {
                EndLocation = e.Location;
                Utilities.ConvertCoordinates(imageBox_CH_F3, out X0, out Y0, EndLocation.X, EndLocation.Y);
                ImageEndLocation.X = X0;
                ImageEndLocation.Y = Y0;
                CHbox_ROI[2] = GetROI(StartLocation, EndLocation);

            }
            curlocation = e.Location;
            curlocation = e.Location;
            imageBox_VB_F1.Invalidate();
            imageBox_VB_F2.Invalidate();
            imageBox_VB_F3.Invalidate();
            imageBox_VB_F4.Invalidate();
            imageBox_CH_F1.Invalidate();
            imageBox_CH_F2.Invalidate();
            imageBox_CH_F3.Invalidate();
            imageBox_CH_F4.Invalidate();
        }
        private void imgBox_CHF3_MouseUp(object sender, MouseEventArgs e)
        {
            if (IsMouseDown == true)
            {
                EndLocation = e.Location;
                Utilities.ConvertCoordinates(imageBox_CH_F3, out X0, out Y0, EndLocation.X, EndLocation.Y);
                ImageEndLocation.X = X0;
                ImageEndLocation.Y = Y0;
                CHbox_ROI[2] = GetROI(StartLocation, EndLocation);

                IsMouseDown = false;
                CHImg_ROI[2] = GetROI(ImageStartLocation, ImageEndLocation);
                textBox3.Text = textBox3.Text + "\r\nX:" + GetROI(ImageStartLocation, ImageEndLocation).X;
                textBox3.Text = textBox3.Text + "\r\nY:" + GetROI(ImageStartLocation, ImageEndLocation).Y;
                textBox3.Text = textBox3.Text + "\r\nHeight:" + GetROI(ImageStartLocation, ImageEndLocation).Height;
                textBox3.Text = textBox3.Text + "\r\nWidth:" + GetROI(ImageStartLocation, ImageEndLocation).Width;
                textBox3.Text = textBox3.Text + "\r\n" + "------------";
                textBox3.Refresh();
            }
        }

        #endregion

        #region -- F4 --
        private void imgBox_VBF4_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawLine(Pens.White, 0, curlocation.Y, imageBox_VB_F4.Width, curlocation.Y);
            e.Graphics.DrawLine(Pens.White, curlocation.X, 0, curlocation.X, imageBox_VB_F4.Height);
            //ImgboxRec = new Rectangle();
            //ImgboxRec = GetROI(StartLocation, EndLocation);
            if (VBbox_ROI[3] != null)
            {
                e.Graphics.DrawRectangle(Pens.Red, VBbox_ROI[3]);
            }
            else
            {
                /*
                Graphics g = this.pic_Img.CreateGraphics();
                g.Clear(this.pic_Img.BackColor);
                g.Dispose();//释放资源*/
            }

        }
        private void imgBox_VBF4_MouseDown(object sender, MouseEventArgs e)
        {
            IsMouseDown = true;
            StartLocation = e.Location;
            Utilities.ConvertCoordinates(imageBox_VB_F4, out X0, out Y0, StartLocation.X, StartLocation.Y);
            ImageStartLocation.X = X0;
            ImageStartLocation.Y = Y0;
        }
        private void imgBox_VBF4_MouseMove(object sender, MouseEventArgs e)
        {
            if (IsMouseDown == true)
            {
                EndLocation = e.Location;
                Utilities.ConvertCoordinates(imageBox_VB_F4, out X0, out Y0, EndLocation.X, EndLocation.Y);
                ImageEndLocation.X = X0;
                ImageEndLocation.Y = Y0;
                VBbox_ROI[3] = GetROI(StartLocation, EndLocation);

            }
            curlocation = e.Location;
            curlocation = e.Location;

            imageBox_VB_F1.Invalidate();
            imageBox_VB_F2.Invalidate();
            imageBox_VB_F3.Invalidate();
            imageBox_VB_F4.Invalidate();
            imageBox_CH_F1.Invalidate();
            imageBox_CH_F2.Invalidate();
            imageBox_CH_F3.Invalidate();
            imageBox_CH_F4.Invalidate();
        }
        private void imgBox_VBF4_MouseUp(object sender, MouseEventArgs e)
        {
            if (IsMouseDown == true)
            {
                EndLocation = e.Location;
                Utilities.ConvertCoordinates(imageBox_VB_F4, out X0, out Y0, EndLocation.X, EndLocation.Y);
                ImageEndLocation.X = X0;
                ImageEndLocation.Y = Y0;
                VBbox_ROI[3] = GetROI(StartLocation, EndLocation);

                IsMouseDown = false;
                VBImg_ROI[3] = GetROI(ImageStartLocation, ImageEndLocation);
                textBox3.Text = textBox3.Text + "\r\nX:" + GetROI(ImageStartLocation, ImageEndLocation).X;
                textBox3.Text = textBox3.Text + "\r\nY:" + GetROI(ImageStartLocation, ImageEndLocation).Y;
                textBox3.Text = textBox3.Text + "\r\nHeight:" + GetROI(ImageStartLocation, ImageEndLocation).Height;
                textBox3.Text = textBox3.Text + "\r\nWidth:" + GetROI(ImageStartLocation, ImageEndLocation).Width;
                textBox3.Text = textBox3.Text + "\r\n" + "------------";
                textBox3.Refresh();
            }
        }


        private void imgBox_CHF4_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawLine(Pens.White, 0, curlocation.Y, imageBox_CH_F4.Width, curlocation.Y);
            e.Graphics.DrawLine(Pens.White, curlocation.X, 0, curlocation.X, imageBox_CH_F4.Height);

            //ImgboxRec = new Rectangle();
            //ImgboxRec = GetROI(StartLocation, EndLocation);
            if (CHbox_ROI[3] != null)
            {
                e.Graphics.DrawRectangle(Pens.Red, CHbox_ROI[3]);
            }
            else
            {
                /*
                Graphics g = this.pic_Img.CreateGraphics();
                g.Clear(this.pic_Img.BackColor);
                g.Dispose();//释放资源*/
            }

        }
        private void imgBox_CHF4_MouseDown(object sender, MouseEventArgs e)
        {
            IsMouseDown = true;
            StartLocation = e.Location;
            Utilities.ConvertCoordinates(imageBox_CH_F4, out X0, out Y0, StartLocation.X, StartLocation.Y);
            ImageStartLocation.X = X0;
            ImageStartLocation.Y = Y0;
        }
        private void imgBox_CHF4_MouseMove(object sender, MouseEventArgs e)
        {
            if (IsMouseDown == true)
            {
                EndLocation = e.Location;
                Utilities.ConvertCoordinates(imageBox_CH_F4, out X0, out Y0, EndLocation.X, EndLocation.Y);
                ImageEndLocation.X = X0;
                ImageEndLocation.Y = Y0;
                CHbox_ROI[3] = GetROI(StartLocation, EndLocation);

            }
            curlocation = e.Location;
            curlocation = e.Location;

            imageBox_VB_F1.Invalidate();
            imageBox_VB_F2.Invalidate();
            imageBox_VB_F3.Invalidate();
            imageBox_VB_F4.Invalidate();
            imageBox_CH_F1.Invalidate();
            imageBox_CH_F2.Invalidate();
            imageBox_CH_F3.Invalidate();
            imageBox_CH_F4.Invalidate();
        }
        private void imgBox_CHF4_MouseUp(object sender, MouseEventArgs e)
        {
            if (IsMouseDown == true)
            {
                EndLocation = e.Location;
                Utilities.ConvertCoordinates(imageBox_CH_F4, out X0, out Y0, EndLocation.X, EndLocation.Y);
                ImageEndLocation.X = X0;
                ImageEndLocation.Y = Y0;
                CHbox_ROI[3] = GetROI(StartLocation, EndLocation);

                IsMouseDown = false;
                CHImg_ROI[3] = GetROI(ImageStartLocation, ImageEndLocation);


                textBox3.Text = textBox3.Text + "\r\nX:" + GetROI(ImageStartLocation, ImageEndLocation).X;
                textBox3.Text = textBox3.Text + "\r\nY:" + GetROI(ImageStartLocation, ImageEndLocation).Y;
                textBox3.Text = textBox3.Text + "\r\nHeight:" + GetROI(ImageStartLocation, ImageEndLocation).Height;
                textBox3.Text = textBox3.Text + "\r\nWidth:" + GetROI(ImageStartLocation, ImageEndLocation).Width;
                textBox3.Text = textBox3.Text + "\r\n" + "------------";
                textBox3.Refresh();
            }
        }

        #endregion
        
        private Rectangle GetROI(Point Start, Point End)
        {
            ImageROItemp = new Rectangle();
            ImageROItemp.X = Math.Min(Start.X, End.X);
            ImageROItemp.Y = Math.Min(Start.Y, End.Y);
            ImageROItemp.Width = Math.Abs(Start.X - End.X);
            ImageROItemp.Height = Math.Abs(Start.Y - End.Y);
            return ImageROItemp;
        }

        private void btn_crop_Click(object sender, EventArgs e)
        {
            for (int Flute = 1; Flute <= 4; Flute++)
            {
                if (!VBImg_ROI[Flute - 1].IsEmpty)
                {
                    int X = 0;
                    int Height = (int)(systemResolution * 1600 / double.Parse(textBox_MicroReso.Text));
                    int Width = VB[Flute - 1].Width;
                    int Y = VBImg_ROI[Flute - 1].Y + VBImg_ROI[Flute - 1].Height - Height;
                    VBImg_ROI2[Flute - 1] = new Rectangle(X, Y, Width, Height);

                    VBCrop[Flute - 1] = new Image<Bgr, byte>(VBImg_ROI2[Flute - 1].Size);
                    VBCrop[Flute - 1] = VB[Flute - 1].Copy(VBImg_ROI2[Flute - 1]);


                    VBImg_ROI[Flute - 1] = Rectangle.Empty;
                    VBImg_ROI2[Flute - 1] = Rectangle.Empty;

                    switch (Flute)
                    {
                        case 1:
                            imageBox_VB_F1.Image = VBCrop[0];
                            break;
                        case 2:
                            imageBox_VB_F2.Image = VBCrop[1];
                            break;
                        case 3:
                            imageBox_VB_F3.Image = VBCrop[2];
                            break;
                        case 4:
                            imageBox_VB_F4.Image = VBCrop[3];
                            break;
                    }

                }
                if (!CHImg_ROI[Flute - 1].IsEmpty)
                {
                    int X = 0;
                    int Height = (int)(systemResolution * 1600 / double.Parse(textBox_MicroReso.Text));
                    int Width = CH[Flute - 1].Width;
                    int Y = CHImg_ROI[Flute - 1].Y + CHImg_ROI[Flute - 1].Height - Height;
                    CHImg_ROI2[Flute - 1] = new Rectangle(X, Y, Width, Height);

                    CHCrop[Flute - 1] = new Image<Bgr, byte>(CHImg_ROI2[Flute - 1].Size);
                    CHCrop[Flute - 1] = CH[Flute - 1].Copy(CHImg_ROI2[Flute - 1]);

                    CHImg_ROI[Flute - 1] = Rectangle.Empty;
                    CHImg_ROI2[Flute - 1] = Rectangle.Empty;

                    switch (Flute)
                    {
                        case 1:
                            imageBox_CH_F1.Image = CHCrop[0];
                            break;
                        case 2:
                            imageBox_CH_F2.Image = CHCrop[1];
                            break;
                        case 3:
                            imageBox_CH_F3.Image = CHCrop[2];
                            break;
                        case 4:
                            imageBox_CH_F4.Image = CHCrop[3];
                            break;
                    }
                }
            }





        }
        private void btn_ClearCrop_Click(object sender, EventArgs e)
        {

            imageBox_VB_F1.Image = VB[0];
            imageBox_VB_F2.Image = VB[1];
            imageBox_VB_F3.Image = VB[2];
            imageBox_VB_F4.Image = VB[3];

            imageBox_CH_F1.Image = CH[0];
            imageBox_CH_F2.Image = CH[1];
            imageBox_CH_F3.Image = CH[2];
            imageBox_CH_F4.Image = CH[3];

        }

        private void btn_labeling_Click(object sender, EventArgs e)
        #region
        {
            string[] sArray = textBox_SaveImgPath.Text.Split('\\');
            string ToolName = sArray[sArray.Length - 1];


            Image<Gray, UInt16> errormapPro = new Image<Gray, UInt16>(textBox_SaveImgPath.Text + "\\" + ToolName + "_WearDepthProRaw.Tif");
            Image<Bgr, Byte> errormapProNorm = new Image<Bgr, Byte>(textBox_SaveImgPath.Text + "\\" + ToolName + "_WearDepthProJet.Tif");
            Image<Gray, UInt16> Wear = null;
            Image<Bgr, Byte> WearNorm, WearImage;
            Rectangle WearArea = Rectangle.Empty;

            int Flute2 = 0;
            

            //string[] sArray = textBox_SaveImgPath.Text.Split('\\');
            //string ToolName = sArray[sArray.Length - 1];

            string SaveDir = textBox_SaveImgPath.Text + "\\Wear\\";
            if (Directory.Exists(SaveDir))
            {
            }
            else
            {
                Directory.CreateDirectory(@SaveDir);
            }

            string WearType = "empty";
            #region --selection--
            if (rabtn_CF.Checked)
            {
                WearType = "CF";
            }
            if (rabtn_CH1.Checked)
            {
                WearType = "CH1";
            }
            if (rabtn_CH2.Checked)
            {
                WearType = "CH2";
            }
            if (rabtn_CH3.Checked)
            {
                WearType = "CH3";
            }
            if (rabtn_VB1.Checked)
            {
                WearType = "VB1";
            }
            if (rabtn_VB2.Checked)
            {
                WearType = "VB2";
            }
            if (rabtn_VB3.Checked)
            {
                WearType = "VB3";
            }
            #endregion

            #region -- Posotion--
            int[] position = new int[9];
            StreamReader sr = new StreamReader(@textBox_SaveImgPath.Text + "\\" + "Postion.TXT");
            int i = 0;
            while (!sr.EndOfStream)
            {               // 每次讀取一行，直到檔尾
                string line = sr.ReadLine();
                textBox3.Text = textBox3.Text + "\r\n" + line;
                position[i] = Convert.ToInt32(line);
                i++;
            }
            sr.Close();                     // 關閉串流
            #endregion

            textBox3.Text = textBox3.Text + "\r\n" + WearType;
            textBox3.SelectionStart = textBox3.Text.Length;
            textBox3.ScrollToCaret();
            textBox3.Refresh();

            for (int Flute = 1; Flute <= 4; Flute++)
            {
                if (rabtn_CF.Checked)
                {
                    if (!VBImg_ROI[Flute - 1].IsEmpty)
                    {
                        if (VBImg_ROI[Flute - 1].Y < 0)
                        {
                            VBImg_ROI[Flute - 1].Y = 0;
                        }
                        if (VBImg_ROI[Flute - 1].Height + VBImg_ROI[Flute - 1].Y > VBCrop[Flute - 1].Height)
                        {
                            VBImg_ROI[Flute - 1].Height = VBCrop[Flute - 1].Height - VBImg_ROI[Flute - 1].Y;
                        }

                        VBImg_ROI2[Flute - 1] = new Rectangle();
                        VBImg_ROI2[Flute - 1].X = position[2 * (Flute - 1)];
                        VBImg_ROI2[Flute - 1].Width = position[2 * Flute] - position[2 * (Flute - 1)] - 1;
                        VBImg_ROI2[Flute - 1].Height = (int)(VBImg_ROI[Flute - 1].Height * double.Parse(textBox_MicroReso.Text) / systemResolution);
                        VBImg_ROI2[Flute - 1].Y = (int)(VBImg_ROI[Flute - 1].Y * double.Parse(textBox_MicroReso.Text) / systemResolution);




                        Wear = new Image<Gray, UInt16>(VBImg_ROI2[Flute - 1].Size);
                        Wear = errormapPro.Copy(VBImg_ROI2[Flute - 1]);
                        Wear.Save(SaveDir + ToolName + "_F" + Flute.ToString() + "_" + WearType + ".Tif");

                        WearNorm = new Image<Bgr, byte>(VBImg_ROI2[Flute - 1].Size);
                        WearNorm = errormapProNorm.Copy(VBImg_ROI2[Flute - 1]);
                        WearNorm.Save(SaveDir + ToolName + "_F" + Flute.ToString() + "_" + WearType + "Norm.Tif");

                        WearImage = new Image<Bgr, byte>(VBImg_ROI[Flute - 1].Size);
                        WearImage = VBCrop[Flute - 1].Copy(VBImg_ROI[Flute - 1]);
                        WearImage.Save(SaveDir + ToolName + "_F" + Flute.ToString() + "_" + WearType + "Image.Tif");


                        WearArea = VBImg_ROI2[Flute - 1];
                        VBImg_ROI[Flute - 1] = Rectangle.Empty;
                        VBImg_ROI2[Flute - 1] = Rectangle.Empty;

                        Flute2 = Flute;
                        System.Media.SystemSounds.Beep.Play();

                    }
                }
                else
                {
                    if (!VBImg_ROI[Flute - 1].IsEmpty)
                    {
                        if (VBImg_ROI[Flute - 1].Y < 0)
                        {
                            VBImg_ROI[Flute - 1].Y = 0;
                        }
                        if (VBImg_ROI[Flute - 1].Height+ VBImg_ROI[Flute - 1].Y > VBCrop[Flute - 1].Height)
                        {
                            VBImg_ROI[Flute - 1].Height = VBCrop[Flute - 1].Height- VBImg_ROI[Flute - 1].Y;
                        }

                        VBImg_ROI2[Flute - 1] = new Rectangle();
                        VBImg_ROI2[Flute - 1].X = position[2 * (Flute-1)];
                        VBImg_ROI2[Flute - 1].Width = position[2 * (Flute - 1) + 1] - position[2 * (Flute - 1)] - 1;
                        VBImg_ROI2[Flute - 1].Height = (int)(VBImg_ROI[Flute - 1].Height * double.Parse(textBox_MicroReso.Text) / systemResolution);
                        VBImg_ROI2[Flute - 1].Y = (int)(VBImg_ROI[Flute - 1].Y * double.Parse(textBox_MicroReso.Text) / systemResolution);




                        Wear = new Image<Gray, UInt16>(VBImg_ROI2[Flute - 1].Size);
                        Wear = errormapPro.Copy(VBImg_ROI2[Flute - 1]);
                        Wear.Save(SaveDir + ToolName + "_F" + Flute.ToString() + "_" + WearType + ".Tif");

                        WearNorm = new Image<Bgr, byte>(VBImg_ROI2[Flute - 1].Size);
                        WearNorm = errormapProNorm.Copy(VBImg_ROI2[Flute - 1]);
                        WearNorm.Save(SaveDir + ToolName + "_F" + Flute.ToString() + "_" + WearType + "Norm.Tif");

                        WearImage = new Image<Bgr, byte>(VBImg_ROI[Flute - 1].Size);
                        WearImage = VBCrop[Flute - 1].Copy(VBImg_ROI[Flute - 1]);
                        WearImage.Save(SaveDir + ToolName + "_F" + Flute.ToString() + "_" + WearType + "Image.Tif");


                        WearArea = VBImg_ROI2[Flute - 1];
                        VBImg_ROI[Flute - 1] = Rectangle.Empty;
                        VBImg_ROI2[Flute - 1] = Rectangle.Empty;

                        Flute2 = Flute;
                        System.Media.SystemSounds.Beep.Play();

                    }

                    if (!CHImg_ROI[Flute - 1].IsEmpty)
                    {

                        if (CHImg_ROI[Flute - 1].Y < 0)
                        {
                            CHImg_ROI[Flute - 1].Y = 0;
                        }
                        if (CHImg_ROI[Flute - 1].Height+ CHImg_ROI[Flute - 1].Y > CHCrop[Flute - 1].Height)
                        {
                            CHImg_ROI[Flute - 1].Height = CHCrop[Flute - 1].Height- CHImg_ROI[Flute - 1].Y;
                        }

                        CHImg_ROI2[Flute - 1] = new Rectangle();
                        CHImg_ROI2[Flute - 1].X = position[2 * (Flute - 1) + 1];
                        CHImg_ROI2[Flute - 1].Width = position[2 * (Flute)] - position[2 * (Flute - 1) + 1] - 1;
                        CHImg_ROI2[Flute - 1].Height = (int)(CHImg_ROI[Flute - 1].Height * double.Parse(textBox_MicroReso.Text) / systemResolution);
                        CHImg_ROI2[Flute - 1].Y = (int)(CHImg_ROI[Flute - 1].Y * double.Parse(textBox_MicroReso.Text) / systemResolution);


                        Wear = new Image<Gray, UInt16>(CHImg_ROI2[Flute - 1].Size);
                        Wear = errormapPro.Copy(CHImg_ROI2[Flute - 1]);
                        Wear.Save(SaveDir + ToolName + "_F" + Flute.ToString() + "_" + WearType + ".Tif");

                        WearNorm = new Image<Bgr, byte>(CHImg_ROI2[Flute - 1].Size);
                        WearNorm = errormapProNorm.Copy(CHImg_ROI2[Flute - 1]);
                        WearNorm.Save(SaveDir + ToolName + "_F" + Flute.ToString() + "_" + WearType + "Norm.Tif");

                        WearImage = new Image<Bgr, byte>(CHImg_ROI[Flute - 1].Size);
                        WearImage = CHCrop[Flute - 1].Copy(CHImg_ROI[Flute - 1]);
                        WearImage.Save(SaveDir + ToolName + "_F" + Flute.ToString() + "_" + WearType + "Image.Tif");

                        WearArea = CHImg_ROI2[Flute - 1];
                        CHImg_ROI[Flute - 1] = Rectangle.Empty;
                        CHImg_ROI2[Flute - 1] = Rectangle.Empty;

                        Flute2 = Flute;
                        System.Media.SystemSounds.Beep.Play();
                    }

                }              
            }
            if (Flute2 != 0 && WearArea != null)
            {
                #region -- ExcelOutput--
                double[] minValues, maxValues;
                Point[] minLocations, maxLocations;

                double A = double.Parse(textBox_Pixelsize.Text) / double.Parse(textBox_Mag.Text);
                double Volume = (double)CvInvoke.Sum(Wear).V0 * (A * A * (toolRadius * Math.PI / Wear.Cols));
                double Area = (double)CvInvoke.CountNonZero(Wear) * (A * (toolRadius * Math.PI / Wear.Cols));
                double Ave = Volume / Area;
                Wear.MinMax(out minValues, out maxValues, out minLocations, out maxLocations);

                textBox3.Text = textBox3.Text + "\r\n" + "V:" + Volume.ToString() + ">>A:" + Area.ToString() + ">>Ave:" + Ave.ToString() + ">>Max:" + maxValues[0].ToString();


                IWorkbook templateWorkbook;
                using (FileStream fs = new FileStream(@textBox_WearDepthOutput.Text, FileMode.Open, FileAccess.Read))
                {
                    templateWorkbook = new XSSFWorkbook(fs);
                }

                XSSFSheet sheetRaw = (XSSFSheet)templateWorkbook.GetSheetAt(1);
                int RowCount = sheetRaw.LastRowNum;
                string Time = DateTime.Now.ToShortDateString() + "-" + DateTime.Now.ToShortTimeString();

                sheetRaw.CreateRow(RowCount + 1);
                sheetRaw.GetRow(RowCount + 1).CreateCell(0).SetCellValue(RowCount + 1);     //編號
                sheetRaw.GetRow(RowCount + 1).CreateCell(1).SetCellValue(1);                //批次
                sheetRaw.GetRow(RowCount + 1).CreateCell(2).SetCellValue(ToolName);            //名稱
                sheetRaw.GetRow(RowCount + 1).CreateCell(3).SetCellValue(Flute2);
                sheetRaw.GetRow(RowCount + 1).CreateCell(4).SetCellValue(WearType);
                sheetRaw.GetRow(RowCount + 1).CreateCell(5).SetCellValue(Time);     
                //時間
                sheetRaw.GetRow(RowCount + 1).CreateCell(6).SetCellValue(WearArea.X);
                sheetRaw.GetRow(RowCount + 1).CreateCell(7).SetCellValue(WearArea.Y);
                sheetRaw.GetRow(RowCount + 1).CreateCell(8).SetCellValue(WearArea.Width);
                sheetRaw.GetRow(RowCount + 1).CreateCell(9).SetCellValue(WearArea.Height);

                sheetRaw.GetRow(RowCount + 1).CreateCell(10).SetCellValue(Volume);           //體積
                sheetRaw.GetRow(RowCount + 1).CreateCell(11).SetCellValue(Area);             //面積
                sheetRaw.GetRow(RowCount + 1).CreateCell(12).SetCellValue(Ave);              //平均深度
                sheetRaw.GetRow(RowCount + 1).CreateCell(13).SetCellValue(maxValues[0] * A);   //最大深度

                using (FileStream fs = new FileStream(@textBox_WearDepthOutput.Text, FileMode.Create, FileAccess.Write))
                {
                    templateWorkbook.Write(fs);
                }
                WearArea = Rectangle.Empty;
                Flute2 = 0;
                #endregion
            }

        }
        #endregion
        
    }
    #endregion
}
#endregion