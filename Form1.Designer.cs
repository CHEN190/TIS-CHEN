namespace TIS_NTHU
{
    partial class Form_TIS
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.serialPort_tool = new System.IO.Ports.SerialPort(this.components);
            this.serialPort_image = new System.IO.Ports.SerialPort(this.components);
            this.folderBrowserDialog_imgpath = new System.Windows.Forms.FolderBrowserDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.Systemsetup = new System.Windows.Forms.TabPage();
            this.textBox_ShiftReso = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox_MicroReso = new System.Windows.Forms.TextBox();
            this.textBox_Mag = new System.Windows.Forms.TextBox();
            this.textBox_Pixelsize = new System.Windows.Forms.TextBox();
            this.textBox_WearDepthOutput = new System.Windows.Forms.TextBox();
            this.label_MicroReso = new System.Windows.Forms.Label();
            this.label_Mag = new System.Windows.Forms.Label();
            this.label_Pixelsize = new System.Windows.Forms.Label();
            this.label_WearDepthOutput = new System.Windows.Forms.Label();
            this.btn_WearDepthOutput = new System.Windows.Forms.Button();
            this.groupBox_motor_control = new System.Windows.Forms.GroupBox();
            this.btn_sent_motor = new System.Windows.Forms.Button();
            this.textBox_serialport2 = new System.Windows.Forms.TextBox();
            this.label_seiralport1_send = new System.Windows.Forms.Label();
            this.textBox_serialport1 = new System.Windows.Forms.TextBox();
            this.label_seiralport2_send = new System.Windows.Forms.Label();
            this.groupBox_motor = new System.Windows.Forms.GroupBox();
            this.label_serialport２ = new System.Windows.Forms.Label();
            this.label_serialport1 = new System.Windows.Forms.Label();
            this.btn_Disconnect = new System.Windows.Forms.Button();
            this.btn_Connect = new System.Windows.Forms.Button();
            this.comboBox_Port2 = new System.Windows.Forms.ComboBox();
            this.comboBox_Port1 = new System.Windows.Forms.ComboBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.label_CH_F4 = new System.Windows.Forms.Label();
            this.label_CH_F3 = new System.Windows.Forms.Label();
            this.label_CH_F2 = new System.Windows.Forms.Label();
            this.label_VB_F4 = new System.Windows.Forms.Label();
            this.label_VB_F3 = new System.Windows.Forms.Label();
            this.label_VB_F2 = new System.Windows.Forms.Label();
            this.imageBox_CH_F4 = new Emgu.CV.UI.ImageBox();
            this.imageBox_VB_F4 = new Emgu.CV.UI.ImageBox();
            this.imageBox_CH_F3 = new Emgu.CV.UI.ImageBox();
            this.imageBox_VB_F3 = new Emgu.CV.UI.ImageBox();
            this.imageBox_CH_F2 = new Emgu.CV.UI.ImageBox();
            this.imageBox_VB_F2 = new Emgu.CV.UI.ImageBox();
            this.btn_ClearCrop = new System.Windows.Forms.Button();
            this.btn_crop = new System.Windows.Forms.Button();
            this.btn_PreviousFlute = new System.Windows.Forms.Button();
            this.btn_NextFlute = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rabtn_VB1 = new System.Windows.Forms.RadioButton();
            this.rabtn_CF = new System.Windows.Forms.RadioButton();
            this.rabtn_VB2 = new System.Windows.Forms.RadioButton();
            this.rabtn_CH3 = new System.Windows.Forms.RadioButton();
            this.rabtn_VB3 = new System.Windows.Forms.RadioButton();
            this.rabtn_CH2 = new System.Windows.Forms.RadioButton();
            this.rabtn_CH1 = new System.Windows.Forms.RadioButton();
            this.btn_labeling = new System.Windows.Forms.Button();
            this.label_CH_F1 = new System.Windows.Forms.Label();
            this.label_VB_F1 = new System.Windows.Forms.Label();
            this.imageBox_CH_F1 = new Emgu.CV.UI.ImageBox();
            this.imageBox_VB_F1 = new Emgu.CV.UI.ImageBox();
            this.ImageProcess = new System.Windows.Forms.TabPage();
            this.三維重建 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton5 = new System.Windows.Forms.RadioButton();
            this.btn_ReconStart2 = new System.Windows.Forms.Button();
            this.button_videosel = new System.Windows.Forms.Button();
            this.btn_ReconStart = new System.Windows.Forms.Button();
            this.textBox_videosel = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btn_sep_path = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_seppath = new System.Windows.Forms.TextBox();
            this.checkBox_notsave = new System.Windows.Forms.CheckBox();
            this.btn_sepFrame = new System.Windows.Forms.Button();
            this.imgBox_RToolReconMap = new Emgu.CV.UI.ImageBox();
            this.btn_FrameFile = new System.Windows.Forms.Button();
            this.checkBox_saveImage = new System.Windows.Forms.CheckBox();
            this.textBox_FrameFile = new System.Windows.Forms.TextBox();
            this.label_ms = new System.Windows.Forms.Label();
            this.btn_LoadVideoPath = new System.Windows.Forms.Button();
            this.label_s = new System.Windows.Forms.Label();
            this.imgBox_LToolReconMap = new Emgu.CV.UI.ImageBox();
            this.label_min = new System.Windows.Forms.Label();
            this.label_VideoPath = new System.Windows.Forms.Label();
            this.textBox_LoadVideoPath = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label_min2 = new System.Windows.Forms.Label();
            this.label_Max = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button4 = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton4 = new System.Windows.Forms.RadioButton();
            this.radioButton6 = new System.Windows.Forms.RadioButton();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox_autolabel = new System.Windows.Forms.TextBox();
            this.datatextBox = new System.Windows.Forms.TextBox();
            this.btn_period = new System.Windows.Forms.Button();
            this.label_min3 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label_sec3 = new System.Windows.Forms.Label();
            this.label_ms3 = new System.Windows.Forms.Label();
            this.imgBox_RWearDepthMap = new Emgu.CV.UI.ImageBox();
            this.btn_FilePath = new System.Windows.Forms.Button();
            this.label_FilePath2 = new System.Windows.Forms.Label();
            this.textBox_FilePath = new System.Windows.Forms.TextBox();
            this.label_FilePath1 = new System.Windows.Forms.Label();
            this.imgBox_LWearDepthMap = new Emgu.CV.UI.ImageBox();
            this.btn_SaveImgPath = new System.Windows.Forms.Button();
            this.btn_WearAnaStart = new System.Windows.Forms.Button();
            this.textBox_SaveImgPath = new System.Windows.Forms.TextBox();
            this.Controlsystem = new System.Windows.Forms.TabPage();
            this.button5 = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.radioButton7 = new System.Windows.Forms.RadioButton();
            this.radioButton8 = new System.Windows.Forms.RadioButton();
            this.radioButton9 = new System.Windows.Forms.RadioButton();
            this.groupBox_Measure = new System.Windows.Forms.GroupBox();
            this.label_ms1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label_sec1 = new System.Windows.Forms.Label();
            this.label_min1 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.label_delay = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox_folderPath = new System.Windows.Forms.TextBox();
            this.textBox_MoveName = new System.Windows.Forms.TextBox();
            this.btn_MeasureStart = new System.Windows.Forms.Button();
            this.label_MovieName = new System.Windows.Forms.Label();
            this.btn_FolderPath = new System.Windows.Forms.Button();
            this.textBox_TotalFrame = new System.Windows.Forms.TextBox();
            this.label_TotalFrame = new System.Windows.Forms.Label();
            this.groupBox_Move = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btn_MoveImgDOWN = new System.Windows.Forms.Button();
            this.radioButton_rela = new System.Windows.Forms.RadioButton();
            this.radioButton_abs = new System.Windows.Forms.RadioButton();
            this.label_Tool_Tar = new System.Windows.Forms.Label();
            this.textBox_Tool_TarPosi = new System.Windows.Forms.TextBox();
            this.btn_MoveImgUP = new System.Windows.Forms.Button();
            this.textBox_Tool_TarSpeed = new System.Windows.Forms.TextBox();
            this.btn_MoveTool = new System.Windows.Forms.Button();
            this.textBox_Tool_TarAcc = new System.Windows.Forms.TextBox();
            this.label_TarAcc = new System.Windows.Forms.Label();
            this.textBox_Img_TarPosi = new System.Windows.Forms.TextBox();
            this.label_TarSpeed = new System.Windows.Forms.Label();
            this.textBox_Img_TarSpeed = new System.Windows.Forms.TextBox();
            this.label_TarPosi = new System.Windows.Forms.Label();
            this.textBox_Img_TarAcc = new System.Windows.Forms.TextBox();
            this.btn_Move = new System.Windows.Forms.Button();
            this.label_Img_Tar = new System.Windows.Forms.Label();
            this.groupBox_ImgSystem = new System.Windows.Forms.GroupBox();
            this.label_EXTime = new System.Windows.Forms.Label();
            this.textBox_EXTime = new System.Windows.Forms.TextBox();
            this.label_extimeSetting = new System.Windows.Forms.Label();
            this.label_FPS = new System.Windows.Forms.Label();
            this.label_vblank = new System.Windows.Forms.Label();
            this.textBox_FPS = new System.Windows.Forms.TextBox();
            this.btn_Preview = new System.Windows.Forms.Button();
            this.btn_Snap = new System.Windows.Forms.Button();
            this.groupBox_Position = new System.Windows.Forms.GroupBox();
            this.textBox_Img_CurPosi = new System.Windows.Forms.TextBox();
            this.label_Tool_CurPosi = new System.Windows.Forms.Label();
            this.textBox_Tool_CurPosi = new System.Windows.Forms.TextBox();
            this.btn_SetOrigin = new System.Windows.Forms.Button();
            this.label_Img_CurPosi = new System.Windows.Forms.Label();
            this.btn_MovetoOrigin = new System.Windows.Forms.Button();
            this.btn_MotorEnable = new System.Windows.Forms.Button();
            this.btn_MotorFree = new System.Windows.Forms.Button();
            this.tabControl_fuction = new System.Windows.Forms.TabControl();
            this.ML = new System.Windows.Forms.TabPage();
            this.name1textBox = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.name2textBox = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.name3textBox = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.name4textBox = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.name5textBox = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.name6textBox = new System.Windows.Forms.TextBox();
            this.Systemsetup.SuspendLayout();
            this.groupBox_motor_control.SuspendLayout();
            this.groupBox_motor.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox_CH_F4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox_VB_F4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox_CH_F3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox_VB_F3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox_CH_F2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox_VB_F2)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox_CH_F1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox_VB_F1)).BeginInit();
            this.ImageProcess.SuspendLayout();
            this.三維重建.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgBox_RToolReconMap)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgBox_LToolReconMap)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgBox_RWearDepthMap)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgBox_LWearDepthMap)).BeginInit();
            this.Controlsystem.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox_Measure.SuspendLayout();
            this.groupBox_Move.SuspendLayout();
            this.groupBox_ImgSystem.SuspendLayout();
            this.groupBox_Position.SuspendLayout();
            this.tabControl_fuction.SuspendLayout();
            this.SuspendLayout();
            // 
            // folderBrowserDialog_imgpath
            // 
            this.folderBrowserDialog_imgpath.HelpRequest += new System.EventHandler(this.folderBrowserDialog_imgpath_HelpRequest);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // Systemsetup
            // 
            this.Systemsetup.Controls.Add(this.textBox_ShiftReso);
            this.Systemsetup.Controls.Add(this.label8);
            this.Systemsetup.Controls.Add(this.label6);
            this.Systemsetup.Controls.Add(this.textBox_MicroReso);
            this.Systemsetup.Controls.Add(this.textBox_Mag);
            this.Systemsetup.Controls.Add(this.textBox_Pixelsize);
            this.Systemsetup.Controls.Add(this.textBox_WearDepthOutput);
            this.Systemsetup.Controls.Add(this.label_MicroReso);
            this.Systemsetup.Controls.Add(this.label_Mag);
            this.Systemsetup.Controls.Add(this.label_Pixelsize);
            this.Systemsetup.Controls.Add(this.label_WearDepthOutput);
            this.Systemsetup.Controls.Add(this.btn_WearDepthOutput);
            this.Systemsetup.Controls.Add(this.groupBox_motor_control);
            this.Systemsetup.Controls.Add(this.groupBox_motor);
            this.Systemsetup.Location = new System.Drawing.Point(4, 34);
            this.Systemsetup.Margin = new System.Windows.Forms.Padding(2);
            this.Systemsetup.Name = "Systemsetup";
            this.Systemsetup.Size = new System.Drawing.Size(2030, 1234);
            this.Systemsetup.TabIndex = 2;
            this.Systemsetup.Text = "系統設定";
            this.Systemsetup.UseVisualStyleBackColor = true;
            this.Systemsetup.Click += new System.EventHandler(this.tabPage4_Click);
            // 
            // textBox_ShiftReso
            // 
            this.textBox_ShiftReso.Font = new System.Drawing.Font("微軟正黑體", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.textBox_ShiftReso.Location = new System.Drawing.Point(704, 313);
            this.textBox_ShiftReso.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_ShiftReso.Name = "textBox_ShiftReso";
            this.textBox_ShiftReso.Size = new System.Drawing.Size(96, 26);
            this.textBox_ShiftReso.TabIndex = 37;
            this.textBox_ShiftReso.Text = "37.69";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(610, 317);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(78, 18);
            this.label8.TabIndex = 36;
            this.label8.Text = "取像解析度";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(487, 193);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(95, 18);
            this.label6.TabIndex = 35;
            this.label6.Text = "相機參數設定:";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // textBox_MicroReso
            // 
            this.textBox_MicroReso.Font = new System.Drawing.Font("微軟正黑體", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.textBox_MicroReso.Location = new System.Drawing.Point(704, 270);
            this.textBox_MicroReso.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_MicroReso.Name = "textBox_MicroReso";
            this.textBox_MicroReso.Size = new System.Drawing.Size(96, 26);
            this.textBox_MicroReso.TabIndex = 34;
            this.textBox_MicroReso.Text = "6.97";
            // 
            // textBox_Mag
            // 
            this.textBox_Mag.Font = new System.Drawing.Font("微軟正黑體", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.textBox_Mag.Location = new System.Drawing.Point(704, 228);
            this.textBox_Mag.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_Mag.Name = "textBox_Mag";
            this.textBox_Mag.Size = new System.Drawing.Size(96, 26);
            this.textBox_Mag.TabIndex = 31;
            this.textBox_Mag.Text = "0.495";
            // 
            // textBox_Pixelsize
            // 
            this.textBox_Pixelsize.Font = new System.Drawing.Font("微軟正黑體", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.textBox_Pixelsize.Location = new System.Drawing.Point(704, 189);
            this.textBox_Pixelsize.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_Pixelsize.Name = "textBox_Pixelsize";
            this.textBox_Pixelsize.Size = new System.Drawing.Size(96, 26);
            this.textBox_Pixelsize.TabIndex = 29;
            this.textBox_Pixelsize.Text = "3.45";
            this.textBox_Pixelsize.TextChanged += new System.EventHandler(this.textBox_Pixelsize_TextChanged);
            // 
            // textBox_WearDepthOutput
            // 
            this.textBox_WearDepthOutput.Font = new System.Drawing.Font("微軟正黑體", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.textBox_WearDepthOutput.Location = new System.Drawing.Point(599, 71);
            this.textBox_WearDepthOutput.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_WearDepthOutput.Name = "textBox_WearDepthOutput";
            this.textBox_WearDepthOutput.Size = new System.Drawing.Size(424, 26);
            this.textBox_WearDepthOutput.TabIndex = 12;
            this.textBox_WearDepthOutput.Text = "‪C:\\Users\\user\\Desktop\\TEST.xlsx";
            this.textBox_WearDepthOutput.TextChanged += new System.EventHandler(this.textBox_WearDepthOutput_TextChanged);
            // 
            // label_MicroReso
            // 
            this.label_MicroReso.AutoSize = true;
            this.label_MicroReso.Location = new System.Drawing.Point(596, 274);
            this.label_MicroReso.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_MicroReso.Name = "label_MicroReso";
            this.label_MicroReso.Size = new System.Drawing.Size(92, 18);
            this.label_MicroReso.TabIndex = 33;
            this.label_MicroReso.Text = "顯微鏡解析度";
            // 
            // label_Mag
            // 
            this.label_Mag.AutoSize = true;
            this.label_Mag.Location = new System.Drawing.Point(596, 232);
            this.label_Mag.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_Mag.Name = "label_Mag";
            this.label_Mag.Size = new System.Drawing.Size(92, 18);
            this.label_Mag.TabIndex = 32;
            this.label_Mag.Text = "鏡頭放大倍率";
            // 
            // label_Pixelsize
            // 
            this.label_Pixelsize.AutoSize = true;
            this.label_Pixelsize.Location = new System.Drawing.Point(596, 193);
            this.label_Pixelsize.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_Pixelsize.Name = "label_Pixelsize";
            this.label_Pixelsize.Size = new System.Drawing.Size(92, 18);
            this.label_Pixelsize.TabIndex = 30;
            this.label_Pixelsize.Text = "相機像素大小";
            // 
            // label_WearDepthOutput
            // 
            this.label_WearDepthOutput.AutoSize = true;
            this.label_WearDepthOutput.Location = new System.Drawing.Point(447, 75);
            this.label_WearDepthOutput.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_WearDepthOutput.Name = "label_WearDepthOutput";
            this.label_WearDepthOutput.Size = new System.Drawing.Size(148, 18);
            this.label_WearDepthOutput.TabIndex = 28;
            this.label_WearDepthOutput.Text = "手動磨耗深度輸出路徑";
            // 
            // btn_WearDepthOutput
            // 
            this.btn_WearDepthOutput.Location = new System.Drawing.Point(1027, 70);
            this.btn_WearDepthOutput.Margin = new System.Windows.Forms.Padding(2);
            this.btn_WearDepthOutput.Name = "btn_WearDepthOutput";
            this.btn_WearDepthOutput.Size = new System.Drawing.Size(76, 26);
            this.btn_WearDepthOutput.TabIndex = 14;
            this.btn_WearDepthOutput.Text = "瀏覽";
            this.btn_WearDepthOutput.UseVisualStyleBackColor = true;
            this.btn_WearDepthOutput.Click += new System.EventHandler(this.btn_WearDepthOutput_Click);
            // 
            // groupBox_motor_control
            // 
            this.groupBox_motor_control.Controls.Add(this.btn_sent_motor);
            this.groupBox_motor_control.Controls.Add(this.textBox_serialport2);
            this.groupBox_motor_control.Controls.Add(this.label_seiralport1_send);
            this.groupBox_motor_control.Controls.Add(this.textBox_serialport1);
            this.groupBox_motor_control.Controls.Add(this.label_seiralport2_send);
            this.groupBox_motor_control.Location = new System.Drawing.Point(82, 165);
            this.groupBox_motor_control.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox_motor_control.Name = "groupBox_motor_control";
            this.groupBox_motor_control.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox_motor_control.Size = new System.Drawing.Size(315, 288);
            this.groupBox_motor_control.TabIndex = 11;
            this.groupBox_motor_control.TabStop = false;
            this.groupBox_motor_control.Text = "馬達控制碼(校正)";
            // 
            // btn_sent_motor
            // 
            this.btn_sent_motor.Location = new System.Drawing.Point(10, 251);
            this.btn_sent_motor.Margin = new System.Windows.Forms.Padding(2);
            this.btn_sent_motor.Name = "btn_sent_motor";
            this.btn_sent_motor.Size = new System.Drawing.Size(290, 26);
            this.btn_sent_motor.TabIndex = 6;
            this.btn_sent_motor.Text = "送出";
            this.btn_sent_motor.UseVisualStyleBackColor = true;
            this.btn_sent_motor.Click += new System.EventHandler(this.btn_sent_motor_Click);
            // 
            // textBox_serialport2
            // 
            this.textBox_serialport2.Location = new System.Drawing.Point(10, 158);
            this.textBox_serialport2.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_serialport2.Multiline = true;
            this.textBox_serialport2.Name = "textBox_serialport2";
            this.textBox_serialport2.Size = new System.Drawing.Size(291, 79);
            this.textBox_serialport2.TabIndex = 11;
            // 
            // label_seiralport1_send
            // 
            this.label_seiralport1_send.AutoSize = true;
            this.label_seiralport1_send.Location = new System.Drawing.Point(7, 28);
            this.label_seiralport1_send.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_seiralport1_send.Name = "label_seiralport1_send";
            this.label_seiralport1_send.Size = new System.Drawing.Size(78, 18);
            this.label_seiralport1_send.TabIndex = 10;
            this.label_seiralport1_send.Text = "刀具轉軸：";
            // 
            // textBox_serialport1
            // 
            this.textBox_serialport1.Location = new System.Drawing.Point(10, 48);
            this.textBox_serialport1.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_serialport1.Multiline = true;
            this.textBox_serialport1.Name = "textBox_serialport1";
            this.textBox_serialport1.Size = new System.Drawing.Size(291, 79);
            this.textBox_serialport1.TabIndex = 7;
            // 
            // label_seiralport2_send
            // 
            this.label_seiralport2_send.AutoSize = true;
            this.label_seiralport2_send.Location = new System.Drawing.Point(7, 138);
            this.label_seiralport2_send.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_seiralport2_send.Name = "label_seiralport2_send";
            this.label_seiralport2_send.Size = new System.Drawing.Size(78, 18);
            this.label_seiralport2_send.TabIndex = 9;
            this.label_seiralport2_send.Text = "光學系統：";
            // 
            // groupBox_motor
            // 
            this.groupBox_motor.Controls.Add(this.label_serialport２);
            this.groupBox_motor.Controls.Add(this.label_serialport1);
            this.groupBox_motor.Controls.Add(this.btn_Disconnect);
            this.groupBox_motor.Controls.Add(this.btn_Connect);
            this.groupBox_motor.Controls.Add(this.comboBox_Port2);
            this.groupBox_motor.Controls.Add(this.comboBox_Port1);
            this.groupBox_motor.Location = new System.Drawing.Point(82, 53);
            this.groupBox_motor.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox_motor.Name = "groupBox_motor";
            this.groupBox_motor.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox_motor.Size = new System.Drawing.Size(316, 90);
            this.groupBox_motor.TabIndex = 6;
            this.groupBox_motor.TabStop = false;
            this.groupBox_motor.Text = "設備連接設定";
            this.groupBox_motor.Enter += new System.EventHandler(this.groupBox_motor_Enter);
            // 
            // label_serialport２
            // 
            this.label_serialport２.AutoSize = true;
            this.label_serialport２.Location = new System.Drawing.Point(7, 56);
            this.label_serialport２.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_serialport２.Name = "label_serialport２";
            this.label_serialport２.Size = new System.Drawing.Size(78, 18);
            this.label_serialport２.TabIndex = 5;
            this.label_serialport２.Text = "光學系統：";
            // 
            // label_serialport1
            // 
            this.label_serialport1.AutoSize = true;
            this.label_serialport1.Location = new System.Drawing.Point(7, 22);
            this.label_serialport1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_serialport1.Name = "label_serialport1";
            this.label_serialport1.Size = new System.Drawing.Size(78, 18);
            this.label_serialport1.TabIndex = 4;
            this.label_serialport1.Text = "刀具轉軸：";
            // 
            // btn_Disconnect
            // 
            this.btn_Disconnect.Location = new System.Drawing.Point(229, 52);
            this.btn_Disconnect.Margin = new System.Windows.Forms.Padding(2);
            this.btn_Disconnect.Name = "btn_Disconnect";
            this.btn_Disconnect.Size = new System.Drawing.Size(71, 26);
            this.btn_Disconnect.TabIndex = 3;
            this.btn_Disconnect.Text = "斷開";
            this.btn_Disconnect.UseVisualStyleBackColor = true;
            this.btn_Disconnect.Click += new System.EventHandler(this.btn_Disconnect_Click);
            // 
            // btn_Connect
            // 
            this.btn_Connect.Location = new System.Drawing.Point(229, 18);
            this.btn_Connect.Margin = new System.Windows.Forms.Padding(2);
            this.btn_Connect.Name = "btn_Connect";
            this.btn_Connect.Size = new System.Drawing.Size(71, 26);
            this.btn_Connect.TabIndex = 2;
            this.btn_Connect.Text = "連接";
            this.btn_Connect.UseVisualStyleBackColor = true;
            this.btn_Connect.Click += new System.EventHandler(this.btn_Connect_Click);
            // 
            // comboBox_Port2
            // 
            this.comboBox_Port2.FormattingEnabled = true;
            this.comboBox_Port2.Location = new System.Drawing.Point(99, 54);
            this.comboBox_Port2.Margin = new System.Windows.Forms.Padding(2);
            this.comboBox_Port2.Name = "comboBox_Port2";
            this.comboBox_Port2.Size = new System.Drawing.Size(92, 25);
            this.comboBox_Port2.TabIndex = 1;
            this.comboBox_Port2.SelectedIndexChanged += new System.EventHandler(this.comboBox_Port2_SelectedIndexChanged);
            // 
            // comboBox_Port1
            // 
            this.comboBox_Port1.FormattingEnabled = true;
            this.comboBox_Port1.Location = new System.Drawing.Point(99, 19);
            this.comboBox_Port1.Margin = new System.Windows.Forms.Padding(2);
            this.comboBox_Port1.Name = "comboBox_Port1";
            this.comboBox_Port1.Size = new System.Drawing.Size(92, 25);
            this.comboBox_Port1.TabIndex = 0;
            this.comboBox_Port1.SelectedIndexChanged += new System.EventHandler(this.comboBox_Port1_SelectedIndexChanged);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.label_CH_F4);
            this.tabPage3.Controls.Add(this.label_CH_F3);
            this.tabPage3.Controls.Add(this.label_CH_F2);
            this.tabPage3.Controls.Add(this.label_VB_F4);
            this.tabPage3.Controls.Add(this.label_VB_F3);
            this.tabPage3.Controls.Add(this.label_VB_F2);
            this.tabPage3.Controls.Add(this.imageBox_CH_F4);
            this.tabPage3.Controls.Add(this.imageBox_VB_F4);
            this.tabPage3.Controls.Add(this.imageBox_CH_F3);
            this.tabPage3.Controls.Add(this.imageBox_VB_F3);
            this.tabPage3.Controls.Add(this.imageBox_CH_F2);
            this.tabPage3.Controls.Add(this.imageBox_VB_F2);
            this.tabPage3.Controls.Add(this.btn_ClearCrop);
            this.tabPage3.Controls.Add(this.btn_crop);
            this.tabPage3.Controls.Add(this.btn_PreviousFlute);
            this.tabPage3.Controls.Add(this.btn_NextFlute);
            this.tabPage3.Controls.Add(this.groupBox2);
            this.tabPage3.Controls.Add(this.btn_labeling);
            this.tabPage3.Controls.Add(this.label_CH_F1);
            this.tabPage3.Controls.Add(this.label_VB_F1);
            this.tabPage3.Controls.Add(this.imageBox_CH_F1);
            this.tabPage3.Controls.Add(this.imageBox_VB_F1);
            this.tabPage3.Location = new System.Drawing.Point(4, 34);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(2030, 1234);
            this.tabPage3.TabIndex = 3;
            this.tabPage3.Text = "手動標註";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // label_CH_F4
            // 
            this.label_CH_F4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label_CH_F4.AutoSize = true;
            this.label_CH_F4.Location = new System.Drawing.Point(1339, 501);
            this.label_CH_F4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_CH_F4.Name = "label_CH_F4";
            this.label_CH_F4.Size = new System.Drawing.Size(49, 18);
            this.label_CH_F4.TabIndex = 72;
            this.label_CH_F4.Text = "F4-CH";
            // 
            // label_CH_F3
            // 
            this.label_CH_F3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label_CH_F3.AutoSize = true;
            this.label_CH_F3.Location = new System.Drawing.Point(965, 501);
            this.label_CH_F3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_CH_F3.Name = "label_CH_F3";
            this.label_CH_F3.Size = new System.Drawing.Size(49, 18);
            this.label_CH_F3.TabIndex = 71;
            this.label_CH_F3.Text = "F3-CH";
            // 
            // label_CH_F2
            // 
            this.label_CH_F2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label_CH_F2.AutoSize = true;
            this.label_CH_F2.Location = new System.Drawing.Point(592, 501);
            this.label_CH_F2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_CH_F2.Name = "label_CH_F2";
            this.label_CH_F2.Size = new System.Drawing.Size(49, 18);
            this.label_CH_F2.TabIndex = 70;
            this.label_CH_F2.Text = "F2-CH";
            // 
            // label_VB_F4
            // 
            this.label_VB_F4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label_VB_F4.AutoSize = true;
            this.label_VB_F4.Location = new System.Drawing.Point(1340, 20);
            this.label_VB_F4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_VB_F4.Name = "label_VB_F4";
            this.label_VB_F4.Size = new System.Drawing.Size(47, 18);
            this.label_VB_F4.TabIndex = 69;
            this.label_VB_F4.Text = "F4-VB";
            // 
            // label_VB_F3
            // 
            this.label_VB_F3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label_VB_F3.AutoSize = true;
            this.label_VB_F3.Location = new System.Drawing.Point(971, 20);
            this.label_VB_F3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_VB_F3.Name = "label_VB_F3";
            this.label_VB_F3.Size = new System.Drawing.Size(47, 18);
            this.label_VB_F3.TabIndex = 68;
            this.label_VB_F3.Text = "F3-VB";
            // 
            // label_VB_F2
            // 
            this.label_VB_F2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label_VB_F2.AutoSize = true;
            this.label_VB_F2.Location = new System.Drawing.Point(592, 20);
            this.label_VB_F2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_VB_F2.Name = "label_VB_F2";
            this.label_VB_F2.Size = new System.Drawing.Size(47, 18);
            this.label_VB_F2.TabIndex = 67;
            this.label_VB_F2.Text = "F2-VB";
            // 
            // imageBox_CH_F4
            // 
            this.imageBox_CH_F4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.imageBox_CH_F4.BackColor = System.Drawing.Color.Silver;
            this.imageBox_CH_F4.FunctionalMode = Emgu.CV.UI.ImageBox.FunctionalModeOption.Minimum;
            this.imageBox_CH_F4.Location = new System.Drawing.Point(1198, 522);
            this.imageBox_CH_F4.Name = "imageBox_CH_F4";
            this.imageBox_CH_F4.Size = new System.Drawing.Size(330, 440);
            this.imageBox_CH_F4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.imageBox_CH_F4.TabIndex = 66;
            this.imageBox_CH_F4.TabStop = false;
            this.imageBox_CH_F4.Paint += new System.Windows.Forms.PaintEventHandler(this.imgBox_CHF4_Paint);
            this.imageBox_CH_F4.MouseDown += new System.Windows.Forms.MouseEventHandler(this.imgBox_CHF4_MouseDown);
            this.imageBox_CH_F4.MouseMove += new System.Windows.Forms.MouseEventHandler(this.imgBox_CHF4_MouseMove);
            this.imageBox_CH_F4.MouseUp += new System.Windows.Forms.MouseEventHandler(this.imgBox_CHF4_MouseUp);
            // 
            // imageBox_VB_F4
            // 
            this.imageBox_VB_F4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.imageBox_VB_F4.BackColor = System.Drawing.Color.Silver;
            this.imageBox_VB_F4.FunctionalMode = Emgu.CV.UI.ImageBox.FunctionalModeOption.Minimum;
            this.imageBox_VB_F4.Location = new System.Drawing.Point(1198, 41);
            this.imageBox_VB_F4.Name = "imageBox_VB_F4";
            this.imageBox_VB_F4.Size = new System.Drawing.Size(330, 440);
            this.imageBox_VB_F4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.imageBox_VB_F4.TabIndex = 65;
            this.imageBox_VB_F4.TabStop = false;
            this.imageBox_VB_F4.Paint += new System.Windows.Forms.PaintEventHandler(this.imgBox_VBF4_Paint);
            this.imageBox_VB_F4.MouseDown += new System.Windows.Forms.MouseEventHandler(this.imgBox_VBF4_MouseDown);
            this.imageBox_VB_F4.MouseMove += new System.Windows.Forms.MouseEventHandler(this.imgBox_VBF4_MouseMove);
            this.imageBox_VB_F4.MouseUp += new System.Windows.Forms.MouseEventHandler(this.imgBox_VBF4_MouseUp);
            // 
            // imageBox_CH_F3
            // 
            this.imageBox_CH_F3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.imageBox_CH_F3.BackColor = System.Drawing.Color.Silver;
            this.imageBox_CH_F3.FunctionalMode = Emgu.CV.UI.ImageBox.FunctionalModeOption.Minimum;
            this.imageBox_CH_F3.Location = new System.Drawing.Point(824, 522);
            this.imageBox_CH_F3.Name = "imageBox_CH_F3";
            this.imageBox_CH_F3.Size = new System.Drawing.Size(330, 440);
            this.imageBox_CH_F3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.imageBox_CH_F3.TabIndex = 64;
            this.imageBox_CH_F3.TabStop = false;
            this.imageBox_CH_F3.Paint += new System.Windows.Forms.PaintEventHandler(this.imgBox_CHF3_Paint);
            this.imageBox_CH_F3.MouseDown += new System.Windows.Forms.MouseEventHandler(this.imgBox_CHF3_MouseDown);
            this.imageBox_CH_F3.MouseMove += new System.Windows.Forms.MouseEventHandler(this.imgBox_CHF3_MouseMove);
            this.imageBox_CH_F3.MouseUp += new System.Windows.Forms.MouseEventHandler(this.imgBox_CHF3_MouseUp);
            // 
            // imageBox_VB_F3
            // 
            this.imageBox_VB_F3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.imageBox_VB_F3.BackColor = System.Drawing.Color.Silver;
            this.imageBox_VB_F3.FunctionalMode = Emgu.CV.UI.ImageBox.FunctionalModeOption.Minimum;
            this.imageBox_VB_F3.Location = new System.Drawing.Point(824, 41);
            this.imageBox_VB_F3.Name = "imageBox_VB_F3";
            this.imageBox_VB_F3.Size = new System.Drawing.Size(330, 440);
            this.imageBox_VB_F3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.imageBox_VB_F3.TabIndex = 63;
            this.imageBox_VB_F3.TabStop = false;
            this.imageBox_VB_F3.Paint += new System.Windows.Forms.PaintEventHandler(this.imgBox_VBF3_Paint);
            this.imageBox_VB_F3.MouseDown += new System.Windows.Forms.MouseEventHandler(this.imgBox_VBF3_MouseDown);
            this.imageBox_VB_F3.MouseMove += new System.Windows.Forms.MouseEventHandler(this.imgBox_VBF3_MouseMove);
            this.imageBox_VB_F3.MouseUp += new System.Windows.Forms.MouseEventHandler(this.imgBox_VBF3_MouseUp);
            // 
            // imageBox_CH_F2
            // 
            this.imageBox_CH_F2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.imageBox_CH_F2.BackColor = System.Drawing.Color.Silver;
            this.imageBox_CH_F2.FunctionalMode = Emgu.CV.UI.ImageBox.FunctionalModeOption.Minimum;
            this.imageBox_CH_F2.Location = new System.Drawing.Point(450, 522);
            this.imageBox_CH_F2.Name = "imageBox_CH_F2";
            this.imageBox_CH_F2.Size = new System.Drawing.Size(330, 440);
            this.imageBox_CH_F2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.imageBox_CH_F2.TabIndex = 62;
            this.imageBox_CH_F2.TabStop = false;
            this.imageBox_CH_F2.Paint += new System.Windows.Forms.PaintEventHandler(this.imgBox_CHF2_Paint);
            this.imageBox_CH_F2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.imgBox_CHF2_MouseDown);
            this.imageBox_CH_F2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.imgBox_CHF2_MouseMove);
            this.imageBox_CH_F2.MouseUp += new System.Windows.Forms.MouseEventHandler(this.imgBox_CHF2_MouseUp);
            // 
            // imageBox_VB_F2
            // 
            this.imageBox_VB_F2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.imageBox_VB_F2.BackColor = System.Drawing.Color.Silver;
            this.imageBox_VB_F2.FunctionalMode = Emgu.CV.UI.ImageBox.FunctionalModeOption.Minimum;
            this.imageBox_VB_F2.Location = new System.Drawing.Point(450, 41);
            this.imageBox_VB_F2.Name = "imageBox_VB_F2";
            this.imageBox_VB_F2.Size = new System.Drawing.Size(330, 440);
            this.imageBox_VB_F2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.imageBox_VB_F2.TabIndex = 61;
            this.imageBox_VB_F2.TabStop = false;
            this.imageBox_VB_F2.Paint += new System.Windows.Forms.PaintEventHandler(this.imgBox_VBF2_Paint);
            this.imageBox_VB_F2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.imgBox_VBF2_MouseDown);
            this.imageBox_VB_F2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.imgBox_VBF2_MouseMove);
            this.imageBox_VB_F2.MouseUp += new System.Windows.Forms.MouseEventHandler(this.imgBox_VBF2_MouseUp);
            // 
            // btn_ClearCrop
            // 
            this.btn_ClearCrop.Location = new System.Drawing.Point(1780, 91);
            this.btn_ClearCrop.Margin = new System.Windows.Forms.Padding(2);
            this.btn_ClearCrop.Name = "btn_ClearCrop";
            this.btn_ClearCrop.Size = new System.Drawing.Size(90, 26);
            this.btn_ClearCrop.TabIndex = 60;
            this.btn_ClearCrop.Text = "清除剪裁";
            this.btn_ClearCrop.UseVisualStyleBackColor = true;
            this.btn_ClearCrop.Click += new System.EventHandler(this.btn_ClearCrop_Click);
            // 
            // btn_crop
            // 
            this.btn_crop.Location = new System.Drawing.Point(1780, 49);
            this.btn_crop.Margin = new System.Windows.Forms.Padding(2);
            this.btn_crop.Name = "btn_crop";
            this.btn_crop.Size = new System.Drawing.Size(90, 26);
            this.btn_crop.TabIndex = 59;
            this.btn_crop.Text = "剪裁";
            this.btn_crop.UseVisualStyleBackColor = true;
            this.btn_crop.Click += new System.EventHandler(this.btn_crop_Click);
            // 
            // btn_PreviousFlute
            // 
            this.btn_PreviousFlute.Location = new System.Drawing.Point(1683, 91);
            this.btn_PreviousFlute.Margin = new System.Windows.Forms.Padding(2);
            this.btn_PreviousFlute.Name = "btn_PreviousFlute";
            this.btn_PreviousFlute.Size = new System.Drawing.Size(76, 26);
            this.btn_PreviousFlute.TabIndex = 58;
            this.btn_PreviousFlute.Text = "上一刃";
            this.btn_PreviousFlute.UseVisualStyleBackColor = true;
            this.btn_PreviousFlute.Click += new System.EventHandler(this.btn_PreviousFlute_Click);
            // 
            // btn_NextFlute
            // 
            this.btn_NextFlute.Location = new System.Drawing.Point(1683, 49);
            this.btn_NextFlute.Margin = new System.Windows.Forms.Padding(2);
            this.btn_NextFlute.Name = "btn_NextFlute";
            this.btn_NextFlute.Size = new System.Drawing.Size(76, 26);
            this.btn_NextFlute.TabIndex = 57;
            this.btn_NextFlute.Text = "下一刃";
            this.btn_NextFlute.UseVisualStyleBackColor = true;
            this.btn_NextFlute.Click += new System.EventHandler(this.btn_NextFlute_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rabtn_VB1);
            this.groupBox2.Controls.Add(this.rabtn_CF);
            this.groupBox2.Controls.Add(this.rabtn_VB2);
            this.groupBox2.Controls.Add(this.rabtn_CH3);
            this.groupBox2.Controls.Add(this.rabtn_VB3);
            this.groupBox2.Controls.Add(this.rabtn_CH2);
            this.groupBox2.Controls.Add(this.rabtn_CH1);
            this.groupBox2.Location = new System.Drawing.Point(1592, 564);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(287, 161);
            this.groupBox2.TabIndex = 56;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "磨耗樣態";
            // 
            // rabtn_VB1
            // 
            this.rabtn_VB1.AutoSize = true;
            this.rabtn_VB1.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.rabtn_VB1.Location = new System.Drawing.Point(24, 38);
            this.rabtn_VB1.Name = "rabtn_VB1";
            this.rabtn_VB1.Size = new System.Drawing.Size(64, 28);
            this.rabtn_VB1.TabIndex = 42;
            this.rabtn_VB1.TabStop = true;
            this.rabtn_VB1.Text = "VB1";
            this.rabtn_VB1.UseVisualStyleBackColor = true;
            this.rabtn_VB1.CheckedChanged += new System.EventHandler(this.rabtn_VB1_CheckedChanged);
            // 
            // rabtn_CF
            // 
            this.rabtn_CF.AutoSize = true;
            this.rabtn_CF.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.rabtn_CF.Location = new System.Drawing.Point(197, 38);
            this.rabtn_CF.Name = "rabtn_CF";
            this.rabtn_CF.Size = new System.Drawing.Size(51, 28);
            this.rabtn_CF.TabIndex = 48;
            this.rabtn_CF.TabStop = true;
            this.rabtn_CF.Text = "CF";
            this.rabtn_CF.UseVisualStyleBackColor = true;
            // 
            // rabtn_VB2
            // 
            this.rabtn_VB2.AutoSize = true;
            this.rabtn_VB2.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.rabtn_VB2.Location = new System.Drawing.Point(24, 76);
            this.rabtn_VB2.Name = "rabtn_VB2";
            this.rabtn_VB2.Size = new System.Drawing.Size(64, 28);
            this.rabtn_VB2.TabIndex = 43;
            this.rabtn_VB2.TabStop = true;
            this.rabtn_VB2.Text = "VB2";
            this.rabtn_VB2.UseVisualStyleBackColor = true;
            // 
            // rabtn_CH3
            // 
            this.rabtn_CH3.AutoSize = true;
            this.rabtn_CH3.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.rabtn_CH3.Location = new System.Drawing.Point(109, 114);
            this.rabtn_CH3.Name = "rabtn_CH3";
            this.rabtn_CH3.Size = new System.Drawing.Size(66, 28);
            this.rabtn_CH3.TabIndex = 47;
            this.rabtn_CH3.TabStop = true;
            this.rabtn_CH3.Text = "CH3";
            this.rabtn_CH3.UseVisualStyleBackColor = true;
            // 
            // rabtn_VB3
            // 
            this.rabtn_VB3.AutoSize = true;
            this.rabtn_VB3.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.rabtn_VB3.Location = new System.Drawing.Point(24, 114);
            this.rabtn_VB3.Name = "rabtn_VB3";
            this.rabtn_VB3.Size = new System.Drawing.Size(64, 28);
            this.rabtn_VB3.TabIndex = 44;
            this.rabtn_VB3.TabStop = true;
            this.rabtn_VB3.Text = "VB3";
            this.rabtn_VB3.UseVisualStyleBackColor = true;
            // 
            // rabtn_CH2
            // 
            this.rabtn_CH2.AutoSize = true;
            this.rabtn_CH2.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.rabtn_CH2.Location = new System.Drawing.Point(109, 76);
            this.rabtn_CH2.Name = "rabtn_CH2";
            this.rabtn_CH2.Size = new System.Drawing.Size(66, 28);
            this.rabtn_CH2.TabIndex = 46;
            this.rabtn_CH2.TabStop = true;
            this.rabtn_CH2.Text = "CH2";
            this.rabtn_CH2.UseVisualStyleBackColor = true;
            // 
            // rabtn_CH1
            // 
            this.rabtn_CH1.AutoSize = true;
            this.rabtn_CH1.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.rabtn_CH1.Location = new System.Drawing.Point(109, 38);
            this.rabtn_CH1.Name = "rabtn_CH1";
            this.rabtn_CH1.Size = new System.Drawing.Size(66, 28);
            this.rabtn_CH1.TabIndex = 45;
            this.rabtn_CH1.TabStop = true;
            this.rabtn_CH1.Text = "CH1";
            this.rabtn_CH1.UseVisualStyleBackColor = true;
            // 
            // btn_labeling
            // 
            this.btn_labeling.Location = new System.Drawing.Point(1604, 747);
            this.btn_labeling.Margin = new System.Windows.Forms.Padding(2);
            this.btn_labeling.Name = "btn_labeling";
            this.btn_labeling.Size = new System.Drawing.Size(76, 26);
            this.btn_labeling.TabIndex = 55;
            this.btn_labeling.Text = "標註";
            this.btn_labeling.UseVisualStyleBackColor = true;
            this.btn_labeling.Click += new System.EventHandler(this.btn_labeling_Click);
            // 
            // label_CH_F1
            // 
            this.label_CH_F1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label_CH_F1.AutoSize = true;
            this.label_CH_F1.Location = new System.Drawing.Point(201, 501);
            this.label_CH_F1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_CH_F1.Name = "label_CH_F1";
            this.label_CH_F1.Size = new System.Drawing.Size(49, 18);
            this.label_CH_F1.TabIndex = 54;
            this.label_CH_F1.Text = "F1-CH";
            // 
            // label_VB_F1
            // 
            this.label_VB_F1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label_VB_F1.AutoSize = true;
            this.label_VB_F1.Location = new System.Drawing.Point(218, 20);
            this.label_VB_F1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_VB_F1.Name = "label_VB_F1";
            this.label_VB_F1.Size = new System.Drawing.Size(47, 18);
            this.label_VB_F1.TabIndex = 53;
            this.label_VB_F1.Text = "F1-VB";
            // 
            // imageBox_CH_F1
            // 
            this.imageBox_CH_F1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.imageBox_CH_F1.BackColor = System.Drawing.Color.Silver;
            this.imageBox_CH_F1.FunctionalMode = Emgu.CV.UI.ImageBox.FunctionalModeOption.Minimum;
            this.imageBox_CH_F1.Location = new System.Drawing.Point(76, 522);
            this.imageBox_CH_F1.Name = "imageBox_CH_F1";
            this.imageBox_CH_F1.Size = new System.Drawing.Size(330, 440);
            this.imageBox_CH_F1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.imageBox_CH_F1.TabIndex = 52;
            this.imageBox_CH_F1.TabStop = false;
            this.imageBox_CH_F1.Paint += new System.Windows.Forms.PaintEventHandler(this.imgBox_CHF1_Paint);
            this.imageBox_CH_F1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.imgBox_CHF1_MouseDown);
            this.imageBox_CH_F1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.imgBox_CHF1_MouseMove);
            this.imageBox_CH_F1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.imgBox_CHF1_MouseUp);
            // 
            // imageBox_VB_F1
            // 
            this.imageBox_VB_F1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.imageBox_VB_F1.BackColor = System.Drawing.Color.Silver;
            this.imageBox_VB_F1.FunctionalMode = Emgu.CV.UI.ImageBox.FunctionalModeOption.Minimum;
            this.imageBox_VB_F1.Location = new System.Drawing.Point(76, 41);
            this.imageBox_VB_F1.Name = "imageBox_VB_F1";
            this.imageBox_VB_F1.Size = new System.Drawing.Size(330, 440);
            this.imageBox_VB_F1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.imageBox_VB_F1.TabIndex = 51;
            this.imageBox_VB_F1.TabStop = false;
            this.imageBox_VB_F1.Click += new System.EventHandler(this.imageBox_VB_F1_Click);
            this.imageBox_VB_F1.Paint += new System.Windows.Forms.PaintEventHandler(this.imgBox_VBF1_Paint);
            this.imageBox_VB_F1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.imgBox_VBF1_MouseDown);
            this.imageBox_VB_F1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.imgBox_VBF1_MouseMove);
            this.imageBox_VB_F1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.imgBox_VBF1_MouseUp);
            // 
            // ImageProcess
            // 
            this.ImageProcess.Controls.Add(this.三維重建);
            this.ImageProcess.Controls.Add(this.label2);
            this.ImageProcess.Controls.Add(this.label_min2);
            this.ImageProcess.Controls.Add(this.label_Max);
            this.ImageProcess.Controls.Add(this.groupBox1);
            this.ImageProcess.Controls.Add(this.imgBox_RWearDepthMap);
            this.ImageProcess.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.ImageProcess.Location = new System.Drawing.Point(4, 34);
            this.ImageProcess.Margin = new System.Windows.Forms.Padding(2);
            this.ImageProcess.Name = "ImageProcess";
            this.ImageProcess.Padding = new System.Windows.Forms.Padding(2);
            this.ImageProcess.Size = new System.Drawing.Size(2030, 1234);
            this.ImageProcess.TabIndex = 1;
            this.ImageProcess.Text = "影像處理";
            this.ImageProcess.UseVisualStyleBackColor = true;
            // 
            // 三維重建
            // 
            this.三維重建.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.三維重建.Controls.Add(this.groupBox3);
            this.三維重建.Controls.Add(this.btn_ReconStart2);
            this.三維重建.Controls.Add(this.button_videosel);
            this.三維重建.Controls.Add(this.btn_ReconStart);
            this.三維重建.Controls.Add(this.textBox_videosel);
            this.三維重建.Controls.Add(this.label5);
            this.三維重建.Controls.Add(this.btn_sep_path);
            this.三維重建.Controls.Add(this.label4);
            this.三維重建.Controls.Add(this.label3);
            this.三維重建.Controls.Add(this.textBox_seppath);
            this.三維重建.Controls.Add(this.checkBox_notsave);
            this.三維重建.Controls.Add(this.btn_sepFrame);
            this.三維重建.Controls.Add(this.imgBox_RToolReconMap);
            this.三維重建.Controls.Add(this.btn_FrameFile);
            this.三維重建.Controls.Add(this.checkBox_saveImage);
            this.三維重建.Controls.Add(this.textBox_FrameFile);
            this.三維重建.Controls.Add(this.label_ms);
            this.三維重建.Controls.Add(this.btn_LoadVideoPath);
            this.三維重建.Controls.Add(this.label_s);
            this.三維重建.Controls.Add(this.imgBox_LToolReconMap);
            this.三維重建.Controls.Add(this.label_min);
            this.三維重建.Controls.Add(this.label_VideoPath);
            this.三維重建.Controls.Add(this.textBox_LoadVideoPath);
            this.三維重建.Location = new System.Drawing.Point(13, 16);
            this.三維重建.Margin = new System.Windows.Forms.Padding(2);
            this.三維重建.Name = "三維重建";
            this.三維重建.Padding = new System.Windows.Forms.Padding(2);
            this.三維重建.Size = new System.Drawing.Size(946, 927);
            this.三維重建.TabIndex = 25;
            this.三維重建.TabStop = false;
            this.三維重建.Text = "三維重建";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.radioButton1);
            this.groupBox3.Controls.Add(this.radioButton3);
            this.groupBox3.Controls.Add(this.radioButton5);
            this.groupBox3.Location = new System.Drawing.Point(399, 157);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(313, 69);
            this.groupBox3.TabIndex = 59;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "重建模式";
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.radioButton1.Location = new System.Drawing.Point(6, 32);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(52, 24);
            this.radioButton1.TabIndex = 42;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "LRs";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.radioButton3.Location = new System.Drawing.Point(71, 32);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(56, 24);
            this.radioButton3.TabIndex = 43;
            this.radioButton3.Text = "HRs";
            this.radioButton3.UseVisualStyleBackColor = true;
            // 
            // radioButton5
            // 
            this.radioButton5.AutoSize = true;
            this.radioButton5.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.radioButton5.Location = new System.Drawing.Point(140, 32);
            this.radioButton5.Name = "radioButton5";
            this.radioButton5.Size = new System.Drawing.Size(123, 24);
            this.radioButton5.TabIndex = 44;
            this.radioButton5.Text = "Other(setup)";
            this.radioButton5.UseVisualStyleBackColor = true;
            // 
            // btn_ReconStart2
            // 
            this.btn_ReconStart2.BackColor = System.Drawing.Color.LightSlateGray;
            this.btn_ReconStart2.Location = new System.Drawing.Point(733, 227);
            this.btn_ReconStart2.Margin = new System.Windows.Forms.Padding(2);
            this.btn_ReconStart2.Name = "btn_ReconStart2";
            this.btn_ReconStart2.Size = new System.Drawing.Size(114, 37);
            this.btn_ReconStart2.TabIndex = 39;
            this.btn_ReconStart2.Text = "高倍率重建";
            this.btn_ReconStart2.UseVisualStyleBackColor = false;
            this.btn_ReconStart2.Click += new System.EventHandler(this.btn_ReconStart2_Click);
            // 
            // button_videosel
            // 
            this.button_videosel.Location = new System.Drawing.Point(772, 109);
            this.button_videosel.Margin = new System.Windows.Forms.Padding(2);
            this.button_videosel.Name = "button_videosel";
            this.button_videosel.Size = new System.Drawing.Size(75, 26);
            this.button_videosel.TabIndex = 38;
            this.button_videosel.Text = "瀏覽";
            this.button_videosel.UseVisualStyleBackColor = true;
            this.button_videosel.Click += new System.EventHandler(this.button_videosel_Click);
            // 
            // btn_ReconStart
            // 
            this.btn_ReconStart.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btn_ReconStart.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.btn_ReconStart.Location = new System.Drawing.Point(733, 174);
            this.btn_ReconStart.Margin = new System.Windows.Forms.Padding(2);
            this.btn_ReconStart.Name = "btn_ReconStart";
            this.btn_ReconStart.Size = new System.Drawing.Size(114, 37);
            this.btn_ReconStart.TabIndex = 16;
            this.btn_ReconStart.Text = "重建";
            this.btn_ReconStart.UseVisualStyleBackColor = false;
            this.btn_ReconStart.Click += new System.EventHandler(this.btn_ReconStart_Click);
            // 
            // textBox_videosel
            // 
            this.textBox_videosel.Location = new System.Drawing.Point(640, 109);
            this.textBox_videosel.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_videosel.Name = "textBox_videosel";
            this.textBox_videosel.Size = new System.Drawing.Size(118, 29);
            this.textBox_videosel.TabIndex = 37;
            this.textBox_videosel.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textBox_videosel.TextChanged += new System.EventHandler(this.textBox_videosel_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(441, 112);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(195, 20);
            this.label5.TabIndex = 36;
            this.label5.Text = "重建檔案(勾選選項時選擇)";
            // 
            // btn_sep_path
            // 
            this.btn_sep_path.Location = new System.Drawing.Point(344, 69);
            this.btn_sep_path.Margin = new System.Windows.Forms.Padding(2);
            this.btn_sep_path.Name = "btn_sep_path";
            this.btn_sep_path.Size = new System.Drawing.Size(76, 26);
            this.btn_sep_path.TabIndex = 35;
            this.btn_sep_path.Text = "瀏覽";
            this.btn_sep_path.UseVisualStyleBackColor = true;
            this.btn_sep_path.Click += new System.EventHandler(this.button4_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(30, 70);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 20);
            this.label4.TabIndex = 34;
            this.label4.Text = "路徑";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(29, 113);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 20);
            this.label3.TabIndex = 33;
            this.label3.Text = "檔案";
            // 
            // textBox_seppath
            // 
            this.textBox_seppath.Location = new System.Drawing.Point(87, 69);
            this.textBox_seppath.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_seppath.Name = "textBox_seppath";
            this.textBox_seppath.Size = new System.Drawing.Size(248, 29);
            this.textBox_seppath.TabIndex = 32;
            this.textBox_seppath.TextChanged += new System.EventHandler(this.textBox_seppath_TextChanged);
            // 
            // checkBox_notsave
            // 
            this.checkBox_notsave.AutoSize = true;
            this.checkBox_notsave.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.checkBox_notsave.Location = new System.Drawing.Point(86, 192);
            this.checkBox_notsave.Margin = new System.Windows.Forms.Padding(2);
            this.checkBox_notsave.Name = "checkBox_notsave";
            this.checkBox_notsave.Size = new System.Drawing.Size(120, 24);
            this.checkBox_notsave.TabIndex = 31;
            this.checkBox_notsave.Text = "不分離+重建";
            this.checkBox_notsave.UseVisualStyleBackColor = true;
            this.checkBox_notsave.CheckedChanged += new System.EventHandler(this.checkBox_notsave_CheckedChanged);
            // 
            // btn_sepFrame
            // 
            this.btn_sepFrame.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btn_sepFrame.Location = new System.Drawing.Point(238, 172);
            this.btn_sepFrame.Margin = new System.Windows.Forms.Padding(2);
            this.btn_sepFrame.Name = "btn_sepFrame";
            this.btn_sepFrame.Size = new System.Drawing.Size(120, 41);
            this.btn_sepFrame.TabIndex = 27;
            this.btn_sepFrame.Text = "單張分離";
            this.btn_sepFrame.UseVisualStyleBackColor = false;
            this.btn_sepFrame.Click += new System.EventHandler(this.btn_sepFrame_Click_1);
            // 
            // imgBox_RToolReconMap
            // 
            this.imgBox_RToolReconMap.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.imgBox_RToolReconMap.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.imgBox_RToolReconMap.Location = new System.Drawing.Point(502, 300);
            this.imgBox_RToolReconMap.Margin = new System.Windows.Forms.Padding(2);
            this.imgBox_RToolReconMap.Name = "imgBox_RToolReconMap";
            this.imgBox_RToolReconMap.Size = new System.Drawing.Size(400, 546);
            this.imgBox_RToolReconMap.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.imgBox_RToolReconMap.TabIndex = 30;
            this.imgBox_RToolReconMap.TabStop = false;
            this.imgBox_RToolReconMap.Click += new System.EventHandler(this.imgBox_RToolReconMap_Click);
            // 
            // btn_FrameFile
            // 
            this.btn_FrameFile.Location = new System.Drawing.Point(344, 109);
            this.btn_FrameFile.Margin = new System.Windows.Forms.Padding(2);
            this.btn_FrameFile.Name = "btn_FrameFile";
            this.btn_FrameFile.Size = new System.Drawing.Size(75, 26);
            this.btn_FrameFile.TabIndex = 29;
            this.btn_FrameFile.Text = "瀏覽";
            this.btn_FrameFile.UseVisualStyleBackColor = true;
            this.btn_FrameFile.Click += new System.EventHandler(this.btn_FrameFile_Click_1);
            // 
            // checkBox_saveImage
            // 
            this.checkBox_saveImage.AutoSize = true;
            this.checkBox_saveImage.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.checkBox_saveImage.Location = new System.Drawing.Point(87, 163);
            this.checkBox_saveImage.Margin = new System.Windows.Forms.Padding(2);
            this.checkBox_saveImage.Name = "checkBox_saveImage";
            this.checkBox_saveImage.Size = new System.Drawing.Size(104, 24);
            this.checkBox_saveImage.TabIndex = 29;
            this.checkBox_saveImage.Text = "分離+重建";
            this.checkBox_saveImage.UseVisualStyleBackColor = true;
            this.checkBox_saveImage.CheckedChanged += new System.EventHandler(this.checkBox_saveImage_CheckedChanged);
            // 
            // textBox_FrameFile
            // 
            this.textBox_FrameFile.Location = new System.Drawing.Point(86, 109);
            this.textBox_FrameFile.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_FrameFile.Name = "textBox_FrameFile";
            this.textBox_FrameFile.Size = new System.Drawing.Size(248, 29);
            this.textBox_FrameFile.TabIndex = 28;
            this.textBox_FrameFile.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textBox_FrameFile.TextChanged += new System.EventHandler(this.textBox_FrameFile_TextChanged_1);
            // 
            // label_ms
            // 
            this.label_ms.AutoSize = true;
            this.label_ms.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.label_ms.Location = new System.Drawing.Point(645, 244);
            this.label_ms.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_ms.Name = "label_ms";
            this.label_ms.Size = new System.Drawing.Size(45, 20);
            this.label_ms.TabIndex = 19;
            this.label_ms.Text = "毫秒:";
            this.label_ms.Click += new System.EventHandler(this.label_ms_Click);
            // 
            // btn_LoadVideoPath
            // 
            this.btn_LoadVideoPath.Location = new System.Drawing.Point(771, 64);
            this.btn_LoadVideoPath.Margin = new System.Windows.Forms.Padding(2);
            this.btn_LoadVideoPath.Name = "btn_LoadVideoPath";
            this.btn_LoadVideoPath.Size = new System.Drawing.Size(76, 26);
            this.btn_LoadVideoPath.TabIndex = 13;
            this.btn_LoadVideoPath.Text = "瀏覽";
            this.btn_LoadVideoPath.UseVisualStyleBackColor = true;
            this.btn_LoadVideoPath.Click += new System.EventHandler(this.btn_LoadVideoPath_Click);
            // 
            // label_s
            // 
            this.label_s.AutoSize = true;
            this.label_s.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.label_s.Location = new System.Drawing.Point(579, 244);
            this.label_s.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_s.Name = "label_s";
            this.label_s.Size = new System.Drawing.Size(29, 20);
            this.label_s.TabIndex = 18;
            this.label_s.Text = "秒:";
            this.label_s.Click += new System.EventHandler(this.label_s_Click);
            // 
            // imgBox_LToolReconMap
            // 
            this.imgBox_LToolReconMap.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.imgBox_LToolReconMap.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.imgBox_LToolReconMap.Location = new System.Drawing.Point(72, 300);
            this.imgBox_LToolReconMap.Margin = new System.Windows.Forms.Padding(2);
            this.imgBox_LToolReconMap.Name = "imgBox_LToolReconMap";
            this.imgBox_LToolReconMap.Size = new System.Drawing.Size(400, 546);
            this.imgBox_LToolReconMap.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.imgBox_LToolReconMap.TabIndex = 2;
            this.imgBox_LToolReconMap.TabStop = false;
            // 
            // label_min
            // 
            this.label_min.AutoSize = true;
            this.label_min.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.label_min.Location = new System.Drawing.Point(401, 244);
            this.label_min.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_min.Name = "label_min";
            this.label_min.Size = new System.Drawing.Size(132, 20);
            this.label_min.TabIndex = 17;
            this.label_min.Text = "三維重建時間_分:";
            this.label_min.Click += new System.EventHandler(this.label_min_Click);
            // 
            // label_VideoPath
            // 
            this.label_VideoPath.AutoSize = true;
            this.label_VideoPath.Location = new System.Drawing.Point(443, 69);
            this.label_VideoPath.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_VideoPath.Name = "label_VideoPath";
            this.label_VideoPath.Size = new System.Drawing.Size(73, 20);
            this.label_VideoPath.TabIndex = 27;
            this.label_VideoPath.Text = "重建路徑";
            this.label_VideoPath.Click += new System.EventHandler(this.label_VideoPath_Click);
            // 
            // textBox_LoadVideoPath
            // 
            this.textBox_LoadVideoPath.Font = new System.Drawing.Font("微軟正黑體", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.textBox_LoadVideoPath.Location = new System.Drawing.Point(520, 64);
            this.textBox_LoadVideoPath.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_LoadVideoPath.Name = "textBox_LoadVideoPath";
            this.textBox_LoadVideoPath.Size = new System.Drawing.Size(238, 26);
            this.textBox_LoadVideoPath.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(205, 955);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 20);
            this.label2.TabIndex = 22;
            this.label2.Text = "Error";
            // 
            // label_min2
            // 
            this.label_min2.AutoSize = true;
            this.label_min2.Location = new System.Drawing.Point(353, 955);
            this.label_min2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_min2.Name = "label_min2";
            this.label_min2.Size = new System.Drawing.Size(42, 20);
            this.label_min2.TabIndex = 21;
            this.label_min2.Text = "Min:";
            // 
            // label_Max
            // 
            this.label_Max.AutoSize = true;
            this.label_Max.Location = new System.Drawing.Point(484, 955);
            this.label_Max.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_Max.Name = "label_Max";
            this.label_Max.Size = new System.Drawing.Size(45, 20);
            this.label_Max.TabIndex = 20;
            this.label_Max.Text = "Max:";
            this.label_Max.Click += new System.EventHandler(this.label_Max_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.name6textBox);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.name5textBox);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.name4textBox);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.name3textBox);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.name2textBox);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.name1textBox);
            this.groupBox1.Controls.Add(this.button4);
            this.groupBox1.Controls.Add(this.groupBox4);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.textBox_autolabel);
            this.groupBox1.Controls.Add(this.datatextBox);
            this.groupBox1.Controls.Add(this.btn_period);
            this.groupBox1.Controls.Add(this.label_min3);
            this.groupBox1.Controls.Add(this.textBox3);
            this.groupBox1.Controls.Add(this.label_sec3);
            this.groupBox1.Controls.Add(this.label_ms3);
            this.groupBox1.Controls.Add(this.btn_FilePath);
            this.groupBox1.Controls.Add(this.label_FilePath2);
            this.groupBox1.Controls.Add(this.textBox_FilePath);
            this.groupBox1.Controls.Add(this.label_FilePath1);
            this.groupBox1.Controls.Add(this.imgBox_LWearDepthMap);
            this.groupBox1.Controls.Add(this.btn_SaveImgPath);
            this.groupBox1.Controls.Add(this.btn_WearAnaStart);
            this.groupBox1.Controls.Add(this.textBox_SaveImgPath);
            this.groupBox1.Location = new System.Drawing.Point(977, 30);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(829, 913);
            this.groupBox1.TabIndex = 26;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "磨耗深度量化";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(566, 147);
            this.button4.Margin = new System.Windows.Forms.Padding(2);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(96, 26);
            this.button4.TabIndex = 64;
            this.button4.Text = "瀏覽";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click_4);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.radioButton2);
            this.groupBox4.Controls.Add(this.radioButton4);
            this.groupBox4.Controls.Add(this.radioButton6);
            this.groupBox4.Location = new System.Drawing.Point(511, 240);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(313, 69);
            this.groupBox4.TabIndex = 58;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "分析模式";
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Checked = true;
            this.radioButton2.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.radioButton2.Location = new System.Drawing.Point(6, 32);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(52, 24);
            this.radioButton2.TabIndex = 42;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "LRs";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton4
            // 
            this.radioButton4.AutoSize = true;
            this.radioButton4.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.radioButton4.Location = new System.Drawing.Point(71, 32);
            this.radioButton4.Name = "radioButton4";
            this.radioButton4.Size = new System.Drawing.Size(56, 24);
            this.radioButton4.TabIndex = 43;
            this.radioButton4.TabStop = true;
            this.radioButton4.Text = "HRs";
            this.radioButton4.UseVisualStyleBackColor = true;
            // 
            // radioButton6
            // 
            this.radioButton6.AutoSize = true;
            this.radioButton6.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.radioButton6.Location = new System.Drawing.Point(140, 32);
            this.radioButton6.Name = "radioButton6";
            this.radioButton6.Size = new System.Drawing.Size(123, 24);
            this.radioButton6.TabIndex = 44;
            this.radioButton6.TabStop = true;
            this.radioButton6.Text = "Other(setup)";
            this.radioButton6.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(35, 146);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(105, 20);
            this.label7.TabIndex = 63;
            this.label7.Text = "資料彙整路徑";
            // 
            // textBox_autolabel
            // 
            this.textBox_autolabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_autolabel.Location = new System.Drawing.Point(511, 327);
            this.textBox_autolabel.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_autolabel.Multiline = true;
            this.textBox_autolabel.Name = "textBox_autolabel";
            this.textBox_autolabel.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox_autolabel.Size = new System.Drawing.Size(318, 120);
            this.textBox_autolabel.TabIndex = 37;
            this.textBox_autolabel.TextChanged += new System.EventHandler(this.textBox_autolabel_TextChanged);
            // 
            // datatextBox
            // 
            this.datatextBox.Font = new System.Drawing.Font("微軟正黑體", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.datatextBox.Location = new System.Drawing.Point(144, 146);
            this.datatextBox.Margin = new System.Windows.Forms.Padding(2);
            this.datatextBox.Name = "datatextBox";
            this.datatextBox.Size = new System.Drawing.Size(409, 26);
            this.datatextBox.TabIndex = 62;
            this.datatextBox.Text = "‪";
            // 
            // btn_period
            // 
            this.btn_period.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btn_period.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btn_period.Location = new System.Drawing.Point(676, 130);
            this.btn_period.Margin = new System.Windows.Forms.Padding(2);
            this.btn_period.Name = "btn_period";
            this.btn_period.Size = new System.Drawing.Size(109, 43);
            this.btn_period.TabIndex = 33;
            this.btn_period.Text = "period產生";
            this.btn_period.UseVisualStyleBackColor = false;
            this.btn_period.Click += new System.EventHandler(this.btn_period_Click);
            // 
            // label_min3
            // 
            this.label_min3.AutoSize = true;
            this.label_min3.Location = new System.Drawing.Point(46, 240);
            this.label_min3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_min3.Name = "label_min3";
            this.label_min3.Size = new System.Drawing.Size(208, 20);
            this.label_min3.TabIndex = 27;
            this.label_min3.Text = "歷程分析+自動標註時間_分:";
            this.label_min3.Click += new System.EventHandler(this.label_min3_Click);
            // 
            // textBox3
            // 
            this.textBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox3.Location = new System.Drawing.Point(511, 451);
            this.textBox3.Margin = new System.Windows.Forms.Padding(2);
            this.textBox3.Multiline = true;
            this.textBox3.Name = "textBox3";
            this.textBox3.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox3.Size = new System.Drawing.Size(318, 135);
            this.textBox3.TabIndex = 24;
            this.textBox3.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            // 
            // label_sec3
            // 
            this.label_sec3.AutoSize = true;
            this.label_sec3.Location = new System.Drawing.Point(294, 240);
            this.label_sec3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_sec3.Name = "label_sec3";
            this.label_sec3.Size = new System.Drawing.Size(29, 20);
            this.label_sec3.TabIndex = 28;
            this.label_sec3.Text = "秒:";
            // 
            // label_ms3
            // 
            this.label_ms3.AutoSize = true;
            this.label_ms3.Location = new System.Drawing.Point(366, 240);
            this.label_ms3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_ms3.Name = "label_ms3";
            this.label_ms3.Size = new System.Drawing.Size(45, 20);
            this.label_ms3.TabIndex = 29;
            this.label_ms3.Text = "毫秒:";
            // 
            // imgBox_RWearDepthMap
            // 
            this.imgBox_RWearDepthMap.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.imgBox_RWearDepthMap.BackColor = System.Drawing.Color.Transparent;
            this.imgBox_RWearDepthMap.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.imgBox_RWearDepthMap.Location = new System.Drawing.Point(552, 949);
            this.imgBox_RWearDepthMap.Margin = new System.Windows.Forms.Padding(2);
            this.imgBox_RWearDepthMap.Name = "imgBox_RWearDepthMap";
            this.imgBox_RWearDepthMap.Size = new System.Drawing.Size(65, 37);
            this.imgBox_RWearDepthMap.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.imgBox_RWearDepthMap.TabIndex = 32;
            this.imgBox_RWearDepthMap.TabStop = false;
            // 
            // btn_FilePath
            // 
            this.btn_FilePath.Location = new System.Drawing.Point(566, 95);
            this.btn_FilePath.Margin = new System.Windows.Forms.Padding(2);
            this.btn_FilePath.Name = "btn_FilePath";
            this.btn_FilePath.Size = new System.Drawing.Size(96, 26);
            this.btn_FilePath.TabIndex = 31;
            this.btn_FilePath.Text = "瀏覽";
            this.btn_FilePath.UseVisualStyleBackColor = true;
            this.btn_FilePath.Click += new System.EventHandler(this.btn_FilePath_Click);
            // 
            // label_FilePath2
            // 
            this.label_FilePath2.AutoSize = true;
            this.label_FilePath2.Location = new System.Drawing.Point(35, 98);
            this.label_FilePath2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_FilePath2.Name = "label_FilePath2";
            this.label_FilePath2.Size = new System.Drawing.Size(105, 20);
            this.label_FilePath2.TabIndex = 30;
            this.label_FilePath2.Text = "個別歷程追蹤";
            this.label_FilePath2.Click += new System.EventHandler(this.label_FilePath2_Click);
            // 
            // textBox_FilePath
            // 
            this.textBox_FilePath.Font = new System.Drawing.Font("微軟正黑體", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.textBox_FilePath.Location = new System.Drawing.Point(144, 96);
            this.textBox_FilePath.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_FilePath.Name = "textBox_FilePath";
            this.textBox_FilePath.Size = new System.Drawing.Size(409, 26);
            this.textBox_FilePath.TabIndex = 29;
            this.textBox_FilePath.TextChanged += new System.EventHandler(this.textBox_FilePath_TextChanged);
            // 
            // label_FilePath1
            // 
            this.label_FilePath1.AutoSize = true;
            this.label_FilePath1.Location = new System.Drawing.Point(35, 47);
            this.label_FilePath1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_FilePath1.Name = "label_FilePath1";
            this.label_FilePath1.Size = new System.Drawing.Size(73, 20);
            this.label_FilePath1.TabIndex = 28;
            this.label_FilePath1.Text = "分析檔案";
            // 
            // imgBox_LWearDepthMap
            // 
            this.imgBox_LWearDepthMap.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.imgBox_LWearDepthMap.BackColor = System.Drawing.Color.Transparent;
            this.imgBox_LWearDepthMap.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.imgBox_LWearDepthMap.Location = new System.Drawing.Point(38, 286);
            this.imgBox_LWearDepthMap.Margin = new System.Windows.Forms.Padding(2);
            this.imgBox_LWearDepthMap.Name = "imgBox_LWearDepthMap";
            this.imgBox_LWearDepthMap.Size = new System.Drawing.Size(400, 546);
            this.imgBox_LWearDepthMap.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.imgBox_LWearDepthMap.TabIndex = 3;
            this.imgBox_LWearDepthMap.TabStop = false;
            // 
            // btn_SaveImgPath
            // 
            this.btn_SaveImgPath.Location = new System.Drawing.Point(566, 44);
            this.btn_SaveImgPath.Margin = new System.Windows.Forms.Padding(2);
            this.btn_SaveImgPath.Name = "btn_SaveImgPath";
            this.btn_SaveImgPath.Size = new System.Drawing.Size(96, 26);
            this.btn_SaveImgPath.TabIndex = 14;
            this.btn_SaveImgPath.Text = "瀏覽";
            this.btn_SaveImgPath.UseVisualStyleBackColor = true;
            this.btn_SaveImgPath.Click += new System.EventHandler(this.btn_SaveImgPath_Click);
            // 
            // btn_WearAnaStart
            // 
            this.btn_WearAnaStart.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btn_WearAnaStart.Location = new System.Drawing.Point(677, 44);
            this.btn_WearAnaStart.Margin = new System.Windows.Forms.Padding(2);
            this.btn_WearAnaStart.Name = "btn_WearAnaStart";
            this.btn_WearAnaStart.Size = new System.Drawing.Size(109, 74);
            this.btn_WearAnaStart.TabIndex = 23;
            this.btn_WearAnaStart.Text = "分析";
            this.btn_WearAnaStart.UseVisualStyleBackColor = false;
            this.btn_WearAnaStart.Click += new System.EventHandler(this.btn_WearAnaStart_Click);
            // 
            // textBox_SaveImgPath
            // 
            this.textBox_SaveImgPath.Font = new System.Drawing.Font("微軟正黑體", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.textBox_SaveImgPath.Location = new System.Drawing.Point(112, 46);
            this.textBox_SaveImgPath.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_SaveImgPath.Name = "textBox_SaveImgPath";
            this.textBox_SaveImgPath.Size = new System.Drawing.Size(441, 26);
            this.textBox_SaveImgPath.TabIndex = 5;
            this.textBox_SaveImgPath.TextChanged += new System.EventHandler(this.textBox_SaveImgPath_TextChanged);
            // 
            // Controlsystem
            // 
            this.Controlsystem.Controls.Add(this.button5);
            this.Controlsystem.Controls.Add(this.groupBox5);
            this.Controlsystem.Controls.Add(this.groupBox_Measure);
            this.Controlsystem.Controls.Add(this.groupBox_Move);
            this.Controlsystem.Controls.Add(this.groupBox_ImgSystem);
            this.Controlsystem.Controls.Add(this.groupBox_Position);
            this.Controlsystem.Font = new System.Drawing.Font("微軟正黑體", 10F);
            this.Controlsystem.Location = new System.Drawing.Point(4, 34);
            this.Controlsystem.Margin = new System.Windows.Forms.Padding(2);
            this.Controlsystem.Name = "Controlsystem";
            this.Controlsystem.Padding = new System.Windows.Forms.Padding(2);
            this.Controlsystem.Size = new System.Drawing.Size(2030, 1234);
            this.Controlsystem.TabIndex = 0;
            this.Controlsystem.Text = "拍攝系統控制";
            this.Controlsystem.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.Crimson;
            this.button5.Location = new System.Drawing.Point(934, 231);
            this.button5.Margin = new System.Windows.Forms.Padding(2);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(97, 339);
            this.button5.TabIndex = 61;
            this.button5.Text = "緊急斷電";
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.button5_Click_1);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.radioButton7);
            this.groupBox5.Controls.Add(this.radioButton8);
            this.groupBox5.Controls.Add(this.radioButton9);
            this.groupBox5.Location = new System.Drawing.Point(934, 112);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(262, 82);
            this.groupBox5.TabIndex = 60;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "拍攝模式";
            // 
            // radioButton7
            // 
            this.radioButton7.AutoSize = true;
            this.radioButton7.Checked = true;
            this.radioButton7.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.radioButton7.Location = new System.Drawing.Point(6, 32);
            this.radioButton7.Name = "radioButton7";
            this.radioButton7.Size = new System.Drawing.Size(52, 24);
            this.radioButton7.TabIndex = 42;
            this.radioButton7.TabStop = true;
            this.radioButton7.Text = "LRs";
            this.radioButton7.UseVisualStyleBackColor = true;
            // 
            // radioButton8
            // 
            this.radioButton8.AutoSize = true;
            this.radioButton8.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.radioButton8.Location = new System.Drawing.Point(71, 32);
            this.radioButton8.Name = "radioButton8";
            this.radioButton8.Size = new System.Drawing.Size(56, 24);
            this.radioButton8.TabIndex = 43;
            this.radioButton8.Text = "HRs";
            this.radioButton8.UseVisualStyleBackColor = true;
            // 
            // radioButton9
            // 
            this.radioButton9.AutoSize = true;
            this.radioButton9.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.radioButton9.Location = new System.Drawing.Point(140, 32);
            this.radioButton9.Name = "radioButton9";
            this.radioButton9.Size = new System.Drawing.Size(123, 24);
            this.radioButton9.TabIndex = 44;
            this.radioButton9.Text = "Other(setup)";
            this.radioButton9.UseVisualStyleBackColor = true;
            // 
            // groupBox_Measure
            // 
            this.groupBox_Measure.Controls.Add(this.label_ms1);
            this.groupBox_Measure.Controls.Add(this.textBox1);
            this.groupBox_Measure.Controls.Add(this.label_sec1);
            this.groupBox_Measure.Controls.Add(this.label_min1);
            this.groupBox_Measure.Controls.Add(this.button3);
            this.groupBox_Measure.Controls.Add(this.label_delay);
            this.groupBox_Measure.Controls.Add(this.label1);
            this.groupBox_Measure.Controls.Add(this.textBox2);
            this.groupBox_Measure.Controls.Add(this.textBox_folderPath);
            this.groupBox_Measure.Controls.Add(this.textBox_MoveName);
            this.groupBox_Measure.Controls.Add(this.btn_MeasureStart);
            this.groupBox_Measure.Controls.Add(this.label_MovieName);
            this.groupBox_Measure.Controls.Add(this.btn_FolderPath);
            this.groupBox_Measure.Controls.Add(this.textBox_TotalFrame);
            this.groupBox_Measure.Controls.Add(this.label_TotalFrame);
            this.groupBox_Measure.Location = new System.Drawing.Point(23, 22);
            this.groupBox_Measure.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox_Measure.Name = "groupBox_Measure";
            this.groupBox_Measure.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox_Measure.Size = new System.Drawing.Size(884, 187);
            this.groupBox_Measure.TabIndex = 23;
            this.groupBox_Measure.TabStop = false;
            this.groupBox_Measure.Text = "影像量測";
            // 
            // label_ms1
            // 
            this.label_ms1.AutoSize = true;
            this.label_ms1.Location = new System.Drawing.Point(622, 86);
            this.label_ms1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_ms1.Name = "label_ms1";
            this.label_ms1.Size = new System.Drawing.Size(0, 18);
            this.label_ms1.TabIndex = 28;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(679, 76);
            this.textBox1.Margin = new System.Windows.Forms.Padding(2);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox1.Size = new System.Drawing.Size(186, 98);
            this.textBox1.TabIndex = 15;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label_sec1
            // 
            this.label_sec1.AutoSize = true;
            this.label_sec1.Location = new System.Drawing.Point(552, 86);
            this.label_sec1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_sec1.Name = "label_sec1";
            this.label_sec1.Size = new System.Drawing.Size(0, 18);
            this.label_sec1.TabIndex = 27;
            this.label_sec1.Click += new System.EventHandler(this.label4_Click);
            // 
            // label_min1
            // 
            this.label_min1.AutoSize = true;
            this.label_min1.Location = new System.Drawing.Point(482, 86);
            this.label_min1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_min1.Name = "label_min1";
            this.label_min1.Size = new System.Drawing.Size(0, 18);
            this.label_min1.TabIndex = 26;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.LightSlateGray;
            this.button3.Location = new System.Drawing.Point(510, 122);
            this.button3.Margin = new System.Windows.Forms.Padding(2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(120, 46);
            this.button3.TabIndex = 25;
            this.button3.Text = "高倍率量測";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label_delay
            // 
            this.label_delay.AutoSize = true;
            this.label_delay.Location = new System.Drawing.Point(10, 150);
            this.label_delay.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_delay.Name = "label_delay";
            this.label_delay.Size = new System.Drawing.Size(92, 18);
            this.label_delay.TabIndex = 23;
            this.label_delay.Text = "錄影延後時間";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 39);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 18);
            this.label1.TabIndex = 10;
            this.label1.Text = "影片儲存路徑";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(110, 147);
            this.textBox2.Margin = new System.Windows.Forms.Padding(2);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(59, 25);
            this.textBox2.TabIndex = 22;
            this.textBox2.Text = "0";
            this.textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // textBox_folderPath
            // 
            this.textBox_folderPath.Location = new System.Drawing.Point(110, 37);
            this.textBox_folderPath.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_folderPath.Name = "textBox_folderPath";
            this.textBox_folderPath.Size = new System.Drawing.Size(550, 25);
            this.textBox_folderPath.TabIndex = 11;
            this.textBox_folderPath.TextChanged += new System.EventHandler(this.textBox_folderPath_TextChanged);
            // 
            // textBox_MoveName
            // 
            this.textBox_MoveName.Location = new System.Drawing.Point(110, 73);
            this.textBox_MoveName.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_MoveName.Name = "textBox_MoveName";
            this.textBox_MoveName.Size = new System.Drawing.Size(550, 25);
            this.textBox_MoveName.TabIndex = 13;
            this.textBox_MoveName.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textBox_MoveName.TextChanged += new System.EventHandler(this.textBox_MoveName_TextChanged);
            // 
            // btn_MeasureStart
            // 
            this.btn_MeasureStart.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btn_MeasureStart.Location = new System.Drawing.Point(351, 122);
            this.btn_MeasureStart.Margin = new System.Windows.Forms.Padding(2);
            this.btn_MeasureStart.Name = "btn_MeasureStart";
            this.btn_MeasureStart.Size = new System.Drawing.Size(120, 46);
            this.btn_MeasureStart.TabIndex = 4;
            this.btn_MeasureStart.Text = "開始量測";
            this.btn_MeasureStart.UseVisualStyleBackColor = false;
            this.btn_MeasureStart.Click += new System.EventHandler(this.btn_MeasureStart_Click);
            // 
            // label_MovieName
            // 
            this.label_MovieName.AutoSize = true;
            this.label_MovieName.Location = new System.Drawing.Point(10, 76);
            this.label_MovieName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_MovieName.Name = "label_MovieName";
            this.label_MovieName.Size = new System.Drawing.Size(64, 18);
            this.label_MovieName.TabIndex = 14;
            this.label_MovieName.Text = "影片名稱";
            // 
            // btn_FolderPath
            // 
            this.btn_FolderPath.Location = new System.Drawing.Point(679, 37);
            this.btn_FolderPath.Margin = new System.Windows.Forms.Padding(2);
            this.btn_FolderPath.Name = "btn_FolderPath";
            this.btn_FolderPath.Size = new System.Drawing.Size(120, 32);
            this.btn_FolderPath.TabIndex = 12;
            this.btn_FolderPath.Text = "瀏覽";
            this.btn_FolderPath.UseVisualStyleBackColor = true;
            this.btn_FolderPath.Click += new System.EventHandler(this.btn_FolderPath_Click);
            // 
            // textBox_TotalFrame
            // 
            this.textBox_TotalFrame.Location = new System.Drawing.Point(110, 110);
            this.textBox_TotalFrame.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_TotalFrame.Name = "textBox_TotalFrame";
            this.textBox_TotalFrame.Size = new System.Drawing.Size(184, 25);
            this.textBox_TotalFrame.TabIndex = 17;
            this.textBox_TotalFrame.Text = "1100";
            this.textBox_TotalFrame.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textBox_TotalFrame.TextChanged += new System.EventHandler(this.textBox_TotalFrame_TextChanged);
            // 
            // label_TotalFrame
            // 
            this.label_TotalFrame.AutoSize = true;
            this.label_TotalFrame.Location = new System.Drawing.Point(10, 113);
            this.label_TotalFrame.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_TotalFrame.Name = "label_TotalFrame";
            this.label_TotalFrame.Size = new System.Drawing.Size(78, 18);
            this.label_TotalFrame.TabIndex = 18;
            this.label_TotalFrame.Text = "目標總幀數";
            this.label_TotalFrame.Click += new System.EventHandler(this.label_TotalFrame_Click);
            // 
            // groupBox_Move
            // 
            this.groupBox_Move.Controls.Add(this.button2);
            this.groupBox_Move.Controls.Add(this.button1);
            this.groupBox_Move.Controls.Add(this.btn_MoveImgDOWN);
            this.groupBox_Move.Controls.Add(this.radioButton_rela);
            this.groupBox_Move.Controls.Add(this.radioButton_abs);
            this.groupBox_Move.Controls.Add(this.label_Tool_Tar);
            this.groupBox_Move.Controls.Add(this.textBox_Tool_TarPosi);
            this.groupBox_Move.Controls.Add(this.btn_MoveImgUP);
            this.groupBox_Move.Controls.Add(this.textBox_Tool_TarSpeed);
            this.groupBox_Move.Controls.Add(this.btn_MoveTool);
            this.groupBox_Move.Controls.Add(this.textBox_Tool_TarAcc);
            this.groupBox_Move.Controls.Add(this.label_TarAcc);
            this.groupBox_Move.Controls.Add(this.textBox_Img_TarPosi);
            this.groupBox_Move.Controls.Add(this.label_TarSpeed);
            this.groupBox_Move.Controls.Add(this.textBox_Img_TarSpeed);
            this.groupBox_Move.Controls.Add(this.label_TarPosi);
            this.groupBox_Move.Controls.Add(this.textBox_Img_TarAcc);
            this.groupBox_Move.Controls.Add(this.btn_Move);
            this.groupBox_Move.Controls.Add(this.label_Img_Tar);
            this.groupBox_Move.Location = new System.Drawing.Point(469, 213);
            this.groupBox_Move.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox_Move.Name = "groupBox_Move";
            this.groupBox_Move.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox_Move.Size = new System.Drawing.Size(438, 357);
            this.groupBox_Move.TabIndex = 8;
            this.groupBox_Move.TabStop = false;
            this.groupBox_Move.Text = "馬達控制面板";
            this.groupBox_Move.Enter += new System.EventHandler(this.groupBox_Move_Enter);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.LightSteelBlue;
            this.button2.Location = new System.Drawing.Point(233, 270);
            this.button2.Margin = new System.Windows.Forms.Padding(2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(162, 33);
            this.button2.TabIndex = 23;
            this.button2.Text = "移至量測位置(標準件)";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.Button2_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.button1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button1.Location = new System.Drawing.Point(28, 270);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(186, 33);
            this.button1.TabIndex = 22;
            this.button1.Text = "移置拆裝刀位置";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // btn_MoveImgDOWN
            // 
            this.btn_MoveImgDOWN.Location = new System.Drawing.Point(243, 171);
            this.btn_MoveImgDOWN.Margin = new System.Windows.Forms.Padding(2);
            this.btn_MoveImgDOWN.Name = "btn_MoveImgDOWN";
            this.btn_MoveImgDOWN.Size = new System.Drawing.Size(70, 32);
            this.btn_MoveImgDOWN.TabIndex = 21;
            this.btn_MoveImgDOWN.Text = "向下";
            this.btn_MoveImgDOWN.UseVisualStyleBackColor = true;
            this.btn_MoveImgDOWN.Click += new System.EventHandler(this.btn_MoveImgDOWN_Click);
            // 
            // radioButton_rela
            // 
            this.radioButton_rela.AutoSize = true;
            this.radioButton_rela.Checked = true;
            this.radioButton_rela.Location = new System.Drawing.Point(11, 228);
            this.radioButton_rela.Margin = new System.Windows.Forms.Padding(2);
            this.radioButton_rela.Name = "radioButton_rela";
            this.radioButton_rela.Size = new System.Drawing.Size(54, 22);
            this.radioButton_rela.TabIndex = 9;
            this.radioButton_rela.TabStop = true;
            this.radioButton_rela.Text = "相對";
            this.radioButton_rela.UseVisualStyleBackColor = true;
            // 
            // radioButton_abs
            // 
            this.radioButton_abs.AutoSize = true;
            this.radioButton_abs.Location = new System.Drawing.Point(64, 228);
            this.radioButton_abs.Margin = new System.Windows.Forms.Padding(2);
            this.radioButton_abs.Name = "radioButton_abs";
            this.radioButton_abs.Size = new System.Drawing.Size(54, 22);
            this.radioButton_abs.TabIndex = 10;
            this.radioButton_abs.TabStop = true;
            this.radioButton_abs.Text = "絕對";
            this.radioButton_abs.UseVisualStyleBackColor = true;
            // 
            // label_Tool_Tar
            // 
            this.label_Tool_Tar.AutoSize = true;
            this.label_Tool_Tar.Location = new System.Drawing.Point(92, 20);
            this.label_Tool_Tar.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_Tool_Tar.Name = "label_Tool_Tar";
            this.label_Tool_Tar.Size = new System.Drawing.Size(92, 18);
            this.label_Tool_Tar.TabIndex = 9;
            this.label_Tool_Tar.Text = "刀具相位調控";
            // 
            // textBox_Tool_TarPosi
            // 
            this.textBox_Tool_TarPosi.Location = new System.Drawing.Point(64, 48);
            this.textBox_Tool_TarPosi.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_Tool_TarPosi.Name = "textBox_Tool_TarPosi";
            this.textBox_Tool_TarPosi.Size = new System.Drawing.Size(151, 25);
            this.textBox_Tool_TarPosi.TabIndex = 9;
            this.textBox_Tool_TarPosi.Text = "0";
            this.textBox_Tool_TarPosi.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textBox_Tool_TarPosi.TextChanged += new System.EventHandler(this.textBox_Tool_TarPosi_TextChanged);
            // 
            // btn_MoveImgUP
            // 
            this.btn_MoveImgUP.Location = new System.Drawing.Point(328, 171);
            this.btn_MoveImgUP.Margin = new System.Windows.Forms.Padding(2);
            this.btn_MoveImgUP.Name = "btn_MoveImgUP";
            this.btn_MoveImgUP.Size = new System.Drawing.Size(65, 32);
            this.btn_MoveImgUP.TabIndex = 20;
            this.btn_MoveImgUP.Text = "向上";
            this.btn_MoveImgUP.UseVisualStyleBackColor = true;
            this.btn_MoveImgUP.Click += new System.EventHandler(this.btn_MoveImgUP_Click);
            // 
            // textBox_Tool_TarSpeed
            // 
            this.textBox_Tool_TarSpeed.Location = new System.Drawing.Point(64, 87);
            this.textBox_Tool_TarSpeed.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_Tool_TarSpeed.Name = "textBox_Tool_TarSpeed";
            this.textBox_Tool_TarSpeed.Size = new System.Drawing.Size(151, 25);
            this.textBox_Tool_TarSpeed.TabIndex = 10;
            this.textBox_Tool_TarSpeed.Text = "0";
            this.textBox_Tool_TarSpeed.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textBox_Tool_TarSpeed.TextChanged += new System.EventHandler(this.textBox_Tool_TarSpeed_TextChanged);
            // 
            // btn_MoveTool
            // 
            this.btn_MoveTool.Location = new System.Drawing.Point(64, 171);
            this.btn_MoveTool.Margin = new System.Windows.Forms.Padding(2);
            this.btn_MoveTool.Name = "btn_MoveTool";
            this.btn_MoveTool.Size = new System.Drawing.Size(150, 32);
            this.btn_MoveTool.TabIndex = 19;
            this.btn_MoveTool.Text = "刀具移動";
            this.btn_MoveTool.UseVisualStyleBackColor = true;
            this.btn_MoveTool.Click += new System.EventHandler(this.btn_MoveTool_Click);
            // 
            // textBox_Tool_TarAcc
            // 
            this.textBox_Tool_TarAcc.Location = new System.Drawing.Point(64, 131);
            this.textBox_Tool_TarAcc.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_Tool_TarAcc.Name = "textBox_Tool_TarAcc";
            this.textBox_Tool_TarAcc.Size = new System.Drawing.Size(151, 25);
            this.textBox_Tool_TarAcc.TabIndex = 11;
            this.textBox_Tool_TarAcc.Text = "0";
            this.textBox_Tool_TarAcc.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label_TarAcc
            // 
            this.label_TarAcc.AutoSize = true;
            this.label_TarAcc.Location = new System.Drawing.Point(14, 134);
            this.label_TarAcc.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_TarAcc.Name = "label_TarAcc";
            this.label_TarAcc.Size = new System.Drawing.Size(50, 18);
            this.label_TarAcc.TabIndex = 18;
            this.label_TarAcc.Text = "加速度";
            // 
            // textBox_Img_TarPosi
            // 
            this.textBox_Img_TarPosi.Location = new System.Drawing.Point(244, 48);
            this.textBox_Img_TarPosi.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_Img_TarPosi.Name = "textBox_Img_TarPosi";
            this.textBox_Img_TarPosi.Size = new System.Drawing.Size(151, 25);
            this.textBox_Img_TarPosi.TabIndex = 12;
            this.textBox_Img_TarPosi.Text = "100";
            this.textBox_Img_TarPosi.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label_TarSpeed
            // 
            this.label_TarSpeed.AutoSize = true;
            this.label_TarSpeed.Location = new System.Drawing.Point(27, 90);
            this.label_TarSpeed.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_TarSpeed.Name = "label_TarSpeed";
            this.label_TarSpeed.Size = new System.Drawing.Size(36, 18);
            this.label_TarSpeed.TabIndex = 17;
            this.label_TarSpeed.Text = "速度";
            // 
            // textBox_Img_TarSpeed
            // 
            this.textBox_Img_TarSpeed.Location = new System.Drawing.Point(244, 87);
            this.textBox_Img_TarSpeed.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_Img_TarSpeed.Name = "textBox_Img_TarSpeed";
            this.textBox_Img_TarSpeed.Size = new System.Drawing.Size(151, 25);
            this.textBox_Img_TarSpeed.TabIndex = 13;
            this.textBox_Img_TarSpeed.Text = "20";
            this.textBox_Img_TarSpeed.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label_TarPosi
            // 
            this.label_TarPosi.AutoSize = true;
            this.label_TarPosi.Location = new System.Drawing.Point(27, 50);
            this.label_TarPosi.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_TarPosi.Name = "label_TarPosi";
            this.label_TarPosi.Size = new System.Drawing.Size(36, 18);
            this.label_TarPosi.TabIndex = 16;
            this.label_TarPosi.Text = "位置";
            // 
            // textBox_Img_TarAcc
            // 
            this.textBox_Img_TarAcc.Location = new System.Drawing.Point(244, 131);
            this.textBox_Img_TarAcc.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_Img_TarAcc.Name = "textBox_Img_TarAcc";
            this.textBox_Img_TarAcc.Size = new System.Drawing.Size(151, 25);
            this.textBox_Img_TarAcc.TabIndex = 14;
            this.textBox_Img_TarAcc.Text = "10";
            this.textBox_Img_TarAcc.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textBox_Img_TarAcc.TextChanged += new System.EventHandler(this.textBox_Img_TarAcc_TextChanged);
            // 
            // btn_Move
            // 
            this.btn_Move.Location = new System.Drawing.Point(130, 222);
            this.btn_Move.Margin = new System.Windows.Forms.Padding(2);
            this.btn_Move.Name = "btn_Move";
            this.btn_Move.Size = new System.Drawing.Size(264, 32);
            this.btn_Move.TabIndex = 10;
            this.btn_Move.Text = "移動";
            this.btn_Move.UseVisualStyleBackColor = true;
            this.btn_Move.Click += new System.EventHandler(this.btn_Move_Click);
            // 
            // label_Img_Tar
            // 
            this.label_Img_Tar.AutoSize = true;
            this.label_Img_Tar.Location = new System.Drawing.Point(286, 21);
            this.label_Img_Tar.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_Img_Tar.Name = "label_Img_Tar";
            this.label_Img_Tar.Size = new System.Drawing.Size(92, 18);
            this.label_Img_Tar.TabIndex = 15;
            this.label_Img_Tar.Text = "系統高度調控";
            // 
            // groupBox_ImgSystem
            // 
            this.groupBox_ImgSystem.Controls.Add(this.label_EXTime);
            this.groupBox_ImgSystem.Controls.Add(this.textBox_EXTime);
            this.groupBox_ImgSystem.Controls.Add(this.label_extimeSetting);
            this.groupBox_ImgSystem.Controls.Add(this.label_FPS);
            this.groupBox_ImgSystem.Controls.Add(this.label_vblank);
            this.groupBox_ImgSystem.Controls.Add(this.textBox_FPS);
            this.groupBox_ImgSystem.Controls.Add(this.btn_Preview);
            this.groupBox_ImgSystem.Controls.Add(this.btn_Snap);
            this.groupBox_ImgSystem.Location = new System.Drawing.Point(25, 213);
            this.groupBox_ImgSystem.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox_ImgSystem.Name = "groupBox_ImgSystem";
            this.groupBox_ImgSystem.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox_ImgSystem.Size = new System.Drawing.Size(424, 146);
            this.groupBox_ImgSystem.TabIndex = 7;
            this.groupBox_ImgSystem.TabStop = false;
            this.groupBox_ImgSystem.Text = "影像資訊";
            // 
            // label_EXTime
            // 
            this.label_EXTime.AutoSize = true;
            this.label_EXTime.Location = new System.Drawing.Point(217, 79);
            this.label_EXTime.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_EXTime.Name = "label_EXTime";
            this.label_EXTime.Size = new System.Drawing.Size(113, 18);
            this.label_EXTime.TabIndex = 15;
            this.label_EXTime.Text = "Exposure Time :";
            this.label_EXTime.Click += new System.EventHandler(this.label_EXTime_Click);
            // 
            // textBox_EXTime
            // 
            this.textBox_EXTime.Location = new System.Drawing.Point(133, 79);
            this.textBox_EXTime.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_EXTime.Name = "textBox_EXTime";
            this.textBox_EXTime.Size = new System.Drawing.Size(69, 25);
            this.textBox_EXTime.TabIndex = 14;
            this.textBox_EXTime.Text = "170";
            this.textBox_EXTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textBox_EXTime.TextChanged += new System.EventHandler(this.textBox_EXTime_TextChanged);
            // 
            // label_extimeSetting
            // 
            this.label_extimeSetting.AutoSize = true;
            this.label_extimeSetting.Location = new System.Drawing.Point(17, 79);
            this.label_extimeSetting.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_extimeSetting.Name = "label_extimeSetting";
            this.label_extimeSetting.Size = new System.Drawing.Size(112, 18);
            this.label_extimeSetting.TabIndex = 13;
            this.label_extimeSetting.Text = "EX Time setting";
            this.label_extimeSetting.Click += new System.EventHandler(this.label_extimeSetting_Click);
            // 
            // label_FPS
            // 
            this.label_FPS.AutoSize = true;
            this.label_FPS.Location = new System.Drawing.Point(217, 107);
            this.label_FPS.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_FPS.Name = "label_FPS";
            this.label_FPS.Size = new System.Drawing.Size(38, 18);
            this.label_FPS.TabIndex = 12;
            this.label_FPS.Text = "FPS :";
            this.label_FPS.Click += new System.EventHandler(this.label_FPS_Click);
            // 
            // label_vblank
            // 
            this.label_vblank.AutoSize = true;
            this.label_vblank.Location = new System.Drawing.Point(17, 108);
            this.label_vblank.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_vblank.Name = "label_vblank";
            this.label_vblank.Size = new System.Drawing.Size(81, 18);
            this.label_vblank.TabIndex = 11;
            this.label_vblank.Text = "FPS setting";
            // 
            // textBox_FPS
            // 
            this.textBox_FPS.Location = new System.Drawing.Point(133, 105);
            this.textBox_FPS.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_FPS.Name = "textBox_FPS";
            this.textBox_FPS.Size = new System.Drawing.Size(69, 25);
            this.textBox_FPS.TabIndex = 11;
            this.textBox_FPS.Text = "331";
            this.textBox_FPS.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textBox_FPS.TextChanged += new System.EventHandler(this.textBox_FPS_TextChanged);
            // 
            // btn_Preview
            // 
            this.btn_Preview.Location = new System.Drawing.Point(20, 32);
            this.btn_Preview.Margin = new System.Windows.Forms.Padding(2);
            this.btn_Preview.Name = "btn_Preview";
            this.btn_Preview.Size = new System.Drawing.Size(120, 32);
            this.btn_Preview.TabIndex = 0;
            this.btn_Preview.Text = "即時影像";
            this.btn_Preview.UseVisualStyleBackColor = true;
            this.btn_Preview.Click += new System.EventHandler(this.btn_Preview_Click);
            // 
            // btn_Snap
            // 
            this.btn_Snap.Location = new System.Drawing.Point(182, 32);
            this.btn_Snap.Margin = new System.Windows.Forms.Padding(2);
            this.btn_Snap.Name = "btn_Snap";
            this.btn_Snap.Size = new System.Drawing.Size(120, 32);
            this.btn_Snap.TabIndex = 1;
            this.btn_Snap.Text = "快照";
            this.btn_Snap.UseVisualStyleBackColor = true;
            this.btn_Snap.Click += new System.EventHandler(this.btn_Snap_Click);
            // 
            // groupBox_Position
            // 
            this.groupBox_Position.Controls.Add(this.textBox_Img_CurPosi);
            this.groupBox_Position.Controls.Add(this.label_Tool_CurPosi);
            this.groupBox_Position.Controls.Add(this.textBox_Tool_CurPosi);
            this.groupBox_Position.Controls.Add(this.btn_SetOrigin);
            this.groupBox_Position.Controls.Add(this.label_Img_CurPosi);
            this.groupBox_Position.Controls.Add(this.btn_MovetoOrigin);
            this.groupBox_Position.Controls.Add(this.btn_MotorEnable);
            this.groupBox_Position.Controls.Add(this.btn_MotorFree);
            this.groupBox_Position.Location = new System.Drawing.Point(25, 363);
            this.groupBox_Position.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox_Position.Name = "groupBox_Position";
            this.groupBox_Position.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox_Position.Size = new System.Drawing.Size(424, 207);
            this.groupBox_Position.TabIndex = 6;
            this.groupBox_Position.TabStop = false;
            this.groupBox_Position.Text = "位置資訊";
            // 
            // textBox_Img_CurPosi
            // 
            this.textBox_Img_CurPosi.Location = new System.Drawing.Point(111, 66);
            this.textBox_Img_CurPosi.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_Img_CurPosi.Name = "textBox_Img_CurPosi";
            this.textBox_Img_CurPosi.Size = new System.Drawing.Size(151, 25);
            this.textBox_Img_CurPosi.TabIndex = 9;
            this.textBox_Img_CurPosi.Text = "0";
            this.textBox_Img_CurPosi.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label_Tool_CurPosi
            // 
            this.label_Tool_CurPosi.AutoSize = true;
            this.label_Tool_CurPosi.Location = new System.Drawing.Point(17, 30);
            this.label_Tool_CurPosi.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_Tool_CurPosi.Name = "label_Tool_CurPosi";
            this.label_Tool_CurPosi.Size = new System.Drawing.Size(92, 18);
            this.label_Tool_CurPosi.TabIndex = 5;
            this.label_Tool_CurPosi.Text = "刀具目前位置";
            // 
            // textBox_Tool_CurPosi
            // 
            this.textBox_Tool_CurPosi.Location = new System.Drawing.Point(111, 28);
            this.textBox_Tool_CurPosi.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_Tool_CurPosi.Name = "textBox_Tool_CurPosi";
            this.textBox_Tool_CurPosi.Size = new System.Drawing.Size(151, 25);
            this.textBox_Tool_CurPosi.TabIndex = 8;
            this.textBox_Tool_CurPosi.Text = "0";
            this.textBox_Tool_CurPosi.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btn_SetOrigin
            // 
            this.btn_SetOrigin.Location = new System.Drawing.Point(284, 23);
            this.btn_SetOrigin.Margin = new System.Windows.Forms.Padding(2);
            this.btn_SetOrigin.Name = "btn_SetOrigin";
            this.btn_SetOrigin.Size = new System.Drawing.Size(120, 32);
            this.btn_SetOrigin.TabIndex = 2;
            this.btn_SetOrigin.Text = "設為原點";
            this.btn_SetOrigin.UseVisualStyleBackColor = true;
            this.btn_SetOrigin.Click += new System.EventHandler(this.btn_SetOrigin_Click);
            // 
            // label_Img_CurPosi
            // 
            this.label_Img_CurPosi.AutoSize = true;
            this.label_Img_CurPosi.Location = new System.Drawing.Point(17, 69);
            this.label_Img_CurPosi.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_Img_CurPosi.Name = "label_Img_CurPosi";
            this.label_Img_CurPosi.Size = new System.Drawing.Size(92, 18);
            this.label_Img_CurPosi.TabIndex = 7;
            this.label_Img_CurPosi.Text = "影像目前位置";
            // 
            // btn_MovetoOrigin
            // 
            this.btn_MovetoOrigin.Location = new System.Drawing.Point(284, 62);
            this.btn_MovetoOrigin.Margin = new System.Windows.Forms.Padding(2);
            this.btn_MovetoOrigin.Name = "btn_MovetoOrigin";
            this.btn_MovetoOrigin.Size = new System.Drawing.Size(120, 32);
            this.btn_MovetoOrigin.TabIndex = 3;
            this.btn_MovetoOrigin.Text = "回到原點";
            this.btn_MovetoOrigin.UseVisualStyleBackColor = true;
            this.btn_MovetoOrigin.Click += new System.EventHandler(this.btn_MovetoOrigin_Click);
            // 
            // btn_MotorEnable
            // 
            this.btn_MotorEnable.Location = new System.Drawing.Point(159, 113);
            this.btn_MotorEnable.Margin = new System.Windows.Forms.Padding(2);
            this.btn_MotorEnable.Name = "btn_MotorEnable";
            this.btn_MotorEnable.Size = new System.Drawing.Size(120, 32);
            this.btn_MotorEnable.TabIndex = 10;
            this.btn_MotorEnable.Text = "刀具馬達Enable";
            this.btn_MotorEnable.UseVisualStyleBackColor = true;
            this.btn_MotorEnable.Click += new System.EventHandler(this.btn_MotorEnable_Click);
            // 
            // btn_MotorFree
            // 
            this.btn_MotorFree.Location = new System.Drawing.Point(17, 113);
            this.btn_MotorFree.Margin = new System.Windows.Forms.Padding(2);
            this.btn_MotorFree.Name = "btn_MotorFree";
            this.btn_MotorFree.Size = new System.Drawing.Size(120, 32);
            this.btn_MotorFree.TabIndex = 9;
            this.btn_MotorFree.Text = "刀具馬達Free";
            this.btn_MotorFree.UseVisualStyleBackColor = true;
            this.btn_MotorFree.Click += new System.EventHandler(this.btn_MotorFree_Click);
            // 
            // tabControl_fuction
            // 
            this.tabControl_fuction.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl_fuction.Controls.Add(this.Controlsystem);
            this.tabControl_fuction.Controls.Add(this.Systemsetup);
            this.tabControl_fuction.Controls.Add(this.ImageProcess);
            this.tabControl_fuction.Controls.Add(this.tabPage3);
            this.tabControl_fuction.Controls.Add(this.ML);
            this.tabControl_fuction.Font = new System.Drawing.Font("微軟正黑體", 10F);
            this.tabControl_fuction.ItemSize = new System.Drawing.Size(100, 30);
            this.tabControl_fuction.Location = new System.Drawing.Point(9, 10);
            this.tabControl_fuction.Margin = new System.Windows.Forms.Padding(2);
            this.tabControl_fuction.Multiline = true;
            this.tabControl_fuction.Name = "tabControl_fuction";
            this.tabControl_fuction.SelectedIndex = 0;
            this.tabControl_fuction.Size = new System.Drawing.Size(2038, 1272);
            this.tabControl_fuction.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControl_fuction.TabIndex = 0;
            // 
            // ML
            // 
            this.ML.Location = new System.Drawing.Point(4, 34);
            this.ML.Name = "ML";
            this.ML.Padding = new System.Windows.Forms.Padding(3);
            this.ML.Size = new System.Drawing.Size(2030, 1234);
            this.ML.TabIndex = 4;
            this.ML.Text = "ML壽命分類";
            this.ML.UseVisualStyleBackColor = true;
            // 
            // name1textBox
            // 
            this.name1textBox.Font = new System.Drawing.Font("微軟正黑體", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.name1textBox.Location = new System.Drawing.Point(115, 195);
            this.name1textBox.Margin = new System.Windows.Forms.Padding(2);
            this.name1textBox.Name = "name1textBox";
            this.name1textBox.Size = new System.Drawing.Size(49, 26);
            this.name1textBox.TabIndex = 65;
            this.name1textBox.Text = "‪TC_4";
            this.name1textBox.TextChanged += new System.EventHandler(this.name1textBox_TextChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(34, 196);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(77, 20);
            this.label9.TabIndex = 66;
            this.label9.Text = "刀具材質:";
            this.label9.Click += new System.EventHandler(this.label9_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(168, 196);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(77, 20);
            this.label10.TabIndex = 67;
            this.label10.Text = "刀具廠商:";
            // 
            // name2textBox
            // 
            this.name2textBox.Font = new System.Drawing.Font("微軟正黑體", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.name2textBox.Location = new System.Drawing.Point(249, 195);
            this.name2textBox.Margin = new System.Windows.Forms.Padding(2);
            this.name2textBox.Name = "name2textBox";
            this.name2textBox.Size = new System.Drawing.Size(81, 26);
            this.name2textBox.TabIndex = 68;
            this.name2textBox.Text = "JSK_D12";
            this.name2textBox.TextChanged += new System.EventHandler(this.textBox4_TextChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(334, 196);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(77, 20);
            this.label11.TabIndex = 69;
            this.label11.Text = "出廠日期:";
            // 
            // name3textBox
            // 
            this.name3textBox.Font = new System.Drawing.Font("微軟正黑體", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.name3textBox.Location = new System.Drawing.Point(415, 195);
            this.name3textBox.Margin = new System.Windows.Forms.Padding(2);
            this.name3textBox.Name = "name3textBox";
            this.name3textBox.Size = new System.Drawing.Size(55, 26);
            this.name3textBox.TabIndex = 70;
            this.name3textBox.Text = "190630";
            this.name3textBox.TextChanged += new System.EventHandler(this.name3textBox_TextChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(486, 196);
            this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(45, 20);
            this.label12.TabIndex = 71;
            this.label12.Text = "批次:";
            // 
            // name4textBox
            // 
            this.name4textBox.Font = new System.Drawing.Font("微軟正黑體", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.name4textBox.Location = new System.Drawing.Point(535, 195);
            this.name4textBox.Margin = new System.Windows.Forms.Padding(2);
            this.name4textBox.Name = "name4textBox";
            this.name4textBox.Size = new System.Drawing.Size(27, 26);
            this.name4textBox.TabIndex = 72;
            this.name4textBox.Text = "1";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(566, 196);
            this.label13.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(45, 20);
            this.label13.TabIndex = 73;
            this.label13.Text = "分級:";
            // 
            // name5textBox
            // 
            this.name5textBox.Font = new System.Drawing.Font("微軟正黑體", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.name5textBox.Location = new System.Drawing.Point(615, 195);
            this.name5textBox.Margin = new System.Windows.Forms.Padding(2);
            this.name5textBox.Name = "name5textBox";
            this.name5textBox.Size = new System.Drawing.Size(27, 26);
            this.name5textBox.TabIndex = 74;
            this.name5textBox.Text = "B";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(652, 195);
            this.label14.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(45, 20);
            this.label14.TabIndex = 75;
            this.label14.Text = "編號:";
            // 
            // name6textBox
            // 
            this.name6textBox.Font = new System.Drawing.Font("微軟正黑體", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.name6textBox.Location = new System.Drawing.Point(701, 195);
            this.name6textBox.Margin = new System.Windows.Forms.Padding(2);
            this.name6textBox.Name = "name6textBox";
            this.name6textBox.Size = new System.Drawing.Size(27, 26);
            this.name6textBox.TabIndex = 76;
            this.name6textBox.Text = "1";
            // 
            // Form_TIS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1904, 1041);
            this.Controls.Add(this.tabControl_fuction);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form_TIS";
            this.Text = "ATIS(Auto Tool Inspection System)-NTHU";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_TIS_FormClosing);
            this.Load += new System.EventHandler(this.Form_TIS_Load);
            this.Systemsetup.ResumeLayout(false);
            this.Systemsetup.PerformLayout();
            this.groupBox_motor_control.ResumeLayout(false);
            this.groupBox_motor_control.PerformLayout();
            this.groupBox_motor.ResumeLayout(false);
            this.groupBox_motor.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox_CH_F4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox_VB_F4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox_CH_F3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox_VB_F3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox_CH_F2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox_VB_F2)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox_CH_F1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox_VB_F1)).EndInit();
            this.ImageProcess.ResumeLayout(false);
            this.ImageProcess.PerformLayout();
            this.三維重建.ResumeLayout(false);
            this.三維重建.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgBox_RToolReconMap)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgBox_LToolReconMap)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgBox_RWearDepthMap)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgBox_LWearDepthMap)).EndInit();
            this.Controlsystem.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox_Measure.ResumeLayout(false);
            this.groupBox_Measure.PerformLayout();
            this.groupBox_Move.ResumeLayout(false);
            this.groupBox_Move.PerformLayout();
            this.groupBox_ImgSystem.ResumeLayout(false);
            this.groupBox_ImgSystem.PerformLayout();
            this.groupBox_Position.ResumeLayout(false);
            this.groupBox_Position.PerformLayout();
            this.tabControl_fuction.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.IO.Ports.SerialPort serialPort_tool;
        private System.IO.Ports.SerialPort serialPort_image;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog_imgpath;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TabPage Systemsetup;
        private System.Windows.Forms.TextBox textBox_MicroReso;
        private System.Windows.Forms.TextBox textBox_Mag;
        private System.Windows.Forms.TextBox textBox_Pixelsize;
        private System.Windows.Forms.TextBox textBox_WearDepthOutput;
        private System.Windows.Forms.Label label_MicroReso;
        private System.Windows.Forms.Label label_Mag;
        private System.Windows.Forms.Label label_Pixelsize;
        private System.Windows.Forms.Label label_WearDepthOutput;
        private System.Windows.Forms.Button btn_WearDepthOutput;
        private System.Windows.Forms.GroupBox groupBox_motor_control;
        private System.Windows.Forms.Button btn_sent_motor;
        private System.Windows.Forms.TextBox textBox_serialport2;
        private System.Windows.Forms.Label label_seiralport1_send;
        private System.Windows.Forms.TextBox textBox_serialport1;
        private System.Windows.Forms.Label label_seiralport2_send;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Label label_CH_F4;
        private System.Windows.Forms.Label label_CH_F3;
        private System.Windows.Forms.Label label_CH_F2;
        private System.Windows.Forms.Label label_VB_F4;
        private System.Windows.Forms.Label label_VB_F3;
        private System.Windows.Forms.Label label_VB_F2;
        private Emgu.CV.UI.ImageBox imageBox_CH_F4;
        private Emgu.CV.UI.ImageBox imageBox_VB_F4;
        private Emgu.CV.UI.ImageBox imageBox_CH_F3;
        private Emgu.CV.UI.ImageBox imageBox_VB_F3;
        private Emgu.CV.UI.ImageBox imageBox_CH_F2;
        private Emgu.CV.UI.ImageBox imageBox_VB_F2;
        private System.Windows.Forms.Button btn_ClearCrop;
        private System.Windows.Forms.Button btn_crop;
        private System.Windows.Forms.Button btn_PreviousFlute;
        private System.Windows.Forms.Button btn_NextFlute;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rabtn_VB1;
        private System.Windows.Forms.RadioButton rabtn_CF;
        private System.Windows.Forms.RadioButton rabtn_VB2;
        private System.Windows.Forms.RadioButton rabtn_CH3;
        private System.Windows.Forms.RadioButton rabtn_VB3;
        private System.Windows.Forms.RadioButton rabtn_CH2;
        private System.Windows.Forms.RadioButton rabtn_CH1;
        private System.Windows.Forms.Button btn_labeling;
        private System.Windows.Forms.Label label_CH_F1;
        private System.Windows.Forms.Label label_VB_F1;
        private Emgu.CV.UI.ImageBox imageBox_CH_F1;
        private Emgu.CV.UI.ImageBox imageBox_VB_F1;
        private System.Windows.Forms.TabPage ImageProcess;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label_min2;
        private System.Windows.Forms.Label label_Max;
        private System.Windows.Forms.Label label_ms;
        private System.Windows.Forms.Label label_s;
        private System.Windows.Forms.Label label_min;
        private System.Windows.Forms.GroupBox 三維重建;
        private System.Windows.Forms.CheckBox checkBox_saveImage;
        private System.Windows.Forms.Button btn_ReconStart;
        private System.Windows.Forms.Button btn_LoadVideoPath;
        private Emgu.CV.UI.ImageBox imgBox_LToolReconMap;
        private System.Windows.Forms.Label label_VideoPath;
        private System.Windows.Forms.TextBox textBox_LoadVideoPath;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btn_FilePath;
        private System.Windows.Forms.Label label_FilePath2;
        private System.Windows.Forms.TextBox textBox_FilePath;
        private System.Windows.Forms.Label label_FilePath1;
        private Emgu.CV.UI.ImageBox imgBox_LWearDepthMap;
        private System.Windows.Forms.Button btn_SaveImgPath;
        private System.Windows.Forms.Button btn_WearAnaStart;
        private System.Windows.Forms.TextBox textBox_SaveImgPath;
        private System.Windows.Forms.TabPage Controlsystem;
        private System.Windows.Forms.GroupBox groupBox_Measure;
        private System.Windows.Forms.Label label_delay;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox_folderPath;
        private System.Windows.Forms.TextBox textBox_MoveName;
        private System.Windows.Forms.Button btn_MeasureStart;
        private System.Windows.Forms.Label label_MovieName;
        private System.Windows.Forms.Button btn_FolderPath;
        private System.Windows.Forms.TextBox textBox_TotalFrame;
        private System.Windows.Forms.Label label_TotalFrame;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.GroupBox groupBox_Move;
        private System.Windows.Forms.Button btn_MoveImgDOWN;
        private System.Windows.Forms.RadioButton radioButton_rela;
        private System.Windows.Forms.RadioButton radioButton_abs;
        private System.Windows.Forms.Label label_Tool_Tar;
        private System.Windows.Forms.TextBox textBox_Tool_TarPosi;
        private System.Windows.Forms.Button btn_MoveImgUP;
        private System.Windows.Forms.TextBox textBox_Tool_TarSpeed;
        private System.Windows.Forms.Button btn_MoveTool;
        private System.Windows.Forms.TextBox textBox_Tool_TarAcc;
        private System.Windows.Forms.Label label_TarAcc;
        private System.Windows.Forms.TextBox textBox_Img_TarPosi;
        private System.Windows.Forms.Label label_TarSpeed;
        private System.Windows.Forms.TextBox textBox_Img_TarSpeed;
        private System.Windows.Forms.Label label_TarPosi;
        private System.Windows.Forms.TextBox textBox_Img_TarAcc;
        private System.Windows.Forms.Button btn_Move;
        private System.Windows.Forms.Label label_Img_Tar;
        private System.Windows.Forms.GroupBox groupBox_ImgSystem;
        private System.Windows.Forms.Label label_EXTime;
        private System.Windows.Forms.TextBox textBox_EXTime;
        private System.Windows.Forms.Label label_extimeSetting;
        private System.Windows.Forms.Label label_FPS;
        private System.Windows.Forms.Label label_vblank;
        private System.Windows.Forms.TextBox textBox_FPS;
        private System.Windows.Forms.Button btn_Preview;
        private System.Windows.Forms.Button btn_Snap;
        private System.Windows.Forms.GroupBox groupBox_Position;
        private System.Windows.Forms.TextBox textBox_Img_CurPosi;
        private System.Windows.Forms.Label label_Tool_CurPosi;
        private System.Windows.Forms.TextBox textBox_Tool_CurPosi;
        private System.Windows.Forms.Button btn_SetOrigin;
        private System.Windows.Forms.Label label_Img_CurPosi;
        private System.Windows.Forms.Button btn_MovetoOrigin;
        private System.Windows.Forms.Button btn_MotorEnable;
        private System.Windows.Forms.Button btn_MotorFree;
        private System.Windows.Forms.TabControl tabControl_fuction;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private Emgu.CV.UI.ImageBox imgBox_RToolReconMap;
        private Emgu.CV.UI.ImageBox imgBox_RWearDepthMap;
        private System.Windows.Forms.Label label_ms1;
        private System.Windows.Forms.Label label_sec1;
        private System.Windows.Forms.Label label_min1;
        private System.Windows.Forms.Label label_min3;
        private System.Windows.Forms.Label label_sec3;
        private System.Windows.Forms.Label label_ms3;
        private System.Windows.Forms.CheckBox checkBox_notsave;
        private System.Windows.Forms.Button btn_sepFrame;
        private System.Windows.Forms.Button btn_FrameFile;
        private System.Windows.Forms.TextBox textBox_FrameFile;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_seppath;
        private System.Windows.Forms.Button btn_sep_path;
        private System.Windows.Forms.Button button_videosel;
        private System.Windows.Forms.TextBox textBox_videosel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btn_ReconStart2;
        private System.Windows.Forms.Button btn_period;
        private System.Windows.Forms.TextBox textBox_autolabel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox_motor;
        private System.Windows.Forms.Label label_serialport２;
        private System.Windows.Forms.Label label_serialport1;
        private System.Windows.Forms.Button btn_Disconnect;
        private System.Windows.Forms.Button btn_Connect;
        private System.Windows.Forms.ComboBox comboBox_Port2;
        private System.Windows.Forms.ComboBox comboBox_Port1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton4;
        private System.Windows.Forms.RadioButton radioButton6;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton radioButton5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox datatextBox;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.RadioButton radioButton7;
        private System.Windows.Forms.RadioButton radioButton8;
        private System.Windows.Forms.RadioButton radioButton9;
        private System.Windows.Forms.TextBox textBox_ShiftReso;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.TabPage ML;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox name1textBox;
        private System.Windows.Forms.TextBox name2textBox;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox name5textBox;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox name4textBox;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox name3textBox;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox name6textBox;
        private System.Windows.Forms.Label label14;
    }
}

