using System;
using System.IO;
using System.Text;

namespace KKStudio.Tools
{
	public static class Logger
	{
		public static bool WriteToConsole { get; set; }
		public static bool WriteLogFile { get; set; }
		public static void Initialize(string logFilePath, string logFileName)
		{
			Logger.LogPath = logFilePath;
			Logger.LogFileName = logFileName;
		}

		public static void Log(LogLevel type, string data)
		{
			object obj = Logger.locker;
			lock (obj)
			{
				string logSign = "I";
				if (type == LogLevel.Warning)
				{
					logSign = "W";
				}
				else if (type == LogLevel.Error)
				{
					logSign = "E";
				}
				else if (type == LogLevel.Info)
				{
					logSign = "I";
				}
				if (Logger.WriteToConsole)
				{
					Console.WriteLine(data);
				}
				if (Logger.WriteLogFile)
				{
					try
					{
						// 写入日志文件，此部分为构造日志字符串
						StreamWriter streamWriter = new StreamWriter(Logger.LogPath + Logger.LogFileName, true);
						DateTime now = DateTime.Now;
						StringBuilder logMessageBuilder = new StringBuilder();
						logMessageBuilder.Append("[{logSign}] ");
						logMessageBuilder.Append(now.ToString("yyyy-MM-dd HH:mm:ss.fff"));
						logMessageBuilder.Append("    ");
						logMessageBuilder.Append(data);
						streamWriter.WriteLine(logMessageBuilder.ToString());
						streamWriter.Close();
					}
					catch
					{
					}
				}
			}
		}

		public static void Log(LogLevel type, string data, string fileName)
		{
			object obj = Logger.locker;
			lock (obj)
			{
				string logSign = "I";
				if (type == LogLevel.Warning)
				{
					logSign = "W";
				}
				else if (type == LogLevel.Error)
				{
					logSign = "E";
				}
				else if (type == LogLevel.Info)
				{
					logSign = "I";
				}
				if (Logger.WriteToConsole)
				{
					Console.WriteLine(data);
				}
				if (Logger.WriteLogFile)
				{
					try
					{
						StreamWriter streamWriter = new StreamWriter(Logger.LogPath + fileName, true);
						DateTime now = DateTime.Now;
						StringBuilder logMessageBuilder = new StringBuilder();
						logMessageBuilder.Append("[{logSign}] ");
						logMessageBuilder.Append(now.ToString("yyyy-MM-dd HH:mm:ss.fff"));
						logMessageBuilder.Append("    ");
						logMessageBuilder.Append(data);
						streamWriter.WriteLine(logMessageBuilder.ToString());
						streamWriter.Close();
					}
					catch
					{
					}
				}
			}
		}

		public static void Log(LogLevel type, string data, object f1)
		{
			object obj = Logger.locker;
			lock (obj)
			{
				if (Logger.WriteToConsole)
				{
					Console.WriteLine(data);
					
					if (Logger.WriteToConsole)
					{
						Console.WriteLine(data);
					}
				}
				string logSign = "I";
				if (type == LogLevel.Warning)
				{
					logSign = "W";
				}
				else if (type == LogLevel.Error)
				{
					logSign = "E";
				}
				else if (type == LogLevel.Info)
				{
					logSign = "I";
				}
				if (Logger.WriteLogFile)
				{
					try
					{
						StreamWriter streamWriter = new StreamWriter(Logger.LogPath + f1, true);
						DateTime now = DateTime.Now;
						StringBuilder logMessageBuilder = new StringBuilder();
						logMessageBuilder.Append("[{logSign}] ");
						logMessageBuilder.Append(now.ToString("yyyy-MM-dd HH:mm:ss.fff"));
						logMessageBuilder.Append("    ");
						logMessageBuilder.Append(string.Format(data, f1));
						streamWriter.WriteLine(logMessageBuilder.ToString());
						streamWriter.Close();
					}
					catch
					{
					}
				}
			}
		}

		public static void Log(LogLevel type, string data, object f1, object f2)
		{
			object obj = Logger.locker;
			lock (obj)
			{
				if (Logger.WriteToConsole)
				{
					Console.WriteLine(data);
				}
				string logSign = "I";
				if (type == LogLevel.Warning)
				{
					logSign = "W";
				}
				else if (type == LogLevel.Error)
				{
					logSign = "E";
				}
				else if (type == LogLevel.Info)
				{
					logSign = "I";
				}
				if (Logger.WriteLogFile)
				{
					try
					{
						StreamWriter streamWriter = new StreamWriter(Logger.LogPath + f1, true);
						DateTime now = DateTime.Now;
						StringBuilder logMessageBuilder = new StringBuilder();
						logMessageBuilder.Append("[{logSign}] ");
						logMessageBuilder.Append(now.ToString("yyyy-MM-dd HH:mm:ss.fff"));
						logMessageBuilder.Append("    ");
						logMessageBuilder.Append(string.Format(data, f1, f2));
						streamWriter.WriteLine(logMessageBuilder.ToString());
						streamWriter.Close();
					}
					catch
					{
					}
				}
			}
		}

		public static void ForceLog(LogLevel type, string data)
		{
			object obj = Logger.locker;
			lock (obj)
			{
				Console.WriteLine(data);
				try
				{
					StreamWriter streamWriter = new StreamWriter(Logger.LogPath + Logger.LogFileName, true);
					DateTime now = DateTime.Now;
					StringBuilder logMessageBuilder = new StringBuilder();
					logMessageBuilder.Append(now.ToString("dd.MM. HH:mm:ss.fff"));
					logMessageBuilder.Append("    ");
					logMessageBuilder.Append(data);
					streamWriter.WriteLine(logMessageBuilder.ToString());
					streamWriter.Close();
				}
				catch
				{
				}
			}
		}

		public static void ForceLog(string data, string fileName)
		{
			object obj = Logger.locker;
			lock (obj)
			{
				Console.WriteLine(data);
				try
				{
					StreamWriter streamWriter = new StreamWriter(Logger.LogPath + fileName, true);
					DateTime now = DateTime.Now;
					StringBuilder logMessageBuilder = new StringBuilder();
					logMessageBuilder.Append(now.ToString("dd.MM. HH:mm:ss.fff"));
					logMessageBuilder.Append("    ");
					logMessageBuilder.Append(data);
					streamWriter.WriteLine(logMessageBuilder.ToString());
					streamWriter.Close();
				}
				catch
				{
				}
			}
		}

		private static string LogPath;

		private static string LogFileName;

		private static readonly object locker = new object();
	}
}
