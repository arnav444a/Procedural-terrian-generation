using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{

    public Animator fadeInOutAni;
    public TerrainGen terrainGen;
    public Slider offsetX, offsetY, resolution;
    float startTime;
    private void Update()
    {
        if (Time.time - startTime >= 0.1f)
        {
            startTime = Time.time;
            terrainGen.offsetX = offsetX.value;
            terrainGen.offsetY = offsetY.value;
            terrainGen.resolution = resolution.value;
        }
    }
    public void LoadNewSeed()
    {
        AsyncOperation loadScene = SceneManager.LoadSceneAsync(0);
        loadScene.allowSceneActivation = false;
        fadeInOutAni.SetTrigger("fadeOut");
        StartCoroutine(waitBeforeReload(loadScene));
    }
    public IEnumerator waitBeforeReload(AsyncOperation loadScene)
    {
        yield return new WaitForSeconds(0.7f);
        loadScene.allowSceneActivation = true;
    }
}
