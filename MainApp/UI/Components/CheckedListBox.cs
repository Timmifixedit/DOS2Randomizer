using System.Windows.Forms;

namespace DOS2Randomizer.UI.Components {
    public class CheckedListBox : System.Windows.Forms.CheckedListBox, IChoosableDesign {
        private DesignType _design = DesignType.Dark;

        public DesignType Design {
            get => _design;
            set {
                _design = value;
                var design = UI.Design.Get(_design);
                BackColor = design.EditBackColor;
                ForeColor = design.TextColor;
                BorderStyle = design.BorderStyle;
            }
        }

        protected override void OnDrawItem(DrawItemEventArgs e) {
            var design = UI.Design.Get(Design);
            bool selected = (e.State & DrawItemState.Selected) == DrawItemState.Selected;
            var selectColor = selected ? design.SelectedColor : BackColor;
            var state = selected ? e.State ^ DrawItemState.Selected : e.State;
            var eventArg = new DrawItemEventArgs(e.Graphics, e.Font, e.Bounds, e.Index,
                state, e.ForeColor, selectColor);
            base.OnDrawItem(eventArg);
        }
    }
}