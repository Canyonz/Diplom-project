using Microsoft.Win32;
using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proga
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>

        public static Main main;
        public static PPStateEquipment state;
        public static PPSTypeAct typeact;
        public static PPSNaznach naznach;
        public static PPSDoljnost Doljnost;
        public static PPSTypeEquip TypeEquip;
        public static PPTStatusAD StatusAD;
        public static PPTUsers Users;
        public static PPTSotryd Sotryd;
        public static PPTAbonent Abonent;
        public static PPTPostavhik Postav;
        public static PPTFacialScore FacialS;
        public static PPTNakladnaya Naklad;
        public static PPTSpecNaklad SpecNaklad;
        public static PPTSklad Sklad;
        public static PPODogovor Dogovor;
        public static PPODogovors Dogovors;
        public static PPOAct Act;
        public static PPOSpecAct SpecAct;
        public static PPTNaklad_Spec Naklad_Spec;
        public static PTTAbonents Abonents;
        public static PPSCity City;
        public static PPSStreet Street;
        public static PPSCityStreet CityStreet;
        public static PPSYslygi Yslygi;
        public static PPSReasons Reasons;
        public static ArhivSpisEquip ArhivSE;
        public static RegistryKey user = null;
        public static RegistryKey data = null;
        public static bool b;
        [STAThread]
        //Назначение главной формы
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Previe preview = new Previe();
            preview.Show();
            RegistryKey currentUserKey = Registry.Users;
            RegistryKey sub = currentUserKey.OpenSubKey(".DEFAULT");
            RegistryKey subsub = sub.OpenSubKey("Software", true);
            RegistryKey rostelecom = subsub.OpenSubKey("Rostelecom");
            if (rostelecom == null)
            {
                rostelecom = subsub.CreateSubKey("Rostelecom");
            }
            user = rostelecom.OpenSubKey("User");
            data = rostelecom.OpenSubKey("Data");
            if (user == null)
            {
                if (data == null)
                {
                    sestx();
                    while (b != true)
                        Application.DoEvents();
                }
                else
                {
                    DateTime end = DateTime.Now + TimeSpan.FromSeconds(4);
                    while (end > DateTime.Now)
                        Application.DoEvents();
                }
            }
            else
            {
                DateTime end = DateTime.Now + TimeSpan.FromSeconds(4);
                while (end > DateTime.Now)
                    Application.DoEvents();
            }
            preview.Dispose();
            Login l = new Login();
            if (user == null)
            {
                l.Show();
                subsub.Close();
                sub.Close();
            }
            while (user == null)
            {
                Application.DoEvents();
            }
            l.Dispose();
            Application.Run(new Authorization());
        }
        //Загрузка заводсвой базы данных
        public static async void sestx()
        {
            if (!DBConnection.Connect(1))
            {
            var process = new Process();
            process.StartInfo.FileName = @"Rostelecom.bat";
            process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            process.StartInfo.CreateNoWindow = true;
            process.Start();
            await process.WaitForExitAsync();
            }
            b = true;
        }
        //Выполнение бат файла
        public static Task WaitForExitAsync(this Process process,
    CancellationToken cancellationToken = default(CancellationToken))
        {
            var tcs = new TaskCompletionSource<object>();
            process.EnableRaisingEvents = true;
            process.Exited += (sender, args) => tcs.TrySetResult(null);
            if (cancellationToken != default(CancellationToken))
                cancellationToken.Register(tcs.SetCanceled);
            return tcs.Task;
        }

    }
}
