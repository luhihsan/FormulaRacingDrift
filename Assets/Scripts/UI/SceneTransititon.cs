using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransititon : MonoBehaviour
{
    public void MoveTo(string tujuan)
    {
        SceneManager.LoadScene(tujuan);
    }

}
