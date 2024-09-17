using MelonLoader;
using BTD_Mod_Helper;
using BloonConquest;
using BTD_Mod_Helper.Extensions;

[assembly: MelonInfo(typeof(BloonConquest.BloonConquest), ModHelperData.Name, ModHelperData.Version, ModHelperData.Author)]
[assembly: MelonGame("Ninja Kiwi", "BloonsTD6")]

namespace BloonConquest;

public class BloonConquest : BloonsTD6Mod
{
    public static string ModTitle = "Bloon Conquest RPG";
    public static string ModInitials = "BC-RPG";
    public static string PlayerName = "";

    public static BloonConquest instance;

    public override void OnApplicationStart()
    {
        instance = this;
        ModHelper.Msg<BloonConquest>(ModTitle + " Loaded");
        //ModHelper.Msg<BloonConquest>(ModInitials + " Found Username: "+ PlayerName);
    }

    public void SetName(string name)
    {
        PlayerName = name;
        ModHelper.Msg<BloonConquest>(ModInitials + " Found Username: " + PlayerName);
    }
    public override void OnMainMenu()
    {
        SetName(BTD_Mod_Helper.Api.Helpers.Instances.Game.GetPlayerLiNKAccount().DisplayName);
        base.OnMainMenu();
    }
}