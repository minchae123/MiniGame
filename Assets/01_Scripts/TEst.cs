using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TEst : MonoBehaviour
{
	public int rows = 10;
	public int cols = 15;
	public int targetSum = 820;
	private int[] numbers;

	public TextMeshProUGUI txt;

	void Start()
	{
		numbers = GenerateNumberArray();
		ShuffleArray(numbers);
		PrintArray(numbers);
	}

	int[] GenerateNumberArray()
	{
		int[] result = new int[rows * cols];
		int sum = 0;
		int index = 0;

		// Initial distribution
		for (int i = 1; i <= 9; i++)
		{
			for (int j = 0; j < 15; j++)
			{
				result[index++] = i;
				sum += i;
			}
		}

		// Adjust distribution to match targetSum
		while (sum != targetSum)
		{
			for (int i = 0; i < result.Length && sum != targetSum; i++)
			{
				int diff = targetSum - sum;
				if (diff > 0 && result[i] < 9)
				{
					result[i]++;
					sum++;
				}
				else if (diff < 0 && result[i] > 1)
				{
					result[i]--;
					sum--;
				}
			}
		}

		return result;
	}

	void ShuffleArray(int[] array)
	{
		for (int i = array.Length - 1; i > 0; i--)
		{
			int randomIndex = Random.Range(0, i + 1);
			int temp = array[i];
			array[i] = array[randomIndex];
			array[randomIndex] = temp;
		}
	}

	void PrintArray(int[] array)
	{
		for (int i = 0; i < rows; i++)
		{
			string row = "";
			for (int j = 0; j < cols; j++)
			{
				row += array[i * cols + j] + " ";
			}
			txt.text += "\n";
			Debug.Log(row);
		}
	}
}
