using System;
//using System.Drawing;
using System.Collections;
using System.ComponentModel;
//using System.Windows.Forms;
//using System.Data;
using System.Runtime.InteropServices;

namespace 智能象棋游戏
{
	/// <summary>
	/// 用于播放音乐
	/// </summary>	
	internal class Helpers 
	{
		[Flags]
		public enum PlaySoundFlags : int 
		{
			SND_SYNC = 0x0000,  /* play synchronously (default) */ //同步
			SND_ASYNC = 0x0001,  /* play asynchronously */ //异步
			SND_NODEFAULT = 0x0002,  /* silence (!default) if sound not found */
			SND_MEMORY = 0x0004,  /* pszSound points to a memory file */
			SND_LOOP = 0x0008,  /* loop the sound until next sndPlaySound */
			SND_NOSTOP = 0x0010,  /* don't stop any currently playing sound */
			SND_NOWAIT = 0x00002000, /* don't wait if the driver is busy */
			SND_ALIAS = 0x00010000, /* name is a registry alias */
			SND_ALIAS_ID = 0x00110000, /* alias is a predefined ID */
			SND_FILENAME = 0x00020000, /* name is file name */
			SND_RESOURCE = 0x00040004  /* name is resource name or atom */
		}

		[DllImport("winmm")]
		public static extern bool PlaySound( string szSound, IntPtr hMod, PlaySoundFlags flags );
	}

	public class Sound 
	{
		public static void Play( string strFileName )
		{
			//Helpers.PlaySound( strFileName, IntPtr.Zero, Helpers.PlaySoundFlags.SND_FILENAME | Helpers.PlaySoundFlags.SND_ASYNC );
			switch(strFileName)
			{
				case "start": strFileName=@"..\..\sound\start.WAV";       break;
				case "back": strFileName=@"..\..\sound\back.WAV";         break;
				case "fall": strFileName=@"..\..\sound\fall.WAV";         break;				
				case "huiqi": strFileName=@"..\..\sound\huiqi.WAV";       break;
                case "huiqiend": strFileName=@"..\..\sound\huiqiend.WAV"; break;
				case "jiangjun": strFileName=@"..\..\sound\jiangjun.WAV"; break;
				case "kill": strFileName=@"..\..\sound\kill.WAV";         break;
				case "win": strFileName=@"..\..\sound\win.WAV";           break;
				case "move": strFileName=@"..\..\sound\move.WAV";         break;
                case "hold": strFileName=@"..\..\sound\hold.WAV";         break;
				case "no": strFileName=@"..\..\sound\no.WAV";             break;
				case "popup": strFileName=@"..\..\sound\popup.WAV";       break;
                case "mayfall": strFileName=@"..\..\sound\mayfall.WAV";   break;	
				case "return_red": strFileName=@"..\..\sound\return_red.WAV";  break;
				case "return_blue": strFileName=@"..\..\sound\return_blue.WAV";break;
			}
			Helpers.PlaySound(strFileName, IntPtr.Zero, Helpers.PlaySoundFlags.SND_FILENAME | Helpers.PlaySoundFlags.SND_ASYNC);			
		}
	}		
}
