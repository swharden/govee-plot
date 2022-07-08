using Govee.Core;

namespace Govee.Interactive;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
        formsPlot1.Refresh();
        formsPlot1.MouseMove += FormsPlot1_MouseMove;
        formsPlot1.Plot.YLabel("Temperature (F)");
        formsPlot1.Plot.XAxis.DateTimeFormat(true);
        formsPlot1.Plot.Legend(legendToolStripMenuItem.Checked);
        formsPlot1.Configuration.EnablePlotObjectEditor = true;
    }

    private void FormsPlot1_MouseMove(object? sender, MouseEventArgs e)
    {
        formsPlot1.Invalidate();
    }

    private void loadCSVToolStripMenuItem_Click(object sender, EventArgs e)
    {
        OpenFileDialog diag = new()
        {
            Title = "Select a Govee data file",
            Filter = "CSV files (*.csv)|*.csv",
        };

        if (diag.ShowDialog() == DialogResult.OK)
        {
            Reading[] readings = DataFile.GetReadings(diag.FileName);
            string label = Path.GetFileName(diag.FileName).Split("_")[0];
            AddReadingsToPlot(readings, label);
        }
    }

    private void AddReadingsToPlot(Reading[] readings, string label)
    {
        double[] temps = readings.Select(x => x.Tempearture).ToArray();
        double[] xs = readings.Select(x => x.Timestamp.ToOADate()).ToArray();
        formsPlot1.Plot.AddSignalXY(xs, temps, label: label);

        if (formsPlot1.Plot.GetPlottables().Length == 1)
            formsPlot1.Plot.AxisAuto();

        formsPlot1.Refresh();
    }

    private void legendToolStripMenuItem_Click(object sender, EventArgs e)
    {
        formsPlot1.Plot.Legend(legendToolStripMenuItem.Checked);
        formsPlot1.Refresh();
    }

    private void saveImageToolStripMenuItem_Click(object sender, EventArgs e)
    {
        SaveFileDialog savefile = new();
        savefile.FileName = "govee.png";
        savefile.Filter = "PNG Files (*.png)|*.png";
        if (savefile.ShowDialog() == DialogResult.OK)
        {
            formsPlot1.Plot.SaveFig(savefile.FileName);
        }
    }

    private void clearToolStripMenuItem_Click(object sender, EventArgs e)
    {
        formsPlot1.Plot.Clear();
        formsPlot1.Refresh();
    }
}
