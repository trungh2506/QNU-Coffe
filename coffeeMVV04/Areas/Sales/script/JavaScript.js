
//hover menu
var list = document.querySelectorAll('.navigation li');
function activeLink() {
    list.forEach((item) => item.classList.remove('hovered'));
    this.classList.add('hovered');
}
list.forEach((item) => item.addEventListener('mouseover', activeLink));

// btn hamburger
function toggle() {
    var navigation = document.querySelector('.navigation');
    var main = document.querySelector('.main');
    navigation.classList.toggle('active');
    main.classList.toggle('active');
}
const getTable = urlParams.get('NumTb');
//var tb1 = document.getElementById('tb1');
//var tb2 = document.getElementById('tb2');
//var tb3 = document.getElementById('tb3');
//var tb4 = document.getElementById('tb4');
//var tb5 = document.getElementById('tb5');
//var tb6 = document.getElementById('tb6');

//table free to online
//tb1.addEventListener("click", function swap() { tb1.classList.toggle('active') });
//tb2.addEventListener("click", function swap() { tb2.classList.toggle('active') });
//tb3.addEventListener("click", function swap() { tb3.classList.toggle('active') });
//tb4.addEventListener("click", function swap() { tb4.classList.toggle('active') });
//tb5.addEventListener("click", function swap() { tb5.classList.toggle('active') });
//tb6.addEventListener("click", function swap() { tb6.classList.toggle('active') });





