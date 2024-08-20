using UnityEngine;
using System.IO;
using System.Collections;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.AddressableAssets.ResourceLocators;
using System.Collections.Generic;

/**
* Dev Script for testing the spawning of assets from asset bundles.
* The assets should be built into asset bundles and be put into a folder under the StreamingAssets folder of this project.
* Define the assets and bundle by assigning the relative asset paths to assetPaths and the asset bundle name to assetBundleName.
*
* assetPaths: String list of RELATIVE paths (to the assets)
* assetBundleFolder: Folder in which all asset bundles are stored under StreamingAssets (default: StandaloneLinux64)
* assetBundleCatalog: Name of the catalog of the related asset bundles. Every release contains a catalog file which is needed to load the asset bundles of this release. Extra catalog files (from other addressable builds) can be added and loaded with Addressables.LoadContentCatalogAsync() in a similar way.
**/
public class AddressableSpawn : MonoBehaviour
{
    private IEnumerable assetPaths = new string[] {
        "Assets/Resources_moved/Objects/Prefabs/Office/Box/Box.prefab", "Assets/Resources_moved/Objects/Prefabs/Office/Cabinet with drawings/Cabinet with drawings.prefab", "Assets/Resources_moved/Objects/Prefabs/Office/Chair Office/Chair Office.prefab"
        };
    private string assetBundleFolder = "StandaloneLinux64";
    private string assetBundleCatalog = "catalog_0.1.json"; // Arena Asset Catalog renamed to catalog_arena AFTER building as of now to prevent clash with user asset building process

    AsyncOperationHandle<IList<GameObject>> opHandle;
    AsyncOperationHandle<Material> materialHandle;

    // Loading the asset
    IEnumerator Start()
    {
        // string path = UnityEngine.Application.dataPath + "/../" + UnityEditor.EditorUserBuildSettings.activeBuildTarget;
        // string path = UnityEngine.AddressableAssets.Addressables.RuntimePath + " and " + UnityEditor.EditorUserBuildSettings.activeBuildTarget;
        //Debug.Log(path);

        // asynchronous loading of assetbundle catalog
        AsyncOperationHandle<IResourceLocator> handle = Addressables.LoadContentCatalogAsync(Path.Combine(Application.streamingAssetsPath, assetBundleFolder, assetBundleCatalog), true);
        yield return handle;


        // GENERAL ASSETBUNDLE LOADING EXAMPLE
        int x = 0, z = 0;
        // asynchronous loading multiple assets
        opHandle = Addressables.LoadAssetsAsync<GameObject>(
            assetPaths,
            asset =>
            {
                Instantiate(asset, new Vector3((3 * x++) - 20, 0, (3 * z) - 20), Quaternion.identity);
                if (x > 15)
                {
                    x = 0;
                    z++;
                }
            },
            Addressables.MergeMode.Union,
            false);
        yield return opHandle;

        // if asset loading worked
        if (opHandle.Status == AsyncOperationStatus.Failed)
        {
            Debug.LogError("There was at least one loading error in the asset bundle!");
        }
        

        // DRYWALL LOADING EXAMPLE
        // load dry wall material 
        materialHandle = Addressables.LoadAssetAsync<Material>("Assets/Resources_moved/Wall Materials/Drywall/Drywall.mat");
        yield return materialHandle;
        Material drywallMaterial = materialHandle.Result;
        Color hue1 = new(0, 0, 0, 1);
        Color hue2 = new(0.46f, 0.38f, 0.23f, 1);
        Color hue3 = new(1, 1, 1, 1);

        // create 3 walls, set material, position and scale
        GameObject Wall1 = GameObject.CreatePrimitive(PrimitiveType.Cube); Wall1.name = "Wall1";
        GameObject Wall2 = GameObject.CreatePrimitive(PrimitiveType.Cube); Wall2.name = "Wall2";
        GameObject Wall3 = GameObject.CreatePrimitive(PrimitiveType.Cube); Wall3.name = "Wall3";
        MeshRenderer Wall1Renderer = Wall1.GetComponent<MeshRenderer>();
        MeshRenderer Wall2Renderer = Wall2.GetComponent<MeshRenderer>();
        MeshRenderer Wall3Renderer = Wall3.GetComponent<MeshRenderer>();
        Wall1Renderer.material = drywallMaterial;  // using the "material" property, you need to manually free up the memory by destroying the material when its not used anymore
        Wall2Renderer.material = drywallMaterial;
        Wall3Renderer.material = drywallMaterial;
        Wall1Renderer.material.SetColor("_BaseColor", hue1);
        Wall2Renderer.material.SetColor("_BaseColor", hue2);
        Wall3Renderer.material.SetColor("_BaseColor", hue3);
        Wall1.transform.position = new Vector3(-20, 0, -17);      // x, y, z
        Wall2.transform.position = new Vector3(-17, 0, -17);
        Wall3.transform.position = new Vector3(-14, 0, -17);
        Wall1.transform.localScale = new Vector3(3, 3, 0.5f);   // width, height, length
        Wall2.transform.localScale = new Vector3(3, 3, 0.5f);
        Wall3.transform.localScale = new Vector3(3, 3, 0.5f);
}
    void OnDestroy()
    {
        Addressables.Release(opHandle);
        Addressables.Release(materialHandle);
        Destroy(GameObject.Find("Wall1").GetComponent<MeshRenderer>().material);
        Destroy(GameObject.Find("Wall2").GetComponent<MeshRenderer>().material);
        Destroy(GameObject.Find("Wall3").GetComponent<MeshRenderer>().material); 
    }
}
