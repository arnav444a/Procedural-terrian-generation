using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIScript : MonoBehaviour
{
    public Animator fadeInOutAni;
    public TerrainGen terrainGen;
    public Slider offsetX, offsetY, resolution;
    float startTime;
    private void Update()
    {
        if(Time.time - startTime >= 0.05f)
        {
            startTime = Time.time;
            terrainGen.offsetX = offsetX.value;
            terrainGen.offsetY = offsetY.value;
            terrainGen.resolution = resolution.value;
        }
    }
    public void LoadNewSeed()
    {
        AsyncOperation loadScene =  SceneManager.LoadSceneAsync(0);
        loadScene.allowSceneActivation = false;
        fadeInOutAni.SetTrigger("fadeOut");
    }
    public IEnumerator waitBeforeReload(AsyncOperation loadScene)
    {
        yield return new WaitForSeconds(0.7f);
        loadScene.allowSceneActivation = true;
    }
}
