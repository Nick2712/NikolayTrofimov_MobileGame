using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;


namespace NikolayTrofimov_MobileGame_Lesson9
{
    internal class AssetBundleViewBase : MonoBehaviour
    {
        private const string UrlAssetBundleSprites =
            "https://drive.google.com/uc?export=download&id=1luXEjBRPqnmEw9T6dsViwwyO1MEdk5la";
        private const string UrlAssetBundleAudio =
            "https://drive.google.com/uc?export=download&id=1AhRKdebijH_Rf8AqZ0_u7d3W284dCL-H";

        private const string UrlDZBundle =
            "https://drive.google.com/uc?export=download&id=1Jrzc5S7maXJiP0J03YLmcR78DW3VGF4v";

        [SerializeField] private SpriteBundleData[] _spriteBundleDatas;
        [SerializeField] private AudioBundleData[] _audioBundleDatas;

        private AssetBundle _spriteAssetBundle;
        private AssetBundle _audioAssetBundle;

        private AssetBundle _dzAssetBundle;


        protected IEnumerator DownloadAndSetAssetBundles()
        {
            yield return GetSpritesAssetBundle();
            yield return GetAudioAssetBundle();


            if (_spriteAssetBundle != null)
            {
                SetSpriteAssets(_spriteAssetBundle);
            }
            else
            {
                Debug.LogError($"AssetBundle {nameof(_spriteAssetBundle)} failed to load");
            }

            if (_audioAssetBundle != null)
            {
                SetAudioAssets(_audioAssetBundle);
            }
            else
            {
                Debug.LogError($"AssetBundle {nameof(_audioAssetBundle)} failed to load");
            }
        }

        protected IEnumerator DZ()
        {
            yield return GetDZSprite();

            if (_dzAssetBundle != null)
            {
                SetSpriteAssets(_dzAssetBundle);
            }
            else
            {
                Debug.LogError($"AssetBundle {nameof(_dzAssetBundle)} failed to load");
            }
        }

        private IEnumerator GetDZSprite()
        {
            UnityWebRequest request = UnityWebRequestAssetBundle.GetAssetBundle(UrlDZBundle);

            yield return request.SendWebRequest();

            while (!request.isDone)
                yield return null;

            StateRequest(request, out _dzAssetBundle);
        }

        private IEnumerator GetSpritesAssetBundle()
        {
            UnityWebRequest request = UnityWebRequestAssetBundle.GetAssetBundle(UrlAssetBundleSprites);

            yield return request.SendWebRequest();

            while (!request.isDone)
                yield return null;

            StateRequest(request, out _spriteAssetBundle);
        }

        private IEnumerator GetAudioAssetBundle()
        {
            UnityWebRequest request = UnityWebRequestAssetBundle.GetAssetBundle(UrlAssetBundleAudio);

            yield return request.SendWebRequest();

            while (!request.isDone)
                yield return null;

            StateRequest(request, out _audioAssetBundle);
        }

        private void StateRequest(UnityWebRequest request, out AssetBundle assetBundle)
        {
            if (request.error == null)
            {
                assetBundle = DownloadHandlerAssetBundle.GetContent(request);
                Debug.Log("complete");
            }
            else
            {
                assetBundle = null;
                Debug.LogError(request.error);
            }
        }

        private void SetSpriteAssets(AssetBundle spriteAssetBundle)
        {
            foreach (SpriteBundleData data in _spriteBundleDatas)
            {
                var sprite = spriteAssetBundle.LoadAsset<Sprite>(data.NameAssetBundle);
                if (sprite != null) data.Image.sprite = sprite;
            }
        }

        private void SetAudioAssets(AssetBundle audioAssetBundle)
        {
            foreach (AudioBundleData data in _audioBundleDatas)
            {
                data.AudioSource.clip = audioAssetBundle.LoadAsset<AudioClip>(data.NameAssetBundle);
                data.AudioSource.Play();
            }
        }
    }
}
