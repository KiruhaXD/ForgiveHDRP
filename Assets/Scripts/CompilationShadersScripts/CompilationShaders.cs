using System.Collections;
using TMPro;
using UnityEditor;
using UnityEngine;

public class CompilationShaders : MonoBehaviour
{
    //[SerializeField] Image compilationShadersImage;
    [SerializeField] TMP_Text compilationProgressText;
    [SerializeField] GameObject compilationShadersPanel;

    float progress = 0f;

    private void Update()
    {
        StartCoroutine(CompilationShadersCoroutine());
    }

    public IEnumerator CompilationShadersCoroutine() 
    {
        AsyncOperation asyncOperation = new AsyncOperation();

        if (ShaderUtil.anythingCompiling == true) // ничего не происходит, так что придется еще искать способ как проверить комплицию шейдеров
        {
            compilationShadersPanel.SetActive(true);

            while (!asyncOperation.isDone)
            {
                progress = asyncOperation.progress;   
                compilationProgressText.text = progress.ToString() + "%";

                Debug.Log("Компиляция шейдеров началась!" + progress);
                yield return null;
            }
        }

        else
            compilationShadersPanel.SetActive(false);
    }
}
