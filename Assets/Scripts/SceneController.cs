using UnityEngine;
using System.Collections;

public class SceneController : MonoBehaviour
{
	public const int gridRows = 2;
	public const int gridCols = 4;
	public const float offsetX = 2f;
	public const float offsetY = 2.5f;

	[SerializeField] private MemoryCard originalCard;
	[SerializeField] private Sprite[] images;

	void Start ()
	{
		Vector3 startPos = originalCard.transform.position;
		int[] numbers = { 0, 0, 1, 1, 2, 2, 3, 3 };
		numbers = ShuffleArray (numbers);

		for (int i = 0; i < gridCols; i++) {
			for (int j = 0; j < gridRows; j++) {
				MemoryCard card;
				if (i == 0 && j == 0) {
					card = originalCard;
				} else {
					card = Instantiate (originalCard) as MemoryCard;
				}

				int index = j * gridCols + i;
				int id = numbers [index];
				card.SetCard (id, images [id]);

				float posX = (offsetX * i) + startPos.x;
				float posY = -(offsetY * j) + startPos.y;
				card.transform.position = new Vector3 (posX, posY, startPos.z);
			}
		}
	}

	private int[] ShuffleArray (int[] numbers)
	{
		int[] newArray = numbers.Clone () as int[];
		for (int i = 0; i < newArray.Length; i++) {
			int tmp = newArray [i];
			int r = Random.Range (i, newArray.Length);
			newArray [i] = newArray [r];
			newArray [r] = tmp;
		}
		return newArray;
	}
}
