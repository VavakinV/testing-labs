var usernameInput = document.querySelector("input[name='username']");
if (usernameInput) {
  usernameInput.value = "tomsmith";
}

var passwordInput = document.querySelector("input[name='password']");
if (passwordInput) {
  passwordInput.value = "SuperSecretPassword!";
}

var submitButton = document.querySelector("button[type='submit']");
if (submitButton) {
  submitButton.click();
}
