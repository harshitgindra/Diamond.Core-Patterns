﻿using Diamond.Patterns.Abstractions;
using ISystemLogger = Serilog.ILogger;

namespace Diamond.Patterns.LoggerSubscriber.Serilog
{
	/// <summary>
	/// Subscribes to log messages from objects throughout the system
	/// and sends them to the system logger.
	/// </summary>
	public class SerilogLoggerSubscriber : ILoggerSubscriber
	{
		/// <summary>
		/// Creates an instance of <see cref="SerilogLoggerSubscriber"/> with the
		/// specified system logger.
		/// </summary>
		/// <param name="systemLogger">An instance of <see cref="Serilog.ILogger"/>.</param>
		public SerilogLoggerSubscriber(ISystemLogger systemLogger)
		{
			this.SystemLogger = systemLogger;
			this.Logger += this.OnInternalLogger;
		}

		/// <summary>
		/// Gets or sets the <see cref="Serilog.ILogger"/> instance.
		/// </summary>
		protected ISystemLogger SystemLogger { get; set; }

		/// <summary>
		/// Gets/sets the <see cref="LoggerDelegate"/> delegate method
		/// used to receive log messages from other components.
		/// </summary>
		public LoggerDelegate Logger { get; set; }

		/// <summary>
		/// Call whenever the InternalLogger is called on the base class.
		/// </summary>
		/// <param name="loggingLevel">Specifies the type of information represented by a log entry.</param>
		/// <param name="message">The log message.</param>
		protected void OnInternalLogger(LoggingLevel loggingLevel, string message)
		{
			switch (loggingLevel)
			{
				case LoggingLevel.Information:
					this.SystemLogger.Information(message);
					break;
				case LoggingLevel.Warning:
					this.SystemLogger.Warning(message);
					break;
				case LoggingLevel.Error:
					this.SystemLogger.Error(message);
					break;
				case LoggingLevel.Debug:
					this.SystemLogger.Debug(message);
					break;
				case LoggingLevel.Verbose:
					this.SystemLogger.Verbose(message);
					break;
			}
		}
	}
}
