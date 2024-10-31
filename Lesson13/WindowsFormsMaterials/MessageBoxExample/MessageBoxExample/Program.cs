using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MessageBoxExample
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
       
        // Single Threaded Apartment
        // Модель потоков STA необходима для взаимодействия с COM
        /*
         * STA-single-threaded apartment 
        Microsoft утверждает,что данный атрибут ф-ция Main() должна иметь во всех windows-приложениях.
         * Это означает, что все потоки в этой программе выполняются в рамках одного процесса, а управление приложением осуществляется одним главным потоком.
         * Это необходимо, чтоб не было проблем, если приложение подключает компоненты. Разработчики компонентов могут дать своему компоненту много прав. 
         * При подключении компонента, он запускает какое-то модальное действие и приложение зависает. При STA всеми потоками руководит поток, запущеный с Main().
         * */
        [STAThread]// однопоточный апартамент 
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
