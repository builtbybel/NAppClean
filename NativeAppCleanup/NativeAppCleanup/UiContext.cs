using System.Windows.Forms;

namespace NAppClean
{
    public class UiContext
    {
        public Label HeaderLabel { get; set; }

        public TextBox CommentBox { get; set; }
        public TextBox SupportedBox { get; set; }
        public TextBox HelpBox { get; set; }

        public RadioButton RadioEnabled { get; set; }
        public RadioButton RadioDisabled { get; set; }
        public Panel MainPanel { get; set; }
    }
}