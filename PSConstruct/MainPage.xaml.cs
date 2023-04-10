namespace PSConstruct;

public partial class MainPage : ContentPage
{
	public List<string> MatherBoard { get; set; }
	public List<string> CPU { get; set; }
	public List<string> GPU { get; set; }
	public List<string> RAM { get; set; }
	public List<string> HDD { get; set; }
	public List<string> PowerUnit { get; set; }

	public MainPage()
	{
		InitializeComponent();

		//Листы для биндингов (надо будет убрать фигурные кобки и заполнить эти листы из базы)
		MatherBoard = new List<string> { "Asus Rogue B450", "MSI MAG B560" };
		CPU = new List<string> { "I9-13600", "RYZEN 2600", "RUZEN 3600" };
		GPU = new List<string> { "Radeon 570 8GB", "Geforce RTX 4090" };
		RAM = new List<string> { "Apacer", "ADATA XPG Lancer" };
		HDD = new List<string> { "Samsung EVO 560 500GB"};
		PowerUnit = new List<string> {"DA700"};

		//Выключение кнопок, чтоб раньше заполнения не нажимались
		ButtonMatherBoard.IsEnabled= false;
		ButtonCPU.IsEnabled = false;
		ButtonGPU.IsEnabled = false;
		ButtonRAM.IsEnabled = false;
		ButtonHDD.IsEnabled = false;
		ButtonPowerUnit.IsEnabled = false;


		


		BindingContext = this;
	}

    private async void Back_Clicked(object sender, EventArgs e)
    {
		await Navigation.PopModalAsync();
    }


	//Чисто кнопки для просмотра характеристик
    private void ButtonMatherBoard_Clicked(object sender, EventArgs e)
    {

    }

    private void ButtonCPU_Clicked(object sender, EventArgs e)
    {

    }

    private void ButtonGPU_Clicked(object sender, EventArgs e)
    {

    }

    private void ButtonRAM_Clicked(object sender, EventArgs e)
    {

    }

    private void ButtonHDD_Clicked(object sender, EventArgs e)
    {

    }

	//Пока реализуют только включение кнопок если Picker в выбраном не пустой 
    //Еще очищают остальные пикеры если мать поменялась
	//(01.04) Как я понимаю надо в этих же обработчикх делать привязку на синхронизацию с матью
    private void PikcerMatherBoard_SelectedIndexChanged(object sender, EventArgs e)
    {
        //Очистка пикеров если мать поменялась
        PickerGPU.SelectedIndex = -1;
        PickerCPU.SelectedIndex = -1;
        PickerRAM.SelectedIndex = -1;
        //-----
        if (PikcerMatherBoard.SelectedIndex !=-1)
        {
            ButtonMatherBoard.IsEnabled = true;
        }
        else
        {
            ButtonMatherBoard.IsEnabled = false;
        }
    }
    private void PickerGPU_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (PickerGPU.SelectedIndex !=-1)
        {
            ButtonGPU.IsEnabled = true;
        }
		else
		{
			ButtonGPU.IsEnabled = false;
		}
    }

    private void PickerCPU_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (PickerCPU.SelectedIndex != -1)
        {
            ButtonCPU.IsEnabled = true;
        }
        else
        {
            ButtonCPU.IsEnabled = false;
        }
    }

    private void PickerRAM_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (PickerRAM.SelectedIndex != -1)
        {
            ButtonRAM.IsEnabled = true;
        }
        else
        {
            ButtonRAM.IsEnabled = false;
        }
    }

    private void PickerHDD_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (PickerHDD.SelectedIndex != -1)
        {
            ButtonHDD.IsEnabled = true;
        }
        else
        {
            ButtonHDD.IsEnabled = false;
        }
    }

    private void PickerPowerUnit_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (PickerPowerUnit.SelectedIndex != -1)
        {
            ButtonPowerUnit.IsEnabled = true;
        }
        else
        {
            ButtonPowerUnit.IsEnabled = false;
        }
    }
}

