using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace TheLastArcher
{
	[RequireComponent(typeof(Text))]
	public class MenuTextItem : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
	{
		private Text m_text;
		private Color m_defaultColor;

		[SerializeField] private Color m_highlightedColor;
		[SerializeField] private Color m_clickedColor;
		[SerializeField] private UnityEvent m_event;

		void Start() 
		{
			m_text = GetComponent<Text> ();
			m_defaultColor = m_text.color;
		}

		#region IPointerExitHandler implementation

		public void OnPointerExit (PointerEventData eventData)
		{
			m_text.color = m_defaultColor;
		}

		#endregion

		#region IPointerEnterHandler implementation

		public void OnPointerEnter (PointerEventData eventData)
		{
			m_text.color = m_highlightedColor;
		}

		#endregion

		#region IPointerClickHandler implementation

		public void OnPointerClick (PointerEventData eventData)
		{
			if (eventData.button == PointerEventData.InputButton.Left) 
			{
				m_text.color = m_clickedColor;

				m_event.Invoke ();
			}
		}

		#endregion
	}
}