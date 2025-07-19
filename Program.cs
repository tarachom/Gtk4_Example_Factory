
using Gtk;
using Gdk;

class Program
{
    static void Main()
    {
        var app = Application.New("ua.org.accounting.factory", Gio.ApplicationFlags.FlagsNone);

        app.OnActivate += (_, args) =>
        {
            FactoryWindow factoryWindow = new(app);
            factoryWindow.Show();
        };

        //Css
        {
            string styleDefaultFile = Path.Combine(AppContext.BaseDirectory, "Default.css");
            var displayDefault = Display.GetDefault();

            if (File.Exists(styleDefaultFile) && displayDefault != null)
            {
                CssProvider provider = CssProvider.New();
                provider.LoadFromPath(styleDefaultFile);
                StyleContext.AddProviderForDisplay(displayDefault, provider, 800);
            }
        }

        app.RunWithSynchronizationContext(null);
    }
}
