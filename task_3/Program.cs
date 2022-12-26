// Задайте две матрицы. Напишите программу, которая будет находить произведение двух матриц.

Console.WriteLine("\nВведите размерность двух матриц. Две матрицы можно перемножить между собой тогда и только тогда, когда количество столбцов первой матрицы равно количеству строк второй матрицы.\n");
SetTheDimensionOfTwoMatrices(out int numLinesMatrixFirst, out int numColumnsMatrixFirst, out int numLinesMatrixSecond, out int numColumnsMatrixSecond);
const int minValue = 0;
const int maxValue = 10;
int[,] firstMatrix = Fill2DArrayWithRandomIntegerNumbers(numLinesMatrixFirst, numColumnsMatrixFirst, minValue, maxValue);
int[,] secondMatrix = Fill2DArrayWithRandomIntegerNumbers(numLinesMatrixSecond, numColumnsMatrixSecond, minValue, maxValue);
System.Console.WriteLine("\nПервая матрица:");
Print2DArray(firstMatrix);
System.Console.WriteLine("\nВторая матрица:");
Print2DArray(secondMatrix);
int[,] matrixProduct = MultiplyTwoMatrices(firstMatrix, secondMatrix);
System.Console.WriteLine("\nРезультат умножения матриц:");
Print2DArray(matrixProduct);


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

// Метод, который позволяет ввести размерность двух матриц и проверяет, удовлетворяют ли введенные данные условию перемножения двух матриц:
void SetTheDimensionOfTwoMatrices(out int numLinesMatrixFirst, out int numColumnsMatrixFirst, out int numLinesMatrixSecond, out int numColumnsMatrixSecond)
{
	while (true)
	{
		numColumnsMatrixFirst = InputNumber("Введите количество столбцов первой матрицы: ");
		numLinesMatrixFirst = InputNumber("Введите количество строк первой матрицы: ");
		numColumnsMatrixSecond = InputNumber("Введите количество столбцов второй матрицы: ");
		numLinesMatrixSecond = InputNumber("Введите количество строк второй матрицы: ");
		if (numColumnsMatrixFirst == numLinesMatrixSecond) break;
		else System.Console.WriteLine("\nДве матрицы можно перемножить между собой тогда и только тогда, когда количество столбцов первой матрицы равно количеству строк второй матрицы.\nУбедитесь в правильности введенных значений и повторите попытку.\n");
	}
}
//---------------------------------------------------------------------------------

// Метод, возвращающий результат перемножения двух матриц:
int[,] MultiplyTwoMatrices(int[,] matrixA, int[,] matrixB)
{
	int[,] matrixC = new int[matrixA.GetLength(0), matrixB.GetLength(1)]; // Результатом умножения матриц Am×n и Bn×k будет матрица Cm×k 
	for (int i = 0; i < matrixC.GetLength(0); i++)
	{
		for (int j = 0; j < matrixC.GetLength(1); j++)
		{
			int sum = 0;
			for (int n = 0; n < matrixA.GetLength(1); n++)
			{
				sum = sum + matrixA[i, n] * matrixB[n, j];
			}
			matrixC[i, j] = sum; // Сij = Ai1 · B1j + Ai2 · B2j + ... + Ain · Bnj
		}
	}
	return matrixC;
}
//------------------------------------------------------------------------------------