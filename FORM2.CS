using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Threading;

namespace 智能象棋游戏
{
	
	/// <summary>
	/// ***Form2功能:1.调用其它几个自定义类,实现自定义类的功能
	/// ***          2.是对自定义类的视觉实现;也可以说是其它几个自定义类与Form1的接口        
	/// </summary>
	public class Form2 : 智能象棋游戏.Form1
	{
		private System.ComponentModel.IContainer components = null;

		public const string FileName="..\\..\\游戏布置文件.ini";
		public Hashtable myHT=new Hashtable(); //建立初始表，用于存放对应的旗子字符串和旗子图象
		public System.Windows.Forms.PictureBox[] pictureBoxs=new PictureBox[32]; //存放旗子的一组图片框
		
		public Image[] imgs=new Image[14];	
		
		public string battle=null;		
		
		public string[] soldiers=new string[32];

		public Point[] tempPoint=new Point[32]; //存放盛旗子的32个点			
	
		public bool whetherSelected=false;  //保证只有一个图像移动,并且确保移动正确
		public Point p=new Point();                     //移动图象时,记录鼠标的旧坐标
		
		public Point beforeMovePoint=new Point();
        
		public bool letDown=false;
        
		public string[] signString=new string[2];  //存放标志谁走旗的两个字符串
		public int signRight=0;       //哪方走旗索引
		public bool start=false;      //标志位,使第一次走旗时,无条件执行	     

		public string wrongString="right";

		public DateTime startTime=new DateTime(); 	//纪录开始的时间,用系统时间减去开始时间,就是下棋用得时间
		public bool displaystartTime=false;  //当选择了一个游戏类型后(即开始游戏后)才开始计时

		public bool pause=false;         //标志是否按了暂停键

		public bool whichFangQianZou=false;

		public int pauseCount=0;  //记录暂停的时间
        
		public FlagMoveRule a=new FlagMoveRule();
		public RegretMoveFlag huiQi=new RegretMoveFlag();  //贮存走的每一步旗的信息,完成悔旗操作功能
        public JudgeWhichOneWiner jiangJun=new JudgeWhichOneWiner(); //判断是否将军和是否游戏结果(一方获胜)
		public KeyboardOperaterFunction keyBoard=new KeyboardOperaterFunction();
		public SaveGameStatus fileOperate=new SaveGameStatus();
		public RepaintPictureToRound round=new RepaintPictureToRound();   //将所有pictureBox控件由方形变为圆形
		public ComputerBrainpower computer=new ComputerBrainpower();

		public int index=0;   //标志当前哪个pictureBox激活
		
		public bool label3_ShanShuo=false;

		public bool add_Or_Not=true;  //退旗代码中用到的标志变量

		public int shanShuoVarialbe=0;		 //显示时间变量,完成闪烁功能
		public int fen=0,second=0;          //求得当前时间变量
		public string whoGoString="";       //记录label3_Text当前字符串,用于完成闪烁功能		
		
		private System.Timers.Timer timer1;

		static public Form2 form2;	

		public bool GoOnceTime=false;       //电脑自动走旗控制变量
		public bool computerAutoPause=false;    //当退旗时,使电脑走旗暂停                 
		public int computerAutoNumber=0;     //在退旗时,如果不再退旗,电脑在间隔时间内自动走旗  
 
		int SoundValue=0;  //使连续两个声音同步

		public Form2()
		{			
			//建立pictureBoxs的实例
			for(int i=0;i<32;i++)						
				this.pictureBoxs[i]=new PictureBox();							
			
			InitializeComponent();	
			
			//以下代码初始化MyHT对照表
			string[] str={"蓝兵","蓝炮","蓝車","蓝马","蓝象","蓝士","蓝将","红卒","红炮","红車","红马","红象","红士","红帅"}; 			
			
			imgs[0]=Image.FromFile(@"..\..\img\blue-bing.gif");
			imgs[1]=Image.FromFile(@"..\..\img\blue-pao.gif");
			imgs[2]=Image.FromFile(@"..\..\img\blue-ju.gif");
			imgs[3]=Image.FromFile(@"..\..\img\blue-ma.gif");
			imgs[4]=Image.FromFile(@"..\..\img\blue-xiang.gif");
			imgs[5]=Image.FromFile(@"..\..\img\blue-shi.gif");
			imgs[6]=Image.FromFile(@"..\..\img\blue-jiang.gif");
			imgs[7]=Image.FromFile(@"..\..\img\red-zu.gif");
			imgs[8]=Image.FromFile(@"..\..\img\red-pao.gif");
			imgs[9]=Image.FromFile(@"..\..\img\red-ju.gif");
			imgs[10]=Image.FromFile(@"..\..\img\red-ma.gif");
			imgs[11]=Image.FromFile(@"..\..\img\red-xiang.gif");
			imgs[12]=Image.FromFile(@"..\..\img\red-shi.gif");
			imgs[13]=Image.FromFile(@"..\..\img\red-shuai.gif");			
			for(int i=0;i<=13;i++)
			{
				myHT.Add(str[i],imgs[i]);
			}	
			
			//往panel1中添加pictureBoxs数组控件
			this.panel1.Controls.AddRange(pictureBoxs);					

			//使所有PictureBoxs隐藏,不影响主界面的显示
			for(int i=0;i<32;i++)						
				this.pictureBoxs[i].Visible=false;				
			
			for(int i=0;i<32;i++)
			{
				this.pictureBoxs[i].MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBoxs_MouseUp);
				this.pictureBoxs[i].MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBoxs_MouseMove);
				this.pictureBoxs[i].MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBoxs_MouseDown);				
			}
            
			signString[0]="blue";   //初始化标志哪方走旗字符串
			signString[1]="red";   

			this.pictureBox6.Width=this.width/2-5;
			this.pictureBox6.Height=this.height/2+3;				
		}		
		public void ReFresh()
		{			
			this.MyInitializeComponent();
			int tempIndex=0; 			
			for(int i=0;i<90;i++)
			{
				if((i>=0&&i<=8)||(i>=81&&i<=89))
				{					
					tempPoint[tempIndex]=new Point(point[i].X,point[i].Y);
					tempIndex++;					
				} 
				if(i==19||i==25||i==27||i==29||i==31||i==33||i==35)
				{
					tempPoint[tempIndex]=new Point(point[i].X,point[i].Y);
					tempIndex++;					
				}
				if(i==54||i==56||i==58||i==60||i==62||i==64||i==70)
				{
					tempPoint[tempIndex]=new Point(point[i].X,point[i].Y);
					tempIndex++;					
				}				
			}
			a.InitializePart(point,width,height);
			
		}		
		
		public void LoadPictures()
		{            
			//调整pictureBox组的位置/图像来源/显示模式	
			for(int i=0;i<32;i++)
			{				
				this.pictureBoxs[i].Width=this.width;
				this.pictureBoxs[i].Height=this.height;	
				
				this.pictureBoxs[i].Left=this.tempPoint[i].X-this.pictureBoxs[i].Width/2;
				this.pictureBoxs[i].Top=this.tempPoint[i].Y-this.pictureBoxs[i].Height/2;
				
				this.pictureBoxs[i].Cursor=new Cursor(@"..\..\cursor\harrow.cur");
				this.pictureBoxs[i].SizeMode=System.Windows.Forms.PictureBoxSizeMode.StretchImage;
				
				this.pictureBoxs[i].Visible=true;			
			}

			//本语句如果执行,虽然所有pictureBox控件都变为真正的圆;但是,图像拖动效果不太好,出现延迟
			//round.MakeToPictureBoxsToCircle(this.pictureBoxs);
			
			string tempStr=null;				
			StreamReader sr = new StreamReader(FileName,System.Text.Encoding.Default);
			while(tempStr!=battle&&(tempStr=sr.ReadLine())!="[结束]");
			if(tempStr.Equals("[结束]")) return;   //找不到战役名称,则退出			
			tempStr=sr.ReadLine();    //略过战役名称			
			tempStr=tempStr.Trim();				
			int index=0;
			while(!tempStr.Equals("[END]"))
			{
				string[] str=new string[9];
				str=tempStr.Split(' ');
				foreach(string str1 in str)
				{
					string str2;
					str2=str1.Trim();
					if(str1.CompareTo("                                                           ")>0)
						soldiers[index++]=str2;
				}				
				tempStr=sr.ReadLine();			
			} 
			for(int i=0;i<32;i++)
			{
				if(soldiers[i]!="NULL")
				{					
					this.pictureBoxs[i].Image=(Image)myHT[soldiers[i]];					
					continue;
				}			
				this.pictureBoxs[i].Visible=false;
			}			
			sr.Close();  	
			a.Initialize(this.soldiers,this.point,this.tempPoint,this.width,this.height);

            if (IsReplay == false)
            {
                label3.Text="请一方走旗";
			    start=false; 

			    pauseCount=0;
			    pause=false;

			    huiQi.Initialize();
			    add_Or_Not=true;

			    templabel3_Text="";

			    this.whichFangQianZou=false;

			    beforeSaved=true;
			    maySave=true;

			    jiangJun.shanShuo=false;	
    			
			    this.computerAuto=false;            

                //弹出选择模式框音乐
                //Sound.Play("popup");            

                login = new Form3();

                //弹出选择游戏模式对话框
                if (login.ShowDialog() == DialogResult.OK)
                {
                    label1.Text = login.textBox1.Text.ToString() + " VS " + login.textBox2.Text.ToString();
                    if (login.radioButton1.Checked)
                        this.computerAuto = true;
                    login.Close();
                }
                else
                    login.Close();

                playName[1] = "女孩"; playName[2] = "男孩";
                playName[3] = login.textBox1.Text.ToString();
                playName[4] = login.textBox2.Text.ToString();

            }
            IsReplay = false;
		
			//播放开始音乐
			Sound.Play("start");

			
			//开始显示下棋已用时间
			startTime=DateTime.Now;
			displaystartTime=true;

			if(this.computerAuto)           //置计算机为红方
			{
				start=true;
				this.label3.Text="请 蓝方(you) 走旗";
			}
			this.GoOnceTime=false;	
	
			label3_ShanShuo=false;        //停止闪烁文字
		}
		
		public void FromARead()
		{
			for(int i=0;i<=89;i++)
			{				
				if(a.have[i]==true&&a.whichPicture[i]!=-1)
				{					
					this.pictureBoxs[a.whichPicture[i]].Location=new Point(a.allPoint[i].X-width/2,a.allPoint[i].Y-height/2);
					this.pictureBoxs[a.whichPicture[i]].Width=this.width;
					this.pictureBoxs[a.whichPicture[i]].Height=this.height;		
				}
			}		
		}
		private void panel1_Resize(object sender, System.EventArgs e)
		{			
			base.Refresh();
			
			this.ReFresh();	
			
			FromARead();		  
		}	
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

		#region 设计器生成的代码
		/// <summary>
		/// 设计器支持所需的方法 - 不要使用代码编辑器修改
		/// 此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(Form2));
			this.timer1 = new System.Timers.Timer();
			((System.ComponentModel.ISupportInitialize)(this.statusBarPanel1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.statusBarPanel2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.statusBarPanel3)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.statusBarPanel4)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.timer1)).BeginInit();
			// 
			// panel1
			// 
			this.panel1.Name = "panel1";
			this.panel1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.panel1.Size = new System.Drawing.Size(1304, 496);
			this.panel1.Resize += new System.EventHandler(this.panel1_Resize);
			// 
			// panel2
			// 
			this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
			this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
			this.panel2.Location = new System.Drawing.Point(408, 0);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(184, 529);
			// 
			// statusBar1
			// 
			this.statusBar1.Dock = System.Windows.Forms.DockStyle.None;
			this.statusBar1.Location = new System.Drawing.Point(0, 496);
			this.statusBar1.Name = "statusBar1";
			this.statusBar1.Size = new System.Drawing.Size(600, 24);
			// 
			// menuItem8
			// 
			this.menuItem8.Click += new System.EventHandler(this.menuItem8_Click);
			// 
			// menuItem9
			// 
			this.menuItem9.Click += new System.EventHandler(this.menuItem9_Click);
			// 
			// label2
			// 
			this.label2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label2.Location = new System.Drawing.Point(8, 184);
			this.label2.Name = "label2";
			// 
			// pictureBox3
			// 
			this.pictureBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
			this.pictureBox3.Location = new System.Drawing.Point(0, 400);
			this.pictureBox3.Name = "pictureBox3";
			// 
			// pictureBox1
			// 
			this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
			this.pictureBox1.Location = new System.Drawing.Point(72, 400);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(80, 88);
			// 
			// pictureBox4
			// 
			this.pictureBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
			this.pictureBox4.Location = new System.Drawing.Point(104, 8);
			this.pictureBox4.Name = "pictureBox4";
			// 
			// pictureBox5
			// 
			this.pictureBox5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
			this.pictureBox5.Location = new System.Drawing.Point(24, 8);
			this.pictureBox5.Name = "pictureBox5";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(8, 224);
			this.label3.Name = "label3";
			// 
			// label4
			// 
			this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
			this.label4.Location = new System.Drawing.Point(8, 320);
			this.label4.Name = "label4";
			// 
			// menuItem3
			// 
			this.menuItem3.Click += new System.EventHandler(this.menuItem3_Click);
			// 
			// menuItem4
			// 
			this.menuItem4.Click += new System.EventHandler(this.menuItem4_Click);
			// 
			// menuItem7
			// 
			this.menuItem7.Click += new System.EventHandler(this.menuItem7_Click);
			// 
			// menuItem13
			// 
			this.menuItem13.Click += new System.EventHandler(this.menuItem13_Click);
			// 
			// menuItem14
			// 
			this.menuItem14.Click += new System.EventHandler(this.menuItem14_Click);
			// 
			// menuItem16
			// 
			this.menuItem16.Click += new System.EventHandler(this.menuItem16_Click);
			// 
			// menuItem18
			// 
			this.menuItem18.Click += new System.EventHandler(this.menuItem18_Click);
			// 
			// menuItem19
			// 
			this.menuItem19.Click += new System.EventHandler(this.menuItem19_Click);
			// 
			// menuItem20
			// 
			this.menuItem20.Click += new System.EventHandler(this.menuItem20_Click);
			// 
			// label5
			// 
			this.label5.Name = "label5";
			// 
			// menuItem22
			// 
			this.menuItem22.Click += new System.EventHandler(this.menuItem22_Click);
			// 
			// menuItem23
			// 
			this.menuItem23.Click += new System.EventHandler(this.menuItem23_Click);
			// 
			// menuItem25
			// 
			this.menuItem25.Click += new System.EventHandler(this.menuItem25_Click);
			// 
			// menuItem26
			// 
			this.menuItem26.Click += new System.EventHandler(this.menuItem26_Click);
			// 
			// menuItem28
			// 
			this.menuItem28.Click += new System.EventHandler(this.menuItem28_Click);
			// 
			// menuItem29
			// 
			this.menuItem29.Click += new System.EventHandler(this.menuItem29_Click);
			// 
			// menuItem31
			// 
			this.menuItem31.Click += new System.EventHandler(this.menuItem31_Click);
			// 
			// menuItem32
			// 
			this.menuItem32.Click += new System.EventHandler(this.menuItem32_Click);
			// 
			// menuItem34
			// 
			this.menuItem34.Click += new System.EventHandler(this.menuItem34_Click);
			// 
			// menuItem35
			// 
			this.menuItem35.Click += new System.EventHandler(this.menuItem35_Click);
			// 
			// menuItem37
			// 
			this.menuItem37.Click += new System.EventHandler(this.menuItem37_Click);
			// 
			// menuItem38
			// 
			this.menuItem38.Click += new System.EventHandler(this.menuItem38_Click);
			// 
			// menuItem39
			// 
			this.menuItem39.Click += new System.EventHandler(this.menuItem39_Click);
			// 
			// menuItem40
			// 
			this.menuItem40.Click += new System.EventHandler(this.menuItem40_Click);
			// 
			// menuItem41
			// 
			this.menuItem41.Click += new System.EventHandler(this.menuItem41_Click);
			// 
			// menuItem43
			// 
			this.menuItem43.Click += new System.EventHandler(this.menuItem43_Click);
			// 
			// menuItem44
			// 
			this.menuItem44.Click += new System.EventHandler(this.menuItem44_Click);
			// 
			// menuItem47
			// 
			this.menuItem47.Click += new System.EventHandler(this.menuItem47_Click);

            //
            //
            //
            lbRollback.Click += new EventHandler(lbRollback_Click);

			// 
			// pictureBox2
			// 
			this.pictureBox2.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
			this.pictureBox2.Location = new System.Drawing.Point(8, 264);
			this.pictureBox2.Name = "pictureBox2";
			this.pictureBox2.Size = new System.Drawing.Size(48, 48);
			// 
			// menuItem17
			// 
			this.menuItem17.Click += new System.EventHandler(this.menuItem17_Click);
			// 
			// menuItem57
			// 
			this.menuItem57.Click += new System.EventHandler(this.menuItem57_Click);
            //
            //menuItem74
            //
            this.menuItem74.Click += new System.EventHandler(this.menuItem74_Click);
			// 
			// label6
			// 
			this.label6.Name = "label6";
			// 
			// pictureBox6
			// 
			this.pictureBox6.Location = new System.Drawing.Point(16, 416);
			this.pictureBox6.Name = "pictureBox6";
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("隶书", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label1.Name = "label1";
			// 
			// label7
			// 
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(80, 23);
			this.label7.Text = "<后退&B>";
			this.label7.Click += new System.EventHandler(this.label7_Click);
			// 
			// label8
			// 
			this.label8.Location = new System.Drawing.Point(96, 368);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(80, 23);
			this.label8.Text = "<前进&G>";
			this.label8.Click += new System.EventHandler(this.label8_Click);
			// 
			// timer1
			// 
			this.timer1.Enabled = true;
			this.timer1.Interval = 500;
			this.timer1.SynchronizingObject = this;
			this.timer1.Elapsed += new System.Timers.ElapsedEventHandler(this.timer1_Elapsed);
			// 
			// Form2
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(592, 529);
			this.Name = "Form2";
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form2_KeyDown);
			this.Load += new System.EventHandler(this.Form2_Load);
			((System.ComponentModel.ISupportInitialize)(this.statusBarPanel1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.statusBarPanel2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.statusBarPanel3)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.statusBarPanel4)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.timer1)).EndInit();

		}

       
		#endregion

		[STAThread]
		static void Main() 
		{			
			//if(MessageBox.Show("请在分辨率为:(1024*768)象素下运行本游戏,否则可能出现图形不完整!!!","提醒",MessageBoxButtons.OKCancel,MessageBoxIcon.Asterisk)==DialogResult.OK)
			//{
				form2=new Form2();
				Application.Run(form2);				
			//}			
		}	
		

		private void Form2_Load(object sender, System.EventArgs e)
		{
			int fen=0,second=0;
			label2.Text="下棋用时: "+fen.ToString()+"分 "+second.ToString()+"秒";	
			
			//设置初始背景音乐
			Helpers.PlaySound(@"..\..\sound\bk_music\first.WAV", IntPtr.Zero, Helpers.PlaySoundFlags.SND_FILENAME | Helpers.PlaySoundFlags.SND_ASYNC | Helpers.PlaySoundFlags.SND_LOOP);
		}


		#region 显示下棋时间和系统当前时间代码		
		
		int increase=0;
		private void timer1_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
		{
			SoundValue++;
			if(SoundValue==3&&signRight==1&&this.start&&switchEnd!=0)
				Sound.Play("return_red");   //播放红方下旗音乐
			else if(SoundValue==3&&signRight==0&&this.start&&switchEnd!=0)
			{
				Sound.Play("return_blue");
			}


			if(jiangJun.shanShuo&&shanShuoVarialbe%2==0)   //当将军时显示闪烁文字
			{
				label6.Text=" 将军";				
			}
			else 
			{
				//shanShuoVarialbe=0;
				label6.Text="";
			}
			if(label3_ShanShuo&&shanShuoVarialbe%2==0)    //当不是某方走旗,而某方要拿旗时,显示提示文字
			{				
				this.label3.Text="";
			}
			else if(label3_ShanShuo)
			{
                this.label3.Text=whoGoString;				
			}
			shanShuoVarialbe++; 
			if(shanShuoVarialbe>50000)
				shanShuoVarialbe=0;
			this.statusBarPanel4.Text="当前时间: "+DateTime.Now.ToString();			
			if(pause)
			{					
				increase++;
				if(increase%2==0)
					pauseCount++;
				if(increase>1000)
					this.increase=0;
			}
			
			if(displaystartTime)
			{
				fen=DateTime.Now.Minute-startTime.Minute;                
				second=DateTime.Now.Second-startTime.Second;				

				
				second=second-(pauseCount%60);
				fen=fen-(pauseCount/60);
				while(second<0)
				{
					fen-=1; second+=60;
				}				
				if(!pause)
					label2.Text="下棋用时: "+fen.ToString()+"分 "+second.ToString()+"秒";
			}	
			//电脑走旗代码
            if (huiQi.IsReplayAndNoAddItem == false)
            {
                lock (this)
                {
                    if (this.computerAuto && this.signRight == 1 && this.computerAutoPause == false)
                    {
                        Thread.Sleep(600);
                        Point fromPoint = new Point(-1, -1);
                        Point toPoint = new Point(-1, -1);
                        computer.ComputerAuto(this.a, this.jiangJun, ref fromPoint, ref toPoint);

                        //this.label1.Text=a.whichPicture[a.CountIndex(fromPoint)].ToString();
                        index = a.whichPicture[a.CountIndex(fromPoint)];
                        this.MouseDownFunction();
                        this.MovePicture(fromPoint, toPoint, index, true);
                        this.MouseUpFunction();
                        //this.signRight=0;				
                    }
                }
            }
			if(this.computerAutoPause)
			{
				if(this.signRight==0)
				{
					this.computerAutoPause=false;
				}
				else
				{
					this.computerAutoNumber++;
					if(this.computerAutoNumber==4)
					{
						this.computerAutoPause=false;
						this.computerAutoNumber=0;
					}
				}
			}
		}		

		private void menuItem57_Click(object sender, System.EventArgs e)
		{
			pause=!pause;
			if(pause)
			{
				label3.Text="已暂停";
				this.menuItem57.Text="继续";
			}
			else
			{
				this.menuItem57.Text="暂停";
				if(start)
					SettingNoChangeDecriptText();
				else
					label3.Text="请一方走旗";				
			}
		}
		#endregion

		
		#region 装载战役事件代码
		private void menuItem7_Click(object sender, System.EventArgs e)
		{
            huiQi.IsReplayAndNoAddItem = false;
			battle="[車VS马之战]";
			this.LoadPictures();
			this.label5.Text="战役:"+battle;
		}

		private void menuItem3_Click(object sender, System.EventArgs e)
		{
            huiQi.IsReplayAndNoAddItem = false;
            //IsReplay = false;
			battle="[新战役]";
			this.LoadPictures();
			this.label5.Text="战役:"+battle;            
		}

		private void menuItem13_Click(object sender, System.EventArgs e)
		{
            huiQi.IsReplayAndNoAddItem = false;
			battle="[車VS炮之战]";
			this.LoadPictures();
			this.label5.Text="战役:"+battle;
		}

		private void menuItem14_Click(object sender, System.EventArgs e)
		{
            huiQi.IsReplayAndNoAddItem = false;
			battle="[兵VS兵之战]";
			this.LoadPictures();
			this.label5.Text="战役:"+battle;
		}

		private void menuItem16_Click(object sender, System.EventArgs e)
		{
            huiQi.IsReplayAndNoAddItem = false;
			battle="[马VS炮之战]";
			this.LoadPictures();
			this.label5.Text="战役:"+battle;
		}

		private void menuItem17_Click(object sender, System.EventArgs e)
		{
            huiQi.IsReplayAndNoAddItem = false;
			battle="[炮马車之战]";
			this.LoadPictures();
			this.label5.Text="战役:"+battle;
		}

		private void menuItem18_Click(object sender, System.EventArgs e)
		{
            huiQi.IsReplayAndNoAddItem = false;
			battle="[炮VS兵之战]";
			this.LoadPictures();
			this.label5.Text="战役:"+battle;
		}

		private void menuItem19_Click(object sender, System.EventArgs e)
		{
            huiQi.IsReplayAndNoAddItem = false;
			battle="[将军之战]";
			this.LoadPictures();
			this.label5.Text="战役:"+battle;
		}

		private void menuItem20_Click(object sender, System.EventArgs e)
		{
            huiQi.IsReplayAndNoAddItem = false;
			battle="[无士之战]";
			this.LoadPictures();
			this.label5.Text="战役:"+battle;
		}		
		private void menuItem4_Click(object sender, System.EventArgs e)
		{
            huiQi.IsReplayAndNoAddItem = false;
			this.ReStart();
		}

		private void menuItem22_Click(object sender, System.EventArgs e)
		{
            huiQi.IsReplayAndNoAddItem = false;
			battle="[高手让一車]";
			this.LoadPictures();
			this.label5.Text="高手VS赖鸟:"+battle;
		}

		private void menuItem23_Click(object sender, System.EventArgs e)
		{
            huiQi.IsReplayAndNoAddItem = false;
			battle="[高手让两車]";
			this.LoadPictures();
			this.label5.Text="高手VS赖鸟:"+battle;
		}

		private void menuItem25_Click(object sender, System.EventArgs e)
		{
            huiQi.IsReplayAndNoAddItem = false;
			battle="[高手让一马]";
			this.LoadPictures();
			this.label5.Text="高手VS赖鸟:"+battle;
		}

		private void menuItem26_Click(object sender, System.EventArgs e)
		{
            huiQi.IsReplayAndNoAddItem = false;
			battle="[高手让两马]";
			this.LoadPictures();
			this.label5.Text="高手VS赖鸟:"+battle;
		}

		private void menuItem28_Click(object sender, System.EventArgs e)
		{
            huiQi.IsReplayAndNoAddItem = false;
			battle="[高手让一炮]";
			this.LoadPictures();
			this.label5.Text="高手VS赖鸟:"+battle;
		}

		private void menuItem29_Click(object sender, System.EventArgs e)
		{
            huiQi.IsReplayAndNoAddItem = false;
			battle="[高手让两炮]";
			this.LoadPictures();
			this.label5.Text="高手VS赖鸟:"+battle;
		}

		private void menuItem31_Click(object sender, System.EventArgs e)
		{
            huiQi.IsReplayAndNoAddItem = false;
			battle="[高手让一象]";
			this.LoadPictures();
			this.label5.Text="高手VS赖鸟:"+battle;
		}

		private void menuItem32_Click(object sender, System.EventArgs e)
		{
            huiQi.IsReplayAndNoAddItem = false;
			battle="[高手让一士]";
			this.LoadPictures();
			this.label5.Text="高手VS赖鸟:"+battle;
		}

		private void menuItem34_Click(object sender, System.EventArgs e)
		{
            huiQi.IsReplayAndNoAddItem = false;
			battle="[高手让三卒]";
			this.LoadPictures();
			this.label5.Text="高手VS赖鸟:"+battle;
		}

		private void menuItem35_Click(object sender, System.EventArgs e)
		{
            huiQi.IsReplayAndNoAddItem = false;
			battle="[高手让五卒]";
			this.LoadPictures();
			this.label5.Text="高手VS赖鸟:"+battle;
		}

		private void menuItem38_Click(object sender, System.EventArgs e)
		{
            huiQi.IsReplayAndNoAddItem = false;
			battle="[高手让車車炮]";
			this.LoadPictures();
			this.label5.Text="高手VS赖鸟:"+battle;
		}

		private void menuItem41_Click(object sender, System.EventArgs e)
		{
            huiQi.IsReplayAndNoAddItem = false;
			battle="[高手让車車马]";
			this.LoadPictures();
			this.label5.Text="高手VS赖鸟:"+battle;
		}

		private void menuItem39_Click(object sender, System.EventArgs e)
		{
            huiQi.IsReplayAndNoAddItem = false;
			battle="[高手让马马炮]";
			this.LoadPictures();
			this.label5.Text="高手VS赖鸟:"+battle;
		}

		private void menuItem40_Click(object sender, System.EventArgs e)
		{
            huiQi.IsReplayAndNoAddItem = false;
			battle="[高手让马马車]";
			this.LoadPictures();
			this.label5.Text="高手VS赖鸟:"+battle;
		}

		private void menuItem43_Click(object sender, System.EventArgs e)
		{
            huiQi.IsReplayAndNoAddItem = false;
			battle="[高手让炮炮马]";
			this.LoadPictures();
			this.label5.Text="高手VS赖鸟:"+battle;
		}

		private void menuItem44_Click(object sender, System.EventArgs e)
		{
            huiQi.IsReplayAndNoAddItem = false;
			battle="[高手让炮炮車]";
			this.LoadPictures();
			this.label5.Text="高手VS赖鸟:"+battle;
		}

		private void menuItem37_Click(object sender, System.EventArgs e)
		{
            huiQi.IsReplayAndNoAddItem = false;
			battle="[高手让車马炮]";
			this.LoadPictures();
			this.label5.Text="高手VS赖鸟:"+battle;
		}

		private void menuItem47_Click(object sender, System.EventArgs e)
		{
            huiQi.IsReplayAndNoAddItem = false;
			battle="[高手半对全军]";
			this.LoadPictures();
			this.label5.Text="高手VS赖鸟:"+battle;
		}
		#endregion		
				
		
		#region 图象拖动事件代码	
		
		public void MouseDownFunction()        //设置鼠标按下时的对数
		{			
			//是不是轮到你走旗了			
			if((a.who[a.CountIndex(pictureBoxs[index].Left+width/2,pictureBoxs[index].Top+height/2)])!=signString[signRight]&&start)                
			{
				//播放非法拿旗声音
				Sound.Play("no");
				
				Cursor.Current=new Cursor(@"..\..\cursor\stop.cur");					
				if(GoOnceTime==false&&this.computerAuto)
				{
					this.label3.Text="蓝方(you)!!! 红方(computer)";	
					whoGoString=this.label3.Text.ToString();
				}
				else
					SettingNoChangeDecriptText();
				wrongString="wrong";
				label3_ShanShuo=true;				
				return;			
			}
			
			//播放拿旗声音
			Sound.Play("hold");
			
			wrongString="right";            
            label3_ShanShuo=false;
			
			whetherSelected=true;			
			p.X=Cursor.Position.X;
			p.Y=Cursor.Position.Y;			
			
			beforeMovePoint.X=this.pictureBoxs[index].Left+this.width/2;
			beforeMovePoint.Y=this.pictureBoxs[index].Top+this.height/2;			
			
			this.pictureBoxs[index].BringToFront();   		
			
			this.pictureBox6.Visible=true;
			this.pictureBox6.Left=this.pictureBoxs[index].Left+1;
			this.pictureBox6.Top=this.pictureBoxs[index].Top+6;			
		}		
		
		int switchEnd=0;
		public void MouseUpFunction()
		{
			SoundValue=0;
			
			if(wrongString=="wrong")
				return;
						
			whetherSelected=false;			
			
			if(letDown)
			{				
				Point dropPoint=a.GetNearPoint(this.pictureBoxs[index].Left+width/2,this.pictureBoxs[index].Top+height/2); //求得当前pictureBox所在的点(在旗盘上存在的点)			
				jiangJun.JiangJun(beforeMovePoint,dropPoint,this.a);				
				
				Point point=a.GetNearPoint(this.pictureBoxs[index].Left+width/2,this.pictureBoxs[index].Top+height/2); //求得当前pictureBox所在的点(在旗盘上存在的点)
				
				//计算目的点是哪个pictureBox
				int sourceIndex=a.whichPicture[a.CountIndex(this.beforeMovePoint)];
				int objectIndex=a.whichPicture[a.CountIndex(point)];

				this.SettingNoChangeDecriptText();				
				if(a.JudgeQiZi(beforeMovePoint,point))
				{					
					if(add_Or_Not)
						huiQi.SaveNewItem(sourceIndex,objectIndex,beforeMovePoint,point,label3.Text.ToString(),this.signRight,this.start,this.wrongString,this.whichFangQianZou,this.a);					
					else
					{
						add_Or_Not=true;
						huiQi.SubLastItem();
						huiQi.SaveNewItem(sourceIndex,objectIndex,beforeMovePoint,point,label3.Text.ToString(),this.signRight,this.start,this.wrongString,this.whichFangQianZou,this.a);					
					}
				}		
				
				switchEnd=a.ChangeQiZi(beforeMovePoint,point);		
				
				if(switchEnd==0)
				{					
					//播放落旗子的音乐
					Sound.Play("fall");
					
					//将pictureBox移到原位置
					this.MovePicture(point,beforeMovePoint,index,false);	
					SettingNoChangeDecriptText();					
				}
				if(switchEnd==1)
				{
					//播放落旗但没吃对方旗子的音乐
					Sound.Play("fall");		
					
					//将picture从当前位置移到目的位置
					Point currentPoint=new Point(this.pictureBoxs[index].Left+width/2,this.pictureBoxs[index].Top+height/2);
					this.MovePicture(currentPoint,point,index,false);					
                   
					SettingChangeDecriptText();
						
					SaveLastItem(-1,-1,beforeMovePoint,point,this.label3.Text.ToString(),this.signRight,this.start,this.wrongString,this.whichFangQianZou,this.a);					
                    this.pictureBox6.Visible=false;								
				}
				if(switchEnd==2)
				{
					//播放落旗且已吃了对方旗子的音乐
					Sound.Play("kill");
					
					//使picture移动到当前位置,并将当前位置pictureBox隐藏
					Point currentPoint=new Point(this.pictureBoxs[index].Left+width/2,this.pictureBoxs[index].Top+height/2);
					this.MovePicture(currentPoint,point,index,false);	
					this.pictureBoxs[objectIndex].Hide();

					SettingChangeDecriptText();					
					SaveLastItem(-1,-1,beforeMovePoint,point,this.label3.Text.ToString(),this.signRight,this.start,this.wrongString,this.whichFangQianZou,this.a);					               
					this.pictureBox6.Visible=false;					
				}				
				
				//播放将军声音
				if(jiangJun.shanShuo)  //jiangJun类中的成员变量shanShuo,标志当前旗局是否将军
				{					
					Sound.Play("jiangjun");
				}

				if(jiangJun.WinGame(this.a)!=0)
				{					
					this.start=false;
					//播放本旗局结束-胜利声音
					Sound.Play("win");
					
					this.signRight=0;
					end();
					return;
				}				
			}
			else
			{
				switchEnd=0; //避免播放return_red/black的音乐，因为玩者已经知道
				//播放非法置旗子音乐
				Sound.Play("back");
				
				Point point=new Point(this.pictureBoxs[index].Left+width/2,this.pictureBoxs[index].Top+height/2); //求得当前pictureBox所在的点(在旗盘上不存在的点)
				this.MovePicture(point,beforeMovePoint,index,false);				
			}			
			this.pictureBox2.Visible=false;	  //不显示标志可以落旗的下箭头图片			
		}		
		
		public void MouseMoveFunction()
		{
			if(whetherSelected==true)
			{				
				if(this.pictureBoxs[index].Left>this.panel1.Left-10&&this.pictureBoxs[index].Right<this.panel1.Right+10&&this.pictureBoxs[index].Top>this.panel1.Top-10&&this.pictureBoxs[index].Bottom<this.panel1.Bottom+10)				
				{			
					//播放移动旗子声音
					Sound.Play("move");
					
					this.pictureBoxs[index].Left=this.pictureBoxs[index].Left+(Cursor.Position.X-p.X);
					this.pictureBoxs[index].Top=this.pictureBoxs[index].Top+(Cursor.Position.Y-p.Y);
				
					p.X=Cursor.Position.X;
					p.Y=Cursor.Position.Y;						

					//判断是否是正确位置;如果是,则修改鼠标为"下键头"	
					Point point=a.GetNearPoint(this.pictureBoxs[index].Left+width/2,this.pictureBoxs[index].Top+height/2);										
					if(point.X!=-1&&a.AcceptJudge(beforeMovePoint,point,jiangJun.GenEatGen))
					{						
						string str1=a.str[a.CountIndex(beforeMovePoint)];   //求得手中握的是什么旗子
						string str2=a.str[a.CountIndex(point)];             //求得要放置的位置是什么旗子
						string who1=a.who[a.CountIndex(beforeMovePoint)]; //求得手中握的旗子是属于哪方
						string who2=a.who[a.CountIndex(point)];           //求得要放旗子位置存放哪方的旗子

						this.pictureBox2.Visible=true;
						if(beforeMovePoint==point)
						{
							Cursor.Current=new Cursor(@"..\..\cursor\hold.cur");							
							label3.Text="请为 ["+str1+"] 选择位置";
							if(this.signRight==0)
								this.pictureBox2.Image=Image.FromFile(@"..\..\img\boy.GIF");
							else 
								this.pictureBox2.Image=Image.FromFile(@"..\..\img\girl.GIF");
						}
						else
						{
							//播放可以放旗的声音
							Sound.Play("mayfall");
							
							this.pictureBox2.Image=Image.FromFile(@"..\..\img\down.gif");
							if(!a.have[a.CountIndex(point)])
							{
								if(who1=="blue")
									Cursor.Current=new Cursor(@"..\..\cursor\finger.cur");	
								else
									Cursor.Current=new Cursor(@"..\..\cursor\finger1.cur");
								label3.Text="可以放置    ["+str1+"]";

							}
							else 
							{
								if(who2=="red"||who1=="blue")
								{
									Cursor.Current=new Cursor(@"..\..\cursor\ok2.cur"); 
									label3.Text="["+str1+"] 可以吃 ["+str2+"]";
								}
								else 
								{
									if(who2=="blue"||who1=="red")
									{
										Cursor.Current=new Cursor(@"..\..\cursor\ok1.cur");
										label3.Text="["+str1+"] 可以吃 ["+str2+"]";
									}
								}								
							}							
						}	
						letDown=true;  		
					}
					else
					{
						label3.Text="不能放置["+a.str[a.CountIndex(beforeMovePoint)]+"]";
						Cursor.Current=new Cursor(@"..\..\cursor\hold.cur");
						letDown=false;
						this.pictureBox2.Visible=false;
					}
				}
				else
				{
					letDown=false;
					Cursor.Current=new Cursor(@"..\..\cursor\stop.cur");
					label3.Text="["+a.str[a.CountIndex(beforeMovePoint)]+"] 不能出界";
				}
			}				
		}
		private void pictureBoxs_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{		
			if(pause)
			{
				Sound.Play("no");
				return;   //暂停时候不能走旗
			}
			
			if(keyBoard.KeyBoardOperating)
			{
				Sound.Play("no");  //为防止冲突,键盘操作时,鼠标禁止操作
				return;
			}		
			
			if(e.Button==MouseButtons.Right)  //为了避免鼠标左右键冲突,只限按左键
				return;		
			
			keyBoard.MouseOperating=true;

			index=0;
			for(int i=0;i<32;i++)
				if(pictureBoxs[i].Capture)
					index=i;
			MouseDownFunction();         			
		}

		
		private void pictureBoxs_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
		{			
			if(pause)
			{
				Sound.Play("no");
				return;   //暂停时候不能走旗
			}
			if(!keyBoard.MouseOperating)
			{
				Sound.Play("no");
				return;
			}			

			if(e.Button==MouseButtons.Right)   //为了避免鼠标左右键冲突,只限按左键
				return;		
			MouseUpFunction();	
		
			keyBoard.MouseOperating=false;
		}
		
		private void pictureBoxs_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
		{			
			if(pause)
				return;   //暂停时候不能走旗
			if(keyBoard.KeyBoardOperating)
			{				
				return;
			}			
			MouseMoveFunction();
		}
		
		public void ReStart()
		{
            //IsReplay = false;
			if(battle!=null)
				this.LoadPictures();
			else
				MessageBox.Show(this,"请先选择战役");
			templabel3_Text="";
			this.pictureBox2.Visible=false;			
		}
		public void end()
		{
			double rateLive_Blue=(a.bluenum*10/a.blueNumTotal)*10;  //存活率
			double rateLive_Red=(a.rednum*10/a.redNumTotal)*10;     
			double rateDeath_Blue=(((a.blueNumTotal*10-a.bluenum*10)/a.blueNumTotal)*10); //军队损失率
			double rateDeath_Red=(((a.redNumTotal*10-a.rednum*10)/a.redNumTotal)*10);
			if(rateLive_Blue==0)
				rateLive_Blue++;
			if(rateLive_Red==0)
				rateLive_Red++;
			double bluerate=(rateDeath_Blue/rateLive_Blue)*100;
			double redrate=(rateDeath_Red/rateLive_Red)*100;
			double blueScore=this.fen*2+bluerate*30;               //成绩
			double redScore=this.fen*2+redrate*30;
			
			
			if(jiangJun.WinGame(this.a)==1)
			{				
				this.label3.Text="蓝方获胜!!!";
				blueZhanJi++;
				jiangJun.shanShuo=false;Thread.Sleep(500);MessageBox.Show("\n蓝方赢得比赛,红方再接再力!!!"+"\n\n"+this.label2.Text.ToString()+"\n\n\n"+"   蓝方            红方\n\n"+"总旗数目:"+a.blueNumTotal.ToString()+"个"+"   总旗数目:"+a.redNumTotal.ToString()+"个\n\n"+"失旗数目:"+(a.blueNumTotal-a.bluenum).ToString()+"个  "+"  失旗数目:"+(a.redNumTotal-a.rednum).ToString()+"个\n\n"+"军队损失率:%"+((int)(rateDeath_Blue)).ToString()+"  军队损失率:%"+((int)rateDeath_Red).ToString()+"\n\n"+"得分:"+((int)(blueScore+15000)).ToString()+"分"+"    得分"+((int)redScore).ToString()+"分","蓝方胜利"); 
				this.statusBarPanel3.Text="蓝方: "+blueZhanJi.ToString();				
			}
			else
			{				
				this.label3.Text="红方获胜!!!";
				redZhanJi++;
				jiangJun.shanShuo=false;Thread.Sleep(500);MessageBox.Show("\n红方赢得比赛,蓝方再接再力!!!"+"\n\n"+this.label2.Text.ToString()+"\n\n\n"+"   蓝方            红方\n\n"+"总旗数目:"+a.blueNumTotal.ToString()+"个"+"   总旗数目:"+a.redNumTotal.ToString()+"个\n\n"+"失旗数目:"+(a.blueNumTotal-a.bluenum).ToString()+"个  "+"  失旗数目:"+(a.redNumTotal-a.rednum).ToString()+"个\n\n"+"军队损失率:%"+((int)(rateDeath_Blue)).ToString()+"  军队损失率:%"+((int)rateDeath_Red).ToString()+"\n\n"+"得分:"+((int)blueScore).ToString()+"分"+"    得分"+((int)(redScore+15000)).ToString()+"分","红方胜利"); 
				this.statusBarPanel2.Text="红方: "+redZhanJi.ToString();				
			}
			//this.ReStart();				
			
            ////清空旗盘
            //for(int i=0;i<32;i++)
            //    this.pictureBoxs[i].Visible=false;
            //this.label3.Text="请选择游戏类型";	
            this.pictureBox2.Visible=false;

            //当下旗结束时，才可以启用回放功能
            menuItem74.Enabled = true;
            lbRollback.Enabled = true;

            //displaystartTime=false;  //在新旗局开始之前,不能悔旗操作
			
            ////恢复变量状态,在新旗局开始之前,不能设置断点和恢复断点
            //maySave=false;  
            //beforeSaved=false;

            //播放背景音乐
			Helpers.PlaySound(@"..\..\sound\bk_music\three.WAV", IntPtr.Zero, Helpers.PlaySoundFlags.SND_FILENAME | Helpers.PlaySoundFlags.SND_ASYNC | Helpers.PlaySoundFlags.SND_LOOP);
		}
		public double XtoY_Value(Point p1,Point p2,int x)
		{
			//设直线方程为: y=Kx+C,根据两个点可以求出直线方程,进而可以返回x对应的y值
			double x1=p1.X,y1=p1.Y;
			double x2=p2.X,y2=p2.Y;            
			double C,K;			
			if(x1!=x2)
			{
				K=(y2-y1)/(x2-x1); 
				C=y2-K*x2;				
				double y=(K*x)+C;				
				return y;
			}
			else return -1.0;
		}
		
		public void MovePicture(Point fromPoint,Point toPoint,int index,bool computerRun)
		{
            try
            {
                this.pictureBoxs[index].BringToFront();

                if (fromPoint != toPoint)
                {
                    if (a.GetTwoPointDistance(fromPoint, toPoint) <= 2 * height && fromPoint.X == toPoint.X)//垂直,且距离为一格时,如兵
                    {
                        int i = 0;
                        if (fromPoint.Y > toPoint.Y)
                        {
                            for (int variableY = fromPoint.Y; variableY != toPoint.Y; variableY--)
                            {
                                this.pictureBoxs[index].Left = fromPoint.X - width / 2;
                                this.pictureBoxs[index].Top = variableY - height / 2;
                                this.ReFresh();
                                if (i++ % 3 == 0)
                                    Thread.Sleep(1);
                            }
                        }
                        else
                        {
                            for (int variableY = fromPoint.Y; variableY != toPoint.Y; variableY++)
                            {
                                this.pictureBoxs[index].Left = fromPoint.X - width / 2;
                                this.pictureBoxs[index].Top = variableY - height / 2;
                                this.ReFresh();
                                if (i++ % 3 == 0)
                                    Thread.Sleep(1);
                            }
                        }
                    }
                    else if (fromPoint.X == toPoint.X)   //如炮垂直走旗
                    {
                        int i = 0;
                        if (fromPoint.Y > toPoint.Y)
                        {
                            for (int variableY = fromPoint.Y; variableY != toPoint.Y; variableY--)
                            {
                                this.pictureBoxs[index].Left = fromPoint.X - width / 2;
                                this.pictureBoxs[index].Top = variableY - height / 2;
                                this.ReFresh();
                                if (i++ % 8 == 0)
                                    Thread.Sleep(1);
                            }
                        }
                        else
                        {
                            for (int variableY = fromPoint.Y; variableY != toPoint.Y; variableY++)
                            {
                                this.pictureBoxs[index].Left = fromPoint.X - width / 2;
                                this.pictureBoxs[index].Top = variableY - height / 2;
                                this.ReFresh();
                                if (i++ % 8 == 0)
                                    Thread.Sleep(1);
                            }
                        }
                    }
                    else
                    {
                        double valueY = fromPoint.Y;
                        int k = 1;
                        if (fromPoint.X > toPoint.X)
                            k = -1;
                        int add = 0;
                        for (int variableX = fromPoint.X; variableX != toPoint.X; variableX += k)
                        {
                            valueY = this.XtoY_Value(fromPoint, toPoint, variableX);
                            if (valueY != -1.0)
                            {
                                this.pictureBoxs[index].Left = variableX - width / 2;
                                this.pictureBoxs[index].Top = (int)valueY - height / 2;

                                int x1 = fromPoint.X, y1 = fromPoint.Y;
                                int x2 = toPoint.X, y2 = toPoint.Y;
                                double distance = Math.Sqrt((x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1));
                                this.ReFresh();
                                if (add++ % 8 == 0)
                                    Thread.Sleep(1);
                                Random num = new Random();
                                int getNum = num.Next(100);
                                if (getNum % 2 == 0 && distance < 250.0 && computerRun == false)
                                    Thread.Sleep(5);
                                if (getNum % 2 == 0 && distance < 300 && computerRun)   //在退旗/进旗操作中,延迟旗子速度,以致于能够看清旗子运动轨迹
                                    Thread.Sleep(10);
                            }
                        }
                    }
                }
                this.pictureBoxs[index].Left = toPoint.X - width / 2;
                this.pictureBoxs[index].Top = toPoint.Y - height / 2;
            }
            catch
            {
 
            }
		}
		
		public void SettingChangeDecriptText()
		{			
			if(a.who[a.CountIndex(this.pictureBoxs[index].Left+width/2,this.pictureBoxs[index].Top+height/2)].ToString()=="blue")
			{				
				signRight=1;
				if(!(login.textBox1.Text.ToString().Equals("player1")&&login.textBox2.Text.ToString().Equals("player2")))
					label3.Text=login.textBox1.Text.ToString()+" 请走旗";
				else
					label3.Text="红方 请走旗";				
			}
			else 
			{
				signRight=0;
				if(!(login.textBox1.Text.ToString().Equals("player1")&&login.textBox2.Text.ToString().Equals("player2")))
					label3.Text=login.textBox2.Text.ToString()+" 请走旗";
				else
				{					
					label3.Text="蓝方 请走旗";	//播放蓝方下旗音乐			
				}				
			}
			start=true;
			whichFangQianZou=true;
			whoGoString="不能连续走旗 "+label3.Text.ToString();

			if(GoOnceTime==false&&this.computerAuto)
				GoOnceTime=true;			
		}
		public void SettingNoChangeDecriptText()
		{			
			if(whichFangQianZou==false)
			{
				label3.Text="请一方走旗";
				return;
			}
			if(signRight==1)
			{				
				if(!(login.textBox1.Text.ToString().Equals("player1")&&login.textBox2.Text.ToString().Equals("player2")))
					label3.Text=login.textBox1.Text.ToString()+" 请走旗";
				else
					label3.Text="红方走旗";				
			}
			else 
			{				
				if(!(login.textBox1.Text.ToString().Equals("player1")&&login.textBox2.Text.ToString().Equals("player2")))
					label3.Text=login.textBox2.Text.ToString()+" 请走旗";
				else
				{					
					label3.Text="蓝方走旗";				
				}
			}
			start=true;
			whoGoString="不能连续走旗 "+label3.Text.ToString();			
		}		
		int temp_from_index;int temp_to_index;Point tempbeforemovepoint;Point temppoint;string templabel3_Text;int tempsignright;bool tempstart;string tempwrongstring;bool tempwhichfangxianzou;FlagMoveRule tempa=new FlagMoveRule(); 
		public void SaveLastItem(int tempFromIndex,int tempToIndex,Point tempbeforeMovePoint,Point temppoint,string templabel3_Text,int tempsignRight,bool tempstart,string tempwrongString,bool tempwhichFangQianZou,FlagMoveRule a)
		{			
			//赋值
			this.temp_from_index=tempFromIndex;this.temp_to_index=tempToIndex;this.tempbeforemovepoint=tempbeforeMovePoint;this.temppoint=temppoint;this.templabel3_Text=templabel3_Text;
			this.tempsignright=tempsignRight;this.tempstart=tempstart;this.tempwrongstring=tempwrongString;this.tempwhichfangxianzou=tempwhichFangQianZou;this.tempa=a;
		}
		#endregion


		#region 悔旗操作代码
		private void Back()
		{		
			if(displaystartTime==false)
			{
				this.label3.Text="请选择游戏类型";
				Sound.Play("no");
				return;
			}
            if (add_Or_Not)
			{
				huiQi.SaveNewItem(temp_from_index,temp_to_index,tempbeforemovepoint,temppoint,this.templabel3_Text,tempsignright,tempstart,tempwrongstring,tempwhichfangxianzou,tempa);					
				add_Or_Not=false;
			}
			
			//退旗操作
			int fromIndex=-1,toIndex=-1; string label3_Text="请一方走旗";
			Point fromPoint,toPoint;
			fromPoint=new Point(-1,-1);  toPoint=new Point(-1,-1);					
			int end=huiQi.FallBack(ref fromIndex,ref toIndex,ref fromPoint,ref toPoint,ref label3_Text,ref this.signRight,ref this.start,ref this.wrongString,ref this.whichFangQianZou,ref this.a);
					
			if(end==0)
			{
				label3.Text="已经退到起始 请一方走旗";
				Sound.Play("huiqiend");
				this.whichFangQianZou=false;
				return;
			}

            if (!huiQi.IsReplayAndNoAddItem)
            {
                this.label3.Text = "[" + a.str[a.CountIndex(fromPoint)] + "]" + "后退 " + "        " + label3_Text;
            }
            else
            {
                this.label3.Text = "观看:[" + a.str[a.CountIndex(fromPoint)] + "]" + "后退," + "" + "按<B>键继续...";
            }
			if(fromIndex==-1&&toIndex==-1)  //最后一步只是存储一些参数
			{				
				return;
			}
			Sound.Play("huiqi");
			if(toIndex==-1)  //本步操作为移动操作
			{
				this.MovePicture(toPoint,fromPoint,fromIndex,true);
			}
			else
			{
				this.pictureBoxs[toIndex].Visible=true;
				this.MovePicture(toPoint,fromPoint,fromIndex,true);				
			}			
			this.jiangJun.JiangJun(this.a);   			
		}

		private void forward()
		{			
			if(displaystartTime==false)
			{
				Sound.Play("no");
				this.label3.Text="请选择游戏类型";
				return;
			}
            if (add_Or_Not)
			{
				huiQi.SaveNewItem(temp_from_index,temp_to_index,tempbeforemovepoint,temppoint,templabel3_Text,tempsignright,tempstart,tempwrongstring,tempwhichfangxianzou,tempa);					
				add_Or_Not=false;
			}		
			//往前移动旗子
			int fromIndex=-1,toIndex=-1; string label3_Text="请一方走旗";
			Point fromPoint,toPoint;
			fromPoint=new Point(-1,-1);  toPoint=new Point(-1,-1);						
			int end=huiQi.GoAhead(ref fromIndex,ref toIndex,ref fromPoint,ref toPoint,ref label3_Text,ref this.signRight,ref this.start,ref this.wrongString,ref this.whichFangQianZou,ref a);
						
			if(end==0)
			{
				label3.Text="已经退到最后 "+templabel3_Text;
				Sound.Play("huiqiend");
				return;
			}

            if (!huiQi.IsReplayAndNoAddItem)
            {
                this.label3.Text = "[" + a.str[a.CountIndex(toPoint)] + "]" + "前进 " + "        " + label3_Text;
            }
            else
            {
                this.label3.Text = "观看:[" + a.str[a.CountIndex(toPoint)] + "]" + "前进," + "" + "按<G>键继续...";
            }
			if(fromIndex==-1&&toIndex==-1)  //对最后一步旗只修改参数,不移动图片
				return;			
			
			Sound.Play("huiqi");

			if(toIndex==-1)  //本步操作为移动操作
			{
				this.MovePicture(fromPoint,toPoint,fromIndex,true);
			}
			else
			{
				this.MovePicture(fromPoint,toPoint,fromIndex,true);
				this.pictureBoxs[toIndex].Visible=false;
			}			
			this.jiangJun.JiangJun(this.a);
		}

        private bool IsReplay = false;
        //private bool IsReplayAndNoAddItem = false;
        private void RePlay()
        {
            IsReplay = true;

            huiQi.IsReplayAndNoAddItem = true;

            computerAutoPause = true;

            //Back
            if (displaystartTime == false)
            {
                this.label3.Text = "请选择游戏类型";
                Sound.Play("no");
                return;
            }
            if (add_Or_Not)
            {
                huiQi.IsReplayAndNoAddItem = false;
                huiQi.SaveNewItem(temp_from_index, temp_to_index, tempbeforemovepoint, temppoint, this.templabel3_Text, tempsignright, tempstart, tempwrongstring, tempwhichfangxianzou, tempa);
                add_Or_Not = false;
                huiQi.IsReplayAndNoAddItem = true;
            }

            //退旗操作
            int end = -1;
            int fromIndex = -1, toIndex = -1;
            string label3_Text = "请一方走旗";
            Point fromPoint, toPoint;
            fromPoint = new Point(-1, -1); toPoint = new Point(-1, -1);
            while (end != 0)
            {                
                end = huiQi.FallBack(ref fromIndex, ref toIndex, ref fromPoint, ref toPoint, ref label3_Text, ref this.signRight, ref this.start, ref this.wrongString, ref this.whichFangQianZou, ref this.a);
            }

            //this.whichFangQianZou = false;

            //if (end == 0)
            //{
            //    label3.Text = "已经退到起始 请一方走旗";
            //    Sound.Play("huiqiend");
            //    this.whichFangQianZou = false;
            //    return;
            //}

            //this.label3.Text = "[" + a.str[a.CountIndex(fromPoint)] + "]" + "后退 " + "        " + label3_Text;
            if (fromIndex == -1 && toIndex == -1)  //最后一步只是存储一些参数
            {
                return;
            }
            //Sound.Play("huiqi");
            //if (toIndex == -1)  //本步操作为移动操作
            //{
            //    this.MovePicture(toPoint, fromPoint, fromIndex, true);
            //}
            //else
            //{
            //    this.pictureBoxs[toIndex].Visible = true;
            //    this.MovePicture(toPoint, fromPoint, fromIndex, true);
            //}
            //this.jiangJun.JiangJun(this.a);   			

            //恢复旗子原始位置
            if (battle != null)
                this.LoadPictures();

            this.label3.Text = " 请连续按< G >键....";


            ////Forward(正向一步一步移动旗子)                 
            ////这里遇到问题：程序能够正确实现,并能够正确的往前走旗，但PictureBoxs在移动过程中看不清楚，得等所有旗子移动完毕才能看清楚,所以回放动作要用用户来处发每一步往前走旗             
            ////感兴趣的话，可以将下面的代码注释去掉，即可看一下运行效果! 也许您有更好的解决办法!            
            ////
            //int fromIndex2 = -1, toIndex2 = -1; 
            //string label3_Text2 = "请一方走旗";
            //Point fromPoint2, toPoint2;
            //fromPoint2 = new Point(-1, -1); toPoint2 = new Point(-1, -1);
            //int end2 = -1;
            //Thread.Sleep(5000);
            //while (end2 != 0)
            //{
            //    Thread.Sleep(1000);
            //    end2 = huiQi.GoAhead(ref fromIndex2, ref toIndex2, ref fromPoint2, ref toPoint2, ref label3_Text, ref this.signRight, ref this.start, ref this.wrongString, ref this.whichFangQianZou, ref a);
            //    this.label3.Text = "[" + a.str[a.CountIndex(toPoint)] + "]" + "前进 " + "        " + label3_Text2;
            //    if (fromIndex == -1 && toIndex == -1)  //对最后一步旗只修改参数,不移动图片
            //        return;

            //    Sound.Play("huiqi");
            //    if (toIndex2 == -1)  //本步操作为移动操作
            //    {
            //        this.MovePicture(fromPoint2, toPoint2, fromIndex2, true);
            //    }
            //    else
            //    {
            //        this.MovePicture(fromPoint2, toPoint2, fromIndex2, true);
            //        this.pictureBoxs[toIndex2].Visible = false;
            //    }
            //    this.jiangJun.JiangJun(this.a);
            //}

            //if (end2 == 0)
            //{
            //    //label3.Text = "已经退到最后 " + templabel3_Text;
            //    Sound.Play("huiqiend");
            //    return;
            //}                   
            
        }
		private void label7_Click(object sender, System.EventArgs e)
		{
			if(pause||fetch)  //当键盘正在走旗或暂停时,不准退旗
			{
				Sound.Play("no");
				return;   //暂停时候不能悔旗操作
			}

			label3_ShanShuo=false;        //停止闪烁文字
			this.Back();
			this.computerAutoPause=true;
		}

		private void label8_Click(object sender, System.EventArgs e)
		{
			if(pause||fetch)  //当键盘正在走旗或暂停时,不准退旗
			{
				Sound.Play("no");
				return;   //暂停时候不能悔旗操作
			}

			label3_ShanShuo=false;        //停止闪烁文字
			this.forward();
			this.computerAutoPause=true;
		}

        private void menuItem74_Click(object sender, System.EventArgs e)
        {
            RePlay();
        }

        void lbRollback_Click(object sender, EventArgs e)
        {
            RePlay();
        }        

		#endregion


		#region 支持键盘操作代码		
			   
		public bool fetch=false;
		private void Form2_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
            if (e.KeyCode == Keys.B && whetherSelected == false)  //当鼠标玩者在走旗时,键盘玩者不得悔旗操作
            {
                label7_Click(sender, e);
                return;
            }
            if (e.KeyCode == Keys.G && whetherSelected == false)  //当鼠标玩者在走旗时,键盘玩者不得悔旗操作
            {
                label8_Click(sender, e);
                return;
            }
			if(pause)
			{
				Sound.Play("no");
				return;   //暂停时候不能走旗
			}

			if(keyBoard.MouseOperating)
			{
				Sound.Play("no");
				return;
			}   
			
			//将光标移动到最近一点代码			
				double distance=double.MaxValue;
				int smallIndex=-1;
				Point cursorCurrentPoint=new Point(Cursor.Position.X,Cursor.Position.Y-48);
				for(int i=0;i<90;i++)
					if(a.GetTwoPointDistance(a.allPoint[i],cursorCurrentPoint)<distance)
					{
						distance=a.GetTwoPointDistance(a.allPoint[i],cursorCurrentPoint);
						smallIndex=i;
					}
				Cursor.Position=new Point(a.allPoint[smallIndex].X,a.allPoint[smallIndex].Y+48);			
			if((e.KeyCode==Keys.ControlKey&&fetch==false)||(e.KeyCode==Keys.Space&&fetch==false)||(e.KeyCode==Keys.Enter&&fetch==false))
			{				
				index=a.whichPicture[a.CountIndex(a.GetNearPoint(Cursor.Position.X,Cursor.Position.Y-48))];
                
				if(index==-1)
					return;
				
				MouseDownFunction();
				if(label3_ShanShuo==false)  //MouseDownFunction顺利执行(即是轮到该方走旗)
				{
					fetch=true;				
					keyBoard.KeyBoardOperating=true;
					
					this.pictureBox2.Visible=true;
					if(this.signRight==0)
						this.pictureBox2.Image=Image.FromFile(@"..\..\img\boy.GIF");
					else 
						this.pictureBox2.Image=Image.FromFile(@"..\..\img\girl.GIF");					
				}
				else
					Cursor.Current=new Cursor(@"..\..\cursor\stop.cur");
			}
			else if((e.KeyCode==Keys.ControlKey&&fetch==true)||(e.KeyCode==Keys.Space&&fetch==true)||(e.KeyCode==Keys.Enter&&fetch==true))
			{
				fetch=false;
				MouseUpFunction();				
				keyBoard.KeyBoardOperating=false;				
				string str="已放下旗子    ";
				str+=this.label3.Text.ToString();
				this.label3.Text=str;
			}
			if((e.KeyCode==Keys.Up)||(e.KeyCode==Keys.W))
			{
				Point CurrentPoint=new Point(Cursor.Position.X,Cursor.Position.Y-48);
				Point objectPoint=keyBoard.Find_Up_Point(this.a,CurrentPoint);
				Cursor.Position=new Point(objectPoint.X,objectPoint.Y+48);
			    if(fetch)
					this.MouseMoveFunction();
			}
			if((e.KeyCode==Keys.Down)||(e.KeyCode==Keys.S))
			{
				Point CurrentPoint=new Point(Cursor.Position.X,Cursor.Position.Y-48);
				Point objectPoint=keyBoard.Find_Down_Point(this.a,CurrentPoint);
				Cursor.Position=new Point(objectPoint.X,objectPoint.Y+48);
				if(fetch)
					this.MouseMoveFunction();
			}
			
			if((e.KeyCode==Keys.Left)||(e.KeyCode==Keys.A))
			{
				Point CurrentPoint=new Point(Cursor.Position.X,Cursor.Position.Y-48);				
				Point objectPoint=keyBoard.Find_Left_Point(this.a,CurrentPoint);						
				Cursor.Position=new Point(objectPoint.X,objectPoint.Y+48); 				
				if(fetch)
					this.MouseMoveFunction();
			}
			if((e.KeyCode==Keys.Right)||(e.KeyCode==Keys.D))
			{
				Point CurrentPoint=new Point(Cursor.Position.X,Cursor.Position.Y-48);				
				Point objectPoint=keyBoard.Find_Right_Point(this.a,CurrentPoint);			
				Cursor.Position=new Point(objectPoint.X,objectPoint.Y+48);				
				if(fetch)
					this.MouseMoveFunction();				
			}
		}
		#endregion


		#region 游戏 设置断点/恢复断点 代码
		
		public bool[] pictureBoxsStatus=new bool[32];
		public Point[] pictureBoxsLocation=new Point[32];
		public bool beforeSaved=false;
		public bool maySave=false;
		public void SavePictureBoxsStatus()
		{			
			for(int i=0;i<32;i++)
			{
				this.pictureBoxsStatus[i]=false;  //初始化

				this.pictureBoxsStatus[i]=this.pictureBoxs[i].Visible;				
			}
			for(int i=0;i<32;i++)
			{
				this.pictureBoxsLocation[i]=new Point(this.pictureBoxs[i].Left,this.pictureBoxs[i].Top);
			}
		}
		public void RestorePictureBoxStatus()
		{
			for(int i=0;i<32;i++)
				this.pictureBoxs[i].Visible=this.pictureBoxsStatus[i];
			for(int i=0;i<32;i++)
				this.pictureBoxs[i].Location=new Point(this.pictureBoxsLocation[i].X,this.pictureBoxsLocation[i].Y);
		}
		private void menuItem9_Click(object sender, System.EventArgs e)  //读取断点
		{			
			if(beforeSaved==false)
			{
				MessageBox.Show("没有设置断点,不能恢复断点!!!");
				return;
			}
			this.fileOperate.Read(ref Form2.form2);			
			this.RestorePictureBoxStatus();			
			this.ReFresh();			
			if(this.signRight==0&&this.whichFangQianZou)
				this.label3.Text="蓝方走旗";
			else
			{
				if(this.signRight==1&&this.whichFangQianZou)
					this.label3.Text="红方走旗";
				else this.label3.Text="请一方走旗";
			}
		}

		private void menuItem8_Click(object sender, System.EventArgs e)   //设置断点
		{		
			if(maySave==false)			
			{
				MessageBox.Show("游戏开始后,才可以设置断点!!!");
				return;					
			}
			this.SavePictureBoxsStatus();			
			fileOperate.Save(Form2.form2);//保存代码
			beforeSaved=true;
		}
		#endregion	
		
	}
}

