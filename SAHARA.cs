using System;

namespace iReverse_Qualcomm_Tool_Lite
{
	// Token: 0x0200000D RID: 13
	internal static class SAHARA
	{
		// Token: 0x02000036 RID: 54
		[Serializable]
		public struct SAHARA_REQUESTS_HELLO
		{
			// Token: 0x0400016E RID: 366
			public SAHARA.SAHARA_HEADER header;

			// Token: 0x0400016F RID: 367
			public int version;

			// Token: 0x04000170 RID: 368
			public int minVersion;

			// Token: 0x04000171 RID: 369
			public int maxCommandPacketSize;

			// Token: 0x04000172 RID: 370
			public SAHARA.SAHARA_MODE mode;

			// Token: 0x04000173 RID: 371
			public int res1;

			// Token: 0x04000174 RID: 372
			public int res2;

			// Token: 0x04000175 RID: 373
			public int res3;

			// Token: 0x04000176 RID: 374
			public int res4;

			// Token: 0x04000177 RID: 375
			public int res5;

			// Token: 0x04000178 RID: 376
			public int res6;
		}

		// Token: 0x02000037 RID: 55
		public struct SAHARA_HEADER
		{
			// Token: 0x04000179 RID: 377
			public SAHARA.SAHARA_CMD command;

			// Token: 0x0400017A RID: 378
			public int size;
		}

		// Token: 0x02000038 RID: 56
		public struct SAHARA_HEADER64
		{
			// Token: 0x0400017B RID: 379
			public SAHARA.SAHARA_CMD command;

			// Token: 0x0400017C RID: 380
			public int size;
		}

		// Token: 0x02000039 RID: 57
		public struct SAHARA_PBL_INFO
		{
			// Token: 0x0400017D RID: 381
			public string serial;

			// Token: 0x0400017E RID: 382
			public string msm_id;

			// Token: 0x0400017F RID: 383
			public string pk_hash;

			// Token: 0x04000180 RID: 384
			public int pbl_sw;
		}

		// Token: 0x0200003A RID: 58
		public enum SAHARA_MODE
		{
			// Token: 0x04000182 RID: 386
			SAHARA_MODE_IMAGE_PENDING,
			// Token: 0x04000183 RID: 387
			SAHARA_MODE_IMAGE_TX_COMPLETE,
			// Token: 0x04000184 RID: 388
			SAHARA_MODE_MEMDEBUG,
			// Token: 0x04000185 RID: 389
			SAHARA_MODE_COMMAND
		}

		// Token: 0x0200003B RID: 59
		public enum SAHARA_EXEC_CMD
		{
			// Token: 0x04000187 RID: 391
			SAHARA_EXEC_CMD_NOP,
			// Token: 0x04000188 RID: 392
			SAHARA_EXEC_CMD_SERIAL_NUM_READ,
			// Token: 0x04000189 RID: 393
			SAHARA_EXEC_CMD_MSM_HW_ID_READ,
			// Token: 0x0400018A RID: 394
			SAHARA_EXEC_CMD_OEM_PK_HASH_READ,
			// Token: 0x0400018B RID: 395
			SAHARA_EXEC_CMD_SWITCH_TO_DMSS_DLOAD,
			// Token: 0x0400018C RID: 396
			SAHARA_EXEC_CMD_SWITCH_TO_STREAM_DLOAD,
			// Token: 0x0400018D RID: 397
			SAHARA_EXEC_CMD_READ_DEBUG_DATA,
			// Token: 0x0400018E RID: 398
			SAHARA_EXEC_CMD_GET_SOFTWARE_VERSION_SBL,
			// Token: 0x0400018F RID: 399
			SAHARA_EXEC_CMD_LAST,
			// Token: 0x04000190 RID: 400
			SAHARA_EXEC_CMD_MAX = 2147483647
		}

		// Token: 0x0200003C RID: 60
		public struct SAHARA_REQUESTS_END_IMG_TRSFR_PACKET
		{
			// Token: 0x04000191 RID: 401
			public SAHARA.SAHARA_HEADER header;

			// Token: 0x04000192 RID: 402
			public int image_id;

			// Token: 0x04000193 RID: 403
			public int status;
		}

		// Token: 0x0200003D RID: 61
		public struct SAHARA_SWITCH_PACKET
		{
			// Token: 0x04000194 RID: 404
			public SAHARA.SAHARA_HEADER header;

			// Token: 0x04000195 RID: 405
			public SAHARA.SAHARA_MODE mode;
		}

		// Token: 0x0200003E RID: 62
		public struct SAHARA_REQUESTS_IMGDONE_PACKET
		{
			// Token: 0x04000196 RID: 406
			public SAHARA.SAHARA_HEADER header;
		}

		// Token: 0x0200003F RID: 63
		public struct SAHARA_RESPONSE_IMGDONE_PACKET
		{
			// Token: 0x04000197 RID: 407
			public SAHARA.SAHARA_HEADER header;

			// Token: 0x04000198 RID: 408
			public SAHARA.SAHARA_STATUS status;
		}

		// Token: 0x02000040 RID: 64
		public struct SAHARA_RESPONSE_IMGDONE_PACKET64
		{
			// Token: 0x04000199 RID: 409
			public SAHARA.SAHARA_HEADER64 header;

			// Token: 0x0400019A RID: 410
			public SAHARA.SAHARA_STATUS status;
		}

		// Token: 0x02000041 RID: 65
		public enum SAHARA_CMD
		{
			// Token: 0x0400019C RID: 412
			SAHARA_CMD_HELLO_REQ = 1,
			// Token: 0x0400019D RID: 413
			SAHARA_CMD_HELLO_RESP,
			// Token: 0x0400019E RID: 414
			SAHARA_CMD_READ_DATA,
			// Token: 0x0400019F RID: 415
			SAHARA_CMD_IMG_END_TRSFR,
			// Token: 0x040001A0 RID: 416
			SAHARA_CMD_IMG_DONE_REQ,
			// Token: 0x040001A1 RID: 417
			SAHARA_CMD_IMG_DONE_RESP,
			// Token: 0x040001A2 RID: 418
			SAHARA_RESET_REQ,
			// Token: 0x040001A3 RID: 419
			SAHARA_RESET_RSP,
			// Token: 0x040001A4 RID: 420
			SAHARA_MEMORY_DEBUG,
			// Token: 0x040001A5 RID: 421
			SAHARA_CMD_EXECUTE_REQ = 13,
			// Token: 0x040001A6 RID: 422
			SAHARA_CMD_EXECUTE_RESPONSE,
			// Token: 0x040001A7 RID: 423
			SAHARA_CMD_EXECUTE_DATA,
			// Token: 0x040001A8 RID: 424
			SAHARA_MEMORY_READ = 10,
			// Token: 0x040001A9 RID: 425
			SAHARA_CMD_READY,
			// Token: 0x040001AA RID: 426
			SAHARA_CMD_SWITCH_MODE,
			// Token: 0x040001AB RID: 427
			SAHARA_EXECUTE_REQ,
			// Token: 0x040001AC RID: 428
			SAHARA_EXECUTE_RSP,
			// Token: 0x040001AD RID: 429
			SAHARA_EXECUTE_DATA,
			// Token: 0x040001AE RID: 430
			SAHARA_64BIT_MEMORY_DEBUG,
			// Token: 0x040001AF RID: 431
			SAHARA_64BIT_MEMORY_READ,
			// Token: 0x040001B0 RID: 432
			SAHARA_64BIT_MEMORY_READ_DATA
		}

		// Token: 0x02000042 RID: 66
		public enum SAHARA_IMAGE_ID
		{
			// Token: 0x040001B2 RID: 434
			kMbnImageNone,
			// Token: 0x040001B3 RID: 435
			kMbnImageOemSbl,
			// Token: 0x040001B4 RID: 436
			kMbnImageAmss,
			// Token: 0x040001B5 RID: 437
			kMbnImageOcbl,
			// Token: 0x040001B6 RID: 438
			kMbnImageHash,
			// Token: 0x040001B7 RID: 439
			kMbnImageAppbl,
			// Token: 0x040001B8 RID: 440
			kMbnImageApps,
			// Token: 0x040001B9 RID: 441
			kMbnImageHostDl,
			// Token: 0x040001BA RID: 442
			kMbnImageDsp1,
			// Token: 0x040001BB RID: 443
			kMbnImageFsbl,
			// Token: 0x040001BC RID: 444
			kMbnImageDbl,
			// Token: 0x040001BD RID: 445
			kMbnImageOsbl,
			// Token: 0x040001BE RID: 446
			kMbnImageDsp2,
			// Token: 0x040001BF RID: 447
			kMbnImageEhostdl,
			// Token: 0x040001C0 RID: 448
			SAHARA_IMAGE_FIREHOSE,
			// Token: 0x040001C1 RID: 449
			kMbnImageNorprg,
			// Token: 0x040001C2 RID: 450
			kMbnImageRamfs1,
			// Token: 0x040001C3 RID: 451
			kMbnImageRamfs2,
			// Token: 0x040001C4 RID: 452
			kMbnImageAdspQ5,
			// Token: 0x040001C5 RID: 453
			kMbnImageAppsKernel,
			// Token: 0x040001C6 RID: 454
			kMbnImageBackupRamfs,
			// Token: 0x040001C7 RID: 455
			kMbnImageSbl1,
			// Token: 0x040001C8 RID: 456
			kMbnImageSbl2,
			// Token: 0x040001C9 RID: 457
			kMbnImageRpm,
			// Token: 0x040001CA RID: 458
			kMbnImageSbl3,
			// Token: 0x040001CB RID: 459
			kMbnImageTz,
			// Token: 0x040001CC RID: 460
			kMbnImageSsdKeys,
			// Token: 0x040001CD RID: 461
			kMbnImageGen,
			// Token: 0x040001CE RID: 462
			kMbnImageDsp3,
			// Token: 0x040001CF RID: 463
			kMbnImageAcdb,
			// Token: 0x040001D0 RID: 464
			kMbnImageWdt,
			// Token: 0x040001D1 RID: 465
			kMbnImageMba,
			// Token: 0x040001D2 RID: 466
			kMbnImageLast = 31
		}

		// Token: 0x02000043 RID: 67
		public struct SAHARA_REQUESTS_READDATA
		{
			// Token: 0x040001D3 RID: 467
			public SAHARA.SAHARA_HEADER header;

			// Token: 0x040001D4 RID: 468
			public SAHARA.SAHARA_IMAGE_ID imageID;

			// Token: 0x040001D5 RID: 469
			public int offset;

			// Token: 0x040001D6 RID: 470
			public int size;
		}

		// Token: 0x02000044 RID: 68
		public struct SAHARA_REQUESTS_READDATA_64
		{
			// Token: 0x040001D7 RID: 471
			public SAHARA.SAHARA_HEADER header;

			// Token: 0x040001D8 RID: 472
			public SAHARA.SAHARA_IMAGE_ID imageID;

			// Token: 0x040001D9 RID: 473
			public long offset;

			// Token: 0x040001DA RID: 474
			public long size;
		}

		// Token: 0x02000045 RID: 69
		public struct SAHARA_REQUESTS_IMG_DONE
		{
			// Token: 0x040001DB RID: 475
			public SAHARA.SAHARA_HEADER header;
		}

		// Token: 0x02000046 RID: 70
		public struct SAHARA_REQUESTS_IMG_DONE64
		{
			// Token: 0x040001DC RID: 476
			public SAHARA.SAHARA_HEADER64 header;
		}

		// Token: 0x02000047 RID: 71
		public struct SAHARA_RESPONSE_HELLO
		{
			// Token: 0x040001DD RID: 477
			public SAHARA.SAHARA_HEADER header;

			// Token: 0x040001DE RID: 478
			public int version;

			// Token: 0x040001DF RID: 479
			public int minVersion;

			// Token: 0x040001E0 RID: 480
			public int status;

			// Token: 0x040001E1 RID: 481
			public SAHARA.SAHARA_MODE mode;

			// Token: 0x040001E2 RID: 482
			public int res1;

			// Token: 0x040001E3 RID: 483
			public int res2;

			// Token: 0x040001E4 RID: 484
			public int res3;

			// Token: 0x040001E5 RID: 485
			public int res4;

			// Token: 0x040001E6 RID: 486
			public int res5;

			// Token: 0x040001E7 RID: 487
			public int res6;
		}

		// Token: 0x02000048 RID: 72
		public struct SAHARA_RESPONSE_EXECCMD_RESPONSE
		{
			// Token: 0x040001E8 RID: 488
			public SAHARA.SAHARA_HEADER header;

			// Token: 0x040001E9 RID: 489
			public SAHARA.SAHARA_EXEC_CMD cmd;

			// Token: 0x040001EA RID: 490
			public int size;
		}

		// Token: 0x02000049 RID: 73
		public struct SAHARA_REQUEST_EXE_CMD
		{
			// Token: 0x040001EB RID: 491
			public SAHARA.SAHARA_HEADER header;

			// Token: 0x040001EC RID: 492
			public SAHARA.SAHARA_EXEC_CMD clientCmd;
		}

		// Token: 0x0200004A RID: 74
		public enum SAHARA_STATUS64
		{
			// Token: 0x040001EE RID: 494
			SAHARA_STATUS_SUCCESS = 1,
			// Token: 0x040001EF RID: 495
			SAHARA_NAK_INVALID_CMD = 0,
			// Token: 0x040001F0 RID: 496
			SAHARA_NAK_PROTOCOL_MISMATCH = 2,
			// Token: 0x040001F1 RID: 497
			SAHARA_NAK_INVALID_TARGET_PROTOCOL,
			// Token: 0x040001F2 RID: 498
			SAHARA_NAK_INVALID_HOST_PROTOCOL,
			// Token: 0x040001F3 RID: 499
			SAHARA_NAK_INVALID_PACKET_SIZE,
			// Token: 0x040001F4 RID: 500
			SAHARA_NAK_UNEXPECTED_IMAGE_ID,
			// Token: 0x040001F5 RID: 501
			SAHARA_NAK_INVALID_HEADER_SIZE,
			// Token: 0x040001F6 RID: 502
			SAHARA_NAK_INVALID_DATA_SIZE,
			// Token: 0x040001F7 RID: 503
			SAHARA_NAK_INVALID_IMAGE_TYPE,
			// Token: 0x040001F8 RID: 504
			SAHARA_NAK_INVALID_TX_LENGTH,
			// Token: 0x040001F9 RID: 505
			SAHARA_NAK_INVALID_RX_LENGTH,
			// Token: 0x040001FA RID: 506
			SAHARA_NAK_GENERAL_TX_RX_ERROR,
			// Token: 0x040001FB RID: 507
			SAHARA_NAK_READ_DATA_ERROR,
			// Token: 0x040001FC RID: 508
			SAHARA_NAK_UNSUPPORTED_NUM_PHDRS,
			// Token: 0x040001FD RID: 509
			SAHARA_NAK_INVALID_PDHR_SIZE,
			// Token: 0x040001FE RID: 510
			SAHARA_NAK_MULTIPLE_SHARED_SEG,
			// Token: 0x040001FF RID: 511
			SAHARA_NAK_UNINIT_PHDR_LOC,
			// Token: 0x04000200 RID: 512
			SAHARA_NAK_INVALID_DEST_ADDR,
			// Token: 0x04000201 RID: 513
			SAHARA_NAK_INVALID_IMG_HDR_DATA_SIZE,
			// Token: 0x04000202 RID: 514
			SAHARA_NAK_INVALID_ELF_HDR,
			// Token: 0x04000203 RID: 515
			SAHARA_NAK_UNKNOWN_HOST_ERROR,
			// Token: 0x04000204 RID: 516
			SAHARA_NAK_TIMEOUT_RX,
			// Token: 0x04000205 RID: 517
			SAHARA_NAK_TIMEOUT_TX,
			// Token: 0x04000206 RID: 518
			SAHARA_NAK_INVALID_HOST_MODE,
			// Token: 0x04000207 RID: 519
			SAHARA_NAK_INVALID_MEMORY_READ,
			// Token: 0x04000208 RID: 520
			SAHARA_NAK_INVALID_DATA_SIZE_REQUEST,
			// Token: 0x04000209 RID: 521
			SAHARA_NAK_MEMORY_DEBUG_NOT_SUPPORTED,
			// Token: 0x0400020A RID: 522
			SAHARA_NAK_INVALID_MODE_SWITCH,
			// Token: 0x0400020B RID: 523
			SAHARA_NAK_CMD_EXEC_FAILURE,
			// Token: 0x0400020C RID: 524
			SAHARA_NAK_EXEC_CMD_INVALID_PARAM,
			// Token: 0x0400020D RID: 525
			SAHARA_NAK_EXEC_CMD_UNSUPPORTED,
			// Token: 0x0400020E RID: 526
			SAHARA_NAK_EXEC_DATA_INVALID_CLIENT_CMD,
			// Token: 0x0400020F RID: 527
			SAHARA_NAK_HASH_TABLE_AUTH_FAILURE,
			// Token: 0x04000210 RID: 528
			SAHARA_NAK_HASH_VERIFICATION_FAILURE,
			// Token: 0x04000211 RID: 529
			SAHARA_NAK_HASH_TABLE_NOT_FOUND,
			// Token: 0x04000212 RID: 530
			SAHARA_NAK_LAST_CODE,
			// Token: 0x04000213 RID: 531
			SAHARA_NAK_MAX_CODE = 2147483647
		}

		// Token: 0x0200004B RID: 75
		public enum SAHARA_STATUS
		{
			// Token: 0x04000215 RID: 533
			SAHARA_STATUS_32,
			// Token: 0x04000216 RID: 534
			SAHARA_STATUS_64,
			// Token: 0x04000217 RID: 535
			SAHARA_NAK_PROTOCOL_MISMATCH,
			// Token: 0x04000218 RID: 536
			SAHARA_NAK_INVALID_TARGET_PROTOCOL,
			// Token: 0x04000219 RID: 537
			SAHARA_NAK_INVALID_HOST_PROTOCOL,
			// Token: 0x0400021A RID: 538
			SAHARA_NAK_INVALID_PACKET_SIZE,
			// Token: 0x0400021B RID: 539
			SAHARA_NAK_UNEXPECTED_IMAGE_ID,
			// Token: 0x0400021C RID: 540
			SAHARA_NAK_INVALID_HEADER_SIZE,
			// Token: 0x0400021D RID: 541
			SAHARA_NAK_INVALID_DATA_SIZE,
			// Token: 0x0400021E RID: 542
			SAHARA_NAK_INVALID_IMAGE_TYPE,
			// Token: 0x0400021F RID: 543
			SAHARA_NAK_INVALID_TX_LENGTH,
			// Token: 0x04000220 RID: 544
			SAHARA_NAK_INVALID_RX_LENGTH,
			// Token: 0x04000221 RID: 545
			SAHARA_NAK_GENERAL_TX_RX_ERROR,
			// Token: 0x04000222 RID: 546
			SAHARA_NAK_READ_DATA_ERROR,
			// Token: 0x04000223 RID: 547
			SAHARA_NAK_UNSUPPORTED_NUM_PHDRS,
			// Token: 0x04000224 RID: 548
			SAHARA_NAK_INVALID_PDHR_SIZE,
			// Token: 0x04000225 RID: 549
			SAHARA_NAK_MULTIPLE_SHARED_SEG,
			// Token: 0x04000226 RID: 550
			SAHARA_NAK_UNINIT_PHDR_LOC,
			// Token: 0x04000227 RID: 551
			SAHARA_NAK_INVALID_DEST_ADDR,
			// Token: 0x04000228 RID: 552
			SAHARA_NAK_INVALID_IMG_HDR_DATA_SIZE,
			// Token: 0x04000229 RID: 553
			SAHARA_NAK_INVALID_ELF_HDR,
			// Token: 0x0400022A RID: 554
			SAHARA_NAK_UNKNOWN_HOST_ERROR,
			// Token: 0x0400022B RID: 555
			SAHARA_NAK_TIMEOUT_RX,
			// Token: 0x0400022C RID: 556
			SAHARA_NAK_TIMEOUT_TX,
			// Token: 0x0400022D RID: 557
			SAHARA_NAK_INVALID_HOST_MODE,
			// Token: 0x0400022E RID: 558
			SAHARA_NAK_INVALID_MEMORY_READ,
			// Token: 0x0400022F RID: 559
			SAHARA_NAK_INVALID_DATA_SIZE_REQUEST,
			// Token: 0x04000230 RID: 560
			SAHARA_NAK_MEMORY_DEBUG_NOT_SUPPORTED,
			// Token: 0x04000231 RID: 561
			SAHARA_NAK_INVALID_MODE_SWITCH,
			// Token: 0x04000232 RID: 562
			SAHARA_NAK_CMD_EXEC_FAILURE,
			// Token: 0x04000233 RID: 563
			SAHARA_NAK_EXEC_CMD_INVALID_PARAM,
			// Token: 0x04000234 RID: 564
			SAHARA_NAK_EXEC_CMD_UNSUPPORTED,
			// Token: 0x04000235 RID: 565
			SAHARA_NAK_EXEC_DATA_INVALID_CLIENT_CMD,
			// Token: 0x04000236 RID: 566
			SAHARA_NAK_HASH_TABLE_AUTH_FAILURE,
			// Token: 0x04000237 RID: 567
			SAHARA_NAK_HASH_VERIFICATION_FAILURE,
			// Token: 0x04000238 RID: 568
			SAHARA_NAK_HASH_TABLE_NOT_FOUND,
			// Token: 0x04000239 RID: 569
			SAHARA_NAK_LAST_CODE,
			// Token: 0x0400023A RID: 570
			SAHARA_NAK_MAX_CODE = 2147483647
		}
	}
}
