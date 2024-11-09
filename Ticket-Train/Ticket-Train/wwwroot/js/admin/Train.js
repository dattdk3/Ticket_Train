$(document).ready(function () {
    $('#trainform').on('submit', function (e) {
        e.preventDefault();

        const data = {
            Name: $('#TrainName').val()
        };

        $.ajax({
            type: 'POST',
            url: '/Train/CreateTrain',
            contentType: 'application/json',
            data: JSON.stringify(data),
            success: function (response) {
                if (response.success) {
                    alert(response.message);
                    window.location.href = '/Train/ShowView';
                }
            },
            error: function (xhr) {
                alert(xhr.responseJSON.message);
            }
        });
    });
    $('#updateForm').submit(function (event) {
        event.preventDefault();

        var stationId = $('#TrainId').val();
        var updatedName = $('#UpdateTrainName').val();

        var data = {
            TrainId: TrainId,
            Name: updatedName
        }
        $.ajax({
            url: `/Train/EditTrain`,
            type: 'PUT',
            contentType: 'application/json',
            data: JSON.stringify(data),
            success: function (response) {
                alert("Cập nhật tàu thành công!");
                location.reload();
            },
            error: function () {
                alert("Không thể cập nhật trạm.");
            }
        });
    });

});

function editTrain(trainId) {
    // Gọi API để lấy thông tin trạm
    $.ajax({
        url: `/Train/ShoweditForm/${trainId}`, // Đường dẫn API cho chi tiết trạm
        type: 'GET',
        success: function (data) {

            console.log(data);

            $('#TrainId').val(data.data.trainId);
            $('#UpdateTrainName').val(data.data.name);
            $('#btnUpdate').prop('disabled', false);
        },
        error: function () {
            alert("Không thể lấy thông tin trạm.");
        }
    });
}

function deleteTrain(stationId) {
    // Gọi API để lấy thông tin trạm
    $.ajax({
        url: `/Train/delete/${stationId}`, // Đường dẫn API cho chi tiết trạm
        type: 'PUT',
        success: function (response) {

            alert("Xoá trạm thành công!");
            location.reload();
        },
        error: function () {
            alert("Không thể lấy thông tin trạm.");
        }
    });
}