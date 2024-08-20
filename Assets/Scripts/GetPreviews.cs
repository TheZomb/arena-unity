using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.AddressableAssets.ResourceLocators;
using UnityEngine.ResourceManagement.AsyncOperations;

public class GetPreviews : MonoBehaviour
{
    private IEnumerable assetPaths = new string[] {
        "Assets/Resources_moved/Objects/Prefabs/Office/Box/Box.prefab", "Assets/Resources_moved/Objects/Prefabs/Office/Cabinet with drawings/Cabinet with drawings.prefab", "Assets/Resources_moved/Objects/Prefabs/Office/Chair Office/Chair Office.prefab", 
        }; // hard coded paths for some examples from the asset bundle
    private string assetBundleFolder = "StandaloneLinux64";
    private string assetBundleCatalog = "catalog_0.1.json";
    AsyncOperationHandle<IList<GameObject>> opHandle;

    static Texture2D GetAssetPreviewFromGUID(string guid)
    {
        var method = typeof(AssetPreview).GetMethod("GetAssetPreviewFromGUID",
            System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Static,
            null,
            new[] { typeof(string) },
            null);
        var args = new object[] { guid };

        return method.Invoke(null, args) as Texture2D;
    }

    // Start is called before the first frame update
    IEnumerator Start()
    {
        AsyncOperationHandle<IResourceLocator> handle = Addressables.LoadContentCatalogAsync(Path.Combine(Application.streamingAssetsPath, assetBundleFolder, assetBundleCatalog), true);
        yield return handle;
        
        opHandle = Addressables.LoadAssetsAsync<GameObject>(
            assetPaths,
            asset =>
            {
                Texture2D thumbnail = AssetPreview.GetAssetPreview(asset);
                if (thumbnail != null)
                {
                    //Create a new texture with transparent background
                    Texture2D transparentTexture = new Texture2D(thumbnail.width, thumbnail.height, TextureFormat.RGBA32, false);
                    Color[] pixels = thumbnail.GetPixels(0);

                    //Get the background color
                    Color backgroundColor = pixels[0];
                    for (int j = 0; j < pixels.Length; j++)
                    {
                        if (pixels[j] == backgroundColor) pixels[j].a = 0; //If this pixel is exactly the background color, make it transparent
                    }
                    transparentTexture.SetPixels(pixels);
                    transparentTexture.Apply();

                    string savePath = Application.dataPath + "/../Previews/" + asset + ".png";
                    if (!string.IsNullOrEmpty(savePath))
                    {
                        byte[] pngData = transparentTexture.EncodeToPNG();
                        File.WriteAllBytes(savePath, pngData);

                        Debug.Log("Prefab thumbnail saved: " + savePath);
                    }
                }
            },
            Addressables.MergeMode.Union,
            false);
        yield return opHandle;

        if (opHandle.Status == AsyncOperationStatus.Failed)
        {
            Debug.LogError("There was an error generating the previews!");
        }
    }
    void OnDestroy()
    {
        Addressables.Release(opHandle);
    }
}
