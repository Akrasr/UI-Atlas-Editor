using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI_Atlas_Editor
{
    public partial class Form1 : Form
    {
        private MainManager manager;
        public static Color Back;
        private bool loaded;
        public Form1()
        {
            InitializeComponent();
            FlagAllElements(false);
            Back = this.BackColor;
            groupBox1.Enabled = false;
        }

        private void FlagAllElements(bool flag) //Enabling/Disabling UI elements
        {
            saveAsToolStripMenuItem.Enabled = flag;
            saveToolStripMenuItem.Enabled = flag;
            listBox1.Enabled = flag;
            button1.Enabled = flag;
        }

        private int GetInt(object sender) //Parsing int
        {
            IntSave(sender);
            if (((TextBox)sender).Text == "-")
            {
                return 0;
            }
            if (((TextBox)sender).Text.Length == 0)
            {
                return 0;
            }
            return Int32.Parse(((TextBox)sender).Text);
        }

        public void IntSave(object sender) //deleting all wrong characters from text while parsing to int
        {
            string[] ints = { "-", "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "," };
            TextBox tb = (TextBox)sender;
            string res = "";
            bool f = false;
            for (int i = 0; i < tb.Text.Length; i++)
            {
                if (("" + tb.Text.ToCharArray()[i]) == ints[0] && i != 0) // if '-' is not at start delete it
                {
                    continue;
                }
                if (ints.Contains("" + tb.Text.ToCharArray()[i]))
                {
                    res += tb.Text.ToCharArray()[i];
                }
                else
                    f = true;
            }
            int pos = tb.SelectionStart; //saving cursor position
            if (f) pos--;
            tb.Text = res;
            tb.Select(pos, 0);
        }

        private void LoadSpriteData(int index)
        {
            UISpriteData data = manager.GetSpriteData(index);
            manager.LoadSpriteData(index);
            this.textBox1.Text = data.name;
            this.textBox2.Text = "" + data.x;
            this.textBox3.Text = "" + data.y;
            this.textBox4.Text = "" + data.width;
            this.textBox5.Text = "" + data.height;
            this.textBox6.Text = "" + data.borderLeft;
            this.textBox8.Text = "" + data.borderRight;
            this.textBox10.Text = "" + data.borderTop;
            this.textBox12.Text = "" + data.borderBottom;
            this.textBox7.Text = "" + data.paddingLeft;
            this.textBox9.Text = "" + data.paddingRight;
            this.textBox11.Text = "" + data.paddingTop;
            this.textBox13.Text = "" + data.paddingBottom;
            groupBox1.Enabled = true;
        }

        private void ClearSpriteData()
        {
            for (int i = 0; i < listBox1.Items.Count; i++)
                listBox1.SetSelected(i, false);
            this.textBox1.Text = "";
            this.textBox2.Text = "";
            this.textBox3.Text = "";
            this.textBox4.Text = "";
            this.textBox5.Text = "";
            this.textBox6.Text = "";
            this.textBox7.Text = "";
            this.textBox8.Text = "";
            this.textBox9.Text = "";
            this.textBox10.Text = "";
            this.textBox11.Text = "";
            this.textBox12.Text = "";
            this.textBox13.Text = "";
            groupBox1.Enabled = false;
        }

        private void Open()
        {
            string atlasPath, imagePath;
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.RestoreDirectory = true;
                openFileDialog.Title = "Open UI Atlas File";
                openFileDialog.Filter = "114 files (*.114)|*.114|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 1;
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    atlasPath = openFileDialog.FileName;
                }
                else { return; }
            }
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.RestoreDirectory = true;
                openFileDialog.Title = "Open Atlas Image";
                openFileDialog.Filter = "Image files (*.png, *.jpg)|*.png;*.jpg|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 1;
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    imagePath = openFileDialog.FileName;
                } else { return; }
            }
            try
            {
                MainManager man = new MainManager(atlasPath, imagePath, pictureBox1.CreateGraphics());
                this.manager = man;
                FlagAllElements(true);
                listBox1.Items.Clear();
                loaded = false;
                listBox1.Items.AddRange(manager.GetSpriteNames());
                ClearSpriteData();
                loaded = true;
                manager.DrawAtlas();
            } catch
            {
                MessageBox.Show("Error while loading files");
            }
        }

        private void SaveAs()
        {
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.RestoreDirectory = true;
                sfd.Title = "Save UI Atlas file as";
                sfd.Filter = "114 files (*.114)|*.114|All files (*.*)|*.*";
                sfd.FilterIndex = 1;
                DialogResult dr = sfd.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    manager.SaveAs(sfd.FileName);
                }
                else if (dr == DialogResult.Cancel)
                {
                    return;
                }
            }
        }

        //Sprite Data editing

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (loaded)
            {
                manager.SetName(textBox1.Text);
                listBox1.Items.Clear(); //Updating listbox
                listBox1.Items.AddRange(manager.GetSpriteNames());
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (loaded)
                manager.SetX(GetInt(sender));
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (loaded)
                manager.SetY(GetInt(sender));
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            if (loaded)
                manager.SetWidth(GetInt(sender));
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            if (loaded)
                manager.SetHeight(GetInt(sender));
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e) //Loading Sprite Data
        {
            if (!loaded)
                return;
            int ind = listBox1.SelectedIndex;
            loaded = false;
            LoadSpriteData(ind);
            loaded = true;
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Open();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            manager.Save();
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveAs();
        }

        private void button1_Click(object sender, EventArgs e) //Drawing Atlas
        {
            loaded = false;
            ClearSpriteData();
            loaded = true;
            manager.DrawAtlas();
        }

        private void label9_Click(object sender, EventArgs e)
        {
        }

        //Sprite Data editing

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            if (loaded)
                manager.SetBorderRight(GetInt(sender));
        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {
            if (loaded)
                manager.SetPaddingRight(GetInt(sender));
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            if (loaded)
                manager.SetBorderLeft(GetInt(sender));
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            if (loaded)
                manager.SetPaddingLeft(GetInt(sender));
        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {
            if (loaded)
                manager.SetBorderTop(GetInt(sender));
        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {
            if (loaded)
                manager.SetPaddingTop(GetInt(sender));
        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {
            if (loaded)
                manager.SetBorderBottom(GetInt(sender));
        }

        private void textBox13_TextChanged(object sender, EventArgs e)
        {
            if (loaded)
                manager.SetPaddingBottom(GetInt(sender));
        }
    }
}
