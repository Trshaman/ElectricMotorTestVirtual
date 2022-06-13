using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceProcess;
namespace GlobalFunctions
{
  public class ServiceSwitch
  {
    #region public void StopAllServices(bool showErrorMessage)
    /// <summary>
    /// Stops the SQL Services.
    /// </summary>
    /// <param name="showErrorMessage"></param>
    public void StopAllServices(bool showErrorMessage)
    {
      ServiceController[] scServicesToStop = ServiceController.GetServices();
      int counter = 0;
      foreach (ServiceController scTemp in scServicesToStop)
      {
        if (scTemp.Status == ServiceControllerStatus.Running)
        {
          try
          {
            scTemp.Stop();
            counter++;
          }
          catch (Exception exc)
          {
            if (showErrorMessage)
            {
              throw new Exception("Error in Class ServiceSwitch.StopAllSQLServices " + exc.Message);
            }
          }

        }

      }

    }
    #endregion

    #region public void StopAllSQLServices(bool showErrorMessage)
    /// <summary>
    /// Stops the SQL Services.
    /// </summary>
    /// <param name="showErrorMessage"></param>
    public void StopAllSQLServices(bool showErrorMessage)
    {

      //string[] sqlServices = {"MsDtsServer100", "MSSQL$SQLEXPRESS", "MSSQLFDLauncher", "MSSQLSERVER",
      //"MSSQLServerOLAPService", "SQLBrowser", "SQLWriter"};
      ServiceController[] scServicesToStop = System.ServiceProcess.ServiceController.GetServices();
      int counter = 0;
      foreach (ServiceController scTemp in scServicesToStop)
      {
        if (scTemp.Status == ServiceControllerStatus.Running)
        {
          if ((scTemp.ServiceName == "MsDtsServer100") || (scTemp.ServiceName == "MSSQL$SQLEXPRESS") || (scTemp.ServiceName == "MSSQLSERVER") ||
              (scTemp.ServiceName == "MSSQLFDLauncher") || (scTemp.ServiceName == "MSSQLServerOLAPService") ||
              (scTemp.ServiceName == "SQLBrowser") || (scTemp.ServiceName == "SQLWriter"))
          {
            try
            {
              scTemp.Stop();
              counter++;
            }
            catch (Exception exc)
            {
              if (showErrorMessage)
              {
                throw new Exception("Error in Class ServiceSwitch.StopAllSQLServices " + exc.Message);
              }

            }

          }

        }

      }

    }
    #endregion

    #region public void StopOnlySQLMainServices(bool showErrorMessage)
    /// <summary>
    /// Stops the SQL Services.
    /// </summary>
    /// <param name="showErrorMessage"></param>
    public void StopOnlySQLMainServices(bool showErrorMessage)
    {
      //string[] sqlServices = {"MsDtsServer100", "MSSQL$SQLEXPRESS", "MSSQLFDLauncher", "MSSQLSERVER",
      //"MSSQLServerOLAPService", "SQLBrowser", "SQLWriter"};
      ServiceController[] scServicesToStop = ServiceController.GetServices();
      int counter = 0;
      foreach (ServiceController scTemp in scServicesToStop)
      {
        if (scTemp.Status == ServiceControllerStatus.Running)
        {
          if ((scTemp.ServiceName == "MSSQL$SQLEXPRESS") || (scTemp.ServiceName == "MSSQLSERVER"))
          {
            try
            {
              scTemp.Stop();
              counter++;
            }
            catch (Exception exc)
            {
              if (showErrorMessage)
              {
                throw new Exception("Error in Class ServiceSwitch.StopAllSQLServices " + exc.Message);
              }

            }

          }

        }

      }

    }
    #endregion

    #region public void StartAllSQLServices(bool showErrorMessage)
    /// <summary>
    /// Starts all Sql Services.
    /// </summary>
    /// <param name="showErrorMessage"></param>
    public void StartAllSQLServices(bool showErrorMessage)
    {
      ServiceController[] scServicesToStart = ServiceController.GetServices();
      int counter = 0;
      foreach (ServiceController scTemp in scServicesToStart)
      {
        if (scTemp.Status == ServiceControllerStatus.Stopped)
        {
          if ((scTemp.ServiceName == "MsDtsServer100") || (scTemp.ServiceName == "MSSQL$SQLEXPRESS") || (scTemp.ServiceName == "MSSQLSERVER") ||
              (scTemp.ServiceName == "MSSQLFDLauncher") || (scTemp.ServiceName == "MSSQLServerOLAPService") ||
              (scTemp.ServiceName == "SQLBrowser") || (scTemp.ServiceName == "SQLWriter"))
          {
            try
            {
              scTemp.Start();
              counter++;
            }
            catch (Exception exc)
            {
              if (showErrorMessage)
              {
                throw new Exception("Error in Class ServiceSwitch.StartAllSQLServices: " +
                    exc.Message);
              }

            }

          }

        }

      }
    }

    /// <summary>
    /// Starts all Sql Services.
    /// </summary>
    /// <param name="showErrorMessage"></param>
    public Exception StartAllSQLServices()
    {
      ServiceController[] scServicesToStart = ServiceController.GetServices();
      int counter = 0;
      foreach (ServiceController scTemp in scServicesToStart)
      {
        if (scTemp.Status == ServiceControllerStatus.Stopped)
        {
          if ((scTemp.ServiceName == "MsDtsServer100") || (scTemp.ServiceName == "MSSQL$SQLEXPRESS") || (scTemp.ServiceName == "MSSQLSERVER") ||
              (scTemp.ServiceName == "MSSQLFDLauncher") || (scTemp.ServiceName == "MSSQLServerOLAPService") ||
              (scTemp.ServiceName == "SQLWriter"))
          {
            try
            {
              scTemp.Start();
              counter++;
            }
            catch (Exception exc) { return exc;}
          }
        }
      }
      return null;
    }
    #endregion

    #region public void PauseAllSQLServices(bool showErrorMessage)
    /// <summary>
    /// Starts all Sql Services.
    /// </summary>
    /// <param name="showErrorMessage"></param>
    public void PauseAllSQLServices(bool showErrorMessage)
    {
      ServiceController[] scServicesToStart = ServiceController.GetServices();
      int counter = 0;
      foreach (ServiceController scTemp in scServicesToStart)
      {
        if (scTemp.Status == ServiceControllerStatus.Running)
        {
          if ((scTemp.ServiceName == "MsDtsServer100") || (scTemp.ServiceName == "MSSQL$SQLEXPRESS") || (scTemp.ServiceName == "MSSQLSERVER") ||
              (scTemp.ServiceName == "MSSQLFDLauncher") || (scTemp.ServiceName == "MSSQLServerOLAPService") ||
              (scTemp.ServiceName == "SQLBrowser") || (scTemp.ServiceName == "SQLWriter"))
          {
            try
            {
              if (scTemp.CanPauseAndContinue)
              {
                scTemp.Pause();
                counter++;
              }
            }
            catch (Exception exc)
            {
              if (showErrorMessage)
              {
                throw new Exception("Error in Class ServiceSwitch.StartAllSQLServices: " +
                    exc.Message);
              }

            }

          }

        }

      }
    }
    #endregion

    #region public void RestartPausedSQLServices(bool showErrorMessage)
    /// <summary>
    /// Starts all Sql Services.
    /// </summary>
    /// <param name="showErrorMessage"></param>
    public void RestartPausedSQLServices(bool showErrorMessage)
    {
      ServiceController[] scServicesToStart = ServiceController.GetServices();
      int counter = 0;
      foreach (ServiceController scTemp in scServicesToStart)
      {
        if (scTemp.Status == ServiceControllerStatus.Paused)
        {
          if ((scTemp.ServiceName == "MsDtsServer100") || (scTemp.ServiceName == "MSSQL$SQLEXPRESS") || (scTemp.ServiceName == "MSSQLSERVER") ||
              (scTemp.ServiceName == "MSSQLFDLauncher") || (scTemp.ServiceName == "MSSQLServerOLAPService") ||
              (scTemp.ServiceName == "SQLBrowser") || (scTemp.ServiceName == "SQLWriter"))
          {
            try
            {
              scTemp.Continue();
              counter++;
            }
            catch (Exception exc)
            {
              if (showErrorMessage)
              {
                throw new Exception("Error in Class ServiceSwitch.StartAllSQLServices: " +
                    exc.Message);
              }

            }

          }

        }

      }
    }
    #endregion

    #region public bool StopAndStartSQLServices(bool showMessages)
    /// <summary>
    /// Stops and starts service. Returns true when finished.
    /// </summary>
    /// <param name="showMessages"></param>
    /// <returns>boolean true when finished</returns>
    public bool StopAndStartSQLServices(bool showMessages)
    {
      bool done = false;
      try
      {
        StopAllSQLServices(showMessages);
        StartAllSQLServices(showMessages);
        done = true;
      }
      catch (Exception exc)
      {
        if (showMessages)
        {
          throw new Exception("ServiceSwitch.StopAndStartSQLServices: " +
              exc.Message);
        }
      }
      return done;
    }
    #endregion

    public string CurrentRunningServices
    {
      get
      {
        string r = "";
        ServiceController[] scServicesToRead = ServiceController.GetServices();
        foreach (ServiceController scTemp in scServicesToRead)
        {
          if (scTemp.Status == ServiceControllerStatus.Running)
          {
            r += scTemp.ServiceName + ", ";
          }
        }
        return r;
      }
    }

    public string StoppedServices
    {
      get
      {
        string r = "";
        ServiceController[] scServicesToRead = ServiceController.GetServices();
        foreach (ServiceController scTemp in scServicesToRead)
        {
          if (scTemp.Status == ServiceControllerStatus.Stopped)
          {
            r += scTemp.ServiceName + ", ";
          }
        }
        return r;
      }
    }

    public string PausedServices
    {
      get
      {
        string r = "";
        ServiceController[] scServicesToRead = ServiceController.GetServices();
        foreach (ServiceController scTemp in scServicesToRead)
        {
          if (scTemp.Status == ServiceControllerStatus.Paused)
          {
            r += scTemp.ServiceName + ", ";
          }
        }
        return r;
      }
    }

    public bool SQLServerIsStopped
    {
      get
      {
        bool stopped = false;
        ServiceController[] scServicesToRead = ServiceController.GetServices();
        foreach (ServiceController scTemp in scServicesToRead)
        {
          if (scTemp.ServiceName == "MSSQLSERVER")
          {
            if (scTemp.Status == ServiceControllerStatus.Stopped)
            {
              stopped = true;
            }
            else
            {
              stopped = false;
            }
          }
        }
        return stopped;
      }
    }

    public bool SQLExpressServerIsStopped
    {
     
      get
      {
         bool stopped = false;
        ServiceController[] scServicesToRead = ServiceController.GetServices();
        foreach (ServiceController scTemp in scServicesToRead)
        {
          if (scTemp.ServiceName == "MSSQL$SQLEXPRESS")
          {
            if (scTemp.Status == ServiceControllerStatus.Stopped)
            {
              stopped = true;
            }
            else
            {
              stopped = false;
            }
          }
        }
        return stopped;
      }
    }

    #region public void StartSQLExpressServiceIfStopped(bool showErrorMessage)
    /// <summary>
    /// Starts all Sql Services.
    /// </summary>
    /// <param name="showErrorMessage"></param>
    public void StartSQLExpressServiceIfStopped(bool showErrorMessage)
    {
      ServiceController[] scServicesToStart = ServiceController.GetServices();
      int counter = 0;
      foreach (ServiceController scTemp in scServicesToStart)
      {
        if (scTemp.Status == ServiceControllerStatus.Stopped)
        {
          if (scTemp.ServiceName == "MSSQL$SQLEXPRESS")
          {
            try
            {
              scTemp.Start();
              counter++;
            }
            catch (Exception exc)
            {
              if (showErrorMessage)
              {
                throw new Exception("Error in Class ServiceSwitch.StartAllSQLServices: " +
                    exc.Message);
              }

            }

          }

        }

      }
    }
    #endregion


  }
}
