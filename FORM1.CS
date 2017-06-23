using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
//using AxWMPLib;
//using WMPLib;

namespace 智能象棋游戏
{
	/// <summary>
	/// ***Form类主要是绘出界面,进行一些简单的初始化操作
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		public System.Windows.Forms.Panel panel1;
		public System.Windows.Forms.Panel panel2;
		public System.Windows.Forms.StatusBar statusBar1;
		public System.Windows.Forms.StatusBarPanel statusBarPanel1;
		public System.Windows.Forms.StatusBarPanel statusBarPanel2;
		public System.Windows.Forms.MainMenu mainMenu1;
		public System.Windows.Forms.MenuItem menuItem1;
		public System.Windows.Forms.MenuItem menuItem8;
		public System.Windows.Forms.MenuItem menuItem9;
		public System.Windows.Forms.MenuItem menuItem12;
		public System.Windows.Forms.Label label2;
		public System.Windows.Forms.PictureBox pictureBox3;
		public System.Windows.Forms.PictureBox pictureBox1;
		public System.Windows.Forms.PictureBox pictureBox4;
		public System.Windows.Forms.PictureBox pictureBox5;
		public System.Windows.Forms.Label label3;
		public System.Windows.Forms.Label label4;
		private System.ComponentModel.IContainer components=null;	
		public System.Windows.Forms.MenuItem menuItem2;
		public System.Windows.Forms.MenuItem menuItem3;
		public System.Windows.Forms.MenuItem menuItem4;
		public System.Windows.Forms.MenuItem menuItem5;
		public System.Windows.Forms.MenuItem menuItem6;
		public System.Windows.Forms.MenuItem menuItem7;
		public System.Windows.Forms.MenuItem menuItem13;
		public System.Windows.Forms.MenuItem menuItem14;
		public System.Windows.Forms.MenuItem menuItem16;
		public System.Windows.Forms.MenuItem menuItem18;
		public System.Windows.Forms.MenuItem menuItem19;
		public System.Windows.Forms.MenuItem menuItem15;
		public System.Windows.Forms.MenuItem menuItem20;
		public System.Windows.Forms.Label label5;
		private System.Windows.Forms.MenuItem menuItem21;
		public System.Windows.Forms.MenuItem menuItem22;
		public System.Windows.Forms.MenuItem menuItem23;
		public System.Windows.Forms.MenuItem menuItem24;
		public System.Windows.Forms.MenuItem menuItem25;
		public System.Windows.Forms.MenuItem menuItem26;
		public System.Windows.Forms.MenuItem menuItem27;
		public System.Windows.Forms.MenuItem menuItem28;
		public System.Windows.Forms.MenuItem menuItem29;
		public System.Windows.Forms.MenuItem menuItem30;
		public System.Windows.Forms.MenuItem menuItem31;
		public System.Windows.Forms.MenuItem menuItem32;
		public System.Windows.Forms.MenuItem menuItem33;
		public System.Windows.Forms.MenuItem menuItem34;
		public System.Windows.Forms.MenuItem menuItem35;
		private System.Windows.Forms.MenuItem menuItem36;
		public System.Windows.Forms.MenuItem menuItem37;
		public System.Windows.Forms.MenuItem menuItem38;
		public System.Windows.Forms.MenuItem menuItem39;
		public System.Windows.Forms.MenuItem menuItem40;
		public System.Windows.Forms.MenuItem menuItem41;
		public System.Windows.Forms.MenuItem menuItem42;
		public System.Windows.Forms.MenuItem menuItem43;
		public System.Windows.Forms.MenuItem menuItem44;
		public System.Windows.Forms.MenuItem menuItem45;
		public System.Windows.Forms.MenuItem menuItem46;
		public System.Windows.Forms.MenuItem menuItem47;
		public System.Windows.Forms.PictureBox pictureBox2;
		public System.Windows.Forms.MenuItem menuItem17;			
		private System.Windows.Forms.MenuItem menuItem48;
		private System.Windows.Forms.MenuItem menuItem49;
		private System.Windows.Forms.MenuItem menuItem50;
		private System.Windows.Forms.MenuItem menuItem51;
		private System.Windows.Forms.MenuItem menuItem52;
		private System.Windows.Forms.MenuItem menuItem53;
		private System.Windows.Forms.MenuItem menuItem54;
		private System.Windows.Forms.MenuItem menuItem55;
		private System.Windows.Forms.MenuItem menuItem56;
		public System.Windows.Forms.StatusBarPanel statusBarPanel3;
		public System.Windows.Forms.StatusBarPanel statusBarPanel4;
		public System.Windows.Forms.MenuItem menuItem57;
		private System.Windows.Forms.MenuItem menuItem58;
		private System.Windows.Forms.MenuItem menuItem59;
		private System.Windows.Forms.MenuItem menuItem60;
		private System.Windows.Forms.MenuItem menuItem61;
		private System.Windows.Forms.MenuItem menuItem62;
		private System.Windows.Forms.MenuItem menuItem63;
		private System.Windows.Forms.MenuItem menuItem64;
		private System.Windows.Forms.MenuItem menuItem65;
		private System.Windows.Forms.MenuItem menuItem66;
		private System.Windows.Forms.MenuItem menuItem68;
		public System.Windows.Forms.Label label6;
		public System.Windows.Forms.PictureBox pictureBox6;
		public System.Windows.Forms.Label label1;
		private System.Windows.Forms.MenuItem menuItem10;
		public System.Windows.Forms.Label label7;
		public System.Windows.Forms.Label label8;
	 
		public string[] playName=new string[5];
		//自定义全局变量
		public  Point []point=new Point[90];
		public int width,height;
		public int blueZhanJi=0;  //战绩
		public int redZhanJi=0;
		
		static public Form3 login;
		public System.Windows.Forms.MenuItem menuItem11;
		public System.Windows.Forms.MenuItem menuItem67;
		private System.Windows.Forms.MenuItem menuItem69;
		public bool computerAuto=false;
		private System.Windows.Forms.NotifyIcon notifyIcon1;
		public System.Windows.Forms.NotifyIcon notifyIcon2;
		private System.Windows.Forms.ContextMenu contextMenu1;
		private System.Windows.Forms.MenuItem menuItem70;
		private System.Windows.Forms.MenuItem menuItem71;
        private System.Windows.Forms.MenuItem menuItem72;
        protected Label lbRollback;
        private MenuItem menuItem73;
        protected MenuItem menuItem74;		

		public int displaySize=-1;

		public Form1()
		{
			//
			// Windows 窗体设计器支持所必需的
			//			
			if(this.displaySize==-1)
				AdjustDisplay();
			InitializeComponent(); 			
			MyInitializeComponent();
			//
			// TODO: 在 InitializeComponent 调用后添加任何构造函数代码
			//				
		}

		/// <summary>
		/// 清理所有正在使用的资源。
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows 窗体设计器生成的代码
		/// <summary>
		/// 设计器支持所需的方法 - 不要使用代码编辑器修改
		/// 此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lbRollback = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.statusBar1 = new System.Windows.Forms.StatusBar();
            this.statusBarPanel1 = new System.Windows.Forms.StatusBarPanel();
            this.statusBarPanel2 = new System.Windows.Forms.StatusBarPanel();
            this.statusBarPanel3 = new System.Windows.Forms.StatusBarPanel();
            this.statusBarPanel4 = new System.Windows.Forms.StatusBarPanel();
            this.mainMenu1 = new System.Windows.Forms.MainMenu(this.components);
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.menuItem8 = new System.Windows.Forms.MenuItem();
            this.menuItem9 = new System.Windows.Forms.MenuItem();
            this.menuItem10 = new System.Windows.Forms.MenuItem();
            this.menuItem11 = new System.Windows.Forms.MenuItem();
            this.menuItem67 = new System.Windows.Forms.MenuItem();
            this.menuItem69 = new System.Windows.Forms.MenuItem();
            this.menuItem12 = new System.Windows.Forms.MenuItem();
            this.menuItem2 = new System.Windows.Forms.MenuItem();
            this.menuItem3 = new System.Windows.Forms.MenuItem();
            this.menuItem68 = new System.Windows.Forms.MenuItem();
            this.menuItem4 = new System.Windows.Forms.MenuItem();
            this.menuItem5 = new System.Windows.Forms.MenuItem();
            this.menuItem6 = new System.Windows.Forms.MenuItem();
            this.menuItem7 = new System.Windows.Forms.MenuItem();
            this.menuItem13 = new System.Windows.Forms.MenuItem();
            this.menuItem14 = new System.Windows.Forms.MenuItem();
            this.menuItem16 = new System.Windows.Forms.MenuItem();
            this.menuItem17 = new System.Windows.Forms.MenuItem();
            this.menuItem18 = new System.Windows.Forms.MenuItem();
            this.menuItem19 = new System.Windows.Forms.MenuItem();
            this.menuItem20 = new System.Windows.Forms.MenuItem();
            this.menuItem48 = new System.Windows.Forms.MenuItem();
            this.menuItem21 = new System.Windows.Forms.MenuItem();
            this.menuItem22 = new System.Windows.Forms.MenuItem();
            this.menuItem23 = new System.Windows.Forms.MenuItem();
            this.menuItem24 = new System.Windows.Forms.MenuItem();
            this.menuItem25 = new System.Windows.Forms.MenuItem();
            this.menuItem26 = new System.Windows.Forms.MenuItem();
            this.menuItem27 = new System.Windows.Forms.MenuItem();
            this.menuItem28 = new System.Windows.Forms.MenuItem();
            this.menuItem29 = new System.Windows.Forms.MenuItem();
            this.menuItem30 = new System.Windows.Forms.MenuItem();
            this.menuItem31 = new System.Windows.Forms.MenuItem();
            this.menuItem32 = new System.Windows.Forms.MenuItem();
            this.menuItem33 = new System.Windows.Forms.MenuItem();
            this.menuItem34 = new System.Windows.Forms.MenuItem();
            this.menuItem35 = new System.Windows.Forms.MenuItem();
            this.menuItem36 = new System.Windows.Forms.MenuItem();
            this.menuItem38 = new System.Windows.Forms.MenuItem();
            this.menuItem41 = new System.Windows.Forms.MenuItem();
            this.menuItem46 = new System.Windows.Forms.MenuItem();
            this.menuItem39 = new System.Windows.Forms.MenuItem();
            this.menuItem40 = new System.Windows.Forms.MenuItem();
            this.menuItem42 = new System.Windows.Forms.MenuItem();
            this.menuItem43 = new System.Windows.Forms.MenuItem();
            this.menuItem44 = new System.Windows.Forms.MenuItem();
            this.menuItem45 = new System.Windows.Forms.MenuItem();
            this.menuItem37 = new System.Windows.Forms.MenuItem();
            this.menuItem47 = new System.Windows.Forms.MenuItem();
            this.menuItem49 = new System.Windows.Forms.MenuItem();
            this.menuItem50 = new System.Windows.Forms.MenuItem();
            this.menuItem57 = new System.Windows.Forms.MenuItem();
            this.menuItem73 = new System.Windows.Forms.MenuItem();
            this.menuItem74 = new System.Windows.Forms.MenuItem();
            this.menuItem58 = new System.Windows.Forms.MenuItem();
            this.menuItem59 = new System.Windows.Forms.MenuItem();
            this.menuItem60 = new System.Windows.Forms.MenuItem();
            this.menuItem61 = new System.Windows.Forms.MenuItem();
            this.menuItem62 = new System.Windows.Forms.MenuItem();
            this.menuItem63 = new System.Windows.Forms.MenuItem();
            this.menuItem64 = new System.Windows.Forms.MenuItem();
            this.menuItem65 = new System.Windows.Forms.MenuItem();
            this.menuItem66 = new System.Windows.Forms.MenuItem();
            this.menuItem51 = new System.Windows.Forms.MenuItem();
            this.menuItem52 = new System.Windows.Forms.MenuItem();
            this.menuItem53 = new System.Windows.Forms.MenuItem();
            this.menuItem54 = new System.Windows.Forms.MenuItem();
            this.menuItem55 = new System.Windows.Forms.MenuItem();
            this.menuItem56 = new System.Windows.Forms.MenuItem();
            this.menuItem15 = new System.Windows.Forms.MenuItem();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenu1 = new System.Windows.Forms.ContextMenu();
            this.menuItem70 = new System.Windows.Forms.MenuItem();
            this.menuItem71 = new System.Windows.Forms.MenuItem();
            this.menuItem72 = new System.Windows.Forms.MenuItem();
            this.notifyIcon2 = new System.Windows.Forms.NotifyIcon(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel4)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(150)))), ((int)(((byte)(223)))));
            this.panel1.Controls.Add(this.pictureBox6);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(392, 480);
            this.panel1.TabIndex = 3;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            this.panel1.Resize += new System.EventHandler(this.panel1_Resize);
            // 
            // pictureBox6
            // 
            this.pictureBox6.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox6.Image")));
            this.pictureBox6.Location = new System.Drawing.Point(312, 408);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(64, 64);
            this.pictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox6.TabIndex = 0;
            this.pictureBox6.TabStop = false;
            this.pictureBox6.Visible = false;
            // 
            // panel2
            // 
            this.panel2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.panel2.Controls.Add(this.lbRollback);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.pictureBox2);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.pictureBox5);
            this.panel2.Controls.Add(this.pictureBox4);
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Controls.Add(this.pictureBox3);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new System.Drawing.Point(392, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(176, 480);
            this.panel2.TabIndex = 6;
            // 
            // lbRollback
            // 
            this.lbRollback.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbRollback.Enabled = false;
            this.lbRollback.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lbRollback.Font = new System.Drawing.Font("楷体_GB2312", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbRollback.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.lbRollback.Location = new System.Drawing.Point(96, 319);
            this.lbRollback.Name = "lbRollback";
            this.lbRollback.Size = new System.Drawing.Size(72, 23);
            this.lbRollback.TabIndex = 16;
            this.lbRollback.Text = "<回放>";
            this.lbRollback.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label8.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label8.Font = new System.Drawing.Font("楷体_GB2312", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.label8.Location = new System.Drawing.Point(88, 368);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(72, 23);
            this.label8.TabIndex = 15;
            this.label8.Text = "<前进>";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label7.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label7.Font = new System.Drawing.Font("楷体_GB2312", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.label7.Location = new System.Drawing.Point(8, 368);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(72, 23);
            this.label7.TabIndex = 14;
            this.label7.Text = "<后退>";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label1.Font = new System.Drawing.Font("楷体_GB2312", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.Gold;
            this.label1.Location = new System.Drawing.Point(8, 144);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(152, 40);
            this.label1.TabIndex = 13;
            this.label1.Text = "player1 VS player2";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label1.DoubleClick += new System.EventHandler(this.label1_DoubleClick);
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("楷体_GB2312", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.ForeColor = System.Drawing.Color.Maroon;
            this.label6.Location = new System.Drawing.Point(56, 280);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(104, 40);
            this.label6.TabIndex = 12;
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(0, 280);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(56, 48);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox2.TabIndex = 11;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Visible = false;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("楷体_GB2312", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(8, 96);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(152, 40);
            this.label5.TabIndex = 10;
            this.label5.Text = "战役:请选择战役";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label4.Location = new System.Drawing.Point(8, 335);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 23);
            this.label4.TabIndex = 9;
            this.label4.Text = "功能操作:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("楷体_GB2312", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.label3.Location = new System.Drawing.Point(8, 232);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(152, 48);
            this.label3.TabIndex = 6;
            this.label3.Text = "请选择游戏类型";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox5
            // 
            this.pictureBox5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox5.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox5.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox5.Image")));
            this.pictureBox5.Location = new System.Drawing.Point(16, 8);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(72, 80);
            this.pictureBox5.TabIndex = 5;
            this.pictureBox5.TabStop = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox4.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox4.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox4.Image")));
            this.pictureBox4.Location = new System.Drawing.Point(96, 8);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(72, 80);
            this.pictureBox4.TabIndex = 4;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(80, 396);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(80, 83);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.pictureBox3.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(8, 396);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(72, 88);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox3.TabIndex = 2;
            this.pictureBox3.TabStop = false;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("楷体_GB2312", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(8, 200);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(152, 40);
            this.label2.TabIndex = 1;
            this.label2.Text = "已用时间:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // statusBar1
            // 
            this.statusBar1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.statusBar1.Dock = System.Windows.Forms.DockStyle.None;
            this.statusBar1.Location = new System.Drawing.Point(0, 480);
            this.statusBar1.Name = "statusBar1";
            this.statusBar1.Panels.AddRange(new System.Windows.Forms.StatusBarPanel[] {
            this.statusBarPanel1,
            this.statusBarPanel2,
            this.statusBarPanel3,
            this.statusBarPanel4});
            this.statusBar1.ShowPanels = true;
            this.statusBar1.Size = new System.Drawing.Size(568, 24);
            this.statusBar1.TabIndex = 2;
            this.statusBar1.Text = "中国象旗";
            this.statusBar1.PanelClick += new System.Windows.Forms.StatusBarPanelClickEventHandler(this.statusBar1_PanelClick);
            // 
            // statusBarPanel1
            // 
            this.statusBarPanel1.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.statusBarPanel1.Name = "statusBarPanel1";
            this.statusBarPanel1.Text = "战绩:";
            this.statusBarPanel1.Width = 50;
            // 
            // statusBarPanel2
            // 
            this.statusBarPanel2.Name = "statusBarPanel2";
            this.statusBarPanel2.Text = "红方: 0";
            this.statusBarPanel2.Width = 50;
            // 
            // statusBarPanel3
            // 
            this.statusBarPanel3.Name = "statusBarPanel3";
            this.statusBarPanel3.Text = "蓝方: 0";
            this.statusBarPanel3.Width = 50;
            // 
            // statusBarPanel4
            // 
            this.statusBarPanel4.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
            this.statusBarPanel4.Name = "statusBarPanel4";
            this.statusBarPanel4.Text = "当前时间:";
            this.statusBarPanel4.Width = 550;
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem1,
            this.menuItem2,
            this.menuItem58,
            this.menuItem51,
            this.menuItem15});
            // 
            // menuItem1
            // 
            this.menuItem1.Index = 0;
            this.menuItem1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem8,
            this.menuItem9,
            this.menuItem10,
            this.menuItem11,
            this.menuItem67,
            this.menuItem69,
            this.menuItem12});
            this.menuItem1.Text = "文件(&F)";
            // 
            // menuItem8
            // 
            this.menuItem8.Index = 0;
            this.menuItem8.Text = "设置断点...";
            // 
            // menuItem9
            // 
            this.menuItem9.Index = 1;
            this.menuItem9.Text = "读取断点...";
            // 
            // menuItem10
            // 
            this.menuItem10.Index = 2;
            this.menuItem10.Text = "-";
            // 
            // menuItem11
            // 
            this.menuItem11.Index = 3;
            this.menuItem11.Text = "切换到双人游戏";
            this.menuItem11.Click += new System.EventHandler(this.menuItem11_Click);
            // 
            // menuItem67
            // 
            this.menuItem67.Index = 4;
            this.menuItem67.Text = "切换到单人游戏";
            this.menuItem67.Click += new System.EventHandler(this.menuItem67_Click);
            // 
            // menuItem69
            // 
            this.menuItem69.Index = 5;
            this.menuItem69.Text = "-";
            // 
            // menuItem12
            // 
            this.menuItem12.Index = 6;
            this.menuItem12.Text = "退出";
            this.menuItem12.Click += new System.EventHandler(this.menuItem12_Click);
            // 
            // menuItem2
            // 
            this.menuItem2.Index = 1;
            this.menuItem2.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem3,
            this.menuItem68,
            this.menuItem4,
            this.menuItem5,
            this.menuItem6,
            this.menuItem48,
            this.menuItem21,
            this.menuItem36,
            this.menuItem49,
            this.menuItem50,
            this.menuItem57,
            this.menuItem73,
            this.menuItem74});
            this.menuItem2.Text = "操作(&O)";
            // 
            // menuItem3
            // 
            this.menuItem3.Index = 0;
            this.menuItem3.Text = "新开一局";
            // 
            // menuItem68
            // 
            this.menuItem68.Index = 1;
            this.menuItem68.Text = "-";
            // 
            // menuItem4
            // 
            this.menuItem4.Checked = true;
            this.menuItem4.Index = 2;
            this.menuItem4.Text = "重新开始";
            // 
            // menuItem5
            // 
            this.menuItem5.Index = 3;
            this.menuItem5.Text = "-";
            // 
            // menuItem6
            // 
            this.menuItem6.Index = 4;
            this.menuItem6.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem7,
            this.menuItem13,
            this.menuItem14,
            this.menuItem16,
            this.menuItem17,
            this.menuItem18,
            this.menuItem19,
            this.menuItem20});
            this.menuItem6.Text = "选择残局";
            // 
            // menuItem7
            // 
            this.menuItem7.Index = 0;
            this.menuItem7.Text = "車VS马之战";
            // 
            // menuItem13
            // 
            this.menuItem13.Index = 1;
            this.menuItem13.Text = "車VS炮之战";
            // 
            // menuItem14
            // 
            this.menuItem14.Index = 2;
            this.menuItem14.Text = "兵VS兵之战";
            // 
            // menuItem16
            // 
            this.menuItem16.Index = 3;
            this.menuItem16.Text = "马VS炮之战";
            // 
            // menuItem17
            // 
            this.menuItem17.Index = 4;
            this.menuItem17.Text = "炮马車之战";
            // 
            // menuItem18
            // 
            this.menuItem18.Index = 5;
            this.menuItem18.Text = "炮VS兵之战";
            // 
            // menuItem19
            // 
            this.menuItem19.Index = 6;
            this.menuItem19.Text = "将军之战";
            // 
            // menuItem20
            // 
            this.menuItem20.Index = 7;
            this.menuItem20.Text = "无士之战";
            // 
            // menuItem48
            // 
            this.menuItem48.Index = 5;
            this.menuItem48.Text = "-";
            // 
            // menuItem21
            // 
            this.menuItem21.Index = 6;
            this.menuItem21.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem22,
            this.menuItem23,
            this.menuItem24,
            this.menuItem25,
            this.menuItem26,
            this.menuItem27,
            this.menuItem28,
            this.menuItem29,
            this.menuItem30,
            this.menuItem31,
            this.menuItem32,
            this.menuItem33,
            this.menuItem34,
            this.menuItem35});
            this.menuItem21.Text = "一般高手VS菜鸟";
            // 
            // menuItem22
            // 
            this.menuItem22.Index = 0;
            this.menuItem22.Text = "高手让一車";
            // 
            // menuItem23
            // 
            this.menuItem23.Index = 1;
            this.menuItem23.Text = "高手让两車";
            // 
            // menuItem24
            // 
            this.menuItem24.Index = 2;
            this.menuItem24.Text = "-";
            // 
            // menuItem25
            // 
            this.menuItem25.Index = 3;
            this.menuItem25.Text = "高手让一马";
            // 
            // menuItem26
            // 
            this.menuItem26.Index = 4;
            this.menuItem26.Text = "高手让两马";
            // 
            // menuItem27
            // 
            this.menuItem27.Index = 5;
            this.menuItem27.Text = "-";
            // 
            // menuItem28
            // 
            this.menuItem28.Index = 6;
            this.menuItem28.Text = "高手让一炮";
            // 
            // menuItem29
            // 
            this.menuItem29.Index = 7;
            this.menuItem29.Text = "高手让两炮";
            // 
            // menuItem30
            // 
            this.menuItem30.Index = 8;
            this.menuItem30.Text = "-";
            // 
            // menuItem31
            // 
            this.menuItem31.Index = 9;
            this.menuItem31.Text = "高手让一象";
            // 
            // menuItem32
            // 
            this.menuItem32.Index = 10;
            this.menuItem32.Text = "高手让一士";
            // 
            // menuItem33
            // 
            this.menuItem33.Index = 11;
            this.menuItem33.Text = "-";
            // 
            // menuItem34
            // 
            this.menuItem34.Index = 12;
            this.menuItem34.Text = "高手让三卒";
            // 
            // menuItem35
            // 
            this.menuItem35.Index = 13;
            this.menuItem35.Text = "高手让五卒";
            // 
            // menuItem36
            // 
            this.menuItem36.Index = 7;
            this.menuItem36.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem38,
            this.menuItem41,
            this.menuItem46,
            this.menuItem39,
            this.menuItem40,
            this.menuItem42,
            this.menuItem43,
            this.menuItem44,
            this.menuItem45,
            this.menuItem37,
            this.menuItem47});
            this.menuItem36.Text = "顶尖高手VS菜鸟";
            // 
            // menuItem38
            // 
            this.menuItem38.Index = 0;
            this.menuItem38.Text = "高手让車車炮";
            // 
            // menuItem41
            // 
            this.menuItem41.Index = 1;
            this.menuItem41.Text = "高手让車車马";
            // 
            // menuItem46
            // 
            this.menuItem46.Index = 2;
            this.menuItem46.Text = "-";
            // 
            // menuItem39
            // 
            this.menuItem39.Index = 3;
            this.menuItem39.Text = "高手让马马炮";
            // 
            // menuItem40
            // 
            this.menuItem40.Index = 4;
            this.menuItem40.Text = "高手让马马車";
            // 
            // menuItem42
            // 
            this.menuItem42.Index = 5;
            this.menuItem42.Text = "-";
            // 
            // menuItem43
            // 
            this.menuItem43.Index = 6;
            this.menuItem43.Text = "高手让炮炮马";
            // 
            // menuItem44
            // 
            this.menuItem44.Index = 7;
            this.menuItem44.Text = "高手让炮炮車";
            // 
            // menuItem45
            // 
            this.menuItem45.Index = 8;
            this.menuItem45.Text = "-";
            // 
            // menuItem37
            // 
            this.menuItem37.Index = 9;
            this.menuItem37.Text = "高手让車马炮";
            // 
            // menuItem47
            // 
            this.menuItem47.Index = 10;
            this.menuItem47.Text = "高手半对全军";
            // 
            // menuItem49
            // 
            this.menuItem49.Index = 8;
            this.menuItem49.Text = "-";
            // 
            // menuItem50
            // 
            this.menuItem50.Index = 9;
            this.menuItem50.Text = "转换玩者称呼";
            this.menuItem50.Click += new System.EventHandler(this.label1_DoubleClick);
            // 
            // menuItem57
            // 
            this.menuItem57.Index = 10;
            this.menuItem57.Text = "暂停";
            // 
            // menuItem73
            // 
            this.menuItem73.Index = 11;
            this.menuItem73.Text = "-";
            // 
            // menuItem74
            // 
            this.menuItem74.Enabled = false;
            this.menuItem74.Index = 12;
            this.menuItem74.Text = "回放";
            // 
            // menuItem58
            // 
            this.menuItem58.Index = 2;
            this.menuItem58.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem59,
            this.menuItem60,
            this.menuItem61,
            this.menuItem62,
            this.menuItem63,
            this.menuItem64,
            this.menuItem65,
            this.menuItem66});
            this.menuItem58.Text = "控制(&C)";
            // 
            // menuItem59
            // 
            this.menuItem59.Index = 0;
            this.menuItem59.Text = "鼠标操作:";
            // 
            // menuItem60
            // 
            this.menuItem60.Index = 1;
            this.menuItem60.Text = "拿放旗子-----点击左键";
            // 
            // menuItem61
            // 
            this.menuItem61.Index = 2;
            this.menuItem61.Text = "移动旗子-----左键拖动";
            // 
            // menuItem62
            // 
            this.menuItem62.Index = 3;
            this.menuItem62.Text = "-";
            // 
            // menuItem63
            // 
            this.menuItem63.Index = 4;
            this.menuItem63.Text = "键盘操作:";
            // 
            // menuItem64
            // 
            this.menuItem64.Index = 5;
            this.menuItem64.Text = "拿放旗子-----Ctrl/空格/ENTER(回车)";
            // 
            // menuItem65
            // 
            this.menuItem65.Index = 6;
            this.menuItem65.Text = "移动旗子-----UP/DOWN/LEFT/RIGHT ";
            // 
            // menuItem66
            // 
            this.menuItem66.Index = 7;
            this.menuItem66.Text = "移动旗子-----W(上)/S(下)/A(左)/D(右)";
            // 
            // menuItem51
            // 
            this.menuItem51.Index = 3;
            this.menuItem51.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem52,
            this.menuItem53,
            this.menuItem54,
            this.menuItem55,
            this.menuItem56});
            this.menuItem51.Text = "音乐(M)";
            // 
            // menuItem52
            // 
            this.menuItem52.Index = 0;
            this.menuItem52.Text = "music1";
            // 
            // menuItem53
            // 
            this.menuItem53.Index = 1;
            this.menuItem53.Text = "music2";
            // 
            // menuItem54
            // 
            this.menuItem54.Index = 2;
            this.menuItem54.Text = "music3";
            // 
            // menuItem55
            // 
            this.menuItem55.Index = 3;
            this.menuItem55.Text = "-";
            // 
            // menuItem56
            // 
            this.menuItem56.Index = 4;
            this.menuItem56.Text = "关闭音效";
            // 
            // menuItem15
            // 
            this.menuItem15.Index = 4;
            this.menuItem15.Text = "版本(V)";
            this.menuItem15.Click += new System.EventHandler(this.menuItem15_Click);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenu = this.contextMenu1;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "谢谢您的光临*_*";
            this.notifyIcon1.Visible = true;
            // 
            // contextMenu1
            // 
            this.contextMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem70,
            this.menuItem71,
            this.menuItem72});
            // 
            // menuItem70
            // 
            this.menuItem70.Index = 0;
            this.menuItem70.Text = "最大化";
            this.menuItem70.Click += new System.EventHandler(this.menuItem70_Click);
            // 
            // menuItem71
            // 
            this.menuItem71.Index = 1;
            this.menuItem71.Text = "最小化";
            this.menuItem71.Click += new System.EventHandler(this.menuItem71_Click);
            // 
            // menuItem72
            // 
            this.menuItem72.Index = 2;
            this.menuItem72.Text = "退出";
            this.menuItem72.Click += new System.EventHandler(this.menuItem72_Click);
            // 
            // notifyIcon2
            // 
            this.notifyIcon2.ContextMenu = this.contextMenu1;
            this.notifyIcon2.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon2.Icon")));
            this.notifyIcon2.Text = "双马飞腾";
            this.notifyIcon2.Visible = true;
            // 
            // Form1
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(568, 513);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.statusBar1);
            this.DoubleBuffered = true;
            this.Menu = this.mainMenu1;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "智能象棋游戏";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel4)).EndInit();
            this.ResumeLayout(false);

		}     

		#endregion

		/// <summary>
		/// 应用程序的主入口点。
		/// </summary>	
		/// 

		public void AdjustDisplay()
		{			
            //if(MessageBox.Show("您的显示器是17寸的吗？如果是单击(Y),否则单击(N)","请正确选择，否则旗局会有一点点偏移",MessageBoxButtons.YesNo,MessageBoxIcon.Asterisk)==DialogResult.Yes)
            //{
            //    displaySize=17;		
            //}
            //else
            //{
            //    displaySize=15;
            //}			
            displaySize = 17;
		}
		public void DrawAllSitePoint(object sender,System.Windows.Forms.PaintEventArgs e,int paoX,int paoY,int width)
		{
			Graphics g=e.Graphics;
			width/=4;			
			int distance=5;
			Pen pen=new Pen(Color.Chocolate,2);
			g.DrawLine(pen,paoX-width,paoY-distance,paoX-distance,paoY-distance);
			g.DrawLine(pen,paoX-distance,paoY-distance,paoX-distance,paoY-width);
			g.DrawLine(pen,paoX+distance,paoY-width,paoX+distance,paoY-distance);
			g.DrawLine(pen,paoX+distance,paoY-distance,paoX+width,paoY-distance);
			g.DrawLine(pen,paoX-width,paoY+distance,paoX-distance,paoY+distance);
			g.DrawLine(pen,paoX-distance,paoY+distance,paoX-distance,paoY+width);
			g.DrawLine(pen,paoX+distance,paoY+width,paoX+distance,paoY+distance);
			g.DrawLine(pen,paoX+distance,paoY+distance,paoX+width,paoY+distance);
			pen.Dispose();
		}
		public void DrawLeftHalfSitePoint(object sender,System.Windows.Forms.PaintEventArgs e,int paoX,int paoY,int width)
		{
			Graphics g=e.Graphics;
			width/=4;			
			int distance=5;
			Pen pen=new Pen(Color.Chocolate,2);			
			g.DrawLine(pen,paoX+distance,paoY-width,paoX+distance,paoY-distance);
			g.DrawLine(pen,paoX+distance,paoY-distance,paoX+width,paoY-distance);			
			g.DrawLine(pen,paoX+distance,paoY+width,paoX+distance,paoY+distance);
			g.DrawLine(pen,paoX+distance,paoY+distance,paoX+width,paoY+distance);
			pen.Dispose();
		}
		public void DrawRightHalfSitePoint(object sender,System.Windows.Forms.PaintEventArgs e,int paoX,int paoY,int width)
		{
			Graphics g=e.Graphics;
			width/=4;			
			int distance=5;
			Pen pen=new Pen(Color.Chocolate,2);
			g.DrawLine(pen,paoX-width,paoY-distance,paoX-distance,paoY-distance);
			g.DrawLine(pen,paoX-distance,paoY-distance,paoX-distance,paoY-width);			
			g.DrawLine(pen,paoX-width,paoY+distance,paoX-distance,paoY+distance);
			g.DrawLine(pen,paoX-distance,paoY+distance,paoX-distance,paoY+width);			
			pen.Dispose();
		}
		
		public void MyInitializeComponent()
		{	//函数功能：得到一组点，以便用这些点来确定pictureBoxs组的位置		
			int startLeft,startTop;
			if(this.displaySize==15)
			{
				startLeft=48;startTop=30;//左上角点	800*600
			}
			else
			{
				startLeft=60;startTop=35;//左上角点     1024*768
			}
			int Index=0; //记录点的索引			
			width=panel1.Width;
			height=panel1.Height;
			width=width/9;  height=height/10;  //确定每个方格的宽和高
			width-=4; height-=3;			
			int startX=startLeft,startY=startTop;
			for(int i=0;i<2;i++)
			{
				for(int j=0;j<4;j++)
				{
					for(int k=0;k<8;k++)
					{						
						point[Index]=new Point(startX,startY);
						Index++;
						startX+=width;
					}				
					point[Index]=new Point(point[Index-1].X+width,point[Index-1].Y);
					Index++;
					
					startY+=height;  //往下移动动坐标,以记录下一行坐标
					startX=startLeft;
				}				
				//记录上面忘下的九个点
				for(int ii=Index-9,j=0;j<9;ii++,j++)
				{					
					point[Index]=new Point(point[ii].X,point[ii].Y+height);
					Index++;
				}					
				startX=startLeft;
				startY=startTop+5*height+height/2;	//移动坐标记下方旗盘坐标		    
			}				            
		}		
		
		public void panel1_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
		{//方法功能：画旗盘
			Graphics g=e.Graphics;
			int startLeft,startTop;
			if(this.displaySize==15)
			{
				startLeft=48;startTop=32;//左上角点	 800*600
			}
			else
			{
				startLeft=60;startTop=35;//左上角点 1024*768
			}
			int Index=0; //记录点的索引			
			width=panel1.Width;
			height=panel1.Height;
			width=width/9;  height=height/10;  //确定每个方格的宽和高
			width-=4; height-=3;			
			Pen pen1=new Pen(Color.DarkBlue,3);	
			Pen pen2=new Pen(Color.Black,2);
			int startX=startLeft,startY=startTop;
			for(int i=0;i<2;i++)
			{
				for(int j=0;j<4;j++)
				{
					for(int k=0;k<8;k++)
					{//以下括号内所有语句为画一行方格						
						g.DrawRectangle(pen1,startX,startY,width,height);						
						point[Index]=new Point(startX,startY);
						Index++;
						startX+=width;
					}					
					point[Index]=new Point(point[Index-1].X+width,point[Index-1].Y);
					Index++;
					
					startY+=height;  //往下移动动坐标,画下一行方格
					startX=startLeft;
				}				
				//记录上面忘下的九个点
				for(int ii=Index-9,j=0;j<9;ii++,j++)
				{					
					point[Index]=new Point(point[ii].X,point[ii].Y+height);
					Index++;
				}
				int paoX,paoY;  //声明画炮点的漂亮图案坐标
				int x,y,temp;   //画将/帅的辅助变量
				if(i==0)
				{
					paoX=startLeft+width;
					paoY=startTop+2*height;							
					x=startLeft+3*width;
					y=startTop+2*height;
					temp=0;					
				}
				else
				{
					paoX=startLeft+width;
					paoY=startTop+7*height+height/2;					
					x=startLeft+3*width;
					y=startLeft+9*height+2;
					temp=7*height+height/2+2;
				}				
				
				//画横向的两个炮的漂亮图案
				DrawAllSitePoint(sender,e,paoX,paoY,width);		
				paoX=startLeft+7*width;
				DrawAllSitePoint(sender,e,paoX,paoY,width);	
                
				//画将/帅家					
				float[] dashValues={3,1,3,1,3,1};
				pen2.DashPattern=dashValues;
				g.DrawLine(pen2,x,startTop+temp,x+2*width,y);
				x=startLeft+5*width;
				g.DrawLine(pen2,x,startTop+temp,x-2*width,y);

				//画中间的河				
				Font font=new Font("华文行楷", 42F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));                				
				Brush brush=new SolidBrush(Color.Purple);
				PointF tempPoint=new PointF(startLeft,startTop+4*height+10);
				string tempStr;
				if(this.displaySize==15)
				{
					tempStr="  楚   河       汉   界     "; /************适于800*600 分辩率**************/
				}
				else
				{
					tempStr="      楚    河           汉    界     ";   /************适于1024*768分辩率**************/
					tempPoint.Y=tempPoint.Y+8;
				}
				g.DrawString(tempStr,font,brush,tempPoint);

				startX=startLeft;
				startY=startTop+5*height+height/2;	//移动坐标,画下方旗盘		    
			}			
			for(int i=29;i<=33;i+=2)
				DrawAllSitePoint(sender,e,this.point[i].X,this.point[i].Y,width);
			for(int i=56;i<=60;i+=2)
				DrawAllSitePoint(sender,e,this.point[i].X,this.point[i].Y,width);
			this.DrawLeftHalfSitePoint(sender,e,this.point[27].X,this.point[27].Y,width);
			this.DrawRightHalfSitePoint(sender,e,this.point[35].X,this.point[35].Y,width);
			this.DrawLeftHalfSitePoint(sender,e,this.point[54].X,this.point[54].Y,width);
			this.DrawRightHalfSitePoint(sender,e,this.point[62].X,this.point[62].Y,width);

			pen1.Dispose();
			g.Dispose();	
			MyInitializeComponent();
			
		}

		private void Form1_Load(object sender, System.EventArgs e)
		{
            this.panel1.Cursor = new Cursor(@"..\..\cursor\greenflag.cur");
            this.label7.Cursor = new Cursor(@"..\..\cursor\greenflag.cur");
            this.label8.Cursor = new Cursor(@"..\..\cursor\greenflag.cur");
			this.pictureBox1.Cursor=new Cursor(@"..\..\cursor\heart.cur");
			this.pictureBox3.Cursor=new Cursor(@"..\..\cursor\heart.cur");
			this.pictureBox4.Cursor=new Cursor(@"..\..\cursor\heart.cur");
			this.pictureBox5.Cursor=new Cursor(@"..\..\cursor\heart.cur");	
			MyInitializeComponent();

			//布置
			this.panel1.Width=this.Width-this.panel2.Width;
			this.panel1.Height=this.Height-this.statusBar1.Height-52;
			this.panel2.Left=this.Left+this.panel1.Width;
			this.panel2.Height=this.panel1.Height;
			this.panel2.Width=this.Width-this.panel1.Width;	
		
			login=new Form3();
			/*if(login.ShowDialog()==DialogResult.OK)
			{
				label1.Text=login.textBox1.Text.ToString()+" VS "+login.textBox2.Text.ToString();								
				if(login.radioButton1.Checked)
					this.computerAuto=true;
				login.Close();
			}
			else
				login.Close();	
		
			playName[1]="女孩"; playName[2]="男孩";
			playName[3]=login.textBox1.Text.ToString();
			playName[4]=login.textBox2.Text.ToString();					*/
		}

		private void panel1_Resize(object sender, System.EventArgs e)
		{			
			MyInitializeComponent();
		}

		private void label1_DoubleClick(object sender, System.EventArgs e)
		{			
			string tempStr;
			tempStr=playName[1];
			playName[1]=playName[3];
			playName[3]=tempStr;
			tempStr=playName[2];
			playName[2]=playName[4];
			playName[4]=tempStr;

			label1.Text=playName[3];
			label1.Text+=" VS "+playName[4];
			login.textBox1.Text=playName[3];
			login.textBox2.Text=playName[4];
			
			//this.blueZhanJi=0;
			//this.redZhanJi=0;
			//this.statusBarPanel2.Text="红方: 0";
			//this.statusBarPanel3.Text="蓝方: 0";
		}

		private void menuItem15_Click(object sender, System.EventArgs e)
		{
			Form4 form=new Form4();
			form.ShowDialog();
		}

		private void menuItem12_Click(object sender, System.EventArgs e)
		{
			Application.Exit();
		}

		private void menuItem11_Click(object sender, System.EventArgs e)
		{
			this.computerAuto=false;
		}

		private void menuItem67_Click(object sender, System.EventArgs e)
		{
			this.computerAuto=true;
		}

		private void statusBar1_PanelClick(object sender, System.Windows.Forms.StatusBarPanelClickEventArgs e)
		{
			this.blueZhanJi=0;
			this.redZhanJi=0;
			this.statusBarPanel2.Text="红方: 0";
			this.statusBarPanel3.Text="蓝方: 0";
		}

		private void menuItem70_Click(object sender, System.EventArgs e)
		{
			this.WindowState=FormWindowState.Maximized;
		}

		private void menuItem72_Click(object sender, System.EventArgs e)
		{
			Application.Exit();
		}

		private void menuItem71_Click(object sender, System.EventArgs e)
		{
			this.WindowState=FormWindowState.Minimized;
		}

	}
}
