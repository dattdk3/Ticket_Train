document.addEventListener('DOMContentLoaded', function () {
    // Lấy thông tin ghế và tổng giá trị từ sessionStorage
    const selectedSeats = JSON.parse(sessionStorage.getItem('selectedSeats')) || [];
    const totalPrice = sessionStorage.getItem('totalPrice') || '0 VND';

    // Hiển thị thông tin ghế và tổng giá trị
    document.getElementById('selectedSeatsDisplay').textContent = selectedSeats.length > 0 ? selectedSeats.join(', ') : 'Chưa chọn ghế';
    document.getElementById('totalPrice').textContent = totalPrice;

    // Xử lý sự kiện nhấn nút "Thành toán"
    document.getElementById('confirmPayment').addEventListener('click', function () {
        const name = document.getElementById('customerName').value;
        const email = document.getElementById('customerEmail').value;
        const phone = document.getElementById('customerPhone').value;
        const paymentMethod = document.getElementById('paymentMethod').value;

        if (!name || !email || !phone || !paymentMethod) {
            alert('Vui lòng điền đầy đủ thông tin!');
            return;
        }

        // Giả lập xử lý thanh toán
        alert(`Thanh toán thành công!\nTên: ${name}\nEmail: ${email}\nSố điện thoại: ${phone}\nPhương thức: ${paymentMethod}\nTổng số ghế: ${selectedSeats.length}\nTổng giá trị: ${totalPrice}`);

        // Chuyển sang trang thành toán
        window.location.href = 'payment-success.html'; // Chuyển đến trang thành công
    });
});
