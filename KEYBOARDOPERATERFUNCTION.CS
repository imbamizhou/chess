using System;
using System.Drawing;
using System.Collections;

namespace 智能象棋游戏
{
	/// <summary>
	/// 作用:1.增加键盘支持功能   2.使鼠标和键盘操作互斥	
	/// </summary>
	public class KeyboardOperaterFunction
	{
		public bool KeyBoardOperating=false;
		public bool MouseOperating=false;		
		public KeyboardOperaterFunction()
		{
			this.KeyBoardOperating=false;
			this.MouseOperating=false;			
		}
		public Point Find_Up_Point(FlagMoveRule a,Point currentPoint)
		{			
			Point p1=a.GetNearPoint(currentPoint.X,currentPoint.Y);
			Point p2=a.GetNextPoint(p1,-1,0);
			if(p2.X!=-1)
				return p2;
			return a.GetNextPoint(p1,9,0);
		}
		public Point Find_Down_Point(FlagMoveRule a,Point currentPoint)
		{			
			Point p1=a.GetNearPoint(currentPoint.X,currentPoint.Y);
			Point p2=a.GetNextPoint(p1,1,0);
			if(p2.X!=-1)
				return p2;
			return a.GetNextPoint(p1,-9,0);
		}
		public Point Find_Left_Point(FlagMoveRule a,Point currentPoint)
		{			
			Point p1=a.GetNearPoint(currentPoint.X,currentPoint.Y);
			Point p2=a.GetNextPoint(p1,0,-1);
			if(p2.X!=-1)
				return p2;
			else
			{
				p2=a.GetNextPoint(p1,0,8);				
				return p2;				
			}			
		}
		public Point Find_Right_Point(FlagMoveRule a,Point currentPoint)
		{			
			Point p1=a.GetNearPoint(currentPoint.X,currentPoint.Y);
			Point p2=a.GetNextPoint(p1,0,1);
			if(p2.X!=-1)
				return p2;
			else
			{				
				return a.GetNextPoint(p1,0,-8);
			}
		}   
	}
}
