using StackFall.Ranges.Int;
using UnityEngine;

namespace StackFall.TubeSystem
{
    public class TubeView : MonoBehaviour
    {
        public void SetLocalScale(SizeInt size)
        {
            var localScale = transform.localScale;
            localScale.x = size.Width;
            localScale.y = size.Height;
            localScale.z = size.Width;
            transform.localScale = localScale;
            
            MoveUpTo(size.Height);
        }

        private void MoveUpTo(float y)
        {
            var localPosition = transform.localPosition;
            localPosition.y = y;
            transform.localPosition = localPosition;
        }
    }
}
