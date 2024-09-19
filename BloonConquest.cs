using MelonLoader;
using BTD_Mod_Helper;
using BloonConquest;
using BTD_Mod_Helper.Extensions;
using Il2CppNinjaKiwi.Common;
using Il2CppAssets.Scripts.Simulation.Towers;
using Il2CppAssets.Scripts.Models.Towers;
using BloonConquest.Hero;
using BloonConquest.Hero.Stats;
using Il2CppAssets.Scripts.Simulation.Objects;
using Il2CppAssets.Scripts.Models;
using System;

[assembly: MelonInfo(typeof(BloonConquest.BloonConquest), ModHelperData.Name, ModHelperData.Version, ModHelperData.RepoOwner)]
[assembly: MelonGame("Ninja Kiwi", "BloonsTD6")]

namespace BloonConquest;

public class BloonConquest : BloonsTD6Mod
{
    public static string ModTitle = "Bloon Conquest RPG";
    public static string ModInitials = "BC-RPG";
    public static string PlayerName = "";
    public static bool debugMode = true;
    public static Tower adventurer;
    private float curGoal;

    public static BloonConquest instance;

    public static void LOG(string str)
    {
        ModHelper.Msg<BloonConquest>(str);
    }
    public static void DEBUG(string str)
    {
        ModHelper.Warning<BloonConquest>("DEBUG: " + str);
    }
    public static void WARN(string str)
    {
        ModHelper.Warning<BloonConquest>(str);
    }
    public static void ERROR(string str)
    {
        ModHelper.Error<BloonConquest>(str);
    }

    public override void OnApplicationStart()
    {
        instance = this;
        LOG(ModTitle + " Loaded");
        if (debugMode) { DEBUG("Debug Mode Enabled!"); }
    }
    public override void OnMainMenu()
    {
        PlayerName = BTD_Mod_Helper.Api.Helpers.Instances.Game.GetPlayerLiNKAccount().DisplayName;
        LocalizationManager LocMan = BTD_Mod_Helper.Api.Helpers.Instances.Game.GetLocalizationManager();
        LocMan.defaultTable["BloonConquest-TheAdventurer"] = PlayerName;
        base.OnMainMenu();
    }
    public override void OnTowerCreated(Tower tower, Entity target, Model modelToUse)
    {
        TowerModel tm = tower.towerModel;
        if (tm.name.Contains("TheAdventurer"))
        {
            StatHandler.tower = tm;
            adventurer = tower;
            if (debugMode) { DEBUG("Placed Adventurer."); }
            StatHandler.CreateButton();
            StatHandler.SetPoints(5);
            curGoal = 100;
        }
        base.OnTowerCreated(tower, target, modelToUse);
    }
    public override void OnRoundEnd()
    {
        while (curGoal < adventurer.damageDealt)
        {
            StatHandler.AddPoints(1);
            curGoal = MathF.Floor(curGoal * 2.5f);
        }
        base.OnRoundEnd();
    }
}