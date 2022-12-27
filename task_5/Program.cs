// Напишите программу, которая заполнит спирально массив 4 на 4.

int sizeColumn = InputNumber("Введите количество строк массива: ");
int sizeLine = InputNumber("Введите количество столбцов массива: ");
int[,] array = new int[sizeLine, sizeColumn];
FillTheArrayInASpiral(array);
Print2DArray(array);


// Метод, заполняющий массив по спирали:
void FillTheArrayInASpiral(int[,] inputArray)
{
	int lengthColumn = inputArray.GetLength(0);
	int lengthString = inputArray.GetLength(1);
	int maxNum = lengthColumn * lengthString;
	int i = 0;
	int j = 0;
	int num = 1;

	while (num < maxNum)
	{

		while (j < lengthString - 1) // заполнение строки слева направо
		{
			array[i, j] = num;
			num++;
			j++;
		}
		array[i, j] = num;
		i++;
		num++;
		if (num > maxNum) break;

		while (i < lengthColumn - 1) // заполнение столбца сверху вних
		{
			array[i, j] = num;
			num++;
			i++;
		}
		array[i, j] = num;
		num++;
		j--;
		if (num > maxNum) break;

		while (j > array.GetLength(1) - lengthString) // заполнение строки справа налево
		{
			array[i, j] = num;
			num++;
			j--;
		}
		array[i, j] = num;
		num++;
		i--;
		if (num > maxNum) break;

		lengthColumn--;

		while (i > array.GetLength(0) - lengthColumn - 1) // заполнение столбца снизу вверх
		{
			array[i, j] = num;
			num++;
			i--;
		}
		if (num > maxNum) break;

		lengthString--;
		i++;
		j++;
		array[i, j] = num;
	}
}
//--------------------------------------------------------------------

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
//-----------------------------------------------------------------

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

