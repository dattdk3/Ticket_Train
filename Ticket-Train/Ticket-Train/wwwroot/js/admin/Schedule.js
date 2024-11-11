$(document).ready(function () {
    $('#scheduleForm').on('submit', function (e) {
        e.preventDefault();

        const data = {
            trainId: $('#TrainId').val(),
            routeId: $('#RouteId').val(),
            departure: $('#DepartureTime').val()
        };
        console.log(data)

        $.ajax({
            type: 'POST',
            url: '/Schedule/CreateSchedule',
            contentType: 'application/json',
            data: JSON.stringify(data),
            success: function (response) {
                if (response.success) {
                    alert(response.message);
                    window.location.href = '/Schedule/ShowView';
                }
            },
            error: function (xhr) {
                alert(xhr.responseJSON.message);
            }
        });
    });


    $('#updateScheduleForm').submit(function (event) {
        event.preventDefault();

        var scheduleId = $('#ScheduleId').val();
        var updatedTrainId = $('#UpdateTrainId').val();
        var updatedRouteId = $('#UpdateRouteId').val();
        var updatedDepartureTime = $('#UpdateDepartureTime').val();

        var data = {
            ScheduleId: scheduleId,
            TrainId: updatedTrainId,
            RouteId: updatedRouteId,
            DepartureTime: updatedDepartureTime,
        }
        $.ajax({
            url: `/Schedule/EditSchedule`,
            type: 'PUT',
            contentType: 'application/json',
            data: JSON.stringify(data),
            success: function (response) {
                alert("Cập nhật lịch trình thành công!");
                location.reload();
            },
            error: function () {
                alert("Không thể cập nhật lịch trình.");
            }
        });
    });

});

function editSchedule(scheduleId) {
    // Gọi API để lấy thông tin trạm
    $.ajax({
        url: `/Schedule/ShoweditForm/${scheduleId}`, // Đường dẫn API cho chi tiết trạm
        type: 'GET',
        success: function (data) {

            console.log(data);

            $('#ScheduleId').val(data.data.scheduleId);
            $('#UpdateTrainId').val(data.data.trainId);
            $('#UpdateRouteId').val(data.data.routeId);
            $('#UpdateDepartureTime').val(data.data.departureTime);
            $('#btnUpdate').prop('disabled', false);
        },
        error: function () {
            alert("Không thể lấy thông tin lịch trình.");
        }
    });
}

function deleteSchedule(scheduleId) {
    // Gọi API để lấy thông tin trạm
    $.ajax({
        url: `/Schedule/delete/${scheduleId}`, // Đường dẫn API cho chi tiết trạm
        type: 'PUT',
        success: function (response) {

            alert("Xoá tuyến thành công!");
            location.reload();
        },
        error: function () {
            alert("Không thể lấy thông tin tuyến.");
        }
    });
}