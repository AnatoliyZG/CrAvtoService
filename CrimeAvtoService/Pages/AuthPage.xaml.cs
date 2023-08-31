namespace CrimeAvtoService;

public partial class AuthPage : ContentPage
{
    public string PhoneNumber => NumberEntry.Text.Replace(" ", "").Replace("(","").Replace(")","");

	public AuthPage()
	{
		InitializeComponent();
	}

    private void Start_Clicked(object sender, EventArgs e)
    {
        if (PhoneNumber.Length == 12)
        {
            App.Current.MainPage = new NavigationPage();
        }
        else
        {
            ErrorLabel.Text = "����� ������ ���������� � +7 � �������� 12 ��������!";
        }
    }

    private void Number_TextChanged(object sender, TextChangedEventArgs e)
    {
        if(e.NewTextValue.Length < 3)
        {
            NumberEntry.Text = "+7";
        }
    }
}