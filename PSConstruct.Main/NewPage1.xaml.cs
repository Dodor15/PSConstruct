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
    //���������� ���������� ��� ����--------

    //��� ����
    string MBName;
    string MBCPUsocket;
    string MBGPUsocket;
    string MBRAMsocket;
    int CountRAM;

    //��� �����
    string CPUName;
    string CPUsocket;
    int CoreCount;
    int StreamCount;
    double CoreHz;
    bool GraphCore;
    int CPUPowerEat;

    //��� ������
    string GPUName;
    string GPUsocket;
    int GPUMemoryCount;
    string GPUMemoryType;
    int GPUSpeed;
    int GPUPowerEat;

    //��� �����
    string HDDName;
    int HDDMemorySpeed;
    int HDDMemoryCount;
    int HDDPowerEat;

    //��� ���������
    string RAMName;
    int RAMMemorySpeed;
    int RAMMemoryCount;
    string RAMsocket;

    //��� �����
    string PowerUnitName;
    int Power;

    //���������� ���������� ��� ����--------

    public List<string> Compl { get; set; }
	public NewPage1()
	{
        //���� ������ ���������, � �� ���� ������� ���������, � ��������� ������....
        Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
        InitializeComponent();
        //����� ��� ������
		Compl = new List<string> { "����", "��", "������", "���������", "����������", "��" };
        BindingContext = this;
    }

    private void ToParceButton_Clicked(object sender, EventArgs e)
    {
        //���� ����� (https://www.nix.ru/) ����� �� ��� ������ ���������� 5 ����
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

                //���� ��� ������

                //������� ������, ���� �� �������������
                ResultLabel.Text = "";
                //�������� ���� �������� ���� ������� �� ������� �������� ���������� ������� �����
                for (int i = 0; i < rows.Count; i++)
                {
                    if (tableData[i, 0] == "������")
                    {
                        if (tableData[i, 1].Length > 22)
                        {
                            //������ ��������, ���� ������ "��������� �������"
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
                    if (tableData[i, 0] == "������ ����������")
                    {

                        if (tableData[i, 1].Length > 22)
                        {
                            string socket = tableData[i, 1].Remove(tableData[i, 1].Length - 16);
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
                    if (tableData[i, 0] == "��� �������������� ������")
                    {
                        //��� ���� ������ DDR4 ����� "���������������� DDR4 � ������ �������� ���������� ���� � �.�"
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
                    if (tableData[i, 0] == "���������� ������ ������")
                    {
                        ResultLabel.Text += tableData[i,1] + "\n";
                        CountRAM = Convert.ToInt32(tableData[i, 1]);
                    }
                }
                MBGPUsocket = "PCI Express 16x";
                //������ ������� ����� ��������� � ������� ���������� ������ ��� ���� PCI ��� ��� �� ����������� ������ ��� ��� ������� ������
                ResultLabel.Text += "PCI Express 16x";
                break;
            case 1:

                //���� ��� ���������

                ResultLabel.Text = "";
                for (int i = 0; i < rows.Count; i++)
                {
                    if (tableData[i, 0] == "������")
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
                    if (tableData[i, 0] == "������ ����������")
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
                    if (tableData[i, 0] == "���������� ����")
                    {
                        string socket = tableData[i, 1];
                        ResultLabel.Text += socket + "\n";
                        CoreCount = Convert.ToInt32(socket);
                        
                    }
                    if (tableData[i, 0] == "���������� �������")
                    {
                        ResultLabel.Text += tableData[i, 1] + "\n";
                        StreamCount = Convert.ToInt32(tableData[i,1]);
                    }
                    if (tableData[i, 0] == "������� ������ ����������")
                    {
                        string[] word = tableData[i, 1].Split(' ');
                        ResultLabel.Text += word[0];
                        CoreHz = Convert.ToDouble( word[0]);
                    }
                    if (tableData[i, 0] == "��������� ����������")
                    {
                        string[] word = tableData[i, 1].Split(' ');
                        if (word[0] == "���")
                        {
                            ResultLabel.Text += "false\n";
                            GraphCore = false;
                        }
                        else { ResultLabel.Text += "true\n"; GraphCore = true; }
                    }
                    
                    if (tableData[i,0]== "������������ ��������")
                    {
                        string[] word = tableData[i, 1].Split(' ');
                        ResultLabel.Text += word[0];
                        CPUPowerEat = Convert.ToInt32(word[0]);
                    }


                }
                //ResultLabel.Text += "PCI Express 16x";
                break;
            case 2:
                //���� ������
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
                    
                    if (tableData[i, 0] == "�����������")
                    {
                        string[] word = tableData[i, 1].Split(' ');
                        ResultLabel.Text +="������"+ word[0]+"\n";
                        GPUMemoryCount = Convert.ToInt32( word[0]);
                    }
                    if (tableData[i, 0] == "��� �����������")
                    {
                        string socket = tableData[i, 1];
                        ResultLabel.Text +="��� "+ socket + "\n";
                        GPUMemoryType = socket;

                    }
                    if (tableData[i, 0] == "������� �����������")
                    {
                        string[] word = tableData[i, 1].Split(' ');
                        ResultLabel.Text +="������� "+ word[0] + "\n";
                        GPUSpeed = Convert.ToInt32( word[0]);
                    }
                    string power="";
                    if (tableData[i, 0] == "�������:������������ �����������������")
                    {
                        string[] word = tableData[i, 1].Split(' ');
                        ResultLabel.Text += "������� " + word[0] + "\n";
                        GPUPowerEat = Convert.ToInt32( word[0]);
                        power = word[0];
                    }
                    else if (tableData[i, 0] == "������������� �������� ����� �������"&&power=="")
                    {
                        string[] word = tableData[i, 1].Split(' ');
                        ResultLabel.Text += "������� " + $"{Convert.ToInt32(word[0]) - Convert.ToInt32(word[0])/2}\n";
                        GPUPowerEat = Convert.ToInt32(word[0]) - Convert.ToInt32(word[0]) / 2;
                    }







                }
                GPUsocket = "PCI Express 16x";
                ResultLabel.Text += "PCI Express 16x";
                break;
            case 4:
                //���� ���������� ������
                ResultLabel.Text = "";
                for (int i = 0; i < rows.Count; i++)
                {
                    if (tableData[i, 0] == "������")
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

                    if (tableData[i, 0] == "������� ����������")
                    {
                        string[] word = tableData[i, 1].Split(' ');
                        //� ���� ��� ������ ���� (�� �� ����)
                        if (word[1] == "��")
                        {
                            ResultLabel.Text += "������" +Convert.ToInt32(word[0])*1024 + "\n";
                            HDDMemoryCount = Convert.ToInt32(word[0]) * 1024;
                        }
                        else {ResultLabel.Text += "������" + word[0] + "\n"; HDDMemoryCount = Convert.ToInt32(word[0]); }
                        
                    }
                    if (tableData[i, 0] == "�������������� �������� �������� ������")
                    {
                        string[] word = tableData[i, 1].Split(' ');
                        ResultLabel.Text += "������� " + word[1] + "\n";
                        HDDMemorySpeed = Convert.ToInt32(word[1]);
                    }
                    //���� � ������� �� �������� ����������������� �� ������� ��������� ��� ������ (�������� �� ��������������)
                    ;
                    if (tableData[i, 0] == "����������� �������")
                    {
                        string[] word = tableData[i, 1].Split(' ');
                        ResultLabel.Text += "������� " + word[0] + "\n";
                        HDDPowerEat = Convert.ToInt32(word[0]);
                        
                    }
                    
                }
                    break;
            case 5:
                //���� ��� ����� �������
                ResultLabel.Text = "";
                for (int i = 0; i < rows.Count; i++)
                {
                    if (tableData[i, 0] == "������")
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
                    if (tableData[i, 0] == "�������� ����� �������")
                    {
                        string[] word = tableData[i, 1].Split(' ');
                        ResultLabel.Text += "����� " + word[0] + "\n";
                        Power = Convert.ToInt32(word[0]);
                    }
                }
                break;
            case 3:
                //���� ��� ���������
                ResultLabel.Text = "";
                for (int i = 0; i < rows.Count; i++)
                {
                    if (tableData[i, 0] == "�����")
                    {
                        string socket = tableData[i, 1];
                        ResultLabel.Text += socket + " ";
                        RAMName = socket;
                    }
                    if (tableData[i, 0] == "������")
                    {
                        string socket = tableData[i, 1];
                        ResultLabel.Text += socket + "\n";
                        RAMName +=" "+ socket;
                        
                    }
                    if (tableData[i, 0] == "��� ������������")
                    {
                        string[] word = tableData[i, 1].Split(' ');
                        ResultLabel.Text += "����� " + word[2] + "\n";
                        RAMsocket = word[2];
                    }
                    if (tableData[i, 0] == "����� ������ ������")
                    {
                        string[] word = tableData[i, 1].Split(' ');
                        
                        ResultLabel.Text += "speed " + word[0] + "\n";
                        RAMMemoryCount = Convert.ToInt32(word[0]);
                    }
                    if (tableData[i, 0] == "���������� ����������� ������")
                    {
                        string[] word = tableData[i, 1].Split(' ');
                        ResultLabel.Text += "speed " + word[0] + "\n";
                        RAMMemorySpeed = Convert.ToInt32(word[0]);
                    }
                }
                break;

        }

    }

    private async void AddDataBase_Clicked(object sender, EventArgs e)
    {
        switch (whoIs.SelectedIndex)
        {
            case 0:
                using (var context = new ConfigContext())
                {
                    BDMotherBoard MB = new BDMotherBoard
                    {
                        MDName = this.MBName,
                        CountRAM = this.CountRAM,
                        CPUsocket = this.CPUsocket,
                        GPUsocket = this.GPUsocket,
                        RAMsocket = this.RAMsocket
                    };
                    context.BDMotherBoards.Add(MB);
                    await context.SaveChangesAsync();
                }
                break;
            case 1:
                using (var context = new ConfigContext())
                {
                    DBCPU cpu = new DBCPU
                    {
                        CoreCount = this.CoreCount,
                        CoreHz = this.CoreHz,
                        CPUName = this.CPUName,
                        CPUsocket = this.CPUsocket,
                        GraphicsCore = this.GraphCore,
                        StreamsCount = this.StreamCount,
                        PowerEat = this.CPUPowerEat
                    };
                    context.DBCPUs.Add(cpu);
                    await context.SaveChangesAsync();
                }
                break;
            case 2:
                using (var context = new ConfigContext())
                {
                    DBGPU gpu = new DBGPU
                    {
                        bandwidth = GPUSpeed,
                        GPUMemoryCount = this.GPUMemoryCount,
                        GPUName = this.GPUName,
                        GPUsocket = this.GPUsocket,
                        MemoryType = this.GPUMemoryType,
                        PowerEat = this.GPUPowerEat
                    };
                    context.DBGPUs.Add(gpu);
                    context.SaveChanges();
                }
                break;
            case 3:
                using (var context = new ConfigContext())
                {
                    DBRAM ram = new DBRAM
                    {
                        RamMemoryCount = this.RAMMemoryCount,
                        RamMemorySpeed = this.RAMMemorySpeed,
                        RAMName = this.RAMName,
                        RAMsocket = this.RAMsocket
                    };
                    context.DBRAMs.Add(ram);
                    context.SaveChanges();
                }
                break;
            case 4:
                using (var context = new ConfigContext())
                {
                    DBHDD hdd = new DBHDD
                    {
                        HDDMemoryCount = this.HDDMemoryCount,
                        HDDName = this.HDDName,
                        HDDPowerEat = this.HDDPowerEat,
                        MemorySpeed = this.HDDMemorySpeed
                    };
                    context.DBHDDs.Add(hdd);
                    context.SaveChanges();
                }
                break;
            case 5:
                using (var context = new ConfigContext())
                {
                    DBPowerUnit pu = new DBPowerUnit
                    {
                        PowerUnitName = this.PowerUnitName,
                        Power = this.Power
                    };
                    context.DBPowerUnits.Add(pu);
                    context.SaveChanges();
                }
                break;

        }
    }
}