document.getElementById('startButton').click();

var progress = document.querySelector('div.progress');
var observer = new MutationObserver(() => {
  var value = progress.textContent.trim();
  if (value === '75%') {
    document.getElementById('stopButton').click();
    observer.disconnect();
  }
});

observer.observe(progress, { childList: true, subtree: true, characterData: true });
