const newText = "Helloooooooooooooooooooooo";

const div = document.querySelector('#sibling-41\\.1');
div.childNodes[0].nodeValue = newText;

const cell = document.querySelector('tr.row-41 td.column-1');
cell.textContent = newText;
