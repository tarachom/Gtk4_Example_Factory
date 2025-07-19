using Gtk;
using GObject;

using static Gtk.Orientation;

partial class FactoryWindow : Window
{
    [Subclass<GObject.Object>]
    partial class Record
    {
        public Guid Uid { get; set; } = Guid.Empty;
        public string? Назва { get; set; }
        public string? Опис { get; set; }
        public int? Кількість { get; set; }
        public Record(string? Назва, string? Опис, int Кількість, Guid Uid) : this()
        {
            this.Назва = Назва;
            this.Опис = Опис;
            this.Кількість = Кількість;
            this.Uid = Uid;
        }
    }

    public FactoryWindow(Application? app) : base()
    {
        Application = app;
        Title = "Перегляд стовпців та фабрика";
        SetDefaultSize(900, 900);

        Box vBox = Box.New(Vertical, 0);
        vBox.MarginTop = vBox.MarginBottom = vBox.MarginStart = vBox.MarginEnd = 10;
        Child = vBox;

        var store = Gio.ListStore.New(Record.GetGType());

        for (int i = 1; i < 100_000; i++)
            store.Append(new Record($"Назва {i}", $"Текст {i} текст {i} \nТекст {i} текст {i}", i, Guid.NewGuid()));

        SingleSelection model = SingleSelection.New(store);
        model.Autoselect = true;

        ColumnView columnView = ColumnView.New(model);

        //1
        {
            SignalListItemFactory factory = SignalListItemFactory.New();
            factory.OnSetup += (factory, e) =>
            {
                ListItem listitem = (ListItem)e.Object;
                listitem.SetChild(new LabelControl());
            };

            factory.OnBind += (factory, e) =>
            {
                ListItem listitem = (ListItem)e.Object;

                LabelControl? label = (LabelControl?)listitem.GetChild();
                label?.SetText(((Record?)listitem.Item)?.Назва);
            };

            ColumnViewColumn column = ColumnViewColumn.New("Назва", factory);
            column.Resizable = true;

            columnView.AppendColumn(column);
        }

        //2
        {
            SignalListItemFactory factory = SignalListItemFactory.New();
            factory.OnSetup += (factory, e) =>
            {
                ListItem listitem = (ListItem)e.Object;
                listitem.SetChild(new LabelControl2());
            };

            factory.OnBind += (factory, e) =>
            {
                ListItem listitem = (ListItem)e.Object;
                Record? record = (Record?)listitem.Item;

                LabelControl2? label = (LabelControl2?)listitem.GetChild();
                label?.SetText(record?.Назва, record?.Кількість.ToString());
            };

            ColumnViewColumn column = ColumnViewColumn.New("Назва\nКількість", factory);
            column.Resizable = true;

            columnView.AppendColumn(column);
        }

        //3
        {
            SignalListItemFactory factory = SignalListItemFactory.New();
            factory.OnSetup += (factory, e) =>
            {
                ListItem listitem = (ListItem)e.Object;
                listitem.SetChild(new LabelControl3());
            };

            factory.OnBind += (factory, e) =>
            {
                ListItem listitem = (ListItem)e.Object;
                Record? record = (Record?)listitem.Item;

                LabelControl3? label = (LabelControl3?)listitem.GetChild();
                label?.SetText(record?.Назва, record?.Опис, record?.Кількість.ToString(), record?.Uid.ToString());
            };

            ColumnViewColumn column = ColumnViewColumn.New("Назва\nОпис\nКількість / Id", factory);
            column.Resizable = true;

            columnView.AppendColumn(column);
        }

        ScrolledWindow scroll = ScrolledWindow.New();
        scroll.SetPolicy(PolicyType.Automatic, PolicyType.Automatic);
        scroll.Vexpand = true;
        scroll.Child = columnView;

        vBox.Append(scroll);
    }
}