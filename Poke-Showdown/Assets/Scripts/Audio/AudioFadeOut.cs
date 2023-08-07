using System.Collections;

namespace UnityEngine
{
    public static class AudioSourceExtensions
    {
        public static void FadeOut(this AudioSource a, float duration)
        {
            a.GetComponent<MonoBehaviour>().StartCoroutine(FadeOutCore(a, duration));
        }

        private static IEnumerator FadeOutCore(AudioSource a, float duration)
        {
            float startVolume = a.volume;
            float adjustedVolume = startVolume;

            while (adjustedVolume > 0)
            {
                adjustedVolume -= startVolume * Time.deltaTime / duration;
                a.volume = adjustedVolume;
                Debug.Log(adjustedVolume);
                yield return null;
            }

            a.Stop();
            a.volume = startVolume;
        }
    }
}
