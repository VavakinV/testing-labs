document.getElementById('enableButton').click();

var input = document.getElementById('inputField');

var observer = new MutationObserver(() => {
  if (!input.disabled) {
    observer.disconnect();
    input.focus();
    input.value = 'Hello world';
    input.dispatchEvent(new Event('input', { bubbles: true }));
  }
});

observer.observe(input, { attributes: true, attributeFilter: ['disabled'] });
