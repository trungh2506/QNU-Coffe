
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

//btn dropdown
function DropDownMenu1() {
    var dropdown = document.querySelector('.icon');
    var sub = document.querySelector('.sub-menu1');
    sub.classList.toggle('active');
}
function DropDownMenu2() {
    var dropdown = document.querySelector('.icon');
    var sub = document.querySelector('.sub-menu2');
    sub.classList.toggle('active');
}
function DropDownMenu3() {
    var dropdown = document.querySelector('.icon');
    var sub = document.querySelector('.sub-menu3');
    sub.classList.toggle('active');
}



