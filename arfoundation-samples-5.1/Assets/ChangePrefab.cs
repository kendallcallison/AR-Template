using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangePrefab : MonoBehaviour
{
    public GameObject[] prefabs;


    public void ChangeFacePrefab(int prefabIndex)
    {

        SceneManager.LoadScene(prefabIndex);
        
    }
}
