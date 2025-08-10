using System;
using System.Globalization;

// Token: 0x02000002 RID: 2
public static class NumericHelper
{
	// Token: 0x06000001 RID: 1 RVA: 0x00002050 File Offset: 0x00000250
	public static bool IsNumeric(object expression)
	{
		bool flag = expression == null;
		bool result;
		if (flag)
		{
			result = false;
		}
		else
		{
			bool flag2 = expression is string;
			if (flag2)
			{
				bool flag3 = ((string)expression).StartsWith("$");
				CultureInfo provider;
				if (flag3)
				{
					provider = new CultureInfo("en-US");
				}
				else
				{
					provider = CultureInfo.InvariantCulture;
				}
				double num;
				bool flag4 = double.TryParse((string)expression, NumberStyles.Any, provider, out num);
				if (flag4)
				{
					return true;
				}
			}
			else
			{
				double num;
				bool flag5 = double.TryParse(expression.ToString(), out num);
				if (flag5)
				{
					return true;
				}
			}
			bool flag7;
			bool flag6 = bool.TryParse(expression.ToString(), out flag7);
			result = flag6;
		}
		return result;
	}

	// Token: 0x06000002 RID: 2 RVA: 0x00002100 File Offset: 0x00000300
	public static double Val(string expression)
	{
		bool flag = expression == null;
		checked
		{
			double result;
			if (flag)
			{
				result = 0.0;
			}
			else
			{
				for (int i = expression.Length; i > 0; i--)
				{
					double result2;
					bool flag2 = double.TryParse(expression.Substring(0, i), out result2);
					if (flag2)
					{
						return result2;
					}
				}
				result = 0.0;
			}
			return result;
		}
	}

	// Token: 0x06000003 RID: 3 RVA: 0x00002164 File Offset: 0x00000364
	public static double Val(object expression)
	{
		bool flag = expression == null;
		double result;
		if (flag)
		{
			result = 0.0;
		}
		else
		{
			double num;
			bool flag2 = double.TryParse(expression.ToString(), out num);
			if (flag2)
			{
				result = num;
			}
			else
			{
				bool flag4;
				bool flag3 = bool.TryParse(expression.ToString(), out flag4);
				if (flag3)
				{
					result = (double)(flag4 ? -1 : 0);
				}
				else
				{
					DateTime dateTime;
					bool flag5 = DateTime.TryParse(expression.ToString(), out dateTime);
					if (flag5)
					{
						result = (double)dateTime.Day;
					}
					else
					{
						result = 0.0;
					}
				}
			}
		}
		return result;
	}

	// Token: 0x06000004 RID: 4 RVA: 0x000021EC File Offset: 0x000003EC
	public static int Val(char expression)
	{
		int num;
		bool flag = int.TryParse(expression.ToString(), out num);
		int result;
		if (flag)
		{
			result = num;
		}
		else
		{
			result = 0;
		}
		return result;
	}
}
