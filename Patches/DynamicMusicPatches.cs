namespace P3ks_DynamicMusic.Patches
{
   using DynamicMusic;

   using HarmonyLib;

   using System.Linq;

   using UnityEngine;

   [HarmonyPatch(typeof(LayeredSection<FixedLayerMixer>), "FillStream")]
   public static class FixedLayerMixerPatch
   {
      [HarmonyPrefix]
      public static bool FillStreamPrefix(LayeredSection<FixedLayerMixer> __instance, float[] data)
      {
         if (data == null)
         {
            Debug.LogWarning("FillStream: data is null");
            return false;
         }

         using (LayeredSection<FixedLayerMixer>.s_FillStreamMarker.Auto()) // Use static access
         {
            for (var i = 0; i < data.Length; i++)
            {
               if (i >= data.Length)
               {
                  Debug.LogWarning("FillStream: data out of bounds.");
                  break;
               }

               data[i] = __instance.Mixer[__instance.cursor++];
               // __instance.cursor %= Content.SamplesFor[__instance.Sect] * 2;
            }
         }

         return false; // Prevent original method execution
      }
   }

   [HarmonyPatch(typeof(LayeredSection<BloodmoonLayerMixer>), "FillStream")]
   public static class BloodmoonLayerMixerPatch
   {
      [HarmonyPrefix]
      public static bool FillStreamPrefix(LayeredSection<BloodmoonLayerMixer> __instance, float[] data)
      {
         if (data == null)
         {
            Debug.LogWarning("FillStream: data is null");
            return false;
         }

         using (LayeredSection<BloodmoonLayerMixer>.s_FillStreamMarker.Auto()) // Use static access
         {
            for (var i = 0; i < data.Length; i++)
            {
               if (i >= data.Length)
               {
                  Debug.LogWarning("FillStream: data out of bounds.");
                  break;
               }

               data[i] = __instance.Mixer[__instance.cursor++];
               // __instance.cursor %= Content.SamplesFor[__instance.Sect] * 2;
            }
         }

         return false; // Prevent original method execution
      }
   }

   [HarmonyPatch(typeof(LayeredSection<CombatLayerMixer>), "FillStream")]
   public static class CombatLayerMixerPatch
   {
      [HarmonyPrefix]
      public static bool FillStreamPrefix(LayeredSection<CombatLayerMixer> __instance, float[] data)
      {
         if (data == null)
         {
            Debug.LogWarning("FillStream: data is null");
            return false;
         }

         using (LayeredSection<CombatLayerMixer>.s_FillStreamMarker.Auto()) // Use static access
         {
            for (var i = 0; i < data.Length; i++)
            {
               if (i >= data.Length)
               {
                  Debug.LogWarning("FillStream: data out of bounds.");
                  break;
               }

               data[i] = __instance.Mixer[__instance.cursor++];
               // __instance.cursor %= Content.SamplesFor[__instance.Sect] * 2;
            }
         }

         return false; // Prevent original method execution
      }
   }
}