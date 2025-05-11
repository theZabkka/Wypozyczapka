<?xml version="1.0" encoding="utf-8" ?>
<ContentPage xmlns="http://schemas.microsoft.com/dotnet/2021/maui"
             xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
             x:Class="Application.Pages.HomePage"
             BackgroundColor="#F8F8FF"
             Shell.NavBarIsVisible="False"
             Shell.TabBarIsVisible="False">

    <Grid>

        <Image Source="tlo.png"
               Aspect="AspectFill"
               Opacity="0.2"
               ZIndex="0" />

        <!-- Pasek tytułowy -->
        <Border BackgroundColor="White"
                HeightRequest="80"
                VerticalOptions="Start"
                HorizontalOptions="Fill"
                ZIndex="1">
            <Border.StrokeShape>
                <RoundRectangle CornerRadius="0,0,20,20" />
            </Border.StrokeShape>
            <Label Text="WypożyczApka"
                   HorizontalOptions="Center"
                   VerticalOptions="Center"
                   FontSize="28"
                   FontAttributes="Bold"
                   TextColor="#4A4A4A"/>
        </Border>

        <!-- Lista kafelków z aktualnościami -->
        <CollectionView ItemsLayout="VerticalList"
                        Margin="20,100,20,20"
                        x:Name="NewsCollectionView"
                        ZIndex="2">
            <CollectionView.ItemTemplate>
                <DataTemplate>
                    <Frame CornerRadius="20"
                           HasShadow="True"
                           Margin="0,10"
                           Padding="0"
                           BackgroundColor="White">
                        <Grid RowDefinitions="Auto,Auto"
                              ColumnDefinitions="Auto,*">
                            <Image Source="{Binding ImageSource}"
                                   WidthRequest="100"
                                   HeightRequest="100"
                                   Margin="10"
                                   Aspect="AspectFill"
                                   Grid.RowSpan="2"/>
                                   <!--CornerRadius="10"-->
                            <Label Text="{Binding Title}"
                                   FontSize="18"
                                   FontAttributes="Bold"
                                   TextColor="#333"
                                   Margin="10,10,10,0"
                                   Grid.Column="1"/>
                            <Label Text="{Binding Description}"
                                   FontSize="14"
                                   TextColor="#555"
                                   Margin="10,0,10,10"
                                   Grid.Column="1"
                                   Grid.Row="1"/>
                        </Grid>
                    </Frame>
                </DataTemplate>
            </CollectionView.ItemTemplate>
        </CollectionView>

    </Grid>
</ContentPage>
