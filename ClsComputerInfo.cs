using System;
using System.Management;
using Microsoft.VisualBasic.CompilerServices;

namespace iReverse_Qualcomm_Tool_Lite
{
	// Token: 0x02000006 RID: 6
	public class ClsComputerInfo
	{
		// Token: 0x06000034 RID: 52 RVA: 0x00009818 File Offset: 0x00007A18
		internal string GetProcessorId()
		{
			string result = string.Empty;
			using (ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher(new SelectQuery("Win32_processor")))
			{
				foreach (ManagementBaseObject managementBaseObject in managementObjectSearcher.Get())
				{
					result = ((ManagementObject)managementBaseObject)["processorId"].ToString();
				}
			}
			return result;
		}

		// Token: 0x06000035 RID: 53 RVA: 0x0000989C File Offset: 0x00007A9C
		internal string GetMACAddress()
		{
			ManagementClass managementClass = new ManagementClass("Win32_NetworkAdapterConfiguration");
			ManagementObjectCollection instances = managementClass.GetInstances();
			string text = string.Empty;
			try
			{
				foreach (ManagementBaseObject managementBaseObject in instances)
				{
					ManagementObject managementObject = (ManagementObject)managementBaseObject;
					bool flag = text.Equals(string.Empty);
					if (flag)
					{
						bool flag2 = Conversions.ToBoolean(managementObject["IPEnabled"]);
						if (flag2)
						{
							text = managementObject["MacAddress"].ToString();
						}
						managementObject.Dispose();
					}
					text = text.Replace(":", string.Empty);
				}
			}
			finally
			{
				ManagementObjectCollection.ManagementObjectEnumerator managementObjectEnumerator = null;
				bool flag3 = managementObjectEnumerator != null;
				if (flag3)
				{
					((IDisposable)managementObjectEnumerator).Dispose();
				}
			}
			return text;
		}

		// Token: 0x06000036 RID: 54 RVA: 0x00009990 File Offset: 0x00007B90
		internal string GetMotherBoardID()
		{
			string result = string.Empty;
			using (ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher(new SelectQuery("Win32_BaseBoard")))
			{
				foreach (ManagementBaseObject managementBaseObject in managementObjectSearcher.Get())
				{
					result = ((ManagementObject)managementBaseObject)["SerialNumber"].ToString();
				}
			}
			return result;
		}
	}
}
