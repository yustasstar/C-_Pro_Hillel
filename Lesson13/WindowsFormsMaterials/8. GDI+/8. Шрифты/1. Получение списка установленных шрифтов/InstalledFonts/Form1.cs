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
            
            // ����� InstalledFontCollection ������������ ������������� � ������� ������
            // ������� ��������� �������
            using (InstalledFontCollection fontFamilies = new InstalledFontCollection())
            {
                 int offset = 10;
                // �������� ����� ��� ������
                foreach (FontFamily family in fontFamilies.Families)
                {
                    try
                    {
                        // ������� �����, ������� ����� ���������� �����
                        // c ��������� �������
                        Label lblFont = new Label();
                        lblFont.Text = family.Name;
                        lblFont.Font = new Font(family, 14);
                        lblFont.Left = 100;
                        lblFont.Top = offset;
                        lblFont.BorderStyle = BorderStyle.FixedSingle;
                        // ��������� Label �� �����
                        this.Controls.Add(lblFont);
                        offset += 35;
                    }
                    catch
                    {
                        // ���� ��������� ����� �� ����� ����� ������� 
                        //(������������ �� ��������� ��� �������� ������� Font),
                        // �� ����� ���������� ������. 
                    }
                }
            }
        }
    }
}