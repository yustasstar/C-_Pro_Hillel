using System;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Windows.Forms;
using Microsoft.Win32;

namespace WindowsApplication1
{
    public partial class Form1 : Form
    {
        List<string> names;
        public Form1()
        {
            InitializeComponent();
            
            names = new List<string>();
            // инициализация объекта
            names.Add("one");
            names.Add("two");
            names.Add("three");
        }

        // Сохранение данных в реестр
        private void button1_Click(object sender, EventArgs e)
        {
            Save(names/*сохраняемые данные*/, "software\\test"/*подраздел реестра*/, "ValueName"/*имя*/);
            MessageBox.Show("Данные успешно сохранены в реестр!");
        }

        // Загрузка данных из реестра
        private void button2_Click(object sender, EventArgs e)
        {
            // Загружаем сохраненный объект
            List<string> obj = null;
            try{
                Load(ref obj/*загружаемые данные*/, "software\\test"/*подраздел реестра*/, "ValueName"/*имя*/);
                foreach (string str in obj)
                    MessageBox.Show(str);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        public void Save(List<string> obj, string akey, string avalue)
        {
            // Создание бинарного потока
            BinaryFormatter formatter = new BinaryFormatter();
            MemoryStream stream = new MemoryStream();
            // Сериализация в бинарный поток
            formatter.Serialize(stream, obj);
            // Описание ключа реестра
            RegistryKey regKey;
            // Открытие ключа реестра
            regKey = Registry.CurrentUser.CreateSubKey(akey);
            // Запись  в реестр
            regKey.SetValue(avalue, stream.ToArray());
            stream.Close();
        }

        public void Load(ref List<string> obj, string akey, string avalue)
        {
            // BinaryFormatter отвечает за сериализацию и десериализацию объектов
            BinaryFormatter formatter = new BinaryFormatter();
            // Описание ключа реестра
            RegistryKey regKey;
            // Открытие ключа реестра
            regKey = Registry.CurrentUser.OpenSubKey(akey);
            // Чтение из реестра в байтовый массив
            byte[] barray = null;
            barray = (byte[])regKey.GetValue(avalue);
            if (barray != null)
            {
                // Создание бинарного потока
                MemoryStream stream = new MemoryStream(barray);
                // десериализация из бинарного потока в List
                obj = formatter.Deserialize(stream) as List<string>;
                stream.Close();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            const string subkey = "software\\test";// подраздел реестра для данных нашей программы
            try
            {
                //Удаление заданного вложенного раздела. Строка subkey не учитывает регистр знаков.
                Registry.CurrentUser.DeleteSubKey(subkey, true);
                MessageBox.Show("Из реестра удален подраздел test");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            } 
        }
    }
}