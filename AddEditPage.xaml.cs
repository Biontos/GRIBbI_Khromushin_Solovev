using MushroomsApp.Models;

namespace MushroomsApp;

public partial class AddEditPage : ContentPage
{
    public event EventHandler<Mushroom> Saved;

    private Mushroom editingMushroom;

    public AddEditPage(Mushroom mushroom = null)
    {
        InitializeComponent();

        if (mushroom != null)
        {
            editingMushroom = mushroom;
            NameEntry.Text = mushroom.Name;
            DescriptionEditor.Text = mushroom.Description;
        }
    }

    void OnSaveClicked(object sender, EventArgs e)
    {
        var name = NameEntry.Text?.Trim();
        var description = DescriptionEditor.Text?.Trim();

        if (string.IsNullOrWhiteSpace(name))
        {
            DisplayAlert("Ошибка", "Название не может быть пустым", "OK");
            return;
        }

        var result = new Mushroom { Name = name, Description = description };
        Saved?.Invoke(this, result);
        Navigation.PopAsync();
    }
}
