

// Register api 
    $('#register').on('submit', function (e) {
        e.preventDefault();

        const userData = {
            email: $('#registerEmail').val(),
            password: $('#registerPassword').val(),
            name: $('#registerName').val()
        };

        $.ajax({
            type: 'POST',
            url: '/Account/register',
            contentType: 'application/json',
            data: JSON.stringify(userData),
            success: function (response) {
                alert(response.message); // Thông báo đăng ký thành công
            },
            error: function (xhr) {
                alert(xhr.responseJSON.message); // Thông báo lỗi đăng ký
            }
        });
    });

    // Login api 
    $('#login').on('submit', function (e) {
        e.preventDefault();

    const loginData = {
        email: $('#loginEmail').val(),
    password: $('#loginPassword').val()
        };

    $.ajax({
        type: 'POST',
    url: '/Account/login',
    contentType: 'application/json',
    data: JSON.stringify(loginData),
    success: function (response) {
        alert(response.message); // Thông báo đăng nhập thành công
    window.location.href = '/home/index'; // Chuyển hướng tới trang Home
            },
    error: function (xhr) {
        alert(xhr.responseJSON.message); // Thông báo lỗi đăng nhập
            }
        });
    });

