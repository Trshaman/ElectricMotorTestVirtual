﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace ElectricMotorTestVirtual.OOP_Approach.Recipe
{
    [Serializable]
    public class TestSettings
    {

        public string Name { get; set; }

        public ulong No { get; set; }

        public string TestDescription { get; set; }

        public TestRecipe RecipeSettings { get; set; }

        public TestSettings()
        {
            this.RecipeSettings = new TestRecipe();
        }
        public static Exception SaveTestsAsXML(string fileName, List<TestSettings> testList)
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

        public static List<TestSettings> LoadTestsFromXML(string fileName)
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

        public bool IsTestSettingsAppropriate()
        {
            if (this.RecipeSettings.EmkTestRecipe.IsTestActive || this.RecipeSettings.HVTestRecipe.IsTestActive || this.RecipeSettings.LCRTestRecipe.IsTestActive || this.RecipeSettings.PerformanceTestRecipe.IsTestActive)
            {
                if (!string.IsNullOrEmpty(this.Name))
                {
                    return true;
                }
                else
                {
                    MessageBox.Show("Test adı boş bırakılamaz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            else
            {
                MessageBox.Show("Herhangi bir test aktif değil!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
