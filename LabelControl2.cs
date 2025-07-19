
using Gtk;

public class LabelControl2 : Box
{
    Label label1;
    Label label2;

    public LabelControl2() : base()
    {
        SetOrientation(Orientation.Vertical);
        Valign = Align.Start;

        {
            label1 = Label.New(null);
            label1.Halign = Align.Start;

            Append(label1);
        }

        {
            Separator separator = Separator.New(Orientation.Vertical);
            Append(separator);
        }

        {
            label2 = Label.New(null);
            label2.Halign = Align.Start;

            Append(label2);
        }
    }

    public void SetText(string? text1, string? text2)
    {
        label1.SetText(text1 ?? "");
        label2.SetText(text2 ?? "");
    }
}