namespace PT_Lab2
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(Singleton.StartForm);// запуск происходит через свойство Класса-одиночки: стартовая форма
            Application.Exit();
        }
    }
}