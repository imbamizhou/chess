using System;
using System.IO;
using System.Drawing;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace 智能象棋游戏
{
	/// <summary>
	/// 功能:实现 游戏 设置断点,读取断点 功能 
	/// </summary>
	public class SaveGameStatus
	{		
		public string openFileName="..\\..\\save\\SAVA.bin";   //存储文件名
		public string saveFileName="..\\..\\save\\SAVA.bin";   //存储文件名	
		
		public SaveGameStatus()
		{
				
		}
		
		public void Save(Form2 form2)
		{ 
			//******序列化Form2中的数组和变量和类*******//
			IFormatter formatter=new BinaryFormatter();			
			Stream stream=new FileStream(this.saveFileName,FileMode.Create,FileAccess.Write,FileShare.None);			
			
			//序列化Form2 中pictureBoxStatus数组
			formatter.Serialize(stream,form2.pictureBoxsStatus);

			
			formatter.Serialize(stream,form2.battle);
			formatter.Serialize(stream,form2.soldiers);
			formatter.Serialize(stream,form2.tempPoint);
			formatter.Serialize(stream,form2.whetherSelected);
			formatter.Serialize(stream,form2.letDown);
			formatter.Serialize(stream,form2.signRight);
			formatter.Serialize(stream,form2.start);
			formatter.Serialize(stream,form2.wrongString);
			formatter.Serialize(stream,form2.startTime);
			formatter.Serialize(stream,form2.displaystartTime);
			formatter.Serialize(stream,form2.pause);
			formatter.Serialize(stream,form2.whichFangQianZou);
			formatter.Serialize(stream,form2.pauseCount);
			formatter.Serialize(stream,form2.label3_ShanShuo);
			formatter.Serialize(stream,form2.add_Or_Not);
			formatter.Serialize(stream,form2.shanShuoVarialbe);
			formatter.Serialize(stream,form2.whoGoString);

			
			//序列化Form2中类FlagMoveRule a中的变量和数组;
			formatter.Serialize(stream,form2.a.GenEatGen);	formatter.Serialize(stream,form2.a.have);	formatter.Serialize(stream,form2.a.who);	formatter.Serialize(stream,form2.a.str);	formatter.Serialize(stream,form2.a.allPoint);	formatter.Serialize(stream,form2.a.partPoint);	formatter.Serialize(stream,form2.a.whichPicture);	formatter.Serialize(stream,form2.a.rednum);	formatter.Serialize(stream,form2.a.bluenum);	formatter.Serialize(stream,form2.a.width);	formatter.Serialize(stream,form2.a.height);	formatter.Serialize(stream,form2.a.first_X);	formatter.Serialize(stream,form2.a.first_Y);	formatter.Serialize(stream,form2.a.blueNumTotal);	formatter.Serialize(stream,form2.a.redNumTotal);
			
			//序列化Form2中RegretMoveFlag huiQi中的变量/数组和类实例数组
			formatter.Serialize(stream,form2.huiQi.fromIndex);	formatter.Serialize(stream,form2.huiQi.toIndex);	formatter.Serialize(stream,form2.huiQi.fromPoint);	formatter.Serialize(stream,form2.huiQi.toPoint);	formatter.Serialize(stream,form2.huiQi.fromPointIndex);	formatter.Serialize(stream,form2.huiQi.toPointIndex);	formatter.Serialize(stream,form2.huiQi.label3_Text);	formatter.Serialize(stream,form2.huiQi.signRight);	formatter.Serialize(stream,form2.huiQi.start);	formatter.Serialize(stream,form2.huiQi.wrongString);	formatter.Serialize(stream,form2.huiQi.whichFangQianZou);formatter.Serialize(stream,form2.huiQi.activeIndex);formatter.Serialize(stream,form2.huiQi.tailIndex);			
			for(int i=0;i<=form2.huiQi.tailIndex;i++)
			{
				formatter.Serialize(stream,form2.huiQi.b[i].GenEatGen);
				formatter.Serialize(stream,form2.huiQi.b[i].have);
				formatter.Serialize(stream,form2.huiQi.b[i].who);
				formatter.Serialize(stream,form2.huiQi.b[i].str);
				formatter.Serialize(stream,form2.huiQi.b[i].allPoint);
				formatter.Serialize(stream,form2.huiQi.b[i].partPoint);
				formatter.Serialize(stream,form2.huiQi.b[i].whichPicture);
				formatter.Serialize(stream,form2.huiQi.b[i].rednum);
				formatter.Serialize(stream,form2.huiQi.b[i].bluenum);
				formatter.Serialize(stream,form2.huiQi.b[i].width);
				formatter.Serialize(stream,form2.huiQi.b[i].height);
				formatter.Serialize(stream,form2.huiQi.b[i].first_X);
				formatter.Serialize(stream,form2.huiQi.b[i].first_Y);
				formatter.Serialize(stream,form2.huiQi.b[i].redNumTotal);
				formatter.Serialize(stream,form2.huiQi.b[i].blueNumTotal);
			}			
			
			//序列化Form2中类JudgeWhichOneWiner jiangJun中的变量/数组/类实例
	        formatter.Serialize(stream,form2.jiangJun.blueToRed);formatter.Serialize(stream,form2.jiangJun.redToBlue);
			formatter.Serialize(stream,form2.jiangJun.shanShuo);formatter.Serialize(stream,form2.jiangJun.GenEatGen);		
			//序列化Form2中类JudgeWhichOneWiner jiangJun中FlagMoveRule b的变量/数组
			formatter.Serialize(stream,form2.jiangJun.b.GenEatGen);	formatter.Serialize(stream,form2.jiangJun.b.have);	formatter.Serialize(stream,form2.jiangJun.b.who);	formatter.Serialize(stream,form2.jiangJun.b.str);	formatter.Serialize(stream,form2.jiangJun.b.allPoint);	formatter.Serialize(stream,form2.jiangJun.b.partPoint);	formatter.Serialize(stream,form2.jiangJun.b.whichPicture);	formatter.Serialize(stream,form2.jiangJun.b.rednum);	formatter.Serialize(stream,form2.jiangJun.b.bluenum);	formatter.Serialize(stream,form2.jiangJun.b.width);	formatter.Serialize(stream,form2.jiangJun.b.height);formatter.Serialize(stream,form2.jiangJun.b.first_X);	formatter.Serialize(stream,form2.jiangJun.b.first_Y);	formatter.Serialize(stream,form2.jiangJun.b.redNumTotal);	formatter.Serialize(stream,form2.jiangJun.b.blueNumTotal);
			
           
			//序列化Form2中类KeyboardOperaterFunction keyBoard中的变量 		
			formatter.Serialize(stream,form2.keyBoard.KeyBoardOperating);
			formatter.Serialize(stream,form2.keyBoard.MouseOperating);			
			
			
			stream.Close();
		}

		public void Read(ref Form2 form2)
		{
			IFormatter formatter=new BinaryFormatter();
			Stream stream=new FileStream(this.openFileName,FileMode.Open,FileAccess.Read,FileShare.Read);
			
			//Form2 a=new Form2();
			Form2 a=form2;
			
			//反序列化Form2 中pictureBoxStatus数组
			a.pictureBoxsStatus=(bool[])formatter.Deserialize(stream);
			
			a.battle=(string)formatter.Deserialize(stream);	
			a.soldiers=(string[])formatter.Deserialize(stream);
			a.tempPoint=(Point[])formatter.Deserialize(stream);
			a.whetherSelected=(bool)formatter.Deserialize(stream);
			a.letDown=(bool)formatter.Deserialize(stream);
			a.signRight=(int)formatter.Deserialize(stream);
			a.start=(bool)formatter.Deserialize(stream);
            a.wrongString=(string)formatter.Deserialize(stream);
			a.startTime=(DateTime)formatter.Deserialize(stream);
			a.displaystartTime=(bool)formatter.Deserialize(stream);
			a.pause=(bool)formatter.Deserialize(stream);
			a.whichFangQianZou=(bool)formatter.Deserialize(stream);
			a.pauseCount=(int)formatter.Deserialize(stream);
			a.label3_ShanShuo=(bool)formatter.Deserialize(stream);
			a.add_Or_Not=(bool)formatter.Deserialize(stream);
			a.shanShuoVarialbe=(int)formatter.Deserialize(stream);		
			a.whoGoString=(string)formatter.Deserialize(stream);
			
			//反序列化Form2中FlagMoveRule a中的变量和数组
			a.a.GenEatGen=(bool)formatter.Deserialize(stream);  a.a.have=(bool[])formatter.Deserialize(stream);	a.a.who=(string[])formatter.Deserialize(stream);	a.a.str=(string[])formatter.Deserialize(stream);	a.a.allPoint=(Point[])formatter.Deserialize(stream);	a.a.partPoint=(Point[])formatter.Deserialize(stream);	a.a.whichPicture=(int[])formatter.Deserialize(stream);	a.a.rednum=(int)formatter.Deserialize(stream);	a.a.bluenum=(int)formatter.Deserialize(stream);	a.a.width=(int)formatter.Deserialize(stream);	a.a.height=(int)formatter.Deserialize(stream);	a.a.first_X=(int)formatter.Deserialize(stream);	a.a.first_Y=(int)formatter.Deserialize(stream);	a.a.blueNumTotal=(int)formatter.Deserialize(stream);a.a.redNumTotal=(int)formatter.Deserialize(stream);

            //反序列化Form2中RegretMoveFlag huiQi中的变量/数组和类实例数组
			a.huiQi.fromIndex=(int[])formatter.Deserialize(stream);	a.huiQi.toIndex=(int[])formatter.Deserialize(stream);	a.huiQi.fromPoint=(Point[])formatter.Deserialize(stream);	a.huiQi.toPoint=(Point[])formatter.Deserialize(stream);	a.huiQi.fromPointIndex=(int[])formatter.Deserialize(stream);	a.huiQi.toPointIndex=(int[])formatter.Deserialize(stream);	a.huiQi.label3_Text=(string[])formatter.Deserialize(stream);	a.huiQi.signRight=(int[])formatter.Deserialize(stream);	a.huiQi.start=(bool[])formatter.Deserialize(stream);	a.huiQi.wrongString=(string[])formatter.Deserialize(stream);a.huiQi.whichFangQianZou=(bool[])formatter.Deserialize(stream);a.huiQi.activeIndex=(int)formatter.Deserialize(stream);	a.huiQi.tailIndex=(int)formatter.Deserialize(stream);
			for(int i=0;i<=form2.huiQi.tailIndex;i++)
			{
				a.huiQi.b[i].GenEatGen=(bool)formatter.Deserialize(stream);
				a.huiQi.b[i].have=(bool[])formatter.Deserialize(stream);
				a.huiQi.b[i].who=(string[])formatter.Deserialize(stream);
				a.huiQi.b[i].str=(string[])formatter.Deserialize(stream);
				a.huiQi.b[i].allPoint=(Point[])formatter.Deserialize(stream);
				a.huiQi.b[i].partPoint=(Point[])formatter.Deserialize(stream);
				a.huiQi.b[i].whichPicture=(int[])formatter.Deserialize(stream);
				a.huiQi.b[i].rednum=(int)formatter.Deserialize(stream);
				a.huiQi.b[i].bluenum=(int)formatter.Deserialize(stream);
				a.huiQi.b[i].width=(int)formatter.Deserialize(stream);
				a.huiQi.b[i].height=(int)formatter.Deserialize(stream);
				a.huiQi.b[i].first_X=(int)formatter.Deserialize(stream);
				a.huiQi.b[i].first_Y=(int)formatter.Deserialize(stream);
				a.huiQi.b[i].redNumTotal=(int)formatter.Deserialize(stream);
				a.huiQi.b[i].blueNumTotal=(int)formatter.Deserialize(stream);
			}			
			//反序列化Form2中类JudgeWhichOneWiner jiangJun中的变量/数组/类实例
            a.jiangJun.blueToRed=(bool)formatter.Deserialize(stream);a.jiangJun.redToBlue=(bool)formatter.Deserialize(stream);	
			a.jiangJun.shanShuo=(bool)formatter.Deserialize(stream);a.jiangJun.GenEatGen=(bool)formatter.Deserialize(stream);		
			//反序列化Form2中类JudgeWhichOneWiner jiangJun中FlagMoveRule b的变量/数组
			a.jiangJun.b.GenEatGen=(bool)formatter.Deserialize(stream);	a.jiangJun.b.have=(bool[])formatter.Deserialize(stream);a.jiangJun.b.who=(string[])formatter.Deserialize(stream);	a.jiangJun.b.str=(string[])formatter.Deserialize(stream);	a.jiangJun.b.allPoint=(Point[])formatter.Deserialize(stream);	a.jiangJun.b.partPoint=(Point[])formatter.Deserialize(stream);	a.jiangJun.b.whichPicture=(int[])formatter.Deserialize(stream);	a.jiangJun.b.rednum=(int)formatter.Deserialize(stream);	a.jiangJun.b.bluenum=(int)formatter.Deserialize(stream);	a.jiangJun.b.width=(int)formatter.Deserialize(stream);	a.jiangJun.b.height=(int)formatter.Deserialize(stream);	a.jiangJun.b.first_X=(int)formatter.Deserialize(stream);a.jiangJun.b.first_Y=(int)formatter.Deserialize(stream);a.jiangJun.b.redNumTotal=(int)formatter.Deserialize(stream);a.jiangJun.b.blueNumTotal=(int)formatter.Deserialize(stream);			
			
			//反序列化Form2中类KeyboardOperaterFunction keyBoard中的变量 
			a.keyBoard.KeyBoardOperating=(bool)formatter.Deserialize(stream);
			a.keyBoard.MouseOperating=(bool)formatter.Deserialize(stream);				
	        	
			stream.Close();
		}		
	}
}
