fetch("https://imdb8.p.rapidapi.com/auto-complete?q=pokemon", {
	"method": "GET",
	"headers": {
		"x-rapidapi-key": "097660fff6mshbf3bbda085b3705p15078ajsn26fe42704123",
		"x-rapidapi-host": "imdb8.p.rapidapi.com",
	}
})
.then(response=>response.json())
.then(response => {
	console.log(response);
})
.catch(err => {
	console.error(err);
});