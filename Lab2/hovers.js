const captions = document.querySelectorAll('.figcaption');
captions.forEach(el => {
    el.style.display = 'block';
  });

setTimeout(() => {
    const link = captions[1].querySelector("a");
    link.click();
}, 10000);
