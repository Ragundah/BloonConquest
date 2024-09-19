using BTD_Mod_Helper.Api;
using BTD_Mod_Helper.Api.Components;
using BTD_Mod_Helper.Api.Enums;
using BTD_Mod_Helper.Api.Helpers;
using BTD_Mod_Helper.Extensions;
using Il2Cpp;
using Il2CppAssets.Scripts;
using Il2CppAssets.Scripts.Data.Global;
using Il2CppAssets.Scripts.Data.Knowledge.Effects;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Simulation.Towers;
using Il2CppAssets.Scripts.Unity.Achievements.List;
using Il2CppAssets.Scripts.Unity.UI.InGameMenu.StoreMenu;
using Il2CppNinjaKiwi.Common.ResourceUtils;
using Il2CppNinjaKiwi.LiNK.AuthenticationProviders;
using Il2CppTMPro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace BloonConquest.Hero.Stats
{
    internal static class StatHandler
    {
        private static int points = 0;
        public static TowerModel tower;
        static ModHelperText pointsText1;

        private static void UpdateAllTexts()
        {
            try { pointsText1.GetComponent<NK_TextMeshProUGUI>().text = "Stat Points: " + points; } catch { }
        }

        public static void AddPoints(int point)
        {
            points += point;
            if (BloonConquest.debugMode) { BloonConquest.DEBUG("Points Added: " + point); BloonConquest.DEBUG("New Value: " + points); }
            UpdateAllTexts();
        }
        public static void RemovePoints(int point)
        {
            points -= point;
            if (BloonConquest.debugMode) { BloonConquest.DEBUG("Points Removed: " + point); BloonConquest.DEBUG("New Value: " + points); }
            UpdateAllTexts();
        }
        public static void SetPoints(int point)
        {
            points = point;
            if (BloonConquest.debugMode) { BloonConquest.DEBUG("Points Set To: " + point); BloonConquest.DEBUG("New Value: " + points); }
            UpdateAllTexts();
        }
        public static int GetPoints() { return points; }

        public static void CreateButton()
        {
            GameObject parent = GameObject.Find("MainHudRightAlign(Clone)");
            ModHelperPanel panel = parent.gameObject.AddModHelperPanel(new Info("BloonConquestPanel", -200, -550, 380, 700), VanillaSprites.BrownPanel, null, 10, 10);
            panel.transform.localPosition = new Vector3(-200, -350, 0);
            panel.AddComponent<VerticalLayoutGroup>();
            var rect = new RectOffset();
            rect.bottom = 10;
            rect.left = 10;
            rect.right = 10;
            rect.top = 10;
            panel.GetComponent<VerticalLayoutGroup>().padding = rect;
            panel.GetComponent<VerticalLayoutGroup>().spacing = 10;
            ModHelperText PointsText = panel.AddText(new Info("BloonConquestPanelOpenStatButtonText", 0, 0, 300, 120), "Current Points: 5", 32, TextAlignmentOptions.Center);
            ModHelperButton StrButton = panel.AddButton(new Info("BloonConquestPanelOpenStatButton", 0, 0, 300, 120), VanillaSprites.PanelFrame, new Action(() => ApplyUpgrade(1, 1)));
            ModHelperText StrButtonText = StrButton.AddText(new Info("BloonConquestPanelOpenStatButtonText", 0, 0, 280, 100), "Upgrade Str +1", 32, TextAlignmentOptions.Center);
            ModHelperButton DexButton = panel.AddButton(new Info("BloonConquestPanelOpenStatButton", 0, 0, 300, 120), VanillaSprites.PanelFrame, new Action(() => ApplyUpgrade(2, 1.125f)));
            ModHelperText DexButtonText = DexButton.AddText(new Info("BloonConquestPanelOpenStatButtonText", 0, 0, 280, 100), "Upgrade Dex +1", 32, TextAlignmentOptions.Center);
            ModHelperButton IntButton = panel.AddButton(new Info("BloonConquestPanelOpenStatButton", 0, 0, 300, 120), VanillaSprites.PanelFrame, new Action(() => ApplyUpgrade(0, 1.2f)));
            ModHelperText IntButtonText = IntButton.AddText(new Info("BloonConquestPanelOpenStatButtonText", 0, 0, 280, 100), "Upgrade Int +1", 32, TextAlignmentOptions.Center);
            pointsText1 = PointsText;
        }

        public static void ApplyUpgrade(int upgradeType, float mod)
        {
            var tower = BloonConquest.adventurer;
            if (points <= 0) { BloonConquest.DEBUG("0 Points, Returning!"); return; }
            var newModel = tower.rootModel.Duplicate().Cast<TowerModel>();
            switch (upgradeType)
            {
                case 0:
                    {
                        newModel.range *= mod;
                        newModel.GetAttackModel().range *= mod;
                        break;
                    }
                case 1:
                    {
                        newModel.GetWeapon().projectile.GetDamageModel().damage += mod;
                        break;
                    }
                case 2:
                    {
                        newModel.GetWeapon().rate *= mod;
                        break;
                    }
                default: { BloonConquest.ERROR("UNABLE TO FIND UPGRADE TYPE: " + upgradeType); return; }
            }
            tower.UpdateRootModel(newModel);
            points -= 1;
            UpdateAllTexts();
        }

        public static void DestroyAll()
        {

        }
    }
}
