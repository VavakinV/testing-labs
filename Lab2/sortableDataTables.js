function findHeaderBySpan(table, text) {
  return Array.from(table.querySelectorAll("th"))
    .find(th => {
      const span = th.querySelector("span");
      return span && span.textContent.trim() === text;
    });
}

const table1 = document.querySelector("#table1");
const table2 = document.querySelector("#table2");

[table1, table2].forEach(tbl => {
const th = findHeaderBySpan(tbl, "First Name");
th.click();
});

setTimeout(() => {
[table1, table2].forEach(tbl => {
    const th = findHeaderBySpan(tbl, "Due");
    th.click();
});
}, 5000);
