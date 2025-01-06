using MonkeyFinder.Services;

namespace MonkeyFinder.ViewModel;

public partial class MonkeysViewModel : BaseViewModel
{
    MonkeyService monkeyService;
    public ObservableCollection<Monkey> Monkeys { get; } = new();

    public MonkeysViewModel(MonkeyService monkeyService)
    {
        Title = "Monkey Finder";
        this.monkeyService = monkeyService;
    }

    [RelayCommand] //from mvvm toolkit input namespace formerly called ICommand

    async Task GetMonkeysAsync()
    {
        if (IsBusy) return;

        try
        {
            IsBusy = true;
            var monkeys = await monkeyService.GetMonkeys();

            if (Monkeys.Count != 0)
                Monkeys.Clear();

            foreach (var monkey in monkeys)
                Monkeys.Add(monkey);
             //if thousands of items don't call an event each time; do batch adding so one event is called
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
            //accessing UI through viewmodel isn't good practice it's better to use an interface
            await Shell.Current.DisplayAlert("Error!", $"Unable to get monkeys {ex.Message}", "OK"); //also bad practice to directly output the error
            //using Shell allows for multiple window options
        }
        finally
        {
            IsBusy = false;
        }
    }
}
