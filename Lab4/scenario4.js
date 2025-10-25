function setInputValue(el, val) {
    var setter = Object.getOwnPropertyDescriptor(el.__proto__, 'value').set;
    setter.call(el, val);
    el.dispatchEvent(new Event('input', { bubbles: true }));
}

var wait = ms => new Promise(r => setTimeout(r, ms));

// 1. Логин
setInputValue(document.querySelector('#user-name'), 'performance_glitch_user');
setInputValue(document.querySelector('#password'), 'secret_sauce');
document.querySelector('#login-button').click();

// 2. Подождать, пока страница "отлагает"
await wait(2000);

// 3. Открыть описание первого товара и добавить в корзину
document.querySelectorAll('.inventory_item')[0].querySelector('a').click();
await wait(2000);
document.querySelector('.inventory_details_desc_container button').click();

// 4. Вернуться к списку товаров
window.history.back();
await wait(2000);

// 5. Сортировать по цене (low-high)
var sel = document.querySelector('.product_sort_container');
sel.value = 'lohi';
sel.dispatchEvent(new Event('change', { bubbles: true }));
await wait(2000);

// 6. Добавить товар стоимостью $49.99
var items = Array.from(document.querySelectorAll('.inventory_item'));
var target = items.find(i => i.querySelector('.inventory_item_price').textContent === '$49.99');
if (target) target.querySelector('.pricebar button').click();

// 7. Разлогиниться
await wait(2000);
document.querySelector('#react-burger-menu-btn').click();
await wait(2000);
document.querySelector('.bm-menu-wrap #logout_sidebar_link').click();