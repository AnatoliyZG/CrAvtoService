namespace CrimeAvtoService;

public partial class App : Application
{
	public bool Authed = false;

	public App()
	{
		InitializeComponent();

		MainPage = Authed ? new NavigationPage() : new AppShell();
	}
}

public enum AuthSate
{
	NonAuthorized = 0,
	AvtoUser = 1,
	AvtoService = 2,
}
