using System;
using System.Drawing;
using System.Windows.Forms;

namespace TestDatasets
{
    public class CustomMessageBox : Form
    {
        private Panel contentPanel;

        public CustomMessageBox(string message, string title, MessageBoxButtons buttons)
        {
            this.Text = title;
            this.Size = new Size(800, 400);
            this.MaximumSize = new Size(1200, 800);
            this.StartPosition = FormStartPosition.CenterScreen;

            // Erstellen Sie ein scrollbares Panel
            Panel scrollPanel = new Panel
            {
                Dock = DockStyle.Fill,
                AutoScroll = true
            };

            // Erstellen Sie ein Panel für den Inhalt
            contentPanel = new Panel
            {
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink
            };

            // Fügen Sie den Inhalt zum contentPanel hinzu
            Label messageLabel = new Label
            {
                Text = message,
                AutoSize = true,
                MaximumSize = new Size(350, 0) // Maximale Breite, unbegrenzte Höhe
            };
            contentPanel.Controls.Add(messageLabel);

            // Fügen Sie das contentPanel zum scrollPanel hinzu
            scrollPanel.Controls.Add(contentPanel);

            // Erstellen Sie ein Panel für die Buttons
            FlowLayoutPanel buttonPanel = new FlowLayoutPanel
            {
                Dock = DockStyle.Bottom,
                FlowDirection = FlowDirection.RightToLeft,
                Height = 40
            };

            // Fügen Sie die Panels zum Formular hinzu
            this.Controls.Add(scrollPanel);
            this.Controls.Add(buttonPanel);

            if (buttons == MessageBoxButtons.OK || buttons == MessageBoxButtons.OKCancel)
            {
                AddButton(buttonPanel, "OK", DialogResult.OK);
            }
            if (buttons == MessageBoxButtons.YesNo || buttons == MessageBoxButtons.YesNoCancel)
            {
                AddButton(buttonPanel, "Save", DialogResult.Yes);
                AddButton(buttonPanel, "Reject", DialogResult.No);
            }
            if (buttons == MessageBoxButtons.OKCancel || buttons == MessageBoxButtons.YesNoCancel)
            {
                AddButton(buttonPanel, "Cancel", DialogResult.Cancel);
            }
        }

        private void AddButton(FlowLayoutPanel panel, string text, DialogResult result)
        {
            Button button = new Button
            {
                Text = text,
                DialogResult = result
            };
            panel.Controls.Add(button);
        }

        public static DialogResult Show(string message, string title, MessageBoxButtons buttons)
        {
            using (var box = new CustomMessageBox(message, title, buttons))
            {
                return box.ShowDialog();
            }
        }
    }
}
