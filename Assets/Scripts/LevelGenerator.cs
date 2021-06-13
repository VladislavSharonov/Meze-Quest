using System.Collections.Generic;
using UnityEngine;
using Image = UnityEngine.UI.Image;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] private Image mapPreview = null;
    
    [SerializeField] private GameObject character;
    [SerializeField] private GameObject wall;
    [SerializeField] private GameObject trap;
    [SerializeField] private GameObject coin;
    [SerializeField] private GameObject winZone;
    [SerializeField] private GameObject checkpoint;
    [SerializeField] private GameObject key;
    [SerializeField] private GameObject door;
    [SerializeField] private GameObject finishLine;

    public static string[] Map { get; set; }
    public static Sprite MapPreview { get; set; }

    private Dictionary<char, GameObject> legend = new Dictionary<char, GameObject>();

    private void MakeLegend()
    {
        legend['-'] = null;
        legend['#'] = wall;
        legend['*'] = character;
        legend['!'] = winZone;
        legend['$'] = coin;
        legend['^'] = trap;
        legend['['] = key;
        legend[']'] = door;
        legend['&'] = checkpoint;
        legend['~'] = finishLine;
        mapPreview.sprite = MapPreview;
    }

    // Start is called before the first frame update
    private void Start()
    {
        MakeLegend();
        
        var i = 0;
        foreach (var row in Map)
        {
            var j = 0;
            foreach (var c in row)
            {
                if (!(legend[c] is null)) 
                    Instantiate(legend[c], new Vector3(i, 0, j), Quaternion.identity);
                j++;
            }

            i++;
        }
    }
}
