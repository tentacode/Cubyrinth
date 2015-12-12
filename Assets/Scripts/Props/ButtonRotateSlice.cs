using UnityEngine;
using System.Collections;

public class ButtonRotateSlice : MonoBehaviour
{
	public SliceRotator.RotationDirection direction;
	public SliceRotator sliceRotator;

	public void OnClick ()
	{
		sliceRotator.Rotate(direction);
	}
}
