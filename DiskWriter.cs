using System;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using Microsoft.Win32.SafeHandles;

namespace iReverse_Qualcomm_Tool_Lite
{
	// Token: 0x02000007 RID: 7
	internal static class DiskWriter
	{
		// Token: 0x06000038 RID: 56
		[DllImport("kernel32.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Auto, SetLastError = true)]
		public static extern SafeFileHandle CreateFile(string fileName, uint desiredAccess, uint shareMode, IntPtr securityAttributes, uint creationDisposition, uint flagsAndAttributes, IntPtr hTemplateFile);

		// Token: 0x06000039 RID: 57
		[DllImport("Kernel32.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Auto, SetLastError = true)]
		private static extern int CloseHandle(SafeFileHandle hObject);

		// Token: 0x0600003A RID: 58
		[DllImport("Kernel32.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Auto, SetLastError = true)]
		private static extern int SetCommTimeouts(SafeFileHandle hFile, ref DiskWriter.Timeout lpCommTimeouts);

		// Token: 0x0600003B RID: 59
		[DllImport("kernel32.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Auto, SetLastError = true)]
		internal static extern int WriteFile(SafeFileHandle hFile, byte[] bytes, int numBytesToWrite, out int numBytesWritten, IntPtr overlapped_MustBeZero);

		// Token: 0x0600003C RID: 60
		[DllImport("kernel32", CharSet = CharSet.Auto, SetLastError = true)]
		internal static extern int ReadFile(SafeFileHandle hFile, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 3)] byte[] bytes, int numBytesToRead, ref int numBytesRead, IntPtr overlapped_MustBeZero);

		// Token: 0x0600003D RID: 61
		[DllImport("Kernel32.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Auto, SetLastError = true)]
		private static extern int GetCommState(SafeFileHandle hFile, out DiskWriter.DCB lpDCB);

		// Token: 0x0600003E RID: 62
		[DllImport("Kernel32.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Auto, SetLastError = true)]
		private static extern int SetCommState(SafeFileHandle hFile, ref DiskWriter.DCB lpDCB);

		// Token: 0x0600003F RID: 63
		[DllImport("Kernel32.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
		public static extern int FlushFileBuffers(SafeFileHandle hFile);

		// Token: 0x06000040 RID: 64 RVA: 0x00009A20 File Offset: 0x00007C20
		public static bool Openport(string devices, BackgroundWorker worker, DoWorkEventArgs e)
		{
			DiskWriter.OpenWritePort = DiskWriter.CreateFile(devices, 3221225472U, 3U, IntPtr.Zero, 3U, 128U, IntPtr.Zero);
			DiskWriter.DCB structure = default(DiskWriter.DCB);
			structure.DCBlength = checked((uint)Marshal.SizeOf<DiskWriter.DCB>(structure));
			bool flag = DiskWriter.GetCommState(DiskWriter.OpenWritePort, out structure) == 0;
			bool result;
			if (flag)
			{
				DiskWriter.OpenWritePort.Dispose();
				DiskWriter.OpenWritePort.Close();
				e.Cancel = true;
				result = false;
			}
			else
			{
				structure.BaudRate = 921600U;
				structure.ByteSize = 8;
				structure.StopBits = 0;
				structure.Parity = 0;
				bool flag2 = DiskWriter.SetCommState(DiskWriter.OpenWritePort, ref structure) == 0;
				if (flag2)
				{
					DiskWriter.OpenWritePort.Dispose();
					DiskWriter.OpenWritePort.Close();
					e.Cancel = true;
					result = false;
				}
				else
				{
					bool cancellationPending = worker.CancellationPending;
					if (cancellationPending)
					{
						worker.CancelAsync();
						e.Cancel = true;
						result = false;
					}
					else
					{
						DiskWriter.FlushFileBuffers(DiskWriter.OpenWritePort);
						result = true;
					}
				}
			}
			return result;
		}

		// Token: 0x06000041 RID: 65 RVA: 0x00009B28 File Offset: 0x00007D28
		public static void Close()
		{
			DiskWriter.OpenWritePort.Dispose();
			DiskWriter.OpenWritePort.Close();
		}

		// Token: 0x06000042 RID: 66 RVA: 0x00009B44 File Offset: 0x00007D44
		public static void DiskWrite(byte[] data)
		{
			try
			{
				int num;
				DiskWriter.WriteFile(DiskWriter.OpenWritePort, data, data.Length, out num, IntPtr.Zero);
			}
			catch (Exception ex)
			{
				throw new Exception(ex.ToString());
			}
		}

		// Token: 0x06000043 RID: 67 RVA: 0x00009B8C File Offset: 0x00007D8C
		public static byte[] DiskRead(int delay = 0)
		{
			Thread.Sleep(delay);
			byte[] array = new byte[1048576];
			int count = 0;
			DiskWriter.ReadFile(DiskWriter.OpenWritePort, array, array.Length, ref count, IntPtr.Zero);
			return array.Take(count).ToArray<byte>();
		}

		// Token: 0x0400005B RID: 91
		public static SafeFileHandle OpenWritePort;

		// Token: 0x0400005C RID: 92
		public const uint GENERIC_READ = 2147483648U;

		// Token: 0x0400005D RID: 93
		public const uint GENERIC_WRITE = 1073741824U;

		// Token: 0x0400005E RID: 94
		public const uint FILE_ATTRIBUTE_NORMAL = 128U;

		// Token: 0x0400005F RID: 95
		public const uint FILE_SHARE_READ = 1U;

		// Token: 0x04000060 RID: 96
		public const uint FILE_SHARE_WRITE = 2U;

		// Token: 0x04000061 RID: 97
		public const uint FILE_SHARE_DELETE = 3U;

		// Token: 0x04000062 RID: 98
		public const uint OPEN_EXISTING = 3U;

		// Token: 0x04000063 RID: 99
		public const int NOPARITY = 0;

		// Token: 0x04000064 RID: 100
		public const int ONESTOPBIT = 0;

		// Token: 0x02000016 RID: 22
		private class Timeout
		{
			// Token: 0x040000C3 RID: 195
			public uint ReadIntervalTimeout = 0U;

			// Token: 0x040000C4 RID: 196
			public uint ReadTotalTimeoutMultiplier = 0U;

			// Token: 0x040000C5 RID: 197
			public uint ReadTotalTimeoutConstant = 0U;

			// Token: 0x040000C6 RID: 198
			public uint WriteTotalTimeoutMultiplier = 0U;

			// Token: 0x040000C7 RID: 199
			public uint WriteTotalTimeoutConstant = 0U;
		}

		// Token: 0x02000017 RID: 23
		public struct DCB
		{
			// Token: 0x040000C8 RID: 200
			public uint DCBlength;

			// Token: 0x040000C9 RID: 201
			public uint BaudRate;

			// Token: 0x040000CA RID: 202
			public uint uiFlagBits;

			// Token: 0x040000CB RID: 203
			public ushort wReserved;

			// Token: 0x040000CC RID: 204
			public ushort XonLim;

			// Token: 0x040000CD RID: 205
			public ushort XoffLim;

			// Token: 0x040000CE RID: 206
			public byte ByteSize;

			// Token: 0x040000CF RID: 207
			public byte Parity;

			// Token: 0x040000D0 RID: 208
			public byte StopBits;

			// Token: 0x040000D1 RID: 209
			public char XonChar;

			// Token: 0x040000D2 RID: 210
			public char XoffChar;

			// Token: 0x040000D3 RID: 211
			public char ErrorChar;

			// Token: 0x040000D4 RID: 212
			public char EofChar;

			// Token: 0x040000D5 RID: 213
			public char EvtChar;

			// Token: 0x040000D6 RID: 214
			public ushort wReserved1;
		}
	}
}
