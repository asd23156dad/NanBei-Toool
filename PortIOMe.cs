using System;
using System.IO.Ports;
using System.Threading;

namespace iReverse_Qualcomm_Tool_Lite
{
	// Token: 0x02000008 RID: 8
	internal static class PortIOMe
	{
		// Token: 0x17000004 RID: 4
		// (get) Token: 0x06000044 RID: 68 RVA: 0x00009BD4 File Offset: 0x00007DD4
		// (set) Token: 0x06000045 RID: 69 RVA: 0x00009BDB File Offset: 0x00007DDB
		public static int PortCOM { get; set; }

		// Token: 0x17000005 RID: 5
		// (get) Token: 0x06000046 RID: 70 RVA: 0x00009BE3 File Offset: 0x00007DE3
		// (set) Token: 0x06000047 RID: 71 RVA: 0x00009BEA File Offset: 0x00007DEA
		public static bool FoundPort { get; set; } = false;

		// Token: 0x17000006 RID: 6
		// (get) Token: 0x06000048 RID: 72 RVA: 0x00009BF2 File Offset: 0x00007DF2
		// (set) Token: 0x06000049 RID: 73 RVA: 0x00009BF9 File Offset: 0x00007DF9
		public static int WaktuCariPort { get; set; } = 30;

		// Token: 0x0600004A RID: 74 RVA: 0x00009C04 File Offset: 0x00007E04
		public static bool PortsOpen()
		{
			bool result;
			try
			{
				bool isOpen = PortIOMe.Ports.IsOpen;
				if (isOpen)
				{
					PortIOMe.Ports.DiscardInBuffer();
					PortIOMe.Ports.DiscardOutBuffer();
					PortIOMe.Ports.Close();
				}
				PortIOMe.Ports = new SerialPort();
				PortIOMe.Ports.BaudRate = 921600;
				PortIOMe.Ports.PortName = "COM" + PortIOMe.PortCOM.ToString();
				PortIOMe.Ports.Open();
				result = true;
			}
			catch (Exception ex)
			{
				uiManager.logs(ex.ToString(), true, (uiManager.MessageType)uiManager.Merah);
				result = false;
			}
			return result;
		}

		// Token: 0x0600004B RID: 75 RVA: 0x00009CC0 File Offset: 0x00007EC0
		public static byte[] PortRead(int timeSpan)
		{
			Thread.Sleep(timeSpan);
			int bytesToRead = PortIOMe.Ports.BytesToRead;
			byte[] array = new byte[bytesToRead];
			PortIOMe.Ports.Read(array, 0, bytesToRead);
			return array;
		}

		// Token: 0x0600004C RID: 76 RVA: 0x00009CFA File Offset: 0x00007EFA
		public static void PortWrite(byte[] request)
		{
			PortIOMe.Ports.Write(request, 0, request.Length);
		}

		// Token: 0x04000065 RID: 101
		public static SerialPort Ports = new SerialPort();
	}
}
