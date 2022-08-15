using System;
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

        public double Std {
            get => _importance;
            set {
                _importance = value;
                plotCanvas.Refresh();
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
                plotCanvas.Plot.SetAxisLimits(0, XRange, 0, 1);
                plotCanvas.Refresh();
            }

        }

        private void SetImportance() {
            _importance = Math.Exp((0.5 - importanceBar.Value / ImportanceBarFactor) * ImportanceScaling);
            plotCanvas.Refresh();
        }

        public Function? Function {
            get => _func;
            set {
                _func = value;
                if (_func is not null) {
                    plotCanvas.Plot.AddFunction(x => _func(x, _importance));
                    plotCanvas.Plot.SetAxisLimits(0, XRange, 0, 1);
                    plotCanvas.Refresh();
                }
            }
        }
    }
}
