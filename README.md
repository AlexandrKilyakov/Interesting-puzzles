# Сборник интересных задач

В данном репозитории я собираю собственные решения задач, которые мне показались интересными.
В данном репозитории есть следующие задачи:
1. Спиральная матрица - (Spiral-matrix);
2. Четные числа Фибоначчи - (Even-Fibonacci-Numbers);
3. Метод Жордана-Гаусса - (Jordan-Gauss-method).

## Спиральная матрица

Необходимо вывести таблицу размером n×n, заполненную числами от 1 до n^2 по спирали, выходящей из левого верхнего угла и закрученной по часовой стрелке.

Код из файла js:
```javascript
let max = input.value;
let arrIP = new Array(max);
let start = 1;
let border = 0, a = 0, b = 0;
let minA = 0, minB = 0, maxA = max, maxB = max;

for (let i = 0; i < max; i++) // Зополняем нулями матрицу
{
  arrIP[i] = new Array(max);
  for (let j = 0; j < max; j++) 
  {
    arrIP[i][j] = 0;
  }
}

while(start <= max**2) // Вносим данные по спирали
{
  if(maxB >= b && border == 0)  // Слева направо
  {
    arrIP[a][b++] = start++;				
    if(maxB == b)
    {
      minA++;
      border = 1;
      b--;
      a++;
    }
  }
  else if(maxA >= a && border == 1) // Слева вниз
  {
    arrIP[a++][b] = start++;

    if(maxA == a)
    {
      maxB--;
      border = 2;
      a--;
      b--;
    }
  }
  else if(minB <= b && border == 2) // Справа налево
  {
    arrIP[a][b--] = start++;				
    if(minB == b + 1)
    {
      maxA--;
      border = 3;
      a--;
      b++;
    }
  }
  else if(minA <= a && border == 3) // Справа вверх
  {
    arrIP[a--][b] = start++;				
    if(minA == a + 1)
    {
      minB++;
      border = 0;
      a++;
      b++;
    }
  }
}
```

Результат:

![Показан результат](https://user-images.githubusercontent.com/76633175/131887517-8b750f58-17d0-4740-ae1d-0d130130373c.png)

## Четные числа Фибоначчи

Необходимо вывести n чисел из последовательности, которые являются четными, начиная с 0.

Код из файла js:
```javascript
let n = input.value;
	let FN = [0, 2];
	for(let i = 1; i < n; i++) FN.push(4 * FN[i] + FN[i - 1]);
```

Результат:

![Показан результат](https://user-images.githubusercontent.com/76633175/131887354-cfae9cbe-4f90-4140-aff8-952d59cd2898.png)


## Метод Жордана-Гаусса

Метод Гаусса — Жордана — метод, который используется для решения квадратных систем линейных алгебраических уравнений, нахождения обратной матрицы, нахождения координат вектора в заданном базисе или отыскания ранга матрицы. Метод является модификацией метода Гаусса.

Решение данного метода реализованно в виде форм, созданных благодаря Visual Studio, на ЯП C#. Первая страница предлагает ввести размеры матрицы, после чего заполнить необходимые поля. После этого можно перейти на вторую форму, и получить решение, после чего найти все Х-ы.

Форма 1 после заполнения:

![image](https://user-images.githubusercontent.com/76633175/132061370-126453a7-ab56-4bf1-97e7-33eaa17c7322.png)

Вывод формы 2:

![image](https://user-images.githubusercontent.com/76633175/132061411-4644e2c4-4e60-497f-9ac4-27c6a99dde5d.png)

Решение:

![image](https://user-images.githubusercontent.com/76633175/132061424-2ed2041c-20c6-489e-8446-be7f4a3060f5.png)

Найти Х:

![image](https://user-images.githubusercontent.com/76633175/132061448-8e928fb3-af99-4a37-a00b-3452f8f3c247.png)

Код для получения обратной матрицы:
```C#
for (i = 0; i < row_num; i++)
{
    for (j = 0; j < col_num; j++)
    {
        if (i == j && col_num - 1 != j)
        {
            partially_pivot(arrA, i, j);

            diagonal_element = arrA[i, j];
            k = i;
            l = j;

            for (l = 0; l < col_num; l++)
            {
                // для изготовления диагонального элемента 1
                arrA[k, l] /= diagonal_element;
                div++;
            }


            for (k = 0; k < row_num; k++)
            {
                //setting flag = элемент в соответствующей строке, который находится точно под рассматриваемым диагональным элементом
                flag = arrA[k, j];

                for (l = 0; l < col_num; l++)
                    if (k != i)
                    {
                        // выполнение строковой операции, чтобы охватить все элементы = 0, кроме диагонального элемента
                        arrA[k, l] = (arrA[k, l]) - flag * (arrA[i, l]);
                    }

            }
        }
    }
}
```
