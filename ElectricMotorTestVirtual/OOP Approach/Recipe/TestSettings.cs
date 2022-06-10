using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ElectricMotorTestVirtual.OOP_Approach.Recipe
{
    public class TestSettings
    {

        public string Name { get; set; }

        public ulong No { get; set; }

        public List<TestRecipe> RecipeSettings { get; set; }

        public static Exception SaveTestsAsXML(string fileName, List<TestRecipe> testList)
        {
            FileStream fs = null;
            try
            {
                fs = new FileStream(fileName, FileMode.Create);
                XmlSerializer x = new XmlSerializer(typeof(List<TestSettings>));
                x.Serialize(fs, testList); ;
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

        public static List<TestSettings> LoadTestsAsXML(string fileName)
        {
            if (File.Exists(fileName))
            {
                try
                {
                    using (StreamReader fs = new StreamReader(fileName))
                    {
                        XmlSerializer x = new XmlSerializer(typeof (List<TestSettings>));
                        return (List<TestSettings>)x.Deserialize(fs); 
                    }
                }
                catch (Exception ex)
                {

                }
            }
            return null;
        }

        public TestSettings Copy(string name)
        {
            TestSettings newTest = new TestSettings();
            newTest.Name = name;
            newTest.No = No;
            newTest.RecipeSettings = this.RecipeSettings;
            return newTest;
        }
    }
}
