using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Instruments : MonoBehaviour
{
    public static void ConnectPosRot(GameObject gameObject1, GameObject gameObject2)
    {
        gameObject1.transform.position = gameObject2.transform.position;
        gameObject1.transform.rotation = gameObject2.transform.rotation;
    }
    public static void SceneLoad(string nameScene)
    {
        SceneManager.LoadScene(nameScene);
    }
    
}
