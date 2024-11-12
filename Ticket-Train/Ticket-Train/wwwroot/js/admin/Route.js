$(document).ready(function () {
    $('#routeForm').on('submit', function (e) {
        e.preventDefault();

        const data = {
            OriginId: $('#OriginId').val(),
            DestinationId: $('#DestinationId').val(),
            Distance: $('#Distance').val()
        };
        console.log(data)

        $.ajax({
            type: 'POST',
            url: '/Route/CreateRoute',
            contentType: 'application/json',
            data: JSON.stringify(data),
            success: function (response) {
                if (response.success) {
                    alert(response.message);
                    window.location.href = '/Route/ShowView';
                }
            },
            error: function (xhr) {
                alert(xhr.responseJSON.message);
            }
        });
    });


    $('#updateRouteForm').submit(function (event) {
        event.preventDefault();

        var routeId = $('#RouteId').val();
        var updatedOriginId = $('#UpdateOriginId').val();
        var updatedDestinationId = $('#UpdateDestinationId').val();
        var updatedDistance = $('#UpdateDistance').val();

        var data = {
            RouteId: routeId,
            OriginId: updatedOriginId,
            DestinationId: updatedDestinationId,
            Distance: updatedDistance,
        }
        $.ajax({
            url: `/Route/EditRoute`,
            type: 'PUT',
            contentType: 'application/json',
            data: JSON.stringify(data),
            success: function (response) {
                alert("Cập nhật tuyến thành công!");
                location.reload();
            },
            error: function () {
                alert("Không thể cập nhật tuyến.");
            }
        });
    });

});


function editRoute(routeId) {
    // Gọi API để lấy thông tin trạm
    $.ajax({
        url: `/Route/ShoweditForm/${routeId}`, // Đường dẫn API cho chi tiết trạm
        type: 'GET',
        success: function (data) {

            console.log(data);

            $('#RouteId').val(data.data.routeId);
            $('#UpdateOriginId').val(data.data.originId);
            $('#UpdateDestinationId').val(data.data.destinationId);
            $('#UpdateDistance').val(data.data.distance);
            $('#btnUpdate').prop('disabled', false);
        },
        error: function () {
            alert("Không thể lấy thông tin ghế.");
        }
    });
}

function deleteRoute(routeId) {
    // Gọi API để lấy thông tin trạm
    $.ajax({
        url: `/Route/delete/${routeId}`, // Đường dẫn API cho chi tiết trạm
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