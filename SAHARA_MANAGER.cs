using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace iReverse_Qualcomm_Tool_Lite
{
	// Token: 0x0200000E RID: 14
	internal static class SAHARA_MANAGER
	{
		// Token: 0x17000007 RID: 7
		// (get) Token: 0x0600009A RID: 154 RVA: 0x00011098 File Offset: 0x0000F298
		// (set) Token: 0x0600009B RID: 155 RVA: 0x0001109F File Offset: 0x0000F29F
		public static byte[] loader { get; set; }

		// Token: 0x17000008 RID: 8
		// (get) Token: 0x0600009C RID: 156 RVA: 0x000110A7 File Offset: 0x0000F2A7
		// (set) Token: 0x0600009D RID: 157 RVA: 0x000110AE File Offset: 0x0000F2AE
		public static SAHARA.SAHARA_MODE mode { get; set; }

		// Token: 0x0600009E RID: 158 RVA: 0x000110B6 File Offset: 0x0000F2B6
		public static void sendBytes(byte[] bytes)
		{
			PortIOMe.PortWrite(bytes);
			Thread.Sleep(80);
		}

		// Token: 0x0600009F RID: 159 RVA: 0x000110C8 File Offset: 0x0000F2C8
		public static object RawDeserialize(byte[] rawData, int position, Type anyType)
		{
			int num = Marshal.SizeOf(anyType);
			bool flag = num > rawData.Length;
			object result;
			if (flag)
			{
				result = null;
			}
			else
			{
				IntPtr intPtr = Marshal.AllocHGlobal(num);
				Marshal.Copy(rawData, position, intPtr, num);
				object obj = Marshal.PtrToStructure(intPtr, anyType);
				Marshal.FreeHGlobal(intPtr);
				result = obj;
			}
			return result;
		}

		// Token: 0x060000A0 RID: 160 RVA: 0x00011114 File Offset: 0x0000F314
		public static void SaharaConnect(object sender, DoWorkEventArgs e)
		{
			SAHARA_MANAGER.cpu64 = false;
			uiManager.logs("Connect To Devices : ", false, (uiManager.MessageType)uiManager.Hitam);
			bool flag = !PortIOMe.PortsOpen();
			if (flag)
			{
				uiManager.logs("Failed To Open Port", true, (uiManager.MessageType)uiManager.Merah);
			}
			else
			{
				uiManager.logs("Ok", true, (uiManager.MessageType)uiManager.Hijau);
				byte[] array = PortIOMe.PortRead(50);
				uiManager.logs("Handshake : ", false, (uiManager.MessageType)uiManager.Hitam);
				bool flag2 = array.Length == 0;
				if (flag2)
				{
					SAHARA_MANAGER.hangHack(SAHARA.SAHARA_MODE.SAHARA_MODE_COMMAND);
				}
				else
				{
					bool flag3 = array.Length == Marshal.SizeOf(typeof(SAHARA.SAHARA_REQUESTS_HELLO));
					if (flag3)
					{
						object obj = SAHARA_MANAGER.RawDeserialize(array, 0, typeof(SAHARA.SAHARA_REQUESTS_HELLO));
						SAHARA.SAHARA_REQUESTS_HELLO pkt = (SAHARA.SAHARA_REQUESTS_HELLO)obj;
						SAHARA_MANAGER.SendHelloResponse(pkt, SAHARA.SAHARA_MODE.SAHARA_MODE_COMMAND);
					}
					PortIOMe.Ports.DiscardInBuffer();
					PortIOMe.Ports.DiscardOutBuffer();
					PortIOMe.Ports.Close();
				}
			}
		}

		// Token: 0x060000A1 RID: 161 RVA: 0x00011210 File Offset: 0x0000F410
		public static void hangHack(SAHARA.SAHARA_MODE mode)
		{
			SAHARA.SAHARA_SWITCH_PACKET msg = default(SAHARA.SAHARA_SWITCH_PACKET);
			msg.header.command = SAHARA.SAHARA_CMD.SAHARA_CMD_SWITCH_MODE;
			msg.header.size = Marshal.SizeOf(typeof(SAHARA.SAHARA_SWITCH_PACKET));
			msg.mode = SAHARA.SAHARA_MODE.SAHARA_MODE_IMAGE_PENDING;
			byte[] request = SAHARA_MANAGER.SerializeMessage<SAHARA.SAHARA_SWITCH_PACKET>(msg);
			uiManager.logs("Get Device Mode : ", false, (uiManager.MessageType)uiManager.Kuning);
			PortIOMe.PortWrite(request);
			int num = 0;
			checked
			{
				for (;;)
				{
					byte[] bytes = PortIOMe.PortRead(0);
					bool flag = Encoding.UTF8.GetString(bytes).Contains("xml");
					if (flag)
					{
						break;
					}
					num++;
					Thread.Sleep(500);
					bool flag2 = num == 3;
					if (flag2)
					{
						goto Block_2;
					}
				}
				uiManager.logs("Device On Flash Mode", true, (uiManager.MessageType)uiManager.Kuning);
				SAHARA_MANAGER.sendingloaderStatus = true;
				PortIOMe.Ports.DiscardInBuffer();
				PortIOMe.Ports.DiscardOutBuffer();
				PortIOMe.Ports.Close();
				return;
				Block_2:
				uiManager.logs("Error After 3 times read response", true, (uiManager.MessageType)uiManager.Kuning);
				uiManager.logs("Please Reconect Device", true, (uiManager.MessageType)uiManager.Kuning);
				SAHARA_MANAGER.sendingloaderStatus = false;
				PortIOMe.Ports.DiscardInBuffer();
				PortIOMe.Ports.DiscardOutBuffer();
				PortIOMe.Ports.Close();
			}
		}

		// Token: 0x060000A2 RID: 162 RVA: 0x0001135C File Offset: 0x0000F55C
		public static byte[] SerializeMessage<T>(T msg) where T : struct
		{
			int num = Marshal.SizeOf(typeof(T));
			byte[] array = new byte[num];
			IntPtr intPtr = Marshal.AllocHGlobal(num);
			Marshal.StructureToPtr<T>(msg, intPtr, true);
			Marshal.Copy(intPtr, array, 0, num);
			Marshal.FreeHGlobal(intPtr);
			return array;
		}

		// Token: 0x060000A3 RID: 163 RVA: 0x000113A8 File Offset: 0x0000F5A8
		public static bool validateResponse(SAHARA.SAHARA_CMD expectedCMD, byte[] response)
		{
			int num = response.Length;
			bool flag = expectedCMD == SAHARA.SAHARA_CMD.SAHARA_CMD_READ_DATA && num == 20;
			bool result;
			if (flag)
			{
				SAHARA_MANAGER.cpu64 = false;
				result = true;
			}
			else
			{
				bool flag2 = expectedCMD == SAHARA.SAHARA_CMD.SAHARA_CMD_READ_DATA && num == 32;
				if (flag2)
				{
					SAHARA_MANAGER.cpu64 = true;
					result = true;
				}
				else
				{
					bool flag3 = expectedCMD == SAHARA.SAHARA_CMD.SAHARA_CMD_HELLO_REQ && num == 48;
					if (flag3)
					{
						result = true;
					}
					else
					{
						bool flag4 = expectedCMD == SAHARA.SAHARA_CMD.SAHARA_CMD_IMG_END_TRSFR && num == 16;
						if (flag4)
						{
							result = true;
						}
						else
						{
							bool flag5 = expectedCMD == SAHARA.SAHARA_CMD.SAHARA_CMD_IMG_DONE_RESP && num == 16;
							if (flag5)
							{
								object obj = SAHARA_MANAGER.RawDeserialize(response, 0, typeof(SAHARA.SAHARA_RESPONSE_IMGDONE_PACKET));
							}
							bool flag6 = expectedCMD == SAHARA.SAHARA_CMD.SAHARA_CMD_READY && num == 8;
							if (flag6)
							{
								object obj2 = SAHARA_MANAGER.RawDeserialize(response, 0, typeof(SAHARA.SAHARA_RESPONSE_IMGDONE_PACKET));
								result = true;
							}
							else
							{
								bool flag7 = expectedCMD == SAHARA.SAHARA_CMD.SAHARA_CMD_EXECUTE_RESPONSE && num == 16;
								result = flag7;
							}
						}
					}
				}
			}
			return result;
		}

		// Token: 0x060000A4 RID: 164 RVA: 0x00011498 File Offset: 0x0000F698
		public static void SendHelloResponse(SAHARA.SAHARA_REQUESTS_HELLO pkt, SAHARA.SAHARA_MODE mode)
		{
			bool flag = mode == SAHARA.SAHARA_MODE.SAHARA_MODE_COMMAND;
			if (flag)
			{
				pkt.header.command = SAHARA.SAHARA_CMD.SAHARA_CMD_HELLO_RESP;
				pkt.mode = SAHARA.SAHARA_MODE.SAHARA_MODE_COMMAND;
				pkt.header.size = Marshal.SizeOf(typeof(SAHARA.SAHARA_REQUESTS_HELLO));
				pkt.maxCommandPacketSize = 0;
				mode = SAHARA.SAHARA_MODE.SAHARA_MODE_COMMAND;
				uiManager.logs("Sending Hello Response Packet : ", false, (uiManager.MessageType)uiManager.Hitam);
				byte[] bytes = SAHARA_MANAGER.SerializeMessage<SAHARA.SAHARA_REQUESTS_HELLO>(pkt);
				SAHARA_MANAGER.sendBytes(bytes);
				uiManager.logs("OK", true, (uiManager.MessageType)uiManager.Hijau);
			}
			bool flag2 = mode == SAHARA.SAHARA_MODE.SAHARA_MODE_IMAGE_PENDING;
			if (flag2)
			{
				pkt.header.command = SAHARA.SAHARA_CMD.SAHARA_CMD_HELLO_RESP;
				pkt.mode = SAHARA.SAHARA_MODE.SAHARA_MODE_IMAGE_PENDING;
				pkt.header.size = Marshal.SizeOf(typeof(SAHARA.SAHARA_REQUESTS_HELLO));
				pkt.maxCommandPacketSize = 0;
				mode = SAHARA.SAHARA_MODE.SAHARA_MODE_IMAGE_PENDING;
				byte[] bytes2 = SAHARA_MANAGER.SerializeMessage<SAHARA.SAHARA_REQUESTS_HELLO>(pkt);
				SAHARA_MANAGER.sendBytes(bytes2);
			}
			byte[] array = PortIOMe.PortRead(0);
			bool flag3 = SAHARA_MANAGER.validateResponse(SAHARA.SAHARA_CMD.SAHARA_CMD_READY, array);
			if (flag3)
			{
				SAHARA_MANAGER.dumpDeviceInfo();
				SAHARA_MANAGER.switchMode(SAHARA.SAHARA_MODE.SAHARA_MODE_IMAGE_PENDING);
			}
			else
			{
				bool isAutoLoader = Main.IsAutoLoader;
				if (isAutoLoader)
				{
					bool isLoaderExist = SAHARA_MANAGER.IsLoaderExist;
					if (isLoaderExist)
					{
						bool flag4 = SAHARA_MANAGER.validateResponse(SAHARA.SAHARA_CMD.SAHARA_CMD_READ_DATA, array);
						if (flag4)
						{
							mode = SAHARA.SAHARA_MODE.SAHARA_MODE_IMAGE_PENDING;
							bool flag5 = SAHARA_MANAGER.cpu64;
							if (flag5)
							{
								uiManager.logs("CPU 64bit Detected", true, (uiManager.MessageType)uiManager.Hitam);
								SAHARA.SAHARA_REQUESTS_READDATA_64 initReq = (SAHARA.SAHARA_REQUESTS_READDATA_64)SAHARA_MANAGER.RawDeserialize(array, 0, typeof(SAHARA.SAHARA_REQUESTS_READDATA_64));
								SAHARA_MANAGER.sendFlashLoader64(initReq);
							}
							else
							{
								uiManager.logs("CPU 32bit Detected", true, (uiManager.MessageType)uiManager.Hitam);
								SAHARA.SAHARA_REQUESTS_READDATA initReq2 = (SAHARA.SAHARA_REQUESTS_READDATA)SAHARA_MANAGER.RawDeserialize(array, 0, typeof(SAHARA.SAHARA_REQUESTS_READDATA));
								SAHARA_MANAGER.sendFlashLoader(initReq2);
							}
						}
					}
					else
					{
						uiManager.logs("Autoloader belum tersedia untuk perangkat ini silahkan pilih loader secara manual!", true, (uiManager.MessageType)uiManager.Merah);
					}
				}
				else
				{
					bool flag6 = SAHARA_MANAGER.validateResponse(SAHARA.SAHARA_CMD.SAHARA_CMD_READ_DATA, array);
					if (flag6)
					{
						mode = SAHARA.SAHARA_MODE.SAHARA_MODE_IMAGE_PENDING;
						bool flag7 = SAHARA_MANAGER.cpu64;
						if (flag7)
						{
							uiManager.logs("CPU 64bit Detected", true, (uiManager.MessageType)uiManager.Hitam);
							SAHARA.SAHARA_REQUESTS_READDATA_64 initReq3 = (SAHARA.SAHARA_REQUESTS_READDATA_64)SAHARA_MANAGER.RawDeserialize(array, 0, typeof(SAHARA.SAHARA_REQUESTS_READDATA_64));
							SAHARA_MANAGER.sendFlashLoader64(initReq3);
						}
						else
						{
							uiManager.logs("CPU 32bit Detected", true, (uiManager.MessageType)uiManager.Hitam);
							SAHARA.SAHARA_REQUESTS_READDATA initReq4 = (SAHARA.SAHARA_REQUESTS_READDATA)SAHARA_MANAGER.RawDeserialize(array, 0, typeof(SAHARA.SAHARA_REQUESTS_READDATA));
							SAHARA_MANAGER.sendFlashLoader(initReq4);
						}
					}
				}
			}
		}

        // Token: 0x060000A5 RID: 165 RVA: 0x00011708 File Offset: 0x0000F908
        public static void sendFlashLoader(SAHARA.SAHARA_REQUESTS_READDATA initReq)
        {
            int bytesSent = 0;
            int num = 1;
            bool flag = false;
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            int num2 = 0;
            uiManager.logs("Sending Flash Loader : ", false, (uiManager.MessageType)uiManager.Hitam);

            // 唯一新增：用一个局部变量代替编译器生成的字段
            Action cachedUpdateSize = null;

            while (!flag)
            {
                int size = initReq.size;
                int offset = initReq.offset;
                Stream input = new MemoryStream(SAHARA_MANAGER.loader);
                using (BinaryReader binaryReader = new BinaryReader(input))
                {
                    byte[] array = new byte[size];
                    binaryReader.BaseStream.Seek((long)offset, SeekOrigin.Begin);
                    binaryReader.Read(array, 0, size);
                    PortIOMe.PortWrite(array);
                    checked
                    {
                        bytesSent += array.Length;
                        TimeSpan elapsed = stopwatch.Elapsed;
                        double speed = (double)array.Length / elapsed.TotalSeconds;
                        Main.DelegateFunction.label_transferrate.Invoke(new Action(delegate ()
                        {
                            Main.DelegateFunction.label_transferrate.Text = FIREHOSE_MANAGER.GetFileSizes(Convert.ToInt64(speed)) + " /s";
                        }));
                    }
                    uiManager.ProcessBar2((long)bytesSent, (long)SAHARA_MANAGER.loader.Length);
                    stopwatch.Stop();
                    Main.DelegateFunction.label_totalsize.Invoke(new Action(delegate ()
                    {
                        Main.DelegateFunction.label_totalsize.Text = FIREHOSE_MANAGER.GetFileSizes((long)SAHARA_MANAGER.loader.Length);
                    }));

                    Control label_writensize = Main.DelegateFunction.label_writensize;
                    label_writensize.Invoke(
                        cachedUpdateSize ?? (cachedUpdateSize = new Action(delegate ()
                        {
                            Main.DelegateFunction.label_writensize.Text = FIREHOSE_MANAGER.GetFileSizes((long)bytesSent);
                        }))
                    );

                    Main.DelegateFunction.label_transferrate.Invoke(new Action(delegate ()
                    {
                        Main.DelegateFunction.label_transferrate.Text = "0.00 Bytes / s";
                    }));

                    byte[] array2 = PortIOMe.PortRead(0);
                    bool flag2 = array2.Length == 0;
                    checked
                    {
                        if (flag2)
                        {
                            bool flag4;
                            do
                            {
                                array2 = PortIOMe.PortRead(10);
                                bool flag3 = array2.Length == 0;
                                if (!flag3)
                                {
                                    goto IL_279;
                                }
                                num2++;
                                flag4 = (num2 == 10);
                            }
                            while (!flag4);

                            SAHARA_MANAGER.sendingloaderStatus = false;
                            uiManager.logs("Packet Rejected ", true, (uiManager.MessageType)uiManager.Merah);
                            Main.DelegateFunction.label_totalsize.Invoke(new Action(delegate ()
                            {
                                Main.DelegateFunction.label_totalsize.Text = "0.00 Bytes           ";
                            }));
                            Main.DelegateFunction.label_writensize.Invoke(new Action(delegate ()
                            {
                                Main.DelegateFunction.label_writensize.Text = "0.00 Bytes           ";
                            }));
                            PortIOMe.Ports.DiscardInBuffer();
                            PortIOMe.Ports.DiscardOutBuffer();
                            PortIOMe.Ports.Close();
                            break;
                        IL_279:
                            num2 = 0;
                        }
                        bool flag5 = SAHARA_MANAGER.validateResponse(SAHARA.SAHARA_CMD.SAHARA_CMD_READ_DATA, array2);
                        if (flag5)
                        {
                            SAHARA.SAHARA_REQUESTS_READDATA sahara_REQUESTS_READDATA = (SAHARA.SAHARA_REQUESTS_READDATA)SAHARA_MANAGER.RawDeserialize(array2, 0, typeof(SAHARA.SAHARA_REQUESTS_READDATA));
                            initReq = sahara_REQUESTS_READDATA;
                            num += 5;
                        }
                        else
                        {
                            bool flag6 = SAHARA_MANAGER.validateResponse(SAHARA.SAHARA_CMD.SAHARA_CMD_IMG_END_TRSFR, array2);
                            if (!flag6)
                            {
                                SAHARA_MANAGER.sendingloaderStatus = false;
                                uiManager.logs("Packet Rejected", true, (uiManager.MessageType)uiManager.Merah);
                                Main.DelegateFunction.label_totalsize.Invoke(new Action(delegate ()
                                {
                                    Main.DelegateFunction.label_totalsize.Text = "0.00 Bytes           ";
                                }));
                                Main.DelegateFunction.label_writensize.Invoke(new Action(delegate ()
                                {
                                    Main.DelegateFunction.label_writensize.Text = "0.00 Bytes           ";
                                }));
                                PortIOMe.Ports.DiscardInBuffer();
                                PortIOMe.Ports.DiscardOutBuffer();
                                PortIOMe.Ports.Close();
                                break;
                            }
                            SAHARA.SAHARA_REQUESTS_IMG_DONE msg = default(SAHARA.SAHARA_REQUESTS_IMG_DONE);
                            msg.header.command = SAHARA.SAHARA_CMD.SAHARA_CMD_IMG_DONE_REQ;
                            msg.header.size = Marshal.SizeOf(typeof(SAHARA.SAHARA_REQUESTS_IMG_DONE));
                            PortIOMe.PortWrite(SAHARA_MANAGER.SerializeMessage<SAHARA.SAHARA_REQUESTS_IMG_DONE>(msg));
                            byte[] rawData = PortIOMe.PortRead(100);
                            SAHARA.SAHARA_RESPONSE_IMGDONE_PACKET sahara_RESPONSE_IMGDONE_PACKET = (SAHARA.SAHARA_RESPONSE_IMGDONE_PACKET)SAHARA_MANAGER.RawDeserialize(rawData, 0, typeof(SAHARA.SAHARA_RESPONSE_IMGDONE_PACKET));
                            bool flag7 = sahara_RESPONSE_IMGDONE_PACKET.status == SAHARA.SAHARA_STATUS.SAHARA_STATUS_32;
                            if (flag7)
                            {
                                uiManager.logs("OK", true, (uiManager.MessageType)uiManager.Hijau);
                                SAHARA_MANAGER.mode = SAHARA.SAHARA_MODE.SAHARA_MODE_IMAGE_TX_COMPLETE;
                                Main.DelegateFunction.label_totalsize.Invoke(new Action(delegate ()
                                {
                                    Main.DelegateFunction.label_totalsize.Text = "0.00 Bytes           ";
                                }));
                                Main.DelegateFunction.label_writensize.Invoke(new Action(delegate ()
                                {
                                    Main.DelegateFunction.label_writensize.Text = "0.00 Bytes           ";
                                }));
                                PortIOMe.Ports.DiscardInBuffer();
                                PortIOMe.Ports.DiscardOutBuffer();
                                PortIOMe.Ports.Close();
                                SAHARA_MANAGER.sendingloaderStatus = true;
                                break;
                            }
                            PortIOMe.Ports.DiscardInBuffer();
                            PortIOMe.Ports.DiscardOutBuffer();
                            PortIOMe.Ports.Close();
                            uiManager.logs("Failed", true, (uiManager.MessageType)uiManager.Merah);
                            Main.DelegateFunction.label_totalsize.Invoke(new Action(delegate ()
                            {
                                Main.DelegateFunction.label_totalsize.Text = "0.00 Bytes           ";
                            }));
                            Main.DelegateFunction.label_writensize.Invoke(new Action(delegate ()
                            {
                                Main.DelegateFunction.label_writensize.Text = "0.00 Bytes           ";
                            }));
                            SAHARA_MANAGER.sendingloaderStatus = false;
                            break;
                        }
                    }
                }
            }
        }

        // Token: 0x060000A6 RID: 166 RVA: 0x00011C74 File Offset: 0x0000FE74
        public static void sendFlashLoader64(SAHARA.SAHARA_REQUESTS_READDATA_64 initReq)
        {
            int bytesSent = 0;
            int num = 1;
            bool flag = false;
            int num2 = 0;
            uiManager.logs("Sending Flash Loader : ", false, (uiManager.MessageType)uiManager.Hitam);

            // 唯一新增：局部变量代替编译器字段
            Action cachedUpdateSize = null;

            checked
            {
                while (!flag)
                {
                    int num3 = (int)initReq.size;
                    int num4 = (int)initReq.offset;
                    Stream input = new MemoryStream(SAHARA_MANAGER.loader);
                    using (BinaryReader binaryReader = new BinaryReader(input))
                    {
                        Stopwatch stopwatch = new Stopwatch();
                        stopwatch.Start();
                        byte[] array = new byte[num3];
                        binaryReader.BaseStream.Seek(unchecked((long)num4), SeekOrigin.Begin);
                        binaryReader.Read(array, 0, num3);
                        PortIOMe.PortWrite(array);
                        bytesSent += num3;

                        TimeSpan elapsed = stopwatch.Elapsed;
                        double speed = (double)array.Length / elapsed.TotalSeconds;
                        Main.DelegateFunction.label_transferrate.Invoke(new Action(delegate ()
                        {
                            Main.DelegateFunction.label_transferrate.Text = FIREHOSE_MANAGER.GetFileSizes(Convert.ToInt64(speed)) + " /s";
                        }));

                        unchecked
                        {
                            uiManager.ProcessBar2((long)bytesSent, (long)SAHARA_MANAGER.loader.Length);
                            stopwatch.Stop();
                            Main.DelegateFunction.label_totalsize.Invoke(new Action(delegate ()
                            {
                                Main.DelegateFunction.label_totalsize.Text = FIREHOSE_MANAGER.GetFileSizes((long)SAHARA_MANAGER.loader.Length);
                            }));

                            Control label_writensize = Main.DelegateFunction.label_writensize;
                            label_writensize.Invoke(
                                cachedUpdateSize ?? (cachedUpdateSize = new Action(delegate ()
                                {
                                    Main.DelegateFunction.label_writensize.Text = FIREHOSE_MANAGER.GetFileSizes((long)bytesSent);
                                }))
                            );

                            Main.DelegateFunction.label_transferrate.Invoke(new Action(delegate ()
                            {
                                Main.DelegateFunction.label_transferrate.Text = "0.00 Bytes / s";
                            }));

                            byte[] array2 = PortIOMe.PortRead(0);
                            bool flag2 = (array2.Length == 0);
                            if (flag2)
                            {
                                bool flag4;
                                do
                                {
                                    array2 = PortIOMe.PortRead(10);
                                    num2++;
                                    bool flag3 = array2.Length == 0;
                                    if (!flag3)
                                        goto IL_279;
                                    flag4 = (num2 == 10);
                                }
                                while (!flag4);

                                SAHARA_MANAGER.sendingloaderStatus = false;
                                uiManager.logs("Packet Rejected ", true, (uiManager.MessageType)uiManager.Merah);
                                Main.DelegateFunction.label_totalsize.Invoke(new Action(delegate ()
                                {
                                    Main.DelegateFunction.label_totalsize.Text = "0.00 Bytes           ";
                                }));
                                Main.DelegateFunction.label_writensize.Invoke(new Action(delegate ()
                                {
                                    Main.DelegateFunction.label_writensize.Text = "0.00 Bytes           ";
                                }));
                                PortIOMe.Ports.DiscardInBuffer();
                                PortIOMe.Ports.DiscardOutBuffer();
                                PortIOMe.Ports.Close();
                                break;
                            IL_279:
                                num2 = 0;
                            }

                            bool flag5 = SAHARA_MANAGER.validateResponse(SAHARA.SAHARA_CMD.SAHARA_CMD_READ_DATA, array2);
                            if (flag5)
                            {
                                SAHARA.SAHARA_REQUESTS_READDATA_64 sahara_REQUESTS_READDATA_ = (SAHARA.SAHARA_REQUESTS_READDATA_64)SAHARA_MANAGER.RawDeserialize(array2, 0, typeof(SAHARA.SAHARA_REQUESTS_READDATA_64));
                                initReq = sahara_REQUESTS_READDATA_;
                                num += 5;
                            }
                            else
                            {
                                bool flag6 = SAHARA_MANAGER.validateResponse(SAHARA.SAHARA_CMD.SAHARA_CMD_IMG_END_TRSFR, array2);
                                if (!flag6)
                                {
                                    PortIOMe.Ports.DiscardInBuffer();
                                    PortIOMe.Ports.DiscardOutBuffer();
                                    PortIOMe.Ports.Close();
                                    SAHARA_MANAGER.sendingloaderStatus = false;
                                    uiManager.logs("Packet Rejected", true, (uiManager.MessageType)uiManager.Merah);
                                    Main.DelegateFunction.label_totalsize.Invoke(new Action(delegate ()
                                    {
                                        Main.DelegateFunction.label_totalsize.Text = "0.00 Bytes           ";
                                    }));
                                    Main.DelegateFunction.label_writensize.Invoke(new Action(delegate ()
                                    {
                                        Main.DelegateFunction.label_writensize.Text = "0.00 Bytes           ";
                                    }));
                                    break;
                                }
                                SAHARA.SAHARA_REQUESTS_IMG_DONE64 msg = default(SAHARA.SAHARA_REQUESTS_IMG_DONE64);
                                msg.header.command = SAHARA.SAHARA_CMD.SAHARA_CMD_IMG_DONE_REQ;
                                msg.header.size = Marshal.SizeOf(typeof(SAHARA.SAHARA_REQUESTS_IMG_DONE64));
                                PortIOMe.PortWrite(SAHARA_MANAGER.SerializeMessage<SAHARA.SAHARA_REQUESTS_IMG_DONE64>(msg));
                                byte[] rawData = PortIOMe.PortRead(100);
                                SAHARA.SAHARA_RESPONSE_IMGDONE_PACKET64 sahara_RESPONSE_IMGDONE_PACKET = (SAHARA.SAHARA_RESPONSE_IMGDONE_PACKET64)SAHARA_MANAGER.RawDeserialize(rawData, 0, typeof(SAHARA.SAHARA_RESPONSE_IMGDONE_PACKET64));
                                bool flag7 = sahara_RESPONSE_IMGDONE_PACKET.status == SAHARA.SAHARA_STATUS.SAHARA_STATUS_64;
                                if (flag7)
                                {
                                    uiManager.logs("OK", true, (uiManager.MessageType)uiManager.Hijau);
                                    SAHARA_MANAGER.mode = SAHARA.SAHARA_MODE.SAHARA_MODE_IMAGE_TX_COMPLETE;
                                    SAHARA_MANAGER.sendingloaderStatus = true;
                                    Main.DelegateFunction.label_totalsize.Invoke(new Action(delegate ()
                                    {
                                        Main.DelegateFunction.label_totalsize.Text = "0.00 Bytes           ";
                                    }));
                                    Main.DelegateFunction.label_writensize.Invoke(new Action(delegate ()
                                    {
                                        Main.DelegateFunction.label_writensize.Text = "0.00 Bytes           ";
                                    }));
                                    PortIOMe.Ports.DiscardInBuffer();
                                    PortIOMe.Ports.DiscardOutBuffer();
                                    PortIOMe.Ports.Close();
                                    break;
                                }
                                SAHARA_MANAGER.sendingloaderStatus = false;
                                uiManager.logs("Failed", true, (uiManager.MessageType)uiManager.Merah);
                                Main.DelegateFunction.label_totalsize.Invoke(new Action(delegate ()
                                {
                                    Main.DelegateFunction.label_totalsize.Text = "0.00 Bytes           ";
                                }));
                                Main.DelegateFunction.label_writensize.Invoke(new Action(delegate ()
                                {
                                    Main.DelegateFunction.label_writensize.Text = "0.00 Bytes           ";
                                }));
                                PortIOMe.Ports.DiscardInBuffer();
                                PortIOMe.Ports.DiscardOutBuffer();
                                PortIOMe.Ports.Close();
                                break;
                            }
                        }
                    }
                }
            }
        }

        // Token: 0x060000A7 RID: 167 RVA: 0x000121E0 File Offset: 0x000103E0
        public static void dumpDeviceInfo()
		{
			SAHARA_MANAGER.ReadData(SAHARA.SAHARA_EXEC_CMD.SAHARA_EXEC_CMD_MSM_HW_ID_READ);
			SAHARA_MANAGER.ReadData(SAHARA.SAHARA_EXEC_CMD.SAHARA_EXEC_CMD_SERIAL_NUM_READ);
			SAHARA_MANAGER.ReadData(SAHARA.SAHARA_EXEC_CMD.SAHARA_EXEC_CMD_OEM_PK_HASH_READ);
		}

		// Token: 0x060000A8 RID: 168 RVA: 0x000121F8 File Offset: 0x000103F8
		public static bool switchMode(SAHARA.SAHARA_MODE mode)
		{
			SAHARA.SAHARA_SWITCH_PACKET msg = default(SAHARA.SAHARA_SWITCH_PACKET);
			msg.header.command = SAHARA.SAHARA_CMD.SAHARA_CMD_SWITCH_MODE;
			msg.header.size = Marshal.SizeOf(typeof(SAHARA.SAHARA_SWITCH_PACKET));
			msg.mode = SAHARA.SAHARA_MODE.SAHARA_MODE_IMAGE_PENDING;
			byte[] bytes = SAHARA_MANAGER.SerializeMessage<SAHARA.SAHARA_SWITCH_PACKET>(msg);
			SAHARA_MANAGER.sendBytes(bytes);
			byte[] array = PortIOMe.PortRead(0);
			bool flag = SAHARA_MANAGER.validateResponse(SAHARA.SAHARA_CMD.SAHARA_CMD_HELLO_REQ, array);
			if (flag)
			{
				object obj = SAHARA_MANAGER.RawDeserialize(array, 0, typeof(SAHARA.SAHARA_REQUESTS_HELLO));
				SAHARA.SAHARA_REQUESTS_HELLO pkt = (SAHARA.SAHARA_REQUESTS_HELLO)obj;
				bool flag2 = mode == SAHARA.SAHARA_MODE.SAHARA_MODE_IMAGE_PENDING;
				if (flag2)
				{
					SAHARA_MANAGER.SendHelloResponse(pkt, SAHARA.SAHARA_MODE.SAHARA_MODE_IMAGE_PENDING);
				}
			}
			return false;
		}

		// Token: 0x060000A9 RID: 169 RVA: 0x0001229C File Offset: 0x0001049C
		public static void ReadData(SAHARA.SAHARA_EXEC_CMD cmd)
		{
			SAHARA.SAHARA_REQUEST_EXE_CMD msg = default(SAHARA.SAHARA_REQUEST_EXE_CMD);
			msg.header.command = SAHARA.SAHARA_CMD.SAHARA_CMD_EXECUTE_REQ;
			msg.header.size = Marshal.SizeOf(typeof(SAHARA.SAHARA_REQUEST_EXE_CMD));
			msg.clientCmd = cmd;
			byte[] bytes = SAHARA_MANAGER.SerializeMessage<SAHARA.SAHARA_REQUEST_EXE_CMD>(msg);
			SAHARA_MANAGER.sendBytes(bytes);
			byte[] array = PortIOMe.PortRead(10);
			bool flag = SAHARA_MANAGER.validateResponse(SAHARA.SAHARA_CMD.SAHARA_CMD_EXECUTE_RESPONSE, array);
			if (flag)
			{
				SAHARA.SAHARA_RESPONSE_EXECCMD_RESPONSE sahara_RESPONSE_EXECCMD_RESPONSE = (SAHARA.SAHARA_RESPONSE_EXECCMD_RESPONSE)SAHARA_MANAGER.RawDeserialize(array, 0, typeof(SAHARA.SAHARA_RESPONSE_EXECCMD_RESPONSE));
				int size = sahara_RESPONSE_EXECCMD_RESPONSE.size;
				msg.header.command = SAHARA.SAHARA_CMD.SAHARA_CMD_EXECUTE_DATA;
				byte[] bytes2 = SAHARA_MANAGER.SerializeMessage<SAHARA.SAHARA_REQUEST_EXE_CMD>(msg);
				SAHARA_MANAGER.sendBytes(bytes2);
			}
			byte[] array2 = PortIOMe.PortRead(10);
			bool flag2 = cmd == SAHARA.SAHARA_EXEC_CMD.SAHARA_EXEC_CMD_MSM_HW_ID_READ;
			if (flag2)
			{
				Array.Reverse(array2, 0, array2.Length);
				string text = BitConverter.ToString(array2).Replace("-", string.Empty);
				text = text.Substring(0, 14);
				SAHARA_MANAGER._pblInfo.msm_id = text;
				uiManager.logs("MSM_HW_ID :", false, (uiManager.MessageType)uiManager.Hitam);
				uiManager.logs(text, true, (uiManager.MessageType)uiManager.Hitam);
			}
			bool flag3 = cmd == SAHARA.SAHARA_EXEC_CMD.SAHARA_EXEC_CMD_OEM_PK_HASH_READ;
			if (flag3)
			{
				string text2 = BitConverter.ToString(array2).Replace("-", string.Empty);
				SAHARA_MANAGER._pblInfo.pk_hash = text2;
				uiManager.logs("OEM PK_HASH [0] :", false, (uiManager.MessageType)uiManager.Hitam);
				uiManager.logs(text2.Substring(0, 32), true, (uiManager.MessageType)uiManager.Kuning);
				uiManager.logs("OEM PK_HASH [1] :", false, (uiManager.MessageType)uiManager.Hitam);
				uiManager.logs(text2.Substring(checked(text2.Length - 32), 32), true, (uiManager.MessageType)uiManager.Kuning);
				bool isAutoLoader = Main.IsAutoLoader;
				if (isAutoLoader)
				{
					bool flag4 = SAHARA_MANAGER._pblInfo.msm_id.Length < 16;
					if (flag4)
					{
						bool flag5;
						do
						{
							StringBuilder stringBuilder = new StringBuilder();
							string str = stringBuilder.Append("0").ToString();
							SAHARA_MANAGER._pblInfo.msm_id = SAHARA_MANAGER._pblInfo.msm_id + str;
							flag5 = (SAHARA_MANAGER._pblInfo.msm_id.Length == 16);
						}
						while (!flag5);
					}
					Console.WriteLine(SAHARA_MANAGER._pblInfo.msm_id.ToLower() + "_" + SAHARA_MANAGER._pblInfo.pk_hash.Substring(0, 16).ToLower());
					string text3 = SAHARA_MANAGER._pblInfo.msm_id + "_" + SAHARA_MANAGER._pblInfo.pk_hash.Substring(0, 16);
					byte[] array3 = new byte[0];
					uiManager.logs("Downloading loader...", false, (uiManager.MessageType)uiManager.Hitam);
					array3 = FIREHOSE_MANAGER.GetFiles(text3.ToLower(), false);
					Main.OutDecripted = new byte[0];
					Main.OutDecripted = array3;
					bool flag6 = !Cryptography.CryptStream(Main.keyEncrypt, array3, false, "loader", 0L);
					if (flag6)
					{
						SAHARA_MANAGER.IsLoaderExist = false;
						uiManager.logs(" Not Found!", true, (uiManager.MessageType)uiManager.Merah);
					}
					else
					{
						bool flag7 = !Encoding.UTF8.GetString(SAHARA_MANAGER.loader).Contains("ELF");
						if (flag7)
						{
							SAHARA_MANAGER.IsLoaderExist = false;
						}
						else
						{
							SAHARA_MANAGER.IsLoaderExist = true;
							uiManager.logs(" OK", true, (uiManager.MessageType)uiManager.Hijau);
						}
					}
				}
			}
			bool flag8 = cmd == SAHARA.SAHARA_EXEC_CMD.SAHARA_EXEC_CMD_SERIAL_NUM_READ;
			if (flag8)
			{
				string text4 = BitConverter.ToString(array2).Replace("-", string.Empty);
				SAHARA_MANAGER._pblInfo.serial = text4;
				uiManager.logs("Serial Number: :", false, (uiManager.MessageType)uiManager.Hitam);
				uiManager.logs(text4, true, (uiManager.MessageType)uiManager.Kuning);
			}
		}

		// Token: 0x040000B6 RID: 182
		public static bool cpu64 = false;

		// Token: 0x040000B7 RID: 183
		public static SAHARA.SAHARA_PBL_INFO _pblInfo = default(SAHARA.SAHARA_PBL_INFO);

		// Token: 0x040000B8 RID: 184
		public static bool sendingloaderStatus;

		// Token: 0x040000B9 RID: 185
		public static bool IsLoaderExist = false;
	}
}
