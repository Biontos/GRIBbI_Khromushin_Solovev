using MushroomsApp.Models;

namespace MushroomsApp;

public partial class MainPage : ContentPage
{
    private List<Mushroom> mushrooms = new();

    public MainPage()
    {
        InitializeComponent();
        SeedData();
        RefreshList();
    }

    void SeedData()
    {
        
    }

    void RefreshList()
    {
        MushroomList.ItemsSource = null;
        MushroomList.ItemsSource = mushrooms;
    }

    async void OnAddClicked(object sender, EventArgs e)
    {
        var page = new AddEditPage();
        page.Saved += (s, newMushroom) =>
        {
            mushrooms.Add(newMushroom);
            RefreshList();
        };
        await Navigation.PushAsync(page);
    }

    async void OnEditClicked(object sender, EventArgs e)
    {
        var mushroom = (sender as SwipeItem)?.BindingContext as Mushroom;
        if (mushroom != null)
        {
            var page = new AddEditPage(mushroom);
            page.Saved += (s, updatedMushroom) =>
            {
                mushroom.Name = updatedMushroom.Name;
                mushroom.Description = updatedMushroom.Description;
                RefreshList();
            };
            await Navigation.PushAsync(page);
        }
    }

    void OnDeleteClicked(object sender, EventArgs e)
    {
        var mushroom = (sender as SwipeItem)?.BindingContext as Mushroom;
        if (mushroom != null)
        {
            mushrooms.Remove(mushroom);
            RefreshList();
        }
    }
}
