using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelectionMenuGenerator : MonoBehaviour
{
    [SerializeField] private Image previewBox = null;
    [SerializeField] private TextMeshProUGUI desctiption = null;
    [SerializeField] private LevelSelectionItem levelSelectionItem = null;
    
    public void ChangeItem(LevelSelectionItem item)
    {
        if (item is null)
        {
            Debug.LogException(new Exception("Level selection item is not set"));
            return;
        }
        
        if (levelSelectionItem != null)
            levelSelectionItem.Deactivate();
        levelSelectionItem = item;
        levelSelectionItem.Activate();
        
        previewBox.sprite = levelSelectionItem.Preview;
        desctiption.text = levelSelectionItem.Description;
        LevelGenerator.MapPreview = levelSelectionItem.Preview;
        LevelGenerator.Map = Maps.GetByNumber(levelSelectionItem.LevelNumber);
    }

    private void Awake()
    {
        if (levelSelectionItem is null)
        {
            Debug.LogError("Level button has no LevelSelectionItem component");
            return;
        }

        ChangeItem(levelSelectionItem);
    }
}
