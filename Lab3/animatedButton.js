document.getElementById('animationButton').click();

var target = document.getElementById('movingTarget');

var observer = new MutationObserver(() => {
  if (!target.classList.contains('spin')) {
    observer.disconnect();
    target.click();
  }
});

observer.observe(target, { attributes: true, attributeFilter: ['class'] });
