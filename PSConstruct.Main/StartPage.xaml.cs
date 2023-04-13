namespace PSConstruct;

public partial class StartPage : ContentPage
{
	public StartPage()
	{
		InitializeComponent();
		//StartPage = new NavigationPage(new StartPage());
	}

    private async void Button_Clicked(object sender, EventArgs e)
    {
		Header.Text = "«¿√–”« ¿";
		await Navigation.PushModalAsync(new MainPage());
	}

    private async void ToParceButton_Clicked(object sender, EventArgs e)
    {
		await Navigation.PushModalAsync(new NewPage1());
    }

}