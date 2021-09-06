var input = document.querySelector('#number');
var click = document.querySelector('#btn');
var result = document.querySelector('#result');

click.addEventListener("click", function(e) 
{
	e.preventDefault();
	let n = input.value;
	let FN = [0, 2];
	for(let i = 1; i < n; i++) FN.push(4 * FN[i] + FN[i - 1]);
	
	result.innerHTML = FN.join(', ');
});
