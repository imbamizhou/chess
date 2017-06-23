using System;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;

namespace 智能象棋游戏
{
	/// ///****该类主要对悔旗(退旗)操作	  
	public class RegretMoveFlag
	{
        public const int Length = 500;
		public int[] fromIndex=new int[Length];         //记录走一步旗时,动的是哪个图片控件(pictureBox)
		public int[]   toIndex=new int[Length];         //记录走一步旗时,动的是哪个图片控件(pictureBox)		
        
		public Point[] fromPoint=new Point[Length];
		public Point[]   toPoint=new Point[Length];

		public int[] fromPointIndex=new int[Length];  //******
		public int[] toPointIndex=new int[Length];
		
		public string[] label3_Text=new string[Length]; //存放每一步旗的说明文字       			
		public int[] signRight=new int[Length];         //保存哪方走旗标志
		public bool[] start=new bool[Length];           //变量作用:使第一次走旗时,无条件执行,因此当恳旗到第一步之前时,要恢复标志位      
		public string[] wrongString=new string[Length]; //记录排斥标志,当mouse_down事件不执行时,不能执行mouse_up事件						
		public bool[] whichFangQianZou=new bool[Length];//变量作用:因为一开始哪方先走旗是玩者来决定;因此需要这个变量实现其功能;当退旗到第一步之前时,要恢复标志位    
		
		public FlagMoveRule[] b=new FlagMoveRule[Length];	
		public int activeIndex;                            //起流动指针作用
		public int tailIndex;                              //始终指向尾部(刚走完的最后一步旗)的索引

        public bool IsReplayAndNoAddItem = false;
		
		public void ReFresh(FlagMoveRule a)
		{			
		}
		public RegretMoveFlag()
		{	
			this.Initialize();
		}
		public void Initialize()
		{
			//初始化各数组
			for(int i=0;i<Length;i++)
			{
				fromIndex[i]=-1;	  toIndex[i]=-1;
				fromPoint[i].X=-1;	  fromPoint[i].Y=-1;
				toPoint[i].X=-1;	  toPoint[i].Y=-1;
				fromPointIndex[i]=-1; toPointIndex[i]=-1;
			}		
			for(int i=0;i<Length;i++)
			{
				this.label3_Text[i]="";
				this.signRight[i]=0;
				this.start[i]=false;
				this.wrongString[i]="right";
				this.whichFangQianZou[i]=false;
				this.b[i]=new FlagMoveRule();
				this.b[i].Initialize();
			}				
			//初始化索引
			activeIndex=-1;
			tailIndex=-1;
		}
		public void Initialize(int i)
		{
			//初始化一个数组
			fromIndex[i]=-1;	  toIndex[i]=-1;
			fromPoint[i].X=-1;	  fromPoint[i].Y=-1;
			toPoint[i].X=-1;	  toPoint[i].Y=-1;
			fromPointIndex[i]=-1; toPointIndex[i]=-1;
					
			this.label3_Text[i]="";
			this.signRight[i]=0;
			this.start[i]=false;
			this.wrongString[i]="right";
			this.whichFangQianZou[i]=false;			
			this.b[i].Initialize();		
		}
		public void SubLastItem()
		{
            if (IsReplayAndNoAddItem)
            {
                return;
            }

			if(this.activeIndex<this.tailIndex-1)
			{
				for(int i=this.activeIndex+1;i<=this.tailIndex;i++)
					this.Initialize(i);				
				return;
			}			
			this.Initialize(this.tailIndex);

			this.tailIndex--;
			this.activeIndex=this.tailIndex;
		}
		
		public void SaveNewItem(int fromIndex,int toIndex,Point fromPoint,Point toPoint,string label3_Text,int signRight,bool start,string wrongString,bool whichFangQianZou,FlagMoveRule b)
		{
            if (IsReplayAndNoAddItem)
            {
                return;
            }

			if(this.activeIndex>this.tailIndex)
			{
				this.activeIndex=this.tailIndex;				
			}  		
			this.activeIndex++;			

			if(this.activeIndex==Length)
			{
				MessageBox.Show("悔旗类空间不够,应扩大空间");
				return;
			}   
			this.fromIndex[this.activeIndex]=fromIndex;
			this.toIndex[this.activeIndex]=toIndex;
			this.fromPoint[this.activeIndex]=fromPoint;
			
			this.toPoint[this.activeIndex]=toPoint;
			
			this.label3_Text[this.activeIndex]=label3_Text;
			this.signRight[this.activeIndex]=signRight;
			this.start[this.activeIndex]=start;
			this.wrongString[this.activeIndex]=wrongString;
			this.whichFangQianZou[this.activeIndex]=whichFangQianZou;			
			
			FlagMoveRule tempFlagMoveRule=new FlagMoveRule();
			tempFlagMoveRule.Initialize();
			
			for(int i=0;i<90;i++)
			{
				tempFlagMoveRule.have[i]=b.have[i];
				tempFlagMoveRule.who[i]=b.who[i];
				tempFlagMoveRule.str[i]=b.str[i];
				tempFlagMoveRule.allPoint[i]=b.allPoint[i];
				if(i<32)
					tempFlagMoveRule.partPoint[i]=b.partPoint[i];
				tempFlagMoveRule.whichPicture[i]=b.whichPicture[i];
			}
			tempFlagMoveRule.rednum=b.rednum;
			tempFlagMoveRule.bluenum=b.bluenum;
			tempFlagMoveRule.index=b.index;
			tempFlagMoveRule.first_X=b.first_X;
			tempFlagMoveRule.first_Y=b.first_Y;
			tempFlagMoveRule.height=b.height;
			tempFlagMoveRule.width=b.width;		
			
			this.b[this.activeIndex]=tempFlagMoveRule;			

			this.tailIndex=this.activeIndex;		
		}
		public int FallBack(ref int fromIndex,ref int toIndex,ref Point fromPoint,ref Point toPoint,ref string label3_Text,ref int signRight,ref bool start,ref string wrongString,ref bool whichFangQianZou,ref FlagMoveRule b)
		{					
			if(this.activeIndex<0)
				return 0;
			if(this.activeIndex>=this.tailIndex)
				this.activeIndex=this.tailIndex-1;
			if(this.activeIndex<=-1)                   //*******************防止一开始就点后退
				return 0;
			
			fromIndex=this.fromIndex[this.activeIndex];
			toIndex=this.toIndex[this.activeIndex];			
			fromPoint=this.fromPoint[this.activeIndex];
			toPoint=this.toPoint[this.activeIndex];
			label3_Text=this.label3_Text[this.activeIndex];
			signRight=this.signRight[this.activeIndex];
			start=this.start[this.activeIndex];
			wrongString=this.wrongString[this.activeIndex];
			whichFangQianZou=this.whichFangQianZou[this.activeIndex];
						
			b.Initialize();
			
			b.Initialize(this.b[this.activeIndex]);			

			this.activeIndex--; 	

			return 1;
		}
		public int GoAhead(ref int fromIndex,ref int toIndex,ref Point fromPoint,ref Point toPoint,ref string label3_Text,ref int signRight,ref bool start,ref string wrongString,ref bool whichFangQianZou,ref FlagMoveRule b)
		{			
			if(this.activeIndex>=this.tailIndex-1)
				return 0;            //只能前进到最后一步旗
			this.activeIndex++;	
			if(this.activeIndex<0)
				this.activeIndex=0;

			fromIndex=this.fromIndex[this.activeIndex];
			toIndex=this.toIndex[this.activeIndex];
			fromPoint=this.fromPoint[this.activeIndex];
			toPoint=this.toPoint[this.activeIndex];
			label3_Text=this.label3_Text[this.activeIndex+1];
			signRight=this.signRight[this.activeIndex+1];
			start=this.start[this.activeIndex+1];
			wrongString=this.wrongString[this.activeIndex+1];
			whichFangQianZou=this.whichFangQianZou[this.activeIndex+1];
			
			b.Initialize();
				
			b.Initialize(this.b[this.activeIndex+1]);  

			return 1;
		}        
	}
}
