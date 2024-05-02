using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;
using UnityEngine;

public class MakeImageButtons : MonoBehaviour
{
    GameObject image;
    GameObject[] array;
    public GameObject ButtonPrefab;
    GameObject newButton;

    // Start is called before the first frame update
    void Start()
    {
        array = image.GetComponent<PrefabArray>().images;
        
        for (int i = 0; i < array.Length; i++) 
        {
            newButton = Instantiate( ButtonPrefab );

            newButton.GetComponentInChildren<TextMeshProUGUI>().text = array[i].name;

        }
        
    }

}
