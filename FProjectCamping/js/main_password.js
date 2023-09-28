function passwordDisplay(inputElement) {
    var password = inputElement.value;
    console.log(password);
}

function togglePasswordVisibility(iconElement) {
    var passwordInput = iconElement.closest('.pwdarea').querySelector('input');
    if (passwordInput.type === 'password') {
        passwordInput.type = 'text';
        iconElement.classList.remove('bi-eye-slash-fill');
        iconElement.classList.add('bi-eye-fill');
    } else {
        passwordInput.type = 'password';
        iconElement.classList.remove('bi-eye-fill');
        iconElement.classList.add('bi-eye-slash-fill');
    }
}