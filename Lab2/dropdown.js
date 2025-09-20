var dropdown = document.querySelector("select#dropdown");

dropdown.value = "1";

setTimeout(() => {
  dropdown.value = "2";
}, 5000);
