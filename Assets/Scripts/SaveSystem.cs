using UnityEngine;

public static class SaveSystem
{
    public static void Save()
    {
        PlayerPrefs.SetInt(nameof(CoinsSystem.Balance), (int)CoinsSystem.Balance);
        PlayerPrefs.SetInt(nameof(Abilities.ShowMapCount), Abilities.ShowMapCount);
    }

    public static void LoadSave()
    {
        CoinsSystem.AddCoin(
            PlayerPrefs.GetInt(nameof(CoinsSystem.Balance), 
            0));
        
        // Abilities
        Abilities.ShowMapCount = PlayerPrefs.GetInt(
            nameof(Abilities.ShowMapCount), 
            0);
    }
}