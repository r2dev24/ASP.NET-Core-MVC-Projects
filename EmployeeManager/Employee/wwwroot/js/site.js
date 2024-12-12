// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function loadDetails(employeeId) {
    // AJAX 요청으로 Partial View 데이터 로드
    $.ajax({
        url: '/Employee/Details', // URL을 직접 작성
        type: 'GET',
        data: { id: employeeId },
        success: function (data) {
            $('#modalBodyContent').html(data);
            $('#detailModal').modal('show');
        },
        error: function (xhr, status, error) {
            console.error('Error:', error);
            console.error('Status:', status);
            console.error('Response:', xhr.responseText);
            alert('Failed to load details. Please try again.');
        }
    });
}
