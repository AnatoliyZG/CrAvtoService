using System.IO;

namespace CrimeAvtoService;

public partial class AuthPage : ContentPage
{
    private static string filePath => Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "temp.txt");
    public string phone => NumberEntry.Text.Replace(" ", "").Replace("(","").Replace(")","");

    public static string PhoneNumber;

	public AuthPage()
	{
		InitializeComponent();

        if (File.Exists(filePath))
        {
            string content = File.ReadAllText(filePath);

            if(content.Length == 12)
            {
                LoadNavigationPage(content);
            }
            else
            {
                DeleteCache();
            }
        }
	}

    private void Start_Clicked(object sender, EventArgs e)
    {
        if (phone.Length == 12)
        {
            LoadNavigationPage(phone);
            File.WriteAllText(filePath, phone);
        }
        else
        {
            ErrorLabel.Text = "Номер должен начинаться с +7 и содежать 12 символов!";
        }
    }

    private void Number_TextChanged(object sender, TextChangedEventArgs e)
    {
        if(e.NewTextValue.Length < 3)
        {
            NumberEntry.Text = "+7";
        }
    }

    public void LoadNavigationPage(string phone)
    {
        PhoneNumber = phone;
        App.Current.MainPage = new NavigationPage();
    }

    public static void DeleteCache()
    {
        File.Delete(filePath);
    }
}