using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Unity.Achievements.List;
using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace BloonConquest.Hero
{
    internal class TheAdventurer : ModHero
    {
        

        public override string BaseTower => TowerType.DartMonkey;
        public override int Cost => 0;
        public override string DisplayName => "ERROR FTGU";
        public override string Title => "The Adventurer";
        public override string Level1Description => "A Newbie Adventurer. Gains no special benefits.";
        public override string Description => "Use 'Gear' and 'Talents' to gain powerful meta upgrades!";
        public override string NameStyle => TowerType.StrikerJones;
        public override string BackgroundStyle => TowerType.Geraldo;
        public override string GlowStyle => TowerType.AdmiralBrickell;
        public override int MaxLevel => 1;
        public override float XpRatio => 1;

        [Obsolete]
        public override int Abilities => 0;
        public override void ModifyBaseTowerModel(TowerModel towerModel)
        {
            towerModel.range = 10;
            var attackModel = towerModel.GetAttackModel();
            attackModel.range = 10;
        }
    }
}
