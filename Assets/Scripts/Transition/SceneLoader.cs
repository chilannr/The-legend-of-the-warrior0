using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.SceneManagement;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class SceneLoader : MonoBehaviour
{
    [Header("事件监听")]
    public SceneLoadEventSO loadEventSO;
    public GameSceneSO firstLoadScene;

    [SerializeField]private GameSceneSO currentLoadedScene;
    private GameSceneSO sceneToLoad;
    private Vector3 positionToGo;
    private bool fadeScreen;
    public float fadeDuration;
    //public UnityEngine.Transform transform;

    private void Awake()
    {
        //transform = GetComponent<UnityEngine.Transform>();
        //Addressables.LoadSceneAsync(firstLoadScene.sceneReference, LoadSceneMode.Additive);
        currentLoadedScene = firstLoadScene;
        currentLoadedScene.sceneReference.LoadSceneAsync(LoadSceneMode.Additive, true);

    }
    private void OnEnable()
    {
        loadEventSO.LoadRequestEvent += OnLoadRequestEvent;
       
    }
    private void OnDisable()
    {
        loadEventSO.LoadRequestEvent -= OnLoadRequestEvent;
    }

    private void OnLoadRequestEvent(GameSceneSO locationToLoad, Vector3 posToGo, bool fadeScene)
    {
        sceneToLoad = locationToLoad;
        positionToGo = posToGo;
        this.fadeScreen = fadeScene;
        //Debug.Log(positionToGo);

        StartCoroutine(UnLoadPreviousScene());
    }
    IEnumerator UnLoadPreviousScene()
    {
        if (fadeScreen)
        {
            //TODO:渐入渐出
        }
        yield return new WaitForSeconds(fadeDuration);
        if (currentLoadedScene != null)
        {
           
            yield return currentLoadedScene.sceneReference.UnLoadScene();
        }
        LoadNewScene(); 
        // 将目标位置应用于玩家或需要传递的对象


    }
    private void LoadNewScene()
    {
        sceneToLoad.sceneReference.LoadSceneAsync(LoadSceneMode.Additive, true);
        currentLoadedScene = sceneToLoad;
    }
   
}
