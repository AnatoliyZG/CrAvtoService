namespace CrimeAvtoService;

public partial class ProfilePage : ContentPage
{
	public ProfilePage()
	{
		InitializeComponent();
	}

    private void ExitProfile_Clicked(object sender, EventArgs e)
    {
		App.Current.MainPage = new AppShell();
    }
}