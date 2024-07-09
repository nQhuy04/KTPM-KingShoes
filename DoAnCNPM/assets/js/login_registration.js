document.addEventListener('DOMContentLoaded', function () {
    // Chuyển đổi từ form đăng nhập sang form đăng ký
    document.querySelector('.go_to_register_button').addEventListener('click', function (event) {
        event.preventDefault();
        document.getElementById('login_form').style.display = 'none';
        document.getElementById('register_form').style.display = 'block';
    });

    // Chuyển đổi từ form đăng ký về form đăng nhập
    document.querySelector('.go_to_login_button').addEventListener('click', function (event) {
        event.preventDefault();
        document.getElementById('register_form').style.display = 'none';
        document.getElementById('login_form').style.display = 'block';
    });

    const usernameInput = document.getElementById('username');
    const passwordInput = document.getElementById('password');
    const confirmPasswordInput = document.getElementById('confirm-password');
    const usernameError = document.getElementById('username-error');
    const passwordError = document.getElementById('password-error');
    const confirmPasswordError = document.getElementById('confirm-password-error');
    const registerButton = document.querySelector('.Register_button');

    function validateUsername(username) {
        const usernameRegex = /^[a-zA-Z0-9]{3,}$/;
        return usernameRegex.test(username);
    }

    function validatePassword(password) {
        const passwordRegex = /^(?=.*[a-zA-Z])(?=.*[0-9]).{8,}$/;
        return passwordRegex.test(password);
    }

    registerButton.addEventListener('click', function (event) {
        event.preventDefault();
        let valid = true;

        // Reset error messages
        usernameError.textContent = '';
        passwordError.textContent = '';
        confirmPasswordError.textContent = '';

        // Validate username
        if (!usernameInput.value) {
            usernameError.textContent = ' Tên đăng nhập không được để trống.';
            valid = false;
        } else if (!validateUsername(usernameInput.value)) {
            usernameError.textContent = ' Tên đăng nhập phải dài tối thiểu 3 ký tự và chỉ chứa a-z, A-Z, 0-9.';
            valid = false;
        }

        // Validate password
        if (!passwordInput.value) {
            passwordError.textContent = ' Mật khẩu không được để trống.';
            valid = false;
        } else if (!validatePassword(passwordInput.value)) {
            passwordError.textContent = ' Mật khẩu phải bao gồm cả chữ và số và dài tối thiểu 8 ký tự.';
            valid = false;
        }

        // Validate confirm password
        if (!confirmPasswordInput.value) {
            confirmPasswordError.textContent = ' Mật khẩu nhập lại không được để trống.';
            valid = false;
        } else if (confirmPasswordInput.value !== passwordInput.value) {
            confirmPasswordError.textContent = ' Mật khẩu nhập lại không trùng khớp.';
            valid = false;
        }

        // If all validations pass
        if (valid) {
            document.getElementById('register_form').style.display = 'none';
            document.getElementById('login_form').style.display = 'block';
        }


        //chuyen
        const registerButton = document.querySelector('.Register_button');
        const loginButton = document.querySelector('.Login_button');

        registerButton.addEventListener('click', function (event) {
            event.preventDefault();
            let valid = true;

            // Validation logic here...

            // If all validations pass
            if (valid) {
                document.getElementById('register_form').style.display = 'none';
                document.getElementById('login_form').style.display = 'block';
            }
        });

        loginButton.addEventListener('click', function (event) {
            event.preventDefault();

            // Simulate successful login for demonstration
            // Replace this with your actual login validation logic
            const isLoggedIn = true; // Replace with actual login logic

            if (isLoggedIn) {
                // Redirect to Home.html
                window.location.href = 'Home.html';
            } else {
                // Handle login failure if needed
                alert('Đăng nhập không thành công. Vui lòng kiểm tra lại tên đăng nhập và mật khẩu.');
            }
        });

    });


});
