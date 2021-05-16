using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] private GameObject character;
    [SerializeField] private GameObject wall;
    [SerializeField] private GameObject trap;
    [SerializeField] private GameObject coin;
    [SerializeField] private GameObject winZone;
    [SerializeField] private GameObject checkpoint;
    [SerializeField] private GameObject key;
    [SerializeField] private GameObject door;
    
    private string[] Lvl =
    {
        "-------!---------",
        "#######-#########",
        "#-----#---------#",
        "#####-#-#########",
        "#-------#---#--[#",
        "#-###-###-#-#-###",
        "#---#-#--&#-#---#",
        "###-#-#-###-#-#-#",
        "#---#^#---#---#-#",
        "#-###-###-#####-#",
        "#---#---#-#$--#-#",
        "###-#-#-#-###-#-#",
        "#-#-#-#-#---#-#-#",
        "#-#-###-###-#-#-#",
        "#-#---------]-#-#",
        "#-###-#########-#",
        "#-------#*------#",
        "#################",
    };

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
    }

    // Start is called before the first frame update
    void Start()
    {
        MakeLegend();
        
        var i = 0;
        foreach (var row in Lvl)
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
