var input = document.querySelector('#number')
var click = document.querySelector('#btn')
var result = document.querySelector('#result')

click.addEventListener("click", function(e) 
{
	e.preventDefault();
	var n = input.value;
	FN = [0, 2]
	for(var i = 1; i < n; i++)
		FN.push(4 * FN[i] + FN[i - 1]);
	
	result.innerHTML = FN.join(', ');
});