# Сборник интересных задачь

В данном репозитории я собираю собственные решения задач, которые мне показались интересными.
В данном репозитории есть следующие задачи:
1. Спиральная матрица;
2. Четные числа Фибоначчи.

## Спиральная матрица

Необходимо вывести таблицу размером n×n, заполненную числами от 1 до n^2 по спирали, выходящей из левого верхнего угла и закрученной по часовой стрелке.

Код из файла js:
```javascript
var max = input.value;
var arrIP = new Array(max);
var start = 1;
var border = 0, a = 0, b = 0;
var minA = 0, minB = 0, maxA = max, maxB = max;

for (var i = 0; i < max; i++) // Зополняем нулями матрицу
{
  arrIP[i] = new Array(max);
  for (var j = 0; j < max; j++) 
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
var n = input.value;
FN = [0, 2]
for(var i = 1; i < n; i++)
  FN.push(4 * FN[i] + FN[i - 1]);
```

Результат:

![Показан результат](https://user-images.githubusercontent.com/76633175/131887354-cfae9cbe-4f90-4140-aff8-952d59cd2898.png)
