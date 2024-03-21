using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.SceneManagement;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class SceneLoader : MonoBehaviour
{
    [Header("�¼�����")]
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
            //TODO:���뽥��
        }
        yield return new WaitForSeconds(fadeDuration);
        if (currentLoadedScene != null)
        {
           
            yield return currentLoadedScene.sceneReference.UnLoadScene();
        }
        LoadNewScene(); 
        // ��Ŀ��λ��Ӧ������һ���Ҫ���ݵĶ���


    }
    private void LoadNewScene()
    {
        sceneToLoad.sceneReference.LoadSceneAsync(LoadSceneMode.Additive, true);
        currentLoadedScene = sceneToLoad;
    }
   
}
