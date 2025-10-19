var table = document.querySelector('div[role="table"]');
var header = table.querySelector('[role="rowgroup"]');
var cpuIndex = [...header.querySelectorAll('[role="columnheader"], [role="cell"]')]
  .findIndex(c => c.textContent.trim() === 'CPU');

var rows = table.querySelectorAll('div[role="rowgroup"] div[role="row"]');
var chromeRow = [...rows].find(r => r.querySelector('[role="cell"]')?.textContent.trim() === 'Chrome');
var cpuValue = chromeRow?.querySelectorAll('[role="cell"]')[cpuIndex]?.textContent.trim();

var pValue = document.querySelector('p.bg-warning')?.textContent.match(/[\d.]+%/)?.[0];

console.log('Из таблицы:', cpuValue, '| Из <p>:', pValue, '| Совпадает:', cpuValue === pValue);
