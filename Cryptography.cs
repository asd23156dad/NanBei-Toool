using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using Microsoft.VisualBasic.CompilerServices;

namespace iReverse_Qualcomm_Tool_Lite
{
	// Token: 0x0200000F RID: 15
	public static class Cryptography
	{
		// Token: 0x060000AB RID: 171 RVA: 0x00012680 File Offset: 0x00010880
		public static string Base64Encode(string plainText)
		{
			byte[] bytes = Encoding.UTF8.GetBytes(plainText);
			return Convert.ToBase64String(bytes);
		}

		// Token: 0x060000AC RID: 172 RVA: 0x000126A4 File Offset: 0x000108A4
		public static string Base64Decode(string base64EncodedData)
		{
			byte[] bytes = Convert.FromBase64String(base64EncodedData);
			return Encoding.UTF8.GetString(bytes);
		}

		// Token: 0x060000AD RID: 173 RVA: 0x000126C8 File Offset: 0x000108C8
		public static void EncryptFile(string password, byte[] in_file, string Filenya)
		{
			Cryptography.CryptFile(password, in_file, Main.OutDecripted, true, Filenya);
		}

		// Token: 0x060000AE RID: 174 RVA: 0x000126DA File Offset: 0x000108DA
		public static void DecryptFile(string password, byte[] in_file, string FileNYa)
		{
			Cryptography.CryptFile(password, in_file, Main.OutDecripted, false, FileNYa);
		}

		// Token: 0x060000AF RID: 175 RVA: 0x000126EC File Offset: 0x000108EC
		public static void CryptFile(string password, byte[] in_file, byte[] out_file, bool encrypt, string Filenya)
		{
			using (new MemoryStream(in_file))
			{
				using (new MemoryStream(Main.OutDecripted))
				{
					Cryptography.CryptStream(password, in_file, encrypt, Filenya, 0L);
				}
			}
		}

		// Token: 0x060000B0 RID: 176 RVA: 0x00012750 File Offset: 0x00010950
		public static bool CryptStream(string password, byte[] in_stream, bool encrypt, string Filenya, long PanjangFile)
		{
			bool flag = string.IsNullOrEmpty(Filenya);
			if (flag)
			{
				throw new ArgumentException("'Filenya' cannot be null or empty.", "Filenya");
			}
			bool flag2 = in_stream == null;
			if (flag2)
			{
				throw new ArgumentNullException("in_stream");
			}
			bool flag3 = string.IsNullOrEmpty(password);
			if (flag3)
			{
				throw new ArgumentException("'password' cannot be null or empty.", "password");
			}
			AesCryptoServiceProvider aesCryptoServiceProvider = new AesCryptoServiceProvider();
			int num = 0;
			int num2 = 1024;
			checked
			{
				for (;;)
				{
					bool flag4 = !aesCryptoServiceProvider.ValidKeySize(num2);
					if (!flag4)
					{
						break;
					}
					num2 += -1;
					if (num2 < 1)
					{
						goto IL_8C;
					}
				}
				num = num2;
				IL_8C:
				Debug.Assert(num > 0);
				Console.WriteLine("Key size: " + Conversions.ToString(num));
				int blockSize = aesCryptoServiceProvider.BlockSize;
				byte[] rgbKey = new byte[0];
				byte[] rgbIV = new byte[0];
				byte[] salt = new byte[]
				{
					0,
					0,
					1,
					2,
					3,
					4,
					5,
					6,
					241,
					240,
					238,
					33,
					34,
					69
				};
				Cryptography.MakeKeyAndIV(password, salt, num, blockSize, ref rgbKey, ref rgbIV);
				ICryptoTransform cryptoTransform = (!encrypt) ? aesCryptoServiceProvider.CreateDecryptor(rgbKey, rgbIV) : aesCryptoServiceProvider.CreateEncryptor(rgbKey, rgbIV);
				MemoryStream memoryStream = new MemoryStream();
				MemoryStream stream = new MemoryStream(Main.OutDecripted);
				long num3 = 0L;
				bool result;
				try
				{
					using (MemoryStream memoryStream2 = new MemoryStream(in_stream))
					{
						using (CryptoStream cryptoStream = new CryptoStream(stream, cryptoTransform, CryptoStreamMode.Write))
						{
							byte[] buffer = new byte[1025];
							for (;;)
							{
								int num4 = memoryStream2.Read(buffer, 0, 1024);
								num3 += unchecked((long)num4);
								bool flag5 = num4 == 0;
								if (flag5)
								{
									break;
								}
								cryptoStream.Write(buffer, 0, num4);
							}
						}
					}
					bool flag6 = Operators.CompareString(Filenya, "loader", false) == 0;
					if (flag6)
					{
						SAHARA_MANAGER.loader = Cryptography.GetRawData(Main.OutDecripted.Take(Convert.ToInt32(num3)).ToArray<byte>());
					}
					cryptoTransform.Dispose();
					result = true;
				}
				catch (Exception ex)
				{
					Exception ex2 = ex;
					cryptoTransform.Dispose();
					uiManager.logs(ex2.ToString(), true, (uiManager.MessageType)uiManager.Merah);
					result = false;
				}
				return result;
			}
		}

		// Token: 0x060000B1 RID: 177 RVA: 0x000129A0 File Offset: 0x00010BA0
		public static int FilterData(byte[] inputdata)
		{
			byte[] array = new byte[4];
			Stream stream = new MemoryStream(inputdata);
			int num = 0;
			for (;;)
			{
				stream.Seek((long)num, SeekOrigin.Begin);
				stream.Read(array, 0, array.Length);
				bool flag = Encoding.UTF8.GetString(array).ToLower().Contains("<?x");
				if (flag)
				{
					break;
				}
				checked
				{
					num++;
				}
			}
			return num;
		}

		// Token: 0x060000B2 RID: 178 RVA: 0x00012A08 File Offset: 0x00010C08
		public static byte[] GetRawData(byte[] inputdata)
		{
			byte[] array = new byte[5];
			Stream stream = new MemoryStream(inputdata);
			int num = 0;
			checked
			{
				for (;;)
				{
					stream.Seek(unchecked((long)(checked(inputdata.Length - num))), SeekOrigin.Begin);
					stream.Read(array, 0, array.Length);
					bool flag = Operators.CompareString(Encoding.UTF8.GetString(array), "EndCF", false) == 0;
					if (flag)
					{
						break;
					}
					num++;
				}
				return inputdata.Take(inputdata.Length - num).ToArray<byte>();
			}
		}

		// Token: 0x060000B3 RID: 179 RVA: 0x00012A88 File Offset: 0x00010C88
		public static void MakeKeyAndIV(string password, byte[] salt, int key_size_bits, int block_size_bits, ref byte[] key, ref byte[] iv)
		{
			Rfc2898DeriveBytes rfc2898DeriveBytes = new Rfc2898DeriveBytes(password, salt, 1000);
			key = rfc2898DeriveBytes.GetBytes(Convert.ToInt32((double)key_size_bits / 8.0));
			iv = rfc2898DeriveBytes.GetBytes(Convert.ToInt32((double)block_size_bits / 8.0));
		}
	}
}
