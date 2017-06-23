using System;
using System.Drawing;
using System.Windows.Forms;

namespace 智能象棋游戏
{
	
	//*****自定义类*****
	//*****记录旗盘位置特点类,各个旗子的走法*****	

	public class FlagMoveRule:智能象棋游戏.FlagContainer
	{
		public bool GenEatGen=false;
		public FlagMoveRule()
		{
			this.rednum=0;
			this.bluenum=0;
		}
		public FlagMoveRule(string[] soldiers,Point[] allPoint,Point[] partPoint,int width,int height): base(soldiers,allPoint,partPoint,width,height)
		{ 
		}		
		//*****为旗子判断步伐时候:为了提高执行效率,只判断旗子可以走的情况:
		//*****   1.自己周围的规则点是不是在旗盘上; 2.如果周围的规则点在旗盘上,则该点是否是自己的旗子,如果是,则不允许走
		public bool HorseFoot(Point fromPoint,Point toPoint) //判断***马***的走法是否合理
		{
			int fromIndex=this.CountIndex(fromPoint);   //求标志起点信息的一维数组的索引
			int toIndex=this.CountIndex(toPoint);       //求标志终点信息的一维数组的索引
			if(fromPoint==toPoint)  //如果起点和终点是同一个点,则允许放回旗子,重新选其它路
			{				
				return true;
			}
			
			if(who[fromIndex].Equals(who[toIndex]))  //如果起点和终点是同一边的旗子,则不能走
			{				
				return false;			
			}
			double twoPoint_Right_Distance=Math.Sqrt((this.width*this.width)+(width+width)*(width+width));
			double twoPoint_True_Distance=Math.Sqrt((fromPoint.X-toPoint.X)*(fromPoint.X-toPoint.X)+(fromPoint.Y-toPoint.Y)*(fromPoint.Y-toPoint.Y));
			if(this.GetNextPoint(fromPoint,-2,1)==toPoint||this.GetNextPoint(fromPoint,-2,-1)==toPoint)  //当马向上跳时有两种跳法(左上日和右上日)
				if(this.have[this.CountIndex(this.GetNextPoint(fromPoint,-1,0))]==false)   //起点上面没有旗子,也就是不 "挡马腿" 时可以往上走旗
				{					
					if(twoPoint_True_Distance<=twoPoint_Right_Distance)
						return true;
				}
			if(this.GetNextPoint(fromPoint,2,1)==toPoint||this.GetNextPoint(fromPoint,2,-1)==toPoint)   //同上,只是变为向下跳马的情况
				if(this.have[this.CountIndex(this.GetNextPoint(fromPoint,1,0))]==false)
				{					
					if(twoPoint_True_Distance<=twoPoint_Right_Distance)
						return true;					
				}
			if(this.GetNextPoint(fromPoint,1,2)==toPoint||this.GetNextPoint(fromPoint,-1,2)==toPoint)   //同上,只是变为向右跳马的情况
				if(this.have[this.CountIndex(this.GetNextPoint(fromPoint,0,1))]==false)
				{					
					if(twoPoint_True_Distance<=twoPoint_Right_Distance+5)
						return true;
				}
			if(this.GetNextPoint(fromPoint,-1,-2)==toPoint||this.GetNextPoint(fromPoint,1,-2)==toPoint) //同上,只是变为向左跳马的情况
				if(this.have[this.CountIndex(this.GetNextPoint(fromPoint,0,-1))]==false)
				{					
					if(twoPoint_True_Distance<=twoPoint_Right_Distance+5)
						return true;			
				}
			
			return false;		      //除去以上几种情况,其余终点都不能落旗			
		}
		public bool ObiitFoot(Point fromPoint,Point toPoint)//判断***兵/卒***的走法是否合理
		{			
			int fromIndex=this.CountIndex(fromPoint);   //求标志起点信息的一维数组的索引
			int toIndex=this.CountIndex(toPoint);       //求标志终点信息的一维数组的索引
			string isUpOrDownFromPoint=this.IsUpOrDown(fromPoint); //起点是在旗盘上方,还是下方("兵/帅" 在旗子上方和下方走法不一样) 
			string isUpOrDownToPoint=this.IsUpOrDown(toPoint);     //终点是在旗盘上方,还是下方("兵/帅" 在旗子上方和下方走法不一样)
			
			if(fromPoint==toPoint)  //如果起点和终点是同一个点,则允许放回旗子,重新先其它路
			{				
				return true;
			}
			
			if(who[fromIndex].Equals(who[toIndex]))  //如果起点和终点是同一边的旗子,则不能走
			{				
				return false;			
			}

			if(who[fromIndex].Equals("blue"))  //假如起始点是蓝兵
			{	
				if(isUpOrDownFromPoint=="down"&&isUpOrDownToPoint=="down"||isUpOrDownFromPoint=="down"&&isUpOrDownToPoint=="up")//起点和终点都在下面或起点在下面终点在上面时情况
				{					
					if(this.GetNextPoint(fromPoint,-1,0)==toPoint)  //如果终点是起点的上面一个点,则返回真
					{						
						return true;
					}
				}
				else
				{
					if(isUpOrDownFromPoint=="up"&&isUpOrDownToPoint=="up")//如果起点和终点都在上面时的情况
					{
						if(this.GetNextPoint(fromPoint,-1,0)==toPoint) //过河后可以往上走
							return true;
			     		if(this.GetNextPoint(fromPoint,0,1)==toPoint)  //过河后可以往右走
							return true;
						if(this.GetNextPoint(fromPoint,0,-1)==toPoint) //过河后可以往左走
							return true;
					}
				}				
			}
			if(who[fromIndex].Equals("red"))
			{				
				if(isUpOrDownFromPoint=="up"&&isUpOrDownToPoint=="up"||isUpOrDownFromPoint=="up"&&isUpOrDownToPoint=="down")
				{					
					if(this.GetNextPoint(fromPoint,1,0)==toPoint)
					{						
						return true;
					}
				}
				else
					if(isUpOrDownFromPoint=="down"&&isUpOrDownToPoint=="down")
				    {
					   if(this.GetNextPoint(fromPoint,1,0)==toPoint)   //过河后可以往下走
					    	return true;
					   if(this.GetNextPoint(fromPoint,0,1)==toPoint)   //过河后可以往右走
					     	return true;
					   if(this.GetNextPoint(fromPoint,0,-1)==toPoint)  //过河后可以往左走
					    	return true;
				    }				
			}			
			
			return false;			
		}
		public bool JuFoot(Point fromPoint,Point toPoint)     //判断***車***的走法是否合理
		{
			int fromIndex=this.CountIndex(fromPoint);   //求标志起点信息的一维数组的索引
			int toIndex=this.CountIndex(toPoint);       //求标志终点信息的一维数组的索引			
					
			if(fromPoint==toPoint)  //如果起点和终点是同一个点,则允许放回旗子,重新先其它路
			{				
				return true;
			}			
			if(who[fromIndex].Equals(who[toIndex]))  //如果起点和终点是同一边的旗子,则不能走
			{				
				return false;			
			}
			if(fromPoint.X==toPoint.X)   //判断是否在同一条垂直直线上
			{				
				if(fromPoint.Y>toPoint.Y) //起点在终点下面情况
                    for(int i=-1;this.GetNextPoint(fromPoint,i,0)!=toPoint;i--)  //判断起点终点之间有无旗子
						if(this.have[this.CountIndex(this.GetNextPoint(fromPoint,i,0))]==true)
							return false;					
				
				if(fromPoint.Y<toPoint.Y)//起点在终点上面情况
					for(int i=1;this.GetNextPoint(fromPoint,i,0)!=toPoint;i++)  //判断起点终点之间有无旗子
						if(this.have[this.CountIndex(this.GetNextPoint(fromPoint,i,0))]==true)
							return false;	
				return true;					
			}
			if(fromPoint.Y==toPoint.Y)  //判断是否在同一条水平直线上
			{				
				if(fromPoint.X<toPoint.X)  //起点在终点左边
					for(int j=1;this.GetNextPoint(fromPoint,0,j)!=toPoint;j++)  //判断起点终点之间有无旗子
						if(this.have[this.CountIndex(this.GetNextPoint(fromPoint,0,j))]==true)
							return false;										
				
				if(fromPoint.X>toPoint.X)  //起点在终点右边
					for(int j=-1;this.GetNextPoint(fromPoint,0,j)!=toPoint;j--)  //判断起点终点之间有无旗子
						if(this.have[this.CountIndex(this.GetNextPoint(fromPoint,0,j))]==true)
							return false;	
				return true;
			}			
			
			return false;			
		}
		public bool CannonFoot(Point fromPoint,Point toPoint) //判断***炮***的走法是否合理
		{
			int fromIndex=this.CountIndex(fromPoint);   //求标志起点信息的一维数组的索引
			int toIndex=this.CountIndex(toPoint);       //求标志终点信息的一维数组的索引			
					
			if(fromPoint==toPoint)  //如果起点和终点是同一个点,则允许放回旗子,重新先其它路
			{				
				return true;
			}			
			if(who[fromIndex].Equals(who[toIndex]))  //如果起点和终点是同一边的旗子,则不能落旗
			{				
				return false;			
			}
			if(fromPoint.X==toPoint.X)    //判断起点和终点在同一垂直线上情况
			{
				int number_QiZi=0;
				if(fromPoint.Y>toPoint.Y) //起点在终点下面情况
				{
					for(int i=-1;this.GetNextPoint(fromPoint,i,0)!=toPoint;i--)  //判断起点终点之间旗子数量
						if(this.have[this.CountIndex(this.GetNextPoint(fromPoint,i,0))]==true)
							number_QiZi++;
					if(number_QiZi>1)          //如果起点和终点之间的旗子数大于1,则不能落旗
						return false;
					if(number_QiZi==0&&this.have[this.CountIndex(toPoint)]==false)  //起点和终点之间无旗子,且终点也无旗子,则可以在终点落旗
						return true;
					if(number_QiZi==1&&this.have[this.CountIndex(toPoint)]==true)  //起点和终点之间仅有一个旗而且终点有旗子(这里终点有旗子肯定是对方的旗子,如果终点是自己的旗子,则程序执行到本方法第二个 if 语句就返回 false 了)
						return true;
				}

				number_QiZi=0;
				if(fromPoint.Y<toPoint.Y) //起点在终点下面情况
				{
					for(int i=1;this.GetNextPoint(fromPoint,i,0)!=toPoint;i++)  //判断起点终点之间旗子数量
						if(this.have[this.CountIndex(this.GetNextPoint(fromPoint,i,0))]==true)
							number_QiZi++;
					if(number_QiZi>1)          //如果起点和终点之间的旗子数大于1,则不能落旗
						return false;
					if(number_QiZi==0&&this.have[this.CountIndex(toPoint)]==false)       //起点和终点之间无旗子,且终点也无旗子,可以在终点落旗
						return true;
					if(number_QiZi==1&&this.have[this.CountIndex(toPoint)]==true)  //起点和终点之间仅有一个旗而且终点有旗子(这里终点有旗子肯定是对方的旗子,如果终点是自己的旗子,则程序执行到本方法第二个 if 语句就返回 false 了)
						return true;				
				}
			}
			if(fromPoint.Y==toPoint.Y)
			{
				int number_QiZi=0;
				if(fromPoint.X>toPoint.X) //起点在终点右边情况
				{
					for(int j=-1;this.GetNextPoint(fromPoint,0,j)!=toPoint;j--)  //判断起点终点之间旗子数量
						if(this.have[this.CountIndex(this.GetNextPoint(fromPoint,0,j))]==true)
							number_QiZi++;
					if(number_QiZi>1)          //如果起点和终点之间的旗子数大于1,则不能落旗
						return false;
					if(number_QiZi==0&&this.have[this.CountIndex(toPoint)]==false)  //起点和终点之间无旗子,且终点也无旗子,则可以在终点落旗
						return true;
					if(number_QiZi==1&&this.have[this.CountIndex(toPoint)]==true)  //起点和终点之间仅有一个旗而且终点有旗子(这里终点有旗子肯定是对方的旗子,如果终点是自己的旗子,则程序执行到本方法第二个 if 语句就返回 false 了)
						return true;
				}

				number_QiZi=0;
				if(fromPoint.X<toPoint.X) //起点在终点左边情况
				{
					for(int j=1;this.GetNextPoint(fromPoint,0,j)!=toPoint;j++)  //判断起点终点之间旗子数量
						if(this.have[this.CountIndex(this.GetNextPoint(fromPoint,0,j))]==true)
							number_QiZi++;
					if(number_QiZi>1)          //如果起点和终点之间的旗子数大于1,则不能落旗
						return false;
					if(number_QiZi==0&&this.have[this.CountIndex(toPoint)]==false)       //起点和终点之间无旗子,且终点也无旗子,可以在终点落旗
						return true;
					if(number_QiZi==1&&this.have[this.CountIndex(toPoint)]==true)  //起点和终点之间仅有一个旗而且终点有旗子(这里终点有旗子肯定是对方的旗子,如果终点是自己的旗子,则程序执行到本方法第二个 if 语句就返回 false 了)
						return true;				
				}
			}				
			return false;			
		}
		public bool ElephantFoot(Point fromPoint,Point toPoint)//判断***象***的走法是否合理
		{
			int fromIndex=this.CountIndex(fromPoint);   //求标志起点信息的一维数组的索引
			int toIndex=this.CountIndex(toPoint);       //求标志终点信息的一维数组的索引			
					
			if(fromPoint==toPoint)  //如果起点和终点是同一个点,则允许放回旗子,重新先其它路
			{				
				return true;
			}			
			if(who[fromIndex].Equals(who[toIndex]))  //如果起点和终点是同一边的旗子,则不能落旗
			{				
				return false;			
			}
			if(this.IsUpOrDown(fromPoint)!=this.IsUpOrDown(toPoint))  //如果起点和终点所在边不相同(如一个在河上,一个在河下),则不能落旗(即各边的象不能过河)
				return false;
			
			double twoPoint_Right_Distance=Math.Sqrt((width+width)*(width+width)+(width+width)*(width+width));
			double twoPoint_True_Distance=Math.Sqrt((fromPoint.X-toPoint.X)*(fromPoint.X-toPoint.X)+(fromPoint.Y-toPoint.Y)*(fromPoint.Y-toPoint.Y));
			
			//判断象的四种走法
			if(this.GetNextPoint(fromPoint,2,2)==toPoint)  //当象向右下方跳时情况("右下田")
				if(this.have[this.CountIndex(this.GetNextPoint(fromPoint,1,1))]==false)   //起点右下一个点上没有旗子,也就是不 "挡象腿" 时可以往上走旗
				{					
					if(twoPoint_True_Distance<=twoPoint_Right_Distance)
						return true;
				}
			if(this.GetNextPoint(fromPoint,2,-2)==toPoint)  //当象向左下方跳时情况("左下田")
				if(this.have[this.CountIndex(this.GetNextPoint(fromPoint,1,-1))]==false)   //起点左下一个点上没有旗子,也就是不 "挡象腿" 时可以往上走旗
				{					
					if(twoPoint_True_Distance<=twoPoint_Right_Distance)
						return true;
				}
			if(this.GetNextPoint(fromPoint,-2,2)==toPoint)  //当象向右上方跳时情况("右上田")
				if(this.have[this.CountIndex(this.GetNextPoint(fromPoint,-1,1))]==false)   //起点右上一个点上没有旗子,也就是不 "挡象腿" 时可以往上走旗
				{					
					if(twoPoint_True_Distance<=twoPoint_Right_Distance)
						return true;
				}
			if(this.GetNextPoint(fromPoint,-2,-2)==toPoint)  //当象向左上方跳时情况("左上田")
				if(this.have[this.CountIndex(this.GetNextPoint(fromPoint,-1,-1))]==false)   //起点左上一个点上没有旗子,也就是不 "挡象腿" 时可以往上走旗
				{					
					if(twoPoint_True_Distance<=twoPoint_Right_Distance)
						return true;
				}		
			
			return false;			
		}
		public bool ScholarFoot(Point fromPoint,Point toPoint) //判断***士***的走法是否合理
		{  
			int fromIndex=this.CountIndex(fromPoint);   //求标志起点信息的一维数组的索引
			int toIndex=this.CountIndex(toPoint);       //求标志终点信息的一维数组的索引			
					
			if(fromPoint==toPoint)  //如果起点和终点是同一个点,则允许放回旗子,重新先其它路
			{				
				return true;
			}			
			if(who[fromIndex].Equals(who[toIndex]))  //如果起点和终点是同一边的旗子,则不能落旗
			{				
				return false;			
			}
			if(this.IsUpOrDown(fromPoint)!=this.IsUpOrDown(toPoint))  //如果起点和终点所在边不相同(如一个在河上,一个在河下),则不能落旗(即各边的象不能过河)
				return false;

			int index=this.CountIndex(toPoint);
			if(index!=3&&index!=5&&index!=13&&index!=21&&index!=23&&index!=66)
				if(index!=68&&index!=76&&index!=84&&index!=86)
					return false;      //控制士的活动范围

			//判断士的四种走法
			if(this.GetNextPoint(fromPoint,-1,-1)==toPoint)  //士可以往左上方一点跳
				return true;		
			if(this.GetNextPoint(fromPoint,1,-1)==toPoint)   //士可以往左下方一点跳
				return true;	
			if(this.GetNextPoint(fromPoint,-1,+1)==toPoint)  //士可以往右上方一点跳
				return true;	
			if(this.GetNextPoint(fromPoint,1,1)==toPoint)  //士可以往右下方一点跳
				return true;
	
			return false;			
		}
		public bool AgaFoot(Point fromPoint,Point toPoint)//判断***将/帅***的走法是否合理
		{
			int fromIndex=this.CountIndex(fromPoint);   //求标志起点信息的一维数组的索引
			int toIndex=this.CountIndex(toPoint);       //求标志终点信息的一维数组的索引			
					
			if(GenEatGen)  //如果是将与帅相望(之间没有旗子),而且又走的是 将吃帅/帅吃将 这时老将允许直接跳河吃掉对方老将
				if((this.whichPicture[fromIndex]==4&&this.whichPicture[toIndex]==27)||(this.whichPicture[fromIndex]==27&&this.whichPicture[toIndex]==4))
					return true;			
			
			if(fromPoint==toPoint)  //如果起点和终点是同一个点,则允许放回旗子,重新先其它路
			{				
				return true;
			}			
			if(who[fromIndex].Equals(who[toIndex]))  //如果起点和终点是同一边的旗子,则不能落旗
			{				
				return false;			
			}
			if(this.IsUpOrDown(fromPoint)!=this.IsUpOrDown(toPoint))  //如果起点和终点所在边不相同(如一个在河上,一个在河下),则不能落旗(即各边的象不能过河)
				return false;			

			int index=this.CountIndex(toPoint);
			if(index!=3&&index!=4&&index!=5&&index!=12&&index!=13&&index!=14&&index!=21&&index!=22&&index!=23)
                if(index!=66&&index!=67&&index!=68&&index!=75&&index!=76&&index!=77&&index!=84&&index!=85&&index!=86)
					return false;        //控制将帅的活动范围
			
			//判断 将/帅 的四种走法
			if(this.GetNextPoint(fromPoint,0,-1)==toPoint)  //将/帅可以往左方一点走
				return true;		
			if(this.GetNextPoint(fromPoint,0,1)==toPoint)   //将/帅可以往右方一点走
				return true;	
			if(this.GetNextPoint(fromPoint,-1,0)==toPoint)  //将/帅可以往上方一点走
				return true;	
			if(this.GetNextPoint(fromPoint,1,0)==toPoint)    //将/帅可以往下方一点走
				return true;			
			
			return false;			
		}
		public bool AcceptJudge(Point fromPoint,Point toPoint,bool GenEatGen)
		{			
			if(!IsAvailablePoint(toPoint))
				return false;
			
			this.GenEatGen=GenEatGen;
			int index=this.CountIndex(fromPoint);			
			switch(this.str[index])
			{
				case "蓝马":
                case "红马":  return HorseFoot(fromPoint,toPoint); 
                case "蓝兵":
                case "红卒":  return ObiitFoot(fromPoint,toPoint);
				case "蓝車":
				case "红車":  return JuFoot(fromPoint,toPoint);
				case "蓝炮":
				case "红炮":  return CannonFoot(fromPoint,toPoint);
				case "蓝象":
				case "红象":  return ElephantFoot(fromPoint,toPoint);
				case "蓝士":
				case "红士":  return ScholarFoot(fromPoint,toPoint);
				case "蓝将":
				case "红帅":  return AgaFoot(fromPoint,toPoint);                
			}			
			//MessageBox.Show("没法确定您拿的是什么旗子,因此,不知道其步伐规则");            
			return false;
		}
		public bool IsAvailablePoint(Point point)
		{  
			//假如不是旗盘上的有效点,则返回假
			int i;
			for(i=0;i<90;i++)
				if(this.allPoint[i].X==point.X&&this.allPoint[i].Y==point.Y)
					break;
			if(i==90)
				return false;
			return true;
		}
		public Point GetNextPoint(Point point,int x,int y)   //例如: x取 -1,y取 +1,表示往上移一行,再往右移一点,就是所求的点
		{
			int index=this.CountIndex(point);						
			index=index+(x*9);
			index=index+y;			
			if(index>=0&&index<90)
				return this.CountPoint(index);
			return new Point(-1,-1);
		}
		public int ChangeQiZi(Point fromPoint,Point toPoint) 
			  // index表示当前活动的pictureBox;  
			  // fromPoint表示pictureBox起点;  toPoint表示鼠标弹起时pictureBox的位置点
		{
			int fromIndex=this.CountIndex(fromPoint);  //求得起点对应一维数组的索引
			int toIndex=this.CountIndex(toPoint);      //求得终点对应一维数组的索引           

			if(fromPoint==toPoint)
			{					
				return 0;		//起点和终点是同一个点,不修改旗盘参数				
			}			
			if(!this.have[toIndex])
			{				
				//将旗盘起点对应的参数移到第二个点
				this.have[toIndex]=this.have[fromIndex];
				this.who[toIndex]=this.who[fromIndex].ToString();
				this.str[toIndex]=this.str[fromIndex].ToString();
				this.whichPicture[toIndex]=this.whichPicture[fromIndex];
                				
				//将旗盘起点对应的参数初始化s(即将旗子移动之前位置置为空点)
				this.have[fromIndex]=false;
				this.who[fromIndex]="";
				this.str[fromIndex]="";
				this.whichPicture[fromIndex]=-1;		
            
				return 1;
			}
			if(this.have[toIndex])
			{			
				//红方旗子被吃一个
				if(this.who[toIndex]=="red")  
					rednum--;           

				//蓝方旗子被吃一个
				if(this.who[toIndex]=="blue")
					bluenum--;

				//将旗盘起点对应的参数移到第二个点
				this.have[toIndex]=this.have[fromIndex];
				this.who[toIndex]=this.who[fromIndex].ToString();
				this.str[toIndex]=this.str[fromIndex].ToString();
				this.whichPicture[toIndex]=this.whichPicture[fromIndex];
                				
				//将旗盘起点对应的参数初始化s(即将旗子移动之前位置置为空点)
				this.have[fromIndex]=false;
				this.who[fromIndex]="";
				this.str[fromIndex]="";
				this.whichPicture[fromIndex]=-1;			
				
				return 2;               
			}
			return -1;		    
		}
		public bool JudgeQiZi(Point fromPoint,Point toPoint) 
			// index表示当前活动的pictureBox;  
			// fromPoint表示pictureBox起点;  toPoint表示鼠标弹起时pictureBox的位置点
		{
			int fromIndex=this.CountIndex(fromPoint);  //求得起点对应一维数组的索引
			int toIndex=this.CountIndex(toPoint);      //求得终点对应一维数组的索引
			if(fromPoint==toPoint)
			{					
				return false;		//起点和终点是同一个点			
			}			
			if(!this.have[toIndex])
			{			
				return true;
			}
			if(this.have[toIndex])
			{							
				return true;               
			}
			return false;		    
		}
	}
}
