using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Text;

namespace WindowsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent(); 
            
            // Класс InstalledFontCollection представляет установленные в системе шрифты
            // Создаем коллекцию шрифтов
            using (InstalledFontCollection fontFamilies = new InstalledFontCollection())
            {
                 int offset = 10;
                // Проходим через все шрифты
                foreach (FontFamily family in fontFamilies.Families)
                {
                    try
                    {
                        // Создаем метку, которая будет отображать текст
                        // c выбранным шрифтом
                        Label lblFont = new Label();
                        lblFont.Text = family.Name;
                        lblFont.Font = new Font(family, 14);
                        lblFont.Left = 100;
                        lblFont.Top = offset;
                        lblFont.BorderStyle = BorderStyle.FixedSingle;
                        // Добавляем Label на форму
                        this.Controls.Add(lblFont);
                        offset += 35;
                    }
                    catch
                    {
                        // Если выбранный шрифт не имеет стиль Обычный 
                        //(используется по умолчанию при создании объекта Font),
                        // то может возникнуть ошибка. 
                    }
                }
            }
        }
    }
}