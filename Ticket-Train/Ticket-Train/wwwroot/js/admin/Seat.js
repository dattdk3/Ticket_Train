$(document).ready(function () {
    $('#seatForm').on('submit', function (e) {
        e.preventDefault();

        const data = {
            trainId: $('#TrainId').val(),
            scheduleId: $('#ScheduleId').val(),
            status: $('#Status').val(),
            price: $('#Price').val()
        };

        $.ajax({
            type: 'POST',
            url: '/Seat/CreateSeat',
            contentType: 'application/json',
            data: JSON.stringify(data),
            success: function (response) {
                if (response.success) {
                    alert(response.message);
                    window.location.href = '/Seat/ShowView';
                }
            },
            error: function (xhr) {
                alert(xhr.responseJSON.message);
            }
        });
    });


    $('#updateSeatForm').submit(function (event) {
        event.preventDefault();

        var seatId = $('#SeatId').val();
        var updatedTrainId = $('#UpdateTrainId').val();
        var updatedScheduleId = $('#UpdateScheduleId').val();
        var updatedStatus = $('#UpdateStatus').val();
        var updatedPrice = $('#UpdatePrice').val();

        var data = {
            SeatId: seatId,
            TrainId: updatedTrainId,
            ScheduleId: updatedScheduleId,
            Status: updatedStatus,
            Price: updatedPrice
        }
        $.ajax({
            url: `/Seat/EditSeat`,
            type: 'PUT',
            contentType: 'application/json',
            data: JSON.stringify(data),
            success: function (response) {
                alert("Cập nhật ghế thành công!");
                location.reload();
            },
            error: function () {
                alert("Không thể cập nhật ghế.");
            }
        });
    });

});

function editSeat(seatId) {
    // Gọi API để lấy thông tin trạm
    $.ajax({
        url: `/Seat/ShoweditForm/${seatId}`, // Đường dẫn API cho chi tiết trạm
        type: 'GET',
        success: function (data) {

            console.log(data);

            $('#SeatId').val(data.data.seatId);
            $('#UpdateTrainId').val(data.data.trainId);
            $('#UpdateScheduleId').val(data.data.scheduleId);
            $('#UpdateStatus').val(data.data.status);
            $('#UpdatePrice').val(data.data.price);
            $('#btnUpdate').prop('disabled', false);
        },
        error: function () {
            alert("Không thể lấy thông tin ghế.");
        }
    });
}

function deleteSeat(seatId) {
    // Gọi API để lấy thông tin trạm
    $.ajax({
        url: `/Seat/delete/${seatId}`, // Đường dẫn API cho chi tiết trạm
        type: 'PUT',
        success: function (response) {

            alert("Xoá ghế thành công!");
            location.reload();
        },
        error: function () {
            alert("Không thể lấy thông tin ghế.");
        }
    });
}