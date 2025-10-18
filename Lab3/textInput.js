var input = document.getElementById('newButtonName');
input.focus();

for (var ch of 'Hello World!') {
  input.dispatchEvent(new KeyboardEvent('keydown', {key: ch}));
  input.value += ch;
  input.dispatchEvent(new InputEvent('input', {data: ch, inputType: 'insertText'}));
  input.dispatchEvent(new KeyboardEvent('keyup', {key: ch}));
}

input.dispatchEvent(new Event('change', {bubbles: true}));
document.getElementById('updatingButton').click();