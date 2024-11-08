$(document).ready(function () {
    $('#stationform').on('submit', function (e) {
        e.preventDefault();

        const data = {
            Name: $('#StationName').val()
        };

        $.ajax({
            type: 'POST',
            url: '/Station/CreateStation',
            contentType: 'application/json',
            data: JSON.stringify(data),
            success: function (response) {
                if (response.success) {
                    alert(response.message);
                    window.location.href = '/Station/ShowView';
                }
            },
            error: function (xhr) {
                alert(xhr.responseJSON.message);
            }
        });
    });


    $('#updateForm').submit(function (event) {
        event.preventDefault();

        var stationId = $('#StationId').val();
        var updatedName = $('#UpdateStationName').val();

        var data = {
            StationId: stationId,
            Name: updatedName
        }
        $.ajax({
            url: `/Station/EditStation`,
            type: 'PUT',
            contentType: 'application/json',
            data: JSON.stringify(data),
            success: function (response) {
                alert("Cập nhật trạm thành công!");
                location.reload();
            },
            error: function () {
                alert("Không thể cập nhật trạm.");
            }
        });
    });

});

function editStation(stationId) {
    // Gọi API để lấy thông tin trạm
    $.ajax({
        url: `/Station/ShoweditForm/${stationId}`, // Đường dẫn API cho chi tiết trạm
        type: 'GET',
        success: function (data) {

            console.log(data);

            $('#StationId').val(data.data.stationId);
            $('#UpdateStationName').val(data.data.name);
            $('#btnUpdate').prop('disabled', false);
        },
        error: function () {
            alert("Không thể lấy thông tin trạm.");
        }
    });
}
