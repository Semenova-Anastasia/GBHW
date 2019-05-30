using UnityEngine;

namespace GeekBrains
{
    public class Wall : BaseObjectScene, ISelectObj
    {
        [SerializeField] private string Name;

		public string GetMessage()
		{
			return Name;
		}
	}
}