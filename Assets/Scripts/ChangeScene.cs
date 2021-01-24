using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public void ButtonChangeScene(string t_sceneName)
    {
        SceneManager.LoadScene(t_sceneName);
    }
}
