using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace iReverse_Qualcomm_Tool_Lite
{
	// Token: 0x0200000C RID: 12
	internal static class FIREHOSE
	{
		// Token: 0x0600008A RID: 138 RVA: 0x00010C24 File Offset: 0x0000EE24
		public static FIREHOSE.SPARSE_HEADER parsingheader(byte[] bytes)
		{
			GCHandle gchandle = GCHandle.Alloc(bytes, GCHandleType.Pinned);
			FIREHOSE.SPARSE_HEADER result = default(FIREHOSE.SPARSE_HEADER);
			try
			{
				object obj = Marshal.PtrToStructure(gchandle.AddrOfPinnedObject(), typeof(FIREHOSE.SPARSE_HEADER));
				result = ((obj != null) ? ((FIREHOSE.SPARSE_HEADER)obj) : default(FIREHOSE.SPARSE_HEADER));
			}
			finally
			{
				gchandle.Free();
			}
			return result;
		}

		// Token: 0x0600008B RID: 139 RVA: 0x00010C94 File Offset: 0x0000EE94
		public static string pkt_fhConfig(string MemName)
		{
			FIREHOSE.FIREHOSE_CONFIG firehose_CONFIG = new FIREHOSE.FIREHOSE_CONFIG
			{
				Version = 4,
				MemoryName = MemName,
				SkipWrite = 0,
				ZLPAwareHost = 1,
				SkipStorageInit = 0,
				ActivePartition = 0,
				MaxPayloadSizeToTargetInBytes = 8192,
				AckRawDataEveryNumPackets = 1
			};
			return string.Format("<?xml version = \"1.0\"?><data><configure MemoryName=\"{0}\" ZLPAwareHost=\"{1}\" SkipStorageInit=\"{2}\" SkipWrite=\"{3}\" MaxPayloadSizeToTargetInBytes=\"{4}\"/></data>", new object[]
			{
				firehose_CONFIG.MemoryName,
				firehose_CONFIG.ZLPAwareHost,
				firehose_CONFIG.SkipStorageInit,
				firehose_CONFIG.SkipWrite.ToString(),
				firehose_CONFIG.MaxPayloadSizeToTargetInBytes
			});
		}

		// Token: 0x0600008C RID: 140 RVA: 0x00010D50 File Offset: 0x0000EF50
		public static string pkt_setAckRaw(int val)
		{
			return string.Format("<?xml version=\"1.0\" ?><data><configure AckRawData=\"{0}\"/></data>", val);
		}

		// Token: 0x0600008D RID: 141 RVA: 0x00010D74 File Offset: 0x0000EF74
		public static string pkt_peekMem(uint address64, int size)
		{
			return string.Format(" <?xml version=\"1.0\" ?><data><peek address64=\"{0}\" SizeInBytes=\"{1}\"/></data>", address64, size);
		}

		// Token: 0x0600008E RID: 142 RVA: 0x00010DA0 File Offset: 0x0000EFA0
		public static string pkt_eMMCinfo(string drive)
		{
			return "<?xml version=\"1.0\" ?><data><getstorageinfo physical_partition_number=\"" + drive + "\"/></data>";
		}

		// Token: 0x0600008F RID: 143 RVA: 0x00010DC4 File Offset: 0x0000EFC4
		public static string pkt_ProgramUFS(int nPartSectors, string fileName, int startSector, int lun)
		{
			return string.Format(" <?xml version=\"1.0\" ?><data><program SECTOR_SIZE_IN_BYTES=\"4096\" filename=\"{0}\" num_partition_sectors=\"{1}\" physical_partition_number=\"0\" start_sector=\"{2}\"/></data>", fileName, nPartSectors, lun.ToString());
		}

		// Token: 0x06000090 RID: 144 RVA: 0x00010DF0 File Offset: 0x0000EFF0
		public static string BootConf()
		{
			return "<?xml version=\"1.0\" ?><data><setbootablestoragedrive value=\"0\" /></data>";
		}

		// Token: 0x06000091 RID: 145 RVA: 0x00010E0C File Offset: 0x0000F00C
		public static string pkt_readSecBoot()
		{
			return "<?xml version=\"1.0\" ?><data><getSecureBootStatus/></data>";
		}

		// Token: 0x06000092 RID: 146 RVA: 0x00010E28 File Offset: 0x0000F028
		public static string pkt_readSerialNumber()
		{
			return "<?xml version=\"1.0\" ?><data><getserialnum /></data>";
		}

		// Token: 0x06000093 RID: 147 RVA: 0x00010E44 File Offset: 0x0000F044
		public static string pkt_readIMEI()
		{
			return "<?xml version=\"1.0\" ?><data><readIMEI len=\"32\"/></data>";
		}

		// Token: 0x06000094 RID: 148 RVA: 0x00010E60 File Offset: 0x0000F060
		public static string pkt_sendNop()
		{
			return "<?xml version=\"1.0\" ?><data><nop /></data>";
		}

		// Token: 0x06000095 RID: 149 RVA: 0x00010E7C File Offset: 0x0000F07C
		public static string pkt_sendReset()
		{
			return "<?xml version=\"1.0\" ?><data><power value=\"reset\"/></data>";
		}

		// Token: 0x06000096 RID: 150 RVA: 0x00010E98 File Offset: 0x0000F098
		public static string pkt_read(string sectorSize, string numPartitionSectors, string physicalPartNum, string startSector)
		{
			return string.Concat(new string[]
			{
				"<?xml version = \"1.0\"?><data><read SECTOR_SIZE_IN_BYTES=\"",
				sectorSize.ToString(),
				"\" num_partition_sectors=\"",
				numPartitionSectors.ToString(),
				"\" physical_partition_number=\"",
				physicalPartNum.ToString(),
				"\" start_sector=\"",
				startSector.ToString(),
				"\"/></data>"
			});
		}

		// Token: 0x06000097 RID: 151 RVA: 0x00010F04 File Offset: 0x0000F104
		public static string pkt_Program(string sectorsize, string NumPartitionSector, string PhysicalPartition, string StartSector)
		{
			return string.Concat(new string[]
			{
				"<?xml version = \"1.0\"?><data><program SECTOR_SIZE_IN_BYTES=\"",
				sectorsize.ToString(),
				"\" file_sector_offset=\"0\" num_partition_sectors=\"",
				NumPartitionSector.ToString(),
				"\"  physical_partition_number=\"",
				PhysicalPartition.ToString(),
				"\" start_sector=\"",
				StartSector.ToString(),
				"\"/></data>"
			});
		}

		// Token: 0x06000098 RID: 152 RVA: 0x00010F70 File Offset: 0x0000F170
		public static string pkt_patch(string SectorSize, string BytesOffset, string FileName, string PhysicalPartition, string SizeInBytes, string StartSector, string Value, string What)
		{
			return string.Concat(new string[]
			{
				"<?xml version = \"1.0\"?><data><patch SECTOR_SIZE_IN_BYTES=\"",
				SectorSize.ToString(),
				"\" byte_offset=\"",
				BytesOffset.ToString(),
				"\" filename=\"",
				FileName.ToString(),
				"\" physical_partition_number=\"",
				PhysicalPartition.ToString(),
				"\" size_in_bytes=\"",
				SizeInBytes.ToString(),
				"\" start_sector=\"",
				StartSector.ToString(),
				"\" value=\"",
				Value.ToString(),
				"\" what=\"",
				What.ToString(),
				"\"/></data>"
			});
		}

		// Token: 0x06000099 RID: 153 RVA: 0x0001102C File Offset: 0x0000F22C
		public static string pkt_erase(string sectorSize, string numPartitionSectors, string physicalPartNum, string startSector)
		{
			return string.Concat(new string[]
			{
				"<?xml version = \"1.0\"?><data><erase SECTOR_SIZE_IN_BYTES=\"",
				sectorSize.ToString(),
				"\" num_partition_sectors=\"",
				numPartitionSectors.ToString(),
				"\" physical_partition_number=\"",
				physicalPartNum.ToString(),
				"\" start_sector=\"",
				startSector.ToString(),
				"\"/></data>"
			});
		}

		// Token: 0x040000AD RID: 173
		public static FIREHOSE.CHUNK_HEADER chunkheader;

		// Token: 0x040000AE RID: 174
		public static FIREHOSE.SPARSE_HEADER sparseheader;

		// Token: 0x040000AF RID: 175
		public const long SPARSE_MAGIC = -316211398L;

		// Token: 0x040000B0 RID: 176
		public const long SPARSE_RAW_CHUNK = 969409L;

		// Token: 0x040000B1 RID: 177
		public const long SPARSE_FILL_CHUNK = 969410L;

		// Token: 0x040000B2 RID: 178
		public const long SPARSE_DONT_CARE = 969411L;

		// Token: 0x040000B3 RID: 179
		public static FIREHOSE.FIREHOSE_GPT gpt;

		// Token: 0x040000B4 RID: 180
		public static string xml;

		// Token: 0x02000030 RID: 48
		public struct CHUNK_HEADER
		{
			// Token: 0x04000141 RID: 321
			public short wChunkType;

			// Token: 0x04000142 RID: 322
			public short wReserved;

			// Token: 0x04000143 RID: 323
			public int dwChunkSize;

			// Token: 0x04000144 RID: 324
			public int dwTotalSize;
		}

		// Token: 0x02000031 RID: 49
		public struct SPARSE_HEADER
		{
			// Token: 0x04000145 RID: 325
			public int dwMagic;

			// Token: 0x04000146 RID: 326
			public short wVerMajor;

			// Token: 0x04000147 RID: 327
			public short wVerMinor;

			// Token: 0x04000148 RID: 328
			public short wSparseHeaderSize;

			// Token: 0x04000149 RID: 329
			public short wChunkHeaderSize;

			// Token: 0x0400014A RID: 330
			public int dwBlockSize;

			// Token: 0x0400014B RID: 331
			public int dwTotalBlocks;

			// Token: 0x0400014C RID: 332
			public int dwTotalChunks;

			// Token: 0x0400014D RID: 333
			public int dwImageChecksum;
		}

		// Token: 0x02000032 RID: 50
		public struct FIREHOSE_CONFIG
		{
			// Token: 0x0400014E RID: 334
			public int Version;

			// Token: 0x0400014F RID: 335
			public string MemoryName;

			// Token: 0x04000150 RID: 336
			public int SkipWrite;

			// Token: 0x04000151 RID: 337
			public int SkipStorageInit;

			// Token: 0x04000152 RID: 338
			public int ZLPAwareHost;

			// Token: 0x04000153 RID: 339
			public int ActivePartition;

			// Token: 0x04000154 RID: 340
			public int MaxPayloadSizeToTargetInBytes;

			// Token: 0x04000155 RID: 341
			public int AckRawDataEveryNumPackets;

			// Token: 0x04000156 RID: 342
			public int maxPayloadSizeFromTargetInBytes;
		}

		// Token: 0x02000033 RID: 51
		public struct FIREHOSE_GPT
		{
			// Token: 0x04000157 RID: 343
			public FIREHOSE.gpt_header header;

			// Token: 0x04000158 RID: 344
			public List<FIREHOSE.gpt_partition_entry> entries;
		}

		// Token: 0x02000034 RID: 52
		public struct gpt_partition_entry
		{
			// Token: 0x1700000D RID: 13
			// (get) Token: 0x06000125 RID: 293 RVA: 0x0001389C File Offset: 0x00011A9C
			public int num512Sectors
			{
				get
				{
					return checked(this.last_lba - this.first_lba + 1);
				}
			}

			// Token: 0x04000159 RID: 345
			public string partTypeGUID;

			// Token: 0x0400015A RID: 346
			public string partID;

			// Token: 0x0400015B RID: 347
			public int first_lba;

			// Token: 0x0400015C RID: 348
			public int last_lba;

			// Token: 0x0400015D RID: 349
			public byte[] flags;

			// Token: 0x0400015E RID: 350
			public string partName;
		}

		// Token: 0x02000035 RID: 53
		public struct gpt_header
		{
			// Token: 0x0400015F RID: 351
			public string signature;

			// Token: 0x04000160 RID: 352
			public int revision;

			// Token: 0x04000161 RID: 353
			public int header_size;

			// Token: 0x04000162 RID: 354
			public int crc_header;

			// Token: 0x04000163 RID: 355
			public int reserved;

			// Token: 0x04000164 RID: 356
			public int current_lba;

			// Token: 0x04000165 RID: 357
			public int backup_lba;

			// Token: 0x04000166 RID: 358
			public int first_usable_lba;

			// Token: 0x04000167 RID: 359
			public long last_usable_lba;

			// Token: 0x04000168 RID: 360
			public byte[] disk_guid;

			// Token: 0x04000169 RID: 361
			public int starting_lba_pe;

			// Token: 0x0400016A RID: 362
			public int number_partitions;

			// Token: 0x0400016B RID: 363
			public int size_partition_entries;

			// Token: 0x0400016C RID: 364
			public int crc_partition;

			// Token: 0x0400016D RID: 365
			public byte reserved2;
		}
	}
}
