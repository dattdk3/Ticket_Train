$(document).ready(function () {
    $('#register').on('submit', function (e) {
        e.preventDefault();

        const userData = {
            Email: $('#registerEmail').val(),
            Password: $('#registerPassword').val(),
            Name: $('#registerName').val()
        };

        $.ajax({
            type: 'POST',
            url: '/Account/Register',
            contentType: 'application/json',
            data: JSON.stringify(userData),
            success: function (response) {
                if (response.success) {
                    alert(response.message); // Thông báo đăng ký thành công
                    window.location.href = '/Account/login';
                }
            },
            error: function (xhr) {
                alert(xhr.responseJSON.message); // Thông báo lỗi đăng ký
            }
        });
    });


    // for login
    console.log($('#login'));

    $('#login').on('submit', function (e) {
        e.preventDefault();

        const loginModel = {
            Email: $('#loginEmail').val(),
            Password: $('#loginPassword').val()
        };
        $.ajax({
            url: '/Account/Login',
            type: 'POST',
            contentType: 'application/json',
            data: JSON.stringify(loginModel),
            success: function (response) {
                console.log("respond" + response);
                if (response.success) {
                    alert(response.message);
                    // Kiểm tra role và điều hướng
                    if (response.role === 1) {
                        window.location.href = '/train/showview';
                    } else if (response.role === 2) {
                        window.location.href = '/home/index';
                    }
                } else {
                    alert(response.message);
                }
            },
        });
    });
});
