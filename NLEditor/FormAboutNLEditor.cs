using System;
using System.Drawing;
using System.Windows.Forms;

namespace NLEditor
{
    public partial class FormAboutNLEditor : Form
    {
        public FormAboutNLEditor()
        {
            int GetCenter(Control component)
            {
                return (this.ClientSize.Width - component.Width) / 2;
            }

            KeyPreview = true;

            Int32 rtbWidth = 720;
            Int32 topMargin = 12;
            Int32 padding = 12;

            InitializeComponent();

            richTextBox_WhatsNew.Width = rtbWidth;
            richTextBox_PreviousUpdates.Width = rtbWidth;
            picturePadding.Left = richTextBox_WhatsNew.Right;
            pictureClimber.Left = richTextBox_WhatsNew.Right;

            pictureWhatsNew.Top = topMargin;
            pictureWhatsNew.Left = GetCenter(pictureWhatsNew);
            WriteWhatsNewText();

            lblPreviousUpdates.Left = GetCenter(lblPreviousUpdates);
            WritePreviousUpdatesText();

            lblNeoLemmixEditor.Text = "NeoLemmix Editor (Version " + C.Version + ")";
            lblNeoLemmixEditor.Top = richTextBox_PreviousUpdates.Bottom + padding;
            lblNeoLemmixEditor.Left = GetCenter(lblNeoLemmixEditor);

            lblAuthor.Top = lblNeoLemmixEditor.Bottom + padding;
            lblAuthor.Left = GetCenter(lblAuthor);

            lblThanksTo.Top = lblAuthor.Bottom + padding;
            lblThanksTo.Left = GetCenter(lblThanksTo);
            lblDMA.Top = lblThanksTo.Bottom;
            lblDMA.Left = GetCenter(lblDMA);
            lblLFCommunity.Top = lblDMA.Bottom;
            lblLFCommunity.Left = GetCenter(lblLFCommunity);
            linkLF.Top = lblLFCommunity.Bottom;
            linkLF.Left = GetCenter(linkLF);

            check_ShowThisWindow.Top = linkLF.Bottom + padding;
            check_ShowThisWindow.Left = GetCenter(check_ShowThisWindow);
            check_ShowThisWindow.Checked = Properties.Settings.Default.ShowAboutNLWindowAtStartup;
        }

        private void Check_ShowThisWindow_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.ShowAboutNLWindowAtStartup = check_ShowThisWindow.Checked;
            Properties.Settings.Default.Save();
        }

        private void FormAboutNLEditor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }

        private void linkLF_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string url = "https://www.lemmingsforums.net";
            System.Diagnostics.Process.Start(url);
        }

        /// <summary>
        /// Helper function to write bold text
        /// </summary>
        private void WriteBoldText(RichTextBox richTextBox, string text)
        {
            var regularFont = richTextBox.Font;

            richTextBox.SelectionFont = new Font(richTextBox.Font, FontStyle.Bold);
            richTextBox.AppendText(text);
            richTextBox.SelectionFont = new Font(regularFont, FontStyle.Regular);
        }

        /// <summary>
        /// Populates "What's New" field with text
        /// </summary>
        private void WriteWhatsNewText()
        {
            var richTextBox = richTextBox_WhatsNew;
            richTextBox.Clear();

            //// Test version text
            //WriteBoldText(richTextBox, "This version of the Editor is for test purposes only!\n");
            //richTextBox.AppendText("Please do not distribute it publicly as stability cannot be guaranteed. Thanks\n");

            // Version 1.44 features
            WriteBoldText(richTextBox, "Version 1.44 Updates\n");

            // =======================
            // Piece Browser
            // =======================
            WriteBoldText(richTextBox, "\n• Piece Browser\n");
            richTextBox.AppendText(" • Added 'Steel' tab\n");
            richTextBox.AppendText(" • 3-way option 'Data/Descriptions/Pieces Only' switches between showing additional piece data, descriptions (previously 'Show piece names'), or just the pieces\n");
            richTextBox.AppendText(" • Added option to show type rather than name for objects\n");
            richTextBox.AppendText(" • Added option to either scroll piece browser infinitely, or stop at the lowest/highest pieces in each tab\n");
            richTextBox.AppendText(" • Added resizing info to the tooltips\n");
            richTextBox.AppendText(" • Info labels are now drawn with a filled background to ensure visability\n");

            WriteBoldText(richTextBox, "\n• Piece Search\n");
            richTextBox.AppendText(" • Search for specific pieces by name, style, object type, and various other properties\n");

            // =======================
            // Pieces Tab
            // =======================
            WriteBoldText(richTextBox, "\n• Pieces Tab\n");
            richTextBox.AppendText(" • Clicking (and selecting) a piece now opens the \"Pieces\" tab)\n");
            richTextBox.AppendText(" • Piece Metadata is now displayed, showing name, style, type and size\n");
            richTextBox.AppendText(" • Added a \"Load Style\" button to load the style of the selected piece into the browser\n");

            // =======================
            // Skills Tab
            // =======================
            WriteBoldText(richTextBox, "\n• Skills Tab\n");
            WriteBoldText(richTextBox, "• Custom Skillsets");
            richTextBox.AppendText(" - Added a button for \"Save As Custom Skillset\" which allows the user to save the currently-applied skillset as a custom preset. When saving, entering the name of an existing custom skillset will overwrite the existing one\n");

            WriteBoldText(richTextBox, "• Custom Skillsets");
            richTextBox.AppendText(" - Added a dropdown menu for custom preset skillsets (using NLCustomSkillsets.ini)\n");

            WriteBoldText(richTextBox, "• Random Skillset");
            richTextBox.AppendText(" - Added button for Random Skillset, which creates a skillset of up to 10 skills at random, using specified amounts per-skill\n");

            WriteBoldText(richTextBox, "• Set All Non-Zero Skills to [N]");
            richTextBox.AppendText(" - Added a new button to change all non-zero skills to N, where N can be specified using a numeric control\n");

            WriteBoldText(richTextBox, "• Clear Skillset");
            richTextBox.AppendText(" - Added button to clear the skillset, resetting all numerics to 0\n");

            // =======================
            // Hotkeys
            // =======================
            WriteBoldText(richTextBox, "\n• Hotkeys\n");
            WriteBoldText(richTextBox, "• Fully-customisable hotkeys");
            richTextBox.AppendText(" - Choose your own hotkey layout for the Editor's features!\n");

            WriteBoldText(richTextBox, "• Duplicate Up/Down/Left/Right");
            richTextBox.AppendText(" - Duplicate piece(s) to the immediate N/E/S/W of the selected piece(s)\n");

            WriteBoldText(richTextBox, "• Custom Move");
            richTextBox.AppendText(" - Move selected pieces by a custom amount (specified in the F10 settings menu - the default is 64px)\n");

            WriteBoldText(richTextBox, "• Move by Grid Amount");
            richTextBox.AppendText(" - Previous hotkeys to move pieces by 8px now move pieces by the specified grid size\n");

            WriteBoldText(richTextBox, "• Group/Ungroup Pieces");
            richTextBox.AppendText(" - Added Group/Ungroup Pieces hotkeys\n");

            WriteBoldText(richTextBox, "• Horizontal-Only Move");
            richTextBox.AppendText(" - Move selected pieces along the X-axis only\n");

            WriteBoldText(richTextBox, "• Vertical-Only Move");
            richTextBox.AppendText(" - Move selected pieces along the Y-axis only\n");

            WriteBoldText(richTextBox, "• Set Screen Start to Mouse Cursor");
            richTextBox.AppendText(" - Set the screen start to the mouse cursor position\n");

            WriteBoldText(richTextBox, "• Expand/Collapse All Tabs");
            richTextBox.AppendText(" - Expanded or collapse the Globals/Pieces/Skills/Misc tabs\n");

            WriteBoldText(richTextBox, "• Select All");
            richTextBox.AppendText(" - Select all pieces in the level area (Ctrl+A by default)\n");

            // =======================
            // Level Validation
            // =======================
            WriteBoldText(richTextBox, "\n• Level Validation\n");
            richTextBox.AppendText(" • Added a setting to toggle automatic level validation on/off when manually saving a level\n");
            richTextBox.AppendText(" • Expanded validation checks and fixing options\n");
            richTextBox.AppendText(" • Validation now has a minimum time limit of 1 second\n");
            richTextBox.AppendText(" • Dialog now alerts the user that the lem count is higher than the pre-placed lem count (where relevant) rather than just showing \"missing hatch\"\n");

            // =======================
            // Talismans
            // =======================
            WriteBoldText(richTextBox, "\n• Talisman Creation\n");
            richTextBox.AppendText(" • Added support for \"Max Skill Types\" talisman\n");
            richTextBox.AppendText(" • Dialog now shows only the skills that have already been added to the skillset\n");
            richTextBox.AppendText(" • Renamed 'Add Requirement' button to 'Add This Requirement to List' for further clarity\n");
            richTextBox.AppendText(" • A default title is added if the Title field is empty\n");

            // =======================
            // UI
            // =======================
            WriteBoldText(richTextBox, "\n• UI\n");
            richTextBox.AppendText(" • Scroll wheel can be used to change items when mousing over a dropdown list (without clicking)\n");
            richTextBox.AppendText(" • It's no longer possible to type into dropdown lists (to prevent accidental typing). However, it's now possible to use A-Z keys to quickly jump to a style/author when the list is active\n");
            richTextBox.AppendText(" • All secondary windows can now be closed using the [Esc] key\n");
            richTextBox.AppendText(" • Zoom factor is now 1 instead of 0 when opening the Editor\n");
            richTextBox.AppendText(" • Increased maximum zoom level\n");
            richTextBox.AppendText(" • Editor now opens Maximized by default\n");
            richTextBox.AppendText(" • Auto-start checkbox is no longer checked by default, but its state is remembered per-level when closing and re-loading the Editor\n");

            WriteBoldText(richTextBox, "• Level Arranger Window");
            richTextBox.AppendText(" - The Level Arranger can now be opened in its own pop-out window to accompany the Level Arranger. It's external-display compatible, and size & location are remembered between sessions\n");

            WriteBoldText(richTextBox, "• Piece Browser Window");
            richTextBox.AppendText(" - The Piece Browser can now be opened in its own pop-out window to accompany the Level Arranger. It's external-display compatible, and size & location are remembered between sessions\n");

            WriteBoldText(richTextBox, "• Highlight Grouped Pieces");
            richTextBox.AppendText(" - It's now possible to highlight all grouped pieces\n");

            WriteBoldText(richTextBox, "• Highlight Eraser Pieces");
            richTextBox.AppendText(" - It's now possible to highlight all pieces designated as 'Erase'\n");

            WriteBoldText(richTextBox, "• Trigger area colours");
            richTextBox.AppendText(" - It's now possible to choose between 5 different trigger area colours\n");

            WriteBoldText(richTextBox, "• Pre-placed Lemming");
            richTextBox.AppendText(" - Added pink (X, Y) location pin to pre-placed lemming)\n");

            WriteBoldText(richTextBox, "• Helper Icons");
            richTextBox.AppendText(" - Added helper icons to show pre-placed-lem/hatch/exit skills & properties\n");

            WriteBoldText(richTextBox, "• Preview/Postview Text Input");
            richTextBox.AppendText(" - Widened and heightened the text input dialog, also added a \"Preview\" button to show how the text will appear on the screen in-game\n");

            WriteBoldText(richTextBox, "\n• Layout\n");
            richTextBox.AppendText(" • Larger scrollbars for easier access when fine-editing a level\n");
            richTextBox.AppendText(" • Theme/style dropdowns widened for easier reading\n");
            richTextBox.AppendText(" • Tabs widened for easier reading\n");
            richTextBox.AppendText(" • Set minimum window size to 900 x 600)\n");
            richTextBox.AppendText(" • \"Clear Backgrounds\" button moved to above the Piece Browser for better access\n");
            richTextBox.AppendText(" • Improved Settings dialog layout\n");
            richTextBox.AppendText(" • Revised toolbar menu layout\n");
            richTextBox.AppendText(" • Updated all menu dropdrowns to display the hotkey to the right\n");
            richTextBox.AppendText(" • All dialogs (Hotkeys, Options, About, Validate Level, etc) now appear center-screen\n");

            // =======================
            // Misc Features
            // =======================
            WriteBoldText(richTextBox, "\n• Miscellaneous\n");

            WriteBoldText(richTextBox, "• Refresh Styles");
            richTextBox.AppendText(" - It's now possible to refresh the styles without closing and re-opening the Editor. So, if a style is modified during a level editing session, it can be refreshed without interrupting workflow! This feature is accessed via a menu item and customizable hotkey (Ctrl+Shift+F8 by default)\n");

            WriteBoldText(richTextBox, "• Save As Image");
            richTextBox.AppendText(" - Added Save As Image option (plus hotkey) to the File menu; this saves a .png image of the currently loaded level\n");

            WriteBoldText(richTextBox, "• Cleanse Levels");
            richTextBox.AppendText(" - Added \"Cleanse Levels\" menu item - this automatically re-saves all levels in a specified pack to ensure compatibility with NL\n");

            WriteBoldText(richTextBox, "• Level Size");
            richTextBox.AppendText(" - Maximum level width increased to 6400px, maximum height decreased to 1600px\n");

            WriteBoldText(richTextBox, "• Maximum Lemmings Count");
            richTextBox.AppendText(" - 999 is now the maximum number of lemmings supported by the Editor; this is to match NL Player skill panel display\n");

            // =======================
            // Bugfixes
            // =======================
            WriteBoldText(richTextBox, "\n• Bugfixes\n");

            WriteBoldText(richTextBox, "• Bugfix - Missing Piece Handling");
            richTextBox.AppendText(" - Levels with missing pieces no longer create multiple popups; instead, a status bar is used to inform the player that the level has missing pieces\n");

            WriteBoldText(richTextBox, "• Bugfixes - UI\n");
            richTextBox.AppendText(" • Increased minimum selectable grid size to 2px\n");
            richTextBox.AppendText(" • Settings form now stays on top when active\n");
            richTextBox.AppendText(" • Improved mouseover handling for dropdown lists\n");
            richTextBox.AppendText(" • Fixed bug affecting the position of the screen area in relation to the scrollbars when zoomed in\n");
            richTextBox.AppendText(" • Character limits increased to NL Player UI limits: Title (62), Author (60), Talisman Title (54)\n");
            richTextBox.AppendText(" • Cursor anchor is now correctly preserved when zooming in and out\n");

            WriteBoldText(richTextBox, "• Bugfix - Preview/Postview Text");
            richTextBox.AppendText(" - Text is now displayed centred for better previewing\n");

            WriteBoldText(richTextBox, "• Bugfix - Flipped/Inverted/Rotated Pieces\n");
            richTextBox.AppendText(" • Fixed trigger area repositionings for flipped/inverted/rotated objects\n");
            richTextBox.AppendText(" • When flipping a hatch horizontally, the Flip Offset value is calculated and written to the level file so the Player (NLCE Only) can match its position as seen in the Editor)\n");
        }

        /// <summary>
        /// Populates "Previous Updates" field with text
        /// </summary>
        private void WritePreviousUpdatesText()
        {
            var richTextBox = richTextBox_PreviousUpdates;
            richTextBox.Clear();
        }
    }
}
