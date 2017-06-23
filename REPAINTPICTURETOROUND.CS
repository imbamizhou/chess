using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;


namespace 智能象棋游戏
{
	/// <summary>
	/// 功能:将所有picturebox控件变为圆形
	/// </summary>

	public class RepaintPictureToRound
	{
		[System.Runtime.InteropServices.DllImport("gdi32")]
		private static extern IntPtr BeginPath(IntPtr hdc);
		[System.Runtime.InteropServices.DllImport("gdi32")]
		private static extern int SetBkMode(IntPtr hdc,int nBkMode);		
		const int TRANSPARENT=1;
		[System.Runtime.InteropServices.DllImport("gdi32")]					
		private static extern IntPtr EndPath(IntPtr hdc);
		[System.Runtime.InteropServices.DllImport("gdi32")]
		private static extern IntPtr PathToRegion(IntPtr hdc);
		[System.Runtime.InteropServices.DllImport("gdi32")]
		private static extern int Ellipse(IntPtr hdc,int x1,int y1,int x2,int y2);
		[System.Runtime.InteropServices.DllImport("user32")]
		private static extern IntPtr SetWindowRgn(IntPtr hwnd,IntPtr hRgn,bool bRedraw);
		[System.Runtime.InteropServices.DllImport("user32")]
		private static extern IntPtr GetDC(IntPtr hwnd);
		public RepaintPictureToRound()
		{			
		}
		public void MakeToPictureBoxsToCircle(PictureBox[] pb)
		{
			IntPtr dc;
			IntPtr region;
			for(int i=0;i<pb.Length;i++)
			{
				dc=GetDC(pb[i].Handle);
				BeginPath(dc);
				SetBkMode(dc,TRANSPARENT);
				Ellipse(dc,0,0,pb[i].Width-3,pb[i].Height-2);
				EndPath(dc);
				region=PathToRegion(dc);
				SetWindowRgn(pb[i].Handle,region,false);
			}			
		}
	}
}
