// 1. Вход под пользователем standard_user
function setInputValue(el, val) {
  var setter = Object.getOwnPropertyDescriptor(el.__proto__, 'value').set;
  setter.call(el, val);
  el.dispatchEvent(new Event('input', { bubbles: true }));
}
setInputValue(document.querySelector('#user-name'), 'problem_user');
setInputValue(document.querySelector('#password'), 'secret_sauce');
document.querySelector('#login-button').click();

// 2. Добавление товаров
function selectOption(value) {
  var sel = document.querySelector('.product_sort_container');
  sel.value = value;
  sel.dispatchEvent(new Event('change', { bubbles: true }));
}

function addToCartByIndex(idx) {
  var items = document.querySelectorAll('.inventory_item');
  items[idx].querySelector('.pricebar button').click();
}

selectOption('za');
addToCartByIndex(1);

selectOption('lohi');
addToCartByIndex(2);

selectOption('hilo');
var itemsHilo = document.querySelectorAll('.inventory_item');
addToCartByIndex(itemsHilo.length - 2);

selectOption('az');
var itemsAz = document.querySelectorAll('.inventory_item');
addToCartByIndex(itemsAz.length - 1);

// 3. Переход в корзину
document.querySelector('a.shopping_cart_link').click();

// 4. Переход к описанию второго товара
var secondCartItem = document.querySelectorAll('.cart_item')[1];
secondCartItem.querySelector('a').click();

// 5. Удаление товара
document.querySelector('.inventory_details_desc_container button').click();

// 6. Возврат в корзину
document.querySelector('a.shopping_cart_link').click();

// 7. Открыть товар с ценой $9.99
const item = Array.from(document.querySelectorAll('.cart_item'))
                  .find(el => el.querySelector('.inventory_item_price').textContent === '$9.99');
item.querySelector('a').click();

// 8. Удаление товара
document.querySelector('.inventory_details_desc_container button').click();

// 9. Возврат в корзину
document.querySelector('a.shopping_cart_link').click();

// 10. Нажатие checkout
document.querySelector('button#checkout').click();

// 11. Ввод данных и нажатие continue
setInputValue(document.querySelector('#first-name'), 'test');
setInputValue(document.querySelector('#last-name'), 'autotest');
setInputValue(document.querySelector('#postal-code'), '123');

document.querySelector('#continue').click();

// 12. Проверка общей суммы
var totalText = document.querySelector('.summary_total_label').textContent;
var totalValue = parseFloat(totalText.replace(/[^0-9.]/g, ''));
if(totalValue === 25.90){
  console.log('Цена верна: 25.90');
} else {
  console.error('Цена неверна:', totalValue);
}

// 13. Нажатие finish
document.querySelector('#finish').click();

// 14. Проверка сообщения об успехе
const headerText = document.querySelector('.header_secondary_container').textContent.trim();
if(headerText === 'Checkout: Complete!'){
  console.log('Текст верный: Checkout: Complete!');
} else {
  console.error('Текст неверный:', headerText);
}

// 15. Логаут
document.querySelector('#react-burger-menu-btn').click();
document.querySelector('.bm-menu-wrap #logout_sidebar_link').click();