namespace Application.Pages;
using Application.Models;
using System.Collections.ObjectModel;

public partial class HomePage : ContentPage
{
    private ObservableCollection<NewsItem> visibleItems = new();
    private HashSet<NewsItem> allUniqueItems = new();

    public HomePage()
    {
        InitializeComponent();
        LoadNews();
        NewsCollectionView.ItemsSource = visibleItems;
    }

    private void LoadNews()
    {
        var wydarzenia = new List<NewsItem>
    {
    new NewsItem
    {
        Id = Guid.NewGuid(),
        Title = "Dzień Sportu",
        Description = "Zapraszamy wszystkich uczniów na coroczny Dzień Sportu! Zawody rozpoczynają się o 9:00 na boisku.",
        ImageSource = "dziensportu.jpg"
    },
    new NewsItem
    {
        Id = Guid.NewGuid(),
        Title = "Konkurs Matematyczny",
        Description = "Sprawdź swoje umiejętności w konkursie matematycznym. Nagrody czekają na najlepszych!",
        ImageSource = "konkurs.jpg"
    },
    new NewsItem
    {
        Id = Guid.NewGuid(),
        Title = "Wycieczka do Torunia",
        Description = "Zapisy na wycieczkę szkolną do Torunia trwają do piątku. Liczba miejsc ograniczona!",
        ImageSource = "torun.jpg"
    },
    new NewsItem
    {
        Id = Guid.NewGuid(),
        Title = "Dzień Bez Plecaka",
        Description = "Już w środę Dzień Bez Plecaka! Przynieś książki w nietypowy sposób i zgarnij nagrodę za kreatywność.",
        ImageSource = "dzienbez.jpg"
    },
    new NewsItem
    {
        Id = Guid.NewGuid(),
        Title = "Warsztaty z Programowania",
        Description = "Zajęcia dla początkujących z podstaw C#. Zapisy w sali 204 do środy.",
        ImageSource = "programowanie.jpg"
    },
  
    new NewsItem
    {
        Id = Guid.NewGuid(),
        Title = "Szkolny Festiwal Talentów",
        Description = "Zgłoś swój występ i pokaż, co potrafisz! Rejestracja do piątku u pedagoga.",
        ImageSource = "mamtalent.jpg"
    },
    new NewsItem
    {
        Id = Guid.NewGuid(),
        Title = "Akcja 'Sprzątanie Świata'",
        Description = "Wspólnie zadbajmy o otoczenie szkoły. Uczestnicy otrzymają punkty z zachowania.",
        ImageSource = "sprzatanie.jpg"
    },
    new NewsItem
    {
        Id = Guid.NewGuid(),
        Title = "Tydzień Języków Obcych",
        Description = "Codziennie konkursy i gry w różnych językach. Sprawdź plan na tablicy ogłoszeń.",
        ImageSource = "tydzien.jpg"
    }
};
        foreach (var wydarzenie in wydarzenia)
        {
            AddNewsItem(wydarzenie);
        }
    }

    public void AddNewsItem(NewsItem item)
    {
        if (!allUniqueItems.Add(item))
            return; // Już istnieje — nie dodajemy

        if (visibleItems.Count >= 15)
        {
            var toRemove = visibleItems[0];
            visibleItems.RemoveAt(0);
            allUniqueItems.Remove(toRemove);
        }

        visibleItems.Add(item);
    }
    private void OnMenuClicked(object sender, EventArgs e)
    {
        Shell.Current.FlyoutIsPresented = true;
    }
    private async void OnWypozyczTapped(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//Wypozyczenia"); // lub inną nazwę Twojej strony
    }


}

