function waitForElement(selector) {
  return new Promise((resolve, reject) => {
    const element = document.querySelector(selector);
    if (element) return resolve(element);

    const observer = new MutationObserver(() => {
      const el = document.querySelector(selector);
      if (el) {
        observer.disconnect();
        resolve(el);
      }
    });

    observer.observe(document.body, { childList: true, subtree: true });
  });
}


function waitForButton(label) {
  return new Promise((resolve, reject) => {
    const findBtn = () =>
      [...document.querySelectorAll("button")].find(
        (btn) => btn.textContent.trim() === label
      );

    var btn = findBtn();
    if (btn) return resolve(btn);

    const observer = new MutationObserver(() => {
      btn = findBtn();
      if (btn) {
        observer.disconnect();
        resolve(btn);
      }
    });

    observer.observe(document.body, { childList: true, subtree: true });
  });
}


function waitForAttributeRemoval(selector, attribute) {
  return new Promise((resolve, reject) => {
    const el = document.querySelector(selector);
    if (el && !el.hasAttribute(attribute)) return resolve(el);

    const observer = new MutationObserver(() => {
      const elNow = document.querySelector(selector);
      if (elNow && !elNow.hasAttribute(attribute)) {
        observer.disconnect();
        resolve(elNow);
      }
    });

    observer.observe(document.body, { childList: true, subtree: true, attributes: true });
  });
}

async function task1() {
  const checkbox = await waitForElement("input[type='checkbox']");
  checkbox.click();

  await new Promise(r => setTimeout(r, 2000));

  const removeBtn = await waitForButton("Remove");
  removeBtn.click();

  const addBtn = await waitForButton("Add");
  addBtn.click();

  const newCheckbox = await waitForElement("input[type='checkbox']");
  newCheckbox.click();
}

async function task2() {
  const enableBtn = await waitForButton("Enable");
  enableBtn.click();

  const textInput = await waitForAttributeRemoval("input[type='text']", "disabled");

  textInput.value = "Hello world!";

  const disableBtn = await waitForButton("Disable");
  disableBtn.click();
}

async function run() {
  await Promise.all([task1(), task2()]);
}

run();
