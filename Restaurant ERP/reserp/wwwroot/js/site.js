// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
function showTab(event, tabId) {
    // 모든 탭 버튼과 콘텐츠 비활성화
    const tabButtons = document.querySelectorAll('.tab-btn');
    const tabPanes = document.querySelectorAll('.tab-pane');

    tabButtons.forEach(button => button.classList.remove('active'));
    tabPanes.forEach(pane => pane.classList.remove('active'));

    // 클릭한 버튼과 해당 콘텐츠 활성화
    event.currentTarget.classList.add('active');
    document.getElementById(tabId).classList.add('active');
}
