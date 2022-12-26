// Задайте двумерный массив. Напишите программу, которая упорядчит по убыванию элементы каждой строки двумерного массива.

Console.WriteLine("Введите размерность массива: ");
int sizeColumn = InputNumber("Введите количество столбцов: ");
int sizeLine = InputNumber("Введите количество строк: ");
const int minValue = 0;
const int maxValue = 10;
System.Console.WriteLine();
int[,] arrayRandomNumbers = Fill2DArrayWithRandomIntegerNumbers(sizeLine, sizeColumn, minValue, maxValue);
Print2DArray(arrayRandomNumbers);
System.Console.WriteLine();
SortElementsOfAStringInOescendingOrder(arrayRandomNumbers);
Print2DArray(arrayRandomNumbers);

// ======================Методы==============================================================

// Метод, позволяющий ввести в консоль целое число и исключающий ввод других типов значений:
int InputNumber(string invitationText)
{
	int inputNum;
	while (true)
	{
		Console.Write(invitationText);
		string inputStr = Console.ReadLine();
		if (int.TryParse(inputStr, out inputNum))
		{
			break;
		}
		Console.WriteLine("Введено неверное значение!");
	}
	return inputNum;
}
//------------------------------------------------------------------------------------------------------------------

// Метод, формирующий двумерный массив, заполненный случайными  целыми числами. Размерность массива задается пользователем:
int[,] Fill2DArrayWithRandomIntegerNumbers(int numLines, int numColumns, int leftRange, int rigthRange)
{
	int[,] fillableArray = new int[numLines, numColumns];
	Random rand = new Random();
	for (int i = 0; i < fillableArray.GetLength(0); i++)
	{
		for (int j = 0; j < fillableArray.GetLength(1); j++)
		{
			fillableArray[i, j] = rand.Next(leftRange, rigthRange + 1);
		}
	}
	return fillableArray;
}
//------------------------------------------------------------------------------------------------

// Метод вывода двумерного массива в консоль:
void Print2DArray(int[,] outputArray)
{
	for (int i = 0; i < outputArray.GetLength(0); i++)
	{
		for (int j = 0; j < outputArray.GetLength(1); j++)
		{
			Console.Write($"| {outputArray[i, j]} \t");
		}
		Console.WriteLine("|");
	}
}
//-------------------------------------------------------------------------------

// Метод, который упорядчит по убыванию элементы каждой строки двумерного массива.
void SortElementsOfAStringInOescendingOrder(int[,] inputArray)
{
	for (int i = 0; i < inputArray.GetLength(0); i++)
	{
		for (int j = 0; j < inputArray.GetLength(1) - 1; j++)
		{
			int minIndex = j + 1;
			for (int k = j + 1; k < inputArray.GetLength(1); k++)
			{
				if (inputArray[i, k] > inputArray[i, minIndex])
				{
					minIndex = k;
				}
			}

			if (inputArray[i, j] < inputArray[i, minIndex])
			{
				int temporary = inputArray[i, j];
				inputArray[i, j] = inputArray[i, minIndex];
				inputArray[i, minIndex] = temporary;
			}
		}
	}
}
//--------------------------------------------------------------------------