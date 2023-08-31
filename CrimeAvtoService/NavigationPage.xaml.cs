namespace CrimeAvtoService;

public partial class NavigationPage : Shell
{
    public static NavigationPage navigation;

    public NavigationPage()
    {
        InitializeComponent();
        navigation = this;
    }

    public void LoadTab(int tab)
    {
        switch (tab)
        {
            case 0:
                CurrentItem = mapPage;
                break;
            case 1:
                CurrentItem = reviewPage;
                break;
            case 2:
                CurrentItem = profilePage;
                break;
        }

    }
}