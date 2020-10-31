using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class CooldownRadial : MonoBehaviour
{
	[HideInInspector]
	public float TotalTime = 0.0f;

	private float m_RemainingTime;
	private Image m_Image;

	public bool activated = false;
	public bool ready = true;

	// Use this for initialization
	void Start ()
	{
		m_Image = GetComponent<Image>();
	}

	void OnEnable()
	{
		// Al activarlo reseteamos el tiempo total que dura el powerup
		m_RemainingTime = TotalTime;
	}

	// Update is called once per frame
	void Update ()
	{
		// TODO 1 - Comprobamos si se ha acabado el tiempo
		if (m_RemainingTime <= 0)
		{
			// TODO 2 - Desactivamos el gameobject para que no se pinte
			//gameObject.SetActive(false);
			ready = true;
		}
		else
		{
			// TODO 3 - Calculamos cuánto powerup hay que pintar (entre 0 y 1)
			// dependiendo del tiempo que nos queda
			float portion = Mathf.InverseLerp(TotalTime, 0, m_RemainingTime);
            if (portion > 0.98)
            {
				portion = 1;
            }
			// TODO 4 - Asignamos este valor al fillAmount de la imagen
			m_Image.fillAmount = portion;
			// TODO 5 - Restamos al tiempo restante el tiempo que ha pasado
			m_RemainingTime -= Time.deltaTime;
		}

		
	}
	public void StartCooldown(float duration)
	{
		ready = false;
		TotalTime = duration;
		m_RemainingTime = duration;
	}
}
