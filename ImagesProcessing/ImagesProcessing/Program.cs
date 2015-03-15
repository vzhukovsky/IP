using System;
using System.Windows.Forms;

namespace ImagesProcessing
{
    public class Objfdf
    {
        public int Method(int a)
        {
            return 0;
        }
    }

    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var a = 0;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
