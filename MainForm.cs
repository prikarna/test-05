using System;
using System.Windows;
using System.Windows.Forms;
using System.Drawing;

namespace Deka
{
    class MainForm: Form
    {
        private void formClosed(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void menuAbout(object sender, EventArgs e)
        {
            MessageBox.Show(null, "Deka's Editor", "About", MessageBoxButtons.OK);
        }

        private void menuFmtFont(object sender, EventArgs e)
        {
            if (fntDlg.ShowDialog() != DialogResult.Cancel)
            {
                // Do something here
            }
        }

        private void menuFlOpen(object s, EventArgs e)
        {
            if (opFlDlg.ShowDialog() == DialogResult.OK)
            {

            }
        }

        private void menuFlSave(object o, EventArgs e)
        {
            
        }

        private void menuFlSaveAs(object o, EventArgs e)
        {
            if (savFlDlg.ShowDialog() == DialogResult.OK)
            {

            }
        }

        private void menuFlClose(object o, EventArgs e)
        {
            
        }

        private void menuFlNew(object o, EventArgs e)
        {

        }

        private void initMenus()
        {
            MenuItem flItem = new MenuItem("&File");
            MenuItem newItem = new MenuItem("&New");
            newItem.Click += menuFlNew;
            flItem.MenuItems.Add(newItem);

            MenuItem opItem = new MenuItem("&Open...");
            opItem.Click += menuFlOpen;
            flItem.MenuItems.Add(opItem);

            MenuItem cloItem = new MenuItem("&Close");
            cloItem.Click += menuFlClose;
            flItem.MenuItems.Add(cloItem);

            MenuItem sep0 = new MenuItem("-");
            flItem.MenuItems.Add(sep0);

            MenuItem flSav = new MenuItem("&Save");
            flSav.Click += menuFlSave;
            flItem.MenuItems.Add(flSav);

            MenuItem flSavAs = new MenuItem("&Save As...");
            flSavAs.Click += menuFlSaveAs;
            flItem.MenuItems.Add(flSavAs);

            MenuItem sep1 = new MenuItem("-");
            flItem.MenuItems.Add(sep1);

            MenuItem extItem = new MenuItem("&Exit");
            extItem.Click += formClosed;
            flItem.MenuItems.Add(extItem);

            MenuItem edtItem = new MenuItem("&Edit");
            MenuItem edtUnd = new MenuItem("&Undo");
            edtItem.MenuItems.Add(edtUnd);

            MenuItem sep2 = new MenuItem("-");
            edtItem.MenuItems.Add(sep2);

            MenuItem edtCpy = new MenuItem("&Copy");
            edtItem.MenuItems.Add(edtCpy);

            MenuItem edtPast = new MenuItem("&Paste");
            edtItem.MenuItems.Add(edtPast);

            MenuItem sep3 = new MenuItem("-");
            edtItem.MenuItems.Add(sep3);

            MenuItem edtFindNext = new MenuItem("Find&Next");
            edtItem.MenuItems.Add(edtFindNext);

            MenuItem edtFind = new MenuItem("&Find...");
            edtItem.MenuItems.Add(edtFind);

            MenuItem edtRepl = new MenuItem("&Replace...");
            edtItem.MenuItems.Add(edtRepl);

            MenuItem edtGoto = new MenuItem("&Go to line...");
            edtItem.MenuItems.Add(edtGoto);

            MenuItem sep4 = new MenuItem("-");
            edtItem.MenuItems.Add(sep4);

            MenuItem edtSelAll = new MenuItem("&Select All");
            edtItem.MenuItems.Add(edtSelAll);

            MenuItem viewItem = new MenuItem("&View");

            MenuItem fmtItem = new MenuItem("&Format");
            MenuItem fmtFont = new MenuItem("&Font...");
            fmtFont.Click += menuFmtFont;
            fmtItem.MenuItems.Add(fmtFont);

            MenuItem abtItem = new MenuItem("&About");
            abtItem.Click += menuAbout;
            MenuItem hlpItem = new MenuItem("&Help");
            hlpItem.MenuItems.Add(abtItem);

            MainMenu mMnu = new MainMenu();
            mMnu.MenuItems.Add(flItem);
            mMnu.MenuItems.Add(edtItem);
            mMnu.MenuItems.Add(viewItem);
            mMnu.MenuItems.Add(fmtItem);
            mMnu.MenuItems.Add(hlpItem);

            Menu = mMnu;
        }

        private StatusBarPanel statBar;
        private StatusBarPanel lineBar;
        private StatusBar      stat;

        private RichTextBox    edtBox;
        private FontFamily     fontFam;
        private Font           edtFont;
        
        private FontDialog       fntDlg;
        private OpenFileDialog   opFlDlg;
        private SaveFileDialog   savFlDlg;

        private void initComponents()
        {
             initMenus();

             statBar = new StatusBarPanel();
             statBar.Text = "Status ";
             statBar.AutoSize = StatusBarPanelAutoSize.Spring;
             
             lineBar = new StatusBarPanel();
             lineBar.Text = "(xxx,yyy)";
             lineBar.AutoSize = StatusBarPanelAutoSize.Contents;
             lineBar.BorderStyle = StatusBarPanelBorderStyle.Raised;

             stat = new StatusBar();
             stat.Panels.Add(statBar);
             stat.Panels.Add(lineBar);
             stat.ShowPanels = true;

             Controls.Add(stat);

             fontFam = new FontFamily("Courier New");
             edtFont = new Font(fontFam, 12);

             edtBox = new RichTextBox();
             edtBox.Dock = DockStyle.Fill;
             edtBox.Font = edtFont;

             Controls.Add(edtBox);

             fntDlg = new FontDialog();
             fntDlg.ShowColor = true;
             opFlDlg = new OpenFileDialog();
             savFlDlg = new SaveFileDialog();
        }

        public MainForm()
        {
            this.Text = "Editor";
            this.Closed += formClosed;
            
            initComponents();
            
            this.Show();
        }
    }
}