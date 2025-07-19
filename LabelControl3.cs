
using Gtk;

public class LabelControl3 : Box
{
    Label label1;
    Label label2;
    Label label3;
    Label label4;

    public LabelControl3() : base()
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

            Expander expander = Expander.New("Опис");
            expander.Child = label2;

            Append(expander);
        }

        {
            Separator separator = Separator.New(Orientation.Vertical);
            Append(separator);
        }

        {
            Box hBox = Box.New(Orientation.Horizontal, 0);
            Append(hBox);

            label3 = Label.New(null);
            label3.Halign = Align.Start;
            hBox.Append(label3);

            Separator separator = Separator.New(Orientation.Horizontal);
            separator.MarginStart = separator.MarginEnd = 10;
            hBox.Append(separator);

            label4 = Label.New(null);
            label4.Halign = Align.Start;
            hBox.Append(label4);
        }
    }

    public void SetText(string? text1, string? text2, string? text3, string? text4)
    {
        label1.SetText(text1 ?? "");
        label2.SetText(text2 ?? "");
        label3.SetText(text3 ?? "");
        label4.SetText(text4 ?? "");
    }
}