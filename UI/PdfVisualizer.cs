using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Function = System.Func<double, double, double>;

namespace DOS2Randomizer.UI {
    public partial class PdfVisualizer : UserControl {
        private Function? _func;
        private double _importance = 1;
        private const double ImportanceBarFactor = 1000;
        private const double ImportanceScaling = 20;
        private string _xLabel = "";
        private int _xRange = 10;
        public PdfVisualizer() {
            InitializeComponent();
            plotCanvas.Configuration.LockHorizontalAxis = true;
            plotCanvas.Configuration.LockVerticalAxis = true;
            plotCanvas.Plot.YLabel("Likelihood");
            importanceBar.TickFrequency = (int)ImportanceBarFactor;
            importanceBar.Value = (int)(ImportanceBarFactor / 2);
            importanceBar.ValueChanged += (_, _) => { SetImportance(); };
        }

        private (double[], double[]) Sample(Function f) {
            double[] x = Enumerable.Range(0, XRange).Select(v => (double)v).ToArray();
            double[] y = x.Select(xVal => f(xVal, _importance)).ToArray();
            return (x, y);
        }

        private void UpdatePlot() {
            if (_func is null) {
                return;
            }

            plotCanvas.Plot.Clear();
            var (x, y) = Sample(_func);
            plotCanvas.Plot.AddScatter(x, y);
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

        public Function? Function {
            get => _func;
            set {
                _func = value;
                UpdatePlot();
            }
        }
    }
}
