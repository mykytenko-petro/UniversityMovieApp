// elements
const modal = document.querySelector("#auth-modal") as HTMLDialogElement;

const authButton = document.querySelector("#auth-button") as HTMLButtonElement;
const closeModalButton = document.querySelector("#auth-modal-close") as HTMLButtonElement;

const loginBtn = document.getElementById("tab-login-btn") as HTMLButtonElement;
const registerBtn = document.getElementById("tab-register-btn") as HTMLButtonElement;

const loginForm = document.getElementById("login-form") as HTMLFormElement;
const registerForm = document.getElementById("register-form") as HTMLFormElement;

// logic
authButton.onclick = () => modal.showModal()
closeModalButton.onclick = () => modal.close()

loginBtn.addEventListener("click", () => {
    loginForm.style.display = "block";
    registerForm.style.display = "none";
});

registerBtn.addEventListener("click", () => {
    loginForm.style.display = "none";
    registerForm.style.display = "block";
});