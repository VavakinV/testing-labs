function setInputValue(el, val) {
var setter = Object.getOwnPropertyDescriptor(el.__proto__, 'value').set;
setter.call(el, val);
el.dispatchEvent(new Event('input', { bubbles: true }));
}

// 1. Вход в пользователя error_user
setInputValue(document.querySelector('#user-name'), 'error_user');
setInputValue(document.querySelector('#password'), 'secret_sauce');
document.querySelector('#login-button').click();

// 2. Добавить товары в корзину
const addButtons = document.querySelectorAll('.inventory_item .pricebar button');
addButtons.forEach(btn => btn.click());
console.log(`Добавлено товаров: ${addButtons.length}`);

// 3. Проверить, все ли добавились
const removeButtons = document.querySelectorAll('.inventory_item .pricebar button');
const addedCount = Array.from(removeButtons).filter(b => b.textContent === 'Remove').length;
console.log(addedCount === addButtons.length
? 'Все товары успешно добавлены'
: `Добавлены не все товары: ${addedCount}/${addButtons.length}`);

// 4. Убрать все добавленные товары
removeButtons.forEach(btn => {
if (btn.textContent === 'Remove') btn.click();
});


// 5. Проверить, всё ли убрано
const remaining = Array.from(document.querySelectorAll('.inventory_item .pricebar button'))
.filter(b => b.textContent === 'Remove').length;
console.log(remaining === 0
? 'Все товары удалены'
: `Осталось неубранных: ${remaining}`);

// 6. Перейти в корзину и нажать Checkout
document.querySelector('a.shopping_cart_link').click();
document.querySelector('button#checkout').click();

// 7. Ввести test, autotest, 123
setInputValue(document.querySelector('#first-name'), 'test');
setInputValue(document.querySelector('#last-name'), 'autotest');
setInputValue(document.querySelector('#postal-code'), '123');

// 8. Попробовать нажать Continue и Finish
document.querySelector('#continue').click();
const finishBtn = document.querySelector('#finish');
if (finishBtn) {
finishBtn.click();
console.log('Finish нажата');
} else {
console.warn('Кнопка Finish недоступна');
}