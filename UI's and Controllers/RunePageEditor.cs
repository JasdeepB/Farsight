using Farsight.Deserializable_Objects.Perks;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Farsight.UI_s_and_Controllers
{
    public partial class RunePageEditor : Form
    {
        List<AllRunes> runes = JSONParser.Runes();
        int[] runesTrees = { 8000, 8100, 8200, 8400, 8300 }; //Pricision, Domination, Sorcery, Resolve, Inspiration
        List<int> secondaryRuneTree = new List<int>();
        int currentSecondaryTree = 0;
        bool primaryTreeIsDomination = false;

        public RunePageEditor()
        {
            InitializeComponent();
            precisionPictureBox.Image = Images.RuneTree(8000);
            dominationPictureBox.Image = Images.RuneTree(8100);
            sorceryPictureBox.Image = Images.RuneTree(8200);
            resolvePictureBox.Image = Images.RuneTree(8400);
            inspirationPictureBox.Image = Images.RuneTree(8300);
            statmodRuneSelectionLine.BackColor = Color.FromArgb(233, 225, 198);
            primaryRunesTier3PictureBox4.Visible = false;
            secondaryRunesTier3PictureBox4.Visible = false;

            statModOffenseAdaptiveForcePictureBox.Image = Images.StatMods("AdaptiveForce");
            statModOffenseAttackSpeedPictureBox.Image = Images.StatMods("AttackSpeed");
            statModOffenseCDRPictureBox.Image = Images.StatMods("CDR");

            statModFlexAdaptiveForcePictureBox.Image = Images.StatMods("AdaptiveForce");
            statModFlexArmorForcePictureBox.Image = Images.StatMods("Armor");
            statModFlexMagicResistPictureBox.Image = Images.StatMods("MagicResist");

            statModDefenseHealthPictureBox.Image = Images.StatMods("Health");
            statModDefenseArmorPictureBox.Image = Images.StatMods("Armor");
            statModDefenseMagicResistPictureBox.Image = Images.StatMods("MagicResist");
        }

        private void precisionPictureBox_Click(object sender, System.EventArgs e)
        {
            if (currentSecondaryTree == 8000)
            {
                ResetSecondaryTree();//If the user selects the same primary tree as the secondary tree, reset the secondary tree
                secondaryRunePictureBox.Image = null;
            }

            if (primaryTreeIsDomination == true)
            {
                primaryRunesTier3PictureBox1.Location = new Point(200, 344);
                primaryRunesTier3PictureBox2.Location = new Point(272, 344);
                primaryRunesTier3PictureBox3.Location = new Point(344, 344);
                primaryRunesTier3PictureBox4.Location = new Point(408, 344);
                primaryRunesTier3PictureBox4.Visible = false;
            }

            primaryRunePictureBox.Image = Images.RuneTree(8000);

            SetRuneSelectionLineColor(8000, true);

            primaryRuneKeystone1PictureBox.Image = Images.PrecisionTree(8005);
            primaryRuneKeystone2PictureBox.Image = Images.PrecisionTree(8008);
            primaryRuneKeystone3PictureBox.Image = Images.PrecisionTree(8021);
            primaryRuneKeystone4PictureBox.Image = Images.PrecisionTree(8010);

            primaryRunesTier1PictureBox1.Image = Images.PrecisionTree(9101);
            primaryRunesTier1PictureBox2.Image = Images.PrecisionTree(9111);
            primaryRunesTier1PictureBox3.Image = Images.PrecisionTree(8009);
            
            primaryRunesTier2PictureBox1.Image = Images.PrecisionTree(9104);
            primaryRunesTier2PictureBox2.Image = Images.PrecisionTree(9105);
            primaryRunesTier2PictureBox3.Image = Images.PrecisionTree(9103);

            primaryRunesTier3PictureBox1.Image = Images.PrecisionTree(8014);
            primaryRunesTier3PictureBox2.Image = Images.PrecisionTree(8017);
            primaryRunesTier3PictureBox3.Image = Images.PrecisionTree(8229);

            LoadSecondaryTree(8000);
        }

        private void dominationPictureBox_Click(object sender, System.EventArgs e)
        {
            if (currentSecondaryTree == 8100)
            {
                ResetSecondaryTree();
                secondaryRunePictureBox.Image = null;
            }

            primaryTreeIsDomination = true;

            primaryRunePictureBox.Image = Images.RuneTree(8100);

            SetRuneSelectionLineColor(8100, true);

            primaryRuneKeystone1PictureBox.Image = Images.DominationTree(8112);
            primaryRuneKeystone2PictureBox.Image = Images.DominationTree(8124);
            primaryRuneKeystone3PictureBox.Image = Images.DominationTree(8128);
            primaryRuneKeystone4PictureBox.Image = Images.DominationTree(9923);

            primaryRunesTier1PictureBox1.Image = Images.DominationTree(8126);
            primaryRunesTier1PictureBox2.Image = Images.DominationTree(8139);
            primaryRunesTier1PictureBox3.Image = Images.DominationTree(8143);

            primaryRunesTier2PictureBox1.Image = Images.DominationTree(8136);
            primaryRunesTier2PictureBox2.Image = Images.DominationTree(8120);
            primaryRunesTier2PictureBox3.Image = Images.DominationTree(8138);

            primaryRunesTier3PictureBox1.Location = new Point(160, 344);
            primaryRunesTier3PictureBox2.Location = new Point(232, 344);
            primaryRunesTier3PictureBox3.Location = new Point(304, 344);
            primaryRunesTier3PictureBox4.Location = new Point(376, 344);
            primaryRunesTier3PictureBox4.Visible = true;

            primaryRunesTier3PictureBox1.Image = Images.DominationTree(8135);
            primaryRunesTier3PictureBox2.Image = Images.DominationTree(8134);
            primaryRunesTier3PictureBox3.Image = Images.DominationTree(8105);
            primaryRunesTier3PictureBox4.Image = Images.DominationTree(8106);

            LoadSecondaryTree(8100);
        }

        private void SetSecondaryTreeRunes(int runeTree)
        {
            currentSecondaryTree = runeTree;
            SetRuneSelectionLineColor(runeTree, false);

            if (runeTree == 8100) //Checks if the rune tree is the Domination tree
            {
                secondaryRunesTier3PictureBox4.Visible = true;
                secondaryRunesTier3PictureBox1.Location = new Point(608, 216);
                secondaryRunesTier3PictureBox2.Location = new Point(664, 216);
                secondaryRunesTier3PictureBox3.Location = new Point(720, 216);
                secondaryRunesTier3PictureBox4.Location = new Point(776, 216);
            }

            //The secondary rune trees don't use keystones
            PopualateSecondaryRuneTree(runeTree);
        }

        private void PopualateSecondaryRuneTree(int runTree) //Maybe use the JSON file for this?
        {
            switch(runTree)
            {
                case 8000:
                    secondaryRunesTier1PictureBox1.Image = Images.PrecisionTree(9101);
                    secondaryRunesTier1PictureBox2.Image = Images.PrecisionTree(9111);
                    secondaryRunesTier1PictureBox3.Image = Images.PrecisionTree(8009);

                    secondaryRunesTier2PictureBox1.Image = Images.PrecisionTree(9104);
                    secondaryRunesTier2PictureBox2.Image = Images.PrecisionTree(9105);
                    secondaryRunesTier2PictureBox3.Image = Images.PrecisionTree(9103);

                    secondaryRunesTier3PictureBox1.Image = Images.PrecisionTree(8014);
                    secondaryRunesTier3PictureBox2.Image = Images.PrecisionTree(8017);
                    secondaryRunesTier3PictureBox3.Image = Images.PrecisionTree(8229);
                    secondaryRunesTier3PictureBox4.Image = null;
                    break;

                case 8100:
                    secondaryRunesTier1PictureBox1.Image = Images.DominationTree(8126);
                    secondaryRunesTier1PictureBox2.Image = Images.DominationTree(8139);
                    secondaryRunesTier1PictureBox3.Image = Images.DominationTree(8143);

                    secondaryRunesTier2PictureBox1.Image = Images.DominationTree(8136);
                    secondaryRunesTier2PictureBox2.Image = Images.DominationTree(8120);
                    secondaryRunesTier2PictureBox3.Image = Images.DominationTree(8138);

                    secondaryRunesTier3PictureBox1.Image = Images.DominationTree(8135);
                    secondaryRunesTier3PictureBox2.Image = Images.DominationTree(8134);
                    secondaryRunesTier3PictureBox3.Image = Images.DominationTree(8105);
                    secondaryRunesTier3PictureBox4.Image = Images.DominationTree(8106);
                    break;
            }
        }

        private Image GetRuneImage(int runeTree, int runeId)
        {
            if (runeTree == 8000)
            {
                return Images.PrecisionTree(runeId);
            }
            else if (runeTree == 8100)
            {
                return Images.DominationTree(runeId);
            }
            else if (runeTree == 8200)
            {

            }
            else if (runeTree == 8400)
            {

            }
            else if (runeTree == 8300)
            {

            }

            return null;
        }

        private void LoadSecondaryTree(int primaryTreeChoice) //Loads secondary tree based on the first tree's choice
        {
            if  (secondaryRuneTree != null)
            {
                secondaryRuneTree = null;
                secondaryRuneTree = new List<int>();
            }

            for (int i = 0; i < runesTrees.Length; i++)
            {
                if (runesTrees[i] != primaryTreeChoice)
                {
                    secondaryRuneTree.Add(runesTrees[i]);
                }
            }

            secondaryRune1PictureBox.Image = Images.RuneTree(secondaryRuneTree[0]);
            secondaryRune2PictureBox.Image = Images.RuneTree(secondaryRuneTree[1]);
            secondaryRune3PictureBox.Image = Images.RuneTree(secondaryRuneTree[2]);
            secondaryRune4PictureBox.Image = Images.RuneTree(secondaryRuneTree[3]);
        }

        private void secondaryRune1PictureBox_Click(object sender, System.EventArgs e)
        {
            secondaryRunePictureBox.Image = Images.RuneTree(secondaryRuneTree[0]);
            SetSecondaryTreeRunes(secondaryRuneTree[0]);
        }

        private void secondaryRune2PictureBox_Click(object sender, System.EventArgs e)
        {
            secondaryRunePictureBox.Image = Images.RuneTree(secondaryRuneTree[1]);
            SetSecondaryTreeRunes(secondaryRuneTree[1]);
        }

        private void secondaryRune3PictureBox_Click(object sender, System.EventArgs e)
        {
            secondaryRunePictureBox.Image = Images.RuneTree(secondaryRuneTree[2]);
            SetSecondaryTreeRunes(secondaryRuneTree[2]);
        }

        private void secondaryRune4PictureBox_Click(object sender, System.EventArgs e)
        {
            secondaryRunePictureBox.Image = Images.RuneTree(secondaryRuneTree[3]);
            SetSecondaryTreeRunes(secondaryRuneTree[3]);
        }

        private void SetRuneSelectionLineColor(int runeTree, bool isPrimaryTree)
        {
            switch (runeTree)
            {
                case 8000:
                    if (isPrimaryTree)
                    {
                        primaryRuneSelectionLine.BackColor = Color.FromArgb(174, 167, 137);
                    }
                    else
                    {
                        secondaryRuneSelectionLine.BackColor = Color.FromArgb(174, 167, 137);
                    }
                    break;
                case 8100:
                    if (isPrimaryTree)
                    {
                        primaryRuneSelectionLine.BackColor = Color.FromArgb(212, 66, 66);
                    }
                    else
                    {
                        secondaryRuneSelectionLine.BackColor = Color.FromArgb(212, 66, 66);
                    }
                    break;
                case 8200:
                    if (isPrimaryTree)
                    {
                        primaryRuneSelectionLine.BackColor = Color.FromArgb(159,170, 252);
                    }
                    else
                    {
                        secondaryRuneSelectionLine.BackColor = Color.FromArgb(159, 170, 252);
                    }
                    break;
                case 8400:
                    if (isPrimaryTree)
                    {
                        primaryRuneSelectionLine.BackColor = Color.FromArgb(161, 213, 134);
                    }
                    else
                    {
                        secondaryRuneSelectionLine.BackColor = Color.FromArgb(161, 213, 134);
                    }
                    break;
                case 8300:
                    if (isPrimaryTree)
                    {
                        primaryRuneSelectionLine.BackColor = Color.FromArgb(73, 170, 185);
                    }
                    else
                    {
                        secondaryRuneSelectionLine.BackColor = Color.FromArgb(73, 170, 185);
                    }
                    break;
            }
        }

        private void ResetSecondaryTree()
        {
            secondaryRunesTier1PictureBox1.Image = null;
            secondaryRunesTier1PictureBox2.Image = null;
            secondaryRunesTier1PictureBox3.Image = null;

            secondaryRunesTier2PictureBox1.Image = null;
            secondaryRunesTier2PictureBox2.Image = null;
            secondaryRunesTier2PictureBox3.Image = null;

            secondaryRunesTier3PictureBox1.Image = null;
            secondaryRunesTier3PictureBox2.Image = null;
            secondaryRunesTier3PictureBox3.Image = null;
            secondaryRunesTier3PictureBox4.Image = null;

            if (secondaryRunesTier3PictureBox4.Visible)
            {

                secondaryRunesTier3PictureBox4.Visible = false;
                secondaryRunesTier3PictureBox1.Location = new Point(632, 216);
                secondaryRunesTier3PictureBox2.Location = new Point(688, 216);
                secondaryRunesTier3PictureBox3.Location = new Point(744, 216);
                secondaryRunesTier3PictureBox4.Location = new Point(800, 216);
            }
        }
    }
}
