using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    [SerializeField] private Text moneyBar;
    [SerializeField] private Text killedBar;

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    private void FixedUpdate()
    {
        killedBar.text = "killed russians: " + GoodsHolder.KilledSepars;
    }
}
