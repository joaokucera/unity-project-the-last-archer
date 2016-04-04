using UnityEngine;
using System.Collections;

namespace TheLastArcher
{
	public enum AnchorPosition { Left, Right, Bottom, Top }

	[RequireComponent(typeof(SpriteRenderer))]
	public class ObjectPosition : MonoBehaviour 
	{
		private SpriteRenderer m_renderer;

		[SerializeField] private AnchorPosition m_position;

		void Start() 
		{
			m_renderer = transform.FindComponentInHierarchy<SpriteRenderer>();

			SetPosition ();
		}

		private void SetPosition() 
		{
			var orthographic = GlobalVariables.MainCamera.orthographicSize;
			var aspect = GlobalVariables.MainCamera.aspect;

			var position = transform.position;
			var size = m_renderer.sprite.bounds.size;

			switch (m_position) 
			{
			case AnchorPosition.Left:
					position.x = -(orthographic * aspect) + size.x / 2;
					break;
				case AnchorPosition.Right:
					position.x = (orthographic * aspect) - size.x / 2;
					break;
				case AnchorPosition.Bottom:
					position.y = -(orthographic) + size.y / 2;
					break;
				case AnchorPosition.Top:
					position.y = (orthographic) - size.y / 2;
					break;
			}

			transform.position = position;
		}
	}
}