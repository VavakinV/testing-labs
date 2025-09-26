var slider = document.querySelector('input[type="range"]');

if (slider) {
  slider.value = 0;
  slider.dispatchEvent(new Event("change", { bubbles: true }));

  var current = 0;
  const max = 5;
  const step = 0.5;

  const interval = setInterval(() => {
    current += step;
    slider.value = current;
    slider.dispatchEvent(new Event("change", { bubbles: true }));

    if (current >= max) {
      clearInterval(interval);
      slider.dispatchEvent(new Event("change", { bubbles: true }));
    }
  }, 1000);
}
