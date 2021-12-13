using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMapManagement : MonoBehaviour
{
    public GameObject MiniMap;
    bool OnOffMiniMap;

    // Start is called before the first frame update
    void Start()
    {
        OnOffMiniMap = false;
        MiniMap.SetActive(false);        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.M) && !OnOffMiniMap)
        {
            OnOffMiniMap = true;
            MiniMap.SetActive(true);
        }

        else if(Input.GetKeyDown(KeyCode.M) && OnOffMiniMap)
        {
            OnOffMiniMap = false;
            MiniMap.SetActive(false);
        }
    }
}
