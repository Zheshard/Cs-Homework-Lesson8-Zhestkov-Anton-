// Сформируйте трёхмерный массив из двузначных чисел. Напишите программу, которая будет построчно выводить массив, добавляя индексы каждого элемента.

int sizeByX = InputNumber("Введите размер массива по X: ");
int sizeByY = InputNumber("Введите размер массива по Y: ");
int sizeByZ = InputNumber("Введите размер массива по Z: ");
const int minValue = 10;
const int maxValue = 100;
System.Console.WriteLine();
int[,,] arrayRandomNumbers = Fill3DArrayWithRandomIntegerNumbers(sizeByX, sizeByY, sizeByZ, minValue, maxValue);
Print3DArray(arrayRandomNumbers);
System.Console.WriteLine();


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

// Метод, формирующий трехмерный массив, заполненный случайными двузначными числами. Размерность массива задается пользователем:
int[,,] Fill3DArrayWithRandomIntegerNumbers(int numX, int numY, int numZ, int leftRange, int rigthRange)
{
	int[,,] fillableArray = new int[numX, numY, numZ];
	Random rand = new Random();
	for (int i = 0; i < fillableArray.GetLength(0); i++)
	{
		for (int j = 0; j < fillableArray.GetLength(1); j++)
		{
			for (int k = 0; k < fillableArray.GetLength(2); k++)
			{
				fillableArray[i, j, k] = rand.Next(leftRange, rigthRange + 1);
			}
		}
	}
	return fillableArray;
}
//------------------------------------------------------------------------------------------------

// Метод вывода трехмерного массива в консоль:
void Print3DArray(int[,,] outputArray)
{
	for (int i = 0; i < outputArray.GetLength(0); i++)
	{
		for (int j = 0; j < outputArray.GetLength(1); j++)
		{
			for (int k = 0; k < outputArray.GetLength(2); k++)
			{
				Console.Write($"| {outputArray[i, j, k]} ({i},{j},{k}) ");
			}
		}
		Console.WriteLine("|");
	}
}
//-------------------------------------------------------------------------------
