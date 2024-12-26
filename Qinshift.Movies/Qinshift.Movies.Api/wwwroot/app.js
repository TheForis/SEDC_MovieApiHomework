let resultDiv = document.getElementById('result');
let button = document.getElementById('getMovies');

let url = "https://localhost:7060/api/Movies";
function getMoviesFromApi() {
    fetch(url)
        .then(res => res.json())
        .then(movies => {
            console.log(movies)
            writeMovies(movies)
        })
        .catch(err => {
            console.log(err)
        })
}
function writeMovies(movies) {
    for (i = 0; i < movies.length; i++) {
        resultDiv.innerHTML += `
    <p>${movies[i].title}</p>
    <p>${movies[i].plot}</p>
    <p>${movies[i].genre}</p>
    <hr>
    `
    }
}

button.addEventListener('click', () => {
    getMoviesFromApi();
})