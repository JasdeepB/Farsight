using Farsight.Deserializable_Objects.Perks;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Farsight.UI_s_and_Controllers
{
    public partial class RunePageEditor : Form
    {
        public RunePageEditor()
        {
            InitializeComponent();
            primaryRuneLabel.BackColor = System.Drawing.Color.Transparent;
            secondaryRuneLabel.BackColor = System.Drawing.Color.Transparent;
            keystoneCheckBox.BackColor = System.Drawing.Color.Transparent;
            primaryRune1CheckBox.BackColor = System.Drawing.Color.Transparent;
            primaryRune2CheckBox.BackColor = System.Drawing.Color.Transparent;
            primaryRune3CheckBox.BackColor = System.Drawing.Color.Transparent;
            secondaryRune1CheckBox.BackColor = System.Drawing.Color.Transparent;
            secondaryRune2CheckBox.BackColor = System.Drawing.Color.Transparent;
            secondaryRune3CheckBox.BackColor = System.Drawing.Color.Transparent;
            offenseRuneCheckBox.BackColor = System.Drawing.Color.Transparent;
            flexRunePageCheckBox.BackColor = System.Drawing.Color.Transparent;
            defenseRunePageCheckBox.BackColor = System.Drawing.Color.Transparent;
            primaryRunePictureBox.BackColor = System.Drawing.Color.Black;
            secondaryRunePictureBox.BackColor = System.Drawing.Color.Black;
            VSLabel.BackColor = System.Drawing.Color.Transparent;
            playingChampPictureBox.BackColor = System.Drawing.Color.Black;
            againstChampPictureBox.BackColor = System.Drawing.Color.Black;
            LoadTreeDefaults();
        }

        public void LoadTreeDefaults()
        {
            List<AllRunes> runes = JSONParser.Runes();

            runePageNameTextBox.Text = "Yasuo VS Zed";
            playingChampPictureBox.Image = Images.ChampionImage("Yasuo");
            againstChampPictureBox.Image = Images.ChampionImage("Zed");

            primaryRuneLabel.Text = runes[2].name;
            primaryRunePictureBox.Image = Images.PrimaryRuneTree(8000);
            secondaryRuneLabel.Text = runes[0].name;
            secondaryRunePictureBox.Image = Images.SecondaryRuneTree(8100);

            for (int i = 0; i < 4; i++)
            {
                keystoneComboBox.Items.Add(runes[2].slots[0].runes[i].name);
            }

            for (int j = 0; j < 3; j++)
            {
                primaryRune1ComboBox.Items.Add(runes[2].slots[1].runes[j].name);
                primaryRune2ComboBox.Items.Add(runes[2].slots[2].runes[j].name);
                primaryRune3ComboBox.Items.Add(runes[2].slots[3].runes[j].name);

                secondaryRune1ComboBox.Items.Add(runes[0].slots[1].runes[j].name);
                secondaryRune2ComboBox.Items.Add(runes[0].slots[2].runes[j].name);
                secondaryRune3ComboBox.Items.Add(runes[0].slots[3].runes[j].name);

                if (j == 2) //Used for Ultimate hunter, the dominatin tree has 4 selections for the last rune, all others have 3
                {
                    primaryRune3ComboBox.Items.Add(runes[0].slots[3].runes[j++].name);
                }
            }


        }
    }
}
