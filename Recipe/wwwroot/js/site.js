// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.
const testBtn = document.getElementById("test");
const testSearch = document.getElementById("textSearch");
testBtn.addEventListener('click', (e) => {
    e.preventDefault();
    const searchVal = testSearch.value
    const url = "http://www.themealdb.com/api/json/v1/1/filter.php?i=" + searchVal; 
    fetch(url)
        .then(response => response.json())
        .then(data => console.log(data));

})
// Write your JavaScript code.
