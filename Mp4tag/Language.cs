using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Windows.Forms;
using System.IO;

namespace Mp4tag
{
    class Language
    {
        private static Hashtable languageTable = new Hashtable();
        private static Hashtable languageFiles = new Hashtable();
        
        private struct SectionPair
        {
            public String Category;
            public String Key;
        }

        private static void GetLanguages()
        {
            string languageDirectory = Application.StartupPath + "\\lang";
            DirectoryInfo dir = new DirectoryInfo(languageDirectory);

            foreach (var file in dir.GetFiles("*.lng"))
            {
                try
                {
                    string language = IniHandler.GetIniFileString(file.FullName, "General", "Language", "");
                    if (language != "")
                    {
                        languageFiles.Add(language, file.FullName);
                    }
                }
                catch { }
            }
        }

        public static string[] GetAllLanguages()
        {
            List<string> languages = new List<string>();

            foreach (DictionaryEntry entry in languageFiles)
            {
                languages.Add((string)entry.Key);
            }

            return languages.ToArray();
        }

        public static string GetStatus(Form form, string toTranslate)
        {
            SectionPair sectionPair;
            sectionPair.Category = form.Name + ":Status";
            sectionPair.Key = toTranslate;

            return (string)languageTable[sectionPair];
        }

        public static string GetSelectedLanguage()
        {
            return Config.Language;
        }

        private static string GetLanguageFile(string language)
        {
            return (string)languageFiles[language];
        }

        public static void Initialize()
        {
            GetLanguages();
            string languageFile = GetLanguageFile(GetSelectedLanguage());


            foreach (string category in IniHandler.GetCategories(languageFile))
            {
                foreach (string key in IniHandler.GetKeys(languageFile, category))
                {
                    SectionPair sectionPair;
                    sectionPair.Category = category;
                    sectionPair.Key = key;

                    languageTable.Add(sectionPair, IniHandler.GetIniFileString(languageFile, category, key, ""));
                }
            }
        }

        private static void PopulateDataGridView(Form form, DataGridView dgView)
        {
            foreach (DataGridViewColumn column in dgView.Columns)
            {
                SectionPair sectionPair;

                sectionPair.Category = form.Name + ":Label";
                sectionPair.Key = column.Name;
                if (languageTable[sectionPair] != null)
                {
                    column.HeaderText = (string)languageTable[sectionPair];
                }
            }
        }

        private static void PopulateToolStip(Form form, ToolStripItem itmTool)
        {
            SectionPair sectionPair;

            sectionPair.Category = form.Name + ":Label";
            sectionPair.Key = itmTool.Name;
            if (languageTable[sectionPair] != null)
            {
                itmTool.Text = (string)languageTable[sectionPair];
            }
            try
            {
                foreach (ToolStripItem itmDDTool in ((ToolStripMenuItem)itmTool).DropDownItems)
                {
                    PopulateToolStip(form, itmDDTool);
                }
            }
            catch { }
        }

        private static void PopulateMenuStrip(Form form, MenuStrip menuStrip)
        {
            foreach (ToolStripItem itmTool in menuStrip.Items)
            {
                PopulateToolStip(form, itmTool);
            }
        }

        private static void PopulateControls(Form form, Control ctrl)
        {
            SectionPair sectionPair;           

            if (ctrl is CheckBox)
            {
                CheckBox chkBox = ctrl as CheckBox;
                sectionPair.Category = form.Name + ":Label";
                sectionPair.Key = chkBox.Name;
                if (languageTable[sectionPair] != null)
                {
                    chkBox.Text = (string)languageTable[sectionPair];
                }
            }
            else if (ctrl is Label)
            {
                Label lbl = ctrl as Label;
                sectionPair.Category = form.Name + ":Label";
                sectionPair.Key = lbl.Name;
                if (languageTable[sectionPair] != null)
                {
                    lbl.Text = (string)languageTable[sectionPair];
                }
            }
            else if (ctrl is Button)
            {
                Button btn = ctrl as Button;
                sectionPair.Category = form.Name + ":Label";
                sectionPair.Key = btn.Name;
                if (languageTable[sectionPair] != null)
                {
                    btn.Text = (string)languageTable[sectionPair];
                }
            }
            else if (ctrl is ContextMenuStrip)
            {
                ContextMenuStrip item = ctrl as ContextMenuStrip;
                sectionPair.Category = form.Name + ":Label";
                sectionPair.Key = item.Name;
                if (languageTable[sectionPair] != null)
                {
                    item.Text = (string)languageTable[sectionPair];
                }
            }
            else if (ctrl is TabPage)
            {
                TabPage tab = ctrl as TabPage;
                sectionPair.Category = form.Name + ":Label";
                sectionPair.Key = tab.Name;
                if (languageTable[sectionPair] != null)
                {
                    tab.Text = (string)languageTable[sectionPair];
                }
                foreach (Control child in ctrl.Controls)
                {
                    PopulateControls(form, child);
                }
            }
            else if (ctrl is GroupBox)
            {
                GroupBox grpBox = ctrl as GroupBox;
                sectionPair.Category = form.Name + ":Label";
                sectionPair.Key = grpBox.Name;
                if (languageTable[sectionPair] != null)
                {
                    grpBox.Text = (string)languageTable[sectionPair];
                }
                foreach (Control child in ctrl.Controls)
                {
                    PopulateControls(form, child);
                }
            }
            else if (ctrl is RadioButton)
            {
                RadioButton rdoButton = ctrl as RadioButton;
                sectionPair.Category = form.Name + ":Label";
                sectionPair.Key = rdoButton.Name;
                if (languageTable[sectionPair] != null)
                {
                    rdoButton.Text = (string)languageTable[sectionPair];
                }
            }
            else if (ctrl is ComboBox)
            {
                ComboBox cmbBox = ctrl as ComboBox;
                sectionPair.Category = form.Name + ":Tooltip";
                sectionPair.Key = cmbBox.Name;
                if (languageTable[sectionPair] != null)
                {
                    cmbBox.Tag = (string)languageTable[sectionPair];
                }
            }
            else if (ctrl is PictureBox)
            {
                PictureBox picBox = ctrl as PictureBox;
                sectionPair.Category = form.Name + ":Tooltip";
                sectionPair.Key = picBox.Name;
                if (languageTable[sectionPair] != null)
                {
                    picBox.Tag = (string)languageTable[sectionPair];
                }
            }
            else if (ctrl is TextBox)
            {
                TextBox txtBox = ctrl as TextBox;
                sectionPair.Category = form.Name + ":Tooltip";
                sectionPair.Key = txtBox.Name;
                if (languageTable[sectionPair] != null)
                {
                    txtBox.Tag = (string)languageTable[sectionPair];
                }
            }
            else if (ctrl is DataGridView)
            {
                DataGridView dgView = ctrl as DataGridView;
                sectionPair.Category = form.Name + ":Tooltip";
                sectionPair.Key = dgView.Name;
                if (languageTable[sectionPair] != null)
                {
                    dgView.Tag = (string)languageTable[sectionPair];
                }
                PopulateDataGridView(form, dgView);
            }
            else
            {
                foreach (Control child in ctrl.Controls)
                {
                    PopulateControls(form, child);
                }
            }
        }

        public static void Populate(Form form)
        {
            if (form.MainMenuStrip != null)
            {
                PopulateMenuStrip(form, form.MainMenuStrip);
            }

            foreach (Control ctrl in form.Controls)
            {
                PopulateControls(form, ctrl);
            }
        }

        public static string GetFormText(Form form, string text)
        {
            SectionPair sectionPair;

            sectionPair.Category = form.Name + ":Text";
            sectionPair.Key = text;
            if (languageTable[sectionPair] != null)
            {
                return (string)languageTable[sectionPair];
            }

            return "";
        }

        public static string GetFormMessage(Form form, string text)
        {
            SectionPair sectionPair;

            sectionPair.Category = form.Name + ":Message";
            sectionPair.Key = text;
            if (languageTable[sectionPair] != null)
            {
                return (string)languageTable[sectionPair];
            }

            return "";
        }

        public static string GetGlobalMessage(string text)
        {
            SectionPair sectionPair;

            sectionPair.Category = "Global:Message";
            sectionPair.Key = text;
            if (languageTable[sectionPair] != null)
            {
                return (string)languageTable[sectionPair];
            }

            return "";
        }
    }
}
