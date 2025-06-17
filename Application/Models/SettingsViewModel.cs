using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.Maui.Graphics;

namespace Application.ViewModels
{
    public partial class SettingsViewModel : ObservableObject
    {
        [ObservableProperty]
        private bool isDarkTheme = false;

        public Color BackgroundColor => IsDarkTheme ? Colors.Black : Colors.White;
        public Color PageBackgroundColor => IsDarkTheme ? Colors.Black : Colors.White;
        public Color CardBackgroundColor => IsDarkTheme ? Color.FromArgb("#222") : Colors.White;
        public Color TextColor => IsDarkTheme ? Colors.White : Color.FromArgb("#333");
        public Color SubTextColor => IsDarkTheme ? Colors.LightGray : Color.FromArgb("#666");
        public Color DividerColor => IsDarkTheme ? Color.FromArgb("#444") : Color.FromArgb("#CCC");

        partial void OnIsDarkThemeChanged(bool value)
        {
            OnPropertyChanged(nameof(BackgroundColor));
            OnPropertyChanged(nameof(TextColor));
            OnPropertyChanged(nameof(PageBackgroundColor));
            OnPropertyChanged(nameof(CardBackgroundColor));
            OnPropertyChanged(nameof(SubTextColor));
            OnPropertyChanged(nameof(DividerColor));
        }
    }
}