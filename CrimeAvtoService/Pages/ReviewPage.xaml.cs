using System.Linq;
using System.Windows.Input;

namespace CrimeAvtoService;

public partial class ReviewPage : ContentPage
{


    public ReviewPage()
    {
        InitializeComponent();
        LoadServices();
    }

    private void Search_TextChanged(object sender, TextChangedEventArgs e)
    {
    }

    public void LoadServices()
    {
        if (ServicesViewLayout.Count > 0)
            ServicesViewLayout.Clear();

        foreach (var service in AvtoServiceDB.avtoServices)
        {
            ServicesViewLayout.Add(LoadService(service));
        }
    }


    private Frame LoadService(AvtoService service, bool isVisible = true)
    {
        return new Frame()
        {
            HeightRequest = 80,
            Margin = new Thickness(5, 3),
            Padding = 0,
            IsVisible = IsVisible,

            Content = new Grid()
            {
                Children =
                {
                    new Button()
                    {
                        HorizontalOptions = LayoutOptions.Fill,
                        VerticalOptions = LayoutOptions.Fill,
                        BorderColor= Colors.DarkGray,
                        BackgroundColor= Colors.White,
                        BorderWidth = 1,
                        CornerRadius=10,
                    },
                    new HorizontalStackLayout()
                    {
                        Padding = new Thickness(0, 2),
                        Children =
                        {
                            new Image()
                            {
                                BackgroundColor= Colors.DarkGray,
                                Margin=5,
                                HeightRequest=70,
                                WidthRequest=70,
                            },
                            new VerticalStackLayout()
                            {
                                Children =
                                {
                                    new Label()
                                    {
                                        Margin=2,
                                        TextColor=Colors.Black,
                                        FontSize=16,
                                        HorizontalOptions= LayoutOptions.Start,
                                        Text =$"«{service.Name}»",
                                    }
                                },
                            }
                        }
                    },
                }
            },
        };
    }

    private void Search_Clicked(object sender, EventArgs e)
    {
        string filter = SearchRequest.Text.Trim();

        var children = ServicesViewLayout.Children.Select(a => a as Frame).ToArray();

        int index = 0;

        foreach (var service in AvtoServiceDB.avtoServices)
        {
            children[index].IsVisible = filter.Length == 0 || service.Name.ToLower().Contains(filter.ToLower()) || service.Services.Contains(filter.ToLower());

            index++;
        }

        // ServicesView.
        //  LoadServices(SearchRequest.Text);
    }

    private void ServiceRefreshView_Refreshing(object sender, EventArgs e)
    {
        LoadServices();
        ServiceRefreshView.IsRefreshing = false;
    }
}