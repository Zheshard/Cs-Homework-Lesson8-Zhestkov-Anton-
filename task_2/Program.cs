// Задайте прямоугольный двумерный массив. Напишите программу, которая будет находить строку с наименьшей суммой элементов.

Console.WriteLine("Введите размерность массива: ");
int sizeColumn = InputNumber("Введите количество столбцов: ");
int sizeLine = InputNumber("Введите количество строк: ");
const int minValue = 0;
const int maxValue = 10;
System.Console.WriteLine();
int[,] arrayRandomNumbers = Fill2DArrayWithRandomRealNumbers(sizeLine, sizeColumn, minValue, maxValue);
Print2DArray(arrayRandomNumbers);
System.Console.WriteLine();
int lineWithMinAmount = FindTheLineNumberWithTheSmallestSum(arrayRandomNumbers);
System.Console.WriteLine($"Индекс строки с минимальной суммой элементов рвен {lineWithMinAmount}");


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
int[,] Fill2DArrayWithRandomRealNumbers(int numLines, int numColumns, int leftRange, int rigthRange)
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

// Метод, который находит номер строки двумерного массива с наименьшей суммой элементов:
int FindTheLineNumberWithTheSmallestSum(int[,] inputArray)
{
	int[] amountsPerLines = new int[inputArray.GetLength(0)];
	for (int i = 0; i < inputArray.GetLength(0); i++)
	{
		int sumLine = 0;
		for (int j = 0; j < inputArray.GetLength(1); j++)
		{
			sumLine = sumLine + inputArray[i, j];
		}
		amountsPerLines[i] = sumLine;
	}

	System.Console.WriteLine("Суммы элементов строк:");
	System.Console.WriteLine(string.Join("; ", amountsPerLines));
	System.Console.WriteLine();
	int minSum = amountsPerLines[0];
	int indexMinSum = 0;
	for (int k = 0; k < amountsPerLines.Length; k++)
	{
		if (minSum > amountsPerLines[k])
		{
			minSum = amountsPerLines[k];
			indexMinSum = k;
		}
	}
	return indexMinSum;
}
