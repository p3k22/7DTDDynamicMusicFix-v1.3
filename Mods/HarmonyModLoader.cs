namespace P3ks_Craftable_Compass.Mods
{
   using HarmonyLib;

   using System.Linq;

   public class HarmonyModLoader : IModApi
   {
      public void InitMod(Mod _modInstance)
      {
         var patch = new Harmony("P3ks Dynamic Music");
         patch.PatchAll();
      }
   }
}