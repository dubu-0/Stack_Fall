using StackFall.Ranges.Int;
using UnityEngine;

namespace StackFall.Tube
{
    public class TubeView : MonoBehaviour
    {
        public void SetLocalScale(float width, float height)
        {
            transform.localScale = new Vector3(width, height, width);
            MoveUpTo(height);
        }

        private void MoveUpTo(float y)
        {
            var localPosition = transform.localPosition;
            localPosition.y = y;
            transform.localPosition = localPosition;
        }
    }
}
