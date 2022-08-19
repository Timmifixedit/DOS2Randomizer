using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Function = System.Func<double, double, double>;

namespace DOS2Randomizer.UI {
    public partial class PdfVisualizer : UserControl {
        private Function _func;
        private double _importance = 1;
        private const double ImportanceBarFactor = 1000;
        private const double ImportanceScaling = 20;
        private string _xLabel;
        private int _xRange;
        private readonly int[]? _levelSamples;
        
        public PdfVisualizer(Function function, int xRange, string xLabel, int[]? levelSamples = null) {
            InitializeComponent();
            _xRange = xRange;
            _xLabel = xLabel;
            _func = function;
            _levelSamples = levelSamples;
            plotCanvas.Configuration.LockHorizontalAxis = true;
            plotCanvas.Configuration.LockVerticalAxis = true;
            plotCanvas.Plot.YLabel("Likelihood");
            importanceBar.TickFrequency = (int)ImportanceBarFactor;
            importanceBar.Value = (int)(ImportanceBarFactor / 2);
            importanceBar.ValueChanged += (_, _) => { SetImportance(); };
            UpdatePlot();
        }

        private int[] LevelSamples => _levelSamples ?? new[] { 1 };

        private (double[], double[]) Sample(Function f) {
            double[] x = Enumerable.Range(0, XRange).Select(v => (double)v).ToArray();
            double[] y = x.Select(xVal => f(xVal, _importance)).ToArray();
            return (x, y);
        }

        private void UpdatePlot() {
            plotCanvas.Plot.Clear();
            foreach (int level in LevelSamples) {
                var (xRange, y) = Sample((x, std) => _func(x, level * std));
                plotCanvas.Plot.AddScatter(xRange, y, label:$"level {level}");
            }

            plotCanvas.Plot.Legend();
            plotCanvas.Plot.SetAxisLimits(0, XRange, 0, 1);
            plotCanvas.Refresh();
        }

        public double Std {
            get => _importance;
            set {
                _importance = value;
                UpdatePlot();
            }
        }
        public string XLabel {
            get => _xLabel;
            set {
                _xLabel = value;
                plotCanvas.Plot.XLabel(XLabel);
                plotCanvas.Refresh();
            }
        }

        public int XRange {
            get => _xRange;
            set {
                _xRange = value;
                UpdatePlot();
            }

        }

        private void SetImportance() {
            _importance = Math.Exp((0.5 - importanceBar.Value / ImportanceBarFactor) * ImportanceScaling);
            UpdatePlot();
        }

        public Function Function {
            get => _func;
            set {
                _func = value;
                UpdatePlot();
            }
        }
    }
}
