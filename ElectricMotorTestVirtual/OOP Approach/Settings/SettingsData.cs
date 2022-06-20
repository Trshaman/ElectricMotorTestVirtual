using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ElectricMotorTestVirtual.OOP_Approach.Settings
{
    public class SettingsData
    {
        public string ComSettings1 { get; set; } = "Herhangi bir seçim yapılmadı";

        public  string ComSettings2 { get; set; } = "Herhangi bir seçim yapılmadı";

        public  string ComSettings3 { get; set; } = "Herhangi bir seçim yapılmadı";

        public  string SelectedTest { get; set; } = "Herhangi bir seçim yapılmadı";

        public static Exception SaveSettingsAsXML(string fileName, SettingsData settings)
        {
            FileStream fs = null;
            try
            {
                fs = new FileStream(fileName, FileMode.Create);
                XmlSerializer x = new XmlSerializer(typeof(SettingsData));
                x.Serialize(fs, settings); ;
            }
            catch (Exception ex)
            {

                return ex;
            }
            finally
            {
                if (fs != null)
                {
                    fs.Close();
                }
            }
            return null;
        }

        public static SettingsData LoadSettingsFromXML(string fileName)
        {
            if (File.Exists(fileName))
            {
                try
                {
                    using (StreamReader fs = new StreamReader(fileName))
                    {
                        XmlSerializer x = new XmlSerializer(typeof(SettingsData));
                        return (SettingsData)x.Deserialize(fs);
                    }
                }
                catch (Exception ex)
                {

                }
            }
            return null;
        }

    }
}
