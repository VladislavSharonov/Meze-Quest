using UnityEngine;

namespace DefaultNamespace
{
    public class SaveSystem
    {
        public static void Save()
        {
            PlayerPrefs.SetFloat(nameof(CoinsSystem.Balance), CoinsSystem.Balance);
            PlayerPrefs.SetFloat(nameof(Abilities.ShowMapCount), Abilities.ShowMapCount);
        }

        public static void LoadSave()
        {
            CoinsSystem.AddCoin(
                (int)PlayerPrefs.GetFloat(nameof(CoinsSystem.Balance), 
                CoinsSystem.Balance));
            
            // Abilities
            Abilities.ShowMapCount = (int)PlayerPrefs.GetFloat(
                nameof(Abilities.ShowMapCount), 
                Abilities.ShowMapCount);
        }
    }
}