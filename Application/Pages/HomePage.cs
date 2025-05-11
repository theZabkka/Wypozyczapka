namespace Application.Pages;
using Application.Models;
using System.Collections.ObjectModel;

public partial class HomePage : ContentPage
{
    private ObservableCollection<NewsItem> newsItems = new();

    public HomePage()
    {
        InitializeComponent();
        LoadNews();
        NewsCollectionView.ItemsSource = newsItems;
    }

    private void LoadNews()
    {
        for (int i = 1; i <= 15; i++)
        {
            newsItems.Add(new NewsItem  
            {
                Title = $"Wydarzenie #{i}",
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.",
                ImageSource = $"obraz{i}.png"
                //kutas kozła
            });
        }
    }

    public void AddNewsItem(NewsItem item)
    {
        if (newsItems.Count >= 15)
            newsItems.RemoveAt(0); // usuń najstarszy
        newsItems.Add(item);
    }
}
