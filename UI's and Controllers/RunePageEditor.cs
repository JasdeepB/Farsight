using Farsight.Deserializable_Objects.Perks;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Farsight.UI_s_and_Controllers
{
    public partial class RunePageEditor : Form
    {

        #region Global Variables
        List<AllRunes> allRuneTrees = JSONParser.Runes();
        int[] runesTrees = { 8000, 8100, 8200, 8400, 8300 }; //Pricision, Domination, Sorcery, Resolve, Inspiration
        List<int> secondaryRuneTree = new List<int>();
        int currentPrimaryTree = 0;
        int currentSecondaryTree = 0;
        int lastRowSelected = 0;
        bool primaryTreeIsDomination = false;
        Button primaryTreeKeystoneSelection = new Button();
        Button primaryTreeRowOneSelection = new Button();
        Button primaryTreeRowTwoSelection = new Button();
        Button primaryTreeRowThreeSelection = new Button();
        Button secondaryTreeRowOneSelection = new Button();
        Button secondaryTreeRowTwoSelection = new Button();
        Button secondaryTreeRowThreeSelection = new Button();
        Button statModOffenseSelection = new Button();
        Button statModFlexSelection = new Button();
        Button statModDefenseSelection = new Button();
        RunePage runePage = new RunePage();
        Queue<int> rows = new Queue<int>();
        Dictionary<int, int> secondaryRunes = new Dictionary<int, int>();
        #endregion

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
            primaryRuneKeystone4PictureBox.Visible = false;

            statModOffenseAdaptiveForcePictureBox.Image = Images.StatMods("AdaptiveForce");
            statModOffenseAttackSpeedPictureBox.Image = Images.StatMods("AttackSpeed");
            statModOffenseCDRPictureBox.Image = Images.StatMods("CDR");

            statModFlexAdaptiveForcePictureBox.Image = Images.StatMods("AdaptiveForce");
            statModFlexArmorPictureBox.Image = Images.StatMods("Armor");
            statModFlexMagicResistPictureBox.Image = Images.StatMods("MagicResist");

            statModDefenseHealthPictureBox.Image = Images.StatMods("Health");
            statModDefenseArmorPictureBox.Image = Images.StatMods("Armor");
            statModDefenseMagicResistPictureBox.Image = Images.StatMods("MagicResist");
        }

        #region Primary Tree
        private void precisionPictureBox_Click(object sender, System.EventArgs e)
        {
            ClearPrimaryRuneSelections();
            currentPrimaryTree = 8000;
            runePage.primaryStyleId = currentPrimaryTree;

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
            primaryRunesTier3PictureBox3.Image = Images.PrecisionTree(8299);

            LoadSecondaryTreeOptions(8000);
        }

        private void dominationPictureBox_Click(object sender, System.EventArgs e)
        {
            currentPrimaryTree = 8100;
            runePage.primaryStyleId = currentPrimaryTree;

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
            ClearPrimaryRuneSelections();
        }

        private void sorceryPictureBox_Click(object sender, System.EventArgs e)
        {
            currentPrimaryTree = 8200;
            runePage.primaryStyleId = currentPrimaryTree;
            ClearPrimaryRuneSelections();

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
            currentPrimaryTree = 8400;
            runePage.primaryStyleId = currentPrimaryTree;
            ClearPrimaryRuneSelections();

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
            currentPrimaryTree = 8300;
            runePage.primaryStyleId = currentPrimaryTree;
            ClearPrimaryRuneSelections();

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

        private void primaryRuneKeystone1PictureBox_Click(object sender, System.EventArgs e)
        {
            if (((RoundPictureBox)sender).Name != "primaryRuneKeystone1PictureBox")
            {
                return;
            }

            if (currentPrimaryTree != 0)
            {
                runePage.selectedPerkIds[0] = GetRuneID(currentPrimaryTree, 0, 0);
            }

            primaryTreeKeystoneSelection.Location = new Point(primaryRuneKeystone1PictureBox.Location.X, primaryRuneKeystone1PictureBox.Location.Y);
            primaryTreeKeystoneSelection.Size = new Size(primaryRuneKeystone1PictureBox.Size.Width, primaryRuneKeystone1PictureBox.Height);
            this.Controls.Add(primaryTreeKeystoneSelection);

            primaryRuneKeystone2PictureBox_Click(sender, e);
            primaryRuneKeystone3PictureBox_Click(sender, e);
            primaryRuneKeystone4PictureBox_Click(sender, e);
        }

        private void primaryRuneKeystone2PictureBox_Click(object sender, System.EventArgs e)
        {
            if (((RoundPictureBox)sender).Name != "primaryRuneKeystone2PictureBox")
            {
                return;
            }

            if (currentPrimaryTree != 0)
            {
                runePage.selectedPerkIds[0] = GetRuneID(currentPrimaryTree, 0, 1);
            }

            primaryTreeKeystoneSelection.Location = new Point(primaryRuneKeystone2PictureBox.Location.X, primaryRuneKeystone2PictureBox.Location.Y);
            primaryTreeKeystoneSelection.Size = new Size(primaryRuneKeystone2PictureBox.Size.Width, primaryRuneKeystone2PictureBox.Height);
            this.Controls.Add(primaryTreeKeystoneSelection);

            primaryRuneKeystone1PictureBox_Click(sender, e);
            primaryRuneKeystone3PictureBox_Click(sender, e);
            primaryRuneKeystone4PictureBox_Click(sender, e);
        }

        private void primaryRuneKeystone3PictureBox_Click(object sender, System.EventArgs e)
        {
            if (((RoundPictureBox)sender).Name != "primaryRuneKeystone3PictureBox")
            {
                return;
            }

            if (currentPrimaryTree != 0)
            {
                runePage.selectedPerkIds[0] = GetRuneID(currentPrimaryTree, 0, 2);
            }

            primaryTreeKeystoneSelection.Location = new Point(primaryRuneKeystone3PictureBox.Location.X, primaryRuneKeystone3PictureBox.Location.Y);
            primaryTreeKeystoneSelection.Size = new Size(primaryRuneKeystone3PictureBox.Size.Width, primaryRuneKeystone3PictureBox.Height);
            this.Controls.Add(primaryTreeKeystoneSelection);

            primaryRuneKeystone1PictureBox_Click(sender, e);
            primaryRuneKeystone2PictureBox_Click(sender, e);
            primaryRuneKeystone4PictureBox_Click(sender, e);
        }

        private void primaryRuneKeystone4PictureBox_Click(object sender, System.EventArgs e)
        {
            if (((RoundPictureBox)sender).Name != "primaryRuneKeystone4PictureBox")
            {
                return;
            }

            if (currentPrimaryTree != 0)
            {
                runePage.selectedPerkIds[0] = GetRuneID(currentPrimaryTree, 0, 3);
            }

            primaryTreeKeystoneSelection.Location = new Point(primaryRuneKeystone4PictureBox.Location.X, primaryRuneKeystone4PictureBox.Location.Y);
            primaryTreeKeystoneSelection.Size = new Size(primaryRuneKeystone4PictureBox.Size.Width, primaryRuneKeystone4PictureBox.Height);
            this.Controls.Add(primaryTreeKeystoneSelection);

            primaryRuneKeystone1PictureBox_Click(sender, e);
            primaryRuneKeystone2PictureBox_Click(sender, e);
            primaryRuneKeystone3PictureBox_Click(sender, e);
        }

        private void primaryRunesTier1PictureBox1_Click(object sender, System.EventArgs e)
        {
            if (((RoundPictureBox)sender).Name != "primaryRunesTier1PictureBox1")
            {
                return;
            }

            if (currentPrimaryTree != 0)
            {
                runePage.selectedPerkIds[1] = GetRuneID(currentPrimaryTree, 1, 0);
            }

            primaryTreeRowOneSelection.Location = new Point(primaryRunesTier1PictureBox1.Location.X, primaryRunesTier1PictureBox1.Location.Y);
            primaryTreeRowOneSelection.Size = new Size(primaryRunesTier1PictureBox1.Size.Width, primaryRunesTier1PictureBox1.Size.Height);
            this.Controls.Add(primaryTreeRowOneSelection);

            primaryRunesTier1PictureBox2_Click(sender, e);
            primaryRunesTier1PictureBox3_Click(sender, e);
        }

        private void primaryRunesTier1PictureBox2_Click(object sender, System.EventArgs e)
        {
            if (((RoundPictureBox)sender).Name != "primaryRunesTier1PictureBox2")
            {
                return;
            }

            if (currentPrimaryTree != 0)
            {
                runePage.selectedPerkIds[1] = GetRuneID(currentPrimaryTree, 1, 1);
            }

            primaryTreeRowOneSelection.Location = new Point(primaryRunesTier1PictureBox2.Location.X, primaryRunesTier1PictureBox2.Location.Y);
            primaryTreeRowOneSelection.Size = new Size(primaryRunesTier1PictureBox2.Size.Width, primaryRunesTier1PictureBox2.Size.Height);
            this.Controls.Add(primaryTreeRowOneSelection);

            primaryRunesTier1PictureBox1_Click(sender, e);
            primaryRunesTier1PictureBox3_Click(sender, e);
        }

        private void primaryRunesTier1PictureBox3_Click(object sender, System.EventArgs e)
        {
            if (((RoundPictureBox)sender).Name != "primaryRunesTier1PictureBox3")
            {
                return;
            }

            if (currentPrimaryTree != 0)
            {
                runePage.selectedPerkIds[1] = GetRuneID(currentPrimaryTree, 1, 2);
            }

            primaryTreeRowOneSelection.Location = new Point(primaryRunesTier1PictureBox3.Location.X, primaryRunesTier1PictureBox3.Location.Y);
            primaryTreeRowOneSelection.Size = new Size(primaryRunesTier1PictureBox3.Size.Width, primaryRunesTier1PictureBox3.Size.Height);
            this.Controls.Add(primaryTreeRowOneSelection);

            primaryRunesTier1PictureBox1_Click(sender, e);
            primaryRunesTier1PictureBox2_Click(sender, e);
        }

        private void primaryRunesTier2PictureBox1_Click(object sender, System.EventArgs e)
        {
            if (((RoundPictureBox)sender).Name != "primaryRunesTier2PictureBox1")
            {
                return;
            }

            if (currentPrimaryTree != 0)
            {
                runePage.selectedPerkIds[2] = GetRuneID(currentPrimaryTree, 2, 0);
            }

            primaryTreeRowTwoSelection.Location = new Point(primaryRunesTier2PictureBox1.Location.X, primaryRunesTier2PictureBox1.Location.Y);
            primaryTreeRowTwoSelection.Size = new Size(primaryRunesTier2PictureBox1.Size.Width, primaryRunesTier2PictureBox1.Size.Height);
            this.Controls.Add(primaryTreeRowTwoSelection);

            primaryRunesTier2PictureBox2_Click(sender, e);
            primaryRunesTier2PictureBox3_Click(sender, e);
        }

        private void primaryRunesTier2PictureBox2_Click(object sender, System.EventArgs e)
        {
            if (((RoundPictureBox)sender).Name != "primaryRunesTier2PictureBox2")
            {
                return;
            }

            if (currentPrimaryTree != 0)
            {
                runePage.selectedPerkIds[2] = GetRuneID(currentPrimaryTree, 2, 1);
            }

            primaryTreeRowTwoSelection.Location = new Point(primaryRunesTier2PictureBox2.Location.X, primaryRunesTier2PictureBox2.Location.Y);
            primaryTreeRowTwoSelection.Size = new Size(primaryRunesTier2PictureBox2.Size.Width, primaryRunesTier2PictureBox2.Size.Height);
            this.Controls.Add(primaryTreeRowTwoSelection);

            primaryRunesTier2PictureBox1_Click(sender, e);
            primaryRunesTier2PictureBox3_Click(sender, e);
        }

        private void primaryRunesTier2PictureBox3_Click(object sender, System.EventArgs e)
        {
            if (((RoundPictureBox)sender).Name != "primaryRunesTier2PictureBox3")
            {
                return;
            }

            if (currentPrimaryTree != 0)
            {
                runePage.selectedPerkIds[2] = GetRuneID(currentPrimaryTree, 2, 2);
            }

            primaryTreeRowTwoSelection.Location = new Point(primaryRunesTier2PictureBox3.Location.X, primaryRunesTier2PictureBox3.Location.Y);
            primaryTreeRowTwoSelection.Size = new Size(primaryRunesTier2PictureBox3.Size.Width, primaryRunesTier2PictureBox3.Size.Height);
            this.Controls.Add(primaryTreeRowTwoSelection);

            primaryRunesTier2PictureBox1_Click(sender, e);
            primaryRunesTier2PictureBox2_Click(sender, e);
        }

        private void primaryRunesTier3PictureBox1_Click(object sender, System.EventArgs e)
        {
            if (((RoundPictureBox)sender).Name != "primaryRunesTier3PictureBox1")
            {
                return;
            }

            if (currentPrimaryTree != 0)
            {
                runePage.selectedPerkIds[3] = GetRuneID(currentPrimaryTree, 3, 0);
            }

            primaryTreeRowThreeSelection.Location = new Point(primaryRunesTier3PictureBox1.Location.X, primaryRunesTier3PictureBox1.Location.Y);
            primaryTreeRowThreeSelection.Size = new Size(primaryRunesTier3PictureBox1.Size.Width, primaryRunesTier3PictureBox1.Size.Height);
            this.Controls.Add(primaryTreeRowThreeSelection);

            primaryRunesTier3PictureBox2_Click(sender, e);
            primaryRunesTier3PictureBox3_Click(sender, e);
            primaryRunesTier3PictureBox4_Click(sender, e);
        }

        private void primaryRunesTier3PictureBox2_Click(object sender, System.EventArgs e)
        {
            if (((RoundPictureBox)sender).Name != "primaryRunesTier3PictureBox2")
            {
                return;
            }

            if (currentPrimaryTree != 0)
            {
                runePage.selectedPerkIds[3] = GetRuneID(currentPrimaryTree, 3, 1);
            }

            primaryTreeRowThreeSelection.Location = new Point(primaryRunesTier3PictureBox2.Location.X, primaryRunesTier3PictureBox2.Location.Y);
            primaryTreeRowThreeSelection.Size = new Size(primaryRunesTier3PictureBox2.Size.Width, primaryRunesTier3PictureBox2.Size.Height);
            this.Controls.Add(primaryTreeRowThreeSelection);

            primaryRunesTier3PictureBox1_Click(sender, e);
            primaryRunesTier3PictureBox3_Click(sender, e);
            primaryRunesTier3PictureBox4_Click(sender, e);
        }

        private void primaryRunesTier3PictureBox3_Click(object sender, System.EventArgs e)
        {
            if (((RoundPictureBox)sender).Name != "primaryRunesTier3PictureBox3")
            {
                return;
            }

            if (currentPrimaryTree != 0)
            {
                runePage.selectedPerkIds[3] = GetRuneID(currentPrimaryTree, 3, 2);
            }

            primaryTreeRowThreeSelection.Location = new Point(primaryRunesTier3PictureBox3.Location.X, primaryRunesTier3PictureBox3.Location.Y);
            primaryTreeRowThreeSelection.Size = new Size(primaryRunesTier3PictureBox3.Size.Width, primaryRunesTier3PictureBox3.Size.Height);
            this.Controls.Add(primaryTreeRowThreeSelection);

            primaryRunesTier3PictureBox1_Click(sender, e);
            primaryRunesTier3PictureBox2_Click(sender, e);
            primaryRunesTier3PictureBox4_Click(sender, e);
        }

        private void primaryRunesTier3PictureBox4_Click(object sender, System.EventArgs e)
        {
            if (((RoundPictureBox)sender).Name != "primaryRunesTier3PictureBox4")
            {
                return;
            }

            if (currentPrimaryTree != 0)
            {
                runePage.selectedPerkIds[3] = GetRuneID(currentPrimaryTree, 3, 3);
            }

            primaryTreeRowThreeSelection.Location = new Point(primaryRunesTier3PictureBox4.Location.X, primaryRunesTier3PictureBox4.Location.Y);
            primaryTreeRowThreeSelection.Size = new Size(primaryRunesTier3PictureBox4.Size.Width, primaryRunesTier3PictureBox4.Size.Height);
            this.Controls.Add(primaryTreeRowThreeSelection);

            primaryRunesTier3PictureBox1_Click(sender, e);
            primaryRunesTier3PictureBox2_Click(sender, e);
            primaryRunesTier3PictureBox3_Click(sender, e);
        }

        private void ClearPrimaryRuneSelections()
        {
            this.Controls.Remove(primaryTreeKeystoneSelection);
            this.Controls.Remove(primaryTreeRowOneSelection);
            this.Controls.Remove(primaryTreeRowTwoSelection);
            this.Controls.Remove(primaryTreeRowThreeSelection);
        }
        #endregion

        #region Secondary Tree
        private void secondaryRune1PictureBox_Click(object sender, System.EventArgs e)
        {
            secondaryRunePictureBox.Image = Images.RuneTree(secondaryRuneTree[0]);
            SetSecondaryTreeRunes(secondaryRuneTree[0]);
            ClearSecondaryRuneSelections();
        }

        private void secondaryRune2PictureBox_Click(object sender, System.EventArgs e)
        {
            secondaryRunePictureBox.Image = Images.RuneTree(secondaryRuneTree[1]);
            SetSecondaryTreeRunes(secondaryRuneTree[1]);
            ClearSecondaryRuneSelections();
        }

        private void secondaryRune3PictureBox_Click(object sender, System.EventArgs e)
        {
            secondaryRunePictureBox.Image = Images.RuneTree(secondaryRuneTree[2]);
            SetSecondaryTreeRunes(secondaryRuneTree[2]);
            ClearSecondaryRuneSelections();
        }

        private void secondaryRune4PictureBox_Click(object sender, System.EventArgs e)
        {
            secondaryRunePictureBox.Image = Images.RuneTree(secondaryRuneTree[3]);
            SetSecondaryTreeRunes(secondaryRuneTree[3]);
            ClearSecondaryRuneSelections();
        }

        //All secondary tree don't use keystones
        private void secondaryRunesTier1PictureBox1_Click(object sender, System.EventArgs e)
        {
            if (((RoundPictureBox)sender).Name != "secondaryRunesTier1PictureBox1")
            {
                return;
            }

            if (currentSecondaryTree != 0)
            {
                int runeId = GetRuneID(currentSecondaryTree, 1, 0);

                if (ThirdRuneSelectedDetector(1))
                {
                    SetSecondaryRune(runeId, 1);
                }
                else
                {
                    SetSecondaryRune(runeId, 1);
                    ResetSecondaryRuneSelection(lastRowSelected);
                }

                secondaryTreeRow1CheckBox.Checked = true;
            }

            secondaryTreeRowOneSelection.Location = new Point(secondaryRunesTier1PictureBox1.Location.X, secondaryRunesTier1PictureBox1.Location.Y);
            secondaryTreeRowOneSelection.Size = new Size(secondaryRunesTier1PictureBox1.Size.Width, secondaryRunesTier1PictureBox1.Size.Height);
            this.Controls.Add(secondaryTreeRowOneSelection);

            secondaryRunesTier1PictureBox2_Click(sender, e);
            secondaryRunesTier1PictureBox3_Click(sender, e);
        }

        private void secondaryRunesTier1PictureBox2_Click(object sender, System.EventArgs e)
        {
            if (((RoundPictureBox)sender).Name != "secondaryRunesTier1PictureBox2")
            {
                return;
            }

            if (currentSecondaryTree != 0)
            {
                int runeId = GetRuneID(currentSecondaryTree, 1, 1);

                if (ThirdRuneSelectedDetector(1))
                {
                    SetSecondaryRune(runeId, 1);
                }
                else
                {
                    SetSecondaryRune(runeId, 1);
                    ResetSecondaryRuneSelection(lastRowSelected);
                }

                secondaryTreeRow1CheckBox.Checked = true;
            }

            secondaryTreeRowOneSelection.Location = new Point(secondaryRunesTier1PictureBox2.Location.X, secondaryRunesTier1PictureBox2.Location.Y);
            secondaryTreeRowOneSelection.Size = new Size(secondaryRunesTier1PictureBox2.Size.Width, secondaryRunesTier1PictureBox2.Size.Height);
            this.Controls.Add(secondaryTreeRowOneSelection);

            secondaryRunesTier1PictureBox1_Click(sender, e);
            secondaryRunesTier1PictureBox3_Click(sender, e);
        }

        private void secondaryRunesTier1PictureBox3_Click(object sender, System.EventArgs e)
        {
            if (((RoundPictureBox)sender).Name != "secondaryRunesTier1PictureBox3")
            {
                return;
            }

            if (currentSecondaryTree != 0)
            {
                int runeId = GetRuneID(currentSecondaryTree, 1, 2);

                if (ThirdRuneSelectedDetector(1))
                {
                    SetSecondaryRune(runeId, 1);
                }
                else
                {
                    SetSecondaryRune(runeId, 1);
                    ResetSecondaryRuneSelection(lastRowSelected);
                }

                secondaryTreeRow1CheckBox.Checked = true;
            }

            secondaryTreeRowOneSelection.Location = new Point(secondaryRunesTier1PictureBox3.Location.X, secondaryRunesTier1PictureBox3.Location.Y);
            secondaryTreeRowOneSelection.Size = new Size(secondaryRunesTier1PictureBox3.Size.Width, secondaryRunesTier1PictureBox3.Size.Height);
            this.Controls.Add(secondaryTreeRowOneSelection);

            secondaryRunesTier1PictureBox1_Click(sender, e);
            secondaryRunesTier1PictureBox2_Click(sender, e);
        }

        private void secondaryRunesTier2PictureBox1_Click(object sender, System.EventArgs e)
        {
            if (((RoundPictureBox)sender).Name != "secondaryRunesTier2PictureBox1")
            {
                return;
            }

            if (currentSecondaryTree != 0)
            {
                int runeId = GetRuneID(currentSecondaryTree, 2, 0);

                if (ThirdRuneSelectedDetector(2))
                {
                    SetSecondaryRune(runeId, 2);
                }
                else
                {
                    SetSecondaryRune(runeId, 2);
                    ResetSecondaryRuneSelection(lastRowSelected);
                }

                secondaryTreeRow2CheckBox.Checked = true;
            }

            secondaryTreeRowTwoSelection.Location = new Point(secondaryRunesTier2PictureBox1.Location.X, secondaryRunesTier2PictureBox1.Location.Y);
            secondaryTreeRowTwoSelection.Size = new Size(secondaryRunesTier2PictureBox1.Size.Width, secondaryRunesTier2PictureBox1.Size.Height);
            this.Controls.Add(secondaryTreeRowTwoSelection);

            secondaryRunesTier2PictureBox2_Click(sender, e);
            secondaryRunesTier2PictureBox3_Click(sender, e);
        }

        private void secondaryRunesTier2PictureBox2_Click(object sender, System.EventArgs e)
        {
            if (((RoundPictureBox)sender).Name != "secondaryRunesTier2PictureBox2")
            {
                return;
            }

            if (currentSecondaryTree != 0)
            {
                int runeId = GetRuneID(currentSecondaryTree, 2, 1);

                if (ThirdRuneSelectedDetector(2))
                {
                    SetSecondaryRune(runeId, 2);
                }
                else
                {
                    SetSecondaryRune(runeId, 2);
                    ResetSecondaryRuneSelection(lastRowSelected);
                }

                secondaryTreeRow2CheckBox.Checked = true;
            }

            secondaryTreeRowTwoSelection.Location = new Point(secondaryRunesTier2PictureBox2.Location.X, secondaryRunesTier2PictureBox2.Location.Y);
            secondaryTreeRowTwoSelection.Size = new Size(secondaryRunesTier2PictureBox2.Size.Width, secondaryRunesTier2PictureBox2.Size.Height);
            this.Controls.Add(secondaryTreeRowTwoSelection);

            secondaryRunesTier2PictureBox1_Click(sender, e);
            secondaryRunesTier2PictureBox3_Click(sender, e);
        }

        private void secondaryRunesTier2PictureBox3_Click(object sender, System.EventArgs e)
        {
            if (((RoundPictureBox)sender).Name != "secondaryRunesTier2PictureBox3")
            {
                return;
            }

            if (currentSecondaryTree != 0)
            {
                int runeId = GetRuneID(currentSecondaryTree, 2, 2);

                if (ThirdRuneSelectedDetector(2))
                {
                    SetSecondaryRune(runeId, 2);
                }
                else
                {
                    SetSecondaryRune(runeId, 2);
                    ResetSecondaryRuneSelection(lastRowSelected);
                }

                secondaryTreeRow2CheckBox.Checked = true;
            }

            secondaryTreeRowTwoSelection.Location = new Point(secondaryRunesTier2PictureBox3.Location.X, secondaryRunesTier2PictureBox3.Location.Y);
            secondaryTreeRowTwoSelection.Size = new Size(secondaryRunesTier2PictureBox3.Size.Width, secondaryRunesTier2PictureBox3.Size.Height);
            this.Controls.Add(secondaryTreeRowTwoSelection);

            secondaryRunesTier2PictureBox1_Click(sender, e);
            secondaryRunesTier2PictureBox2_Click(sender, e);
        }

        private void secondaryRunesTier3PictureBox1_Click(object sender, System.EventArgs e)
        {
            if (((RoundPictureBox)sender).Name != "secondaryRunesTier3PictureBox1")
            {
                return;
            }

            if (currentSecondaryTree != 0)
            {
                int runeId = GetRuneID(currentSecondaryTree, 3, 0);

                if (ThirdRuneSelectedDetector(3))
                {
                    SetSecondaryRune(runeId, 3);
                }
                else
                {
                    SetSecondaryRune(runeId, 3);
                    ResetSecondaryRuneSelection(lastRowSelected);
                }

                secondaryTreeRow3CheckBox.Checked = true;
            }

            secondaryTreeRowThreeSelection.Location = new Point(secondaryRunesTier3PictureBox1.Location.X, secondaryRunesTier3PictureBox1.Location.Y);
            secondaryTreeRowThreeSelection.Size = new Size(secondaryRunesTier3PictureBox1.Size.Width, secondaryRunesTier3PictureBox1.Size.Height);
            this.Controls.Add(secondaryTreeRowThreeSelection);

            secondaryRunesTier3PictureBox2_Click(sender, e);
            secondaryRunesTier3PictureBox3_Click(sender, e);
            secondaryRunesTier3PictureBox4_Click(sender, e);
        }

        private void secondaryRunesTier3PictureBox2_Click(object sender, System.EventArgs e)
        {
            if (((RoundPictureBox)sender).Name != "secondaryRunesTier3PictureBox2")
            {
                return;
            }

            if (currentSecondaryTree != 0)
            {
                int runeId = GetRuneID(currentSecondaryTree, 3, 1);

                if (ThirdRuneSelectedDetector(3))
                {
                    SetSecondaryRune(runeId, 3);
                }
                else
                {
                    SetSecondaryRune(runeId, 3);
                    ResetSecondaryRuneSelection(lastRowSelected);
                }

                secondaryTreeRow3CheckBox.Checked = true;
            }

            secondaryTreeRowThreeSelection.Location = new Point(secondaryRunesTier3PictureBox2.Location.X, secondaryRunesTier3PictureBox2.Location.Y);
            secondaryTreeRowThreeSelection.Size = new Size(secondaryRunesTier3PictureBox2.Size.Width, secondaryRunesTier3PictureBox2.Size.Height);
            this.Controls.Add(secondaryTreeRowThreeSelection);

            secondaryRunesTier3PictureBox1_Click(sender, e);
            secondaryRunesTier3PictureBox3_Click(sender, e);
            secondaryRunesTier3PictureBox4_Click(sender, e);
        }

        private void secondaryRunesTier3PictureBox3_Click(object sender, System.EventArgs e)
        {
            if (((RoundPictureBox)sender).Name != "secondaryRunesTier3PictureBox3")
            {
                return;
            }

            if (currentSecondaryTree != 0)
            {
                int runeId = GetRuneID(currentSecondaryTree, 3, 2);

                if (ThirdRuneSelectedDetector(3))
                {
                    SetSecondaryRune(runeId, 3);
                }
                else
                {
                    SetSecondaryRune(runeId, 3);
                    ResetSecondaryRuneSelection(lastRowSelected);
                }

                secondaryTreeRow3CheckBox.Checked = true;
            }

            secondaryTreeRowThreeSelection.Location = new Point(secondaryRunesTier3PictureBox3.Location.X, secondaryRunesTier3PictureBox3.Location.Y);
            secondaryTreeRowThreeSelection.Size = new Size(secondaryRunesTier3PictureBox3.Size.Width, secondaryRunesTier3PictureBox3.Size.Height);
            this.Controls.Add(secondaryTreeRowThreeSelection);

            secondaryRunesTier3PictureBox1_Click(sender, e);
            secondaryRunesTier3PictureBox2_Click(sender, e);
            secondaryRunesTier3PictureBox4_Click(sender, e);
        }

        private void secondaryRunesTier3PictureBox4_Click(object sender, System.EventArgs e)
        {
            if (((RoundPictureBox)sender).Name != "secondaryRunesTier3PictureBox4")
            {
                return;
            }

            if (currentSecondaryTree != 0)
            {
                int runeId = GetRuneID(currentSecondaryTree, 3, 3);

                if (ThirdRuneSelectedDetector(3))
                {
                    SetSecondaryRune(runeId, 3);
                }
                else
                {
                    SetSecondaryRune(runeId, 3);
                    ResetSecondaryRuneSelection(lastRowSelected);
                }

                secondaryTreeRow3CheckBox.Checked = true;
            }

            secondaryTreeRowThreeSelection.Location = new Point(secondaryRunesTier3PictureBox4.Location.X, secondaryRunesTier3PictureBox4.Location.Y);
            secondaryTreeRowThreeSelection.Size = new Size(secondaryRunesTier3PictureBox4.Size.Width, secondaryRunesTier3PictureBox4.Size.Height);
            this.Controls.Add(secondaryTreeRowThreeSelection);

            secondaryRunesTier3PictureBox1_Click(sender, e);
            secondaryRunesTier3PictureBox2_Click(sender, e);
            secondaryRunesTier3PictureBox3_Click(sender, e);
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

        private void ClearSecondaryRuneSelections()
        {
            this.Controls.Remove(secondaryTreeRowOneSelection);
            this.Controls.Remove(secondaryTreeRowTwoSelection);
            this.Controls.Remove(secondaryTreeRowThreeSelection);
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

        private void SetSecondaryRune(int runeId, int rowOfOrigin) //So, we can pick any rune from a row as many times as we want
                                                                   //It's when we have 2 runes selected in different rows, and then a 3rd is selected from a different row
                                                                   //We need to deselect the last selected rune from the UI and select the new one
        {
            if (secondaryRunes.ContainsKey(rowOfOrigin))
            {
                secondaryRunes.Remove(rowOfOrigin);
                secondaryRunes.Add(rowOfOrigin, runeId);
            }
            else if (secondaryRunes.Count == 2 && secondaryRunes.ContainsKey(rowOfOrigin) == false)
            {
                secondaryRunes.Remove(lastRowSelected);
                secondaryRunes.Add(rowOfOrigin, runeId);
            }
            else
            {
                secondaryRunes.Add(rowOfOrigin, runeId);
            }

            if (secondaryRunes.Count == 2)
            {
                var selectedRunes = secondaryRunes.Values.ToArray();
                runePage.selectedPerkIds[4] = selectedRunes[0];
                runePage.selectedPerkIds[5] = selectedRunes[1];
            }
        }

        private bool ThirdRuneSelectedDetector(int row)
        {
            if (rows.Count < 2 && rows.Contains(row) == false)
            {
                rows.Enqueue(row);
                return true;
            }
            else if (rows.Count < 2 && rows.Contains(row) == true)
            {
                return true;
            }

            if (rows.Count == 2 && rows.Contains(row) == false)
            {
                lastRowSelected = rows.Peek();
                rows.Dequeue();
                rows.Enqueue(row);
                return false;
            }
            else if (rows.Count == 2 && rows.Contains(row) == true)
            {
                return true;
            }

            return false;
        }

        private void ResetSecondaryRuneSelection(int row)
        {
            switch (row)
            {
                case 1:
                    this.Controls.Remove(secondaryTreeRowOneSelection);
                    secondaryTreeRow1CheckBox.Checked = false;
                    break;
                case 2:
                    this.Controls.Remove(secondaryTreeRowTwoSelection);
                    secondaryTreeRow2CheckBox.Checked = false;
                    break;
                case 3:
                    this.Controls.Remove(secondaryTreeRowThreeSelection);
                    secondaryTreeRow3CheckBox.Checked = false;
                    break;
            }
        }
        #endregion

        #region Statmods
        private void statModOffenseAdaptiveForcePictureBox_Click(object sender, System.EventArgs e)
        {
            if (((RoundPictureBox)sender).Name != "statModOffenseAdaptiveForcePictureBox")
            {
                return;
            }

            statModOffenseSelection.Location = new Point(statModOffenseAdaptiveForcePictureBox.Location.X, statModOffenseAdaptiveForcePictureBox.Location.Y);
            statModOffenseSelection.Size = new Size(statModOffenseAdaptiveForcePictureBox.Size.Width, statModOffenseAdaptiveForcePictureBox.Size.Height);
            this.Controls.Add(statModOffenseSelection);

            statModOffenseAttackSpeedPictureBox_Click(sender, e);
            statModOffenseCDRPictureBox_Click(sender, e);
        }

        private void statModOffenseAttackSpeedPictureBox_Click(object sender, System.EventArgs e)
        {
            if (((RoundPictureBox)sender).Name != "statModOffenseAttackSpeedPictureBox")
            {
                return;
            }

            statModOffenseSelection.Location = new Point(statModOffenseAttackSpeedPictureBox.Location.X, statModOffenseAttackSpeedPictureBox.Location.Y);
            statModOffenseSelection.Size = new Size(statModOffenseAttackSpeedPictureBox.Size.Width, statModOffenseAttackSpeedPictureBox.Size.Height);
            this.Controls.Add(statModOffenseSelection);

            statModOffenseAdaptiveForcePictureBox_Click(sender, e);
            statModOffenseCDRPictureBox_Click(sender, e);
        }

        private void statModOffenseCDRPictureBox_Click(object sender, System.EventArgs e)
        {
            if (((RoundPictureBox)sender).Name != "statModOffenseCDRPictureBox")
            {
                return;
            }

            statModOffenseSelection.Location = new Point(statModOffenseCDRPictureBox.Location.X, statModOffenseCDRPictureBox.Location.Y);
            statModOffenseSelection.Size = new Size(statModOffenseCDRPictureBox.Size.Width, statModOffenseCDRPictureBox.Size.Height);
            this.Controls.Add(statModOffenseSelection);

            statModOffenseAdaptiveForcePictureBox_Click(sender, e);
            statModOffenseAttackSpeedPictureBox_Click(sender, e);
        }

        private void statModFlexAdaptiveForcePictureBox_Click(object sender, System.EventArgs e)
        {
            if (((RoundPictureBox)sender).Name != "statModFlexAdaptiveForcePictureBox")
            {
                return;
            }

            statModFlexSelection.Location = new Point(statModFlexAdaptiveForcePictureBox.Location.X, statModFlexAdaptiveForcePictureBox.Location.Y);
            statModFlexSelection.Size = new Size(statModFlexAdaptiveForcePictureBox.Size.Width, statModFlexAdaptiveForcePictureBox.Size.Height);
            this.Controls.Add(statModFlexSelection);

            statModFlexArmorPictureBox_Click(sender, e);
            statModFlexMagicResistPictureBox_Click(sender, e);
        }

        private void statModFlexArmorPictureBox_Click(object sender, System.EventArgs e)
        {
            if (((RoundPictureBox)sender).Name != "statModFlexArmorPictureBox")
            {
                return;
            }

            statModFlexSelection.Location = new Point(statModFlexArmorPictureBox.Location.X, statModFlexArmorPictureBox.Location.Y);
            statModFlexSelection.Size = new Size(statModFlexArmorPictureBox.Size.Width, statModFlexArmorPictureBox.Size.Height);
            this.Controls.Add(statModFlexSelection);

            statModFlexAdaptiveForcePictureBox_Click(sender, e);
            statModFlexMagicResistPictureBox_Click(sender, e);
        }

        private void statModFlexMagicResistPictureBox_Click(object sender, System.EventArgs e)
        {
            if (((RoundPictureBox)sender).Name != "statModFlexMagicResistPictureBox")
            {
                return;
            }

            statModFlexSelection.Location = new Point(statModFlexMagicResistPictureBox.Location.X, statModFlexMagicResistPictureBox.Location.Y);
            statModFlexSelection.Size = new Size(statModFlexMagicResistPictureBox.Size.Width, statModFlexMagicResistPictureBox.Size.Height);
            this.Controls.Add(statModFlexSelection);

            statModFlexAdaptiveForcePictureBox_Click(sender, e);
            statModFlexArmorPictureBox_Click(sender, e);
        }

        private void statModDefenseHealthPictureBox_Click(object sender, System.EventArgs e)
        {
            if (((RoundPictureBox)sender).Name != "statModDefenseHealthPictureBox")
            {
                return;
            }

            statModDefenseSelection.Location = new Point(statModDefenseHealthPictureBox.Location.X, statModDefenseHealthPictureBox.Location.Y);
            statModDefenseSelection.Size = new Size(statModDefenseHealthPictureBox.Size.Width, statModDefenseHealthPictureBox.Size.Height);
            this.Controls.Add(statModDefenseSelection);

            statModDefenseArmorPictureBox_Click(sender, e);
            statModDefenseMagicResistPictureBox_Click(sender, e);
        }

        private void statModDefenseArmorPictureBox_Click(object sender, System.EventArgs e)
        {
            if (((RoundPictureBox)sender).Name != "statModDefenseArmorPictureBox")
            {
                return;
            }

            statModDefenseSelection.Location = new Point(statModDefenseArmorPictureBox.Location.X, statModDefenseArmorPictureBox.Location.Y);
            statModDefenseSelection.Size = new Size(statModDefenseArmorPictureBox.Size.Width, statModDefenseArmorPictureBox.Size.Height);
            this.Controls.Add(statModDefenseSelection);

            statModDefenseHealthPictureBox_Click(sender, e);
            statModDefenseMagicResistPictureBox_Click(sender, e);
        }

        private void statModDefenseMagicResistPictureBox_Click(object sender, System.EventArgs e)
        {
            if (((RoundPictureBox)sender).Name != "statModDefenseMagicResistPictureBox")
            {
                return;
            }

            statModDefenseSelection.Location = new Point(statModDefenseMagicResistPictureBox.Location.X, statModDefenseMagicResistPictureBox.Location.Y);
            statModDefenseSelection.Size = new Size(statModDefenseMagicResistPictureBox.Size.Width, statModDefenseMagicResistPictureBox.Size.Height);
            this.Controls.Add(statModDefenseSelection);

            statModDefenseHealthPictureBox_Click(sender, e);
            statModDefenseArmorPictureBox_Click(sender, e);
        }
        #endregion

        #region Helper Methods
        private int GetRuneID(int currentTree, int slot, int rune)
        {
            int id = 0;

            switch (currentTree)
            {
                case 8000: //Pricision
                    id = allRuneTrees[2].slots[slot].runes[rune].id;
                    break;
                case 8100: //Domination
                    id = allRuneTrees[0].slots[slot].runes[rune].id;
                    break;
                case 8200: //Sorcery
                    id = allRuneTrees[4].slots[slot].runes[rune].id;
                    break;
                case 8400: //Resolve
                    id = allRuneTrees[2].slots[slot].runes[rune].id;
                    break;
                case 8300: //Inspiration
                    id = allRuneTrees[3].slots[slot].runes[rune].id;
                    break;
            }

            return id;
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
        #endregion

        #region Notes
        //If we have a queue of rows, then our first choice will always be at the front
        //When a 3rd rune is requested we keep the value of the first thing in the queue somewhere safe
        //We then remove it from the queue and add the 3rd rune to the rows queue and the runes queue
        //From here maybe make a method (with a switch statement) that will look at that value we saved
        //and based off that value we can then clear the proper row of any selection
        #endregion
    }
}
