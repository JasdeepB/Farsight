using Farsight.Deserializable_Objects.Perks;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Farsight.UI_s_and_Controllers
{
    public partial class RunePageEditor : Form
    {
        List<AllRunes> allRuneTrees = JSONParser.Runes();
        int[] runesTrees = { 8000, 8100, 8200, 8400, 8300 }; //Pricision, Domination, Sorcery, Resolve, Inspiration
        List<int> secondaryRuneTree = new List<int>();
        int currentSecondaryTree = 0;
        bool primaryTreeIsDomination = false;

        //Maybe create a builder object to store user selections
        //Create a button programatically to show what rune has been selected, doing it this way means you can generate multiple ones from a single source

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

            if (primaryRuneKeystone4PictureBox.Visible == false)
            {
                primaryRuneKeystone1PictureBox.Location = new Point(152, 112);
                primaryRuneKeystone2PictureBox.Location = new Point(224, 112);
                primaryRuneKeystone3PictureBox.Location = new Point(296, 112);
                primaryRuneKeystone4PictureBox.Location = new Point(368, 112);
                primaryRuneKeystone4PictureBox.Visible = true;
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

            LoadSecondaryTreeOptions(8000);
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

            if (primaryRuneKeystone4PictureBox.Visible == false)
            {
                primaryRuneKeystone1PictureBox.Location = new Point(152, 112);
                primaryRuneKeystone2PictureBox.Location = new Point(224, 112);
                primaryRuneKeystone3PictureBox.Location = new Point(296, 112);
                primaryRuneKeystone4PictureBox.Location = new Point(368, 112);
                primaryRuneKeystone4PictureBox.Visible = true;
            }

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

            LoadSecondaryTreeOptions(8100);
        }

        private void sorceryPictureBox_Click(object sender, System.EventArgs e)
        {
            if (currentSecondaryTree == 8200)
            {
                ResetSecondaryTree();
                secondaryRunePictureBox.Image = null;
            }

            if (primaryRuneKeystone4PictureBox.Visible)
            {
                primaryRuneKeystone1PictureBox.Location = new Point(192, 112);
                primaryRuneKeystone2PictureBox.Location = new Point(264, 112);
                primaryRuneKeystone3PictureBox.Location = new Point(336, 112);
                primaryRuneKeystone4PictureBox.Location = new Point(408, 112);
                primaryRuneKeystone4PictureBox.Visible = false;
            }

            if (primaryTreeIsDomination == true)
            {
                primaryRunesTier3PictureBox1.Location = new Point(200, 344);
                primaryRunesTier3PictureBox2.Location = new Point(272, 344);
                primaryRunesTier3PictureBox3.Location = new Point(344, 344);
                primaryRunesTier3PictureBox4.Location = new Point(408, 344);
                primaryRunesTier3PictureBox4.Visible = false;
            }

            primaryTreeIsDomination = false;

            primaryRunePictureBox.Image = Images.RuneTree(8200);

            SetRuneSelectionLineColor(8200, true);

            primaryRuneKeystone1PictureBox.Image = Images.SorceryTree(8214);
            primaryRuneKeystone2PictureBox.Image = Images.SorceryTree(8229);
            primaryRuneKeystone3PictureBox.Image = Images.SorceryTree(8230);
            primaryRuneKeystone4PictureBox.Image = null;

            primaryRunesTier1PictureBox1.Image = Images.SorceryTree(8224);
            primaryRunesTier1PictureBox2.Image = Images.SorceryTree(8226);
            primaryRunesTier1PictureBox3.Image = Images.SorceryTree(8275);

            primaryRunesTier2PictureBox1.Image = Images.SorceryTree(8210);
            primaryRunesTier2PictureBox2.Image = Images.SorceryTree(8234);
            primaryRunesTier2PictureBox3.Image = Images.SorceryTree(8233);

            primaryRunesTier3PictureBox1.Image = Images.SorceryTree(8237);
            primaryRunesTier3PictureBox2.Image = Images.SorceryTree(8232);
            primaryRunesTier3PictureBox3.Image = Images.SorceryTree(8236);
            primaryRunesTier3PictureBox4.Image = null;

            LoadSecondaryTreeOptions(8200);
        }

        private void resolvePictureBox_Click(object sender, System.EventArgs e)
        {
            if (currentSecondaryTree == 8400)
            {
                ResetSecondaryTree();
                secondaryRunePictureBox.Image = null;
            }

            if (primaryRuneKeystone4PictureBox.Visible)
            {
                primaryRuneKeystone1PictureBox.Location = new Point(192, 112);
                primaryRuneKeystone2PictureBox.Location = new Point(264, 112);
                primaryRuneKeystone3PictureBox.Location = new Point(336, 112);
                primaryRuneKeystone4PictureBox.Location = new Point(408, 112);
                primaryRuneKeystone4PictureBox.Visible = false;
            }

            if (primaryTreeIsDomination == true)
            {
                primaryRunesTier3PictureBox1.Location = new Point(200, 344);
                primaryRunesTier3PictureBox2.Location = new Point(272, 344);
                primaryRunesTier3PictureBox3.Location = new Point(344, 344);
                primaryRunesTier3PictureBox4.Location = new Point(408, 344);
                primaryRunesTier3PictureBox4.Visible = false;
            }

            primaryTreeIsDomination = false;

            primaryRunePictureBox.Image = Images.RuneTree(8400);

            SetRuneSelectionLineColor(8400, true);

            primaryRuneKeystone1PictureBox.Image = Images.ResolveTree(8437);
            primaryRuneKeystone2PictureBox.Image = Images.ResolveTree(8439);
            primaryRuneKeystone3PictureBox.Image = Images.ResolveTree(8465);
            primaryRuneKeystone4PictureBox.Image = null;

            primaryRunesTier1PictureBox1.Image = Images.ResolveTree(8446);
            primaryRunesTier1PictureBox2.Image = Images.ResolveTree(8463);
            primaryRunesTier1PictureBox3.Image = Images.ResolveTree(8401);

            primaryRunesTier2PictureBox1.Image = Images.ResolveTree(8429);
            primaryRunesTier2PictureBox2.Image = Images.ResolveTree(8444);
            primaryRunesTier2PictureBox3.Image = Images.ResolveTree(8473);

            primaryRunesTier3PictureBox1.Image = Images.ResolveTree(8451);
            primaryRunesTier3PictureBox2.Image = Images.ResolveTree(8453);
            primaryRunesTier3PictureBox3.Image = Images.ResolveTree(8242);
            primaryRunesTier3PictureBox4.Image = null;

            LoadSecondaryTreeOptions(8400);
        }

        private void inspirationPictureBox_Click(object sender, System.EventArgs e)
        {
            if (currentSecondaryTree == 8300)
            {
                ResetSecondaryTree();
                secondaryRunePictureBox.Image = null;
            }

            if (primaryRuneKeystone4PictureBox.Visible)
            {
                primaryRuneKeystone1PictureBox.Location = new Point(192, 112);
                primaryRuneKeystone2PictureBox.Location = new Point(264, 112);
                primaryRuneKeystone3PictureBox.Location = new Point(336, 112);
                primaryRuneKeystone4PictureBox.Location = new Point(408, 112);
                primaryRuneKeystone4PictureBox.Visible = false;
            }

            if (primaryTreeIsDomination == true)
            {
                primaryRunesTier3PictureBox1.Location = new Point(200, 344);
                primaryRunesTier3PictureBox2.Location = new Point(272, 344);
                primaryRunesTier3PictureBox3.Location = new Point(344, 344);
                primaryRunesTier3PictureBox4.Location = new Point(408, 344);
                primaryRunesTier3PictureBox4.Visible = false;
            }

            primaryTreeIsDomination = false;

            primaryRunePictureBox.Image = Images.RuneTree(8300);

            SetRuneSelectionLineColor(8300, true);

            primaryRuneKeystone1PictureBox.Image = Images.InspirationTree(8351);
            primaryRuneKeystone2PictureBox.Image = Images.InspirationTree(8360);
            primaryRuneKeystone3PictureBox.Image = Images.InspirationTree(8358);
            primaryRuneKeystone4PictureBox.Image = null;

            primaryRunesTier1PictureBox1.Image = Images.InspirationTree(8306);
            primaryRunesTier1PictureBox2.Image = Images.InspirationTree(8304);
            primaryRunesTier1PictureBox3.Image = Images.InspirationTree(8313);

            primaryRunesTier2PictureBox1.Image = Images.InspirationTree(8321);
            primaryRunesTier2PictureBox2.Image = Images.InspirationTree(8316);
            primaryRunesTier2PictureBox3.Image = Images.InspirationTree(8345);

            primaryRunesTier3PictureBox1.Image = Images.InspirationTree(8347);
            primaryRunesTier3PictureBox2.Image = Images.InspirationTree(8410);
            primaryRunesTier3PictureBox3.Image = Images.InspirationTree(8352);
            primaryRunesTier3PictureBox4.Image = null;

            LoadSecondaryTreeOptions(8300);
        }

        private void LoadSecondaryTreeOptions(int primaryTreeChoice) //Loads secondary tree selection based on the first tree's choice
        {
            if (secondaryRuneTree != null)
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
            else
            {
                secondaryRunesTier3PictureBox4.Visible = false;
                secondaryRunesTier3PictureBox1.Location = new Point(632, 216);
                secondaryRunesTier3PictureBox2.Location = new Point(688, 216);
                secondaryRunesTier3PictureBox3.Location = new Point(744, 216);
                secondaryRunesTier3PictureBox4.Location = new Point(800, 216);
            }

            //The secondary rune trees don't use keystones
            SetSecondaryRuneTreeImages(runeTree);
        }

        private void SetSecondaryRuneTreeImages(int runeTree)
        {
            switch (runeTree)
            {
                case 8000:
                    secondaryRunesTier1PictureBox1.Image = Images.PrecisionTree(allRuneTrees[2].slots[1].runes[0].id);
                    secondaryRunesTier1PictureBox2.Image = Images.PrecisionTree(allRuneTrees[2].slots[1].runes[1].id);
                    secondaryRunesTier1PictureBox3.Image = Images.PrecisionTree(allRuneTrees[2].slots[1].runes[2].id);

                    secondaryRunesTier2PictureBox1.Image = Images.PrecisionTree(allRuneTrees[2].slots[2].runes[0].id);
                    secondaryRunesTier2PictureBox2.Image = Images.PrecisionTree(allRuneTrees[2].slots[2].runes[1].id);
                    secondaryRunesTier2PictureBox3.Image = Images.PrecisionTree(allRuneTrees[2].slots[2].runes[2].id);

                    secondaryRunesTier3PictureBox1.Image = Images.PrecisionTree(allRuneTrees[2].slots[3].runes[0].id);
                    secondaryRunesTier3PictureBox2.Image = Images.PrecisionTree(allRuneTrees[2].slots[3].runes[1].id);
                    secondaryRunesTier3PictureBox3.Image = Images.PrecisionTree(allRuneTrees[2].slots[3].runes[2].id);
                    secondaryRunesTier3PictureBox4.Image = null;
                    break;

                case 8100:
                    secondaryRunesTier1PictureBox1.Image = Images.DominationTree(allRuneTrees[0].slots[1].runes[0].id);
                    secondaryRunesTier1PictureBox2.Image = Images.DominationTree(allRuneTrees[0].slots[1].runes[1].id);
                    secondaryRunesTier1PictureBox3.Image = Images.DominationTree(allRuneTrees[0].slots[1].runes[2].id);

                    secondaryRunesTier2PictureBox1.Image = Images.DominationTree(allRuneTrees[0].slots[2].runes[0].id);
                    secondaryRunesTier2PictureBox2.Image = Images.DominationTree(allRuneTrees[0].slots[2].runes[1].id);
                    secondaryRunesTier2PictureBox3.Image = Images.DominationTree(allRuneTrees[0].slots[2].runes[2].id);

                    secondaryRunesTier3PictureBox1.Image = Images.DominationTree(allRuneTrees[0].slots[3].runes[0].id);
                    secondaryRunesTier3PictureBox2.Image = Images.DominationTree(allRuneTrees[0].slots[3].runes[1].id);
                    secondaryRunesTier3PictureBox3.Image = Images.DominationTree(allRuneTrees[0].slots[3].runes[2].id);
                    secondaryRunesTier3PictureBox4.Image = Images.DominationTree(allRuneTrees[0].slots[3].runes[3].id);
                    break;

                case 8200:
                    secondaryRunesTier1PictureBox1.Image = Images.SorceryTree(allRuneTrees[4].slots[1].runes[0].id);
                    secondaryRunesTier1PictureBox2.Image = Images.SorceryTree(allRuneTrees[4].slots[1].runes[1].id);
                    secondaryRunesTier1PictureBox3.Image = Images.SorceryTree(allRuneTrees[4].slots[1].runes[2].id);

                    secondaryRunesTier2PictureBox1.Image = Images.SorceryTree(allRuneTrees[4].slots[2].runes[0].id);
                    secondaryRunesTier2PictureBox2.Image = Images.SorceryTree(allRuneTrees[4].slots[2].runes[1].id);
                    secondaryRunesTier2PictureBox3.Image = Images.SorceryTree(allRuneTrees[4].slots[2].runes[2].id);

                    secondaryRunesTier3PictureBox1.Image = Images.SorceryTree(allRuneTrees[4].slots[3].runes[0].id);
                    secondaryRunesTier3PictureBox2.Image = Images.SorceryTree(allRuneTrees[4].slots[3].runes[1].id);
                    secondaryRunesTier3PictureBox3.Image = Images.SorceryTree(allRuneTrees[4].slots[3].runes[2].id);
                    secondaryRunesTier3PictureBox4.Image = null;
                    break;

                case 8400:
                    secondaryRunesTier1PictureBox1.Image = Images.ResolveTree(allRuneTrees[3].slots[1].runes[0].id);
                    secondaryRunesTier1PictureBox2.Image = Images.ResolveTree(allRuneTrees[3].slots[1].runes[1].id);
                    secondaryRunesTier1PictureBox3.Image = Images.ResolveTree(allRuneTrees[3].slots[1].runes[2].id);

                    secondaryRunesTier2PictureBox1.Image = Images.ResolveTree(allRuneTrees[3].slots[2].runes[0].id);
                    secondaryRunesTier2PictureBox2.Image = Images.ResolveTree(allRuneTrees[3].slots[2].runes[1].id);
                    secondaryRunesTier2PictureBox3.Image = Images.ResolveTree(allRuneTrees[3].slots[2].runes[2].id);

                    secondaryRunesTier3PictureBox1.Image = Images.ResolveTree(allRuneTrees[3].slots[3].runes[0].id);
                    secondaryRunesTier3PictureBox2.Image = Images.ResolveTree(allRuneTrees[3].slots[3].runes[1].id);
                    secondaryRunesTier3PictureBox3.Image = Images.ResolveTree(allRuneTrees[3].slots[3].runes[2].id);
                    secondaryRunesTier3PictureBox4.Image = null;
                    break;

                case 8300:
                    secondaryRunesTier1PictureBox1.Image = Images.InspirationTree(allRuneTrees[1].slots[1].runes[0].id);
                    secondaryRunesTier1PictureBox2.Image = Images.InspirationTree(allRuneTrees[1].slots[1].runes[1].id);
                    secondaryRunesTier1PictureBox3.Image = Images.InspirationTree(allRuneTrees[1].slots[1].runes[2].id);

                    secondaryRunesTier2PictureBox1.Image = Images.InspirationTree(allRuneTrees[1].slots[2].runes[0].id);
                    secondaryRunesTier2PictureBox2.Image = Images.InspirationTree(allRuneTrees[1].slots[2].runes[1].id);
                    secondaryRunesTier2PictureBox3.Image = Images.InspirationTree(allRuneTrees[1].slots[2].runes[2].id);

                    secondaryRunesTier3PictureBox1.Image = Images.InspirationTree(allRuneTrees[1].slots[3].runes[0].id);
                    secondaryRunesTier3PictureBox2.Image = Images.InspirationTree(allRuneTrees[1].slots[3].runes[1].id);
                    secondaryRunesTier3PictureBox3.Image = Images.InspirationTree(allRuneTrees[1].slots[3].runes[2].id);
                    secondaryRunesTier3PictureBox4.Image = null;
                    break;
            }
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
                        primaryRuneSelectionLine.BackColor = Color.FromArgb(159, 170, 252);
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
