using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EncryptionTool
{
    public partial class FormPopup : Form
    {
        private string _popupLabelText;
        public FormPopup(string popupLabelText)
        {
            InitializeComponent();

            _popupLabelText = popupLabelText;
        }

        private void FormPopup_Load(object sender, EventArgs e)
        {
            this.popupLabel.Text = _popupLabelText;
        }
    }
}
