using HtmlAgilityPack;
using PSConstruct.DBClasses;
using System.Collections.Generic;
using System.Globalization;
using System.Net.Http.Headers;
using System.Net.Sockets;
using System.Text;

namespace PSConstruct;

public partial class NewPage1 : ContentPage
{
    //глобальные переменные для базы--------

    //для мамы
    string MBName;
    string MBCPUsocket;
    string MBGPUsocket;
    string MBRAMsocket;
    int CountRAM;

    //Для проца
    string CPUName;
    string CPUsocket;
    int CoreCount;
    int StreamCount;
    double CoreHz;
    bool GraphCore;
    int CPUPowerEat;

    //Для Видюхи
    string GPUName;
    string GPUsocket;
    int GPUMemoryCount;
    string GPUMemoryType;
    int GPUSpeed;
    int GPUPowerEat;

    //Для диска
    string HDDName;
    int HDDMemorySpeed;
    int HDDMemoryCount;
    int HDDPowerEat;

    //Для Оперативы
    string RAMName;
    int RAMMemorySpeed;
    int RAMMemoryCount;
    string RAMsocket;

    //Для Блока
    string PowerUnitName;
    int Power;

    //глобальные переменные для базы--------

    public List<string> Compl { get; set; }
	public NewPage1()
	{
        //чтоб читало кодировки, а то блин вопросы всплывают, а всплывает только....
        Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
        InitializeComponent();
        //выбор что парсим
		Compl = new List<string> { "Мать", "ЦП", "ВИДЮХА", "ОПЕРАТИВА", "НАКОПИТЕЛЬ", "БП" };
        BindingContext = this;
    }

    private void ToParceButton_Clicked(object sender, EventArgs e)
    {
        //Парс никса (https://www.nix.ru/) Жалко на эту работу потраченно 5 дней
        HtmlWeb web = new HtmlWeb();
        HtmlDocument doc = web.Load(URL.Text);
        HtmlNode htmlNode = doc.DocumentNode.SelectSingleNode("//table[@id='PriceTable']");
        List<HtmlNode> rows = htmlNode.Descendants("tr").ToList();
        string[,] tableData = new string[rows.Count, 2];
        for (int i = 1; i < rows.Count; i++)
        {
            var cells = rows[i].Descendants("td");

            if (cells.Count() >= 2)
            {
                tableData[i, 0] = cells.ElementAt(0).InnerText.Trim();
                tableData[i, 1] = cells.ElementAt(1).InnerText.Trim();
            }
            else
            {
                tableData[i, 0] = cells.ElementAt(0).InnerText.Trim();
            }
        }
        switch (whoIs.SelectedIndex)
        {
            case 0:

                //парс для матери

                //Очистка лейбла, чтоб не дублировалось
                ResultLabel.Text = "";
                //Основной цикл перебора всей таблицы по первому элементу двумерного массива строк
                for (int i = 0; i < rows.Count; i++)
                {
                    if (tableData[i, 0] == "Модель")
                    {
                        if (tableData[i, 1].Length > 22)
                        {
                            //странь господня, чтоб убрать "Подобрать рохожее"
                            string socket = tableData[i, 1].Remove(tableData[i, 1].Length - 23);
                            ResultLabel.Text+=socket+ "\n";
                            MBName = socket;
                        }
                        else
                        {
                            string socket = tableData[i, 1];
                            ResultLabel.Text += socket + "\n";
                            MBName = socket;
                        }
                    }
                    if (tableData[i, 0] == "Гнездо процессора")
                    {

                        if (tableData[i, 1].Length > 22)
                        {
                            string socket = tableData[i, 1].Remove(22);
                            ResultLabel.Text += socket + "\n";
                            MBCPUsocket = socket;
                        }
                        else
                        {
                            string socket = tableData[i, 1];
                            ResultLabel.Text += socket + "\n";
                            MBCPUsocket = socket;
                        }
                    }
                    if (tableData[i, 0] == "Тип поддерживаемой памяти")
                    {
                        //это если вместо DDR4 будет "Мультиприкольный DDR4 с первым приколом серверного типа и т.д"
                        if (tableData[i, 1].Length > 3)
                        {
                            string socket = tableData[i, 1].Remove(tableData[i, 1].Length - (tableData[i, 1].Length - 4));
                            ResultLabel.Text += socket + "\n";
                            MBRAMsocket = socket;
                        }
                        else
                        {
                            string socket = tableData[i, 1];
                            ResultLabel.Text += socket + "\n";
                            MBRAMsocket = socket;
                        }
                    }
                    if (tableData[i, 0] == "Количество слотов памяти")
                    {
                        ResultLabel.Text += tableData[i,1] + "\n";
                        CountRAM = Convert.ToInt32(tableData[i, 1]);
                    }
                }
                MBGPUsocket = "PCI Express 16x";
                //Хитрый алексей будет добавлять в таблицу видеокарты только под этот PCI так как на большенстве теблиц эту ифу достать сложно
                ResultLabel.Text += "PCI Express 16x";
                break;
            case 1:

                //парс для прцессора

                ResultLabel.Text = "";
                for (int i = 0; i < rows.Count; i++)
                {
                    if (tableData[i, 0] == "Модель")
                    {
                        if (tableData[i, 1].Length > 22)
                        {
                            string socket = tableData[i, 1].Remove(tableData[i, 1].Length - 23);
                            ResultLabel.Text += socket + "\n";
                            CPUName = socket;
                        }
                        else
                        {
                            string socket = tableData[i, 1];
                            ResultLabel.Text += socket + "\n";
                            CPUName = socket;
                        }
                    }
                    if (tableData[i, 0] == "Гнездо процессора")
                    {
                        if (tableData[i, 1].Length > 22)
                        {
                            string socket = tableData[i, 1].Remove(tableData[i, 1].Length - 21);
                            ResultLabel.Text += socket + "\n";
                            CPUsocket = socket;
                        }
                        else
                        {
                            string socket = tableData[i, 1];
                            ResultLabel.Text += socket + "\n";
                            CPUsocket = socket;
                        }
                    }
                    if (tableData[i, 0] == "Количество ядер")
                    {
                        string socket = tableData[i, 1];
                        ResultLabel.Text += socket + "\n";
                        CoreCount = Convert.ToInt32(socket);
                        
                    }
                    if (tableData[i, 0] == "Количество потоков")
                    {
                        ResultLabel.Text += tableData[i, 1] + "\n";
                        StreamCount = Convert.ToInt32(tableData[i,1]);
                    }
                    if (tableData[i, 0] == "Частота работы процессора")
                    {
                        string[] word = tableData[i, 1].Split(' ');
                        ResultLabel.Text += word[0];
                        CoreHz = Convert.ToDouble( word[0]);
                    }
                    if (tableData[i, 0] == "Видеоядро процессора")
                    {
                        string[] word = tableData[i, 1].Split(' ');
                        if (word[0] == "Нет")
                        {
                            ResultLabel.Text += "false\n";
                            GraphCore = false;
                        }
                        else { ResultLabel.Text += "true\n"; GraphCore = true; }
                    }
                    
                    if (tableData[i,0]== "Рассеиваемая мощность")
                    {
                        string[] word = tableData[i, 1].Split(' ');
                        ResultLabel.Text += word[0];
                        CPUPowerEat = Convert.ToInt32(word[0]);
                    }


                }
                //ResultLabel.Text += "PCI Express 16x";
                break;
            case 2:
                //Парс видюхи
                ResultLabel.Text = "";
                for (int i = 0; i < rows.Count; i++)
                {
                    if (tableData[i, 0] == "GPU")
                    {
                        if (tableData[i, 1].Length > 22)
                        {
                            string socket = tableData[i, 1].Remove(tableData[i, 1].Length - 27);
                            ResultLabel.Text += socket + "\n";
                            GPUName = socket;
                        }
                        else
                        {
                            string socket = tableData[i, 1];
                            ResultLabel.Text += socket + "\n";
                            GPUName = socket;
                        }
                    }
                    
                    if (tableData[i, 0] == "Видеопамять")
                    {
                        string[] word = tableData[i, 1].Split(' ');
                        ResultLabel.Text +="памяти"+ word[0]+"\n";
                        GPUMemoryCount = Convert.ToInt32( word[0]);
                    }
                    if (tableData[i, 0] == "Тип видеопамяти")
                    {
                        string socket = tableData[i, 1];
                        ResultLabel.Text +="Тип "+ socket + "\n";
                        GPUMemoryType = socket;

                    }
                    if (tableData[i, 0] == "Частота видеопамяти")
                    {
                        string[] word = tableData[i, 1].Split(' ');
                        ResultLabel.Text +="Частота "+ word[0] + "\n";
                        GPUSpeed = Convert.ToInt32( word[0]);
                    }
                    string power="";
                    if (tableData[i, 0] == "Питание:Максимальное энергопотребление")
                    {
                        string[] word = tableData[i, 1].Split(' ');
                        ResultLabel.Text += "Питание " + word[0] + "\n";
                        GPUPowerEat = Convert.ToInt32( word[0]);
                        power = word[0];
                    }
                    else if (tableData[i, 0] == "Рекомендуемая мощность блока питания"&&power=="")
                    {
                        string[] word = tableData[i, 1].Split(' ');
                        ResultLabel.Text += "Питание " + $"{Convert.ToInt32(word[0]) - Convert.ToInt32(word[0])/2}\n";
                        GPUPowerEat = Convert.ToInt32(word[0]) - Convert.ToInt32(word[0]) / 2;
                    }







                }
                GPUsocket = "PCI Express 16x";
                ResultLabel.Text += "PCI Express 16x";
                break;
            case 4:
                //Парс внутренних дисков
                ResultLabel.Text = "";
                for (int i = 0; i < rows.Count; i++)
                {
                    if (tableData[i, 0] == "Модель")
                    {
                        if (tableData[i, 1].Length > 22)
                        {
                            string socket = tableData[i, 1].Remove(tableData[i, 1].Length - 17);
                            ResultLabel.Text += socket + "\n";
                            HDDName = socket;
                        }
                        else
                        {
                            string socket = tableData[i, 1];
                            ResultLabel.Text += socket + "\n";
                            HDDName = socket;
                        }
                    }

                    if (tableData[i, 0] == "Емкость накопителя")
                    {
                        string[] word = tableData[i, 1].Split(' ');
                        //В базу суём только гиги (Не за шаги)
                        if (word[1] == "Тб")
                        {
                            ResultLabel.Text += "памяти" +Convert.ToInt32(word[0])*1024 + "\n";
                            HDDMemoryCount = Convert.ToInt32(word[0]) * 1024;
                        }
                        else {ResultLabel.Text += "памяти" + word[0] + "\n"; HDDMemoryCount = Convert.ToInt32(word[0]); }
                        
                    }
                    if (tableData[i, 0] == "Установившаяся скорость передачи данных")
                    {
                        string[] word = tableData[i, 1].Split(' ');
                        ResultLabel.Text += "Частота " + word[1] + "\n";
                        HDDMemorySpeed = Convert.ToInt32(word[1]);
                    }
                    //если в таблице не указанна энергопотребление то берется примерный его размер (половина из рекомендованно)
                    ;
                    if (tableData[i, 0] == "Потребление энергии")
                    {
                        string[] word = tableData[i, 1].Split(' ');
                        ResultLabel.Text += "Питание " + word[0] + "\n";
                        HDDPowerEat = Convert.ToInt32(word[0]);
                        
                    }
                    
                }
                    break;
            case 5:
                //Парс для Блока Питания
                ResultLabel.Text = "";
                for (int i = 0; i < rows.Count; i++)
                {
                    if (tableData[i, 0] == "Модель")
                    {
                        if (tableData[i, 1].Length > 22)
                        {
                            string socket = tableData[i, 1].Remove(tableData[i, 1].Length - 17);
                            ResultLabel.Text += socket + "\n";
                            PowerUnitName = socket;
                        }
                        else
                        {
                            string socket = tableData[i, 1];
                            ResultLabel.Text += socket + "\n";
                            PowerUnitName = socket;
                        }
                    }
                    if (tableData[i, 0] == "Мощность блока питания")
                    {
                        string[] word = tableData[i, 1].Split(' ');
                        ResultLabel.Text += "всего " + word[0] + "\n";
                        Power = Convert.ToInt32(word[0]);
                    }
                }
                break;
            case 3:
                //Парс для Оперативы
                ResultLabel.Text = "";
                for (int i = 0; i < rows.Count; i++)
                {
                    if (tableData[i, 0] == "Серия")
                    {
                        string socket = tableData[i, 1];
                        ResultLabel.Text += socket + " ";
                        RAMName = socket;
                    }
                    if (tableData[i, 0] == "Модель")
                    {
                        string socket = tableData[i, 1];
                        ResultLabel.Text += socket + "\n";
                        RAMName +=" "+ socket;
                        
                    }
                    if (tableData[i, 0] == "Тип оборудования")
                    {
                        string[] word = tableData[i, 1].Split(' ');
                        ResultLabel.Text += "всего " + word[2] + "\n";
                        RAMsocket = word[2];
                    }
                    if (tableData[i, 0] == "Объем модуля памяти")
                    {
                        string[] word = tableData[i, 1].Split(' ');
                        
                        ResultLabel.Text += "speed " + word[0] + "\n";
                        RAMMemoryCount = Convert.ToInt32(word[0]);
                    }
                    if (tableData[i, 0] == "Пропускная способность памяти")
                    {
                        string[] word = tableData[i, 1].Split(' ');
                        ResultLabel.Text += "speed " + word[0] + "\n";
                        RAMMemorySpeed = Convert.ToInt32(word[0]);
                    }
                }
                break;

        }

    }

    private void AddDataBase_Clicked(object sender, EventArgs e)
    {
        switch (whoIs.SelectedIndex)
        {
            case 0:
                using(var context = new ConfigContext())
                break;
            case 1:
                break;
            case 2:
                break;

        }
    }
}