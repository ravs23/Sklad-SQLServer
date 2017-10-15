using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sklad
{
    static class Settings
    {
        public static bool DisplayCatalogPeriodsWithZero = true;
        public static int Discount = 20;
        public static string FolderPrices = @"Prices\";
        static string cfgFile = "Sklad.cfg";
        public static List<string> listXLSX = new List<string>();


        public static void StartUpSettings()
        {
            LoadSettings();
            CreateFolderPrices();
            CreatelistXLSX();
        }

        static void LoadSettings()
        {
            if (File.Exists(cfgFile))
            {
                ReadSetting();
            }
            else
            {
                WriteSetting();
            }
        }

        static void WriteSetting()
        {
            try
            {
                using (FileStream fs = new FileStream(cfgFile, FileMode.Create, FileAccess.Write))
                {
                    using (BinaryWriter writer = new BinaryWriter(fs))
                    {

                        writer.Write(DisplayCatalogPeriodsWithZero);
                        writer.Write(Discount);
                        writer.Write(FolderPrices);

                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        static void ReadSetting()
        {
            try
            {
                using (FileStream fs = new FileStream(cfgFile, FileMode.Open, FileAccess.Read))
                {
                    using (BinaryReader reader = new BinaryReader(fs))
                    {
                        DisplayCatalogPeriodsWithZero = reader.ReadBoolean();
                        Discount = reader.ReadInt32();
                        FolderPrices = reader.ReadString();
                    }
                }
            }
            catch (EndOfStreamException) //поврежденный файл конфигурации
            {
                MessageBox.Show("Поврежден файл конфигурации" + Environment.NewLine + "Перезапустите программу", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                File.Delete(cfgFile);
                Environment.Exit(1);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static void SaveSettings()
        {
            WriteSetting();
            CreateFolderPrices();
            CreatelistXLSX();
        }

        static void CreateFolderPrices()
        {
            try
            {
                if (!Directory.Exists(FolderPrices))
                {
                    Directory.CreateDirectory(FolderPrices);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        static void CreatelistXLSX()
        {
            try
            {
                if (Directory.Exists(FolderPrices))
                {
                    string[] files = Directory.GetFiles(FolderPrices, "*.xlsx", SearchOption.AllDirectories);
                    listXLSX = files.ToList();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

        }

    }


}
