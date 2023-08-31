namespace CrimeAvtoService;

public partial class ReviewPage : ContentPage
{
    public ReviewPage()
    {
        InitializeComponent();
        Content = LoadServices();
    }

    public View GetContent() // LATER
    {
        VerticalStackLayout layout = new VerticalStackLayout()
        {
            Children =
            {
                LoadServices(),
            },
        };

        return layout;
    }

    public ScrollView LoadServices()
    {
        StackLayout views = new StackLayout();

        foreach (var service in AvtoServiceDB.avtoServices)
        {
            views.Add(LoadService(service));
        }

        return new ScrollView()
        {
            Content = views,
        };
    }


    private Frame LoadService(AvtoService service)
    {
        return new Frame()
        {
            HeightRequest = 80,
            Margin = new Thickness(5, 3),
            Padding = 0,

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
                        HorizontalOptions = LayoutOptions.Center,
                        Padding = new Thickness(0, 2),
                        Children =
                        {
                            new Label()
                            {
                                TextColor=Colors.Gray,
                                FontSize=18,
                                HorizontalOptions= LayoutOptions.Center,
                                Text = service.Name,
                            }
                        }
                    },
                }
            },
        };
    }
}