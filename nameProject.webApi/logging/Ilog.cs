using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace nameProject.webApi.logging
{
  public interface Ilog
  {
    void Information(string message);
    void Warning(string message);
    void Error(string message);
    void Debug(string message);
  }
}