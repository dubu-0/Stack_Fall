using UnityEngine;

namespace StackFall
{
    public class TubeView : MonoBehaviour
    {
        public void SetLocalScale(SizeInt newLocalScale)
        {
            transform.localScale = new Vector3(newLocalScale.Width, newLocalScale.Height, newLocalScale.Width);
        }

        public void MoveUpTo(float y)
        {
            var localPosition = transform.localPosition;
            localPosition.y = y;
            transform.localPosition = localPosition;
        }
    }
}
