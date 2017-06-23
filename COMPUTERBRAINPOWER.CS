using System;
using System.Drawing;
using System.Collections;
using System.Windows.Forms;

namespace 智能象棋游戏
{
	/// <summary>
	/// 功能:实现电脑自动分析走旗
    /// </summary>
	public class ComputerBrainpower
	{
		FlagMoveRule b;
		FlagMoveRule c;
		JudgeWhichOneWiner jiangJun;
		
		public ComputerBrainpower()
		{
			b=new FlagMoveRule();
			c=new FlagMoveRule();
			this.jiangJun=new JudgeWhichOneWiner();
		}	
		
		public void ComputerAuto(FlagMoveRule a,JudgeWhichOneWiner jiangJun,ref Point fromPoint,ref Point toPoint)
		{			
			
			b.Initialize(a);
			this.jiangJun.Inialize(jiangJun);  			
			
			//防守
			Point shuaiPoint=new Point(-1,-1);
			shuaiPoint=b.CountPoint(b.GetIndexByPictureIndex(4));			
			
			if(this.jiangJun.ShuaiSymmetryJiang())   //如果将对帅,则直接吃掉将
			{
				Point jiangPoint=new Point(-1,-1);
				jiangPoint=b.CountPoint(b.GetIndexByPictureIndex(27));
				fromPoint=shuaiPoint; toPoint=jiangPoint;
				
				
				return;
			}

			//吃将
			for(int i=89;i>=0;i--)
			{
				for(int j=89;j>=0;j--)
					if(b.who[i]=="red"&&b.AcceptJudge(b.allPoint[i],b.allPoint[j],false)&&b.whichPicture[b.CountIndex(b.allPoint[j])]==27)
					{
						fromPoint=b.allPoint[i]; toPoint=b.allPoint[j];
						this.jiangJun.Inialize(jiangJun);
						this.jiangJun.JiangJun(b.allPoint[i],b.allPoint[j],b);
						if(fromPoint!=toPoint&&this.jiangJun.blueToRed==false)
						{
							Console.WriteLine("777777");
							return;
						}
					}
			}			
			
			b.Initialize(a);
			this.jiangJun.Inialize(jiangJun);   
			
			Point[] footShuaiPoint=new Point[5];
			int footShuaiIndex=0;
			Point[] sideShuaiPoint=new Point[20];           
			for(int i=0;i<90;i++)
				if(b.who[i]=="blue"&&b.AcceptJudge(b.allPoint[i],shuaiPoint,false))
				{
					footShuaiPoint[footShuaiIndex++]=b.allPoint[i];
				}
			if(footShuaiIndex==1)	  //红帅被将军,寻找有没有直接吃掉将帅的旗子的旗子
				for(int i=0;i<90;i++)
					if(b.who[i]=="red"&&b.AcceptJudge(b.allPoint[i],footShuaiPoint[0],false))
					{
						fromPoint=b.allPoint[i]; toPoint=footShuaiPoint[0];
						this.jiangJun.Inialize(jiangJun);
						this.jiangJun.JiangJun(b.allPoint[i],footShuaiPoint[0],b);
						if(fromPoint!=toPoint&&this.jiangJun.blueToRed==false)
						{
							Console.WriteLine("111111");
							return;
						}
					}
          			
			b.Initialize(a);
			this.jiangJun.Inialize(jiangJun);   
			
			if(footShuaiIndex>=1)            //走自己非帅旗子,解除将军
			{				
				for(int i=0;i<90;i++)
					for(int j=0;j<90;j++)
					{
						if(b.who[i]=="red"&&b.AcceptJudge(b.allPoint[i],b.allPoint[j],false))
						{							
							this.jiangJun.Inialize(jiangJun);
							this.jiangJun.JiangJun(b.allPoint[i],b.allPoint[j],b);							
							if(this.jiangJun.blueToRed==false)
							{
								fromPoint=b.allPoint[i];  toPoint=b.allPoint[j];								
								if(fromPoint!=toPoint)
								{									
									Console.WriteLine("333333");
									return;
								}
							}
						}
					}
			}
			
			b.Initialize(a);
			this.jiangJun.Inialize(jiangJun);   

			Random random=new Random();
			int num=random.Next(100);
			if(num%2==1)
			{			
				if(footShuaiIndex>=1)
					for(int i=0;i<30;i++)
					{
						this.jiangJun.Inialize(jiangJun);
						if(b.str[i]=="红士")
							for(int j=0;j<30;j++)
							{
								if(b.AcceptJudge(b.allPoint[i],b.allPoint[j],false))
								{
									this.jiangJun.JiangJun(b.allPoint[i],b.allPoint[j],b);
									if(this.jiangJun.blueToRed==false)
									{
										fromPoint=b.allPoint[i]; toPoint=b.allPoint[j];
										Console.WriteLine("444444");
										if(fromPoint!=toPoint)
											return;
									}
								}
							}
					}
			}
			else
			{
				if(footShuaiIndex>=1)
					for(int i=30;i>=0;i--)
					{
						this.jiangJun.Inialize(jiangJun);
						if(b.str[i]=="红士")
							for(int j=0;j<30;j++)
							{
								if(b.AcceptJudge(b.allPoint[i],b.allPoint[j],false))
								{
									this.jiangJun.JiangJun(b.allPoint[i],b.allPoint[j],b);
									if(this.jiangJun.blueToRed==false)
									{
										fromPoint=b.allPoint[i]; toPoint=b.allPoint[j];
										Console.WriteLine("55555");
										if(fromPoint!=toPoint)
											return;
									}
								}
							}
					}
			}
			
			b.Initialize(a);
			this.jiangJun.Inialize(jiangJun);   

			if(footShuaiIndex>=1)    //"帅" 自己解除将军
			{
				for(int i=0;i<90;i++)
				{				
					this.jiangJun.Inialize(jiangJun);
					this.jiangJun.JiangJun(shuaiPoint,b.allPoint[i],b);
					if(this.jiangJun.blueToRed==false&&b.AcceptJudge(shuaiPoint,b.allPoint[i],false)&&b.who[b.CountIndex(b.allPoint[i])]!="red")
					{
						fromPoint=shuaiPoint;  toPoint=b.allPoint[i];
						this.jiangJun.Inialize(jiangJun);
						this.jiangJun.JiangJun(shuaiPoint,b.allPoint[i],b);
						if(fromPoint!=toPoint&&this.jiangJun.blueToRed==false)
						{
							Console.WriteLine("666666");
							return;
						}
					}

				}
			}			
			
			b.Initialize(a);
			this.jiangJun.Inialize(jiangJun);   

			if(footShuaiIndex>=1)
				for(int i=0;i<50;i++)
					if(b.AcceptJudge(shuaiPoint,b.allPoint[i],false))
					{
						fromPoint=shuaiPoint;  toPoint=b.allPoint[i];
						Console.WriteLine("ccccc");
						if(fromPoint!=toPoint)
							return;
					}
					

			//进攻	
			
			/*吃将
			for(int i=89;i>=0;i--)
			{
				for(int j=89;j>=0;j--)
					if(b.who[i]=="red"&&b.AcceptJudge(b.allPoint[i],b.allPoint[j],false)&&b.whichPicture[b.CountIndex(b.allPoint[j])]==27)
					{
						fromPoint=b.allPoint[i]; toPoint=b.allPoint[j];
						this.jiangJun.Inialize(jiangJun);
						this.jiangJun.JiangJun(b.allPoint[i],b.allPoint[j],b);
						if(fromPoint!=toPoint&&this.jiangJun.blueToRed==false)
						{
							Console.WriteLine("777777");
							return;
						}
					}
			}*/			
			
			b.Initialize(a);
			this.jiangJun.Inialize(jiangJun);   
			
			//有没有可吃的旗子
			for(int i=0;i<90;i++)
			{
				for(int j=0;j<90;j++)
				{
					if(b.who[i]=="red"&&b.who[j]=="blue"&&b.AcceptJudge(b.allPoint[i],b.allPoint[j],false))
					{
						bool may=true;						
						for(int k=0;k<90;k++)
						{
							if(b.who[k]=="blue"&&b.AcceptJudge(b.allPoint[k],b.allPoint[j],false)&&b.CountIndex(b.allPoint[i])<60&&b.allPoint[j].X!=308)
								may=false;							
						}
                       // if (may)
						if(may && b.who[i] != b.who[j] )  //避免误杀自己的旗子
						{
							fromPoint=b.allPoint[i]; toPoint=b.allPoint[j];
							this.jiangJun.Inialize(jiangJun);
							this.jiangJun.JiangJun(b.allPoint[i],b.allPoint[j],b);
							if(this.jiangJun.blueToRed==false)
							{								
								Console.WriteLine("888888");
								if(fromPoint!=toPoint)
									return;
							}
						}
					}
				}
			}

			b.Initialize(a);
			this.jiangJun.Inialize(jiangJun);   			
			
			//避开一方旗子	
			bool mayGo=true;
			int index=-1,myIndex=-1;
			bool run=true;
			for(int i=89;i>=0;i--)
				for(int j=89;j>=0;j--)
				{
					if(b.who[i]=="blue"&&b.who[j]=="red"&&b.AcceptJudge(b.allPoint[i],b.allPoint[j],false)&&run)
					{
						index=i;  myIndex=j;    //i位置的蓝旗子将要吃j位置的红旗子
						run=false;
					}
				} 
            
			b.Initialize(a);
			this.jiangJun.Inialize(jiangJun);   
			
			if(index!=-1)                       //杀死正踩红旗头的旗子
				for(int i=89;i>=0;i--)
				{
					if(b.who[i]=="red"&&b.AcceptJudge(b.allPoint[i],b.allPoint[index],false))
					{						
						fromPoint=b.allPoint[i]; toPoint=b.allPoint[index];
						this.jiangJun.Inialize(jiangJun);
						this.jiangJun.JiangJun(b.allPoint[i],b.allPoint[index],b);
						if(fromPoint!=toPoint&&this.jiangJun.blueToRed==false)
						{
							Console.WriteLine("999999");						
							return;						
						}
					}						
				}
			
			b.Initialize(a);
			this.jiangJun.Inialize(jiangJun);   

			if(myIndex!=-1)                    //保护被蓝旗子踩头的旗子
				for(int k=0;k<90;k++)
				{
					for(int m=0;m<90;m++)
						if(b.who[k]=="red"&&b.AcceptJudge(b.allPoint[k],b.allPoint[m],false) && b.str[k] + string.Empty != string.Empty)
						{							
							b.Initialize(a);
							b.ChangeQiZi(b.allPoint[k],b.allPoint[m]);
                            b.str[m] = b.str[k];
                            try
                            {
                                if ((b.have[m] == false || b.who[m] != "red") && b.AcceptJudge(b.allPoint[m], b.allPoint[myIndex], false)) //防止误杀自己旗子(2006/10)
                                {
                                    fromPoint = b.allPoint[k]; toPoint = b.allPoint[m];
                                    b.Initialize(a);
                                    this.jiangJun.Inialize(jiangJun);
                                    this.jiangJun.JiangJun(b.allPoint[k], b.allPoint[m], b);
                                    if (fromPoint != toPoint && this.jiangJun.blueToRed == false)
                                    {
                                        Console.WriteLine("10 10 10 10");
                                        return;
                                    }
                                }
                            }
                            catch
                            {
                                continue;
                            }
						}
				}
			
			
			
			b.Initialize(a);
			this.jiangJun.Inialize(jiangJun);   

			//逃跑
			if(myIndex!=-1)               
				for(int i=0;i<90;i++)
					for(int j=0;j<90;j++)
					{
                        if (b.who[i] == "blue" && b.who[j] == "red" && b.AcceptJudge(b.allPoint[i], b.allPoint[j], false))
                        {

                            ////自己旗子虽然被对方踩在脚下，但有自己其它的 "战友" "保卫", 则有些时候不必逃跑
                            //bool blnIsProtected = false;
                            //for (int x = 0; x < 90; x++)
                            //{
                            //    if (b.who[x] == "red" && b.who[j] == "red" && b.AcceptJudge(b.allPoint[x], b.allPoint[j], false))
                            //    {
                            //        if (b.allPoint[x] != b.allPoint[j])
                            //        {
                            //            blnIsProtected = true;
                            //        }
                            //    }
                            //}
                            //if (blnIsProtected)
                            //{
                            //    continue;
                            //}


                            for (int k = 0; k < 90; k++)
                            {
                                this.b.Initialize(a);
                                if (b.AcceptJudge(b.allPoint[j], b.allPoint[k], false))
                                {
                                    bool bb = true;
                                    for (int x = 0; x < 90; x++)
                                    {
                                        if (b.who[x] == "red" && b.AcceptJudge(b.allPoint[x], b.allPoint[j], false))
                                            bb = false;
                                    }
                                    b.ChangeQiZi(b.allPoint[j], b.allPoint[k]);
                                    for (int m = 0; m < 90; m++)
                                    {
                                        if (b.who[m] == "blue" && b.AcceptJudge(b.allPoint[m], b.allPoint[k], false))
                                            bb = false;
                                    }
                                    this.b.Initialize(a);
                                    this.jiangJun.Inialize(jiangJun);
                                    this.jiangJun.JiangJun(b.allPoint[j], b.allPoint[k], b);
                                    //this.jiangJun(b);
                                    if (bb && this.jiangJun.blueToRed == false)
                                    {
                                        fromPoint = b.allPoint[j]; toPoint = b.allPoint[k];
                                        if (b.str[b.CountIndex(fromPoint)] == "红卒" && b.CountIndex(fromPoint) == 31)
                                            continue;
                                        Console.WriteLine("11 11 11");
                                        if (fromPoint != toPoint)
                                            return;
                                    }
                                }

                            }
                        }
					}
				
			
			
			b.Initialize(a);
			this.jiangJun.Inialize(jiangJun);   
			
			//招数走旗
			for(int i=89;i>=0;i--)
				for(int j=89;j>=0;j--)
				{					
					b.Initialize(a);
					if(b.who[i]=="red"&&b.AcceptJudge(b.allPoint[i],b.allPoint[j],false))
					{						
						Point p=b.CountPoint(27);
						b.ChangeQiZi(b.allPoint[i],b.allPoint[j]);
						if(b.who[j]=="red"&&b.AcceptJudge(b.allPoint[j],p,false))
						{
							this.jiangJun.Inialize(jiangJun);
							this.jiangJun.JiangJun(b.allPoint[i],b.allPoint[j],a);
							if(this.jiangJun.blueToRed==false)
							{
								fromPoint=b.allPoint[i]; toPoint=b.allPoint[j];
								Console.WriteLine("aaaaaaaa");
								if(fromPoint!=toPoint)
									return;
							}
						}
						for(int k=89;k>=0;k--)
							if(b.who[j]=="red"&&b.AcceptJudge(b.allPoint[j],b.allPoint[k],false))
							{								
								b.ChangeQiZi(b.allPoint[j],b.allPoint[k]);
								if(b.who[k]=="red"&&b.AcceptJudge(b.allPoint[k],p,false))
								{
									this.jiangJun.Inialize(jiangJun);
									this.jiangJun.JiangJun(b.allPoint[i],b.allPoint[j],a);
									if(this.jiangJun.blueToRed==false && b.str[i] != b.str[j])
									{
										fromPoint=b.allPoint[i]; toPoint=b.allPoint[j];
										Console.WriteLine("bbbbbbbbbb");
										if(fromPoint!=toPoint)
											return;
									}
								}
							}
					}
				}
			b.Initialize(a);
				
			
			
			
			b.Initialize(a);
			this.jiangJun.Inialize(jiangJun);   

			//一般走旗
			
			Random rand=new Random();
			int data=rand.Next(100);
			int data1=rand.Next(100);
			int data2=Math.Abs(data-data1);
			if(data2%2==1)
			{
				for(int i=89;i>=0;i--)
				{
					for(int j=89;j>=0;j--)
					{
						if(b.who[i]=="red"&&b.AcceptJudge(b.allPoint[i],b.allPoint[j],false)&&b.allPoint[j].Y>=b.allPoint[i].Y-50)
						{
							mayGo=true;
							for(int k=0;k<90;k++)
							{
								if(b.who[k]=="blue"&&b.AcceptJudge(b.allPoint[k],b.allPoint[j],false))
									mayGo=false;
							}
							if(mayGo)
							{
								fromPoint=b.allPoint[i]; toPoint=b.allPoint[j];
								this.jiangJun.Inialize(jiangJun);
								this.jiangJun.JiangJun(b.allPoint[i],b.allPoint[j],b);
								if(fromPoint!=toPoint&&this.jiangJun.blueToRed==false)
								{
									
									if(b.str[b.CountIndex(fromPoint)]=="红卒"&&b.CountIndex(fromPoint)==31)
										continue;
									Console.WriteLine("12 12 12");
									return;
								}
							}
						}
					}
				}
			}
			else
			{
				for(int i=0;i<90;i++)
				{
					for(int j=89;j>=0;j--)
					{
						if(b.who[i]=="red"&&b.AcceptJudge(b.allPoint[i],b.allPoint[j],false)&&b.allPoint[j].Y>=b.allPoint[i].Y-50)
						{
							mayGo=true;
							for(int k=0;k<90;k++)
							{
								if(b.who[k]=="blue"&&b.AcceptJudge(b.allPoint[k],b.allPoint[j],false))
									mayGo=false;
							}
							if(mayGo)
							{
								fromPoint=b.allPoint[i]; toPoint=b.allPoint[j];
								this.jiangJun.Inialize(jiangJun);
								this.jiangJun.JiangJun(b.allPoint[i],b.allPoint[j],b);
								if(fromPoint!=toPoint&&this.jiangJun.blueToRed==false)
								{
									
									if(b.str[b.CountIndex(fromPoint)]=="红卒"&&b.CountIndex(fromPoint)==31)
										continue;
									Console.WriteLine("13 13 13");
									return;
								}
							}
						}
					}
				}
			}			
			
			b.Initialize(a);
			this.jiangJun.Inialize(jiangJun);   
			
						
			//随机走一个旗子
			for(int i=0;i<90;i++)
			{
				for(int j=89;j>=0;j--)
				{
					if(b.who[i]=="red"&&b.AcceptJudge(b.allPoint[i],b.allPoint[j],false))
					{
						fromPoint=b.allPoint[i]; toPoint=b.allPoint[j];	
						Console.WriteLine("14 14 14");
						if(fromPoint!=toPoint)
							return;
					}
				}
			}
			
		}
		
	}
}
