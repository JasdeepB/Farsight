using System;
using System.Drawing;
using System.IO;

namespace Farsight
{
    class Images
    {
        private static string workingDirectory = Environment.CurrentDirectory;
        private static string projectDirectory = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;

        public Images()
        {

        }

        public static Image ChampionImage(string championName)
        {
            if (championName == "Wukong")
            {
                championName = "MonkeyKing";
            }

            return Image.FromFile(projectDirectory + @"\Farsight\Images\img\champion\" + championName + ".png");
        }

        public static Image RuneTree(int rune)
        {
            string ending = "";

            switch (rune)
            {
                case 8100:
                    ending = "7200_Domination";
                    break;
                case 8000:
                    ending = "7201_Precision";
                    break;
                case 8200:
                    ending = "7202_Sorcery";
                    break;
                case 8300:
                    ending = "7203_Whimsy";
                    break;
                case 8400:
                    ending = "7204_Resolve";
                    break;
            }

            return Image.FromFile(projectDirectory + @"\Farsight\Images\perk-images\Styles\" + ending + ".png");
        }

        public static Image SecondaryRuneTree(int rune)
        {
            string ending = "";

            switch (rune)
            {
                case 8100:
                    ending = "7200_Domination";
                    break;
                case 8000:
                    ending = "7201_Precision";
                    break;
                case 8200:
                    ending = "7202_Sorcery";
                    break;
                case 8300:
                    ending = "7203_Whimsy";
                    break;
                case 8400:
                    ending = "7204_Resolve";
                    break;
            }

            return Image.FromFile(projectDirectory + @"\Farsight\Images\perk-images\Styles\" + ending + ".png");
        }

        public static Image PrecisionTree(int rune)
        {
            string path = "";

            switch (rune)
            {
                case 8005:
                    path = @"\Farsight\Images\perk-images\Styles\Precision\PressTheAttack\PressTheAttack.png";
                    break;
                case 8008:
                    path = @"\Farsight\Images\perk-images\Styles\Precision\LethalTempo\LethalTempoTemp.png";
                    break;
                case 8021:
                    path = @"\Farsight\Images\perk-images\Styles\Precision\FleetFootwork\FleetFootwork.png";
                    break;
                case 8010:
                    path = @"\Farsight\Images\perk-images\Styles\Precision\Conqueror\Conqueror.png";
                    break;
                case 9101:
                    path = @"\Farsight\Images\perk-images\Styles\Precision\Overheal.png";
                    break;
                case 9111:
                    path = @"\Farsight\Images\perk-images\Styles\Precision\Triumph.png";
                    break;
                case 8009:
                    path = @"\Farsight\Images\perk-images\Styles\Precision\PresenceOfMind\PresenceOfMind.png";
                    break;
                case 9104:
                    path = @"\Farsight\Images\perk-images\Styles\Precision\LegendAlacrity\LegendAlacrity.png";
                    break;
                case 9105:
                    path = @"\Farsight\Images\perk-images\Styles\Precision\LegendTenacity\LegendTenacity.png";
                    break;
                case 9103:
                    path = @"\Farsight\Images\perk-images\Styles\Precision\LegendBloodline\LegendBloodline.png";
                    break;
                case 8014:
                    path = @"\Farsight\Images\perk-images\Styles\Precision\CoupDeGrace\CoupDeGrace.png";
                    break;
                case 8017:
                    path = @"\Farsight\Images\perk-images\Styles\Precision\CutDown\CutDown.png";
                    break;
                case 8299:
                    path = @"\Farsight\Images\perk-images\Styles\Sorcery\LastStand\LastStand.png";
                    break;
            }

            return Image.FromFile(projectDirectory + path);
        }

        public static Image DominationTree(int rune)
        {
            string path = "";

            switch (rune)
            {
                case 8112:
                    path = @"\Farsight\Images\perk-images\Styles\Domination\Electrocute\Electrocute.png";
                    break;
                case 8124:
                    path = @"\Farsight\Images\perk-images\Styles\Domination\Predator\Predator.png";
                    break;
                case 8128:
                    path = @"\Farsight\Images\perk-images\Styles\Domination\DarkHarvest\DarkHarvest.png";
                    break;
                case 9923:
                    path = @"\Farsight\Images\perk-images\Styles\Domination\HailOfBlades\HailOfBlades.png";
                    break;
                case 8126:
                    path = @"\Farsight\Images\perk-images\Styles\Domination\CheapShot\CheapShot.png";
                    break;
                case 8139:
                    path = @"\Farsight\Images\perk-images\Styles\Domination\TasteOfBlood\GreenTerror_TasteOfBlood.png";
                    break;
                case 8143:
                    path = @"\Farsight\Images\perk-images\Styles\Domination\SuddenImpact\SuddenImpact.png";
                    break;
                case 8136:
                    path = @"\Farsight\Images\perk-images\Styles\Domination\ZombieWard\ZombieWard.png";
                    break;
                case 8120:
                    path = @"\Farsight\Images\perk-images\Styles\Domination\GhostPoro\GhostPoro.png";
                    break;
                case 8138:
                    path = @"\Farsight\Images\perk-images\Styles\Domination\EyeballCollection\EyeballCollection.png";
                    break;
                case 8135:
                    path = @"\Farsight\Images\perk-images\Styles\Domination\RavenousHunter\RavenousHunter.png";
                    break;
                case 8134:
                    path = @"\Farsight\Images\perk-images\Styles\Domination\IngeniousHunter\IngeniousHunter.png";
                    break;
                case 8105:
                    path = @"\Farsight\Images\perk-images\Styles\Domination\RelentlessHunter\RelentlessHunter.png";
                    break;
                case 8106:
                    path = @"\Farsight\Images\perk-images\Styles\Domination\UltimateHunter\UltimateHunter.png";
                    break;
            }

            return Image.FromFile(projectDirectory + path);
        }

        public static Image SorceryTree(int rune)
        {
            string path = "";

            switch (rune)
            {
                case 8214:
                    path = @"\Farsight\Images\perk-images\Styles\Sorcery\SummonAery\SummonAery.png";
                    break;
                case 8229:
                    path = @"\Farsight\Images\perk-images\Styles\Sorcery\ArcaneComet\ArcaneComet.png";
                    break;
                case 8230:
                    path = @"\Farsight\Images\perk-images\Styles\Sorcery\PhaseRush\PhaseRush.png";
                    break;
                case 8224:
                    path = @"\Farsight\Images\perk-images\Styles\Sorcery\NullifyingOrb\Pokeshield.png";
                    break;
                case 8226:
                    path = @"\Farsight\Images\perk-images\Styles\Sorcery\ManaflowBand\ManaflowBand.png";
                    break;
                case 8275:
                    path = @"\Farsight\Images\perk-images\Styles\Sorcery\NimbusCloak\6361.png";
                    break;
                case 8210:
                    path = @"\Farsight\Images\perk-images\Styles\Sorcery\Transcendence\Transcendence.png";
                    break;
                case 8234:
                    path = @"\Farsight\Images\perk-images\Styles\Sorcery\Celerity\CelerityTemp.png";
                    break;
                case 8233:
                    path = @"\Farsight\Images\perk-images\Styles\Sorcery\AbsoluteFocus\AbsoluteFocus.png";
                    break;
                case 8237:
                    path = @"\Farsight\Images\perk-images\Styles\Sorcery\Scorch\Scorch.png";
                    break;
                case 8232:
                    path = @"\Farsight\Images\perk-images\Styles\Sorcery\Waterwalking\Waterwalking.png";
                    break;
                case 8236:
                    path = @"\Farsight\Images\perk-images\Styles\Sorcery\GatheringStorm\GatheringStorm.png";
                    break;
            }

            return Image.FromFile(projectDirectory + path);
        }

        public static Image ResolveTree(int rune)
        {
            string path = "";

            switch (rune)
            {
                case 8437:
                    path = @"\Farsight\Images\perk-images\Styles\Resolve\GraspOfTheUndying\GraspOfTheUndying.png";
                    break;
                case 8439:
                    path = @"\Farsight\Images\perk-images\Styles\Resolve\VeteranAftershock\VeteranAftershock.png";
                    break;
                case 8465:
                    path = @"\Farsight\Images\perk-images\Styles\Resolve\Guardian\Guardian.png";
                    break;
                case 8446:
                    path = @"\Farsight\Images\perk-images\Styles\Resolve\Demolish\Demolish.png";
                    break;
                case 8463:
                    path = @"\Farsight\Images\perk-images\Styles\Resolve\FontOfLife\FontOfLife.png";
                    break;
                case 8401:
                    path = @"\Farsight\Images\perk-images\Styles\Resolve\MirrorShell\MirrorShell.png";
                    break;
                case 8429:
                    path = @"\Farsight\Images\perk-images\Styles\Resolve\Conditioning\Conditioning.png";
                    break;
                case 8444:
                    path = @"\Farsight\Images\perk-images\Styles\Resolve\SecondWind\SecondWind.png";
                    break;
                case 8473:
                    path = @"\Farsight\Images\perk-images\Styles\Resolve\BonePlating\BonePlating.png";
                    break;
                case 8451:
                    path = @"\Farsight\Images\perk-images\Styles\Resolve\Overgrowth\Overgrowth.png";
                    break;
                case 8453:
                    path = @"\Farsight\Images\perk-images\Styles\Resolve\Revitalize\Revitalize.png";
                    break;
                case 8242:
                    path = @"\Farsight\Images\perk-images\Styles\Sorcery\Unflinching\Unflinching.png";
                    break;
            }

            return Image.FromFile(projectDirectory + path);
        }

        public static Image InspirationTree(int rune)
        {
            string path = "";

            switch (rune)
            {
                case 8351:
                    path = @"\Farsight\Images\perk-images\Styles\Inspiration\GlacialAugment\GlacialAugment.png";
                    break;
                case 8360:
                    path = @"\Farsight\Images\perk-images\Styles\Inspiration\UnsealedSpellbook\UnsealedSpellbook.png";
                    break;
                case 8358:
                    path = @"\Farsight\Images\perk-images\Styles\Inspiration\MasterKey\MasterKey.png";
                    break;
                case 8306:
                    path = @"\Farsight\Images\perk-images\Styles\Inspiration\HextechFlashtraption\HextechFlashtraption.png";
                    break;
                case 8304:
                    path = @"\Farsight\Images\perk-images\Styles\Inspiration\MagicalFootwear\MagicalFootwear.png";
                    break;
                case 8313:
                    path = @"\Farsight\Images\perk-images\Styles\Inspiration\PerfectTiming\PerfectTiming.png";
                    break;
                case 8321:
                    path = @"\Farsight\Images\perk-images\Styles\Inspiration\FuturesMarket\FuturesMarket.png";
                    break;
                case 8316:
                    path = @"\Farsight\Images\perk-images\Styles\Inspiration\MinionDematerializer\MinionDematerializer.png";
                    break;
                case 8345:
                    path = @"\Farsight\Images\perk-images\Styles\Inspiration\BiscuitDelivery\BiscuitDelivery.png";
                    break;
                case 8347:
                    path = @"\Farsight\Images\perk-images\Styles\Inspiration\CosmicInsight\CosmicInsight.png";
                    break;
                case 8410:
                    path = @"\Farsight\Images\perk-images\Styles\Resolve\ApproachVelocity\ApproachVelocity.png";
                    break;
                case 8352:
                    path = @"\Farsight\Images\perk-images\Styles\Inspiration\TimeWarpTonic\TimeWarpTonic.png";
                    break;
            }

            return Image.FromFile(projectDirectory + path);
        }

        public static Image StatMods(string modeType)
        {
            string path = "";

            switch (modeType)
            {
                case "AdaptiveForce":
                    path = @"\Farsight\Images\perk-images\StatMods\StatModsAdaptiveForceIcon.png";
                    break;
                case "AttackSpeed":
                    path = @"\Farsight\Images\perk-images\StatMods\StatModsAttackSpeedIcon.png";
                    break;
                case "CDR":
                    path = @"\Farsight\Images\perk-images\StatMods\StatModsCDRScalingIcon.png";
                    break;
                case "Armor":
                    path = @"\Farsight\Images\perk-images\StatMods\StatModsArmorIcon.png";
                    break;
                case "MagicResist":
                    path = @"\Farsight\Images\perk-images\StatMods\StatModsMagicResIcon.png";
                    break;
                case "Health":
                    path = @"\Farsight\Images\perk-images\StatMods\StatModsHealthScalingIcon.png";
                    break;
            }

            return Image.FromFile(projectDirectory + path);
        }

        public static Image Item(int itemId)
        {

            if (itemId == 0)
            {
                return Image.FromFile(projectDirectory + @"\Farsight\Images\img\item\" + 4403 + ".png");
            }

            return Image.FromFile(projectDirectory + @"\Farsight\Images\img\item\" + itemId.ToString() + ".png");
        }

        public static Image SummonerSpell(int spellId)
        {
            string spellName = "";
            switch (spellId)
            {

                case (21):
                    spellName = "SummonerBarrier";
                    break;
                case (1):
                    spellName = "SummonerBoost";
                    break;
                case (14):
                    spellName = "SummonerDot";
                    break;
                case (3):
                    spellName = "SummonerExhaust";
                    break;
                case (4):
                    spellName = "SummonerFlash";
                    break;
                case (6):
                    spellName = "SummonerHaste";
                    break;
                case (7):
                    spellName = "SummonerHeal";
                    break;
                case (13):
                    spellName = "SummonerMana";
                    break;
                case (11):
                    spellName = "SummonerSmite";
                    break;
                case (12):
                    spellName = "SummonerTeleport";
                    break;
                case (32):
                    spellName = "SummonerSnowball";
                    break;

            }
            //SummonerBarrier = Barrier (21)
            //SummonerBoost = Cleanse (1)
            //SummonerDot = Ignite (14)
            //SummonerExhaust = Exhaust (3)
            //SummonerFlash = Flash (4)
            //SummonerHaste = Ghost (6)
            //SummonerHeal = Heal (7)
            //SummonerMana = Clarity (13)
            //SummonerSmite = Smite (11)
            //SummonerTeleport = Teleport (12)
            //SummonerSnowball = Snowball (32)

            return Image.FromFile(projectDirectory + @"\Farsight\Images\img\spell\" + spellName + ".png");
        }

        public static Image SummonerProfileIcon(int iconId)
        {
            return Image.FromFile(projectDirectory + @"\Farsight\Images\img\profileicon\" + iconId.ToString() + ".png");

        }
    }
}
