var table = document.querySelector('table');
var buttons = table.querySelectorAll('button');
var hideButton = document.getElementById('hideButton');

hideButton.click();

buttons.forEach(btn => {
  if (btn === hideButton) return;
  var r = btn.getBoundingClientRect();
  var style = getComputedStyle(btn);

  let visible =
    document.body.contains(btn) &&
    style.display !== 'none' &&
    style.visibility !== 'hidden' &&
    style.opacity !== '0' &&
    r.width > 0 && r.height > 0 &&
    r.bottom > 0 && r.right > 0 &&
    r.top < window.innerHeight && r.left < window.innerWidth;

  if (visible) {
    var cx = r.left + r.width / 2;
    var cy = r.top + r.height / 2;
    var el = document.elementFromPoint(cx, cy);
    visible = el === btn || btn.contains(el);
  }

  console.log(btn.id || btn.textContent.trim(), visible ? 'видна' : 'скрыта');
});
