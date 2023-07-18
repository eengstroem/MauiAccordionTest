using System.Collections.ObjectModel;

namespace MauiAccordionTest;

public partial class MainPage : ContentPage
{

    public MainPage()
    {
        chartDatas = new List<Sample>();
        chartDatasForBar = new List<Sample>();
        CreateSampleList();
        InitializeComponent();
        BindingContext = this;
    }

    private void CardTapped(object sender, TappedEventArgs e)
    {
        StackLayout stack = sender as StackLayout;
        Grid imageGrid = (Grid)stack.Children[0];
        Image image = (Image)imageGrid.Children[1];


        Grid gridChild = (Grid)stack.Children[2];
        if (gridChild.IsVisible)
        {
            stack.HeightRequest = 90;
            gridChild.IsVisible = false;
            image.Rotation = 0;
        }
        else
        {
            stack.HeightRequest = 300;
            gridChild.IsVisible = true;
            image.Rotation = 180;
        }
    }


    void CreateSampleList()
    {
        //Set some dates
        DateTime a = DateTime.UtcNow;
        DateTime b = new DateTime(
                a.Ticks - (a.Ticks % TimeSpan.TicksPerSecond),
                a.Kind
                );
        DateTime date2 = new DateTime(2023, 6, 25, 10, 30, 50);
        DateTime date3 = new DateTime(2023, 6, 6, 10, 30, 50);
        DateTime date4 = new DateTime(2023, 6, 10, 10, 30, 50);

        DateTime date5 = new DateTime(2023, 6, 12, 10, 30, 50);

        DateTime date6 = new DateTime(2023, 6, 11, 10, 30, 50);
        DateTime date7 = new DateTime(2023, 6, 1, 10, 30, 50);
        DateTime date8 = new DateTime(2023, 6, 5, 10, 30, 50);
        DateTime date9 = new DateTime(2023, 6, 7, 10, 30, 50);
        DateTime date10 = new DateTime(2023, 6, 8, 10, 30, 50);

        //Create collection for the frames
        chartDatas.Add(new Sample
        {
            StrawsAmount = 4,
            MotilityValue = 25,
            Type = "IUI",
            SampleDate = a,
            SampleApproved = true,
            FinanceLevels = new int[] { 100, 200, 100 },
        });
        chartDatas.Add(new Sample
        {
            StrawsAmount = 5,
            MotilityValue = 20,
            Type = "IUI",
            SampleDate = date10,
            SampleApproved = false,
            FinanceLevels = new int[] { 300, 200, 100 },
        });
        chartDatas.Add(new Sample
        {
            StrawsAmount = 2,
            MotilityValue = 30,
            Type = "IUI",
            SampleDate = date2,
            SampleApproved = true,
            FinanceLevels = new int[] { 100, 250, 100 },
        });
        chartDatas.Add(new Sample
        {
            StrawsAmount = 3,
            MotilityValue = 15,
            Type = "IUI",
            SampleDate = date3,
            SampleApproved = true,
            FinanceLevels = new int[] { 100, 200, 300 },
        });
        chartDatas.Add(new Sample
        {
            StrawsAmount = 3,
            MotilityValue = 25,
            Type = "IUI",
            SampleDate = date4,
            SampleApproved = true,
            FinanceLevels = new int[] { 100, 0, 100 },
        });
        chartDatas.Add(new Sample
        {
            StrawsAmount = 3,
            MotilityValue = 20,
            Type = "IUI",
            SampleDate = date5,
            Title = "Semen sample 6",
            SampleApproved = false,
            FinanceLevels = new int[] { 100, 300, 100 },
        });
        chartDatas.Add(new Sample
        {
            StrawsAmount = 2,
            MotilityValue = 30,
            Type = "IUI",
            SampleDate = date6,
            SampleApproved = true,
            FinanceLevels = new int[] { 100, 0, 100 },
        });

        chartDatas = chartDatas.OrderBy(x => x.SampleDate).ToList();
        Data = new ObservableCollection<Sample>(chartDatas);


        //Set names based on # in list
        for (int i = 0; i < chartDatas.Count; i++)
        {
            chartDatas[i].Title = "Semen sample #" + (i + 1);
        }

        //Create collection for the chart
        foreach (Sample data in chartDatas)
        {
            chartDatasForBar.Add(data);
        }

        int totalAmountAll = 0;
        //Set total amount based on amount in sample
        for (int i = 0; i < chartDatas.Count; i++)
        {
            chartDatas[i].TotalAmount = chartDatas[i].FinanceLevels.Sum();
            totalAmountAll += chartDatas[i].FinanceLevels.Sum();
        }



        //Final manipulation before setting
        DataForBarChart = new ObservableCollection<Sample>(chartDatasForBar);
    }


    public Sample SelectedSampleData;
    public IList<Sample> chartDatas;
    public readonly IList<Sample> chartDatasForBar;

    public ObservableCollection<Sample> Data { get; set; } = new();
    public ObservableCollection<Sample> DataForBarChart { get; set; } = new();

    public List<Sample> samplesList { get; private set; } = new List<Sample>();
    public List<Sample> samplesList2 { get; private set; } = new List<Sample>();
}

