var input = document.querySelector('#number')
var click = document.querySelector('#btn')
var table = document.querySelector('table')

var result = ""

click.addEventListener("click", function(e) 
{
	e.preventDefault();
	result = ""
	if(input.value > 0 && input.value < 21)
	{
		let max = input.value;
		let arrIP = new Array(max);
		let start = 1;
		let border = 0, a = 0, b = 0;
		let minA = 0, minB = 0, maxA = max, maxB = max;

		for (let i = 0; i < max; i++)
		{
			arrIP[i] = new Array(max);
			for (let j = 0; j < max; j++) 
			{
				arrIP[i][j] = 0;
			}
		}

		while(start <= max**2)
		{
			if(maxB >= b && border == 0)
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
			else if(maxA >= a && border == 1)
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
			else if(minB <= b && border == 2)
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
			else if(minA <= a && border == 3)
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

		for (let i = 0; i < max; i++)
		{
			result += "</tr>"
			for (let j = 0; j < max; j++)
			{
				result += `<td>${arrIP[i][j]}<td/>`;
			}
			result += "</tr>"
		}
		table.innerHTML = result;
	}
});
