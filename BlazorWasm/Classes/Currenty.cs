public class Currenty
{
    public string Name { get; set; } = "Swag";
    public Currenty()
    {
        Console.WriteLine("Currenty created");
    }

    public event Action OnChange;
    public void NotifyStateChanged() => OnChange?.Invoke();
}
