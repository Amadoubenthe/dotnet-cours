using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NLog;

namespace nameProject.webApi.logging
{
  public class Log : Ilog
  {
    private static NLog.ILogger _logger = LogManager.GetCurrentClassLogger();
    public void Information(string message)
    {
      _logger.Info(message);
    }
    public void Warning(string message)
    {
      _logger.Warn(message);
    }
    public void Error(string message)
    {
      _logger.Error(message);
    }
    public void Debug(string message)
    {
      _logger.Debug(message);
    }
  }
}