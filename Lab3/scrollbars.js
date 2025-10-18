var div = document.querySelector('div[style="height:150px;overflow-y: scroll;width:300px;overflow-x:scroll"]');

div.scrollTop = div.scrollHeight;
div.scrollLeft = div.scrollWidth;

setTimeout(() => {
var btn = document.getElementById('hidingButton');
btn.click();
}, 300);