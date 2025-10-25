// 1. Вход под пользователем locked_out_user
function setInputValue(el, val) {
  var setter = Object.getOwnPropertyDescriptor(el.__proto__, 'value').set;
  setter.call(el, val);
  el.dispatchEvent(new Event('input', { bubbles: true }));
}

setInputValue(document.querySelector('#user-name'), 'locked_out_user');
setInputValue(document.querySelector('#password'), 'secret_sauce');
document.querySelector('#login-button').click();

// 2. Проверка сообщения об ошибке
const errorText = document.querySelector('.error-message-container').textContent.trim();
console.log('Сообщение об ошибке:', errorText);