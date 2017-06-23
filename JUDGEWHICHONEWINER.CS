using System;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;

namespace 智能象棋游戏
{
	/// <summary>
	/// 功能:1.走完一步旗后,判断是否将军
	///      2.走完一步判断是否一方胜利	
	/// </summary>
	public class JudgeWhichOneWiner
	{
		//红帅:4号图片  蓝将:27号图片
		public FlagMoveRule b=new FlagMoveRule();  //接受 a 的值,进行判断
        public bool blueToRed=false;   //表示蓝方将军红方
		public bool redToBlue=false;   //表示红方将军蓝方
		public bool shanShuo=false;    //标志是否显示将军文字
		public bool GenEatGen=false;
		public JudgeWhichOneWiner()
		{
			b.Initialize();
		}
		public void AcceptValue(FlagMoveRule a)
		{
			b.Initialize(a);
		}		
		public void Inialize(JudgeWhichOneWiner a)
		{
			this.b.Initialize(a.b);
			this.blueToRed=a.blueToRed;
			this.redToBlue=a.redToBlue;
			this.shanShuo=a.shanShuo;
			this.GenEatGen=a.GenEatGen;
		}
		public bool ShuaiSymmetryJiang()
		{
			if(this.WinGame(b)!=0)
				return false;
			
			Point shuai=new Point(-1,-1);
			Point jiang=new Point(-1,-1);			
			shuai=b.CountPoint(b.GetIndexByPictureIndex(4));
			jiang=b.CountPoint(b.GetIndexByPictureIndex(27));			
			Point tempPoint=new Point(-1,-1);
			int count=0;
			
			for(tempPoint=b.GetNextPoint(shuai,1,0);tempPoint.X!=-1&&tempPoint!=jiang;)
			{
				if(b.have[b.CountIndex(tempPoint)]==true)
					count++;
				tempPoint=b.GetNextPoint(tempPoint,1,0);
			}			
			if(count==0&&tempPoint==jiang)
				return true;
            return false;		
	    }
		public void ChangeParameter()
		{
			int index;
			Point p;
				
			//检查红帅是否被将军
			index=b.GetIndexByPictureIndex(4);  //红帅为第四章图片
			if(index==-1) return;
			p=b.CountPoint(index);    //找到存有第四章图片的点
			
			this.blueToRed=false;
			this.redToBlue=false;
			this.shanShuo=false;
			this.GenEatGen=false;
			for(int i=0;i<90;i++)
			{
				if(b.have[i]&&b.who[i]=="blue"&&b.AcceptJudge(b.allPoint[i],p,false))
				{
					blueToRed=true;					
					shanShuo=true;					
				}
			}
			//检查蓝将是否被将军
			index=b.GetIndexByPictureIndex(27);  //红帅为第27章图片
			if(index==-1) return;
			p=b.CountPoint(index);    //找到存有第27章图片的点
			for(int i=0;i<90;i++)
			{
				if(b.have[i]&&b.who[i]=="red"&&b.AcceptJudge(b.allPoint[i],p,false))
				{
					redToBlue=true;					
					shanShuo=true;					
				}
			}
			if(ShuaiSymmetryJiang())//如果帅将隔河相望,则也算是将军
			{
				shanShuo=true;
				GenEatGen=true;
			}
		}
		public void JiangJun(Point fromPoint,Point toPoint,FlagMoveRule a)
		{			
			b.Initialize();
			this.AcceptValue(a);			
			b.ChangeQiZi(fromPoint,toPoint);			
			this.ChangeParameter();            
		}
		public void JiangJun(FlagMoveRule a)
		{
			b.Initialize();
			this.AcceptValue(a);
			this.ChangeParameter();
		}
		public int WinGame(FlagMoveRule a)
		{		
			int index=-1;			
			index=a.GetIndexByPictureIndex(4);
			if(index==-1)
				return 1;       //表示蓝方胜
			
			index=-1;
			
			index=a.GetIndexByPictureIndex(27);
			if(index==-1)
				return 2;           //表示红方胜

			if(a.rednum==0)    
			{
				this.shanShuo=false;
				return 1;     //蓝方胜
			}
			if(a.bluenum==0)
			{
				this.shanShuo=false;
				return 2;     //红方胜
			}
			
			return 0;
		}
	}
}
