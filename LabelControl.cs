
using Gtk;

public class LabelControl : Box
{
    Label label;

    public LabelControl() : base()
    {
        SetOrientation(Orientation.Horizontal);
        Valign = Align.Start;

        label = Label.New(null);
        label.Halign = Align.Start;

        Append(label);
    }

    public void SetText(string? text)
    {
        label.SetText(text ?? "");
    }
}