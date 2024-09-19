using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Models.TowerSets;
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
    internal class TheAdventurer : ModTower
    {
        

        public override string BaseTower => TowerType.DartMonkey;
        public override int Cost => 0;
        public override string DisplayName => "BCADN";
        public override TowerSet TowerSet => TowerSet.Primary;
        public override int TopPathUpgrades => 0;
        public override int MiddlePathUpgrades => 0;
        public override int BottomPathUpgrades => 0;
        public override int ShopTowerCount => 1;

        public override void ModifyBaseTowerModel(TowerModel towerModel)
        {
            towerModel.range = 10;
            var attackModel = towerModel.GetAttackModel();
            attackModel.range = 10;
        }
    }
}
