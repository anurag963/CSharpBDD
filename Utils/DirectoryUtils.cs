using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace automationCSharp.Utils
{
    public class DirectoryUtils
    {

        public String GetBaseDirectory()
        {
            try
            {
                //string workspaceDirectory = AppDomain.CurrentDomain.BaseDirectory.Replace("bin\\Debug\\netcoreapp3.1\\", "");
                //string workspaceDirectory = AppDomain.CurrentDomain.BaseDirectory.Replace("bin/Debug/net6.0/", "");
                /*var dirName = AppContext.BaseDirectory.Substring(0, AppContext.BaseDirectory.IndexOf("bin"));
                var fileInfo = new FileInfo(dirName);
                string parent = fileInfo?.FullName;*/

                //log.Info("Base directoty is: " + baseDirectory);
                //return parent;

                String baseDirectory = AppContext.BaseDirectory;
                return Directory.GetCurrentDirectory();
            }
            catch (Exception ex)
            {
                //log.Info("Exception in method " + MethodBase.GetCurrentMethod().Name + ", exception is : " + ex.StackTrace);
                throw ex;

            }
        }








    }
}
