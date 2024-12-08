using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Runtime.InteropServices;//платформа вызова сервисов отвечает за взаимодействие с унаследованным кодом
//При вызове функции из DLL, Framework не следит за выделением памяти внутри DLL.

namespace ExampleImportDll
{
    public partial class Form1 : Form
    {
        ImageList list = new ImageList();
        public Form1()
        {
            InitializeComponent();
            list.ColorDepth = ColorDepth.Depth32Bit;
            list.ImageSize = new Size(32, 32);
            list.TransparentColor = Color.Transparent;

            listView1.LargeImageList = list;

        }

        /*
        Атрибут DllImportAttribute предоставляет сведения, необходимые для вызова функции, 
        экспортированной из неуправляемой динамически подключаемой библиотеки (DLL) (например, функция WIN32API). 
        Минимальным требованием является указание имени динамически подключаемой библиотеки (DLL), 
        содержащей точку входа.

        public sealed class DllImportAttribute : Attribute

        Поля и методы класса DllImportAttribute:
        public DllImportAttribute( - конструктор.
           string dllName – имя dll-модуля, в котором находится импортируемая функция.
        );

        public string EntryPoint; - точка входа. Фактически название функции или ее номер. 
 						        Перед номером нужно ставить #. 

        public CharSet CharSet; - кодировка
 		        Ansi
 		        Auto
 		        Unicode

        public bool ExactSpelling; - определяет, нужно ли точно проверять название функции.

        public CallingConvention CallingConvention; - Показывает соглашение о вызове точки входа.
 			        Winapi – говорит о том, что будет использоваться соглашение по умолчанию, которое принято в конкретной ОС. 
                    Для СЕ.NET – Cdecl – вызывающий метод чистит стек.
                    Для остальных Windows – StdCall – вызванный метод чистит стек. 
        */

        //при объявлении прототипа импортируемой функции её нужно пометить атрибутом [DllImport] c указанием, по меньшей мере, имени DLL-модуля
        [DllImport("user32")]
		public static extern int MessageBox ( // Возле всех импортируемых функций необходимо указывать static extern
 								
			IntPtr hWnd, //при объявлении прототипа функции нужно пользоваться типами данных .NET FRAMEWORK (нельзя использовать HWND, char* и т.п.)
			string text, 
			string caption, 
			int type);
        /*
                IntPtr – специальная структура для представления указателей и дескрипторов.
                 Внутри есть набор функций для преобразования к типам данных:
                 public int ToInt32();
        */

        enum MyButtons { MB_OK = 0, MB_ABORTRETRYIGNORE = 2, IDABORT,IDRETRY, IDIGNORE}
        private void button1_Click(object sender, EventArgs e)
        {
            int rez = MessageBox(this.Handle, "Импортируем функцию из WIN32API", "MessageBox", (int)MyButtons.MB_ABORTRETRYIGNORE);
            switch(rez)
            {
                case (int)MyButtons.IDABORT:
                    MessageBox(this.Handle, "Нажата клавиша Abort", "Прервать", (int)MyButtons.MB_OK);
                    break;
                case (int)MyButtons.IDRETRY:
                    MessageBox(this.Handle, "Нажата клавиша Retry", "Повторить", (int)MyButtons.MB_OK);
                    break;
                case (int)MyButtons.IDIGNORE:
                    MessageBox(this.Handle, "Нажата клавиша Ignore", "Пропустить", (int)MyButtons.MB_OK);
                    break;

            }

        }

        [DllImport("user32", ExactSpelling = true, CharSet = CharSet.Unicode, EntryPoint = "MessageBoxW")]
        public static extern int MyMsgBox1(int hWnd,
            string text,
            string caption,
            int type);

        private void button2_Click(object sender, EventArgs e)
        {
            MyMsgBox1(0, "UNICODE-версия", "Окно сообщения", (int)MyButtons.MB_OK);
        }


        //пример ошибочной депортации MessageBox
        [DllImport("user32", 
            ExactSpelling = true/*будет проверять точное название: A или W на конце функции*/ , 
            CharSet = CharSet.Unicode,
            EntryPoint = "MessageBox")]
        public static extern int MyMsgBox2(int hWnd, 
			string text, 
			string caption, 
			int type);

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                MyMsgBox2(0, "Привет!", "Окно сообщения", (int)MyButtons.MB_OK);//ошибка этапа выполнения
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }

        //пример ошибочной депортации MessageBox - неправильная кодировка
        [DllImport("user32",
            ExactSpelling = true,
            CharSet = CharSet.Unicode,
            EntryPoint = "MessageBoxA")]
        public static extern int MyMsgBox3(int hWnd,
            string text,
            string caption,
            int type);

  
        private void button4_Click(object sender, EventArgs e)
        {
            MyMsgBox3(0, "Привет!", "Окно сообщения", (int)MyButtons.MB_OK); // неверная кодировка
        }

        /*
         Пример импортации функции, использующей стандартные структуры:
         Импортация GetSystemTime:

        void GetSystemTime( - получает текущее время и дату 
          LPSYSTEMTIME lpSystemTime – указатель на структуру SYSTEMTIME
        );

        typedef struct _SYSTEMTIME {
          WORD wYear; - текущий год больше чем 1601
          WORD wMonth; - месяц начинается с 1
          WORD wDayOfWeek; - начинается с 0(воскресенье)
          WORD wDay;
          WORD wHour;
          WORD wMinute;
          WORD wSecond;
          WORD wMilliseconds;
        } SYSTEMTIME, *PSYSTEMTIME;
        */
        public class TimeRoutines
        {
            public struct SYSTEMTIME
            {
                public short wYear;
                public short wMonth;
                public short wDayOfWeek;
                public short wDay;
                public short wHour;
                public short wMinute;
                public short wSecond;
                public short wMilliseconds;
            }
            [DllImport("kernel32")]
            public static extern void GetSystemTime(
            out SYSTEMTIME lpSystemTime//в данном случае указывается out, так как 
                // структура не должна быть инициализированна перед вызовом метода
            );
        }

        private void button5_Click(object sender, EventArgs e)
        {
            TimeRoutines.SYSTEMTIME g;
            TimeRoutines.GetSystemTime(out g);
            System.Windows.Forms.MessageBox.Show(String.Format("{0:D2}:{1:D2}:{2:D2}  {3:D2}.{4:D2}.{5:D4}", 
                g.wHour, g.wMinute, g.wSecond, g.wDay, g.wMonth, g.wYear));

        }

        /*
        DWORD_PTR SHGetFileInfo(  - получает информацию о некотором объекте файловой системы. 
            Например, можно получить атрибуты файла, значок, соответствующий типу файла. 
            LPCTSTR pszPath, - обычно это путь к тому файлу, который необходимо исследовать 
            DWORD dwFileAttributes, - используется только тогда, когда нужно получить атрибуты 
                        некоторого файла или директории. Если атрибуты не нужны, указывается 0.
            SHFILEINFO *psfi, - специальный указатель на структуру, куда будет записана 
 					          полученная информация.
            UINT cbFileInfo, - размер предыдущего аргумента в байтах.
            UINT uFlags – определяет, что необходимо получить.
 			SHGFI_DISPLAYNAME – определяет, заполнять ли поле szDisplayName
 			SHGFI_TYPENAME – определяет, заполнять ли поле szTypeName
 			SHGFI_ICON – говорит о том, что необходимо получить иконку в hIcon, а также  
 					   получить индекс в iIcon. Обычно с Icon указывается флаг:  
 			SHGFI_LARGEICON – большая иконка; 
 			SHGFI_SMALLICON – маленькая иконка;
 			SHGFI_OPENICON – для открытого состояния
 			SHGFI_SELECTED – иконка для выбранного состояния
            );
          
            typedef struct _SHFILEINFO {
            HICON hIcon; - записывается дескриптор полученной иконки
            int iIcon; - индекс иконки в системном списке отображений
            DWORD dwAttributes; - атрибуты файла.
            TCHAR szDisplayName[MAX_PATH]; - название элемента в Microsoft Windows Shell(проводник)
            TCHAR szTypeName[80]; - строка, описывающая тип файла 
            } SHFILEINFO;


            StructLayout и MarshalAs – эти атрибуты обычно используются при смеси управляемого и неуправляемого кода.
            StructLayout – используется для того, чтобы контролировать физическое расположение полей класса или полей структуры
            
            [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct)]
            public sealed class StructLayoutAttribute : Attribute
       
            При использовании структур необходимо помнить о том, что структура может размещатся не 
            последовательно в RAM. Существует возможность указать компилятору о том, что структуру 
            необходимо размещать последовательно.
         
             public StructLayoutAttribute ( - конструктор
               LayoutKind layoutKind – определяет, как должны быть расположены поля класса или  поля структуры
 		            Auto      – 	автоматическая. Framework сам решает, что необходимо сделать
 		            Explicit  – 	указывает, что необходимо контролировать размещение полей вручную. 
                                    Смещение указывается, используя специальный атрибут FieldOffsetAttribute. 
 		            Sequential – 	поля лежат последовательно друг за другом, в том порядке в 
 				                    котором они были объявлены.
            );

           
            При обращении к импортируемой функции происходит автоматическое преобразование из типов .NET в тип WinAPI. 
            Иногда приходится явно указывать, как производить преобразование и передачу. 
            Для этого существует специальный класс атрибута MarshalAsAttribute. 
            Маршаллинг – механизм преобразования типов из одного языка в другой.
         
            public MarshalAsAttribute
            (
               UnmanagedType unmanagedType – как произвести маршаллинг
               ByValArray – используется для фиксированных массивов внутри структур. 
                    При использовании этого значения всегда нужно задавать размер массива через свойство SizeConst.
            );

         */

        class Win32
        { 
            //необходимо импортировать структуру SHFILEINFO
            [StructLayout(LayoutKind.Sequential)]
            public struct SHFILEINFO
            {
                /*
                 IntPtr – специальная структура, для представления указателей и дескрипторов.
                  Внутри есть набор функций для преобразования к типам данных:
                  public int ToInt32();
                */
                public IntPtr hIcon;
                public IntPtr iIcon;
                public uint dwAttributes;
                /*
                 Типы ByValTStr .NET Framework ведут себя, как характерные для языка C 
                 строки фиксированной длины внутри структуры (например, char s[5]).
                */
                [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
                public string szDisplayName;
                [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 80)]
                public string szTypeName;
            }
            public const int SHGFI_ICON = 0x000000100;
            public const int SHGFI_SMALLICON = 0x000000001;
            public const int SHGFI_LARGEICON = 0x000000000;
            public const int SHGFI_DISPLAYNAME = 0x000000200;
            public const int SHGFI_TYPENAME = 0x000000400;
            [DllImport("shell32.dll")]
            public static extern IntPtr 
                SHGetFileInfo(string pszPath, uint dwFileAttributes,  ref SHFILEINFO psfi, uint cbFileInfo, uint uFlags);
        }

        //получим список файлов корневого каталога диска С:\
        private void button6_Click(object sender, EventArgs e)
        {
            string [] str = Directory.GetDirectories(@"C:\Windows","*.*");
            string [] str2 = Directory.GetFiles(@"C:\Windows", "*.*");
            int length = str.Length;
            Array.Resize(ref str, str.Length + str2.Length);
            Array.Copy(str2, 0, str, length, str2.Length);
            Win32.SHFILEINFO sh = new Win32.SHFILEINFO();
			if (str.Length==0) 
            {
                System.Windows.Forms.MessageBox.Show("Файлы не найдены!!!");
				return;
			}

            /*
            sizeof в С# считается небезопасной операцией. И выполняется только через класс Marshal. 
            public sealed class Marshal – класс используется явно или неявно для взаимодействия с unmanaged code. 
                Например, для выделения памяти в неуправляемом коде, копирование блоков неуправляемого кода и т.д.

            public static int SizeOf( - возвращает количество байт, необходимых для объекта. 
               object structure – объект.
            );

            public static Icon FromHandle( - возвращает ссылку на объект типа Icon на основании 
 							            переданного дескриптора. 
               IntPtr handle
            );
             */

			for (int i = 0; i<str.Length;i++)
            {
				Win32.SHGetFileInfo(str[i],0,ref sh,(uint)Marshal.SizeOf(sh),
			        Win32.SHGFI_ICON|Win32.SHGFI_LARGEICON|Win32.SHGFI_DISPLAYNAME);
				System.Drawing.Icon icon = Icon.FromHandle(sh.hIcon);
				list.Images.Add(icon);
				listView1.Items.Add(sh.szDisplayName,i);
			}
      
          
        }


    }
}