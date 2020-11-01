using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowAdvice : MonoBehaviour
{
    [SerializeField]
    private Text m_canvasAdvice = null;

    public void showAdvice(string message) {
        StartCoroutine(showMessage(message));
    }

    IEnumerator showMessage(string message) {
        if (m_canvasAdvice != null) {
            m_canvasAdvice.gameObject.SetActive(true);
            m_canvasAdvice.text = message;
            yield return new WaitForSeconds(3.0f);
            m_canvasAdvice.gameObject.SetActive(false);
            m_canvasAdvice.text = "";
            Destroy(this);
        }
    }
}
